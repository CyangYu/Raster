using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Raster.Math.Geometry
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Ray : IEquatable<Ray>
    {
        #region Public Fields
        /// <summary>
        /// 
        /// </summary>
        public Point3F Origin;
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Direction;
        #endregion Public Fields

        #region Constructor
        public Ray(in Ray other)
            : this(other.Origin, other.Direction)
        {
        }

        public Ray(in Point3F origin, in Vector3 direction)
        {
            Origin = origin;
            Direction = direction;
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
            return Origin.GetHashCode() ^ Direction.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            string.Format("Ray: Origin X = {0}, Y = {1}, Z = {2} Direction: X = {3}, Y = {4}, Z = {5}",
                          Origin.X, Origin.Y, Origin.Z, Direction.X, Direction.Y, Direction.Z);


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
        public Point3F PointAt(float time)
        {
            Direction.Normalize();
            return new Point3F(Origin.X + time * Direction.X,
                               Origin.Y + time * Direction.Y,
                               Origin.Z + time * Direction.Z);
        }

        #endregion Public Instance Methods

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
            return (left.Origin.X == right.Origin.X &&
                    left.Origin.Y == right.Origin.Y &&
                    left.Origin.Z == right.Origin.Z &&
                    left.Direction == right.Direction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Ray left, in Ray right)
        {
            return (left.Origin.X != right.Origin.X ||
                    left.Origin.Y != right.Origin.Y ||
                    left.Origin.Z != right.Origin.Z ||
                    left.Direction != right.Direction);
        }

        #endregion Operator Overload
    }
}
