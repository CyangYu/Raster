using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Raster.Private;

namespace Raster.Core.Math
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
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
        public static readonly Vector4 One      = new Vector4( 1.0f,  1.0f,  1.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 NegOne   = new Vector4(-1.0f, -1.0f, -1.0f, -1.0f);
        #endregion Public Static Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public bool IsInfinity
        {
            get
            {
                return float.IsInfinity(X) && float.IsInfinity(Y) &&
                       float.IsInfinity(Z) && float.IsInfinity(W);
            }
        }

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

        /// <summary>
        /// 
        /// </summary>
        public Vector4 Normalized
        {
            get
            {
                Normalize(in this, out Vector4 result);
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return X;
                    case 1: return Y;
                    case 2: return Z;
                    case 3: return W;
                }

                throw new ArgumentOutOfRangeException("index", "less than 4");
            }

            set
            {
                switch (index)
                {
                    case 0: X = value; break;
                    case 1: Y = value; break;
                    case 2: Z = value; break;
                    case 3: W = value; break;
                    default: throw new ArgumentOutOfRangeException("index", "less than 4");
                }
            }
        }
        #endregion Public Instance Properties

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Vector4(float value)
            : this(value, value, value, value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public Vector4(in Vector4 other)
            : this(other.X, other.Y, other.Z, other.W)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec3"></param>
        /// <param name="w"></param>
        public Vector4(in Vector3 vec3, float w)
            : this(vec3.X, vec3.Y, vec3.Z, w)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec2"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public Vector4(in Vector2 vec2, float z, float w)
            : this(vec2.X, vec2.Y, z, w)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
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
        {
            return string.Format("Vector4: X = {0}, Y = {1}, Z = {2} W = {3}", X, Y, Z, W);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vector4 other) { return this == other; }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Normalize()
        {
            float lenSqr = X * X + Y * Y + Z * Z + W * W;

            if (!MathHelper.IsZero(lenSqr))
            {
                if (!MathHelper.IsOne(lenSqr))
                {
                    float invNorm = MathHelper.FastSqrtInverse(lenSqr);

                    X *= invNorm;
                    Y *= invNorm;
                    Z *= invNorm;
                    W *= invNorm;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 ToVector2() { return new Vector2(X, Y); }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3 ToVector3() { return new Vector3(X, Y, Z); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Add(float value)
        {
            X += value;
            Y += value;
            Z += value;
            W += value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(in Vector4 other)
        {
            X += other.X;
            Y += other.Y;
            Z += other.Z;
            W += other.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Subtract(float value)
        {
            X -= value;
            Y -= value;
            Z -= value;
            W -= value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Subtract(in Vector4 other)
        {
            X -= other.X;
            Y -= other.Y;
            Z -= other.Z;
            W -= other.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="factor"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Multiply(float factor)
        {
            X *= factor;
            Y *= factor;
            Z *= factor;
            W *= factor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Multiply(in Vector4 other)
        {
            X *= other.X;
            Y *= other.Y;
            Z *= other.Z;
            W *= other.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="divisor"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Divide(float divisor)
        {
            float inv = 1.0f / divisor;
            X *= inv;
            Y *= inv;
            Z *= inv;
            W *= inv;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Divide(in Vector4 other)
        {
            X /= other.X;
            Y /= other.Y;
            Z /= other.Z;
            W /= other.W;
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Negate()
        {
            X = -X;
            Y = -Y;
            Z = -Z;
            W = -W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reset(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

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
            Clamp(value, min, max, out Vector4 result);
            return result;
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="x"></param>
       /// <param name="y"></param>
       /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Distance(in Vector4 x, in Vector4 y)
        {
            float dx = x.X - y.X;
            float dy = x.Y - y.Y;
            float dz = x.Z - y.Z;
            float dw = x.W - y.W;
            return MathF.Sqrt(dx * dx + dy * dy + dz * dz + dw * dw);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float DistanceSquared(in Vector4 x, in Vector4 y)
        {
            float dx = x.X - y.X;
            float dy = x.Y - y.Y;
            float dz = x.Z - y.Z;
            float dw = x.W - y.W;
            return dx * dx + dy * dy + dz * dz + dw * dw;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(in Vector4 left, in Vector4 right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="tangent1"></param>
        /// <param name="y"></param>
        /// <param name="tangent2"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Hermite(in Vector4 x, in Vector4 tangent1,
                                      in Vector4 y, in Vector4 tangent2,
                                      float factor)
        {
            Hermite(x, tangent1, y, tangent2, factor, out Vector4 result);
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
        public static Vector4 Lerp(in Vector4 a, in Vector4 b, float t)
        {
            Lerp(a, b, t, out Vector4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Max(in Vector4 x, in Vector4 y)
        {
            Max(x, y, out Vector4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Min(in Vector4 x, in Vector4 y)
        {
            Min(x, y, out Vector4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Normalize(in Vector4 value)
        {
            Normalize(value, out Vector4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec4"></param>
        /// <param name="normal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Reflect(in Vector4 vec4, in Vector4 normal)
        {
            Reflect(vec4, normal, out Vector4 result);
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
            Refract(vec4, normal, eta, out Vector4 result);
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
            Transform(position, matrix, out Vector4 result);
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
            Transform(position, matrix, out Vector4 result);
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
            Transform(position, matrix, out Vector4 result);
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
            Transform(position, rotation, out Vector4 result);
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
            Transform(position, rotation, out Vector4 result);
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
            Transform(position, rotation, out Vector4 result);
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
        /// <param name="x"></param>
        /// <param name="tangent1"></param>
        /// <param name="y"></param>
        /// <param name="tangent2"></param>
        /// <param name="factor"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Hermite(in Vector4 x, in Vector4 tangent1,
                                   in Vector4 y, in Vector4 tangent2,
                                   float factor, out Vector4 result)
        {
            float squared = factor * factor;
            float cubed = factor * squared;
            float part1 = ((2.0f * cubed) - (3.0f * squared)) + 1.0f;
            float part2 = (-2.0f * cubed) + (3.0f * squared);
            float part3 = (cubed - (2.0f * squared)) + factor;
            float part4 = cubed - squared;

            result.X = (x.X * part1) + (y.X * part2) + (tangent1.X * part3) + (tangent2.X * part4);
            result.Y = (x.Y * part1) + (y.Y * part2) + (tangent1.Y * part3) + (tangent2.Y * part4);
            result.Z = (x.Z * part1) + (y.Z * part2) + (tangent1.Z * part3) + (tangent2.Z * part4);
            result.W = (x.W * part1) + (y.W * part2) + (tangent1.W * part3) + (tangent2.W * part4);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="factor"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Lerp(in Vector4 a, in Vector4 b, float t, out Vector4 result)
        {
            t = MathF.Clamp(t, 0.0f, 1.0f);

            result.X = a.X + (b.X - a.X) * t;
            result.Y = a.Y + (b.Y - a.Y) * t;
            result.Z = a.Z + (b.Z - a.Z) * t;
            result.W = a.W + (b.W - a.W) * t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="factor"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LerpUnclamped(in Vector4 a, in Vector4 b, float t, out Vector4 result)
        {
            result.X = a.X + (b.X - a.X) * t;
            result.Y = a.Y + (b.Y - a.Y) * t;
            result.Z = a.Z + (b.Z - a.Z) * t;
            result.W = a.W + (b.W - a.W) * t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Max(in Vector4 x, in Vector4 y, out Vector4 result)
        {
            result.X = x.X > y.X ? x.X : y.X;
            result.Y = x.Y > y.Y ? x.Y : y.Y;
            result.Z = x.Z > y.Z ? x.Z : y.Z;
            result.W = x.W > y.W ? x.W : y.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Min(in Vector4 x, in Vector4 y, out Vector4 result)
        {
            result.X = x.X < y.X ? x.X : y.X;
            result.Y = x.Y < y.Y ? x.Y : y.Y;
            result.Z = x.Z < y.Z ? x.Z : y.Z;
            result.W = x.W < y.W ? x.W : y.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="a"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Mix(in Vector4 x, in Vector4 y, in Vector4 a, out Vector4 result)
        {
            result.X = x.X * (1.0f - a.X) + y.X * a.X;
            result.Y = x.Y * (1.0f - a.Y) + y.Y * a.Y;
            result.Z = x.Z * (1.0f - a.Z) + y.Z * a.Z;
            result.W = x.W * (1.0f - a.W) + y.W * a.W;
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

            if (!MathHelper.IsZero(lenSqr))
            {
                result.X = value.X;
                result.Y = value.Y;
                result.Z = value.Z;
                result.W = value.W;

                if (!MathHelper.IsOne(lenSqr))
                {
                    float invNorm = MathHelper.FastSqrtInverse(lenSqr);

                    result.X *= invNorm;
                    result.Y *= invNorm;
                    result.Z *= invNorm;
                    result.W *= invNorm;
                }
            }
            else
            {
                result = Vector4.Zero;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <param name="result"></param>
        public static void OuterProduct(in Vector4 column, in Vector2 row, out Matrix4x2 result)
        {
            result.M00 = column.X * row.X;
            result.M01 = column.X * row.Y;
                         
            result.M10 = column.Y * row.X;
            result.M11 = column.Y * row.Y;
                        
            result.M20 = column.Z * row.X;
            result.M21 = column.Z * row.Y;
                        
            result.M30 = column.W * row.X;
            result.M31 = column.W * row.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void OuterProduct(in Vector4 column, in Vector3 row, out Matrix4x3 result)
        {
            result.M00 = column.X * row.X;
            result.M01 = column.X * row.Y;
            result.M02 = column.X * row.Z;
                       
            result.M10 = column.Y * row.X;
            result.M11 = column.Y * row.Y;
            result.M12 = column.Y * row.Z;
                         
            result.M20 = column.Z * row.X;
            result.M21 = column.Z * row.Y;
            result.M22 = column.Z * row.Z;
                       
            result.M30 = column.W * row.X;
            result.M31 = column.W * row.Y;
            result.M32 = column.W * row.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <param name="result"></param>
        public static void OuterProduct(in Vector4 column, in Vector4 row, out Matrix4x4 result)
        {
            result.M00 = column.X * row.X;
            result.M01 = column.X * row.Y;
            result.M02 = column.X * row.Z;
            result.M03 = column.X * row.W;
                     
            result.M10 = column.Y * row.X;
            result.M11 = column.Y * row.Y;
            result.M12 = column.Y * row.Z;
            result.M13 = column.Y * row.W;
                      
            result.M20 = column.Z * row.X;
            result.M21 = column.Z * row.Y;
            result.M22 = column.Z * row.Z;
            result.M23 = column.Z * row.W;
                   
            result.M30 = column.W * row.X;
            result.M31 = column.W * row.Y;
            result.M32 = column.W * row.Z;
            result.M33 = column.W * row.W;
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
        /// <param name="edge0"></param>
        /// <param name="edge1"></param>
        /// <param name="x"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SmoothStep(in Vector4 edge0, in Vector4 edge1, in Vector4 x, out Vector4 result)
        {
            float t = MathF.Clamp((x.X - edge0.X) / (edge1.X - edge0.X), 0.0f, 1.0f);
            float step = t * t * (3.0f - 2.0f * t);
            result.X = edge0.X + (edge1.X - edge0.X) * step;

            t = MathF.Clamp((x.Y - edge0.Y) / (edge1.Y - edge0.Y), 0.0f, 1.0f);
            step = t * t * (3.0f - 2.0f * t);
            result.Y = edge0.Y + (edge1.Y - edge0.Y) * step;

            t = MathF.Clamp((x.Z - edge0.Z) / (edge1.Z - edge0.Z), 0.0f, 1.0f);
            step = t * t * (3.0f - 2.0f * t);
            result.Z = edge0.Z + (edge1.Z - edge0.Z) * step;

            t = MathF.Clamp((x.W - edge0.W) / (edge1.W - edge0.W), 0.0f, 1.0f);
            step = t * t * (3.0f - 2.0f * t);
            result.W = edge0.W + (edge1.W - edge0.W) * step;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <param name="x"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Step(in Vector4 edge, in Vector4 x, out Vector4 result)
        {
            result.X = edge.X >= x.X ? 1.0f : 0.0f;
            result.Y = edge.Y >= x.Y ? 1.0f : 0.0f;
            result.Z = edge.Z >= x.Z ? 1.0f : 0.0f;
            result.W = edge.W >= x.W ? 1.0f : 0.0f;
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
        public static void Subtract(float left, in Vector4 right, out Vector4 result)
        {
            result.X = left - right.X;
            result.Y = left - right.Y;
            result.Z = left - right.Z;
            result.W = left - right.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Subtract(in Vector4 left, float right, out Vector4 result)
        {
            result.X = left.X - right;
            result.Y = left.Y - right;
            result.Z = left.Z - right;
            result.W = left.W - right;
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
        /// <param name="value"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Negate(in Vector4 value, out Vector4 result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
            result.Z = -value.Z;
            result.W = -value.W;
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
        public static Vector4 operator +(in Vector4 left, in Vector4 right)
        {
            return new Vector4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector4 operator +(float left, in Vector4 right)
        {
            return new Vector4(left + right.X, left + right.Y, left + right.Z, left + right.W);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector4 operator +(in Vector4 left, float right)
        {
            return new Vector4(left.X + right, left.Y + right, left.Z + right, left.W + right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator -(in Vector4 value)
        {
            return new Vector4(-value.X, -value.Y, -value.Z, -value.W);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector4 operator -(float left, in Vector4 right)
        {
            return new Vector4(left - right.X, left - right.Y, left - right.Z, left - right.W);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector4 operator -(in Vector4 left, float right)
        {
            return new Vector4(left.X - right, left.Y - right, left.Z - right, left.W - right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator -(in Vector4 left, in Vector4 right)
        {
            return new Vector4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator *(float left, in Vector4 right)
        {
            return new Vector4(left * right.X, left * right.Y, left * right.Z, left * right.W);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator *(in Vector4 left, float right)
        {
            return new Vector4(left.X * right, left.Y * right, left.Z * right, left.W * right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator *(in Vector4 left, in Vector4 right)
        {
            return new Vector4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W + right.W);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator /(in Vector4 left, in Vector4 right)
        {
            return new Vector4(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Vector4 left, in Vector4 right)
        {
            return left.X == right.X && left.Y == right.Y &&
                   left.Z == right.Z && left.W == right.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(in Vector4 left, in Vector4 right)
        {
            return left.X != right.X || left.Y != right.Y || 
                   left.Z != right.Z || left.W != right.W;
        }

        #endregion Operator Overload
    }
}
