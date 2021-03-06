﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Raster.Drawing.Primitive;
using Raster.Private;

namespace Raster.Core.Math
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Vector3
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
        #endregion Public Fields

        #region Constant Fields
        /// <summary>
        /// 
        /// </summary>
        private const float kEpsilon = 0.00001f;
        /// <summary>
        /// 
        /// </summary>
        private const float kEpsilonNormalSqrt = 1e-15f;
        #endregion Constant Fields

        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector3 Zero     = new Vector3( 0.0f,  0.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector3 One      = new Vector3( 1.0f,  1.0f,  1.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector3 Right    = new Vector3( 1.0f,  0.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector3 Up       = new Vector3( 0.0f,  1.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector3 Forward  = new Vector3( 0.0f,  0.0f,  1.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector3 Left     = new Vector3(-1.0f,  0.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector3 Down     = new Vector3( 0.0f, -1.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector3 Back     = new Vector3( 0.0f,  0.0f, -1.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector3 NegOne   = new Vector3(-1.0f, -1.0f, -1.0f);
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
                       float.IsInfinity(Z);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float Length
        {
            get { return MathF.Sqrt(X * X + Y * Y + Z * Z); }
        }

        /// <summary>
        /// 
        /// </summary>
        public float LengthSquared
        {
            get { return X * X + Y * Y + Z * Z; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 MidPoint
        {
            get { return new Vector3(X * 0.5f, Y * 0.5f, Z * 0.5f); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Normalized
        {
            get
            {
                Normalize(in this, out Vector3 result);
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
                }

                throw new ArgumentOutOfRangeException("index", "less than 3");
            }

            set
            {
                switch (index)
                {
                    case 0: X = value; break;
                    case 1: Y = value; break;
                    case 2: Z = value; break;
                    default: throw new ArgumentOutOfRangeException("index", "less than 3");
                }
            }
        }
        #endregion Public Instance Properties

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Vector3(float value)
            : this(value, value, value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public Vector3(in Vector3 other)
            : this(other.X, other.Y, other.Z)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec2"></param>
        /// <param name="z"></param>
        public Vector3(in Vector2 vec2, float z)
            : this(vec2.X, vec2.Y, z)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
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
            if (obj is Vector3)
            {
                return this == (Vector3)obj;
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
            hash = HashHelpers.Combine(hash, this.Z.GetHashCode());
            return hash;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("X={0},Y={1},Z={2}", X, Y, Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vector3 other)
        {
            return this == other;
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Inverse()
        {
            float lenSqr = X * X + Y * Y + Z * Z;

            if (!MathHelper.IsZero(lenSqr))
            {
                float invNorm = 1.0f / lenSqr;
                X *= invNorm;
                Y *= invNorm;
                Z *= invNorm;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Normalize()
        {
            float lenSqr = X * X + Y * Y + Z * Z;

            if (!MathHelper.IsZero(lenSqr))
            {
                if (!MathHelper.IsOne(lenSqr))
                {
                    float invNorm = MathHelper.FastSqrtInverse(lenSqr);

                    X *= invNorm;
                    Y *= invNorm;
                    Z *= invNorm;
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
        public Vector4 ToVector4() { return new Vector4(X, Y, Z, 1.0f); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(float value)
        {
            X += value;
            Y += value;
            Z += value;
        }
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(in Vector3 other)
        {
            X += other.X;
            Y += other.Y;
            Z += other.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(float x, float y, float z)
        {
            X += x;
            Y += y;
            Z += z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Subtract(float value)
        {
            X -= value;
            Y -= value;
            Z -= value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Subtract(in Vector3 other)
        {
            X -= other.X;
            Y -= other.Y;
            Z -= other.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Subtract(float x, float y, float z)
        {
            X -= x;
            Y -= y;
            Z -= z;
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Multiply(in Vector3 other)
        {
            X *= other.X;
            Y *= other.Y;
            Z *= other.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Multiply(float x, float y, float z)
        {
            X *= x;
            Y *= y;
            Z *= z;
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Divide(in Vector3 other)
        {
            X /= other.X;
            Y /= other.Y;
            Z /= other.Z;
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reset(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AngleBetween(in Vector3 from, in Vector3 to)
        {
            float denominator = MathF.Sqrt(from.LengthSquared * to.LengthSquared);
            if (denominator < kEpsilonNormalSqrt)
            {
                return 0.0f;
            }

            float dot = MathF.Clamp(Dot(from, to) / denominator, -1.0f, 1.0f);
            return MathF.Acos(dot);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SignedAngle(in Vector3 from, in Vector3 to)
        {
            float unsigned_angle = AngleBetween(from, to);
            float sign = MathF.Sign(from.X * to.Y - from.Y * to.X);
            return unsigned_angle * sign;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Cross(in Vector3 left, in Vector3 right)
        {
            Cross(left, right, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DistanceSquared(in Vector3 x, in Vector3 y)
        {
            float dx = x.X - y.X;
            float dy = x.Y - y.Y;
            float dz = x.Z - y.Z;
            return dx * dx + dy * dy + dz * dz;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(in Vector3 left, in Vector3 right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
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
        public static Vector3 Hermite(in Vector3 x, in Vector3 tangent1, 
                                      in Vector3 y, in Vector3 tangent2, 
                                      float factor)
        {
            Hermite(x, tangent1, y, tangent2, factor, out Vector3 result);
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
        public static Vector3 Lerp(in Vector3 a, in Vector3 b, float t)
        {
            Lerp(a, b, t, out Vector3 result);
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
        public static Vector3 LerpUnclamped(in Vector3 a, in Vector3 b, float t)
        {
            LerpUnclamped(a, b, t, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Max(in Vector3 x, in Vector3 y)
        {
            Max(x, y, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Min(in Vector3 x, in Vector3 y)
        {
            Min(x, y, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="maxDistanceDelta"></param>
        /// <returns></returns>
        public static Vector3 MoveTowards(in Vector3 current, in Vector3 target, float maxDistanceDelta)
        {
            MoveTowards(current, target, maxDistanceDelta, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Normalize(in Vector3 value)
        {
            Normalize(value, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Perpendicular(in Vector3 value)
        {
            Perpendicular(value, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="normal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Project(in Vector3 vector, in Vector3 normal)
        {
            Project(vector, normal, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="normal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 ProjectOnPlane(in Vector3 vector, in Vector3 planeNormal)
        {
            Project(vector, planeNormal, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="view"></param>
        /// <param name="projection"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Project(in Vector3 position,
                                      in Matrix4x4 model, in Matrix4x4 view, in Matrix4x4 projection,
                                      in ViewportF viewport)
        {
            Matrix4x4.Multiply(model, view, out Matrix4x4 temp);
            Matrix4x4.Multiply(temp, projection, out Matrix4x4 worldViewProjection);

            Project(position, worldViewProjection, viewport, out Vector3 result);
            return result;
        }

        public static Vector3 Unproject(in Vector3 position,
                                        in Matrix4x4 model, in Matrix4x4 view, in Matrix4x4 projection,
                                        in ViewportF viewport)
        {
            Matrix4x4.Multiply(model, view, out Matrix4x4 temp);
            Matrix4x4.Multiply(temp, projection, out Matrix4x4 worldViewProjection);

            Matrix4x4.Invert(worldViewProjection, out temp);
            Unproject(position, temp, viewport, out Vector3 result);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec3"></param>
        /// <param name="normal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Reflect(in Vector3 vec3, in Vector3 normal)
        {
            Reflect(vec3, normal, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec3"></param>
        /// <param name="normal"></param>
        /// <param name="eta"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Refract(in Vector3 vec3, in Vector3 normal, float eta)
        {
            Refract(vec3, normal, eta, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Transform(in Vector3 position, in Matrix4x4 matrix)
        {
            Transform(position, matrix, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinate"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Vector3 TransformCoordinate(in Vector3 coordinate, in Matrix4x4 matrix)
        {
            TransformCoordinate(coordinate, matrix, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 TransformNormal(in Vector3 position, in Matrix4x4 matrix)
        {
            TransformNormal(position, matrix, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Transform(in Vector3 position, in Quaternion rotation)
        {
            Transform(position, rotation, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="result"></param>
        public static void CalculateTriangleNormal(in Vector3 v0, in Vector3 v1, in Vector3 v2,
                                                   out Vector3 result)
        {
            Vector3 edge0 = v1 - v0;
            Vector3 edge1 = v2 - v0;

            Cross(edge0, edge1, out Vector3 temp);
            Normalize(temp, out result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Clamp(in Vector3 value, in Vector3 min, in Vector3 max, out Vector3 result)
        {
            result.X = (min.X > value.X) ? min.X : value.X;
            result.X = (max.X < value.X) ? max.X : value.X;

            result.Y = (min.Y > value.Y) ? min.Y : value.Y;
            result.Y = (max.Y < value.Y) ? max.Y : value.Y;

            result.Z = (min.Z > value.Z) ? min.Z : value.Z;
            result.Z = (max.Z < value.Z) ? max.Z : value.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="maxLength"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ClampMagnitude(in Vector3 vector, float maxLength, out Vector3 result)
        {
            float lenSqr = vector.LengthSquared;
            if (lenSqr > maxLength * maxLength)
            {
                float len = MathF.Sqrt(lenSqr);

                float normalized_x = vector.X / len;
                float normalized_y = vector.Y / len;
                float normalized_z = vector.Z / len;

                result.X = normalized_x * maxLength;
                result.Y = normalized_y * maxLength;
                result.Z = normalized_z * maxLength;
                return;
            }

            result.X = vector.X;
            result.Y = vector.Y;
            result.Z = vector.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cross(in Vector3 left, in Vector3 right, out Vector3 result)
        {
            result.X = left.Y * right.Z - left.Z * right.Y;
            result.Y = left.X * right.Z - left.Z * right.X;
            result.Z = left.X * right.Y - left.Y * right.X;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Distance(in Vector3 x, in Vector3 y)
        {
            float dx = x.X - y.X;
            float dy = x.Y - y.Y;
            float dz = x.Z - y.Z;
            return MathF.Sqrt(dx * dx + dy * dy + dz * dz);
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
        public static void Hermite(in Vector3 x, in Vector3 tangent1, 
                                   in Vector3 y, in Vector3 tangent2, 
                                   float factor, out Vector3 result)
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="factor"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Lerp(in Vector3 x, in Vector3 y, float t, out Vector3 result)
        {
            t = MathF.Clamp(t, 0.0f, 1.0f);

            result.X = x.X + (y.X - x.X) * t;
            result.Y = x.Y + (y.Y - x.Y) * t;
            result.Z = x.Z + (y.Z - x.Z) * t;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="factor"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LerpUnclamped(in Vector3 x, in Vector3 y, float t, out Vector3 result)
        {
            result.X = x.X + (y.X - x.X) * t;
            result.Y = x.Y + (y.Y - x.Y) * t;
            result.Z = x.Z + (y.Z - x.Z) * t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Max(in Vector3 x, in Vector3 y, out Vector3 result)
        {
            result.X = (x.X > y.X) ? x.X : y.X;
            result.Y = (x.Y > y.Y) ? x.Y : y.Y;
            result.Z = (x.Z > y.Z) ? x.Z : y.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Min(in Vector3 x, in Vector3 y, out Vector3 result)
        {
            result.X = (x.X < y.X) ? x.X : y.X;
            result.Y = (x.Y < y.Y) ? x.Y : y.Y;
            result.Z = (x.Z < y.Z) ? x.Z : y.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="a"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Mix(in Vector3 x, in Vector3 y, in Vector3 a, out Vector3 result)
        {
            result.X = x.X * (1.0f - a.X) + y.X * a.X;
            result.Y = x.Y * (1.0f - a.Y) + y.Y * a.Y;
            result.Z = x.Z * (1.0f - a.Z) + y.Z * a.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="maxDistanceDelta"></param>
        /// <returns></returns>
        public static void MoveTowards(in Vector3 current, in Vector3 target, float maxDistanceDelta, out Vector3 result)
        {
            float toVector_x = target.X - current.X;
            float toVector_y = target.Y - current.Y;
            float toVector_z = target.Z - current.Z;

            float sqdist = toVector_x * toVector_x + toVector_y * toVector_y + toVector_z * toVector_z;

            if (sqdist == 0 || sqdist <= maxDistanceDelta * maxDistanceDelta)
            {
                result = target;
            }

            float dist = MathF.Sqrt(sqdist);

            result.X = current.X + toVector_x / dist * maxDistanceDelta;
            result.Y = current.Y + toVector_y / dist * maxDistanceDelta;
            result.Z = current.Z + toVector_y / dist * maxDistanceDelta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Normalize(in Vector3 value, out Vector3 result)
        {
            float lenSqr = value.X * value.X + value.Y * value.Y +
                           value.Z * value.Z;

            if (!MathHelper.IsZero(lenSqr))
            {
                result.X = value.X;
                result.Y = value.Y;
                result.Z = value.Z;

                if (!MathHelper.IsOne(lenSqr))
                {
                    float invNorm = MathHelper.FastSqrtInverse(lenSqr);

                    result.X *= invNorm;
                    result.Y *= invNorm;
                    result.Z *= invNorm;
                }
            }
            else
            {
                result = Vector3.Zero;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <param name="result"></param>
        public static void OuterProduct(in Vector3 column, in Vector2 row, out Matrix3x2 result)
        {
            result.M00 = column.X * row.X;
            result.M01 = column.X * row.Y;

            result.M10 = column.Y * row.X;
            result.M11 = column.Y * row.Y;

            result.M20 = column.Z * row.X;
            result.M21 = column.Z * row.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <param name="result"></param>
        public static void OuterProduct(in Vector3 column, in Vector3 row, out Matrix3x3 result)
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <param name="result"></param>
        public static void OuterProduct(in Vector3 column, in Vector4 row, out Matrix3x4 result)
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec3"></param>
        /// <param name="perp"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Perpendicular(in Vector3 vec3, out Vector3 result)
        {
            const float square_zero = (float)(1e-6 * 1e-6);

            // Cross perp with UnitX
            result.X = 0.0f;
            result.Y = -1.0f * vec3.Z;
            result.Z = -1.0f * vec3.Y;

            if (result.LengthSquared < square_zero)
            {
                // Cross perp with UnitY
                result.X = -1.0f * vec3.Z;
                result.Y = 0.0f;
                result.Z = 1.0f * vec3.X;
            }

            result.Normalize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="normal"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Project(in Vector3 vector, in Vector3 normal, out Vector3 result)
        {
            float sqrLength = Dot(normal, normal);
            if (sqrLength < MathF.Epsilon)
            {
                result.X = 0.0f;
                result.Y = 0.0f;
                result.Z = 0.0f;
            }
            else
            {
                float dot = Dot(vector, normal);
                float invSqrLength = 1.0f / sqrLength;

                result.X = normal.X * dot * invSqrLength;
                result.Y = normal.Y * dot * invSqrLength;
                result.Z = normal.Z * dot * invSqrLength;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="planeNormal"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ProjectOnPlane(in Vector3 vector, in Vector3 planeNormal, out Vector3 result)
        {
            float sqrLength = Dot(planeNormal, planeNormal);
            if (sqrLength < MathF.Epsilon)
            {
                result.X = vector.X;
                result.Y = vector.Y;
                result.Z = vector.Z;
            }
            else
            {
                float dot = Dot(vector, planeNormal);
                float invSqrLength = 1.0f / sqrLength;

                result.X = vector.X - planeNormal.X * dot * invSqrLength;
                result.Y = vector.Y - planeNormal.Y * dot * invSqrLength;
                result.Z = vector.Z - planeNormal.Z * dot * invSqrLength;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="worldViewProjection"></param>
        /// <param name="viewport"></param>
        /// <param name="result"></param>
        public static void Project(in Vector3 position, in Matrix4x4 worldViewProjection, in ViewportF viewport, out Vector3 result)
        {
            TransformCoordinate(position, worldViewProjection, out result);
            result.X = ((result.X + 1.0f) * 0.5f * viewport.Bounds.Width) + viewport.Bounds.X;
            result.Y = ((1.0f - result.Y) * 0.5f * viewport.Bounds.Height) + viewport.Bounds.Y;
            result.Z = (result.Z * (viewport.MaxDepth - viewport.MinDepth)) + viewport.MinDepth;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="view"></param>
        /// <param name="projection"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Unproject(in Vector3 position,
                                     in Matrix4x4 invertedWorldViewProjection,
                                     in ViewportF viewport,
                                     out Vector3 result)
        {
            result.X = (((position.X - viewport.Bounds.X) / viewport.Bounds.Width) * 2.0f) - 1.0f;
            result.Y = -((((position.Y - viewport.Bounds.Y) / viewport.Bounds.Height) * 2.0f) - 1.0f);
            result.Z = (position.Z - viewport.MinDepth) / (viewport.MaxDepth - viewport.MinDepth);

            TransformCoordinate(position, invertedWorldViewProjection, out result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec3"></param>
        /// <param name="normal"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Reflect(in Vector3 vec3, in Vector3 normal, out Vector3 result)
        {
            float dot = vec3.X + normal.X + vec3.Y * normal.Y +
                        vec3.Z * normal.Z;

            result.X = vec3.X - 2.0f * dot * normal.X;
            result.Y = vec3.Y - 2.0f * dot * normal.Y;
            result.Z = vec3.Z - 2.0f * dot * normal.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec3"></param>
        /// <param name="normal"></param>
        /// <param name="eta"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Refract(in Vector3 vec3, in Vector3 normal, float eta, out Vector3 result)
        {
            float dot = vec3.X * normal.X + vec3.Y * normal.Y +
                        vec3.Z * normal.Z;
            float k = 1.0f - eta * eta * (1.0f - dot * dot);

            if (k < 0.0f)
            {
                result = Zero;
            }
            else
            {
                float sqrtk = MathF.Sqrt(k);

                result.X = eta * vec3.X - (eta * dot + sqrtk) * normal.X;
                result.Y = eta * vec3.Y - (eta * dot + sqrtk) * normal.Y;
                result.Z = eta * vec3.Z - (eta * dot + sqrtk) * normal.Z;
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
        public static void SmoothStep(in Vector3 edge0, in Vector3 edge1, in Vector3 x, out Vector3 result)
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <param name="x"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Step(in Vector3 edge, in Vector3 x, out Vector3 result)
        {
            result.X = edge.X >= x.X ? 1.0f : 0.0f;
            result.Y = edge.Y >= x.Y ? 1.0f : 0.0f;
            result.Z = edge.Z >= x.Z ? 1.0f : 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Transform(in Vector3 position, in Matrix4x4 matrix, out Vector3 result)
        {
            result.X = position.X * matrix.M00 + position.Y * matrix.M10 + 
                       position.Z * matrix.M20 + matrix.M30;
            result.Y = position.Y * matrix.M01 + position.Y * matrix.M11 + 
                       position.Z * matrix.M21 + matrix.M31;
            result.Z = position.Z * matrix.M02 + position.Y * matrix.M12 + 
                       position.Z * matrix.M22 + matrix.M32;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinate"></param>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        public static void TransformCoordinate(in Vector3 coordinate, in Matrix4x4 matrix, out Vector3 result)
        {
            Vector4 vector;
            vector.X = coordinate.X * matrix.M00 + coordinate.Y * matrix.M10 + coordinate.Z * matrix.M30;
            vector.Y = coordinate.X * matrix.M01 + coordinate.Y * matrix.M11 + coordinate.Z * matrix.M21;
            vector.Z = coordinate.X * matrix.M02 + coordinate.Y * matrix.M12 + coordinate.Z * matrix.M22;
            vector.W = 1.0f / (coordinate.X * matrix.M03 + coordinate.Y * matrix.M13 + coordinate.Z * matrix.M23 + matrix.M33);

            result.X = vector.X * vector.W;
            result.Y = vector.Y * vector.W;
            result.Z = vector.Z * vector.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="normal"></param>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TransformNormal(in Vector3 normal, in Matrix4x4 matrix, out Vector3 result)
        {
            result.X = normal.X * matrix.M00 + normal.Y * matrix.M10 + 
                       normal.Z * matrix.M20 + matrix.M30;
            result.Y = normal.Y * matrix.M01 + normal.Y * matrix.M11 + 
                       normal.Z * matrix.M21 + matrix.M31;
            result.Z = normal.Z * matrix.M02 + normal.Y * matrix.M12 + 
                       normal.Z * matrix.M22 + matrix.M32;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Transform(in Vector3 position, in Quaternion rotation, out Vector3 result)
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add(in Vector3 left, float right, out Vector3 result)
        {
            result.X = left.X + right;
            result.Y = left.Y + right;
            result.Z = left.Z + right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add(in Vector3 left, in Vector3 right, out Vector3 result)
        {
            result.X = left.X + right.X;
            result.Y = left.Y + right.Y;
            result.Z = left.Z + right.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Subtract(float left, in Vector3 right, out Vector3 result)
        {
            result.X = left - right.X;
            result.Y = left - right.Y;
            result.Z = left - right.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Subtract(in Vector3 left, float right, out Vector3 result)
        {
            result.X = left.X - right;
            result.Y = left.Y - right;
            result.Z = left.Z - right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Subtract(in Vector3 left, in Vector3 right, out Vector3 result)
        {
            result.X = left.X - right.X;
            result.Y = left.Y - right.Y;
            result.Z = left.Z - right.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Multiply(in Vector3 left, float right, out Vector3 result)
        {
            result.X = left.X * right;
            result.Y = left.Y * right;
            result.Z = left.Z * right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Multiply(in Vector3 left, in Vector3 right, out Vector3 result)
        {
            result.X = left.X * right.X;
            result.Y = left.Y * right.Y;
            result.Z = left.Z * right.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Negate(in Vector3 value, out Vector3 result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
            result.Z = -value.Z;
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
        public static Vector3 operator +(in Vector3 left, in Vector3 right)
        {
            return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector3 operator +(float left, in Vector3 right)
        {
            return new Vector3(left + right.X, left + right.Y, left + right.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector3 operator +(in Vector3 left, float right)
        {
            return new Vector3(left.X + right, left.Y + right, left.Z + right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator -(in Vector3 value)
        {
            return new Vector3(-value.X, -value.Y, -value.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector3 operator -(float left, in Vector3 right)
        {
            return new Vector3(left - right.X, left - right.Y, left - right.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector3 operator -(in Vector3 left, float right)
        {
            return new Vector3(left.X - right, left.Y - right, left.Z - right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator -(in Vector3 left, in Vector3 right)
        {
            return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="right"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator *(float left, in Vector3 right)
        {
            return new Vector3(left * right.X, left * right.Y, left * right.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator *(in Vector3 left, float right)
        {
            return new Vector3(left.X * right, left.Y * right, left.Z * right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator *(in Vector3 left, in Vector3 right)
        {
            return new Vector3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator /(in Vector3 left, float right)
        {
            return new Vector3(left.X / right, left.Y / right, left.Z / right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator /(in Vector3 left, in Vector3 right)
        {
            return new Vector3(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Vector3 left, in Vector3 right)
        {
            float diff_x = left.X - right.X;
            float diff_y = left.Y - right.Y;
            float diff_z = left.Z - right.Z;

            float sqrLength = diff_x * diff_x + diff_y * diff_y + diff_z * diff_z;
            return sqrLength < kEpsilon * kEpsilon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(in Vector3 left, in Vector3 right)
        {
            return left.X != right.X || left.Y != right.Y ||
                   left.Z != right.Z;
        }

        #endregion Operator Overload   
    }
}
