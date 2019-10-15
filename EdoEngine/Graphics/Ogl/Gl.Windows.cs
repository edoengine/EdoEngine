//=============================================================================
// Gl.Windows.cs
//
// Created by Victor on 2019/10/14
//=============================================================================

using System;
using System.Runtime.InteropServices;

namespace Edo.Graphics.Ogl
{
    // Windows OpenGL calls
    internal static partial class Gl
    {
        // TODO: another partial for shared stuff?
        public const int Triangles = 0x0004;
        public const int Projection = 0x0BA7;
#if EDO_WINDOWS
        private const string LibName = "opengl32";

        #region Initialization

        private delegate void BindFramebufferProc(uint target, uint framebuffer);

        private static BindFramebufferProc _glBindFramebufferProc;

        [DllImport(LibName, EntryPoint = "wglGetProcAddress")]
        private static extern IntPtr GetProcAddress([MarshalAs(UnmanagedType.LPStr)] string proc);

        static Gl()
        {
            _glBindFramebufferProc =
                (BindFramebufferProc) Marshal.GetDelegateForFunctionPointer(GetProcAddress("glBindFramebuffer"),
                    typeof(BindFramebufferProc));
        }

        #endregion

        [DllImport(LibName, EntryPoint = "glBegin")]
        internal static extern void Begin(int mode);

        [DllImport(LibName, EntryPoint = "glClear")]
        internal static extern void Clear(uint mask);

        [DllImport(LibName, EntryPoint = "glClearColor")]
        internal static extern void ClearColor(float red, float green, float blue, float alpha);

        [DllImport(LibName, EntryPoint = "glColor3f")]
        internal static extern void Color3(float red, float green, float blue);

        [DllImport(LibName, EntryPoint = "glEnd")]
        internal static extern void End();

        [DllImport(LibName, EntryPoint = "glLoadIdentity")]
        internal static extern void LoadIdentity();

        [DllImport(LibName, EntryPoint = "glMatrixMode")]
        internal static extern void MatrixMode(int mode);

        [DllImport(LibName, EntryPoint = "glOrtho")]
        internal static extern void Ortho(double left, double right, double bottom, double top, double zNear,
            double zFar);

        [DllImport(LibName, EntryPoint = "glVertex2f")]
        internal static extern void Vertex2(float x, float y);
#endif
    }
}