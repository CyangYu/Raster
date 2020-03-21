using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Raster.Private;

namespace Raster.Drawing.Primitive
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public partial struct Rgba : IEquatable<Rgba>
    {
        #region Public Fields
        /// <summary>
        /// 
        /// </summary>
        private byte r;
        /// <summary>
        /// 
        /// </summary>
        private byte g;
        /// <summary>
        /// 
        /// </summary>
        private byte b;
        /// <summary>
        /// 
        /// </summary>
        private byte a;
        #endregion Public Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public byte R
        {
            get { return r; }
            set { r = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public byte G
        {
            get { return g; }
            set { g = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public byte B
        {
            get { return b; }
            set { b = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public byte A
        {
            get { return a; }
            set { a = value; }
        }

        #endregion Public Instance Properties

        #region Constructor
        public Rgba(Int32 rgba)
        {
#if BIG_ENDIAN
            r = (byte)((rgba & 0x000000FF) >>  0);
            g = (byte)((rgba & 0x0000FF00) >>  8);
            b = (byte)((rgba & 0x00FF0000) >> 16);
            a = (byte)((rgba & 0xFF000000) >> 24);
#else
            r = (byte)((rgba & 0xFF000000) >> 24);
            g = (byte)((rgba & 0x00FF0000) >> 16);
            b = (byte)((rgba & 0x0000FF00) >>  8);
            a = (byte)((rgba & 0x000000FF) >>  0);
#endif
        }

        public Rgba(in Rgba rgba)
            : this(rgba.r, rgba.g, rgba.b, rgba.a)
        {
        }

        public Rgba(byte r, byte g, byte b, byte a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
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
            if (obj is Rgba)
            {
                return Equals((Rgba)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash1 = HashHelpers.Combine(r, g);
            int hash2 = HashHelpers.Combine(b, a);
            return HashHelpers.Combine(hash1, hash2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Rgba: R = {0}, G = {1}, B = {2}, A = {3}", r, g, b, a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Rgba other)
        {
            return this.r == other.r &&
                   this.g == other.g &&
                   this.b == other.b &&
                   this.a == other.a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int32 ToInt32()
        {

#if BIG_ENDIAN
            return (Int32)((a << 24) | (b << 16) | (g << 8) | r);
#else 
            return (Int32)((r << 24) | (g << 16) | (b << 8) | a);
#endif
        }

        #endregion Public Instance Fields

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add(in Rgba left, in Rgba right, out Rgba result)
        {
            result.r = (byte)System.Math.Min(left.r + right.r, byte.MaxValue);
            result.g = (byte)System.Math.Min(left.g + right.g, byte.MaxValue);
            result.b = (byte)System.Math.Min(left.b + right.b, byte.MaxValue);
            result.a = (byte)System.Math.Min(left.a + right.a, byte.MaxValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Subtract(in Rgba left, in Rgba right, out Rgba result)
        {
            result.r = (byte)System.Math.Max(left.r - right.r, byte.MinValue);
            result.g = (byte)System.Math.Max(left.g - right.g, byte.MinValue);
            result.b = (byte)System.Math.Max(left.b - right.b, byte.MinValue);
            result.a = (byte)System.Math.Max(left.a - right.a, byte.MinValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Subtract(in Rgba left, int right, out Rgba result)
        {
            result.r = (byte)System.Math.Min(left.r * right, byte.MaxValue);
            result.g = (byte)System.Math.Min(left.g * right, byte.MaxValue);
            result.b = (byte)System.Math.Min(left.b * right, byte.MaxValue);
            result.a = (byte)System.Math.Min(left.a * right, byte.MaxValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Multiply(in Rgba left, int right, out Rgba result)
        {
            result.r = (byte)System.Math.Min(left.r * right, byte.MaxValue);
            result.g = (byte)System.Math.Min(left.g * right, byte.MaxValue);
            result.b = (byte)System.Math.Min(left.b * right, byte.MaxValue);
            result.a = (byte)System.Math.Min(left.a * right, byte.MaxValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Multiply(in Rgba left, in Rgba right, out Rgba result)
        {
            result.r = (byte)System.Math.Min(left.r * right.r, byte.MaxValue);
            result.g = (byte)System.Math.Min(left.g * right.g, byte.MaxValue);
            result.b = (byte)System.Math.Min(left.b * right.b, byte.MaxValue);
            result.a = (byte)System.Math.Min(left.a * right.a, byte.MaxValue);
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
        public static Rgba operator +(in Rgba left, in Rgba right)
        {
            Add(left, right, out Rgba result);
            return result;
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
            Subtract(left, right, out Rgba result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rgba operator *(int left, in Rgba right)
        {
            Multiply(right, left, out Rgba result);
            return result;
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
            Multiply(left, right, out Rgba result);
            return result;
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
            Multiply(left, right, out Rgba result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Rgba left, in Rgba right)
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
        public static bool operator !=(in Rgba left, in Rgba right)
        {
            return left.r != right.r || left.g != right.g ||
                   left.b != right.b || left.a != right.a;
        }

        #endregion Operator Overload
    }
}
