using System;
using System.Runtime.CompilerServices;
using Raster.Private;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct Vector2 : IEquatable<Vector2>
    {
        #region Public Fields
        /// <summary>
        /// 
        /// </summary>
        public float X;
        /// <summary>
        /// 
        /// </summary>
        public float Y;
        #endregion Public Fields

        #region Public Static Properties
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector2 Zero     = new Vector2( 0.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector2 Unit     = new Vector2( 1.0f,  1.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector2 UnitX    = new Vector2( 1.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector2 UnitY    = new Vector2( 0.0f,  1.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector2 NegUnit  = new Vector2(-1.0f, -1.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector2 NegUnitX = new Vector2(-1.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector2 NegUnitY = new Vector2(0.0f,  -1.0f);
        #endregion

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public float Length
        {
            get
            {
                return MathF.Sqrt(X * X + Y * Y);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float LengthSquared
        {
            get
            {
                return X * X + Y * Y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector2 MidPoint
        {
            get
            {
                return new Vector2(X / 2.0f, Y / 2.0f);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector2 Normalized
        {
            get
            {
                float len = X * X + Y * Y;
                if (len == 0.0f)
                {
                    return Vector2.Zero;
                }

                float inv = 1.0f / MathF.Sqrt(len);
                return new Vector2(X * inv, Y * inv);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector2 Inverted
        {
            get
            {
                float x = X != 0.0f ? 1.0f / X : 0.0f;
                float y = Y != 0.0f ? 1.0f / Y : 0.0f;
                return new Vector2(x, y);
            }
        }
        #region Public Setter/Getter Properties

        #region Constructor
        public Vector2(float value)
            : this(value, value)
        {
        }

        public Vector2(in Vector2 other)
        {
            X = other.X;
            Y = other.Y;
        }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }
        #endregion Constructor

        #region Public Instance Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector2)
            {
                return Equals((Vector2)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = this.X.GetHashCode();
            hash = HashHelpers.Combine(hash, this.Y.GetHashCode());
            return hash;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            string.Format("Vector2: X = {0}, Y = [1}", X, Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vector2 other) => this == other;

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Inverse()
        {
            if (X != 0.0f)
                X = 1.0f / X;

            if (Y != 0.0f)
                Y = 1.0f / Y;
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Normalize()
        {
            float lenSqr = X * X + Y * Y;

            if (lenSqr == 1.0f)
                return;

            float len = MathF.Sqrt(lenSqr);

            if (len != 0.0f)
            {
                float invLen = 1.0f / len;
                X *= invLen;
                Y *= invLen;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vector3 ToVector3() => new Vector3(X, Y, 1.0f);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vector4 ToVector4() => new Vector4(X, Y, 1.0f, 1.0f);
        #endregion Public Instance Method

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AngleBetween(in Vector2 left, in Vector2 right)
        {
            float dot = left.X * right.X + left.Y * right.Y;
            float lenA = left.Length;
            float lenB = right.Length;

            if (lenA == 0.0f || lenB == 0.0f)
                return 0.0f;

            return dot / (lenA * lenB);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Clamp(in Vector2 value, in Vector2 min, in Vector2 max)
        {
            float x = value.X;
            x = (min.X > x) ? min.X : x;
            x = (max.X < x) ? max.X : x;

            float y = value.Y;
            y = (min.Y > y) ? min.Y : y;
            y = (max.Y < y) ? max.Y : y;

            return new Vector2(x, y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cross(in Vector2 left, in Vector2 right) => 
            left.X * right.Y - left.Y * right.X;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Distance(in Vector2 value1, in Vector2 value2)
        {
            float dx = value1.X - value2.X;
            float dy = value1.Y - value2.Y;
            return MathF.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float DistanceSquared(in Vector2 value1, in Vector2 value2)
        {
            float dx = value1.X - value2.X;
            float dy = value1.Y - value2.Y;
            return dx * dx + dy * dy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(in Vector2 left, in Vector2 right) => 
            left.X * right.X + left.Y * right.Y;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Lerp(in Vector2 begin, in Vector2 end, float factor) =>
            new Vector2(begin.X + (end.X - begin.X) * factor,
                        end.Y + (end.Y - begin.Y) * factor);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Min(in Vector2 value1, in Vector2 value2)
        {
            return new Vector2(
                (value1.X < value2.X) ? value1.X : value2.X,
                (value1.Y < value2.Y) ? value1.Y : value2.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Max(in Vector2 value1, in Vector2 value2)
        {
            return new Vector2(
                (value1.X > value2.X) ? value1.X : value2.X,
                (value1.Y > value2.Y) ? value1.Y : value2.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Transform(in Vector2 position, in Matrix3x2 matrix)
        {
            return new Vector2(
                position.X * matrix.M00 + position.Y * matrix.M10 + matrix.M20,
                position.X * matrix.M01 + position.Y * matrix.M11 + matrix.M21);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Transform(in Vector2 position, in Matrix4x4 matrix)
        {
            return new Vector2(
                position.X * matrix.M00 + position.Y * matrix.M10 + matrix.M30,
                position.X * matrix.M01 + position.Y * matrix.M11 + matrix.M31);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="normal"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 TransformNormal(in Vector2 normal, in Matrix3x2 matrix)
        {
            return new Vector2(
                normal.X * matrix.M00 + normal.Y * matrix.M10,
                normal.X * matrix.M01 + normal.Y * matrix.M11);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="normal"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 TransformNormal(in Vector2 normal, in Matrix4x4 matrix)
        {
            return new Vector2(
                normal.X * matrix.M00 + normal.Y * matrix.M10,
                normal.X * matrix.M01 + normal.Y * matrix.M11);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Transform(in Vector2 position, in Quaternion rotation)
        {
            float x2 = rotation.X * rotation.X;
            float y2 = rotation.Y * rotation.Y;
            float z2 = rotation.Z * rotation.Z;

            float wz2 = rotation.W * z2;
            float xx2 = rotation.X * x2;
            float xy2 = rotation.X * y2;
            float yy2 = rotation.Y * y2;
            float zz2 = rotation.Z * z2;

            return new Vector2(
                position.X * (1.0f - yy2 - zz2) + position.Y * (xy2 - wz2),
                position.X * (xy2 + wz2) + position.Y * (1.0f - xx2 - zz2));

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec2"></param>
        /// <param name="normal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Reflect(in Vector2 vec2, in Vector2 normal)
        {
            float dot = vec2.X + normal.X + vec2.Y * normal.Y;
            return new Vector2(vec2.X - 2.0f * dot * normal.X,
                               vec2.Y - 2.0f * dot * normal.Y);
        }

        #endregion Public Static Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator +(in Vector2 left, in Vector2 right) =>
            new Vector2(left.X + right.X, left.Y + right.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator -(in Vector2 left, in Vector2 right) =>
            new Vector2(left.X - right.X, left.Y - right.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator *(float left, in Vector2 right) =>
            new Vector2(left * right.X, left * right.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator *(in Vector2 left, float right) =>
            new Vector2(left.X * right, left.Y * right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator *(in Vector2 left, in Vector2 right) =>
            new Vector2(left.X * right.X, left.Y * right.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator /(in Vector2 left, in Vector2 right)
        {
            if (right.X == 0.0f || right.Y == 0.0f)
                throw new DivideByZeroException("b contain zero component");

            return new Vector2(left.X / right.X, left.Y / right.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator /(in Vector2 left, float right)
        {
            if (right == 0.0f)
                throw new DivideByZeroException("divisor is zero");

            return new Vector2(left.X / right, left.Y / right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Vector2 left, in Vector2 right) =>
            left.X == right.X && left.Y == right.Y;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Vector2 left, in Vector2 right) =>
            left.X != right.X || left.Y != right.Y;

        #endregion Operator Overload
    }
}