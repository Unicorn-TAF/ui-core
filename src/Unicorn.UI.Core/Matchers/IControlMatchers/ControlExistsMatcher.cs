using Unicorn.Taf.Core.Verification.Matchers;
using Unicorn.UI.Core.Controls;
using Unicorn.UI.Core.PageObject;

namespace Unicorn.UI.Core.Matchers.IControlMatchers
{
    /// <summary>
    /// Matcher to check if UI control exists.
    /// </summary>
    public class ControlExistsMatcher : TypeSafeMatcher<IControl>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlExistsMatcher"/> class.
        /// </summary>
        public ControlExistsMatcher()
        {
        }

        /// <summary>
        /// Gets check description.
        /// </summary>
        public override string CheckDescription => "exists";

        /// <summary>
        /// Checks if UI control exists.
        /// </summary>
        /// <param name="actual">UI control under check</param>
        /// <returns>true - if control exists; otherwise - false</returns>
        public override bool Matches(IControl actual)
        {
            if (actual == null)
            {
                DescribeMismatch("null");
                return Reverse;
            }

            bool exists = actual.ExistsInPageObject();
            DescribeMismatch(exists ? "exists" : "does not exist");
            return exists;
        }
    }
}
