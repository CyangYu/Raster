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

        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly RectangleF Empty = new RectangleF(0.0f, 0.0f, 0.0f, 0.0f);

        #endregion Public Static Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public float Left
        {
            get { return X; }
            set { X = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float Top
        {
            get { return Y; }
            set { Y = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float Right
        {
            get { return unchecked(X + Width); }
            set { Width = value - X; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float Bottom
        {
            get { return unchecked(Y + Height); }
            set { Height = value - Y; }
        }

        /// <summary>
        /// 
        /// </summary>
        public PointF Center
        {
            get { return new PointF(X + Width / 2.0f, Y + Height / 2.0f); }
        }

        /// <summary>
        /// 
        /// </summary>
        public PointF TopLeft
        {
            get { return new PointF(X, Y); }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public PointF TopRight
        {
            get { return new PointF(X + Width, Y); }
            set
            {
                Width = value.X - X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public PointF BottomLeft
        {
            get { return new PointF(X, Y + Height); }
            set { X = value.X; Height = value.Y - Y; }
        }

        /// <summary>
        /// 
        /// </summary>
        public PointF BottomRight
        {
            get { return new PointF(X + Width, Y + Height); }
            set { Width = value.X - X; Y = value.Y; }
        }

        /// <summary>
        /// 
        /// </summary>
        public PointF Location
        {
            get { return new PointF(X, Y); }
            set { X = value.X; Y = value.Y; }
        }

        /// <summary>
        /// 
        /// </summary>
        public SizeF Size
        {
            get { return new SizeF(Width, Height); }
            set { Width = value.Width; Height = value.Height; }
        }

        #endregion Public Instance Properties

        #region Constructor
        public RectangleF(in RectangleF other)
            : this(other.X, other.Y, other.Width, other.Height)
        {
        }

        public RectangleF(in PointF location, in SizeF size)
            : this(location.X, location.Y, size.Width, size.Height)
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is RectangleF)
            {
                return Equals((RectangleF)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
            return string.Format("RectangeF X = {0}, Y = {1}, Width = {2}, Height = {3}",
								 X, Y, Width, Height);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(RectangleF other)
        {
            return this.X == other.X && this.Y == other.Y &&
                   this.Width == other.Width && this.Height == other.Height;
        }

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
        public bool Contain(float x, float y)
        {
            return X <= x && X + Width >= x && Y <= y && Y + Height <= y;
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
        public bool Contain(in RectangleF other) 
		{
            return (X <= other.X) && (other.Right <= Right) &&
				   (Y <= other.Y) && (other.Bottom <= Bottom);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IntersectWith(in RectangleF other)
		{
            return (other.X < X + Width) && (X < other.X + other.Width) &&
				   (other.Y < Y + Height) && (Y < other.Y + other.Height);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public void Inflate(in SizeF size) { Inflate(size.Width, size.Height); }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Inflate(float x, float y)
        {
            X       -= x;
            Y       -= y;
            Width   += 2.0f * x;
            Height  += 2.0f * y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        public void Offset(in PointF pos) { Offset(pos.X, pos.Y); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Offset(float x, float y)
        {
            X += x;
            Y += y;
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
        public static RectangleF FromLTRB(float left, float top, float right, float bottom)
        {
            return new RectangleF(left, top, right - left, bottom - top);
        }
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static RectangleF Intersect(in RectangleF value1, in RectangleF value2)
        {
            Intersect(value1, value2, out RectangleF result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static RectangleF Union(in RectangleF value1, in RectangleF value2)
        {
            Union(value1, value2, out RectangleF result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        public static void Intersect(in RectangleF value1, in RectangleF value2, out RectangleF result)
        {
            float left      = SysMath.Max(value1.X, value2.X);
            float top       = SysMath.Max(value1.Y, value2.Y);
            float right     = SysMath.Min(value1.X + value1.Width, value2.X + value2.Width);
            float bottom    = SysMath.Min(value2.Y + value2.Height, value2.Y + value2.Height);

            if (right > left && bottom > top)
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
        public static void Union(in RectangleF value1, in RectangleF value2, out RectangleF result)
        {
            float left      = SysMath.Max(value1.X, value2.X);
            float top       = SysMath.Max(value1.Y, value2.Y);
            float right     = SysMath.Min(value1.X + value1.Width, value2.X + value2.Width);
            float bottom    = SysMath.Min(value2.Y + value2.Height, value2.Y + value2.Height);

            result.X        = left;
            result.Y        = top;
            result.Width    = right - left;
            result.Height   = bottom - top;
        }

		#endregion Public Instance Methods

		#region Operator Overload
		/// <summary>
		/// 
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <returns></returns>
		public static bool operator ==(in RectangleF left, in RectangleF right)
		{
			return left.X == right.X && left.Y == right.Y &&
				   left.Width == right.Width && left.Height == right.Height;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in RectangleF left, in RectangleF right) 
		{
          return left.X != right.X || left.Y != right.Y || 
				 left.Width != right.Width || left.Height != right.Height;
		}
		
        #endregion Operator Overload
    }
}
