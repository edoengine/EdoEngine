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

        [DllImport(LibName, EntryPoint = "glClear")]
        internal static extern void Clear(uint mask);

        [DllImport(LibName, EntryPoint = "glClearColor")]
        internal static extern void ClearColor(float r, float g, float b, float a);
#endif
    }
}