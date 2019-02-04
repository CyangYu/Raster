using System;

namespace Raster.Drawing.Primitive
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct RectangleF : IEquatable<RectangleF>
    {
        #region Public Fields
        /// <summary>
        /// 
        /// </summary>
        public float X;
        /// <summary>
        /// 
        /// </summary>
        public float Y;
        /// <summary>
        /// 
        /// </summary>
        public float Width;
        /// <summary>
        /// 
        /// </summary>
        public float Height;
        #endregion Public Fields

        /// <summary>
        /// 
        /// </summary>
        public static readonly RectangleF Empty = new RectangleF(0.0f, 0.0f, 0.0f, 0.0f);

        /// <summary>
        /// 
        /// </summary>
        public float Top
        {
            get
            {
                return Y;
            }

            set
            {
                Y = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float Bottom
        {
            get
            {
                return Y + Height;
            }

            set
            {
                if (value >= Y)
                {
                    Height = value - Y;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float Left
        {
            get
            {
                return X;
            }

            set
            {
                X = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float Right
        {
            get
            {
                return X + Width;
            }

            set
            {
                if (value >= X)
                {
                    Width = value - X;
                }
            }
        }

        #region Constructor
        public RectangleF(in RectangleF other)
            : this(other.X, other.Y, other.Width, other.Height)
        {
        }

        public RectangleF(float x, float y, float width, float height)
        {
            X       = x;
            Y       = y;
            Width   = width;
            Height  = height;
        }
        #endregion Constructor

        #region Public Instance Methods
        public override bool Equals(object obj)
        {
            if (obj is RectangleF)
            {
                return Equals((RectangleF)obj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Width.GetHashCode() ^ Height.GetHashCode();
        }

        public override string ToString() =>
            string.Format("RectangeF X = {0}, Y = {1}, Width = {2}, Height = {3}",
                           X, Y, Width, Height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(RectangleF other) => this == other;

        /// <summary>
        /// 
        /// </summary>
        public bool IsEmpty() => 
            X == 0.0f && Y == 0.0f && Width == 0.0f && Height == 0.0f;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Contain(float x, float y) =>
            X <= x && X + Width >= x && Y <= y && Y + Height <= y;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>

        public bool Contain(in Point pt) => Contain(pt.X, pt.Y);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public bool Contain(in RectangleF rect)
        {
            return false;
        }

        public bool Intersect(in RectangleF rect)
        {
            return false;
        }

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in RectangleF left, in RectangleF right) =>
            left.X == right.X && left.Y == right.Y && left.Width == right.Width && left.Height == right.Height;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in RectangleF left, in RectangleF right) =>
          left.X != right.X || left.Y != right.Y || left.Width != right.Width || left.Height != right.Height;

        #endregion Operator Overload
    }
}
