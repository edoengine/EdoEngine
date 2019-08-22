//=============================================================================
// EdoApplication.cs
//
// Created by Victor on 2019/08/17
//=============================================================================

using Edo.Graphics;

namespace Edo
{
    /// <summary>
    /// Class defining an external application using Edo Engine
    /// DO NOT inherit from this yourself. Only the class defining the main entry point should inherit from this.
    /// </summary>
    public abstract class EdoApplication
    {
        private static bool _running;
        private EdoWindow _window;
        
        protected void Initialize(string company, string application)
        {
            if (_running)
            {
                Debug.LogError("Attempted to initialize on already running application. Ensure no classes derive from EdoApplication");
                return;
            }

            Application.Name = application;
            Application.Company = company;
            
            Debug.Initialize();
            
            _window = new EdoWindow(1280, 720, application);
        }

        protected void Run()
        {
            if (_running)
            {
                Debug.LogError("Attempted to run an already running application. Ensure no classes derive from EdoApplication");
                return;
            }

            _running = true;

            // Main loop
            while (_running && !_window.Closing)
            {
                _window.OnUpdate();
            }
        }
    }
}