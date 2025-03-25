using System;
using System.Collections.Generic;
using Unicorn.Taf.Core.Utility;
using Unicorn.Taf.Core.Verification.Matchers;
using Unicorn.UI.Core.Controls.Interfaces;

namespace Unicorn.UI.Core.Matchers.TypifiedMatchers
{
    /// <summary>
    /// Matcher to check if control contains specified sub-items.
    /// </summary>
    public class ControlContainsItemsMatcher : TypeSafeMatcher<IHasItems>
    {
        private readonly IEnumerable<string> _expectedItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlContainsItemsMatcher"/> class with specified expected items.
        /// </summary>
        /// <param name="expectedItems">expected items</param>
        public ControlContainsItemsMatcher(params string[] expectedItems)
        {
            _expectedItems = expectedItems;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlContainsItemsMatcher"/> class with specified expected items.
        /// </summary>
        /// <param name="expectedItems">expected items</param>
        public ControlContainsItemsMatcher(IEnumerable<string> expectedItems)
        {
            _expectedItems = expectedItems;
        }

        /// <summary>
        /// Gets check description
        /// </summary>
        public override string CheckDescription =>
            "contains items: " + UiMatchersUtils.DescribeCollection(_expectedItems, 200);

        /// <summary>
        /// Checks if control contains specified sub-items.
        /// </summary>
        /// <param name="actual">control under check</param>
        /// <returns>true - if control contains specified sub-items; otherwise - false</returns>
        public override bool Matches(IHasItems actual)
        {
            if (actual == null)
            {
                DescribeMismatch("null");
                return Reverse;
            }

            CollectionsComparer<string> comparer = new CollectionsComparer<string>()
                .TrimOutputTo(1000)
                .UseItemsBulletsInOutput(">");

            bool result = Reverse ?
                !comparer.NotContains(actual.Items, _expectedItems)
                : comparer.Contains(actual.Items, _expectedItems);

            DescribeMismatch(Environment.NewLine + comparer.Output);

            return result;
        }
    }
}
