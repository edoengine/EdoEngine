//=============================================================================
// EdoWindow.cs
//
// Created by Victor on 2019/08/22
//=============================================================================

using System.ComponentModel;
using GLFW;

namespace Edo.Graphics
{
    /// <summary>
    /// Handles windows abstraction
    /// </summary>
    internal class EdoWindow
    {
        private NativeWindow _nativeWindow;
        private bool _closeCalled; // Safety check for GLFW window closing

        internal bool Closing => _nativeWindow.IsClosing || _closeCalled;

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
            
            // Load icon
            // TODO: This should come from the vfs
            _nativeWindow.SetIcons(new ApplicationIcon("./application.png").ToImage());
            
            // Apply callbacks
            _nativeWindow.Closing += OnClosing;
        }

        ~EdoWindow()
        {
            _nativeWindow.Dispose();
            Glfw.Terminate();
        }

        internal bool HandleEvents()
        {
            Glfw.PollEvents();
            return !Closing; // TODO: Should this return for errors as well?
        }

        internal void Swap()
        {
            _nativeWindow.SwapBuffers();
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            _closeCalled = true;
        }
    }
}