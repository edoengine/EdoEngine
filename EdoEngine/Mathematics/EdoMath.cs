//=============================================================================
// EdoMath.cs
//
// Created by Victor on 2019/10/04
//=============================================================================

using System;

namespace Edo.Mathematics
{
    /// <summary>
    /// Engine math library
    /// </summary>
    public static class EdoMath
    {
        /// <summary>
        /// Clamps a value between a range
        /// </summary>
        /// <param name="value">Value to clamp</param>
        /// <param name="min">Minimum allowed value</param>
        /// <param name="max">Maximum allowed value</param>
        /// <returns>Value between the [min - max] range</returns>
        public static float Clamp(float value, float min, float max) => value > max ? max : value < min ? min : value;

        /// <summary>
        /// Returns the largest of two values
        /// </summary>
        /// <param name="a">First value</param>
        /// <param name="b">Second value</param>
        /// <returns>Larger of two provided values</returns>
        public static float Max(float a, float b) => a < b ? b : a;

        /// <summary>
        /// Gives the square root of a value
        /// </summary>
        /// <param name="value">Value to find square root of</param>
        /// <returns>Square root of the value</returns>
        public static float Sqrt(float value) => (float) Math.Sqrt(value);
        
        public static float Epsilon => 0.00001f;
    }
}