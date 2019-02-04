using System;
using Raster.Private;

namespace Raster.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct Point3F : IEquatable<Point3F>
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
        public float Z;
        #endregion Public Fields

        #region Public Static Properties
        /// <summary>
        /// 
        /// </summary>
        public static readonly Point3F Empty = new Point3F(0.0f, 0.0f, 0.0f);

        #endregion Public Static Properties

        #region Constructor
        public Point3F(in Point3F other)
            : this(other.X, other.Y, other.Z)
        {
        }

        public Point3F(in Vector3 vec3)
            : this(vec3.X, vec3.Y, vec3.Z)
        {
        }

        public Point3F(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
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
            if (obj is Point3F)
            {
                return Equals((Point3F)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = HashHelpers.Combine(X.GetHashCode(), Y.GetHashCode());
            return HashHelpers.Combine(hash, Z.GetHashCode());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            string.Format("Point3F X = {0} Y = {1}, Z = {2}", X, Y, Z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Point3F other) => this == other;

        /// <summary>
        /// 
        /// </summary>
        public bool IsEmpty() => X == 0.0f && Y == 0.0f && Z == 0.0f;

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Point3F Add(in Point3F left, in Point3F right) =>
            new Point3F(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Point3F Subtract(in Point3F left, in Point3F right) =>
            new Point3F(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Point3F Multiply(in Point3F left, float right) =>
            new Point3F(left.X * right, left.Y * right, left.Z * right);

        #endregion Public Static Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point3F operator +(in Point3F left, in Point3F right) =>
            Add(left, right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point3F operator -(in Point3F left, in Point3F right) =>
            Subtract(left, right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point3F operator *(in Point3F left, float right) =>
            Multiply(left, right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Point3F left, in Point3F right) =>
            left.X == right.X && left.Y == right.Y && left.Z == right.Z;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Point3F left, in Point3F right) =>
            left.X != right.X || left.Y != right.Y || left.Z == right.Z;

        #endregion Operator Overload
    }
}
