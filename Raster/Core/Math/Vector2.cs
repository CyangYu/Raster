﻿using System;
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

        #region Constant Fields
        /// <summary>
        /// 
        /// </summary>
        public const float kEpsilon = 0.00001f;
        /// <summary>
        /// 
        /// </summary>
        public const float kEpsilonNormalSqrt = 1e-15f;
        #endregion Constant Fields

        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector2 Zero     = new Vector2( 0.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector2 One      = new Vector2( 1.0f,  1.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector2 Left     = new Vector2( 1.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector2 Up       = new Vector2( 0.0f,  1.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector2 Right    = new Vector2(-1.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector2 Down     = new Vector2( 0.0f, -1.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector2 NegOne   = new Vector2(-1.0f, -1.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector2 PositiveInfinity = new Vector2(float.PositiveInfinity, float.PositiveInfinity);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector2 NegativeInfinity = new Vector2(float.NegativeInfinity, float.NegativeInfinity);
        #endregion Public Static Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public bool IsInfinity
        {
            get { return float.IsInfinity(X) && float.IsInfinity(Y); }
        }

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

        /// <summary>
        /// 
        /// </summary>
        public Vector2 Normalized
        {
            get
            {
                Normalize(in this, out Vector2 result);
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
                }

                throw new ArgumentOutOfRangeException("index", "less than 2");
            }

            set
            {
                switch (index)
                {
                    case 0: X = value; break;
                    case 1: Y = value; break;
                    default: throw new ArgumentOutOfRangeException("index", "less than 2");
                }
            }
        }

        #endregion Public Instance Properties

        #region Constructor
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Vector2(float value)
            : this(value, value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public Vector2(in Vector2 other)
        {
            X = other.X;
            Y = other.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
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
                return this == (Vector2)obj;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashHelpers.Combine(X.GetHashCode(), Y.GetHashCode());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Vector2: X = {0}, Y = {1}", X, Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vector2 other)
        {
            return this == other;
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Inverse()
        {
            float lenSqr = X * X + Y * Y;
            
            if (!MathHelper.IsZero(lenSqr))
            {
                float invNorm = 1.0f / lenSqr;
                X *= invNorm;
                Y *= invNorm;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Normalize()
        {
            float lenSqr = X * X + Y * Y;

            if (!MathHelper.IsZero(lenSqr))
            {
                if (!MathHelper.IsOne(lenSqr))
                {
                    float invNorm = MathHelper.FastSqrtInverse(lenSqr);

                    X *= invNorm;
                    Y *= invNorm;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vector3 ToVector3() { return new Vector3(X, Y, 1.0f); }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vector4 ToVector4() { return new Vector4(X, Y, 1.0f, 1.0f); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(float value)
        {
            X += value;
            Y += value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(in Vector2 other)
        {
            X += other.X;
            Y += other.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(float x, float y)
        {
            X += x;
            Y += y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Subtract(float x, float y)
        {
            X -= x;
            Y -= y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Subtract(in Vector2 other)
        {
            X -= other.X;
            Y -= other.Y;
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Multiply(in Vector2 other)
        {
            X *= other.X;
            Y *= other.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Multiply(float x, float y)
        {
            X *= x;
            Y *= y;
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Divide(in Vector2 other)
        {
            X /= other.X;
            Y /= other.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Negate()
        {
            X = -X;
            Y = -Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reset(float x, float y)
        {
            X = x;
            Y = y;
        }

        #endregion Public Instance Method

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AngleBetween(in Vector2 from, in Vector2 to)
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
        public static float SignedAngle(in Vector2 from, in Vector2 to)
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
        public static Vector2 Clamp(in Vector2 value, in Vector2 min, in Vector2 max)
        {
            Clamp(value, min, max, out Vector2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 ClampMagnitude(in Vector2 vector, float maxLength)
        {
            ClampMagnitude(vector, maxLength, out Vector2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cross(in Vector2 left, in Vector2 right)
        {
            return left.X * right.Y - left.Y * right.X;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Distance(in Vector2 x, in Vector2 y)
        {
            float dx = x.X - y.X;
            float dy = x.Y - y.Y;
            return MathF.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DistanceSquared(in Vector2 x, in Vector2 y)
        {
            float dx = x.X - y.X;
            float dy = x.Y - y.Y;
            return dx * dx + dy * dy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(in Vector2 left, in Vector2 right)
        {
            return left.X * right.X + left.Y * right.Y;
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
        public static Vector2 Hermite(in Vector2 x, in Vector2 tangent1, 
                                      in Vector2 y, in Vector2 tangent2, 
                                      float factor)
        {
            Hermite(x, tangent1, y, tangent2, factor, out Vector2 result);
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
        public static Vector2 Lerp(in Vector2 a, in Vector2 b, float t)
        {
            Lerp(a, b, t, out Vector2 result);
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
        public static Vector2 LerpUnclamped(in Vector2 a, in Vector2 b, float t)
        {
            LerpUnclamped(a, b, t, out Vector2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Max(in Vector2 x, in Vector2 y)
        {
            Max(x, y, out Vector2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Min(in Vector2 x, in Vector2 y)
        {
            Min(x, y, out Vector2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="maxDistanceDelta"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 MoveTowards(in Vector2 current, in Vector2 target, float maxDistanceDelta)
        {
            MoveTowards(current, target, maxDistanceDelta, out Vector2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Normalize(in Vector2 value)
        {
            Normalize(value, out Vector2 result);
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
            Perpendicular(value, out Vector2 result);
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
            Reflect(vec2, normal, out Vector2 result);
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
            Refract(vec2, normal, eta, out Vector2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="currentVelocity"></param>
        /// <param name="smoothTime"></param>
        /// <param name="maxSpeed"></param>
        /// <param name="deltaTime"></param>
        /// <returns></returns>
        public static Vector2 SmoothDamp(in Vector2 current, in Vector2 target, ref Vector2 currentVelocity,
                                         float smoothTime, float maxSpeed, float deltaTime)
        {
            SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime, out Vector2 result);
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
        public static Vector2 SmoothStep(in Vector2 edge0, in Vector2 edge1, in Vector2 x)
        {
            SmoothStep(edge0, edge1, x, out Vector2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Transform(in Vector2 position, in Matrix3x3 matrix)
        {
            Transform(position, matrix, out Vector2 result);
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
            Transform(position, matrix, out Vector2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="normal"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 TransformNormal(in Vector2 normal, in Matrix3x3 matrix)
        {
            TransformNormal(normal, matrix, out Vector2 result);
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
            TransformNormal(normal, matrix, out Vector2 result);
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
            Transform(position, rotation, out Vector2 result);
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
        /// <param name="vector"></param>
        /// <param name="maxLength"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ClampMagnitude(in Vector2 vector, float maxLength, out Vector2 result)
        {
            float lenSqr = vector.LengthSquared;
            if (lenSqr > maxLength * maxLength)
            {
                float len = MathF.Sqrt(lenSqr);

                float normalized_x = vector.X / len;
                float normalized_y = vector.Y / len;

                result.X = normalized_x * maxLength;
                result.Y = normalized_y * maxLength;

                return;
            }

            result.X = vector.X;
            result.Y = vector.Y;
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
        public static void Hermite(in Vector2 x, in Vector2 tangent1, 
                                   in Vector2 y, in Vector2 tangent2, 
                                   float factor, out Vector2 result)
        {
            float squared = factor * factor;
            float cubed = factor * squared;
            float part1 = ((2.0f * cubed) - (3.0f * squared)) + 1.0f;
            float part2 = (-2.0f * cubed) + (3.0f * squared);
            float part3 = (cubed - (2.0f * squared)) + factor;
            float part4 = cubed - squared;

            result.X = (x.X * part1) + (y.X * part2) + (tangent1.X * part3) + (tangent2.X * part4);
            result.Y = (x.Y * part1) + (y.Y * part2) + (tangent1.Y * part3) + (tangent2.Y * part4);
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
        public static void Lerp(in Vector2 a, in Vector2 b, float t, out Vector2 result)
        {
            t = MathF.Clamp(t, 0.0f, 1.0f);

            result.X = a.X + (b.X - a.X) * t;
            result.Y = a.Y + (b.Y - a.Y) * t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="factor"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LerpUnclamped(in Vector2 a, in Vector2 b, float t, out Vector2 result)
        {
            result.X = a.X + (b.X - a.X) * t;
            result.Y = a.Y + (b.Y - a.Y) * t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Max(in Vector2 x, in Vector2 y, out Vector2 result)
        {
            result.X = (x.X > y.X) ? x.X : y.X;
            result.Y = (x.Y > y.Y) ? x.Y : y.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Min(in Vector2 x, in Vector2 y, out Vector2 result)
        {
            result.X = (x.X < y.X) ? x.X : y.X;
            result.Y = (x.Y < y.Y) ? x.Y : y.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="a"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Mix(in Vector2 x, in Vector2 y, in Vector2 a, out Vector2 result)
        {
            result.X = x.X * (1.0f - a.X) + y.X * a.X;
            result.Y = x.Y * (1.0f - a.Y) + y.Y * a.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="maxDistanceDelta"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MoveTowards(in Vector2 current, in Vector2 target, float maxDistanceDelta, out Vector2 result)
        {
            float toVector_x = target.X - current.X;
            float toVector_y = target.Y - current.Y;

            float sqrDistance = toVector_x * toVector_x + toVector_y * toVector_y;

            if (sqrDistance == 0.0f || (maxDistanceDelta >= 0.0f && sqrDistance <= maxDistanceDelta))
            {
                result.X = target.X;
                result.Y = target.Y;
                return;
            }

            float distance = MathF.Sqrt(sqrDistance);

            result.X = current.X + toVector_x / distance * maxDistanceDelta;
            result.Y = current.Y + toVector_y / distance * maxDistanceDelta;
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

            if (!MathHelper.IsZero(lenSqr))
            {
                result = value;

                if (!MathHelper.IsOne(lenSqr))
                {
                    float invNorm = MathHelper.FastSqrtInverse(lenSqr);

                    result.X *= invNorm;
                    result.Y *= invNorm;
                }
            }
            else
            {
                result = Vector2.Zero;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <param name="result"></param>
        public static void OuterProduct(in Vector2 column, in Vector2 row, out Matrix2x2 result)
        {
            result.M00 = column.X * row.X;
            result.M01 = column.X * row.Y;

            result.M10 = column.Y * row.X;
            result.M11 = column.Y * row.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <param name="result"></param>
        public static void OuterProduct(in Vector2 column, in Vector3 row, out Matrix2x3 result)
        {
            result.M00 = column.X * row.X;
            result.M01 = column.X * row.Y;
            result.M02 = column.X * row.Z;

            result.M10 = column.Y * row.X;
            result.M11 = column.Y * row.Y;
            result.M12 = column.Y * row.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <param name="result"></param>
        public static void OuterProduct(in Vector2 column, in Vector4 row, out Matrix2x4 result)
        {
            result.M00 = column.X * row.X;
            result.M01 = column.X * row.Y;
            result.M02 = column.X * row.Z;
            result.M03 = column.X * row.W;
                         
            result.M10 = column.Y * row.X;
            result.M11 = column.Y * row.Y;
            result.M12 = column.Y * row.Z;
            result.M13 = column.Y * row.W;
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
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="currentVelocity"></param>
        /// <param name="smoothTime"></param>
        /// <param name="maxSpeed"></param>
        /// <param name="deltaTime"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SmoothDamp(in Vector2 current, in Vector2 target, ref Vector2 currentVelocity, 
                                      float smoothTime, float maxSpeed, float deltaTime, 
                                      out Vector2 result)
        {
            smoothTime = MathF.Max(0.0001f, smoothTime);
            float omega = 2.0f / smoothTime;

            float x = omega / deltaTime;
            float exp = 1.0f / (1.0f + x + 0.48f * x * x + 0.235f * x * x * x);

            float change_x = current.X - target.X;
            float change_y = current.Y - target.Y;
            Vector2 originalTo = target;

            float maxChange = maxSpeed * smoothTime;

            float maxChangeSqr = maxChange * maxChange;
            float sqrDistance = change_x * change_x + change_y * change_y;

            if (sqrDistance > maxChangeSqr)
            {
                float distsnce = MathF.Sqrt(sqrDistance);
                change_x = change_x / distsnce * maxChange;
                change_y = change_y / distsnce * maxChange;
            }

            Vector2 targetVec;
            targetVec.X = current.X - change_x;
            targetVec.Y = current.Y - change_y;

            float temp_x = (currentVelocity.X + omega * change_x) * deltaTime;
            float temp_y = (currentVelocity.Y + omega * change_y) * deltaTime;

            currentVelocity.X = (currentVelocity.X - omega * temp_x) * exp;
            currentVelocity.Y = (currentVelocity.Y - omega * temp_y) * exp;

            float output_x = targetVec.X + (change_x + temp_x) * exp;
            float output_y = targetVec.Y + (change_y + temp_y) * exp;

            // Prevent overshooting
            float origMinusCurrent_x = originalTo.X - current.X;
            float origMinusCurrent_y = originalTo.Y - current.Y;
            float outMinusOrig_x = output_x - originalTo.X;
            float outMinusOrig_y = output_y - originalTo.Y;

            if (origMinusCurrent_x * outMinusOrig_x + origMinusCurrent_y * outMinusOrig_y > 0)
            {
                output_x = originalTo.X;
                output_y = originalTo.Y;

                currentVelocity.X = (output_x - originalTo.X) / deltaTime;
                currentVelocity.Y = (output_y - originalTo.Y) / deltaTime;
            }

            result.X = output_x;
            result.Y = output_y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="x"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SmoothStep(in Vector2 edge0, in Vector2 edge1, in Vector2 x, out Vector2 result)
        {
            float t = MathF.Clamp((x.X - edge0.X) / (edge1.X - edge0.X), 0.0f, 1.0f);
            float step = t * t * (3.0f - 2.0f * t);
            result.X = edge0.X + (edge1.X - edge0.X) * step;

            t = MathF.Clamp((x.Y - edge0.Y) / (edge1.Y - edge0.Y), 0.0f, 1.0f);
            step = t * t * (3.0f - 2.0f * t);
            result.Y = edge0.Y + (edge1.Y - edge0.Y) * step;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <param name="x"></param>
        /// <param name="result"></param>
        public static void Step(in Vector2 edge, in Vector2 x, out Vector2 result)
        {
            result.X = (edge.X - x.X) >= kEpsilon ? 1.0f : 0.0f;
            result.Y = (edge.Y - x.Y) >= kEpsilon ? 1.0f : 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Transform(in Vector2 position, in Matrix3x3 matrix, out Vector2 result)
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
        public static void TransformNormal(in Vector2 normal, in Matrix3x3 matrix, out Vector2 result)
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
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add(in Vector2 left, float right, out Vector2 result)
        {
            result.X = left.X + right;
            result.Y = left.Y + right;
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
        public static void Subtract(float left, in Vector2 right, out Vector2 result)
        {
            result.X = left - right.X;
            result.Y = left - right.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Subtract(in Vector2 left, float right, out Vector2 result)
        {
            result.X = left.X - right;
            result.Y = left.Y - right;
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
            result.X = left.X - right.X;
            result.Y = left.Y - right.Y;
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
        public static Vector2 operator +(float left, in Vector2 right)
        {
            return new Vector2(left + right.X, left + right.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator +(in Vector2 left, float right)
        {
            return new Vector2(left.X + right, left.Y + right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator +(in Vector2 left, in Vector2 right)
        {
            return new Vector2(left.X + right.X, left.Y + right.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator -(in Vector2 value)
        {
            return new Vector2(-value.X, -value.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator -(float left, in Vector2 right)
        {
            return new Vector2(left - right.X, left - right.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator -(in Vector2 left, float right)
        {
            return new Vector2(left.X - right, left.Y - right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator -(in Vector2 left, in Vector2 right)
        {
            return new Vector2(left.X - right.X, left.Y - right.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator *(float left, in Vector2 right)
        {
            return new Vector2(left * right.X, left * right.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator *(in Vector2 left, float right)
        {
            return new Vector2(left.X * right, left.Y * right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator *(in Vector2 left, in Vector2 right)
        {
            return new Vector2(left.X * right.X, left.Y * right.Y);
        }
          
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator /(in Vector2 left, float right)
        {
            return new Vector2(left.X / right, left.Y / right);
        }  

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator /(in Vector2 left, in Vector2 right)
        {
            return new Vector2(left.X / right.X, left.Y / right.Y);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector3(in Vector2 v)
        {
            return new Vector3(v.X, v.Y, 0.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector4(in Vector2 v)
        {
            return new Vector4(v.X, v.Y, 0.0f, 0.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Vector2 left, in Vector2 right)
        {
            float diff_x = left.X - right.X;
            float diff_y = left.Y - right.Y;
            return (diff_x * diff_x + diff_y * diff_y) < (kEpsilon * kEpsilon);
        }
            

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Vector2 left, in Vector2 right)
        {
            return !(left == right);
        }
            
        #endregion Operator Overload
    }
}