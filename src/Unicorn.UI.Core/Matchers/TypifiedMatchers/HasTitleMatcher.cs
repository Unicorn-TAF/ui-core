using System;
using Unicorn.Taf.Core.Verification.Matchers;
using Unicorn.UI.Core.Controls.Interfaces;

namespace Unicorn.UI.Core.Matchers.TypifiedMatchers
{
    /// <summary>
    /// Matcher to check if <see cref="IHasTitle"/> UI control has specified title. 
    /// </summary>
    public class HasTitleMatcher : TypeSafeMatcher<IHasTitle>
    {
        private readonly string _expectedTitle;

        /// <summary>
        /// Initializes a new instance of the <see cref="HasTitleMatcher"/> class.
        /// </summary>
        public HasTitleMatcher(string expectedTitle)
        {
            _expectedTitle = expectedTitle;
        }

        /// <summary>
        /// Gets check description.
        /// </summary>
        public override string CheckDescription => $"has title '{_expectedTitle}'";

        /// <summary>
        /// Checks if control has specified title.
        /// </summary>
        /// <param name="actual">UI control under check</param>
        /// <returns>true - if control has specified title; otherwise - false</returns>
        public override bool Matches(IHasTitle actual)
        {
            if (actual == null)
            {
                DescribeMismatch("null");
                return Reverse;
            }

            string actualTitle = actual.Title;

            string mismatch = Reverse ?
                actualTitle :
                Environment.NewLine + MatchersUtils.GetStringsDiff(_expectedTitle, actualTitle);

            DescribeMismatch(mismatch);

            return actualTitle.Equals(_expectedTitle);
        }
    }
}
