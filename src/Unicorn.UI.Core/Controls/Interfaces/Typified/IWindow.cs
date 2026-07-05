using Unicorn.UI.Core.PageObject;

namespace Unicorn.UI.Core.Controls.Interfaces.Typified
{
    /// <summary>
    /// Interface for windows implementation.
    /// Has definitions of of basic methods and properties.
    /// Window is <see cref="IContainer"/>
    /// </summary>
    public interface IWindow : IContainer, IHasTitle
    {
        /// <summary>
        /// Closes window.
        /// </summary>
        void Close();
    }
}
