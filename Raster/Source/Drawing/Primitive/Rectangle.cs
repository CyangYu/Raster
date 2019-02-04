using System;

namespace Raster.Drawing
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct Rectangle : IEquatable<Rectangle>
    {
        #region Public Fields
        /// <summary>
        /// 
        /// </summary>
        public int X;
        /// <summary>
        /// 
        /// </summary>
        public int Y;
        /// <summary>
        /// 
        /// </summary>
        public int Width;
        /// <summary>
        /// 
        /// </summary>
        public int Height;
        #endregion Public Fields

        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly Rectangle Empty = new Rectangle(0, 0, 0, 0);
        #endregion Public Static Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public int Left
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
        public int Top
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
        public int Right
        {
            get
            {
                return unchecked(X + Width);
            }

            set
            {
                if (value >= X)
                {
                    Width = value - X;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Bottom
        {
            get
            {
                return X + Width;
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
        public Point TopLeft
        {
            get
            {
                return new Point(X, Y);
            }

            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Point TopRight
        {
            get
            {
                return new Point(X + Width, Y);
            }
        }

        public Point Center
        {
            get
            {
                return new Point(X + (Width >> 1), Y + (Height >> 1));
            }

            set
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Point BottomLeft
        {
            get
            {
                return new Point(X, Y + Height);
            }

            set
            {
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Point BottomRight
        {
            get
            {
                return new Point(X + Width, Y + Height);
            }

            set
            {

            }
        }

        #endregion Public Instance Properties

        #region Constructor
        public Rectangle(in Rectangle other)
            : this(other.X, other.Y, other.Width, other.Height)
        {
        }

        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
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
            if (obj is Rectangle)
            {
                return Equals((Rectangle)obj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Width.GetHashCode() ^ Height.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            string.Format("Rectange X = {0}, Y = {1}, Width = {2}, Height = {3}",
                          X, Y, Width, Height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Rectangle other) => this == other;
        /// <summary>
        /// 
        /// </summary>
        public bool IsEmpty() => X <= 0 && Y <= 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Contain(int x, int y) => 
            X <= x && X + Width >= x && Y <= y && Y + Height >= y;

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
        public bool Contain(in Rectangle other) =>
            (X <= other.X) && (other.X + other.Width <= X + Width) &&
            (Y <= other.Y) && (other.Y + other.Height <= Y + Height);

        public bool Intersect(in Rectangle other)
        {
            return false;
        }

        #endregion Public Instance Methods

        #region Operator Overload
        /// <summary>
        ///     <para>
        /// 
        ///     </para>
        /// </summary>
        public static bool operator ==(in Rectangle left, in Rectangle right) =>
            left.X == right.X && left.Y == right.Y && left.Width == right.Width && left.Height == right.Height;

        /// <summary>
        /// <para>
        /// 
        /// </para>
        /// </summary>
        public static bool operator !=(in Rectangle left, in Rectangle right) =>
          left.X != right.X || left.Y != right.Y || left.Width != right.Width || left.Height != right.Height;

        #endregion Operator Overload
    }
}
