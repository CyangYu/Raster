using System;
using System.Runtime.CompilerServices;

namespace Raster.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    public struct Circle : IEquatable<Circle>
    {
        #region Public Instance Fields
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Center;
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Normal;
        /// <summary>
        /// 
        /// </summary>
        public float Radius;
        #endregion Public Instance Fields

        #region Public Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Circle)
            {
                return Equals((Circle)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Circle: Center X = {0}, Y = {1}, Z = {2}; Normal X = {3}, Y = {4}, Z = {5}; Radius = {6}",
                                 Center.X, Center.Y, Center.Z, Normal.X, Normal.Y, Normal.Z, Radius);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Circle other)
        {
            return this.Center == other.Center &&
                   this.Normal == other.Normal &&
                   this.Radius == other.Radius;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Plane ContainingPlane()
        {
            return new Plane(Center, Normal);
        }

        #endregion Public Instance Methods
    }
}
