//=============================================================================
// Gl.Linux.cs
//
// Created by Victor on 2019/10/14
//=============================================================================

namespace Edo.Graphics.Ogl
{
    // Linux OpenGL calls
    internal static partial class Gl
    {
#if EDO_LINUX
        private const string LibName = "libGL.so";

        [DllImport(LibName, EntryPoint = "glClear", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Clear(uint mask);

        [DllImport(LibName, EntryPoint = "glClearColor", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ClearColor(float red, float green, float blue, float alpha);
#endif
    }
}