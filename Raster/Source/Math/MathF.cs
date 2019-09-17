using System;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class MathF
    {
        /// <summary>
        /// 
        /// </summary>
        public enum RotationOrder : byte
        {
            /// <summary>
            /// 
            /// </summary>
            XYZ,
            /// <summary>
            /// 
            /// </summary>
            XZY,
            /// <summary>
            /// 
            /// </summary>
            YXZ,
            /// <summary>
            /// 
            /// </summary>
            YZX,
            /// <summary>
            /// 
            /// </summary>
            ZXY,
            /// <summary>
            /// 
            /// </summary>
            ZYX,
            /// <summary>
            /// W
            /// </summary>
            Default = ZXY
        };

        public enum ShuffleComponent : byte
        {
            /// <summary>
            /// 
            /// </summary>
            LeftX,
            /// <summary>
            /// 
            /// </summary>
            LeftY,
            /// <summary>
            /// 
            /// </summary>
            LeftZ,
            /// <summary>
            /// 
            /// </summary>
            LeftW,
            /// <summary>
            /// 
            /// </summary>
            RightX,
            /// <summary>
            /// 
            /// </summary>
            RightY,
            /// <summary>
            /// 
            /// </summary>
            RightZ,
            /// <summary>
            /// W
            /// </summary>
            RightW
        };

        #region Public Static Fields
        /// <summary>
        /// E
        /// </summary>
        public const float E = 2.7182818284590452353602874713526625f;
        /// <summary>
        /// PI
        /// </summary>
        public const float PI = 3.1415926535897932384626433832795029f;
        /// <summary>
        /// PI * 2.0
        /// </summary>
        public const float PI_2 = 6.2831853071795864769252867665590058f;
        /// <summary>
        /// PI * 4.0
        /// </summary>
        public const float PI_4 = 12.5663706143591729538505735331180116f;
        /// <summary>
        /// PI / 2.0
        /// </summary>
        public const float Half_PI = 1.5707963267948966192313216916397514f;
        /// <summary>
        /// PI / 4.0
        /// </summary>
        public const float Quart_PI = 0.7853981633974483096156608458198757f;
        /// <summary>
        /// 1.0f / PI
        /// </summary>
        public const float Inv_PI = 0.3183098861837906715377675267450287f;
        /// <summary>
        /// 2.0f / PI
        /// </summary>
        public const float Inv_PI_2 = 0.6366197723675813430755350534900574f;
        /// <summary>
        /// log 2.0 E
        /// </summary>
        public const float Log2E = 1.4426950408889634073599246810018921f;
        /// <summary>
        /// log 10.0 E
        /// </summary>
        public const float Log10E = 0.4342944819032518276511289189166051f;
        /// <summary>
        /// log E 2.0
        /// </summary>
        public const float LogE2 = 0.6931471805599453094172321214581766f;
        /// <summary>
        /// log E 10.0
        /// </summary>
        public const float LogE10 = 2.3025850929940456840179914546843642f;
        /// <summary>
        /// Sqrt(2.0)
        /// </summary>
        public const float Sqrt2 = 1.4142135623730950488016887242096981f;
        /// <summary>
        /// 1.0 / Sqrt(2.0)
        /// </summary>
        public const float Div_1_Sqrt2 = 0.7071067811865475244008443621048490f;
        /// <summary>
        /// 2.0 / Sqrt(2.0)
        /// </summary>
        public const float Div_2_Sqrt2 = 1.1283791670955125738961589031215452f;
        /// <summary>
        /// 
        /// </summary>
        public const float Epsilon = 0.0000001192092896f;
        #endregion Public Static Fields

        #region Public Static Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int AsInt(float x)
        {
            IntFloatUnion u;
            u.IntValue = 0;
            u.FloatValue = x;
            return u.IntValue;
        }

        public static uint AsUInt(float x) { return (uint)AsInt(x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Abs(float radian) { return (float)System.Math.Abs((double)radian); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Asin(float radian) { return (float)System.Math.Asin((double)radian); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Acos(float radian) { return (float)System.Math.Acos((double)radian); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan(float radian) { return (float)System.Math.Atan((double)radian); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan2(float x, float y) { return (float)System.Math.Atan2((double)x, (double)y); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Celling(float num) { return (float)System.Math.Ceiling((double)num); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Clamp(int value, int min, int max) { return System.Math.Max(System.Math.Min(value, max), min); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp(float value, float min, float max) { return Max(Min(value, max), min); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cos(float radian) { return (float)System.Math.Cos((double)radian); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cosh(float radian) { return (float)System.Math.Cosh((double)radian); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DegToRad(float degree) { return MathF.PI * degree / 180.0f; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Exp(float num) { return (float)System.Math.Exp((double)num); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Exp2(float num) { return Pow(2.0f, num); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Floor(float num) { return (float)System.Math.Floor((double)num); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log(float num) { return (float)System.Math.Log((double)num); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log10(float radian) { return (float)System.Math.Log10((double)radian); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float a, float b) { return System.Math.Max(a, b); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float a, float b) { return System.Math.Min(a, b); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Mix(float x, float y, float a) { return x * (1 - a) + y * a; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Mod(float x, float y) { return y * Floor(x / y); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Pow(float x, float y) { return (float)System.Math.Pow((double)x, (double)y); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RadToDeg(float radian) { return 180.0f * radian / MathF.PI; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Round(float num) { return (float)System.Math.Round((double)num); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sign(float radian) { return (float)System.Math.Sign((double)radian); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sin(float radian) { return (float)System.Math.Sin((double)radian); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sinh(float radian) { return (float)System.Math.Sinh((double)radian); }

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
        public static float Tan(float radian) { return (float)System.Math.Tan((double)radian); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Tanh(float radian) { return (float)System.Math.Tanh((double)radian); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Truncate(float num) { return (float)System.Math.Truncate((double)num); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sqrt(float x)
        {
            float invsqrt = MathHelper.FastSqrtInverse(x);
            return invsqrt == 0.0f ? float.NaN : 1.0f / invsqrt;
        }

        #endregion Public Static Methods

        #region 
        [StructLayout(LayoutKind.Explicit)]
        internal struct IntFloatUnion
        {
            [FieldOffset(0)]
            public int IntValue;
            [FieldOffset(0)]
            public float FloatValue;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct LongDoubleUnion
        {
            [FieldOffset(0)]
            public long LongValue;
            [FieldOffset(0)]
            public double DoubleValue;
        }
        #endregion
    }
}
