using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Raster.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Ray : IEquatable<Ray>
    {
        #region Public Fields
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Origin;
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Direction;
        #endregion Public Fields

        #region Public Instance Fields
        /// <summary>
        /// 
        /// </summary>
        public bool IsInfinity
        {
            get { return Origin.IsInfinity; }
        }

        #endregion Public Instance Fields

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public Ray(in Ray other)
            : this(other.Origin, other.Direction)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="direction"></param>
        public Ray(in Vector3 origin, in Vector3 direction)
        {
            this.Origin = origin;
            this.Direction = direction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ine"></param>
        public Ray(in Line line)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        public Ray(in LineSegment segment)
        {

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
            return string.Format("Ray: Origin X = {0}, Y = {1}, Z = {2}, Direction: X = {3}, Y = {4}, Z = {5} ",
                                 Origin.X, Origin.Y, Origin.Z, Direction.X, Direction.Y, Direction.Z);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Ray other)
        {
            return this.Origin.X == other.Origin.X && 
                   this.Origin.Y == other.Origin.Y &&
                   this.Origin.Z == other.Origin.Z && 
                   this.Direction.X == other.Direction.X &&
                   this.Direction.Y == other.Direction.Y && 
                   this.Direction.Z == other.Direction.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="delta></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3 PointAt(float delta)
        {
            PointAt(this, delta, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public float Distance(in Vector3 point)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public float Distance(in Vector3 point, out float d)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <returns></returns>
        public float Distance(in Ray ray)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public float Distance(in Ray ray, out float d)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="d0"></param>
        /// <param name="d1"></param>
        /// <returns></returns>
        public float Distance(in Ray ray, out float d0, float d1)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public float Distance(in Line line)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public float Distance(in Line line, out float d)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="d0"></param>
        /// <param name="d1"></param>
        /// <returns></returns>
        public float Distance(in Line line, out float d0, out float d1)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        public float Distance(in LineSegment segment)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public float Distance(in LineSegment segment, out float d)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="d0"></param>
        /// <param name="d1"></param>
        /// <returns></returns>
        public float Distance(in LineSegment segment, out float d0, out float d1)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sphere"></param>
        /// <returns></returns>
        public float Distance(in Sphere sphere)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capsule"></param>
        /// <returns></returns>
        public float Distance(in Capsule capsule)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Vector3 ClosetPoint(in Vector3 point)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public Vector3 ClosetPoint(in Vector3 point, out float d)
        {

        }

        public Vector3 ClosetPoint(in Ray ray)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public Vector3 CloseetPoint(in Ray ray, out float d)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="d0"></param>
        /// <param name="d1"></param>
        /// <returns></returns>
        public Vector3 ClosetPoint(in Ray ray, out float d0, out float d1)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public Vector3 ClosetPoint(in Line line)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public Vector3 CloseetPoint(in Line line, out float d)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="d0"></param>
        /// <param name="d1"></param>
        /// <returns></returns>
        public Vector3 ClosetPoint(in Line line, out float d0, out float d1)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        public Vector3 ClosetPoint(in LineSegment segment)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public Vector3 CloseetPoint(in LineSegment segment, out float d)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="d0"></param>
        /// <param name="d1"></param>
        /// <returns></returns>
        public Vector3 ClosetPoint(in LineSegment segment, out float d0, out float d1)
        {

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public bool Intersects(in Triangle triangle)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="triangle"></param>
        /// <param name="d"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool Intersects(in Triangle triangle, out float d, out Vector3 point)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plane"></param>
        /// <returns></returns>
        public bool Intersects(in Plane plane)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plane"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public bool Intersects(in Plane plane, out float d)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sphere"></param>
        /// <returns></returns>
        public bool Intersects(in Sphere sphere)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sphere"></param>
        /// <param name="d"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool Intersects(in Sphere sphere, out float d, out Vector3 point)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public bool Intersects(in BoundingBox box)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="box"></param>
        /// <param name="near"></param>
        /// <param name="far"></param>
        /// <returns></returns>
        public bool Intersects(in BoundingBox box, out float near, out float far)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public bool Intersects(in OrientedBox box)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="box"></param>
        /// <param name="near"></param>
        /// <param name="far"></param>
        /// <returns></returns>
        public bool Intersects(in OrientedBox box, out float near, out float far)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capsule"></param>
        /// <returns></returns>
        public bool Intersects(in Capsule capsule)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frustum"></param>
        /// <returns></returns>
        public bool Intersects(in Frustum frustum)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cirle"></param>
        /// <returns></returns>
        public bool Intersects(in Circle cirle)
        {

        }

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PointAt(in Ray ray, float delta, out Vector3 result)
        {
            result.X = ray.Origin.X + delta * ray.Direction.X;
            result.Y = ray.Origin.Y + delta * ray.Direction.Y;
            result.Z = ray.Origin.Z + delta * ray.Direction.Z;
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
            return (left.Origin.X == right.Origin.X &&
                    left.Origin.Y == right.Origin.Y &&
                    left.Origin.Z == right.Origin.Z &&
                    left.Direction.X == right.Direction.X &&
                    left.Direction.Y == right.Direction.Y &&
                    left.Direction.Z == right.Direction.Z);
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
                    left.Direction.X != right.Direction.X ||
                    left.Direction.Y != right.Direction.Y ||
                    left.Direction.Z != right.Direction.Z);
        }

        #endregion Operator Overload
    }
}