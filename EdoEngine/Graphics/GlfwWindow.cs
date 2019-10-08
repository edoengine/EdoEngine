//=============================================================================
// EdoWindow.cs
//
// Created by Victor on 2019/08/22
//=============================================================================

using System.ComponentModel;
using Edo.Vfs;
using GLFW;

namespace Edo.Graphics
{
    /// <summary>
    /// Handles windows abstraction
    /// </summary>
    internal class GlfwWindow : IWindow
    {
        private NativeWindow _nativeWindow;
        private bool _closeCalled; // Safety check for GLFW window closing

        public bool Closing => _nativeWindow.IsClosing || _closeCalled;

        /// <summary>
        /// Constructs a new window
        /// </summary>
        /// <param name="width">Window width</param>
        /// <param name="height">Window height</param>
        /// <param name="title">Window title</param>
        public void Initialize(string title, int width, int height)
        {
            _nativeWindow = new NativeWindow(width, height, title);
            Glfw.MakeContextCurrent(_nativeWindow);
            
            // Load icon
            // TODO: This should come from the vfs
            //_nativeWindow.SetIcons(new ApplicationIcon("./application.png").ToImage());
            var icon = FileSystemManager.Load<ApplicationIcon>("windowicon");
            _nativeWindow.SetIcons(icon.ToImage());
            
            // Apply callbacks
            _nativeWindow.Closing += OnClosing;
        }

        ~GlfwWindow()
        {
            _nativeWindow.Dispose();
            Glfw.Terminate();
        }

        public bool HandleEvents()
        {
            Glfw.PollEvents();
            return !Closing; // TODO: Should this return for errors as well?
        }

        public void Swap()
        {
            _nativeWindow.SwapBuffers();
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            _closeCalled = true;
        }
    }
}