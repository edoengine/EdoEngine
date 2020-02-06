using GLFW;

namespace EdoEngine.Graphics.Backend
{
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
        }

        ~GlfwWindow()
        {
            _window.Dispose();
        }

        public void Update()
        {
            Glfw.PollEvents();
            _window.SwapBuffers();
        }
    }
}