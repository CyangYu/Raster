using System;
using System.Runtime.CompilerServices;

namespace Raster.Core.Math.Simd
{
    partial class math
    {
        /// <summary>
        /// Returns the float value result of a matrix multiplication between a float value and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float mul(float a, float b)
        {
            return a * b;
        }
        /// <summary>
        /// Returns the float value result of a matrix multiplication between a float2 row vector and a float2 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float mul(float2 a, float2 b)
        {
            return a.x * b.x + a.y * b.y;
        }
        /// <summary>
        /// Returns the float2 row vector result of a matrix multiplication between a float2 row vector and a float2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 mul(float2 a, float2x2 b)
        {
            return float2(
                a.x * b.c0.x + a.y * b.c0.y,
                a.x * b.c1.x + a.y * b.c1.y);
        }
        /// <summary>
        /// Returns the float3 row vector result of a matrix multiplication between a float2 row vector and a float2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 mul(float2 a, float2x3 b)
        {
            return float3(
                a.x * b.c0.x + a.y * b.c0.y,
                a.x * b.c1.x + a.y * b.c1.y,
                a.x * b.c2.x + a.y * b.c2.y);
        }
        /// <summary>
        /// Returns the float4 row vector result of a matrix multiplication between a float2 row vector and a float2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 mul(float2 a, float2x4 b)
        {
            return float4(
                a.x * b.c0.x + a.y * b.c0.y,
                a.x * b.c1.x + a.y * b.c1.y,
                a.x * b.c2.x + a.y * b.c2.y,
                a.x * b.c3.x + a.y * b.c3.y);
        }
        /// <summary>
        /// Returns the float value result of a matrix multiplication between a float3 row vector and a float3 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float mul(float3 a, float3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
        /// <summary>
        /// Returns the float2 row vector result of a matrix multiplication between a float3 row vector and a float3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 mul(float3 a, float3x2 b)
        {
            return float2(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z);
        }
        /// <summary>
        /// Returns the float3 row vector result of a matrix multiplication between a float3 row vector and a float3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 mul(float3 a, float3x3 b)
        {
            return float3(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z);
        }
        /// <summary>
        /// Returns the float4 row vector result of a matrix multiplication between a float3 row vector and a float3x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 mul(float3 a, float3x4 b)
        {
            return float4(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z,
                a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z);
        }
        /// <summary>
        /// Returns the float value result of a matrix multiplication between a float4 row vector and a float4 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float mul(float4 a, float4 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
        }
        /// <summary>
        /// Returns the float2 row vector result of a matrix multiplication between a float4 row vector and a float4x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 mul(float4 a, float4x2 b)
        {
            return float2(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w);
        }
        /// <summary>
        /// Returns the float3 row vector result of a matrix multiplication between a float4 row vector and a float4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 mul(float4 a, float4x3 b)
        {
            return float3(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w);
        }
        /// <summary>
        /// Returns the float4 row vector result of a matrix multiplication between a float4 row vector and a float4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 mul(float4 a, float4x4 b)
        {
            return float4(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w,
                a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z + a.w * b.c3.w);
        }
        /// <summary>
        /// Returns the float2 column vector result of a matrix multiplication between a float2x2 matrix and a float2 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 mul(float2x2 a, float2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }
        /// <summary>
        /// Returns the float2x2 matrix result of a matrix multiplication between a float2x2 matrix and a float2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 mul(float2x2 a, float2x2 b)
        {
            return float2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }
        /// <summary>
        /// Returns the float2x3 matrix result of a matrix multiplication between a float2x2 matrix and a float2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 mul(float2x2 a, float2x3 b)
        {
            return float2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }
        /// <summary>
        /// Returns the float2x4 matrix result of a matrix multiplication between a float2x2 matrix and a float2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 mul(float2x2 a, float2x4 b)
        {
            return float2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }
        /// <summary>
        /// Returns the float2 column vector result of a matrix multiplication between a float2x3 matrix and a float3 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 mul(float2x3 a, float3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }
        /// <summary>
        /// Returns the float2x2 matrix result of a matrix multiplication between a float2x3 matrix and a float3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 mul(float2x3 a, float3x2 b)
        {
            return float2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }
        /// <summary>
        /// Returns the float2x3 matrix result of a matrix multiplication between a float2x3 matrix and a float3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 mul(float2x3 a, float3x3 b)
        {
            return float2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }
        /// <summary>
        /// Returns the float2x4 matrix result of a matrix multiplication between a float2x3 matrix and a float3x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 mul(float2x3 a, float3x4 b)
        {
            return float2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }
        /// <summary>
        /// Returns the float2 column vector result of a matrix multiplication between a float2x4 matrix and a float4 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 mul(float2x4 a, float4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }
        /// <summary>
        /// Returns the float2x2 matrix result of a matrix multiplication between a float2x4 matrix and a float4x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 mul(float2x4 a, float4x2 b)
        {
            return float2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }
        /// <summary>
        /// Returns the float2x3 matrix result of a matrix multiplication between a float2x4 matrix and a float4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 mul(float2x4 a, float4x3 b)
        {
            return float2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }
        /// <summary>
        /// Returns the float2x4 matrix result of a matrix multiplication between a float2x4 matrix and a float4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 mul(float2x4 a, float4x4 b)
        {
            return float2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }
        /// <summary>
        /// Returns the float3 column vector result of a matrix multiplication between a float3x2 matrix and a float2 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 mul(float3x2 a, float2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }
        /// <summary>
        /// Returns the float3x2 matrix result of a matrix multiplication between a float3x2 matrix and a float2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 mul(float3x2 a, float2x2 b)
        {
            return float3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }
        /// <summary>
        /// Returns the float3x3 matrix result of a matrix multiplication between a float3x2 matrix and a float2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x3 mul(float3x2 a, float2x3 b)
        {
            return float3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }
        /// <summary>
        /// Returns the float3x4 matrix result of a matrix multiplication between a float3x2 matrix and a float2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 mul(float3x2 a, float2x4 b)
        {
            return float3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }
        /// <summary>
        /// Returns the float3 column vector result of a matrix multiplication between a float3x3 matrix and a float3 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 mul(float3x3 a, float3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }
        /// <summary>
        /// Returns the float3x2 matrix result of a matrix multiplication between a float3x3 matrix and a float3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 mul(float3x3 a, float3x2 b)
        {
            return float3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }
        /// <summary>
        /// Returns the float3x3 matrix result of a matrix multiplication between a float3x3 matrix and a float3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x3 mul(float3x3 a, float3x3 b)
        {
            return float3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }
        /// <summary>
        /// Returns the float3x4 matrix result of a matrix multiplication between a float3x3 matrix and a float3x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 mul(float3x3 a, float3x4 b)
        {
            return float3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }
        /// <summary>
        /// Returns the float3 column vector result of a matrix multiplication between a float3x4 matrix and a float4 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 mul(float3x4 a, float4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }
        /// <summary>
        /// Returns the float3x2 matrix result of a matrix multiplication between a float3x4 matrix and a float4x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 mul(float3x4 a, float4x2 b)
        {
            return float3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }
        /// <summary>
        /// Returns the float3x3 matrix result of a matrix multiplication between a float3x4 matrix and a float4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x3 mul(float3x4 a, float4x3 b)
        {
            return float3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }
        /// <summary>
        /// Returns the float3x4 matrix result of a matrix multiplication between a float3x4 matrix and a float4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 mul(float3x4 a, float4x4 b)
        {
            return float3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }
        /// <summary>
        /// Returns the float4 column vector result of a matrix multiplication between a float4x2 matrix and a float2 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 mul(float4x2 a, float2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }
        /// <summary>
        /// Returns the float4x2 matrix result of a matrix multiplication between a float4x2 matrix and a float2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 mul(float4x2 a, float2x2 b)
        {
            return float4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }
        /// <summary>
        /// Returns the float4x3 matrix result of a matrix multiplication between a float4x2 matrix and a float2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 mul(float4x2 a, float2x3 b)
        {
            return float4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }
        /// <summary>
        /// Returns the float4x4 matrix result of a matrix multiplication between a float4x2 matrix and a float2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 mul(float4x2 a, float2x4 b)
        {
            return float4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }
        /// <summary>
        /// Returns the float4 column vector result of a matrix multiplication between a float4x3 matrix and a float3 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 mul(float4x3 a, float3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }
        /// <summary>
        /// Returns the float4x2 matrix result of a matrix multiplication between a float4x3 matrix and a float3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 mul(float4x3 a, float3x2 b)
        {
            return float4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }
        /// <summary>
        /// Returns the float4x3 matrix result of a matrix multiplication between a float4x3 matrix and a float3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 mul(float4x3 a, float3x3 b)
        {
            return float4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }
        /// <summary>
        /// Returns the float4x4 matrix result of a matrix multiplication between a float4x3 matrix and a float3x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 mul(float4x3 a, float3x4 b)
        {
            return float4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }
        /// <summary>
        /// Returns the float4 column vector result of a matrix multiplication between a float4x4 matrix and a float4 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 mul(float4x4 a, float4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }
        /// <summary>
        /// Returns the float4x2 matrix result of a matrix multiplication between a float4x4 matrix and a float4x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 mul(float4x4 a, float4x2 b)
        {
            return float4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }
        /// <summary>
        /// Returns the float4x3 matrix result of a matrix multiplication between a float4x4 matrix and a float4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 mul(float4x4 a, float4x3 b)
        {
            return float4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }
        /// <summary>
        /// Returns the float4x4 matrix result of a matrix multiplication between a float4x4 matrix and a float4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 mul(float4x4 a, float4x4 b)
        {
            return float4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }
        /// <summary>
        /// Returns the double value result of a matrix multiplication between a double value and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double mul(double a, double b)
        {
            return a * b;
        }
        /// <summary>
        /// Returns the double value result of a matrix multiplication between a double2 row vector and a double2 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double mul(double2 a, double2 b)
        {
            return a.x * b.x + a.y * b.y;
        }
        /// <summary>
        /// Returns the double2 row vector result of a matrix multiplication between a double2 row vector and a double2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 mul(double2 a, double2x2 b)
        {
            return double2(
                a.x * b.c0.x + a.y * b.c0.y,
                a.x * b.c1.x + a.y * b.c1.y);
        }
        /// <summary>
        /// Returns the double3 row vector result of a matrix multiplication between a double2 row vector and a double2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 mul(double2 a, double2x3 b)
        {
            return double3(
                a.x * b.c0.x + a.y * b.c0.y,
                a.x * b.c1.x + a.y * b.c1.y,
                a.x * b.c2.x + a.y * b.c2.y);
        }
        /// <summary>
        /// Returns the double4 row vector result of a matrix multiplication between a double2 row vector and a double2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 mul(double2 a, double2x4 b)
        {
            return double4(
                a.x * b.c0.x + a.y * b.c0.y,
                a.x * b.c1.x + a.y * b.c1.y,
                a.x * b.c2.x + a.y * b.c2.y,
                a.x * b.c3.x + a.y * b.c3.y);
        }
        /// <summary>
        /// Returns the double value result of a matrix multiplication between a double3 row vector and a double3 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double mul(double3 a, double3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
        /// <summary>
        /// Returns the double2 row vector result of a matrix multiplication between a double3 row vector and a double3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 mul(double3 a, double3x2 b)
        {
            return double2(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z);
        }
        /// <summary>
        /// Returns the double3 row vector result of a matrix multiplication between a double3 row vector and a double3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 mul(double3 a, double3x3 b)
        {
            return double3(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z);
        }
        /// <summary>
        /// Returns the double4 row vector result of a matrix multiplication between a double3 row vector and a double3x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 mul(double3 a, double3x4 b)
        {
            return double4(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z,
                a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z);
        }
        /// <summary>
        /// Returns the double value result of a matrix multiplication between a double4 row vector and a double4 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double mul(double4 a, double4 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
        }
        /// <summary>
        /// Returns the double2 row vector result of a matrix multiplication between a double4 row vector and a double4x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 mul(double4 a, double4x2 b)
        {
            return double2(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w);
        }
        /// <summary>
        /// Returns the double3 row vector result of a matrix multiplication between a double4 row vector and a double4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 mul(double4 a, double4x3 b)
        {
            return double3(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w);
        }
        /// <summary>
        /// Returns the double4 row vector result of a matrix multiplication between a double4 row vector and a double4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 mul(double4 a, double4x4 b)
        {
            return double4(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w,
                a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z + a.w * b.c3.w);
        }
        /// <summary>
        /// Returns the double2 column vector result of a matrix multiplication between a double2x2 matrix and a double2 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 mul(double2x2 a, double2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }
        /// <summary>
        /// Returns the double2x2 matrix result of a matrix multiplication between a double2x2 matrix and a double2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 mul(double2x2 a, double2x2 b)
        {
            return double2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }
        /// <summary>
        /// Returns the double2x3 matrix result of a matrix multiplication between a double2x2 matrix and a double2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 mul(double2x2 a, double2x3 b)
        {
            return double2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }
        /// <summary>
        /// Returns the double2x4 matrix result of a matrix multiplication between a double2x2 matrix and a double2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 mul(double2x2 a, double2x4 b)
        {
            return double2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }
        /// <summary>
        /// Returns the double2 column vector result of a matrix multiplication between a double2x3 matrix and a double3 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 mul(double2x3 a, double3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }
        /// <summary>
        /// Returns the double2x2 matrix result of a matrix multiplication between a double2x3 matrix and a double3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 mul(double2x3 a, double3x2 b)
        {
            return double2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }
        /// <summary>
        /// Returns the double2x3 matrix result of a matrix multiplication between a double2x3 matrix and a double3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 mul(double2x3 a, double3x3 b)
        {
            return double2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }
        /// <summary>
        /// Returns the double2x4 matrix result of a matrix multiplication between a double2x3 matrix and a double3x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 mul(double2x3 a, double3x4 b)
        {
            return double2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }
        /// <summary>
        /// Returns the double2 column vector result of a matrix multiplication between a double2x4 matrix and a double4 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 mul(double2x4 a, double4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }
        /// <summary>
        /// Returns the double2x2 matrix result of a matrix multiplication between a double2x4 matrix and a double4x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 mul(double2x4 a, double4x2 b)
        {
            return double2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }
        /// <summary>
        /// Returns the double2x3 matrix result of a matrix multiplication between a double2x4 matrix and a double4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 mul(double2x4 a, double4x3 b)
        {
            return double2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }
        /// <summary>
        /// Returns the double2x4 matrix result of a matrix multiplication between a double2x4 matrix and a double4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 mul(double2x4 a, double4x4 b)
        {
            return double2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }
        /// <summary>
        /// Returns the double3 column vector result of a matrix multiplication between a double3x2 matrix and a double2 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 mul(double3x2 a, double2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }
        /// <summary>
        /// Returns the double3x2 matrix result of a matrix multiplication between a double3x2 matrix and a double2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 mul(double3x2 a, double2x2 b)
        {
            return double3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }
        /// <summary>
        /// Returns the double3x3 matrix result of a matrix multiplication between a double3x2 matrix and a double2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 mul(double3x2 a, double2x3 b)
        {
            return double3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }
        /// <summary>
        /// Returns the double3x4 matrix result of a matrix multiplication between a double3x2 matrix and a double2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 mul(double3x2 a, double2x4 b)
        {
            return double3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }
        /// <summary>
        /// Returns the double3 column vector result of a matrix multiplication between a double3x3 matrix and a double3 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 mul(double3x3 a, double3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }
        /// <summary>
        /// Returns the double3x2 matrix result of a matrix multiplication between a double3x3 matrix and a double3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 mul(double3x3 a, double3x2 b)
        {
            return double3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }
        /// <summary>
        /// Returns the double3x3 matrix result of a matrix multiplication between a double3x3 matrix and a double3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 mul(double3x3 a, double3x3 b)
        {
            return double3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }
        /// <summary>
        /// Returns the double3x4 matrix result of a matrix multiplication between a double3x3 matrix and a double3x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 mul(double3x3 a, double3x4 b)
        {
            return double3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }
        /// <summary>
        /// Returns the double3 column vector result of a matrix multiplication between a double3x4 matrix and a double4 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 mul(double3x4 a, double4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }
        /// <summary>
        /// Returns the double3x2 matrix result of a matrix multiplication between a double3x4 matrix and a double4x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 mul(double3x4 a, double4x2 b)
        {
            return double3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }
        /// <summary>
        /// Returns the double3x3 matrix result of a matrix multiplication between a double3x4 matrix and a double4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 mul(double3x4 a, double4x3 b)
        {
            return double3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }
        /// <summary>
        /// Returns the double3x4 matrix result of a matrix multiplication between a double3x4 matrix and a double4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 mul(double3x4 a, double4x4 b)
        {
            return double3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }
        /// <summary>
        /// Returns the double4 column vector result of a matrix multiplication between a double4x2 matrix and a double2 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 mul(double4x2 a, double2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }
        /// <summary>
        /// Returns the double4x2 matrix result of a matrix multiplication between a double4x2 matrix and a double2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 mul(double4x2 a, double2x2 b)
        {
            return double4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }
        /// <summary>
        /// Returns the double4x3 matrix result of a matrix multiplication between a double4x2 matrix and a double2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 mul(double4x2 a, double2x3 b)
        {
            return double4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }
        /// <summary>
        /// Returns the double4x4 matrix result of a matrix multiplication between a double4x2 matrix and a double2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 mul(double4x2 a, double2x4 b)
        {
            return double4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }
        /// <summary>
        /// Returns the double4 column vector result of a matrix multiplication between a double4x3 matrix and a double3 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 mul(double4x3 a, double3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }
        /// <summary>
        /// Returns the double4x2 matrix result of a matrix multiplication between a double4x3 matrix and a double3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 mul(double4x3 a, double3x2 b)
        {
            return double4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }
        /// <summary>
        /// Returns the double4x3 matrix result of a matrix multiplication between a double4x3 matrix and a double3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 mul(double4x3 a, double3x3 b)
        {
            return double4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }
        /// <summary>
        /// Returns the double4x4 matrix result of a matrix multiplication between a double4x3 matrix and a double3x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 mul(double4x3 a, double3x4 b)
        {
            return double4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }
        /// <summary>
        /// Returns the double4 column vector result of a matrix multiplication between a double4x4 matrix and a double4 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 mul(double4x4 a, double4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }
        /// <summary>
        /// Returns the double4x2 matrix result of a matrix multiplication between a double4x4 matrix and a double4x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 mul(double4x4 a, double4x2 b)
        {
            return double4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }
        /// <summary>
        /// Returns the double4x3 matrix result of a matrix multiplication between a double4x4 matrix and a double4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 mul(double4x4 a, double4x3 b)
        {
            return double4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }
        /// <summary>
        /// Returns the double4x4 matrix result of a matrix multiplication between a double4x4 matrix and a double4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 mul(double4x4 a, double4x4 b)
        {
            return double4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }
        /// <summary>
        /// Returns the int value result of a matrix multiplication between an int value and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mul(int a, int b)
        {
            return a * b;
        }
        /// <summary>
        /// Returns the int value result of a matrix multiplication between an int2 row vector and an int2 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mul(int2 a, int2 b)
        {
            return a.x * b.x + a.y * b.y;
        }
        /// <summary>
        /// Returns the int2 row vector result of a matrix multiplication between an int2 row vector and an int2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 mul(int2 a, int2x2 b)
        {
            return int2(
                a.x * b.c0.x + a.y * b.c0.y,
                a.x * b.c1.x + a.y * b.c1.y);
        }
        /// <summary>
        /// Returns the int3 row vector result of a matrix multiplication between an int2 row vector and an int2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 mul(int2 a, int2x3 b)
        {
            return int3(
                a.x * b.c0.x + a.y * b.c0.y,
                a.x * b.c1.x + a.y * b.c1.y,
                a.x * b.c2.x + a.y * b.c2.y);
        }
        /// <summary>
        /// Returns the int4 row vector result of a matrix multiplication between an int2 row vector and an int2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 mul(int2 a, int2x4 b)
        {
            return int4(
                a.x * b.c0.x + a.y * b.c0.y,
                a.x * b.c1.x + a.y * b.c1.y,
                a.x * b.c2.x + a.y * b.c2.y,
                a.x * b.c3.x + a.y * b.c3.y);
        }
        /// <summary>
        /// Returns the int value result of a matrix multiplication between an int3 row vector and an int3 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mul(int3 a, int3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
        /// <summary>
        /// Returns the int2 row vector result of a matrix multiplication between an int3 row vector and an int3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 mul(int3 a, int3x2 b)
        {
            return int2(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z);
        }
        /// <summary>
        /// Returns the int3 row vector result of a matrix multiplication between an int3 row vector and an int3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 mul(int3 a, int3x3 b)
        {
            return int3(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z);
        }
        /// <summary>
        /// Returns the int4 row vector result of a matrix multiplication between an int3 row vector and an int3x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 mul(int3 a, int3x4 b)
        {
            return int4(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z,
                a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z);
        }
        /// <summary>
        /// Returns the int value result of a matrix multiplication between an int4 row vector and an int4 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mul(int4 a, int4 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
        }
        /// <summary>
        /// Returns the int2 row vector result of a matrix multiplication between an int4 row vector and an int4x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 mul(int4 a, int4x2 b)
        {
            return int2(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w);
        }
        /// <summary>
        /// Returns the int3 row vector result of a matrix multiplication between an int4 row vector and an int4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 mul(int4 a, int4x3 b)
        {
            return int3(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w);
        }
        /// <summary>
        /// Returns the int4 row vector result of a matrix multiplication between an int4 row vector and an int4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 mul(int4 a, int4x4 b)
        {
            return int4(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w,
                a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z + a.w * b.c3.w);
        }
        /// <summary>
        /// Returns the int2 column vector result of a matrix multiplication between an int2x2 matrix and an int2 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 mul(int2x2 a, int2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }
        /// <summary>
        /// Returns the int2x2 matrix result of a matrix multiplication between an int2x2 matrix and an int2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 mul(int2x2 a, int2x2 b)
        {
            return int2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }
        /// <summary>
        /// Returns the int2x3 matrix result of a matrix multiplication between an int2x2 matrix and an int2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 mul(int2x2 a, int2x3 b)
        {
            return int2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }
        /// <summary>
        /// Returns the int2x4 matrix result of a matrix multiplication between an int2x2 matrix and an int2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 mul(int2x2 a, int2x4 b)
        {
            return int2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }
        /// <summary>
        /// Returns the int2 column vector result of a matrix multiplication between an int2x3 matrix and an int3 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 mul(int2x3 a, int3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }
        /// <summary>
        /// Returns the int2x2 matrix result of a matrix multiplication between an int2x3 matrix and an int3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 mul(int2x3 a, int3x2 b)
        {
            return int2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }
        /// <summary>
        /// Returns the int2x3 matrix result of a matrix multiplication between an int2x3 matrix and an int3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 mul(int2x3 a, int3x3 b)
        {
            return int2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }
        /// <summary>
        /// Returns the int2x4 matrix result of a matrix multiplication between an int2x3 matrix and an int3x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 mul(int2x3 a, int3x4 b)
        {
            return int2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }
        /// <summary>
        /// Returns the int2 column vector result of a matrix multiplication between an int2x4 matrix and an int4 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 mul(int2x4 a, int4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }
        /// <summary>
        /// Returns the int2x2 matrix result of a matrix multiplication between an int2x4 matrix and an int4x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 mul(int2x4 a, int4x2 b)
        {
            return int2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }
        /// <summary>
        /// Returns the int2x3 matrix result of a matrix multiplication between an int2x4 matrix and an int4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 mul(int2x4 a, int4x3 b)
        {
            return int2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }
        /// <summary>
        /// Returns the int2x4 matrix result of a matrix multiplication between an int2x4 matrix and an int4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 mul(int2x4 a, int4x4 b)
        {
            return int2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }
        /// <summary>
        /// Returns the int3 column vector result of a matrix multiplication between an int3x2 matrix and an int2 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 mul(int3x2 a, int2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }
        /// <summary>
        /// Returns the int3x2 matrix result of a matrix multiplication between an int3x2 matrix and an int2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 mul(int3x2 a, int2x2 b)
        {
            return int3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }
        /// <summary>
        /// Returns the int3x3 matrix result of a matrix multiplication between an int3x2 matrix and an int2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 mul(int3x2 a, int2x3 b)
        {
            return int3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }
        /// <summary>
        /// Returns the int3x4 matrix result of a matrix multiplication between an int3x2 matrix and an int2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 mul(int3x2 a, int2x4 b)
        {
            return int3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }
        /// <summary>
        /// Returns the int3 column vector result of a matrix multiplication between an int3x3 matrix and an int3 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 mul(int3x3 a, int3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }
        /// <summary>
        /// Returns the int3x2 matrix result of a matrix multiplication between an int3x3 matrix and an int3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 mul(int3x3 a, int3x2 b)
        {
            return int3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }
        /// <summary>
        /// Returns the int3x3 matrix result of a matrix multiplication between an int3x3 matrix and an int3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 mul(int3x3 a, int3x3 b)
        {
            return int3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }
        /// <summary>
        /// Returns the int3x4 matrix result of a matrix multiplication between an int3x3 matrix and an int3x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 mul(int3x3 a, int3x4 b)
        {
            return int3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }
        /// <summary>
        /// Returns the int3 column vector result of a matrix multiplication between an int3x4 matrix and an int4 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 mul(int3x4 a, int4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }
        /// <summary>
        /// Returns the int3x2 matrix result of a matrix multiplication between an int3x4 matrix and an int4x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 mul(int3x4 a, int4x2 b)
        {
            return int3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }
        /// <summary>
        /// Returns the int3x3 matrix result of a matrix multiplication between an int3x4 matrix and an int4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 mul(int3x4 a, int4x3 b)
        {
            return int3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }
        /// <summary>
        /// Returns the int3x4 matrix result of a matrix multiplication between an int3x4 matrix and an int4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 mul(int3x4 a, int4x4 b)
        {
            return int3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }
        /// <summary>
        /// Returns the int4 column vector result of a matrix multiplication between an int4x2 matrix and an int2 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 mul(int4x2 a, int2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }
        /// <summary>
        /// Returns the int4x2 matrix result of a matrix multiplication between an int4x2 matrix and an int2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x2 mul(int4x2 a, int2x2 b)
        {
            return int4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }
        /// <summary>
        /// Returns the int4x3 matrix result of a matrix multiplication between an int4x2 matrix and an int2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 mul(int4x2 a, int2x3 b)
        {
            return int4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }
        /// <summary>
        /// Returns the int4x4 matrix result of a matrix multiplication between an int4x2 matrix and an int2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 mul(int4x2 a, int2x4 b)
        {
            return int4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }
        /// <summary>
        /// Returns the int4 column vector result of a matrix multiplication between an int4x3 matrix and an int3 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 mul(int4x3 a, int3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }
        /// <summary>
        /// Returns the int4x2 matrix result of a matrix multiplication between an int4x3 matrix and an int3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x2 mul(int4x3 a, int3x2 b)
        {
            return int4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }
        /// <summary>
        /// Returns the int4x3 matrix result of a matrix multiplication between an int4x3 matrix and an int3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 mul(int4x3 a, int3x3 b)
        {
            return int4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }
        /// <summary>
        /// Returns the int4x4 matrix result of a matrix multiplication between an int4x3 matrix and an int3x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 mul(int4x3 a, int3x4 b)
        {
            return int4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }
        /// <summary>
        /// Returns the int4 column vector result of a matrix multiplication between an int4x4 matrix and an int4 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 mul(int4x4 a, int4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }
        /// <summary>
        /// Returns the int4x2 matrix result of a matrix multiplication between an int4x4 matrix and an int4x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x2 mul(int4x4 a, int4x2 b)
        {
            return int4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }
        /// <summary>
        /// Returns the int4x3 matrix result of a matrix multiplication between an int4x4 matrix and an int4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 mul(int4x4 a, int4x3 b)
        {
            return int4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }
        /// <summary>
        /// Returns the int4x4 matrix result of a matrix multiplication between an int4x4 matrix and an int4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 mul(int4x4 a, int4x4 b)
        {
            return int4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }
        /// <summary>
        /// Returns the uint value result of a matrix multiplication between a uint value and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mul(uint a, uint b)
        {
            return a * b;
        }
        /// <summary>
        /// Returns the uint value result of a matrix multiplication between a uint2 row vector and a uint2 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mul(uint2 a, uint2 b)
        {
            return a.x * b.x + a.y * b.y;
        }
        /// <summary>
        /// Returns the uint2 row vector result of a matrix multiplication between a uint2 row vector and a uint2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 mul(uint2 a, uint2x2 b)
        {
            return uint2(
                a.x * b.c0.x + a.y * b.c0.y,
                a.x * b.c1.x + a.y * b.c1.y);
        }
        /// <summary>
        /// Returns the uint3 row vector result of a matrix multiplication between a uint2 row vector and a uint2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 mul(uint2 a, uint2x3 b)
        {
            return uint3(
                a.x * b.c0.x + a.y * b.c0.y,
                a.x * b.c1.x + a.y * b.c1.y,
                a.x * b.c2.x + a.y * b.c2.y);
        }
        /// <summary>
        /// Returns the uint4 row vector result of a matrix multiplication between a uint2 row vector and a uint2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 mul(uint2 a, uint2x4 b)
        {
            return uint4(
                a.x * b.c0.x + a.y * b.c0.y,
                a.x * b.c1.x + a.y * b.c1.y,
                a.x * b.c2.x + a.y * b.c2.y,
                a.x * b.c3.x + a.y * b.c3.y);
        }
        /// <summary>
        /// Returns the uint value result of a matrix multiplication between a uint3 row vector and a uint3 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mul(uint3 a, uint3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
        /// <summary>
        /// Returns the uint2 row vector result of a matrix multiplication between a uint3 row vector and a uint3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 mul(uint3 a, uint3x2 b)
        {
            return uint2(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z);
        }
        /// <summary>
        /// Returns the uint3 row vector result of a matrix multiplication between a uint3 row vector and a uint3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 mul(uint3 a, uint3x3 b)
        {
            return uint3(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z);
        }
        /// <summary>
        /// Returns the uint4 row vector result of a matrix multiplication between a uint3 row vector and a uint3x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 mul(uint3 a, uint3x4 b)
        {
            return uint4(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z,
                a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z);
        }
        /// <summary>
        /// Returns the uint value result of a matrix multiplication between a uint4 row vector and a uint4 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mul(uint4 a, uint4 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
        }
        /// <summary>
        /// Returns the uint2 row vector result of a matrix multiplication between a uint4 row vector and a uint4x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 mul(uint4 a, uint4x2 b)
        {
            return uint2(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w);
        }
        /// <summary>
        /// Returns the uint3 row vector result of a matrix multiplication between a uint4 row vector and a uint4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 mul(uint4 a, uint4x3 b)
        {
            return uint3(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w);
        }
        /// <summary>
        /// Returns the uint4 row vector result of a matrix multiplication between a uint4 row vector and a uint4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 mul(uint4 a, uint4x4 b)
        {
            return uint4(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w,
                a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z + a.w * b.c3.w);
        }
        /// <summary>
        /// Returns the uint2 column vector result of a matrix multiplication between a uint2x2 matrix and a uint2 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 mul(uint2x2 a, uint2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }
        /// <summary>
        /// Returns the uint2x2 matrix result of a matrix multiplication between a uint2x2 matrix and a uint2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x2 mul(uint2x2 a, uint2x2 b)
        {
            return uint2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }
        /// <summary>
        /// Returns the uint2x3 matrix result of a matrix multiplication between a uint2x2 matrix and a uint2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 mul(uint2x2 a, uint2x3 b)
        {
            return uint2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }
        /// <summary>
        /// Returns the uint2x4 matrix result of a matrix multiplication between a uint2x2 matrix and a uint2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 mul(uint2x2 a, uint2x4 b)
        {
            return uint2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }
        /// <summary>
        /// Returns the uint2 column vector result of a matrix multiplication between a uint2x3 matrix and a uint3 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 mul(uint2x3 a, uint3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }
        /// <summary>
        /// Returns the uint2x2 matrix result of a matrix multiplication between a uint2x3 matrix and a uint3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x2 mul(uint2x3 a, uint3x2 b)
        {
            return uint2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }
        /// <summary>
        /// Returns the uint2x3 matrix result of a matrix multiplication between a uint2x3 matrix and a uint3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 mul(uint2x3 a, uint3x3 b)
        {
            return uint2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }
        /// <summary>
        /// Returns the uint2x4 matrix result of a matrix multiplication between a uint2x3 matrix and a uint3x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 mul(uint2x3 a, uint3x4 b)
        {
            return uint2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }
        /// <summary>
        /// Returns the uint2 column vector result of a matrix multiplication between a uint2x4 matrix and a uint4 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 mul(uint2x4 a, uint4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }
        /// <summary>
        /// Returns the uint2x2 matrix result of a matrix multiplication between a uint2x4 matrix and a uint4x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x2 mul(uint2x4 a, uint4x2 b)
        {
            return uint2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }
        /// <summary>
        /// Returns the uint2x3 matrix result of a matrix multiplication between a uint2x4 matrix and a uint4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 mul(uint2x4 a, uint4x3 b)
        {
            return uint2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }
        /// <summary>
        /// Returns the uint2x4 matrix result of a matrix multiplication between a uint2x4 matrix and a uint4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 mul(uint2x4 a, uint4x4 b)
        {
            return uint2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }
        /// <summary>
        /// Returns the uint3 column vector result of a matrix multiplication between a uint3x2 matrix and a uint2 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 mul(uint3x2 a, uint2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }
        /// <summary>
        /// Returns the uint3x2 matrix result of a matrix multiplication between a uint3x2 matrix and a uint2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 mul(uint3x2 a, uint2x2 b)
        {
            return uint3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }
        /// <summary>
        /// Returns the uint3x3 matrix result of a matrix multiplication between a uint3x2 matrix and a uint2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 mul(uint3x2 a, uint2x3 b)
        {
            return uint3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }
        /// <summary>
        /// Returns the uint3x4 matrix result of a matrix multiplication between a uint3x2 matrix and a uint2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 mul(uint3x2 a, uint2x4 b)
        {
            return uint3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }
        /// <summary>
        /// Returns the uint3 column vector result of a matrix multiplication between a uint3x3 matrix and a uint3 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 mul(uint3x3 a, uint3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }
        /// <summary>
        /// Returns the uint3x2 matrix result of a matrix multiplication between a uint3x3 matrix and a uint3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 mul(uint3x3 a, uint3x2 b)
        {
            return uint3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }
        /// <summary>
        /// Returns the uint3x3 matrix result of a matrix multiplication between a uint3x3 matrix and a uint3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 mul(uint3x3 a, uint3x3 b)
        {
            return uint3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }
        /// <summary>
        /// Returns the uint3x4 matrix result of a matrix multiplication between a uint3x3 matrix and a uint3x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 mul(uint3x3 a, uint3x4 b)
        {
            return uint3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }
        /// <summary>
        /// Returns the uint3 column vector result of a matrix multiplication between a uint3x4 matrix and a uint4 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 mul(uint3x4 a, uint4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }
        /// <summary>
        /// Returns the uint3x2 matrix result of a matrix multiplication between a uint3x4 matrix and a uint4x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 mul(uint3x4 a, uint4x2 b)
        {
            return uint3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }
        /// <summary>
        /// Returns the uint3x3 matrix result of a matrix multiplication between a uint3x4 matrix and a uint4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 mul(uint3x4 a, uint4x3 b)
        {
            return uint3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }
        /// <summary>
        /// Returns the uint3x4 matrix result of a matrix multiplication between a uint3x4 matrix and a uint4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 mul(uint3x4 a, uint4x4 b)
        {
            return uint3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }
        /// <summary>
        /// Returns the uint4 column vector result of a matrix multiplication between a uint4x2 matrix and a uint2 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 mul(uint4x2 a, uint2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }
        /// <summary>
        /// Returns the uint4x2 matrix result of a matrix multiplication between a uint4x2 matrix and a uint2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 mul(uint4x2 a, uint2x2 b)
        {
            return uint4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }
        /// <summary>
        /// Returns the uint4x3 matrix result of a matrix multiplication between a uint4x2 matrix and a uint2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 mul(uint4x2 a, uint2x3 b)
        {
            return uint4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }
        /// <summary>
        /// Returns the uint4x4 matrix result of a matrix multiplication between a uint4x2 matrix and a uint2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 mul(uint4x2 a, uint2x4 b)
        {
            return uint4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }
        /// <summary>
        /// Returns the uint4 column vector result of a matrix multiplication between a uint4x3 matrix and a uint3 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 mul(uint4x3 a, uint3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }
        /// <summary>
        /// Returns the uint4x2 matrix result of a matrix multiplication between a uint4x3 matrix and a uint3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 mul(uint4x3 a, uint3x2 b)
        {
            return uint4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }
        /// <summary>
        /// Returns the uint4x3 matrix result of a matrix multiplication between a uint4x3 matrix and a uint3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 mul(uint4x3 a, uint3x3 b)
        {
            return uint4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }
        /// <summary>
        /// Returns the uint4x4 matrix result of a matrix multiplication between a uint4x3 matrix and a uint3x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 mul(uint4x3 a, uint3x4 b)
        {
            return uint4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }
        /// <summary>
        /// Returns the uint4 column vector result of a matrix multiplication between a uint4x4 matrix and a uint4 column vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 mul(uint4x4 a, uint4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }
        /// <summary>
        /// Returns the uint4x2 matrix result of a matrix multiplication between a uint4x4 matrix and a uint4x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 mul(uint4x4 a, uint4x2 b)
        {
            return uint4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }
        /// <summary>
        /// Returns the uint4x3 matrix result of a matrix multiplication between a uint4x4 matrix and a uint4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 mul(uint4x4 a, uint4x3 b)
        {
            return uint4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }
        /// <summary>
        /// Returns the uint4x4 matrix result of a matrix multiplication between a uint4x4 matrix and a uint4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 mul(uint4x4 a, uint4x4 b)
        {
            return uint4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }
    }
}
