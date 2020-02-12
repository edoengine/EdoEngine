using System;
using System.IO;
using System.Reflection;
using EdoEngine.Graphics.Backend;

namespace EdoEngine
{
    public abstract class Application
    {
        /// <summary>
        /// The full path to the directory the application's executable resides in
        /// </summary>
        public static string AppPath => Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
        
        private IWindow _mainWindow;

        protected void Run()
        {
            _mainWindow = new GlfwWindow(1280, 720, "Shiori - Edo Engine");

            while (_mainWindow.IsOpen)
            {
                // Fixed updating
                if (false)
                {
                    Time.UpdateFixed();
                }
                
                _mainWindow.Update();
                
                Time.UpdateTime();
                // Do this last to catch closing events before attempting next frame
                _mainWindow.PollEvents();
            }
        }
    }
}