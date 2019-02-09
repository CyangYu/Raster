using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Raster.Private;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
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

        #region Public Static Fields
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
        #endregion Public Static Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public float Length
        {
            get { return MathF.Sqrt(X * X + Y * Y); }
        }

        /// <summary>
        /// 
        /// </summary>
        public float LengthSquared
        {
            get { return X * X + Y * Y; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector2 MidPoint
        {
            get { return new Vector2(X / 2.0f, Y / 2.0f); }
        }

        #endregion Public Instance Properties

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
        public override int GetHashCode() =>
            HashHelpers.Combine(X.GetHashCode(), Y.GetHashCode());

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
            float lenSqr = X * X + Y * Y;
            float invNorm = 1.0f / lenSqr;

            X *= invNorm;
            Y *= invNorm;
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Normalize()
        {
            float lenSqr = X * X + Y * Y;
            float invLen = MathHelper.FastSqrtInverse(lenSqr);

            X *= invLen;
            Y *= invLen;         
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
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Clamp(in Vector2 value, in Vector2 min, in Vector2 max)
        {
            Vector2 result;
            Clamp(value, min, max, out result);
            return result;
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
        public static float DistanceSquared(in Vector2 value1, in Vector2 value2)
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
        /// <param name="value1"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Inverse(in Vector2 value)
        {
            Vector2 result;
            Inverse(value, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Lerp(in Vector2 begin, in Vector2 end, float factor)
        {
            Vector2 result;
            Lerp(begin, end, factor, out result);
            return result;
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
            Vector2 result;
            Max(value1, value2, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Min(in Vector2 value1, in Vector2 value2)
        {
            Vector2 result;
            Min(value1, value2, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Normalize(in Vector2 value)
        {
            Vector2 result;
            Normalize(value, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Perpendicular(in Vector2 value)
        {
            Vector2 result;
            Perpendicular(value, out result);
            return result;
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
            Vector2 result;
            Reflect(vec2, normal, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec2"></param>
        /// <param name="normal"></param>
        /// <param name="eta"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Refract(in Vector2 vec2, in Vector2 normal, float eta)
        {
            Vector2 result;
            Refract(vec2, normal, eta, out result);
            return result;
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
            Vector2 result;
            Transform(position, matrix, out result);
            return result;
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
            Vector2 result;
            Transform(position, matrix, out result);
            return result;
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
            Vector2 result;
            TransformNormal(normal, matrix, out result);
            return result;
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
            Vector2 result;
            TransformNormal(normal, matrix, out result);
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Transform(in Vector2 position, in Quaternion rotation)
        {
            Vector2 result;
            Transform(position, rotation, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Clamp(in Vector2 value, in Vector2 min, in Vector2 max, out Vector2 result)
        {
            result.X = (min.X > value.X) ? min.X : value.X;
            result.X = (max.X < value.X) ? max.X : value.X;

            result.Y = (min.Y > value.Y) ? min.Y : value.Y;
            result.Y = (max.Y < value.Y) ? max.Y : value.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Inverse(in Vector2 value, out Vector2 result)
        {
            float lenSqr = value.X * value.X + value.Y * value.Y;
            float invNorm = 1.0f / lenSqr;

            result.X = value.X * invNorm;
            result.Y = value.Y * invNorm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="factor"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Lerp(in Vector2 begin, in Vector2 end, float factor, out Vector2 result)
        {
            result.X = begin.X + (end.X - begin.X) * factor;
            result.Y = begin.Y + (end.Y - begin.Y) * factor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Min(in Vector2 value1, in Vector2 value2, out Vector2 result)
        {
            result.X = (value1.X < value2.X) ? value1.X : value2.X;
            result.Y = (value1.Y < value2.Y) ? value1.Y : value2.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Max(in Vector2 value1, in Vector2 value2, out Vector2 result)
        {
            result.X = (value1.X > value2.X) ? value1.X : value2.X;
            result.Y = (value1.Y > value2.Y) ? value1.Y : value2.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Normalize(in Vector2 value, out Vector2 result)
        {
            float lenSqr = value.X * value.X + value.Y * value.Y;
            float invNorm = MathHelper.FastSqrtInverse(lenSqr);

            result.X = value.X * invNorm;
            result.Y = value.Y * invNorm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Perpendicular(in Vector2 value, out Vector2 result)
        {
            float temp = value.X;
            result.X = -value.Y;
            result.Y =  temp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Transform(in Vector2 position, in Matrix3x2 matrix, out Vector2 result)
        {
            result.X = position.X * matrix.M00 + position.Y * matrix.M10 + matrix.M20;
            result.Y = position.X * matrix.M01 + position.Y * matrix.M11 + matrix.M21;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Transform(in Vector2 position, in Matrix4x4 matrix, out Vector2 result)
        {
            result.X = position.X * matrix.M00 + position.Y * matrix.M10 + matrix.M30;
            result.Y = position.X * matrix.M01 + position.Y * matrix.M11 + matrix.M31;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="normal"></param>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TransformNormal(in Vector2 normal, in Matrix3x2 matrix, out Vector2 result)
        {
            result.X = normal.X * matrix.M00 + normal.Y * matrix.M10;
            result.Y = normal.X * matrix.M01 + normal.Y * matrix.M11;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="normal"></param>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TransformNormal(in Vector2 normal, in Matrix4x4 matrix, out Vector2 result)
        {
            result.X = normal.X * matrix.M00 + normal.Y * matrix.M10;
            result.Y = normal.X * matrix.M01 + normal.Y * matrix.M11;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Transform(in Vector2 position, in Quaternion rotation, out Vector2 result)
        {
            float x2 = rotation.X * rotation.X;
            float y2 = rotation.Y * rotation.Y;
            float z2 = rotation.Z * rotation.Z;

            float wz2 = rotation.W * z2;
            float xx2 = rotation.X * x2;
            float xy2 = rotation.X * y2;
            float yy2 = rotation.Y * y2;
            float zz2 = rotation.Z * z2;

            result.X = position.X * (1.0f - yy2 - zz2) + position.Y * (xy2 - wz2);
            result.Y = position.X * (xy2 + wz2) + position.Y * (1.0f - xx2 - zz2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec2"></param>
        /// <param name="normal"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Reflect(in Vector2 vec2, in Vector2 normal, out Vector2 result)
        {
            float dot = vec2.X + normal.X + vec2.Y * normal.Y;

            result.X = vec2.X - 2.0f * dot * normal.X;
            result.Y = vec2.Y - 2.0f * dot * normal.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec2"></param>
        /// <param name="normal"></param>
        /// <param name="eta"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Refract(in Vector2 vec2, in Vector2 normal, float eta, out Vector2 result)
        {
            float dot = vec2.X * normal.X + vec2.Y * normal.Y;
            float k = 1.0f - eta * eta * (1.0f - dot * dot);

            if (k < 0.0f)
            {
                result = Zero;
            }
            else
            {
                float sqrtk = MathF.Sqrt(k);

                result.X = eta * vec2.X - (eta * dot + sqrtk) * normal.X;
                result.Y = eta * vec2.Y - (eta * dot + sqrtk) * normal.Y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add(in Vector2 left, in Vector2 right, out Vector2 result)
        {
            result.X = left.X + right.X;
            result.Y = left.Y + right.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Subtract(in Vector2 left, in Vector2 right, out Vector2 result)
        {
            result.X = left.X + right.X;
            result.Y = left.Y + right.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Multiply(in Vector2 left, float right, out Vector2 result)
        {
            result.X = left.X * right;
            result.Y = left.Y * right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Multiply(in Vector2 left, in Vector2 right, out Vector2 result)
        {
            result.X = left.X * right.X;
            result.Y = left.Y * right.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Negate(in Vector2 value, out Vector2 result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
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
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator -(in Vector2 value) =>
            new Vector2(-value.X, -value.Y);

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
        public static Vector2 operator /(in Vector2 left, float right) =>
            new Vector2(left.X / right, left.Y / right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator /(in Vector2 left, in Vector2 right) =>
            new Vector2(left.X / right.X, left.Y / right.Y);

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