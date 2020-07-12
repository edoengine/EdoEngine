using System;
using GLFW;

namespace EdoEngine.Graphics.Window
{
    /// <summary>
    /// Vulkan based GLFW window.
    /// </summary>
    internal class GlfwWindowVk : GlfwWindow
    {
        internal GlfwWindowVk(int width, int height, string title) : base(width, height, title, ClientApi.None)
        {
            if (!Vulkan.IsSupported)
            {
                // TODO: Proper logging
                Console.WriteLine("Attempted to create a Vulkan window, but hardware reports it is not supported!");
                throw new ApplicationException("Vulkan not supported.");
            }
        }
    }
}
