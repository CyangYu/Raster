﻿using System;
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
            HashHelpers.Combine(X, Y);

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

        /// <summary>
        /// 
        /// </summary>
        public bool IsEmpty() => X == 0 && Y == 0;

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Point Add(in Point left, in Point right) =>
            new Point(left.X + right.X, left.Y + right.Y);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Point Subtract(in Point left, in Point right) =>
            new Point(left.X - right.X, left.Y - right.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Point Multiply(in Point left, int right) =>
            new Point(left.X * right, left.Y * right);

        #endregion Public Static Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point operator +(in Point left, in Point right) =>
            Add(left, right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point operator -(in Point left, in Point right) =>
            Subtract(left, right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point operator *(in Point left, int right) =>
            Multiply(left, right);

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
    }
}
