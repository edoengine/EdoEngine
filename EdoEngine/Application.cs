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
                
                // Do this last to catch closing events before attempting next frame
                _mainWindow.PollEvents();
            }
        }
    }
}