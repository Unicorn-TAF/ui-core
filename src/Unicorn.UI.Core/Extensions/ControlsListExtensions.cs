using System.Collections.Generic;
using System.Linq;
using Unicorn.UI.Core.Controls;

namespace Unicorn.UI.Core.Extensions
{
    /// <summary>
    /// Extensions for controls lists
    /// </summary>
    public static class ControlsListExtensions
    {
        /// <summary>
        /// Gets control from list by its text. When searching for the control its trimmed textContent is used.
        /// </summary>
        /// <typeparam name="T">desired control type</typeparam>
        /// <param name="controlsList">source controls list</param>
        /// <param name="text">control text to search by</param>
        /// <returns>first control from list matching desired text, exception is thrown if none found</returns>
        /// <exception cref="ControlNotFoundException"></exception>
        public static T GetByText<T>(this IEnumerable<T> controlsList, string text) where T : IControl =>
            GetByText(controlsList, text, true);

        /// <summary>
        /// Gets control from list by its text.
        /// </summary>
        /// <typeparam name="T">desired control type</typeparam>
        /// <param name="controlsList">source controls list</param>
        /// <param name="text">control text to search by</param>
        /// <param name="trimText">true if trim actual control text; otherwise - false</param>
        /// <returns>first control from list matching desired text, exception is thrown if none found</returns>
        /// <exception cref="ControlNotFoundException"></exception>
        public static T GetByText<T>(this IEnumerable<T> controlsList, string text, bool trimText) where T : IControl
        {
            T control = trimText ?
                controlsList.FirstOrDefault(b => b.Text.Trim().Equals(text)) :
                controlsList.FirstOrDefault(b => b.Text.Equals(text));

            return control != null ? control :
                throw new ControlNotFoundException($"{typeof(T).Name} with {(trimText ? "trimmed ": "")}text '{text}' was not found");
        }

        /// <summary>
        /// Determines whether list of controls has any control with specified text or not. 
        /// When searching for the control its trimmed textContent is used.
        /// </summary>
        /// <typeparam name="T">desired control type</typeparam>
        /// <param name="controlsList">source controls list</param>
        /// <param name="text">control text to search by</param>
        /// <returns>true - if control with specified text content exists in list; otherwise - false</returns>
        public static bool AnyWithText<T>(this IEnumerable<T> controlsList, string text) where T : IControl =>
            AnyWithText(controlsList, text, true);

        /// <summary>
        /// Determines whether list of controls has any control with specified text or not. 
        /// When searching for the control its trimmed textContent is used.
        /// </summary>
        /// <typeparam name="T">desired control type</typeparam>
        /// <param name="controlsList">source controls list</param>
        /// <param name="text">control text to search by</param>
        /// <param name="trimText">true if trim actual control text; otherwise - false</param>
        /// <returns>true - if control with specified text content exists in list; otherwise - false</returns>
        public static bool AnyWithText<T>(this IEnumerable<T> controlsList, string text, bool trimText) where T : IControl =>
            trimText ?
            controlsList.Any(b => b.Text.Trim().Equals(text)) :
            controlsList.Any(b => b.Text.Equals(text));

        /// <summary>
        /// Gets from list control which specified attribute contains expected substring.
        /// </summary>
        /// <typeparam name="T">desired control type</typeparam>
        /// <param name="controlsList">source controls list</param>
        /// <param name="attribute">attribute name</param>
        /// <param name="expectedPart">part of attribute value to search by</param>
        /// <returns>first control from list matching desired text, exception is thrown if none found</returns>
        /// <exception cref="ControlNotFoundException"></exception>
        public static T GetByAttributeContains<T>(this IEnumerable<T> controlsList, string attribute, string expectedPart) where T : IControl
        {
            T control = controlsList.FirstOrDefault(b => b.GetAttribute(attribute).Contains(expectedPart));
            return control != null ? control :
                throw new ControlNotFoundException($"{typeof(T).Name} with attribute '{attribute}' containing '{expectedPart}' was not found");
        }

        /// <summary>
        /// Determines whether list of controls has any control which specified attribute contains expected substring.
        /// </summary>
        /// <typeparam name="T">desired control type</typeparam>
        /// <param name="controlsList">source controls list</param>
        /// <param name="attribute">attribute name</param>
        /// <param name="expectedPart">part of attribute value to search by</param>
        /// <returns>true - if control with specified text content exists in list; otherwise - false</returns>
        public static bool AnyWithAttributeContains<T>(this IEnumerable<T> controlsList, string attribute, string expectedPart) where T : IControl =>
            controlsList.Any(b => b.GetAttribute(attribute).Contains(expectedPart));
    }
}
