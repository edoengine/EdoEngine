//=============================================================================
// EdoApplication.cs
//
// Created by Victor on 2019/08/17
//=============================================================================

using Edo.Graphics;
using Edo.Graphics.Ogl;
//using OpenGL;

namespace Edo
{
    /// <summary>
    /// Class defining an external application using Edo Engine
    /// DO NOT inherit from this yourself. Only the class defining the main entry point should inherit from this.
    /// </summary>
    public abstract class EdoApplication
    {
        private IWindow _window;

        protected void Initialize(string company, string application)
        {
            Application.Name = application;
            Application.Company = company;

            // TODO: Move this to an OpenGL/Graphics handler
            //Gl.Initialize(); // This needs to be done before the glfw context is made current
            _window = new GlfwWindow();
            _window.Initialize(application, 1280, 720);
        }

        protected void Run()
        {
            while (!_window.Closing)
            {
                // Check window events first. This will catch the window closing after the loop starts
                if (!_window.HandleEvents())
                    break;
                
                //Gl.Viewport(0, 0, 1280, 720);
                //Gl.Clear(ClearBufferMask.ColorBufferBit);
                //Gl.Clear(Gl.ColorBufferBit);
                Gl.Clear(0x00004000);
                Gl.ClearColor(0.6901961f, 0.1921569f, 0.2470588f, 1);
                
                // renderer drawing, (fixed)update?
                /*Gl.MatrixMode(MatrixMode.Projection);
                Gl.LoadIdentity();
                Gl.Ortho(0.0, 1.0f, 0.0, 1.0, 0.0, 1.0);
                //Gl.MatrixMode(MatrixMode.Modelview);
                //Gl.LoadIdentity();
                
                Gl.Begin(PrimitiveType.Triangles);
                Gl.Color3(1f, 0f, 0f);
                Gl.Vertex2(0f, 0f);
                Gl.Color3(0f, 1f, 0f);
                Gl.Vertex2(0.5f, 1f);
                Gl.Color3(0f, 0f, 1f);
                Gl.Vertex2(1f, 0f);
                Gl.End();*/
                
                _window.Swap();
            }
        }
    }
}