namespace Unicorn.UI.Core.Controls.Interfaces
{
    /// <summary>
    /// Interface for controls which have a value.
    /// </summary>
    public interface IHasValue
    {
        /// <summary>
        /// Gets value as a <see cref="string"/>
        /// </summary>
        string Value { get; }
    }
}
