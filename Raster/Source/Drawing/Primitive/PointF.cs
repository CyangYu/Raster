using System;
using Raster.Private;

namespace Raster.Drawing.Primitive
{
    /// <summary>
    /// 
    /// </summary>
    public struct PointF : IEquatable<PointF>
    {
        #region Public Instance Fields
        /// <summary>
        /// 
        /// </summary>
        public float X;
        /// <summary>
        /// 
        /// </summary>
        public float Y;
        #endregion Public Instance Fields

        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly PointF Empty = new PointF(0.0f, 0.0f);
        #endregion Public Static Fields

        #region Constructor
        public PointF(in PointF other)
            : this(other.X, other.Y)
        {
        }

        public PointF(float x, float y)
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
            if (obj is PointF)
            {
                return Equals((PointF)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() =>
            HashHelpers.Combine(X.GetHashCode(), Y.GetHashCode());

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            string.Format("PointF X = {0} Y = {1}", X, Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(PointF other) => this == other;

        /// <summary>
        /// 
        /// </summary>
        public bool IsEmpty() => X == 0.0f && Y == 0.0f;

        #endregion Public Instance Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static PointF operator +(in PointF left, in PointF right) =>
            new PointF(left.X + right.X, left.Y + right.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static PointF operator -(in PointF left, in PointF right) =>
            new PointF(left.X - right.X, left.Y - right.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static PointF operator *(in PointF left, float right) =>
            new PointF(left.X * right, left.Y * right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in PointF left, in PointF right) =>
            left.X == right.X && left.Y == right.Y;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in PointF left, in PointF right) =>
            left.X != right.X || left.Y != right.Y;

        #endregion Operator Overload
    }
}
