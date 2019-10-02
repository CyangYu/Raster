using System;
using System.Runtime.CompilerServices;
using Raster.Math;

namespace Raster.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    public static class CollisionHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="triangle"></param>
        /// <param name="result"></param>
        public static void ClosetPointPointTriangle(in Vector3 point, in Triangle triangle, out Vector3 result)
        {
            Vector3 edgeA = triangle.Vertex1 - triangle.Vertex0;
            Vector3 edgeB = triangle.Vertex2 - triangle.Vertex0;

            Vector3 edge0 = point - triangle.Vertex0;
            float d0 = Vector3.Dot(edgeA, edge0);
            float d1 = Vector3.Dot(edgeB, edge0);

            if (d0 <= 0.0f && d1 <= 0.0f)
            {
                result = triangle.Vertex0;
                return;
            }

            Vector3 edge1 = point - triangle.Vertex1;
            float d2 = Vector3.Dot(edgeA, edge1);
            float d3 = Vector3.Dot(edgeB, edge1);

            if (d2 >= 0.0f && d3 <= d2)
            {
                result = triangle.Vertex1;
                return;
            }

            float vc = d0 * d3 - d2 * d1;
            if (vc <= 0.0f && d0 >= 0.0f && d2 <= 0.0f)
            {
                float v = d0 / (d0 - d2);
                result = triangle.Vertex0 + v * edgeA;
                return;
            }

            Vector3 edge2 = point - triangle.Vertex2;
            float d4 = Vector3.Dot(edgeA, edge2);
            float d5 = Vector3.Dot(edgeB, edge2);

            if (d4 >= 0.0f && d4 <= d5)
            {
                result = triangle.Vertex2;
                return;
            }

            float vb = d4 * d1 - d0 * d5;
            if (vb <= 0.0f && d1 >= 0.0f && d5 <= 0.0f)
            {
                float w = d1 / (d1 - d5);
                result = triangle.Vertex0 + w * edgeB;
                return;
            }

            float va = d2 * d5 - d4 * d3;
            if (va <= 0.0f && (d3 - d2) >= 0.0f && (d4 - d5) >= 0.0f)
            {
                float w = (d3 - d2) / ((d3 - d2) + (d4 - d5));
                result = triangle.Vertex1 + w * (triangle.Vertex2 - triangle.Vertex1);
                return;
            }

            float denom = 1.0f / (va + vb + vc);
            float v2 = vb * denom;
            float w2 = vc * denom;
            result = triangle.Vertex0 + edgeA * v2 + edgeB * w2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plane"></param>
        /// <param name="point"></param>
        /// <param name="result"></param>
        public static void ClosetPointPlanePoint(in Plane plane, in Vector3 point, out Vector3 result)
        {
            float dot = Vector3.Dot(plane.Normal, point);
            float t = dot - plane.Distance;

            result = point - (t * plane.Normal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="box"></param>
        /// <param name="point"></param>
        /// <param name="result"></param>
        public static void ClosetPointBoxPoint(in BoundingBox box, in Vector3 point, out Vector3 result)
        {
            Vector3.Max(point, box.Minimum, out Vector3 temp);
            Vector3.Min(temp, box.Maximum, out result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sphere"></param>
        /// <param name="point"></param>
        /// <param name="result"></param>
        public static void ClosetPointSpherePoint(in Sphere sphere, in Vector3 point, out Vector3 result)
        {
            Vector3.Subtract(point, sphere.Center, out result);
            result.Normalize();

            result.Multiply(sphere.Radius);
            result.Add(sphere.Center);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sphere0"></param>
        /// <param name="sphere1"></param>
        /// <param name="result"></param>
        public static void ClosetPointSphereSphere(in Sphere sphere0, in Sphere sphere1, out Vector3 result)
        {
            Vector3.Subtract(sphere0.Center, sphere1.Center, out result);
            result.Normalize();

            result.Multiply(sphere0.Radius);
            result.Add(sphere0.Center);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plane"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static float DistancePlanePoint(in Plane plane, in Vector3 point)
        {
            float dot = Vector3.Dot(plane.Normal, point);
            return dot - plane.Distance;
        }

        public static float DistanceBoxPoint(in BoundingBox box, ref Vector3 point)
        {
            float distance = 0.0f;

            if (point.X < box.Minimum.X)
            {
                distance += (box.Minimum.X - point.X) * (box.Minimum.X - point.X);
            }
            if (point.X > box.Maximum.X)
            {
                distance += (point.X - box.Maximum.X) * (point.X - box.Maximum.X);
            }

            if (point.Y < box.Minimum.Y)
            {
                distance += (box.Minimum.Y - point.Y) * (box.Minimum.Y - point.Y);
            }
            if (point.X > box.Maximum.X)
            {
                distance += (point.Y - box.Maximum.Y) * (point.Y - box.Maximum.Y);
            }

            if (point.Z < box.Minimum.Z)
            {
                distance += (box.Minimum.Z - point.Z) * (box.Minimum.Z - point.Z);
            }
            if (point.Z > box.Maximum.Z)
            {
                distance += (point.Z - box.Maximum.Z) * (point.Z - box.Maximum.Z);
            }

            return MathF.Sqrt(distance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="box0"></param>
        /// <param name="box1"></param>
        /// <returns></returns>
        public static float DistanceBoxBox(in BoundingBox box0, in BoundingBox box1)
        {
            float distance = 0.0f;

            // Distance for X.
            if (box0.Minimum.X > box1.Maximum.X)
            {
                float delta = box1.Maximum.X - box0.Minimum.X;
                distance += delta * delta;
            }
            else if (box1.Minimum.X > box0.Maximum.X)
            {
                float delta = box0.Maximum.X - box1.Minimum.X;
                distance += delta * delta;
            }

            if (box0.Minimum.Y > box1.Maximum.Y)
            {
                float delta = box1.Maximum.Y - box0.Minimum.Y;
                distance += delta * delta;
            }
            else if (box1.Maximum.Y > box0.Maximum.X)
            {
                float delta = box0.Maximum.Y - box1.Minimum.Y;
                distance += delta * delta;
            }

            if (box0.Minimum.Z > box1.Maximum.Z)
            {
                float delta = box1.Maximum.Z - box0.Minimum.Z;
                distance += delta * delta;
            }
            else if (box1.Minimum.Z > box0.Maximum.Z)
            {
                float delta = box0.Maximum.Z - box1.Minimum.Z;
                distance += delta * delta;
            }

            return MathF.Sqrt(distance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sphere"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static float DistanceSpherePoint(in Sphere sphere, in Vector3 point)
        {
            float distance = Vector3.Distance(sphere.Center, point);
            distance -= sphere.Radius;

            return MathF.Max(distance, 0.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sphere0"></param>
        /// <param name="sphere1"></param>
        /// <returns></returns>
        public static float DistanceSphereSphere(in Sphere sphere0, in Sphere sphere1)
        {
            float distance = Vector3.Distance(sphere0.Center, sphere1.Center);
            distance -= sphere0.Radius + sphere1.Radius;

            return MathF.Max(distance, 0.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool RayIntersectsPoint(in Ray ray, Vector3 point)
        {
            Vector3.Subtract(ray.Origin, point, out Vector3 temp);

            float b = Vector3.Dot(temp, ray.Direction);
            float c = Vector3.Dot(temp, temp) - MathHelper.ZeroTolerance;

            if (c > 0.0f && b > 0.0f)
            {
                return false;
            }

            float discriminant = b * b - c;
            if (discriminant < 0.0f)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray0"></param>
        /// <param name="ray1"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool RayIntersectsRay(in Ray ray0, in Ray ray1, out Vector3 point)
        {
            Vector3.Cross(ray0.Direction, ray1.Direction, out Vector3 cross);
            float denominator = cross.Length;

            if (MathHelper.IsZero(denominator))
            {
                if (MathHelper.NearEqual(ray1.Origin.X, ray0.Origin.X) &&
                    MathHelper.NearEqual(ray1.Origin.Y, ray0.Origin.Y) &&
                    MathHelper.NearEqual(ray1.Origin.Z, ray0.Origin.Z))
                {
                    point = Vector3.Zero;
                    return true;
                }
            }

            denominator *= denominator;

            Matrix3x3 matrix;
            matrix.M00 = ray1.Origin.X - ray0.Origin.X;
            matrix.M01 = ray1.Origin.Y - ray0.Origin.Y;
            matrix.M02 = ray1.Origin.Z - ray0.Origin.Z;
            matrix.M10 = ray1.Direction.X;
            matrix.M11 = ray1.Direction.Y;
            matrix.M12 = ray1.Direction.Z;
            matrix.M20 = cross.X;
            matrix.M21 = cross.Y;
            matrix.M22 = cross.Z;

            float det0 = matrix.Determinant;

            matrix.M10 = ray0.Direction.X;
            matrix.M11 = ray0.Direction.Y;
            matrix.M12 = ray0.Direction.Z;

            float det1 = matrix.Determinant;

            float s = det0 / denominator;
            float t = det1 / denominator;

            Vector3 point0 = ray0.Origin + (s * ray0.Direction);
            Vector3 point1 = ray1.Origin + (t * ray1.Direction);

            if (!MathHelper.NearEqual(point1.X, point0.X) ||
                !MathHelper.NearEqual(point1.Y, point0.Y) ||
                !MathHelper.NearEqual(point1.Z, point0.Z))
            {
                point = Vector3.Zero;
                return false;
            }

            point = point0;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="plane"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool RayIntersectsPlane(in Ray ray, in Plane plane, out float distance)
        {
            float direction = Vector3.Dot(plane.Normal, ray.Direction);

            if (MathHelper.IsZero(direction))
            {
                distance = 0.0f;
                return false;
            }

            float position = Vector3.Dot(plane.Normal, ray.Origin);
            distance = (-plane.Distance - position) / direction;

            if (distance < 0.0f)
            {
                distance = 0.0f;
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="plane"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool RayIntersectsPlane(in Ray ray, in Plane plane, out Vector3 point)
        {
            if (!RayIntersectsPlane(ray, plane, out float distance))
            {
                point = Vector3.Zero;
                return false;
            }

            point = ray.Origin + (ray.Direction * distance);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="sphere"></param>
        /// <returns></returns>
        public static bool RayIntersectsSphere(in Ray ray, in Sphere sphere, out float distance)
        {
            Vector3.Subtract(ray.Origin, sphere.Center, out Vector3 temp);

            float b = Vector3.Dot(temp, ray.Direction);
            float c = Vector3.Dot(temp, temp) - (sphere.Radius * sphere.Radius);

            if (c > 0.0f && b > 0.0f)
            {
                distance = 0.0f;
                return false;
            }

            float discriminant = b * b - c;

            if (discriminant < 0.0f)
            {
                distance = 0.0f;
                return false;
            }

            distance = -b - MathF.Sqrt(discriminant);
            if (distance < 0.0f)
            {
                distance = 0.0f;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="sphere"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool RayIntersectsSphere(in Ray ray, in Sphere sphere, out Vector3 point)
        {
            if (!RayIntersectsSphere(ray, sphere, out float distance))
            {
                point = Vector3.Zero;
                return false;
            }

            point = ray.Origin + (ray.Direction * distance);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plane0"></param>
        /// <param name="plane1"></param>
        /// <returns></returns>
        public static bool PlaneIntersectsPlane(in Plane plane0, in Plane plane1)
        {
            Vector3.Cross(plane0.Normal, in plane1.Normal, out Vector3 direction);

            float denominator = Vector3.Dot(direction, direction);
            if (MathHelper.IsZero(denominator))
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sphere0"></param>
        /// <param name="sphere1"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static bool SphereIntersectSphere(in Sphere sphere0, in Sphere sphere1)
        {
            float radiisum = sphere0.Radius + sphere1.Radius;
            return Vector3.DistanceSquared(sphere0.Center, sphere1.Center) <= radiisum * radiisum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="box0"></param>
        /// <param name="box1"></param>
        /// <returns></returns>
        public static bool BoxIntersectsBox(in BoundingBox box0, in BoundingBox box1)
        {
            if (box0.Minimum.X > box1.Maximum.X || box1.Minimum.X > box0.Maximum.X)
            {
                return false;
            }

            if (box0.Minimum.Y > box1.Maximum.Y || box1.Minimum.Y > box0.Maximum.Y)
            {
                return false;
            }

            if (box0.Minimum.Z > box1.Maximum.Z || box1.Minimum.Z > box0.Maximum.Z)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="box"></param>
        /// <param name="sphere"></param>
        /// <returns></returns>
        public static bool BoxIntersectsSphere(in BoundingBox box, in Sphere sphere)
        {
            Vector3.Clamp(sphere.Center, box.Minimum, box.Maximum, out Vector3 vector);
            float distance = Vector3.DistanceSquared(sphere.Center, vector);

            return distance <= sphere.Radius * sphere.Radius;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sphere"></param>
        /// <param name="triange"></param>
        /// <returns></returns>
        public static bool SphereIntersectsTriangle(in Sphere sphere, in Triangle triange)
        {
            ClosetPointPointTriangle(sphere.Center, triange, out Vector3 point);
            Vector3.Subtract(point, sphere.Center, out Vector3 result);

            float dot = Vector3.Dot(result, result);
            return dot <= sphere.Radius * sphere.Radius;
        }



    }
}
