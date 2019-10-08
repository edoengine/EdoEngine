using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using Edo.Graphics;

namespace VfsTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SetupWindowIcon();
        }

        private static void SetupWindowIcon()
        {
            // load bitmap
            var bmp = new Bitmap("./application.png");
            var width = bmp.Width;
            var height = bmp.Height;

            // Setup the bitmap
            var rect = new Rectangle(0, 0, width, height);
            var bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);

            // Create icon
            var ptr = bmpData.Scan0;
            var bytes = Math.Abs(bmpData.Stride) * height;
            var pixels = new byte[bytes];
            Marshal.Copy(ptr, pixels, 0, bytes);

            bmp.Dispose();

            // Adjust color channels
            for (var i = 0; i < pixels.Length; i += 4)
            {
                // Swap red and blue channels
                var r = pixels[i];
                pixels[i] = pixels[i + 2];
                pixels[i + 2] = r;
            }

            var icon = new ApplicationIcon {Width = width, Height = height, Pixels = pixels};

            using var fs = File.Create("./windowicon");
            new BinaryFormatter().Serialize(fs, icon);
        }
    }
}