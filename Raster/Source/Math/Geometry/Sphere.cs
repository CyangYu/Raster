using System;
using System.Runtime.CompilerServices;

namespace Raster.Math.Geometry
{
    public struct Sphere : IEquatable<Sphere>
    {
        #region Public Instance Fields
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Center;
        /// <summary>
        /// 
        /// </summary>
        public float Radius;
        #endregion Public Instance Fields

        #region Constructor
        public Sphere(in Sphere other)
            : this(other.Center, other.Radius)
        {
        }

        public Sphere(Vector3 center, float radius)
        {
            Center = center;
            Radius = radius;
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
            if (obj is Sphere)
            {
                return Equals((Sphere)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Center.GetHashCode() ^ Radius.GetHashCode();
        }

        public override string ToString() =>
            string.Format("Sphere: Center X = {0}, Y = {1} Z = {2} Radius = {3}",
                          Center.X, Center.Y, Center.Z, Radius);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Sphere other) => this == other;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Intersect(in Ray ray)
        {
            return 0;
        }

        #endregion Public Instance Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(in Sphere left, in Sphere right)
        {
            return (left.Center.X == right.Center.X && 
					left.Center.Y != right.Center.Y &&
                    left.Center.Z != right.Center.Z && 
					left.Radius != right.Radius);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(in Sphere left, in Sphere right)
        {
            return (left.Center.X != right.Center.X && 
					left.Center.Y != right.Center.Y &&
                    left.Center.Z != right.Center.Z && 
					left.Radius != right.Radius);
        }
    }
}
