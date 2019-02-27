using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Raster.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Ray : IEquatable<Ray>, IHitable
    {
        #region Public Fields
        /// <summary>
        /// 
        /// </summary>
        public Vector3 origin;
        /// <summary>
        /// 
        /// </summary>
        public Vector3 direction;
        #endregion Public Fields

        #region Constructor
        public Ray(in Ray other)
            : this(other.origin, other.direction)
        {
        }

        public Ray(in Vector3 origin, in Vector3 direction)
        {
            this.origin = origin;
            this.direction = direction;
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
            if (obj is Ray)
            {
                return Equals((Ray)obj);
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
            return string.Format("Ray: Origin R = {0}, Y = {1}, Z = {2}, " +
                                 "Direction: R = {3}, Y = {4}, Z = {5} ",
                                 origin.R, origin.Y, origin.Z,
                                 direction.R, direction.Y, direction.Z);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Ray other) => this == other;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3 PointAt(float time)
        {
            return new Vector3(
                origin.R + time * direction.R,
                origin.Y + time * direction.Y,
                origin.Z + time * direction.Z);
        }

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PointAt(in Ray ray, float time, out Vector3 result)
        {
            result.R = ray.origin.R + time * ray.direction.R;
            result.Y = ray.origin.Y + time * ray.direction.Y;
            result.Z = ray.origin.Z + time * ray.direction.Z;
        }

        #endregion Public Static Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(in Ray left, in Ray right)
        {
            return (left.origin.R == right.origin.R &&
                    left.origin.Y == right.origin.Y &&
                    left.origin.Z == right.origin.Z &&
                    left.direction.R == right.direction.R &&
                    left.direction.Y == right.direction.Y &&
                    left.direction.Z == right.direction.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Ray left, in Ray right)
        {
            return (left.origin.R != right.origin.R ||
                    left.origin.Y != right.origin.Y ||
                    left.origin.Z != right.origin.Z ||
                    left.direction.R != right.direction.R ||
                    left.direction.Y != right.direction.Y ||
                    left.direction.Z != right.direction.Z);
        }

        #endregion Operator Overload
    }
}
