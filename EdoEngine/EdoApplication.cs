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
        private EdoWindow _window;

        protected void Initialize(string company, string application)
        {
            Application.Name = application;
            Application.Company = company;
            
            Debug.Initialize();
            
            // TODO: Move this to an OpenGL/Graphics handler
            OpenGL.Gl.Initialize(); // This needs to be done before the glfw context is made current
            _window = new EdoWindow(1280, 720, application);
        }

        protected void Run()
        {
            while (!_window.Closing)
            {
                // Check window events first. This will catch the window closing after the loop starts
                if (!_window.HandleEvents())
                    break;
                
                // renderer drawing, (fixed)update?
                _window.Swap();
            }
        }
    }
}