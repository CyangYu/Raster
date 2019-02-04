using System;

namespace Raster.Math.Geometry
{
    public struct PointF : IEquatable<PointF>
    {
        public float X;
        public float Y;

        /// <summary>
        /// 
        /// </summary>
        public static readonly PointF Empty = new PointF(0.0f, 0.0f);

        public PointF(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsEmpty => X == 0.0f && Y == 0.0f;

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

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override string ToString() => 
            string.Format("PointF X = {0} Y = {1}", X, Y);

        public bool Equals(PointF other) => this == other;
    }
}
