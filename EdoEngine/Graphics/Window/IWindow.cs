using System;

namespace EdoEngine.Graphics.Window
{
    /// <summary>
    /// Provides a way of interacting with windows to display app contents.
    /// </summary>
    internal interface IWindow : IDisposable
    {
        /// <summary>
        /// Has the window been closed.
        /// </summary>
        /// <returns>True if the window successfully closed.</returns>
        bool Closed();

        void Update();
    }
}
