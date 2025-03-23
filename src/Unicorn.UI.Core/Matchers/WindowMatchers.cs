using System;
using Unicorn.UI.Core.Matchers.TypifiedMatchers;

namespace Unicorn.UI.Core.Matchers
{
    /// <summary>
    /// Entry point for Window matchers.
    /// </summary>
    public class WindowMatchers
    {
        /// <summary>
        /// Gets matcher to check if window has specified title.
        /// </summary>
        /// <param name="expectedTitle">expected window title</param>
        /// <returns>matcher instance</returns>
        [Obsolete("Use UI.Control.HasTitle instead")]
        public WindowHasTitleMatcher HasTitle(string expectedTitle) =>
            new WindowHasTitleMatcher(expectedTitle);

        /// <summary>
        /// Gets matcher to check if modal window has specified text content.
        /// </summary>
        /// <param name="expectedText">expected text content</param>
        /// <returns>matcher instance</returns>
        public ModalWindowHasTextMatcher HasText(string expectedText) =>
            new ModalWindowHasTextMatcher(expectedText);
    }
}
