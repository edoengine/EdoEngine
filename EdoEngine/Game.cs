using EdoEngine.Graphics.Window;

namespace EdoEngine
{
    public abstract class Game
    {
        private IWindow _mainWindow;

        protected void Run()
        {
            // TODO: Determine which renderer to use
            _mainWindow = new GlfwWindowOgl(1280, 720, "Edo Engine");

            /*try
            {
                _mainWindow = new GlfwWindowVk(1280, 720, "Edo Engine");
            }
            catch (ApplicationException e)
            {
                _mainWindow = new GlfwWindowOgl(1280, 720, "Edo Engine");
            }*/

            while (!_mainWindow.Closed())
            {
                // Swap buffers and poll events last to avoid attempting to draw to a destroyed window.
                _mainWindow.Update();
            }
        }
    }
}
