using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Raster.Drawing.Primitive;

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
            : this(line.Origin, line.Direction)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        public Ray(in LineSegment segment)
            : this(segment.Start, segment.Direction)
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
            return string.Format("Ray: Origin = {{X = {0}, Y = {1}, Z = {2}}; Direction = {{X = {3}, Y = {4}, Z = {5}}",
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
            return this.Origin == other.Origin &&
                   this.Direction == other.Direction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="delta></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3 PointAt(float distance)
        {
            PointAt(this, distance, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Vector3 ClosetPoint(in Vector3 point)
        {
            Collision.ClosetPointPointRay(point, this, out float distance, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public Vector3 ClosetPoint(in Vector3 point, out float distance)
        {
            Collision.ClosetPointPointRay(point, this, out distance, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <returns></returns>
        public Vector3 ClosetPoint(in Ray ray)
        {
            Collision.ClosetPointRayRay(this, ray, out float distance0, out float distance1, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="d0"></param>
        /// <param name="d1"></param>
        /// <returns></returns>
        public Vector3 ClosetPoint(in Ray ray, out float distance0, out float distance1)
        {
            Collision.ClosetPointRayRay(this, ray, out distance0, out distance1, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public Vector3 ClosetPoint(in Line line)
        {
            Collision.ClosetPointRayLine(this, line, out float distance0, out float distance1, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="d0"></param>
        /// <param name="d1"></param>
        /// <returns></returns>
        public Vector3 ClosetPoint(in Line line, out float distance0, out float distance1)
        {
            Collision.ClosetPointRayLine(this, line, out distance0, out distance1, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        public Vector3 ClosetPoint(in LineSegment segment)
        {
            Collision.ClosetPointRayLineSegment(this, segment, out float distance0, out float distance1, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="d0"></param>
        /// <param name="d1"></param>
        /// <returns></returns>
        public Vector3 ClosetPoint(in LineSegment segment, out float distance0, out float distance1)
        {
            Collision.ClosetPointRayLineSegment(this, segment, out distance0, out distance1, out Vector3 result);
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="capsule"></param>
        /// <returns></returns>
        public float Distance(in Capsule capsule)
        {
            return Collision.DistanceRayCapsule(this, capsule);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public float Distance(in Vector3 point)
        {
            return Collision.DistanceRayPoint(this, point, out float distance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public float Distance(in Vector3 point, out float distance)
        {
            return Collision.DistanceRayPoint(this, point, out distance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public float Distance(in Line line)
        {
            return Collision.DistanceRayLine(this, line, out float distance0, out float distance1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="distance0"></param>
        /// <param name="distance1"></param>
        /// <returns></returns>
        public float Distance(in Line line, out float distance0, out float distance1)
        {
            return Collision.DistanceRayLine(this, line, out distance0, out distance1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        public float Distance(in LineSegment segment)
        {
            return Collision.DistanceRayLineSegment(this, segment, out float distance0, out float distance1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="distance0"></param>
        /// <param name="distance1"></param>
        /// <returns></returns>
        public float Distance(in LineSegment segment, out float distance0, out float distance1)
        {
            return Collision.DistanceRayLineSegment(this, segment, out distance0, out distance1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <returns></returns>
        public float Distance(in Ray ray)
        {
            return Collision.DistanceRayRay(this, ray, out float distance0, out float distance1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="d0"></param>
        /// <param name="d1"></param>
        /// <returns></returns>
        public float Distance(in Ray ray, out float distance0, float distance1)
        {
            return Collision.DistanceRayRay(this, ray, out distance0, out distance1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sphere"></param>
        /// <returns></returns>
        public float Distance(in Sphere sphere)
        {
            return Collision.DistanceRaySphere(this, sphere);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public bool Intersects(in BoundingBox box)
        {
            return Collision.RayIntersectsBox(this, box, out float distance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="box"></param>
        /// <param name="distance"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool Intersects(in BoundingBox box, out float distance, out Vector3 point)
        {
            return Collision.RayIntersectsBox(this, box, out distance, out point);
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
            near = 0.0f;
            far = 1.0f;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capsule"></param>
        /// <returns></returns>
        public bool Intersects(in Capsule capsule)
        {
            return Collision.RayIntersectsCapsule(this, capsule);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cirle"></param>
        /// <returns></returns>
        public bool Intersects(in Circle cirle)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frustum"></param>
        /// <returns></returns>
        public bool Intersects(in Frustum frustum)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public bool Intersects(in OrientedBox box)
        {
            return false;
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
            near = 0.0f;
            far = 1.0f;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plane"></param>
        /// <returns></returns>
        public bool Intersects(in Plane plane)
        {
            return Collision.RayIntersectsPlane(this, plane, out float distance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plane"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public bool Intersects(in Plane plane, out float distance, out Vector3 point)
        {
            return Collision.RayIntersectsPlane(this, plane, out distance, out point);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <returns></returns>
        public bool Intersects(in Ray ray)
        {
            return Collision.RayIntersectsRay(this, ray, out Vector3 point);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool Intersects(in Ray ray, out Vector3 point)
        {
            return Collision.RayIntersectsRay(this, ray, out point);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sphere"></param>
        /// <returns></returns>
        public bool Intersects(in Sphere sphere)
        {
            return Collision.RayIntersectsSphere(this, sphere, out float distance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sphere"></param>
        /// <param name="d"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool Intersects(in Sphere sphere, out float distance, out Vector3 point)
        {
            return Collision.RayIntersectsSphere(this, sphere, out distance, out point);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public bool Intersects(in Triangle triangle)
        {
            return Collision.RayIntersectsTriangle(this, triangle, out float distance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="triangle"></param>
        /// <param name="d"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool Intersects(in Triangle triangle, out float distance, out Vector3 point)
        {
            return Collision.RayIntersectsTriangle(this, triangle, out distance, out point);
        }

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="worldViewProjection"></param>
        /// <param name="viewport"></param>
        /// <returns></returns>
        public static Ray GetPickRay(int x, int y,
                                     in Matrix4x4 worldViewProjection,
                                     in Viewport viewport)
        {
            GetPickRay(x, y, worldViewProjection, viewport, out Ray result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="worldViewProjection"></param>
        /// <param name="viewport"></param>
        /// <param name="result"></param>
        public static void GetPickRay(int x, int y,
                                      in Matrix4x4 worldViewProjection,
                                      in Viewport viewport,
                                      out Ray result)
        {
            Vector3 nearPoint = new Vector3(x, y, 0.0f);
            Vector3 farPoint = new Vector3(x, y, 1.0f);

            Matrix4x4.Inverse(worldViewProjection, out Matrix4x4 invertedWorldViewProjection);

            Vector3.Unproject(nearPoint, invertedWorldViewProjection, viewport, out nearPoint);
            Vector3.Unproject(farPoint, invertedWorldViewProjection, viewport, out farPoint);

            Vector3.Subtract(farPoint, nearPoint, out result.Direction);
            result.Direction.Normalize();

            result.Origin.X = nearPoint.X;
            result.Origin.Y = nearPoint.Y;
            result.Origin.Z = nearPoint.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PointAt(in Ray ray, float distance, out Vector3 result)
        {
            result.X = ray.Origin.X + distance * ray.Direction.X;
            result.Y = ray.Origin.Y + distance * ray.Direction.Y;
            result.Z = ray.Origin.Z + distance * ray.Direction.Z;
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
            return left.Origin == right.Origin &&
                   left.Direction == right.Direction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Ray left, in Ray right)
        {
            return left.Origin != right.Origin ||
                   left.Direction != right.Direction; 
        }

        #endregion Operator Overload
    }
}