namespace Unicorn.UI.Core.Controls.Interfaces
{
    /// <summary>
    /// Interface for controls which have a value.
    /// Has definitions of of basic methods and properties.
    /// </summary>
    public interface IHasValue
    {
        /// <summary>
        /// Gets control value.
        /// </summary>
        string Value
        {
            get;
        }
    }
}
