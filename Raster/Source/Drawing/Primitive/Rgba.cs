using System;
using System.Runtime.CompilerServices;

namespace Raster.Drawing.Primitive
{
    [Serializable]
    public partial struct Rgba : IEquatable<Rgba>
    {
        #region Public Fields
        /// <summary>
        /// 
        /// </summary>
        public byte R;
        /// <summary>
        /// 
        /// </summary>
        public byte G;
        /// <summary>
        /// 
        /// </summary>
        public byte B;
        /// <summary>
        /// 
        /// </summary>
        public byte A;
        #endregion Public Fields

        #region Constructor
        public Rgba(Int32 rgba)
        {
#if BIG_ENDIAN
            R = (byte)((rgba & 0x000000FF) >>  0);
            G = (byte)((rgba & 0x0000FF00) >>  8);
            B = (byte)((rgba & 0x00FF0000) >> 16);
            A = (byte)((rgba & 0xFF000000) >> 24);
#else
            R = (byte)((rgba & 0xFF000000) >> 24);
            G = (byte)((rgba & 0x00FF0000) >> 16);
            B = (byte)((rgba & 0x0000FF00) >>  8);
            A = (byte)((rgba & 0x000000FF) >>  0);
#endif
        }

        public Rgba(in Rgba rgba)
            : this(rgba.R, rgba.G, rgba.B, rgba.A)
        {
        }

        public Rgba(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
        #endregion Constructor

        #region Public Instance Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int32 ToInt32()
        {

#if BIG_ENDIAN
            return (Int32)((A << 24) | (B << 16) | (G << 8) | R);
#else 
            return (Int32)((R << 24) | (G << 16) | (B << 8) | A);
#endif
        }
        #endregion Public Instance Fields

        #region Operator Overload

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgba operator +(in Rgba left, in Rgba right)
        {
            Rgba rgba = new Rgba();
            rgba.R = (byte)System.Math.Min(left.R + right.R, byte.MaxValue);
            rgba.G = (byte)System.Math.Min(left.G + right.G, byte.MaxValue);
            rgba.B = (byte)System.Math.Min(left.B + right.B, byte.MaxValue);
            rgba.A = (byte)System.Math.Min(left.A + right.A, byte.MaxValue);
            return rgba;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgba operator -(in Rgba left, in Rgba right)
        {
            Rgba rgba = new Rgba();
            rgba.R = (byte)System.Math.Max(0, left.R - right.R);
            rgba.G = (byte)System.Math.Max(0, left.G - right.G);
            rgba.B = (byte)System.Math.Max(0, left.B - right.B);
            rgba.A = (byte)System.Math.Max(0, left.A - right.A);
            return rgba;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgba operator *(in int left, in Rgba right)
        {
            Rgba rgba = new Rgba();
            rgba.R = (byte)System.Math.Min(left * right.R, byte.MaxValue);
            rgba.G = (byte)System.Math.Min(left * right.G, byte.MaxValue);
            rgba.B = (byte)System.Math.Min(left * right.B, byte.MaxValue);
            rgba.A = (byte)System.Math.Min(left * right.A, byte.MaxValue);
            return rgba;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgba operator *(in Rgba left, int right)
        {
            Rgba rgba = new Rgba();
            rgba.R = (byte)System.Math.Min(left.R * right, byte.MaxValue);
            rgba.G = (byte)System.Math.Min(left.R * right, byte.MaxValue);
            rgba.B = (byte)System.Math.Min(left.R * right, byte.MaxValue);
            rgba.A = (byte)System.Math.Min(left.R * right, byte.MaxValue);
            return rgba;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgba operator *(in Rgba left, in Rgba right)
        {
            Rgba rgba = new Rgba();
            rgba.R = (byte)System.Math.Min(left.R * right.R, byte.MaxValue);
            rgba.G = (byte)System.Math.Min(left.G * right.G, byte.MaxValue);
            rgba.B = (byte)System.Math.Min(left.B * right.B, byte.MaxValue);
            rgba.A = (byte)System.Math.Min(left.A * right.A, byte.MaxValue);
            return rgba;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Rgba left, in Rgba right) =>
            (left.R == right.R && left.G == right.G && left.B == right.B && left.A == right.A);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Rgba left, in Rgba right) =>
            left.R != right.R || left.G != right.G || left.B != right.B || left.A != right.A;

        #endregion Operator Overload

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Rgba)
            {
                return Equals((Rgba)obj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return R.GetHashCode() ^ G.GetHashCode() ^ B.GetHashCode() ^ A.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            string.Format("Rgba: R = {0}, G = {1}, B = {2}, A = {3}", R, G, B, A);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Rgba other) => this == other;
    }
}
