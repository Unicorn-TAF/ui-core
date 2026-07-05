using System;
using Unicorn.Taf.Core.Verification.Matchers;
using Unicorn.UI.Core.Controls.Interfaces;
using Unicorn.UI.Core.Controls.Interfaces.Typified;

namespace Unicorn.UI.Core.Matchers.TypifiedMatchers
{
    /// <summary>
    /// Matcher to check if <see cref="IHasValue"/> UI control has specified value.
    /// </summary>
    public class InputHasValueMatcher : TypeSafeMatcher<IHasValue>
    {
        private readonly string _expectedValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckboxHasCheckStateMatcher"/> class with expected value.
        /// </summary>
        public InputHasValueMatcher(string isChecked)
        {
            _expectedValue = isChecked;
        }

        /// <summary>
        /// Gets check description.
        /// </summary>
        public override string CheckDescription => $"has value '{_expectedValue}'";

        /// <summary>
        /// Checks if control has specified value.
        /// </summary>
        /// <param name="actual">UI control under check</param>
        /// <returns>true - if control has expected value; otherwise - false</returns>
        public override bool Matches(IHasValue actual)
        {
            if (actual == null)
            {
                DescribeMismatch("null");
                return Reverse;
            }

            var actualValue = actual.Value;

            string mismatch = Reverse ?
                actualValue :
                Environment.NewLine + MatchersUtils.GetStringsDiff(_expectedValue, actualValue);

            DescribeMismatch(mismatch);

            return actualValue.Equals(_expectedValue);
        }
    }
}
