using Unicorn.UI.Core.Controls;

namespace Unicorn.UI.Core.Synchronization.Conditions
{
    /// <summary>
    /// Represents conditions for <see cref="IControl"/> waits.
    /// </summary>
    public static class Until
    {
        /// <summary>
        /// Checks if element exist and visible.
        /// </summary>
        /// <typeparam name="TTarget">Target element type implementing <see cref="IControl"/></typeparam>
        /// <param name="element">target element</param>
        /// <returns><c>true</c> when element exist and <c>false</c> otherwise</returns>
        public static TTarget Visible<TTarget>(this TTarget element) where TTarget : class, IControl =>
            element.Visible ? element : null;

        /// <summary>
        /// Checks if element is not visible.
        /// </summary>
        /// <typeparam name="TTarget">Target element type implementing <see cref="IControl"/></typeparam>
        /// <param name="element">target element</param>
        /// <returns><c>true</c> when element is not visible <c>false</c> otherwise</returns>
        public static TTarget NotVisible<TTarget>(this TTarget element) where TTarget : class, IControl =>
            !element.Visible ? element : null;

        /// <summary>
        /// Checks if element enabled.
        /// </summary>
        /// <typeparam name="TTarget">Target element type implementing <see cref="IControl"/></typeparam>
        /// <param name="element">target element</param>
        /// <returns><c>true</c> when element enabled and <c>false</c> otherwise</returns>
        public static TTarget Enabled<TTarget>(this TTarget element) where TTarget : class, IControl =>
            element.Enabled ? element : null;

        /// <summary>
        /// Checks if element disabled.
        /// </summary>
        /// <typeparam name="TTarget">Target element type implementing <see cref="IControl"/></typeparam>
        /// <param name="element">target element</param>
        /// <returns><c>true</c> when element disabled and <c>false</c> otherwise</returns>
        public static TTarget Disabled<TTarget>(this TTarget element) where TTarget : class, IControl =>
            !element.Enabled ? element : null;

        /// <summary>
        /// Checks if element attribute contains expected value.
        /// </summary>
        /// <typeparam name="TTarget">Target element type implementing <see cref="IControl"/></typeparam>
        /// <param name="element">target element</param>
        /// <param name="attribute">element attribute</param>
        /// <param name="value">attribute value</param>
        /// <returns><c>element</c> when attribute contains expected value and <c>null</c> otherwise</returns>
        public static TTarget AttributeContains<TTarget>(this TTarget element, string attribute, string value) where TTarget : class, IControl =>
            element.GetAttribute(attribute).Contains(value) ? element : null;

        /// <summary>
        /// Checks if element attribute does not contain expected value.
        /// </summary>
        /// <typeparam name="TTarget">Target element type implementing <see cref="IControl"/></typeparam>
        /// <param name="element">target element</param>
        /// <param name="attribute">element attribute</param>
        /// <param name="value">attribute value</param>
        /// <returns><c>element</c> when attribute does not contain expected value and <c>null</c> otherwise</returns>
        public static TTarget AttributeDoesNotContain<TTarget>(this TTarget element, string attribute, string value) where TTarget : class, IControl =>
            !element.GetAttribute(attribute).Contains(value) ? element : null;

        /// <summary>
        /// Checks if element attribute has expected value.
        /// </summary>
        /// <typeparam name="TTarget">Target element type implementing <see cref="IControl"/></typeparam>
        /// <param name="element">target element</param>
        /// <param name="attribute">element attribute</param>
        /// <param name="value">attribute value</param>
        /// <returns><c>element</c> when attribute does not contain expected value and <c>null</c> otherwise</returns>
        public static TTarget AttributeHasValue<TTarget>(this TTarget element, string attribute, string value) where TTarget : class, IControl =>
            element.GetAttribute(attribute).Equals(value) ? element : null;

        /// <summary>
        /// Checks if element has expected attribute.
        /// </summary>
        /// <typeparam name="TTarget">Target element type implementing <see cref="IControl"/></typeparam>
        /// <param name="element">target element</param>
        /// <param name="attributeName">expected attribute name</param>
        /// <returns><c>element</c> when attribute exists and <c>null</c> otherwise</returns>
        public static TTarget HasAttribute<TTarget>(this TTarget element, string attributeName) where TTarget : class, IControl =>
            element.GetAttribute(attributeName) != null ? element : null;

        /// <summary>
        /// Checks if element does not have expected attribute.
        /// </summary>
        /// <typeparam name="TTarget">Target element type implementing <see cref="IControl"/></typeparam>
        /// <param name="element">target element</param>
        /// <param name="attributeName">expected attribute name</param>
        /// <returns><c>element</c> when attribute does not exist and <c>null</c> otherwise</returns>
        public static TTarget DoesNotHaveAttribute<TTarget>(this TTarget element, string attributeName) where TTarget : class, IControl =>
            element.GetAttribute(attributeName) == null ? element : null;

        /// <summary>
        /// Checks if element text has expected value.
        /// </summary>
        /// <typeparam name="TTarget">Target element type implementing <see cref="IControl"/></typeparam>
        /// <param name="element">target element</param>
        /// <param name="text">expected text</param>
        /// <returns><c>element</c> when text is equal to expected value and <c>null</c> otherwise</returns>
        public static TTarget HasText<TTarget>(this TTarget element, string text) where TTarget : class, IControl =>
            element.Text.Equals(text) ? element : null;

        /// <summary>
        /// Checks if element text contains expected value.
        /// </summary>
        /// <typeparam name="TTarget">Target element type implementing <see cref="IControl"/></typeparam>
        /// <param name="element">target element</param>
        /// <param name="textPart">expected text part</param>
        /// <returns><c>element</c> when text contains expected value and <c>null</c> otherwise</returns>
        public static TTarget ContainsText<TTarget>(this TTarget element, string textPart) where TTarget : class, IControl =>
            element.Text.Contains(textPart) ? element : null;

        /// <summary>
        /// Checks if element text does not contain expected value.
        /// </summary>
        /// <typeparam name="TTarget">Target element type implementing <see cref="IControl"/></typeparam>
        /// <param name="element">target element</param>
        /// <param name="textPart">text part</param>
        /// <returns><c>element</c> when text does not contain expected value and <c>null</c> otherwise</returns>
        public static TTarget DoesNotContainText<TTarget>(this TTarget element, string textPart) where TTarget : class, IControl =>
            !element.Text.Contains(textPart) ? element : null;
    }
}
