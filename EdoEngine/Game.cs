using System;
using GLFW;

namespace EdoEngine
{
    public abstract class Game
    {
        protected void Run()
        {
            var window = new NativeWindow();

            while (!window.IsClosed)
            {
                window.SwapBuffers();
                Glfw.PollEvents();
            }
        }
    }
}
