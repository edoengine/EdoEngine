//=============================================================================
// EdoWindow.cs
//
// Created by Victor on 2019/08/22
//=============================================================================

using GLFW;

namespace Edo.Graphics
{
    /// <summary>
    /// Handles windows abstraction
    /// </summary>
    internal class EdoWindow
    {
        private NativeWindow _nativeWindow;

        internal int Width => _nativeWindow.Size.Width;

        internal int Height => _nativeWindow.Size.Height;

        internal bool Closing => _nativeWindow.IsClosing;

        /// <summary>
        /// Constructs a new window
        /// </summary>
        /// <param name="width">Window width</param>
        /// <param name="height">Window height</param>
        /// <param name="title">Window title</param>
        internal EdoWindow(int width, int height, string title)
        {
            _nativeWindow = new NativeWindow(width, height, title);
            Glfw.MakeContextCurrent(_nativeWindow);
        }

        ~EdoWindow()
        {
            _nativeWindow.Dispose();
            Glfw.Terminate();
        }

        internal void OnUpdate()
        {
            Glfw.PollEvents();
            _nativeWindow.SwapBuffers();
        }
    }
}