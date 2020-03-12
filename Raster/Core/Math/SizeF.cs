using System;
using System.Runtime.InteropServices;
using Raster.Private;

namespace Raster.Core.Math
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct SizeF : IEquatable<SizeF>
    {
        #region Public Fields
        /// <summary>
        /// 
        /// </summary>
        public float Width;
        /// <summary>
        /// 
        /// </summary>
        public float Height;
        #endregion

        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public readonly static SizeF Empty = new SizeF(0.0f, 0.0f);

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return Width == 0.0f && Height == 0.0f;
            }
        }
        #endregion Public Instance Properties

        #endregion Public Static Fields

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public SizeF(in SizeF other)
            : this(other.Width, other.Height)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public SizeF(float width, float height)
        {
            Width = width;
            Height = height;
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
            if (obj is SizeF)
            {
                return Equals((SizeF)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashHelpers.Combine(Width.GetHashCode(), Height.GetHashCode());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Width={0},Height={1}", Width, Height);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(SizeF other)
        {
            return this.Width == other.Width &&
                   this.Height == other.Height;
        }

        #endregion Public Instance Method

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static SizeF operator +(in SizeF left, in SizeF right)
        {
            return new SizeF(left.Width + right.Width, left.Height + right.Height);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static SizeF operator -(in SizeF left, in SizeF right)
        {
            return new SizeF(left.Width - right.Width, left.Height - right.Height);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static SizeF operator *(in SizeF left, float right)
        {
            return new SizeF(left.Width * right, left.Height * right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in SizeF left, in SizeF right)
        {
            return left.Width == right.Width && left.Height == right.Height;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in SizeF left, in SizeF right)
        {
            return left.Width != right.Width || left.Height != right.Height;
        }

        #endregion Operator Overload     
    }
}
