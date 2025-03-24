using System.Collections.Generic;
using Unicorn.UI.Core.Controls.Interfaces;
using Unicorn.UI.Core.Matchers.IControlMatchers;
using Unicorn.UI.Core.Matchers.TypifiedMatchers;

namespace Unicorn.UI.Core.Matchers
{
    /// <summary>
    /// Entry point for general control matchers.
    /// </summary>
    public class ControlMatchers
    {
        /// <summary>
        /// Matcher to check if UI control has specified attribute which contains expected value.
        /// </summary>
        /// <param name="attribute">attribute name</param>
        /// <param name="expectedValue">expected part of attribute value</param>
        /// <returns><see cref="AttributeContainsMatcher"/> instance</returns>
        public AttributeContainsMatcher HasAttributeContains(string attribute, string expectedValue) =>
            new AttributeContainsMatcher(attribute, expectedValue);

        /// <summary>
        /// Matcher to check if UI control has specified attribute with specified value.
        /// </summary>
        /// <param name="attribute">attribute name</param>
        /// <param name="expectedValue">expected attribute value</param>
        /// <returns><see cref="AttributeIsEqualToMatcher"/> instance</returns>
        public AttributeIsEqualToMatcher HasAttributeIsEqualTo(string attribute, string expectedValue) =>
            new AttributeIsEqualToMatcher(attribute, expectedValue);

        /// <summary>
        /// Matcher to check if  UI control is enabled.
        /// </summary>
        /// <returns><see cref="ControlEnabledMatcher"/> instance</returns>
        public ControlEnabledMatcher Enabled() =>
            new ControlEnabledMatcher();

        /// <summary>
        /// Matcher to check if UI control is visible.
        /// </summary>
        /// <returns><see cref="ControlVisibleMatcher"/> instance</returns>
        public ControlVisibleMatcher Visible() =>
            new ControlVisibleMatcher();

        /// <summary>
        /// Matcher to check if <see cref="ISelectable"/> UI control is selected.
        /// </summary>
        /// <returns><see cref="SelectedMatcher"/> instance</returns>
        public SelectedMatcher Selected() =>
            new SelectedMatcher();

        /// <summary>
        /// Matcher to check if <see cref="ISortable"/> UI control is sorted by specified direction.
        /// </summary>
        /// <param name="direction">sorting direction</param>
        /// <returns><see cref="SortedMatcher"/> instance</returns>
        public SortedMatcher Sorted(SortDirection direction) =>
            new SortedMatcher(direction);

        /// <summary>
        /// Matcher to check if UI control has specific text.
        /// </summary>
        /// <param name="expectedText">expected control text</param>
        /// <returns><see cref="ControlHasTextMatcher"/> instance</returns>
        public ControlHasTextMatcher HasText(string expectedText) =>
            new ControlHasTextMatcher(expectedText);

        /// <summary>
        /// Matcher to check if UI control has text matching specific regular expression.
        /// </summary>
        /// <param name="expectedTextRegex">regular expression</param>
        /// <returns><see cref="ControlHasTextMatchesMatcher"/> instance</returns>
        public ControlHasTextMatchesMatcher HasTextMatching(string expectedTextRegex) =>
            new ControlHasTextMatchesMatcher(expectedTextRegex);

        /// <summary>
        /// Matcher to check if <see cref="IHasValueValidation"/> UI control has validation errors.
        /// </summary>
        /// <returns><see cref="ControlHasValidationErrorMatcher"/> instance</returns>
        public ControlHasValidationErrorMatcher HasValidationError() =>
            new ControlHasValidationErrorMatcher();

        /// <summary>
        /// Gets matcher to check if control has specified title.
        /// </summary>
        /// <param name="expectedTitle">expected control title</param>
        /// <returns>matcher instance</returns>
        public HasTitleMatcher HasTitle(string expectedTitle) =>
            new HasTitleMatcher(expectedTitle);

        /// <summary>
        /// Gets matcher to check if control contains specified sub-items.
        /// </summary>
        /// <param name="expectedObjects">expected objects</param>
        /// <returns>matcher instance</returns>
        public ControlContainsItemsMatcher ContainsItems(IEnumerable<string> expectedObjects) =>
            new ControlContainsItemsMatcher(expectedObjects);

        /// <summary>
        /// Gets matcher to check if control contains specified sub-items.
        /// </summary>
        /// <param name="expectedObjects">expected objects</param>
        /// <returns>matcher instance</returns>
        public ControlContainsItemsMatcher ContainsItems(params string[] expectedObjects) =>
            new ControlContainsItemsMatcher(expectedObjects);

        /// <summary>
        /// Gets matcher to check if control has exactly specified sub-items (order ignored).
        /// </summary>
        /// <param name="expectedObjects">expected objects</param>
        /// <returns>matcher instance</returns>
        public ControlHasExactlyItemsMatcher HasExactlyItems(IEnumerable<string> expectedObjects) =>
            new ControlHasExactlyItemsMatcher(expectedObjects);

        /// <summary>
        /// Gets matcher to check if control has exactly specified sub-items (order ignored).
        /// </summary>
        /// <param name="expectedObjects">expected objects</param>
        /// <returns>matcher instance</returns>
        public ControlHasExactlyItemsMatcher HasExactlyItems(params string[] expectedObjects) =>
            new ControlHasExactlyItemsMatcher(expectedObjects);
    }
}
