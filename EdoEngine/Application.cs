using EdoEngine.Graphics.Backend;

namespace EdoEngine
{
    public abstract class Application
    {
        private IWindow _mainWindow;

        protected void Run()
        {
            _mainWindow = new GlfwWindow(1280, 720, "Shiori - Edo Engine");

            while (_mainWindow.IsOpen)
            {
                _mainWindow.Update();
            }
        }
    }
}