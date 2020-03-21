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

        /// <summary>
        /// 
        /// </summary>
        public float Grayscale
        {
            get { return r * 0.299f + g * 0.587f + b * 0.114f; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float Luminance
        {
            get
            {
                float _r, _g, _b;

                if (r <= 0.03928) { _r = r / 12.92f; } else { _r = MathF.Pow((r + 0.055f) / 1.055f, 2.4f); }
                if (g <= 0.03928) { _g = g / 12.92f; } else { _g = MathF.Pow((g + 0.055f) / 1.055f, 2.4f); }
                if (b <= 0.03928) { _b = b / 12.92f; } else { _b = MathF.Pow((b + 0.055f) / 1.055f, 2.4f); }

                return 0.2126f * _r + 0.7152f * _g + 0.0722f * _b;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color Inverted
        {
            get { return new Color(1.0f - r, 1.0f - g, 1.0f - b, 1.0f - a); }
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
                    case 0: return r;
                    case 1: return g;
                    case 2: return b;
                    case 3: return a;
                }

                throw new ArgumentOutOfRangeException("index", "less than 4");
            }

            set
            {
                switch (index)
                {
                    case 0: r = MathF.Clamp(value, 0.0f, 1.0f); break;
                    case 1: g = MathF.Clamp(value, 0.0f, 1.0f); break;
                    case 2: b = MathF.Clamp(value, 0.0f, 1.0f); break;
                    case 3: a = MathF.Clamp(value, 0.0f, 1.0f); break;
                    default: throw new ArgumentOutOfRangeException("index", "less than 4");
                }
            }
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Multiply(in Color other)
        {
            r = MathF.Clamp(this.r * other.r, 0.0f, 1.0f);
            g = MathF.Clamp(this.g * other.g, 0.0f, 1.0f);
            b = MathF.Clamp(this.b * other.b, 0.0f, 1.0f);
            a = MathF.Clamp(this.a * other.a, 0.0f, 1.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invert()
        {
            r = 1.0f - r;
            g = 1.0f - g;
            b = 1.0f - b;
            a = 1.0f - a;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cyan"></param>
        /// <param name="magnet"></param>
        /// <param name="yellow"></param>
        /// <param name="k"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ToCMYK(out float cyan, out float magnet, out float yellow, out float black)
        {
            // avoid to divided by zero
            if (MathHelper.IsZero(r * g * b) == true)
            {
                cyan = 0.0f;
                magnet = 0.0f;
                yellow = 0.0f;
                black = 0.0f;
            }
            else
            {
                cyan = 1.0f - r;
                magnet = 1.0f - g;
                yellow = 1.0f - b;

                float min = MathF.Min(cyan, MathF.Min(magnet, yellow));
                float inv_min = 1.0f - min;

                cyan = (cyan - min) / inv_min;
                magnet = (magnet - min) / inv_min;
                yellow = (yellow - min) / inv_min;
                black = inv_min;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hue"></param>
        /// <param name=""></param>
        /// <param name="saturation"></param>
        /// <param name="lightness"></param>
        public void ToHSL(out float hue, out float saturation, out float lightness)
        {
            float min = MathF.Min(r, MathF.Min(g, b));
            float max = MathF.Max(r, MathF.Max(g, b));
            float delta = max - min;
            float delta2 = min + max;
            
            lightness = (min + max) * 0.5f;

            if (MathHelper.IsZero(delta) == true)
            {
                hue = 0.0f;
                saturation = 0.0f;
            }
            else
            {
                hue = 0.0f;

                if (lightness < 0.5f)
                {
                    saturation = delta / (min + max);
                }
                else
                {
                    saturation = delta / (2.0f - delta2);
                }
                
                float delta_r = (((max - r) / 6.0f) + (delta / 2.0f)) / delta;
                float delta_g = (((max - g) / 6.0f) + (delta / 2.0f)) / delta;
                float delta_b = (((max - b) / 6.0f) + (delta / 2.0f)) / delta;

                if (MathHelper.IsZero(r - max) == true)
                {
                    hue = delta_b - delta_g;
                }
                else if (MathHelper.IsZero(g - max) == true)
                {
                    hue = 0.3333333f + delta_r - delta_b;
                }
                else if (MathHelper.IsZero(b - max) == true)
                {
                    hue = 0.6666667f + delta_g - delta_r;
                }

                if (hue < 0.0f)
                {
                    hue += 1.0f;
                }

                if (hue > 1.0f)
                {
                    hue -= 1.0f;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hue"></param>
        /// <param name="saturation"></param>
        /// <param name="brightness"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ToHSV(out float hue, out float saturation, out float value)
        {
            float min = MathF.Min(r, MathF.Min(g, b));
            float max = MathF.Max(r, MathF.Max(g, b));
            float delta = max - min;

            value = max;

            if (MathHelper.IsZero(delta) == true)
            {
                hue = 0.0f;
                saturation = 0.0f;
            }
            else
            {
                hue = 0.0f;
                saturation = delta / max;

                float delta_r = (((max - r) / 6.0f) + (delta / 2.0f)) / delta;
                float delta_g = (((max - g) / 6.0f) + (delta / 2.0f)) / delta;
                float delta_b = (((max - b) / 6.0f) + (delta / 2.0f)) / delta;

                if (MathHelper.IsZero(r - max) == true)
                {
                    hue = delta_b - delta_g;
                }
                else if (MathHelper.IsZero(g - max) == true)
                {
                    hue = 0.3333333f + delta_r - delta_b;
                }
                else if (MathHelper.IsZero(b - max) == true)
                {
                    hue = 0.6666667f + delta_g - delta_r;
                }

                if (hue < 0.0f)
                {
                    hue += 1.0f;
                }

                if (hue > 1.0f)
                {
                    hue -= 1.0f;
                }
            }
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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Max(in Color x, in Color y)
        {
            Max(x, y, out Color result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Min(in Color x, in Color y)
        {
            Min(x, y, out Color result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Mix(in Color x, in Color y, in Color a)
        {
            Mix(x, y, a, out Color result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge0"></param>
        /// <param name="edge1"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color SmoothStep(in Color edge0, in Color edge1, in Color x)
        {
            SmoothStep(edge0, edge1, x, out Color result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color SmoothStep(in Color edge, in Color x)
        {
            Step(edge, x, out Color result);
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
        /// <param name="cyan"></param>
        /// <param name="magent"></param>
        /// <param name="yellow"></param>
        /// <param name="k"></param>
        /// <param name="result"></param>
        public static void FromCMYK(float cyan, float magenta, float yellow, float black, out Color result)
        {
            result.r = MathF.Clamp(1.0f - (cyan * (1.0f - black) + black), 0.0f, 1.0f);
            result.g = MathF.Clamp(1.0f - (magenta * (1.0f - black) + black), 0.0f, 1.0f);
            result.b = MathF.Clamp(1.0f - (yellow * (1.0f - black) + black), 0.0f, 1.0f);
            result.a = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hue"></param>
        /// <param name="saturation"></param>
        /// <param name="lightness"></param>
        /// <param name="result"></param>
        public static void FromHSL(float hue, float saturation, float lightness, out Color result)
        {
            float temp2 = 0.0f;

            if (lightness < 0.5f)
            {
                temp2 = lightness * (1.0f + saturation);
            }
            else
            {
                temp2 = lightness + saturation - (lightness * saturation);
            }

            result = KnownColor.Black;

            float temp1 = 2.0f * lightness - temp2;
            float[] temp3 = new float[3] { hue + 0.3333333f, hue, hue - 0.333333f };

            for (int i = 0; i < 3; i++)
            {
                if (temp3[i] < 0.0f)
                {
                    temp3[i] += 1.0f;
                }
                else if (temp3[i] > 1.0f)
                {
                    temp3[i] -= 1.0f;
                }

                float sixtemp3 = temp3[i] * 6.0f;
                if (sixtemp3 < 1.0f)
                {
                    result[i + 1] = temp1 + (temp2 - temp1) * sixtemp3;
                }
                else if (temp3[i] * 2.0f < 1.0f)
                {
                    result[i + 1] = temp2;
                }
                else if (temp3[i] * 3.0f < 2.0f)
                {
                    result[i + 1] = temp1 + (temp2 - temp1) * (0.6666667f - temp3[i]) * 6.0f;
                }
                else
                {
                    result[i + 1] = temp1;
                }
            }

            result.r = result.r == 1.0f ? 0.0f : result.r;
            result.g = result.g == 1.0f ? 0.0f : result.g;
            result.b = result.b == 1.0f ? 0.0f : result.b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hue"></param>
        /// <param name="saturation"></param>
        /// <param name="v"></param>
        /// <param name="result"></param>
        public static void FromHSV(float hue, float saturation, float value, out Color result)
        {
            if (MathHelper.IsZero(saturation))
            {
                result.r = value;
                result.g = value;
                result.b = value;
                result.a = 1.0f;
            }
            else
            {
                float domain = MathF.Floor(hue * (1.0f / 60.0f));
                float frac = (hue * (1.0f / 60.0f)) - domain;

                float f0 = value * (1.0f - saturation);
                float f1 = value * (1.0f - saturation * frac);
                float f2 = value * (1.0f - saturation * (1.0f - frac));

                switch (domain)
                {
                    case 0:
                        result.r = value;
                        result.g = f2;
                        result.b = f0;
                        break;

                    case 1:
                        result.r = f1;
                        result.g = value;
                        result.b = f0;
                        break;

                    case 2:
                        result.r = f0;
                        result.g = value;
                        result.b = f2;
                        break;

                    case 3:
                        result.r = f0;
                        result.g = f1;
                        result.b = value;
                        break;

                    case 4:
                        result.r = f2;
                        result.g = f0;
                        result.b = value;
                        break;

                    case 5:
                        result.r = value;
                        result.g = f0;
                        result.b = f1;
                        break;

                    default:
                        result.r = 0.0f;
                        result.g = 0.0f;
                        result.b = 0.0f;
                        break;
                }

                result.a = 1.0f;
            }
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
