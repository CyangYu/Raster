﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Raster.Math;
using Raster.Private;

namespace Raster.Drawing.Primitive
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
        public Color RGBA => new Color(r, g, b, a);

        /// <summary>
        /// 
        /// </summary>
        public Color RGAB => new Color(r, g, a, b);

        /// <summary>
        /// 
        /// </summary>
        public Color RBGA => new Color(r, b, g, a);

        /// <summary>
        /// 
        /// </summary>
        public Color RBAG => new Color(r, b, a, g);

        /// <summary>
        /// 
        /// </summary>
        public Color RAGB => new Color(r, a, g, b);

        /// <summary>
        /// 
        /// </summary>
        public Color RABG => new Color(r, a, b, g);

        /// <summary>
        /// 
        /// </summary>
        public Color GRBA => new Color(g, r, b, a);

        /// <summary>
        /// 
        /// </summary>
        public Color GRAB => new Color(g, r, a, b);

        /// <summary>
        /// 
        /// </summary>
        public Color GBRA => new Color(g, b, r, a);

        /// <summary>
        /// 
        /// </summary>
        public Color GBAR => new Color(g, b, a, r);

        /// <summary>
        /// 
        /// </summary>
        public Color GARB => new Color(g, a, r, b);

        /// <summary>
        /// 
        /// </summary>
        public Color GABR => new Color(g, a, b, r);

        /// <summary>
        /// 
        /// </summary>
        public Color BRGA => new Color(b, r, g, a);

        /// <summary>
        /// 
        /// </summary>
        public Color BRAG => new Color(b, r, a, g);

        /// <summary>
        /// 
        /// </summary>
        public Color BGRA => new Color(b, r, g, a);

        /// <summary>
        /// 
        /// </summary>
        public Color BGAR => new Color(b, g, a, r);

        /// <summary>
        /// 
        /// </summary>
        public Color BARG => new Color(b, a, r, g);

        /// <summary>
        /// 
        /// </summary>
        public Color BAGR => new Color(b, a, g, r);

        /// <summary>
        /// 
        /// </summary>
        public Color ARGB => new Color(a, r, g, b);

        /// <summary>
        /// 
        /// </summary>
        public Color ARBG => new Color(a, r, b, g);

        /// <summary>
        /// 
        /// </summary>
        public Color AGRB => new Color(a, g, r, b);

        /// <summary>
        /// 
        /// </summary>
        public Color AGBR => new Color(a, g, b, r);

        /// <summary>
        /// 
        /// </summary>
        public Color ABRG => new Color(a, b, r, g);

        /// <summary>
        /// 
        /// </summary>
        public Color ABGR => new Color(a, b, g, r);

        #endregion Public Instance Properties

        #region Constructor
        public Color(in Color other)
            : this(other.R, other.G, other.B, other.A)
        {
        }

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
        public override string ToString() =>
            string.Format("Color: Red = {0}, Green = {1}, Blue = {2}, Alpha = {3}", R, G, B, A);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Color other) => this == other;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="right"></param>
        /// <param name="left"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetColor(float r, float g, float b, float a)
        {
            this.r = MathF.Clamp(r, 0.0f, 1.0f);
            this.g = MathF.Clamp(g, 0.0f, 1.0f);
            this.b = MathF.Clamp(b, 0.0f, 1.0f);
            this.a = MathF.Clamp(a, 0.0f, 1.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Rgba ToRgba()
        {
            return new Rgba(
                (byte)(R * 0xFF),
                (byte)(G * 0xFF),
                (byte)(B * 0xFF),
                (byte)(A * 0xFF));
        }

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rgba"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color FromRgba(in Rgba rgba)
        {
            return new Color(
                rgba.R / byte.MaxValue,
                rgba.G / byte.MaxValue,
                rgba.B / byte.MaxValue,
                rgba.A / byte.MaxValue
            );
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
        public static bool operator ==(in Color left, in Color right) =>
            left.r == right.r && left.g == right.g && left.b == right.b && left.a == right.a;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Color left, in Color right) =>
           left.r != right.r || left.g != right.g || left.b != right.b || left.a != right.a;

        #endregion Operator Overload
    }
}