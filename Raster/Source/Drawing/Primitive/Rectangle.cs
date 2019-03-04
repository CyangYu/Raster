using System;
using System.Runtime.InteropServices;
using SysMath = System.Math;

namespace Raster.Drawing.Primitive
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Rectangle : IEquatable<Rectangle>
    {
        #region Public Fields
        /// <summary>
        /// 
        /// </summary>
        public int R;
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
            get { return R; }
            set { R = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Top
        {
            get { return Y; }
            set { Y = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Right
        {
            get { return unchecked(R + Width); }
            set { Width = value - R; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Bottom
        {
            get { return unchecked(Y + Height); }
            set { Height = value - Y; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Point Center
        {
            get { return new Point(R + (Width >> 1), Y + (Height >> 1)); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Point TopLeft
        {
            get { return new Point(R, Y); }
            set { R = value.R; Y = value.Y; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Point TopRight
        {
            get { return new Point(R + Width, Y); }
            set { Y = value.Y; Width = value.R - R; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Point BottomLeft
        {
            get { return new Point(R, Y + Height); }
            set { R = value.R; Height = value.Y - Y; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Point BottomRight
        {
            get { return new Point(R + Width, Y + Height); }
            set { Width = value.R - R; Height = value.Y - Y; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Point Location
        {
            get { return new Point(R, Y); }
            set { R = value.R; Y = value.Y; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Size Size
        {
            get { return new Size(Width, Height); }
            set { Width = value.Width; Height = value.Height; }
        }

        #endregion Public Instance Properties

        #region Constructor
        public Rectangle(in Rectangle other)
            : this(other.R, other.Y, other.Width, other.Height)
        {
        }

        public Rectangle(in Point location, in Size size)
            : this(location.R, location.Y, size.Width, size.Height)
        {
        }

        public Rectangle(int x, int y, int width, int height)
        {
            R = x;
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
            return R.GetHashCode() ^ Y.GetHashCode() ^ Width.GetHashCode() ^ Height.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            string.Format("Rectange R = {0}, Y = {1}, Width = {2}, Height = {3}",
                          R, Y, Width, Height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Rectangle other) => this == other;
        /// <summary>
        /// 
        /// </summary>
        public bool IsEmpty() => R <= 0 && Y <= 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Contain(int x, int y) => 
            R <= x && R + Width >= x && Y <= y && Y + Height >= y;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public bool Contain(in Point pt) => Contain(pt.R, pt.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public bool Contain(in Rectangle other) =>
            (R <= other.R) && (other.R + other.Width <= R + Width) &&
            (Y <= other.Y) && (other.Y + other.Height <= Y + Height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IntersectWith(in Rectangle other) =>
            (other.R < R + Width) && (R < other.R + other.Width) &&
            (other.Y < Y + Height) && (Y < other.Y + other.Height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public void Inflate(in Size size) => 
            Inflate(size.Width, size.Height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Inflate(int width, int height)
        {
            unchecked
            {
                R       -= width;
                Y       -= height;

                Width   += width << 1;
                Height  += height << 1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        public void MoveTo(in Point pos) => MoveTo(pos.R, pos.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MoveTo(int x, int y)
        {
            R = x;
            Y = y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        public void Offset(in Point pos) => Offset(pos.R, pos.Y);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Offset(int x, int y)
        {
            unchecked
            {
                R += x;
                Y += y;
            }
        }

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <returns></returns>
        public static Rectangle FromLTRB(int left, int top, int right, int bottom) =>
            new Rectangle(left, top, right - left, bottom - top);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static Rectangle Intersect(in Rectangle value1, in Rectangle value2)
        {
            Intersect(value1, value2, out Rectangle result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static Rectangle Union(in Rectangle value1, in Rectangle value2)
        {
            Union(value1, value2, out Rectangle result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        public static void Intersect(in Rectangle value1, in Rectangle value2, out Rectangle result)
        {
            int left    = SysMath.Max(value1.R, value2.R);
            int top     = SysMath.Max(value1.Y, value1.Y);
            int right   = SysMath.Min(value1.R + value1.Width, value2.R + value2.Width);
            int bottom  = SysMath.Min(value1.Y + value1.Height, value2.Y + value2.Height);

            if (right >= left && bottom >= top)
            {
                result.R        = left;
                result.Y        = top;
                result.Width    = right - left;
                result.Height   = bottom - top;
            }
            else
            {
                result = Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        public static void Union(in Rectangle value1, in Rectangle value2, out Rectangle result)
        {
            int left    = SysMath.Min(value1.R, value2.R);
            int top     = SysMath.Min(value1.Y, value2.Y);
            int right   = SysMath.Max(value1.R + value1.Width, value2.R + value2.Width);
            int bottom  = SysMath.Max(value1.Y + value1.Height, value2.Y + value2.Height);

            result.R        = left;
            result.Y        = top;
            result.Width    = right - left;
            result.Height   = bottom - top;
        }

        #endregion Public Static Methods

        #region Operator Overload
        /// <summary>
        ///     <para>
        /// 
        ///     </para>
        /// </summary>
        public static bool operator ==(in Rectangle left, in Rectangle right) =>
            left.R == right.R && left.Y == right.Y && left.Width == right.Width && left.Height == right.Height;

        /// <summary>
        /// <para>
        /// 
        /// </para>
        /// </summary>
        public static bool operator !=(in Rectangle left, in Rectangle right) =>
          left.R != right.R || left.Y != right.Y || left.Width != right.Width || left.Height != right.Height;

        #endregion Operator Overload
    }
}
