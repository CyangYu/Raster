﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Raster.Private;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct Vector4 : IEquatable<Vector4>
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
        /// <summary>
        /// 
        /// </summary>
        public float Z;
        /// <summary>
        /// 
        /// </summary>
        public float W;
        #endregion

        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 Zero     = new Vector4( 0.0f,  0.0f,  0.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 Unit     = new Vector4( 1.0f,  1.0f,  1.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 UnitX    = new Vector4( 1.0f,  0.0f,  0.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 UnitY    = new Vector4( 0.0f,  1.0f,  0.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 UnitZ    = new Vector4( 0.0f,  0.0f,  1.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 UnitW    = new Vector4( 0.0f,  0.0f,  0.0f,  1.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 NegUnit  = new Vector4(-1.0f, -1.0f, -1.0f, -1.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 NegUnitX = new Vector4(-1.0f,  0.0f,  0.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 NegUnitY = new Vector4( 0.0f, -1.0f,  0.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 NegUnitZ = new Vector4( 0.0f,  0.0f, -1.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 NegUnitW = new Vector4( 0.0f,  0.0f,  0.0f, -1.0f);
        #endregion Public Static Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public float Length
        {
            get { return MathF.Sqrt(X * X + Y * Y + Z * Z + W * W); }
        }

        /// <summary>
        /// 
        /// </summary>
        public float LengthSquared
        {
            get { return X * X + Y * Y + Z * Z + W * W; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector4 MidPoint
        {
            get { return new Vector4(X / 2.0f, Y / 2.0f, Z / 2.0f, W / 2.0f); }
        }

        #endregion Public Instance Properties

        #region Constructor
        public Vector4(float value)
            : this(value, value, value, value)
        {
        }

        public Vector4(in Vector4 other)
            : this(other.X, other.Y, other.Z, other.W)
        {
        }

        public Vector4(in Vector3 vec3, float w)
            : this(vec3.X, vec3.Y, vec3.Z, w)
        {
        }

        public Vector4(in Vector2 vec2, float z, float w)
            : this(vec2.X, vec2.Y, z, w)
        {
        }

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
        #endregion Constructor

        #region Public Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector4)
            {
                return Equals((Vector4)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash1 = HashHelpers.Combine(X.GetHashCode(), Y.GetHashCode());
            int hash2 = HashHelpers.Combine(Z.GetHashCode(), W.GetHashCode());
            return HashHelpers.Combine(hash1, hash2);
        }

        public override string ToString()
            => string.Format("Vector4: X = {0}, Y = [1}, Z = {2} W = {3}", X, Y, Z, W);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vector4 other) => this == other;

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Inverse()
        {
            float lenSqr = X * X + Y * Y + Z * Z + W * W;
            float invNorm = 1.0f / lenSqr;

            X *= invNorm;
            Y *= invNorm;
            Z *= invNorm;
            W *= invNorm;
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Normalize()
        {
            float lenSqr = X * X + Y * Y + Z * Z + W * W;
            float invNorm = MathHelper.FastSqrtInverse(lenSqr);

            X *= invNorm;
            Y *= invNorm;
            Z *= invNorm;
            W *= invNorm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 ToVector2() => new Vector2(X, Y);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3 ToVector3() => new Vector3(X, Y, Z);

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AngleBetween(in Vector4 left, in Vector4 right)
        {
            float dot = left.X * right.X + left.Y * right.Y + 
                        left.Z * right.Z + left.W * right.W;
            float lenProduct = left.Length * right.Length;

            if (MathHelper.IsZero(lenProduct))
            {
                lenProduct = MathHelper.ZeroTolerance;
            }

            float cos = dot / lenProduct;
            cos = MathF.Clamp(cos, -1.0f, 1.0f);
            return MathF.Acos(cos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static Vector4 Clamp(in Vector4 value, in Vector4 min, in Vector4 max)
        {
            Vector4 result;
            Clamp(value, min, max, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Distance(in Vector4 value1, in Vector4 value2)
        {
            float dx = value1.X - value2.X;
            float dy = value1.Y - value2.Y;
            float dz = value1.Z - value2.Z;
            float dw = value1.W - value2.W;
            return MathF.Sqrt(dx * dx + dy * dy + dz * dz + dw * dw);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float DistanceSquared(in Vector4 value1, in Vector4 value2)
        {
            float dx = value1.X - value2.X;
            float dy = value1.Y - value2.Y;
            float dz = value1.Z - value2.Z;
            float dw = value1.W - value2.W;
            return dx * dx + dy * dy + dz * dz + dw * dw;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(in Vector4 left, in Vector4 right) =>
            left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Inverse(in Vector4 value)
        {
            Vector4 result;
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
        public static Vector4 Lerp(in Vector4 begin, in Vector4 end, float factor)
        {
            Vector4 result;
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
        public static Vector4 Max(in Vector4 value1, in Vector4 value2)
        {
            Vector4 result;
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
        public static Vector4 Min(in Vector4 value1, in Vector4 value2)
        {
            Vector4 result;
            Min(value1, value2, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Normalize(in Vector4 value)
        {
            Vector4 result;
            Normalize(value, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Transform(in Vector2 position, in Matrix4x4 matrix)
        {
            Vector4 result;
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
        public static Vector4 Transform(in Vector3 position, in Matrix4x4 matrix)
        {
            Vector4 result;
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
        public static Vector4 Transform(in Vector4 position, in Matrix4x4 matrix)
        {
            Vector4 result;
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
        public static Vector4 Transform(in Vector2 position, in Quaternion rotation)
        {
            Vector4 result;
            Transform(position, rotation, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Transform(in Vector3 position, in Quaternion rotation)
        {
            Vector4 result;
            Transform(position, rotation, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Transform(in Vector4 position, in Quaternion rotation)
        {
            Vector4 result;
            Transform(position, rotation, out result);
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
        public static Vector4 Refract(in Vector4 vec4, in Vector4 normal, float eta)
        {
            Vector4 result;
            Refract(vec4, normal, eta, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec4"></param>
        /// <param name="normal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Relfect(in Vector4 vec4, in Vector4 normal)
        {
            Vector4 result;
            Reflect(vec4, normal, out result);
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
        public static void Clamp(in Vector4 value, in Vector4 min, in Vector4 max, out Vector4 result)
        {
            result.X = (min.X > value.X) ? min.X : value.X;
            result.X = (max.X < value.X) ? max.X : value.X;

            result.Y = (min.Y > value.Y) ? min.Y : value.Y;
            result.Y = (max.Y < value.Y) ? max.Y : value.Y;

            result.Z = (min.Z > value.Z) ? min.Z : value.Z;
            result.Z = (max.Z < value.Z) ? max.Z : value.Z;

            result.W = (min.W > value.W) ? min.W : value.W;
            result.W = (max.W < value.W) ? max.W : value.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Inverse(in Vector4 value, out Vector4 result)
        {
            float lenSqr = value.X * value.X + value.Y * value.Y +
                           value.Z * value.Z + value.W * value.W;
            float invNorm = 1.0f / lenSqr;

            result.X = value.X * invNorm;
            result.Y = value.Y * invNorm;
            result.Z = value.Z * invNorm;
            result.W = value.W * invNorm;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="factor"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Lerp(in Vector4 begin, in Vector4 end, float factor, out Vector4 result)
        {
            result.X = begin.X + (end.X - begin.X) * factor;
            result.Y = begin.Y + (end.Y - begin.Y) * factor;
            result.Z = begin.Z + (end.Z - begin.Z) * factor;
            result.W = begin.W + (end.W - begin.W) * factor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Max(in Vector4 value1, in Vector4 value2, out Vector4 result)
        {
            result.X = value1.X > value2.X ? value1.X : value2.X;
            result.Y = value1.Y > value2.Y ? value1.Y : value2.Y;
            result.Z = value1.Z > value2.Z ? value1.Z : value2.Z;
            result.W = value1.W > value2.W ? value1.W : value2.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Min(in Vector4 value1, in Vector4 value2, out Vector4 result)
        {
            result.X = value1.X < value2.X ? value1.X : value2.X;
            result.Y = value1.Y < value2.Y ? value1.Y : value2.Y;
            result.Z = value1.Z < value2.Z ? value1.Z : value2.Z;
            result.W = value1.W < value2.W ? value1.W : value2.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Normalize(in Vector4 value, out Vector4 result)
        {
            float lenSqr = value.X * value.X + value.Y * value.Y + 
                           value.Z * value.Z + value.W * value.W;
            float invNorm = MathHelper.FastSqrtInverse(lenSqr);

            result.X = value.X * invNorm;
            result.Y = value.Y * invNorm;
            result.Z = value.Z * invNorm;
            result.W = value.W * invNorm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Transform(in Vector2 position, in Matrix4x4 matrix, out Vector4 result)
        {
            result.X = position.X * matrix.M00 + position.Y * matrix.M10 + matrix.M30;
            result.Y = position.X * matrix.M01 + position.Y * matrix.M11 + matrix.M31;
            result.Z = position.X * matrix.M02 + position.Y * matrix.M12 + matrix.M32;
            result.W = position.X * matrix.M03 + position.Y * matrix.M13 + matrix.M33;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Transform(in Vector3 position, in Matrix4x4 matrix, out Vector4 result)
        {
            result.X = position.X * matrix.M00 + position.Y * matrix.M10 + 
                       position.Z * matrix.M20 + matrix.M30;
            result.Y = position.X * matrix.M01 + position.Y * matrix.M11 + 
                       position.Z * matrix.M21 + matrix.M31;
            result.Z = position.X * matrix.M02 + position.Y * matrix.M12 + 
                       position.Z * matrix.M22 + matrix.M32;
            result.W = position.X * matrix.M03 + position.Y * matrix.M13 + 
                       position.Z * matrix.M23 + matrix.M33;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Transform(in Vector4 position, in Matrix4x4 matrix, out Vector4 result)
        {
            result.X = position.X * matrix.M00 + position.Y * matrix.M10 + 
                       position.Z * matrix.M20 + position.W * matrix.M30;
            result.Y = position.X * matrix.M01 + position.Y * matrix.M11 + 
                       position.Z * matrix.M21 + position.W * matrix.M31;
            result.Z = position.X * matrix.M02 + position.Y * matrix.M12 + 
                       position.Z * matrix.M22 + position.W * matrix.M32;
            result.W = position.X * matrix.M03 + position.Y * matrix.M13 + 
                       position.Z * matrix.M23 + position.W * matrix.M33;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Transform(in Vector2 position, in Quaternion rotation, out Vector4 result)
        {
            float x2 = rotation.X + rotation.X;
            float y2 = rotation.Y + rotation.Y;
            float z2 = rotation.Z + rotation.Z;

            float wx2 = rotation.W * x2;
            float wy2 = rotation.W * y2;
            float wz2 = rotation.W * z2;
            float xx2 = rotation.X * x2;
            float xy2 = rotation.X * y2;
            float xz2 = rotation.X * z2;
            float yy2 = rotation.Y * y2;
            float yz2 = rotation.Y * z2;
            float zz2 = rotation.Z * z2;

            result.X = position.X * (1.0f - yy2 - zz2) + position.Y * (xy2 - wz2);
            result.Y = position.X * (xy2 + wz2) + position.Y * (1.0f - xx2 - zz2);
            result.Z = position.X * (xz2 - wy2) + position.Y * (yz2 + wx2);
            result.W = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Transform(in Vector3 position, in Quaternion rotation, out Vector4 result)
        {
            float x2 = rotation.X + rotation.X;
            float y2 = rotation.Y + rotation.Y;
            float z2 = rotation.Z + rotation.Z;

            float wx2 = rotation.W * x2;
            float wy2 = rotation.W * y2;
            float wz2 = rotation.W * z2;
            float xx2 = rotation.X * x2;
            float xy2 = rotation.X * y2;
            float xz2 = rotation.X * z2;
            float yy2 = rotation.Y * y2;
            float yz2 = rotation.Y * z2;
            float zz2 = rotation.Z * z2;

            result.X = position.X * (1.0f - yy2 - zz2) + position.Y * (xy2 - wz2) + 
                       position.Z * (xz2 + wy2);
            result.Y = position.X * (xy2 + wz2) + position.Y * (1.0f - xx2 - zz2) + 
                       position.Z * (yz2 - wx2);
            result.Z = position.X * (xz2 - wy2) + position.Y * (yz2 + wx2) + 
                       position.Z * (1.0f - xx2 - yy2);
            result.W = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Transform(in Vector4 position, in Quaternion rotation, out Vector4 result)
        {
            float x2 = rotation.X + rotation.X;
            float y2 = rotation.Y + rotation.Y;
            float z2 = rotation.Z + rotation.Z;

            float wx2 = rotation.W * x2;
            float wy2 = rotation.W * y2;
            float wz2 = rotation.W * z2;
            float xx2 = rotation.X * x2;
            float xy2 = rotation.X * y2;
            float xz2 = rotation.X * z2;
            float yy2 = rotation.Y * y2;
            float yz2 = rotation.Y * z2;
            float zz2 = rotation.Z * z2;

            result.X = position.X * (1.0f - yy2 - zz2) + position.Y * (xy2 - wz2) + 
                       position.Z * (xz2 + wy2);
            result.Y = position.X * (xy2 + wz2) + position.Y * (1.0f - xx2 - zz2) + 
                       position.Z * (yz2 - wx2);
            result.Z = position.X * (xz2 - wy2) + position.Y * (yz2 + wx2) + 
                       position.Z * (1.0f - xx2 - yy2);
            result.W = position.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec3"></param>
        /// <param name="normal"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Reflect(in Vector4 vec4, in Vector4 normal, out Vector4 result)
        {
            float dot = vec4.X + normal.X + vec4.Y * normal.Y + 
                        vec4.Z * normal.Z + vec4.W * normal.W;

            result.X = vec4.X - 2.0f * dot * normal.X;
            result.Y = vec4.Y - 2.0f * dot * normal.Y;
            result.Z = vec4.Z - 2.0f * dot * normal.Z;
            result.W = vec4.W - 2.0f * dot * normal.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec4"></param>
        /// <param name="normal"></param>
        /// <param name="eta"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Refract(in Vector4 vec4, in Vector4 normal, float eta, out Vector4 result)
        {
            float dot = vec4.X * normal.X + vec4.Y * normal.Y + 
                        vec4.Z * normal.Z + vec4.W * normal.W;
            float k = 1.0f - eta * eta * (1.0f - dot * dot);

            if (k < 0.0f)
            {
                result = Zero;
            }
            else
            {
                float sqrtk = MathF.Sqrt(k);

                result.X = eta * vec4.X - (eta * dot + sqrtk) * normal.X;
                result.Y = eta * vec4.Y - (eta * dot + sqrtk) * normal.Y;
                result.Z = eta * vec4.Z - (eta * dot + sqrtk) * normal.Z;
                result.W = eta * vec4.W - (eta * dot + sqrtk) * normal.W;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add(in Vector4 left, in Vector4 right, out Vector4 result)
        {
            result.X = left.X + right.X;
            result.Y = left.Y + right.Y;
            result.Z = left.Z + right.Z;
            result.W = left.W + right.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Subtract(in Vector4 left, in Vector4 right, out Vector4 result)
        {
            result.X = left.X - right.X;
            result.Y = left.Y - right.Y;
            result.Z = left.Z - right.Z;
            result.W = left.W - right.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Multiply(in Vector4 left, float right, out Vector4 result)
        {
            result.X = left.X * right;
            result.Y = left.Y * right;
            result.Z = left.Z * right;
            result.W = left.W * right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Multiply(in Vector4 left, in Vector4 right, out Vector4 result)
        {
            result.X = left.X * right.X;
            result.Y = left.Y * right.Y;
            result.Z = left.Z * right.Z;
            result.W = left.W * right.W;
        }

        #endregion Public Static Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator +(in Vector4 left, in Vector4 right) =>
            new Vector4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator -(in Vector4 value) =>
            new Vector4(-value.X, -value.Y, -value.Z, -value.W);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator -(in Vector4 left, in Vector4 right) =>
            new Vector4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator *(float left, in Vector4 right) =>
            new Vector4(left * right.X, left * right.Y, left * right.Z, left * right.W);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator *(in Vector4 left, in Vector4 right) =>
             new Vector4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W + right.W);
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator /(in Vector4 left, in Vector4 right) =>
            new Vector4(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Vector4 left, in Vector4 right) =>
             left.X == right.X && left.Y == right.Y && left.Z == right.Z && left.W == right.W;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(in Vector4 left, in Vector4 right) =>
            left.X != right.X || left.Y != right.Y || left.Z != right.Z || left.W != right.W;

        #endregion Operator Overload
    }
}
