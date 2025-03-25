namespace Unicorn.UI.Core.Controls.Interfaces
{
    /// <summary>
    /// Interface for controls with drag-and-drop functionality.
    /// </summary>
    public interface IDraggable
    {
        /// <summary>
        /// Drags the control.
        /// </summary>
        void Drag();

        /// <summary>
        /// Drops the control to specified <see cref="IControl"/> control.
        /// </summary>
        /// <param name="destinationControl">control instance to drop to</param>
        void DropTo(IControl destinationControl);
    }
}
