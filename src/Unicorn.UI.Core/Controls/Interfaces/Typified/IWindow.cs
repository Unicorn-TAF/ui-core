using Unicorn.UI.Core.PageObject;

namespace Unicorn.UI.Core.Controls.Interfaces.Typified
{
    /// <summary>
    /// Interface for windows implementation. 
    /// Has definitions of basic methods and properties.
    /// </summary>
    public interface IWindow : IHasTitle
    {
        /// <summary>
        /// Closes window.
        /// </summary>
        void Close();
    }
}
