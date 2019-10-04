using System;

namespace Edo
{
    [Serializable]
    public struct Vector2 : IEquatable<Vector2>
    {
        // For serialization
        private float _x;
        private float _y;

        // Properties for accessing vector values, and Json serialization
        public float X
        {
            get => _x;
            set => _x = value;
        }

        public float Y
        {
            get => _y;
            set => _y = value;
        }

        #region Shorthands

        public static Vector2 Zero => new Vector2(0, 0);
        public static Vector2 One => new Vector2(1, 1);
        public static Vector2 Up => new Vector2(0, 1);
        public static Vector2 Down => new Vector2(0, -1);
        public static Vector2 Left => new Vector2(-1, 0);
        public static Vector2 Right => new Vector2(1, 0);
        public static Vector2 PositiveInfinity => new Vector2(float.PositiveInfinity, float.PositiveInfinity);
        public static Vector2 NegativeInfinity => new Vector2(float.NegativeInfinity, float.NegativeInfinity);

        #endregion

        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
        {
            t = Mathf.Clamp01(t);
            return new Vector2(a._x + (b._x - a._x) * t, a._y + (b._y - a._y) * t);
        }

        public override string ToString() => $"{_x:F1}, {_y:F1}";

        public float Magnitude => (float) Math.Sqrt(_x * _x + _y * _y);
        public float SqrMagnitude => _x * _x + _y * _y;

        #region IEquatable Stuff
        
        public bool Equals(Vector2 other) => _x == other._x && _y == other._y;
        public override bool Equals(object obj) => obj is Vector2 other && Equals(other);

        // Allows use as keys in hash tables
        public override int GetHashCode()
            => unchecked(_x.GetHashCode() * 397 ^ _y.GetHashCode()); // TODO: Performance concerns, hash collisions?
        
        #endregion

        #region Operators

        // vector addition
        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a._x + b._x, a._y + b._y);

        // vector subtraction
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a._x - b._x, a._y - b._y);

        // vector multiplication
        public static Vector2 operator *(Vector2 a, Vector2 b) => new Vector2(a._x * b._x, a._y * b._y);

        // vector division
        public static Vector2 operator /(Vector2 a, Vector2 b) => new Vector2(a._x / b._y, a._y / b._y);

        // negation
        public static Vector2 operator -(Vector2 v) => new Vector2(-v._x, -v._y);

        // vector-scalar multiplication
        public static Vector2 operator *(Vector2 v, float s) => new Vector2(v._x * s, v._y * s);

        public static Vector2 operator *(float s, Vector2 v) => new Vector2(v._x * s, v._y * s);

        // vector-scalar division
        public static Vector2 operator /(Vector2 v, float s) => new Vector2(v._x / s, v._y / s);

        // vector equality
        public static bool operator ==(Vector2 a, Vector2 b) => a.Equals(b);
        public static bool operator !=(Vector2 a, Vector2 b) => !a.Equals(b);

        #endregion
    }
}