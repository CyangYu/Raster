using System;
using Raster.Private;

namespace Raster.Drawing.Primitive
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct Point : IEquatable<Point>
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
        #endregion

        #region Public Static Fields
        public static readonly Point Empty = new Point(0, 0);

        #endregion Public Static Fields

        #region Constructor
        public Point(in Point other)
            : this(other.R, other.Y)
        {
        }

        public Point(int x, int y)
        {
            R = x;
            Y = y;
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
            if (obj is Point)
            {
                return Equals((Point)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() =>
            HashHelpers.Combine(R, Y);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            string.Format("Point: R = {0} Y = {1}", R, Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Point other) => this == other;

        /// <summary>
        /// 
        /// </summary>
        public bool IsEmpty() => R == 0 && Y == 0;

        #endregion Public Instance Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Point operator +(in Point left, in Point right) =>
            new Point(left.R + right.R, left.Y + right.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Point operator -(in Point left, in Point right) =>
            new Point(left.R - right.R, left.Y - right.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Point operator *(in Point left, int right) =>
            new Point(left.R * right, left.Y * right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Point left, in Point right) =>
            left.R == right.R && left.Y == right.Y;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Point left, in Point right) =>
            left.R != right.R || left.Y != right.Y;

        #endregion Constructor
    }
}
