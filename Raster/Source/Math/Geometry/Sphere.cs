using System;
using System.Runtime.CompilerServices;

namespace Raster.Math.Geometry
{
    public struct Sphere : IEquatable<Sphere>
    {
        public Vector3 Center;
        public float Radius;
		
        public Sphere(in Sphere other)
            : this(other.Center, other.Radius)
        {
        }

        public Sphere(Vector3 center, float radius)
        {
            Center = center;
            Radius = radius;
        }

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

        public override bool Equals(object obj)
        {
            if (obj is Sphere)
			{
                return Equals((Sphere)obj);
			}
			
            return false;
        }

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
    }
}
