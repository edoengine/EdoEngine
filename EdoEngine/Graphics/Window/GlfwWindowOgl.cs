using GLFW;

namespace EdoEngine.Graphics.Window
{
    /// <summary>
    /// OpenGL based GLFW window.
    /// </summary>
    internal class GlfwWindowOgl : GlfwWindow
    {
        internal GlfwWindowOgl(int width, int height, string title) : base(width, height, title, ClientApi.OpenGL)
        {
        }

        public override void Update()
        {
            Window.SwapBuffers();
            base.Update();
        }
    }
}
