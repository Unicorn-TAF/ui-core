using Unicorn.Taf.Core.Verification.Matchers;
using Unicorn.UI.Core.Controls.Interfaces;

namespace Unicorn.UI.Core.Matchers.TypifiedMatchers
{
    /// <summary>
    /// Matcher to check if UI control has data validation error. 
    /// </summary>
    public class ControlHasValidationErrorMatcher : TypeSafeMatcher<IHasValueValidation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlHasValidationErrorMatcher"/> class.
        /// </summary>
        public ControlHasValidationErrorMatcher()
        {
        }

        /// <summary>
        /// Gets check description.
        /// </summary>
        public override string CheckDescription => "has validation error";

        /// <summary>
        /// Checks if UI control has data validation error.
        /// </summary>
        /// <param name="actual">UI control under check</param>
        /// <returns>true - if control has data validation error; otherwise - false</returns>
        public override bool Matches(IHasValueValidation actual)
        {
            if (actual == null)
            {
                DescribeMismatch("null");
                return Reverse;
            }

            bool hasValidationError = actual.HasValidationError;

            DescribeMismatch(hasValidationError ? "has validation error" : "data validation passed");

            return hasValidationError;
        }
    }
}
