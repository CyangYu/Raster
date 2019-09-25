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
            get { return X; }
            set { X = value; }
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
            get { return unchecked(X + Width); }
            set { Width = value - X; }
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
            get { return new Point(X + (Width >> 1), Y + (Height >> 1)); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Point TopLeft
        {
            get { return new Point(X, Y); }
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
            get { return new Point(X + Width, Y); }
            set
            {
                Y = value.Y;
                Width = value.X - X;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Point BottomLeft
        {
            get { return new Point(X, Y + Height); }
            set
            {
                X = value.X;
                Height = value.Y - Y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Point BottomRight
        {
            get { return new Point(X + Width, Y + Height); }
            set
            {
                Width = value.X - X;
                Height = value.Y - Y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Point Location
        {
            get { return new Point(X, Y); }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Size Size
        {
            get { return new Size(Width, Height); }
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        #endregion Public Instance Properties

        #region Constructor
        public Rectangle(in Rectangle other)
            : this(other.X, other.Y, other.Width, other.Height)
        {
        }

        public Rectangle(in Point location, in Size size)
            : this(location.X, location.Y, size.Width, size.Height)
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
        public override string ToString()
        {
            return string.Format("Rectange X  = {0}, Y = {1}, Width = {2}, Height = {3}",
                          X, Y, Width, Height);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Rectangle other)
        {
            return this.X == other.X && this.Y == other.Y &&
                   this.Width == other.Width && this.Height == other.Height;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsEmpty() { return X <= 0 && Y <= 0; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Contain(int x, int y)
        {
            return X <= x && X + Width >= x && Y <= y && Y + Height >= y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public bool Contain(in Point pt) { return Contain(pt.X, pt.Y); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public bool Contain(in Rectangle other)
        {
            return (X <= other.X) && (other.X + other.Width <= X + Width) &&
                   (Y <= other.Y) && (other.Y + other.Height <= Y + Height);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IntersectWith(in Rectangle other)
        {
            return (other.X < X + Width) && (X < other.X + other.Width) &&
                   (other.Y < Y + Height) && (Y < other.Y + other.Height);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public void Inflate(in Size size) { Inflate(size.Width, size.Height); }
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Inflate(int width, int height)
        {
            unchecked
            {
                X       -= width;
                Y       -= height;

                Width   += width << 1;
                Height  += height << 1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        public void Offset(in Point pos) { Offset(pos.X, pos.Y); }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Offset(int x, int y)
        {
            unchecked
            {
                X  += x;
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
            int left    = SysMath.Max(value1.X, value2.X);
            int top     = SysMath.Max(value1.Y, value1.Y);
            int right   = SysMath.Min(value1.X + value1.Width, value2.X + value2.Width);
            int bottom  = SysMath.Min(value1.Y + value1.Height, value2.Y + value2.Height);

            if (right >= left && bottom >= top)
            {
                result.X        = left;
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
            int left    = SysMath.Min(value1.X, value2.X);
            int top     = SysMath.Min(value1.Y, value2.Y);
            int right   = SysMath.Max(value1.X + value1.Width, value2.X + value2.Width);
            int bottom  = SysMath.Max(value1.Y + value1.Height, value2.Y + value2.Height);

            result.X        = left;
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
        public static bool operator ==(in Rectangle left, in Rectangle right)
        {
            return left.X == right.X && left.Y == right.Y &&
                   left.Width == right.Width && left.Height == right.Height;
        }

        /// <summary>
        /// <para>
        /// 
        /// </para>
        /// </summary>
        public static bool operator !=(in Rectangle left, in Rectangle right)
        {
            return left.X != right.X || left.Y != right.Y ||
                   left.Width != right.Width || left.Height != right.Height;
        }

        #endregion Operator Overload
    }
}
