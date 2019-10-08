//=============================================================================
// ApplicationIcon.cs
//
// Created by Victor on 2019/09/13
//=============================================================================

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: InternalsVisibleTo("VfsTest")]
namespace Edo.Graphics
{
    /// <summary>
    /// Helper for loading an icon for the GLFW window
    /// </summary>
    [Serializable]
    internal struct ApplicationIcon
    {
        internal int Width;
        internal int Height;
        internal byte[] Pixels;

        /// <summary>
        /// Converts this image to a GLFW compatible image
        /// </summary>
        /// <returns>GLFW image</returns>
        public GLFW.Image ToImage()
        {
            var size = Width * Height * 4;
            var img = new GLFW.Image(Width, Height, Marshal.AllocHGlobal(size));

            Marshal.Copy(Pixels, 0, img.Pixels, Math.Min(size, Pixels.Length));
            return img;
        }
    }
}