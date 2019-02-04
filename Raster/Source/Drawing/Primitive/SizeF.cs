using System;

namespace Raster.Drawing
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
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

        #endregion Public Static Fields

        #region Constructor
        public SizeF(in SizeF other)
            : this(other.Width, other.Height)
        {
        }

        public SizeF(float width, float height)
        {
            Width  = width;
            Height = height;
        }

        #endregion

        #region Public Instance Methods
        public override bool Equals(object obj)
        {
            if (obj is SizeF)
            {
                return Equals((SizeF)obj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Width.GetHashCode() ^ Height.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            string.Format("SizeF: Width = {0}, Height = {1}", Width, Height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(SizeF other) => this == other;

        #endregion Public Instance Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in SizeF left, in SizeF right) =>
            left.Width == right.Width && left.Height == right.Height;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in SizeF left, in SizeF right) =>
            left.Width != right.Width || left.Height != right.Height;

        #endregion Operator Overload     
    }
}
