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
            /// 
            /// </summary>
            XYX,
            /// <summary>
            /// 
            /// </summary>
            XZX,
            /// <summary>
            /// 
            /// </summary>
            YXY,
            /// <summary>
            /// 
            /// </summary>
            YZY,
            /// <summary>
            /// 
            /// </summary>
            ZXZ,
            /// <summary>
            /// 
            /// </summary>
            ZYZ,
            /// <summary>
            /// 
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
        /// <summary>
        /// 
        /// </summary>
        public const float Deg2Rad = PI / 180.0f;
        /// <summary>
        /// 
        /// </summary>
        public const float Rad2Deg = 180.0f / PI;
        #endregion Public Static Fields

        #region Public Static Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int AsInt(uint x) { return (int)x; }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static uint AsUInt(float x) { return (uint)AsInt(x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static long AsLong(ulong x) { return (long)x; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static long AsLong(double x)
        {
            LongDoubleUnion u;
            u.LongValue = 0;
            u.DoubleValue = x;
            return u.LongValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static ulong AsULong(long x) { return (ulong)x; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static ulong AsULong(double x) { return (ulong)AsLong(x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float AsFloat(int x)
        {
            IntFloatUnion u;
            u.FloatValue = 0.0f;
            u.IntValue = x;

            return u.FloatValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float AsFloat(uint x) { return AsFloat((int)x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double AsDouble(long x)
        {
            LongDoubleUnion u;
            u.DoubleValue = 0.0;
            u.LongValue = x;
            return u.DoubleValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double AsDouble(ulong x) { return AsDouble((long)x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsFinite(float x) { return Abs(x) < float.PositiveInfinity; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsInf(float x) { return Abs(x) == float.PositiveInfinity; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsNaN(float x) { return (AsUInt(x) & 0x7FFFFFFF) > 0x7F800000; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int Abs(int x) { return Max(-x, x); }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static long Abs(long x) { return Max(-x, x); }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Abs(float x) { return Max(-x, x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Abs(double x) { return Max(-x, x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Abs(in Vector2 x) { return new Vector2(Abs(x.X), Abs(x.Y)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Abs(in Vector3 x) { return new Vector3(Abs(x.X), Abs(x.Y), Abs(x.Z)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Abs(in Vector4 x) { return new Vector4(Abs(x.X), Abs(x.Y), Abs(x.Z), Asin(x.W)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Asin(float x) { return (float)System.Math.Asin((double)x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Asin(double x) { return System.Math.Asin(x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Asin(in Vector2 x) { return new Vector2(Asin(x.X), Asin(x.Y)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Asin(in Vector3 x) { return new Vector3(Asin(x.X), Asin(x.Y), Asin(x.Z)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Asin(in Vector4 x) { return new Vector4(Asin(x.X), Asin(x.Y), Asin(x.Z), Asin(x.W)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Acos(float x) { return (float)System.Math.Acos((double)x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Acos(double x) { return System.Math.Acos(x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Acos(in Vector2 x) { return new Vector2(Acos(x.X), Acos(x.Y)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Acos(in Vector3 x) { return new Vector3(Acos(x.X), Acos(x.Y), Acos(x.Z)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Acos(in Vector4 x) { return new Vector4(Acos(x.X), Acos(x.Y), Acos(x.Z), Acos(x.W)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan(float x) { return (float)System.Math.Atan((double)x); }

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
        public static int Clamp(int value, int min, int max) { return Max(Min(max, value), min); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static uint Clamp(uint value, uint min, uint max) { return Max(Min(max, value), min); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Clamp(long value, long min, long max) { return Max(Min(max, value), min); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static ulong Clamp(ulong value, ulong min, ulong max) { return Max(Min(max, value), min); }
        
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
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Clamp(double value, double min, double max) { return Max(Min(value, max), min); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Clamp(in Vector2 value, in Vector2 min, in Vector2 max) { return Max(Min(value, max), min); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Clamp(in Vector3 value, in Vector3 min, in Vector3 max) { return Max(Min(value, max), min); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Clamp(in Vector4 value, in Vector4 min, in Vector4 max) { return Max(Min(value, max), min); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cos(float x) { return (float)System.Math.Cos((double)x); }

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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float Cross(in Vector2 x, in Vector2 y) { return x.X * y.Y - x.Y * y.X; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector3 Cross(in Vector3 x, in Vector3 y) { return new Vector3(x.Y * y.Z - y.Y * x.Z, x.X * y.Z - y.X * x.Z, x.X * y.Y - y.X * x.Y); }
        
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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float Distance(float x, float y) { return Abs(y - x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double Distance(double x, double y) { return Abs(y - x); }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float Distance(in Vector2 x, in Vector2 y) { return Length(y - x); }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float Distance(in Vector3 x, in Vector3 y) { return Length(y - x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float Distance(in Vector4 x, in Vector4 y) { return Length(y - x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float DistanceSquared(float x, float y) { return (y - x) * (y - x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double DistanceSquared(double x, double y) { return (y - x) * (y - x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float DistanceSquared(in Vector2 x, in Vector2 y) { return LengthSquared(y - x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float DistanceSquared(in Vector3 x, in Vector3 y) { return LengthSquared(y - x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float DistanceSquared(in Vector4 x, in Vector4 y) { return LengthSquared(y - x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float Dot(float x, float y) { return x * y; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double Dot(double x, double y) { return x * y; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float Dot(in Vector2 x, in Vector2 y) { return x.X * y.X + x.Y * y.Y; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float Dot(in Vector3 x, in Vector3 y) { return x.X * y.X + x.Y * y.Y + x.Z * y.Z; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float Dot(in Vector4 x, in Vector4 y) { return x.X * y.X + x.Y * y.Y + x.Z * y.Z + x.W + y.W; }

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
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Length(float x) { return Abs(x); }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Length(in Vector2 x) { return Sqrt(Dot(x, x)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Length(in Vector3 x) { return Sqrt(Dot(x, x)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Length(in Vector4 x) { return Sqrt(Dot(x, x)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float LengthSquared(float x) { return x * x; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double LenghSquared(double x) { return x * x; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float LengthSquared(in Vector2 x) { return Dot(x, x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float LengthSquared(in Vector3 x) { return Dot(x, x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float LengthSquared(in Vector4 x) { return Dot(x, x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static float Lerp(float x, float y, float s) { return x + s * (y - x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double Lerp(double x, double y, double s) { return x + s * (y - x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Vector2 Lerp(in Vector2 x, in Vector2 y, float s) { return x + s * (y - x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Vector3 Lerp(in Vector3 x, in Vector3 y, float s) { return x + s * (y - x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Vector4 Lerp(in Vector4 x, in Vector4 y, float s) { return x + s * (y - x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Vector2 Lerp(in Vector2 x, in Vector2 y, in Vector2 s) { return x + s * (y - x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Vector3 Lerp(in Vector3 x, in Vector3 y, in Vector3 s) { return x + s * (y - x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Vector4 Lerp(in Vector4 x, in Vector4 y, in Vector4 s) { return x + s * (y - x); }

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
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int Mad(int a, int b, int c) { return a * b + c; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static uint Mad(uint a, uint b, uint c) { return a * b + c; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static long Mad(long a, long b, long c) { return a * b + c; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static ulong Mad(ulong a, ulong b, ulong c) { return a * b + c; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static float Mad(float a, float b, float c) { return a * b + c; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static double Mad(double a, double b, double c) { return a * b + c; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int Max(int x, int y) { return x > y ? x : y; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static uint Max(uint x, uint y) { return x > y ? x : y; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static long Max(long x, long y) { return x > y ? x : y; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static ulong Max(ulong x, ulong y) { return x > y ? x : y; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float x, float y) { return float.IsNaN(y) || x > y ? x : y; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double Max(double x, double y) { return double.IsNaN(y) || x > y ? x : y; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector2 Max(in Vector2 x, in Vector2 y) { return new Vector2(Max(x.X, y.X), Max(x.Y, y.Y)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3 Max(in Vector3 x, in Vector3 y) { return new Vector3(Max(x.X, y.X), Max(x.Y, y.Y), Max(x.Z, y.Z)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector4 Max(in Vector4 x, in Vector4 y) { return new Vector4(Max(x.X, y.X), Max(x.Y, y.Y), Max(x.Z, y.Z), Max(x.W, y.W)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int Min(int x, int y) { return x < y ? x : y; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static uint Min(uint x, uint y) { return x < y ? x : y; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static long Min(long x, long y) { return x < y ? x : y; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static ulong Min(ulong x, ulong y) { return x < y ? x : y; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float x, float y) { return float.IsNaN(y) || x < y ? x : y; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double Min(double x, double y) { return double.IsNaN(y) || x < y ? x : y; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector2 Min(in Vector2 x, in Vector2 y) { return new Vector2(Min(x.X, y.X), Min(x.Y, y.Y)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3 Min(in Vector3 x, in Vector3 y) { return new Vector3(Min(x.X, y.X), Min(x.Y, y.Y), Min(x.Z, y.Z)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector4 Min(in Vector4 x, in Vector4 y) { return new Vector4(Min(x.X, y.X), Min(x.Y, y.Y), Min(x.Z, y.Z), Min(x.W, y.W)); }


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
        /// <param name="i"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Vector2 Reflect(in Vector2 i, in Vector2 n) { return i - 2.0f * n * Dot(i, n); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Vector3 Reflect(in Vector3 i, in Vector3 n) { return i - 2.0f * n * Dot(i, n); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Vector4 Reflect(in Vector4 i, in Vector4 n) { return i - 2.0f * n * Dot(i, n); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="n"></param>
        /// <param name="eta"></param>
        /// <returns></returns>
        public static Vector2 Refract(in Vector2 i, in Vector2 n, float eta)
        {
            float ni = Dot(n, i);
            float k = 1.0f - eta * eta * (1.0f - ni * ni);
            return Select(new Vector2(0.0f), eta * i - (eta * ni + Sqrt(k)) * n, k >= 0.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="n"></param>
        /// <param name="eta"></param>
        /// <returns></returns>
        public static Vector3 Refract(in Vector3 i, in Vector3 n, float eta)
        {
            float ni = Dot(n, i);
            float k = 1.0f - eta * eta * (1.0f - ni * ni);
            return Select(new Vector3(0.0f), eta * i - (eta * ni + Sqrt(k)) * n, k >= 0.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="n"></param>
        /// <param name="eta"></param>
        /// <returns></returns>
        public static Vector4 Refract(in Vector4 i, in Vector4 n, float eta)
        {
            float ni = Dot(n, i);
            float k = 1.0f - eta * eta * (1.0f - ni * ni);
            return Select(new Vector4(0.0f), eta * i - (eta * ni + Sqrt(k)) * n, k >= 0.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Remap(float a, float b, float c, float d, float x) { return Lerp(c, d, UnLerp(a, b, x)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector2 Remap(in Vector2 a, in Vector2 b, in Vector2 c, in Vector2 d, in Vector2 x) { return Lerp(c, d, UnLerp(a, b, x)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 Remap(in Vector3 a, in Vector3 b, in Vector3 c, in Vector3 d, in Vector3 x) { return Lerp(c, d, UnLerp(a, b, x)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector4 Remap(in Vector4 a, in Vector4 b, in Vector4 c, in Vector4 d, in Vector4 x) { return Lerp(c, d, UnLerp(a, b, x)); }

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
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Select(int a, int b, bool c) { return c ? b : a; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Select(uint a, uint b, bool c) { return c ? b : a; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Select(long a, long b, bool c) { return c ? b : a; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Select(float a, float b, bool c) { return c ? b : a; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Select(in Vector2 a, in Vector2 b, bool c) { return c ? b : a; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Select(in Vector3 a, in Vector3 b, bool c) { return c ? b : a; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Select(in Vector4 a, in Vector4 b, bool c) { return c ? b : a; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Select(ulong a, ulong b, bool c) { return c ? b : a; }

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
        /// <param name="s"></param>
        /// <param name="c"></param>
        public static void SinCos(float radian, out float s, out float c) 
        {
            s = Sin(radian);
            c = Cos(radian);
        }

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
        /// <param name="edge0"></param>
        /// <param name="edge1"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStep(float edge0, float edge1, float x)
        {
            float t = Stature((x - edge0) / (edge1 - edge0));
            return t * t * (3.0f - 2.0f * t);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge0"></param>
        /// <param name="edge1"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SmoothStep(double edge0, double edge1, double x)
        {
            double t = Stature((x - edge0) / (edge1 - edge0));
            return t * t * (3.0f - 2.0f * t);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge0"></param>
        /// <param name="edge1"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector2 SmoothSetp(in Vector2 edge0, in Vector2 edge1, in Vector2 x)
        {
            Vector2 t = Stature((x - edge0) / (edge1 - edge0));
            return t * t * (3.0f - (2.0f * t));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge0"></param>
        /// <param name="edge1"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 SmoothSetp(in Vector3 edge0, in Vector3 edge1, in Vector3 x)
        {
            Vector3 t = Stature((x - edge0) / (edge1 - edge0));
            return t * t * (3.0f - (2.0f * t));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Stature(float x) { return Clamp(x, 0.0f, 1.0f); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Stature(double x) { return Clamp(x, 0.0, 1.0); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector2 Stature(in Vector2 x) { return Clamp(x, new Vector2(0.0f), new Vector2(1.0f)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 Stature(in Vector3 x) { return Clamp(x, new Vector3(0.0f), new Vector3(1.0f)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector4 Stature(in Vector4 x) { return Clamp(x, new Vector4(0.0f), new Vector4(1.0f)); }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Tan(float x) { return (float)System.Math.Tan((double)x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Tan(double x) { return System.Math.Tan(x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector2 Tan(in Vector2 x) { return new Vector2(Tan(x.X), Tan(x.Y)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 Tan(in Vector3 x) { return new Vector3(Tan(x.X), Tan(x.Y), Tan(x.Z)); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector4 Tan(in Vector4 x) { return new Vector4(Tan(x.X), Tan(x.Y), Tan(x.Y), Tan(x.Z)); }

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
            return invsqrt == 0.0f ? float.PositiveInfinity : 1.0f / invsqrt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float UnLerp(float a, float b, float x) { return (x - a) / (b - a); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double UnLerp(double a, double b, double x) { return (x - a) / (b - a); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Vector2 UnLerp(in Vector2 a, in Vector2 b, in Vector2 x) { return (x - a) / (b - a); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Vector3 UnLerp(in Vector3 a, in Vector3 b, in Vector3 x) { return (x - a) / (b - a); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Vector4 UnLerp(in Vector4 a, in Vector4 b, in Vector4 x) { return (x - a) / (b - a); }

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
