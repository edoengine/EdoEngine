//=============================================================================
// Vector2.cs
//
// Created by Victor on 2019/10/04
//=============================================================================

using System;

namespace Edo.Mathematics
{
    [Serializable]
    public struct Vector2 : IEquatable<Vector2>
    {
        // Vector components. Necessary for serialization
        private float _x;
        private float _y;

        // Component properties. Allow for serialization via Json
        /// <summary>
        /// X component of this vector
        /// </summary>
        public float X
        {
            get => _x;
            set => _x = value;
        }

        /// <summary>
        /// Y component of this vector
        /// </summary>
        public float Y
        {
            get => _y;
            set => _y = value;
        }

        /// <summary>
        /// Constructs a new 2D Vector
        /// </summary>
        /// <param name="x">X component</param>
        /// <param name="y">Y component</param>
        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }

        #region Shorthand Properties

        /// <summary>
        /// Represents the zero vector (0, 0)
        /// </summary>
        public static Vector2 Zero => new Vector2(0, 0);

        /// <summary>
        /// Represents the one vector (1, 1)
        /// </summary>
        public static Vector2 One => new Vector2(1, 1);

        /// <summary>
        /// Represents a vector pointing up (0, 1)
        /// </summary>
        public static Vector2 Up => new Vector2(0, 1);

        /// <summary>
        /// Represents a vector pointing down (0, -1)
        /// </summary>
        public static Vector2 Down => new Vector2(0, -1);

        /// <summary>
        /// Represents a vector pointing left (-1, 0)
        /// </summary>
        public static Vector2 Left => new Vector2(-1, 0);

        /// <summary>
        /// Represents a vector pointing right (1, 0)
        /// </summary>
        public static Vector2 Right => new Vector2(1, 0);

        /// <summary>
        /// A vector with infinite x and y components
        /// </summary>
        public static Vector2 PositiveInfinity => new Vector2(float.PositiveInfinity, float.PositiveInfinity);

        /// <summary>
        /// A vector with negative infinite x and y components
        /// </summary>
        public static Vector2 NegativeInfinity => new Vector2(float.NegativeInfinity, float.NegativeInfinity);

        #endregion

        #region Vector Properties

        /// <summary>
        /// Length of the vector
        /// </summary>
        public float Magnitude => EdoMath.Sqrt(SqrMagnitude);

        /// <summary>
        /// Changes the vector to a unit vector representation
        /// </summary>
        public void Normalize() => this = this / Magnitude;

        /// <summary>
        /// Gets a unit vector representation of the Vector2
        /// </summary>
        public Vector2 Normalized
        {
            get
            {
                var vec = new Vector2(_x, _y);
                vec.Normalize();
                return vec;
            }
        }

        /// <summary>
        /// Length of the vector squared
        /// </summary>
        public float SqrMagnitude => _x * _x + _y * _y;

        #endregion

        #region Vector Calculations

        /// <summary>
        /// Finds the distance between two vectors
        /// </summary>
        /// <param name="a">Vector (point) one</param>
        /// <param name="b">Vector (point) two</param>
        /// <returns>Distance between provided vectors</returns>
        public static float Distance(Vector2 a, Vector2 b)
            => EdoMath.Sqrt((a._x - b._x) * (a._x - b._x) + (a._y - b._y) * (a._y - b._y));

        /// <summary>
        /// Computes the dot product of two vectors
        /// </summary>
        /// <param name="a">First vector</param>
        /// <param name="b">Second vector</param>
        /// <returns>Dot product of <see cref="a"/> and <see cref="b"/></returns>
        public static float Dot(Vector2 a, Vector2 b) => a._x * b._x + a._y * b._y;

        #endregion

        #region IEquatable

        /// <summary>
        /// Checks if two vectors are equal to each other
        /// </summary>
        /// <param name="other">Vector2 to check equality with</param>
        /// <returns>True if both vectors are equal to each other</returns>
        public bool Equals(Vector2 other) => _x == other._x && _y == other._y;

        /// <summary>
        /// Checks if two vectors are equal to each other
        /// </summary>
        /// <param name="obj">Object to check equality with</param>
        /// <returns>True if <see cref="obj"/> is a Vector2 and equal to this vector</returns>
        public override bool Equals(object obj) => obj is Vector2 other && Equals(other);

        /// <summary>
        /// Gets a unique hash value. Allows for use as keys in hash tables
        /// </summary>
        /// <returns>Hash value of this vector</returns>
        public override int GetHashCode() => unchecked(_x.GetHashCode() * 397 ^ _y.GetHashCode());

        #endregion

        #region Operators

        // Vector addition
        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a._x + b._x, a._y + b._y);

        // Vector subtraction
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a._x - b._x, a._y + b._y);
        public static Vector2 operator -(Vector2 v) => new Vector2(-v._x, -v._y); // negate

        // Vector multiplication
        public static Vector2 operator *(Vector2 a, Vector2 b) => new Vector2(a._x * b._x, a._y + b._y);
        public static Vector2 operator *(Vector2 v, float s) => new Vector2(v._x * s, v._y * s); // scalar
        public static Vector2 operator *(float s, Vector2 v) => new Vector2(v._x * s, v._y * s);

        // Vector division
        public static Vector2 operator /(Vector2 a, Vector2 b) => new Vector2(a._x / b._x, a._y / b._y);
        public static Vector2 operator /(Vector2 v, float s) => new Vector2(v._x / s, v._y / s);

        // Vector equality
        public static bool operator ==(Vector2 a, Vector2 b) => a.Equals(b);
        public static bool operator !=(Vector2 a, Vector2 b) => !a.Equals(b);

        #endregion

        public override string ToString() => $"{_x:F1}, {_y:F1}";
    }
}