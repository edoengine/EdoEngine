using System;
using GLFW;

namespace EdoEngine.Graphics.Window
{
    /// <summary>
    /// Provides a base for working with GLFW windows. OpenGL or Vulkan rendering on desktop.
    /// </summary>
    internal abstract class GlfwWindow : IWindow
    {
        protected readonly NativeWindow Window;

        protected GlfwWindow(int width, int height, string title, ClientApi renderingApi)
        {
            if (!Glfw.Init())
            {
                // TODO: Proper logging
                Console.WriteLine("GLFW failed to initialize!");
                throw new ApplicationException("Could not initialize GLFW window.");
            }

            Glfw.WindowHint(Hint.ClientApi, renderingApi);
            Glfw.WindowHint(Hint.ScaleToMonitor, true);

            Window = new NativeWindow(width, height, title);
            Window.CenterOnScreen();
        }

        #region IDisposable

        public void Dispose()
        {
            Window?.Dispose();
            Glfw.Terminate();
        }

        #endregion

        #region IWindow

        public bool Closed()
        {
            return Window.IsClosed;
        }

        public virtual void Update()
        {
            Glfw.PollEvents();
        }

        #endregion
    }
}
