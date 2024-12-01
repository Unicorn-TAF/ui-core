/// <summary>
/// Interface for controls which have values validation logic.
/// </summary>
namespace Unicorn.UI.Core.Controls.Interfaces
{
    public interface IHasValueValidation
    {
        /// <summary>
        /// Gets a value indicating whether control data validation failed or not.
        /// </summary>
        bool HasValidationError
        {
            get;
        }
    }
}
