using System.ComponentModel;
using GLFW;

namespace EdoEngine.Graphics.Backend
{
    /// <summary>
    /// Wrapper for a window using GLFW (OpenGL(ES) + Vulkan)
    /// </summary>
    public class GlfwWindow : IWindow
    {
        public bool IsOpen => !_window.IsClosing;

        private NativeWindow _window;

        internal GlfwWindow(int width, int height, string title)
        {
            // TODO: Hints
            Glfw.WindowHint(Hint.ClientApi, ClientApi.OpenGL);
            Glfw.WindowHint(Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Hint.ContextVersionMinor, 3);
            Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);
            Glfw.WindowHint(Hint.Doublebuffer, true);
            Glfw.WindowHint(Hint.Decorated, true);

            _window = new NativeWindow(width, height, title);
            _window.CenterOnScreen();
            
            //_window.Closed
            // TODO: Below event allows for cancelling closing from pressing the 'x' button. Will this block when called?
            //_window.Closing
            //_window.Disposed
            //_window.Refreshed
            //_window.CharacterInput
            //_window.FileDrop
            //_window.FocusChanged
            //_window.KeyAction
            //_window.KeyPress
            //_window.KeyRelease
            //_window.KeyRepeat
            //_window.MaximizeChanged
            //_window.MouseButton
            //_window.MouseEnter
            //_window.MouseLeave
            //_window.MouseMoved
            //_window.MouseScroll
            //_window.PositionChanged
            //_window.SizeChanged
            //_window.ContentScaleChanged
            //_window.FramebufferSizeChanged
        }

        ~GlfwWindow()
        {
            _window.Dispose();
        }

        public void PollEvents()
        {
            Glfw.PollEvents();
        }

        public void Update()
        {
            _window.SwapBuffers();
        }
    }
}