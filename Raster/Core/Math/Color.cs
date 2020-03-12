using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Raster.Core.Math;
using Raster.Private;

namespace Raster.Core.Math
{
    /// <summary>
    ///
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public partial struct Color : IEquatable<Color>
    {
        #region Public Fields
        /// <summary>
        /// The Red Component Of Color
        /// </summary>
        private float r;
        /// <summary>
        /// The Green Component Of Color
        /// </summary>
        private float g;
        /// <summary>
        /// The Blue Component Of Color
        /// </summary>
        private float b;
        /// <summary>
        /// The Alpha Component Of Color
        /// </summary>
        public float a;
        #endregion Public Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public float R
        {
            get { return r; }
            set { r = MathF.Clamp(0.0f, 1.0f, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public float G
        {
            get { return g; }
            set { g = MathF.Clamp(0.0f, 1.0f, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public float B
        {
            get { return b; }
            set { b = MathF.Clamp(0.0f, 1.0f, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public float A
        {
            get { return a; }
            set { a = MathF.Clamp(0.0f, 1.0f, value); }
        }
        #endregion Public Instance Properties

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public Color(in Color other)
        {
            this.r = other.r;
            this.g = other.g;
            this.b = other.b;
            this.a = other.a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Color(float value)
        {
            float v = MathF.Clamp(value, 0.0f, 1.0f);

            this.r = v;
            this.g = v;
            this.b = v;
            this.a = v;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public Color(float r, float g, float b, float a)
        {
            this.r = MathF.Clamp(r, 0.0f, 1.0f);
            this.g = MathF.Clamp(g, 0.0f, 1.0f);
            this.b = MathF.Clamp(b, 0.0f, 1.0f);
            this.a = MathF.Clamp(a, 0.0f, 1.0f);
        }

        #endregion

        #region Public Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Color)
            {
                return Equals((Color)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash1 = HashHelpers.Combine(r.GetHashCode(), g.GetHashCode());
            int hash2 = HashHelpers.Combine(b.GetHashCode(), a.GetHashCode());
            return HashHelpers.Combine(hash1, hash2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("R={0},G={1},B={2},A={3}", r, g, b, a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Color other)
        {
            return this.r == other.r && this.g == other.g &&
                   this.b == other.b && this.a == other.a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public void Add(in Color other)
        {
            this.r = MathF.Min(this.r + other.r, 1.0f);
            this.g = MathF.Min(this.g + other.g, 1.0f);
            this.b = MathF.Min(this.b + other.b, 1.0f);
            this.a = MathF.Min(this.a + other.a, 1.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public void Subtract(in Color other)
        {
            this.r = MathF.Max(this.r - other.r, 0.0f);
            this.g = MathF.Max(this.g - other.g, 0.0f);
            this.b = MathF.Max(this.b - other.b, 0.0f);
            this.a = MathF.Max(this.a - other.a, 0.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public void Multiply(in Color other)
        {
            this.r = MathF.Clamp(this.r * other.r, 0.0f, 1.0f);
            this.g = MathF.Clamp(this.g * other.g, 0.0f, 1.0f);
            this.b = MathF.Clamp(this.b * other.b, 0.0f, 1.0f);
            this.a = MathF.Clamp(this.a * other.a, 0.0f, 1.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="right"></param>
        /// <param name="left"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reset(float r, float g, float b, float a)
        {
            this.r = MathF.Clamp(r, 0.0f, 1.0f);
            this.g = MathF.Clamp(g, 0.0f, 1.0f);
            this.b = MathF.Clamp(b, 0.0f, 1.0f);
            this.a = MathF.Clamp(a, 0.0f, 1.0f);
        }

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Lerp(in Color a, in Color b, float t)
        {
            Lerp(a, b, t, out Color result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color LerpUnclamped(in Color a, in Color b, float t)
        {
            Lerp(a, b, t, out Color result);
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
        public static void Clamp(in Color value, in Color min, in Color max, out Color result)
        {
            result.r = (min.r > value.r) ? min.r : value.r;
            result.r = (max.r < value.r) ? max.r : value.r;

            result.g = (min.g > value.g) ? min.g : value.g;
            result.g = (max.g < value.g) ? max.g : value.g;

            result.b = (min.b > value.b) ? min.b : value.b;
            result.b = (max.b < value.b) ? max.b : value.b;

            result.a = (min.a > value.a) ? min.a : value.a;
            result.a = (max.a < value.a) ? max.a : value.a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Lerp(in Color a, in Color b, float t, out Color result)
        {
            t = MathF.Clamp(t, 0.0f, 1.0f);

            result.r = MathF.Clamp(a.r + (b.r - a.r) * t, 0.0f, 1.0f);
            result.g = MathF.Clamp(a.g + (b.g - a.g) * t, 0.0f, 1.0f);
            result.b = MathF.Clamp(a.b + (b.b - a.b) * t, 0.0f, 1.0f);
            result.a = MathF.Clamp(a.a + (b.a - a.a) * t, 0.0f, 1.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LerpUnclamped(in Color a, in Color b, float t, out Color result)
        {
            t = MathF.Clamp(t, 0.0f, 1.0f);

            result.r = MathF.Clamp(a.r + (b.r - a.r) * t, 0.0f, 1.0f);
            result.g = MathF.Clamp(a.g + (b.g - a.g) * t, 0.0f, 1.0f);
            result.b = MathF.Clamp(a.b + (b.b - a.b) * t, 0.0f, 1.0f);
            result.a = MathF.Clamp(a.a + (b.a - a.a) * t, 0.0f, 1.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Max(in Color x, in Color y, out Color result)
        {
            result.r = x.r > y.r ? x.r : y.r;
            result.g = x.g > y.g ? x.g : y.g;
            result.b = x.b > y.b ? x.b : y.b;
            result.a = x.a > y.a ? x.a : y.a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Min(in Color x, in Color y, out Color result)
        {
            result.r = x.r < y.r ? x.r : y.r;
            result.g = x.g < y.g ? x.g : y.g;
            result.b = x.b < y.b ? x.b : y.b;
            result.a = x.a < y.a ? x.a : y.a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="a"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Mix(in Color x, in Color y, in Color a, out Color result)
        {
            result.r = x.r * (1.0f - a.r) + y.r * a.r;
            result.g = x.g * (1.0f - a.g) + y.g * a.g;
            result.b = x.b * (1.0f - a.b) + y.b * a.b;
            result.a = x.a * (1.0f - a.a) + y.a * a.a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge0"></param>
        /// <param name="edge1"></param>
        /// <param name="x"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SmoothStep(in Color edge0, in Color edge1, in Color x, out Color result)
        {
            float t = MathF.Clamp((x.r - edge0.r) / (edge1.r - edge0.r), 0.0f, 1.0f);
            float step = t * t * (3.0f - 2.0f * t);
            result.r = edge0.r + (edge1.r - edge0.r) * step;

            t = MathF.Clamp((x.g - edge0.g) / (edge1.g - edge0.g), 0.0f, 1.0f);
            step = t * t * (3.0f - 2.0f * t);
            result.g = edge0.g + (edge1.g - edge0.g) * step;

            t = MathF.Clamp((x.b - edge0.b) / (edge1.b - edge0.b), 0.0f, 1.0f);
            step = t * t * (3.0f - 2.0f * t);
            result.b = edge0.b + (edge1.b - edge0.b) * step;

            t = MathF.Clamp((x.a - edge0.a) / (edge1.a - edge0.a), 0.0f, 1.0f);
            step = t * t * (3.0f - 2.0f * t);
            result.a = edge0.a + (edge1.a - edge0.a) * step;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <param name="x"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Step(in Color edge, in Color x, out Color result)
        {
            result.r = edge.r >= x.r ? 1.0f : 0.0f;
            result.g = edge.g >= x.g ? 1.0f : 0.0f;
            result.b = edge.b >= x.b ? 1.0f : 0.0f;
            result.a = edge.a >= x.a ? 1.0f : 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add(in Color left, in Color right, out Color result)
        {
            result.r = MathF.Min(left.r + right.r, 1.0f);
            result.g = MathF.Min(left.g + right.g, 1.0f);
            result.b = MathF.Min(left.b + right.b, 1.0f);
            result.a = MathF.Min(left.a + right.a, 1.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Subtract(in Color left, in Color right, out Color result)
        {
            result.r = MathF.Max(left.r - right.r, 0.0f);
            result.g = MathF.Max(left.g - right.g, 0.0f);
            result.b = MathF.Max(left.b - right.b, 0.0f);
            result.a = MathF.Max(left.a - right.a, 0.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Multiply(in Color left, float right, out Color result)
        {
            result.r = MathF.Clamp(left.r * right, 0.0f, 1.0f);
            result.g = MathF.Clamp(left.g * right, 0.0f, 1.0f);
            result.b = MathF.Clamp(left.b * right, 0.0f, 1.0f);
            result.a = MathF.Clamp(left.a * right, 0.0f, 1.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Multiply(in Color left, in Color right, out Color result)
        {
            result.r = left.r * right.r;
            result.g = left.g * right.g;
            result.b = left.b * right.b;
            result.a = left.a * right.a;
        }

        #endregion Public Static Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Color operator +(in Color left, in Color right)
        {
            Add(left, right, out Color result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Color operator -(in Color left, in Color right)
        {
            Subtract(left, right, out Color result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Color operator *(float left, in Color right)
        {
            Multiply(right, left, out Color result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Color operator *(in Color left, float right)
        {
            Multiply(left, right, out Color result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Color operator *(in Color left, in Color right)
        {
            Multiply(left, right, out Color result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Color left, in Color right)
        {
            return left.r == right.r && left.g == right.g &&
                   left.b == right.b && left.a == right.a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Color left, in Color right)
        {
            return left.r != right.r || left.g != right.g ||
                   left.b != right.b || left.a != right.a;
        }

        #endregion Operator Overload
    }
}
