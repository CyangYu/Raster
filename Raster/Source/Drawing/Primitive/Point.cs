using System;
using System.Numerics;

namespace Raster.Drawing
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
        public int X;
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
            : this(other.X, other.Y)
        {
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        #endregion Constructor

        /// <summary>
        /// 
        /// </summary>
        public bool IsEmpty => X == 0 && Y == 0;

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point operator +(in Point left, in Point right) => 
            new Point(left.X + right.X, left.Y + right.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point operator -(in Point left, in Point right) =>
            new Point(left.X - left.X, left.Y - right.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(in Point left, in Point right) =>
            left.X == right.X && left.Y == right.Y;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(in Point left, in Point right) =>
            left.X != right.X || left.Y != right.Y;

        #endregion Constructor

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
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() => 
            string.Format("Point: X = {0} Y = {1}", X, Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Point other) => this == other;
    }
}
