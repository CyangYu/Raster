using System;
using System.Runtime;
using System.Runtime.CompilerServices;
using SysMath = System.Math;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
    public static class MathF
    {
        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly float E       = 2.71828182845904523536f;
        /// <summary>
        /// 
        /// </summary>
        public static readonly float PI      = 3.14159265358979323846f;
        /// <summary>
        /// 
        /// </summary>
        public static readonly float PI_2    = 6.28318530717958647693f;
        /// <summary>
        /// 
        /// </summary>
        public static readonly float Half_PI = 1.57079632679489661923f;
        /// <summary>
        /// 
        /// </summary>
        public static readonly float Log2E   = 1.442695040888963387f;
        /// <summary>
        /// 
        /// </summary>
        public static readonly float Log10E  = 0.4342944819032518f;
        /// <summary>
        /// 
        /// </summary>
        public static readonly float Epsilon = 1.192092896e-07f;
        #endregion Public Static Fields

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Abs(float radian) => (float)System.Math.Abs((double)radian);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Asin(float radian) => (float)System.Math.Asin((double)radian);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Acos(float radian) => (float)System.Math.Acos((double)radian);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan(float radian) => (float)System.Math.Atan((double)radian);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan2(float x, float y) => (float)System.Math.Atan2((double)x, (double)y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Celling(float num) => (float)System.Math.Ceiling((double)num);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Clamp(int value, int min, int max) => SysMath.Max(SysMath.Min(value, max), min);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp(float value, float min, float max) => Max(Min(value, max), min);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cos(float radian) => (float)System.Math.Cos((double)radian);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cosh(float radian) => (float)System.Math.Cosh((double)radian);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DegToRad(float degree) => MathF.PI * degree / 180.0f;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Exp(float num) => (float)System.Math.Exp((double)num);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Exp2(float num) => Pow(2.0f, num);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Floor(float num) => (float)System.Math.Floor((double)num);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log(float num) => (float)System.Math.Log((double)num);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log10(float radian) => (float)System.Math.Log10((double)radian);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float a, float b) => a > b ? a : b;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float a, float b) => a < b ? a : b;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Mix(float x, float y, float a) => x * (1 - a) + y * a;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Mod(float x, float y) => y * Floor(x / y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Pow(float x, float y) => (float)System.Math.Pow((double)x, (double)y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RadToDeg(float radian) => 180.0f * radian / MathF.PI;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Round(float num) => (float)System.Math.Round((double)num);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sign(float radian) => (float)System.Math.Sign((double)radian);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sin(float radian) => (float)System.Math.Sin((double)radian);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sinh(float radian) => (float)System.Math.Sinh((double)radian);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStep(float edge0, float edge1, float x)
        {
            float t = Clamp((x - edge0) / (edge1 - edge0), 0.0f, 1.0f);
            return t * t * (3.0f - 2.0f * t);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Tan(float radian) => (float)System.Math.Tan((double)radian);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Tanh(float radian) => (float)System.Math.Tanh((double)radian);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Truncate(float num) => (float)System.Math.Truncate((double)num);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sqrt(float x)
        {
            float invsqrt = MathHelper.FastSqrtInverse(x);
            return invsqrt == 0.0f ? 0.0f : 1.0f / invsqrt;
        }

        #endregion Public Static Methods
    }
}
