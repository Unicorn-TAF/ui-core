using System.Collections.Generic;

namespace Unicorn.UI.Core.Controls.Interfaces
{
    /// <summary>
    /// Interface for controls which have list of inner items.
    /// </summary>
    public interface IHasItems
    {
        /// <summary>
        /// Gets strings list representing items (item name/label/text)
        /// </summary>
        IList<string> Items { get; }
    }
}
