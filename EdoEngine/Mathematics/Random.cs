//=============================================================================
// Random.cs
//
// Created by Victor on 2019/10/05
//=============================================================================

using System;
using System.Security.Cryptography;

namespace Edo.Mathematics
{
    public static class Random
    {
        private static readonly RNGCryptoServiceProvider Rng = new RNGCryptoServiceProvider();

        /// <summary>
        /// Returns a random number between [min - max)
        /// </summary>
        /// <param name="min">Minimum value of random range (inclusive)</param>
        /// <param name="max">Maximum value of random range (exclusive)</param>
        /// <returns>Random integer between provided range</returns>
        public static int Range(int min, int max) => (int) Range(min, (float) max); // Cast to prevent infinite recursion

        /// <summary>
        /// Returns a random number between [min - max]
        /// </summary>
        /// <param name="min">Minimum value of random range (inclusive)</param>
        /// <param name="max">Maximum value of random range (exclusive)</param>
        /// <returns>Random float between provided range</returns>
        public static float Range(float min, float max)
        {
            var randomNum = new byte[1];
            Rng.GetBytes(randomNum);
            var asciiVal = (float) Convert.ToDouble(randomNum[0]);

            // We are using EdoMath.Max, and subtracting 0.00000000001,
            // to ensure the "multiplier" will always be between 0.0 and .99999999999
            // Otherwise, it is possible for it to be "1", which causes problems with rounding.
            var multiplier = EdoMath.Max(0f, asciiVal / 255f - 0.00000000001f); // TODO: Precision?
            var valueInRange = multiplier * (max - min);

            return min + valueInRange;
        }
    }
}