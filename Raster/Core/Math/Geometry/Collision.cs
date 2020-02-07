using System;
using System.Runtime.CompilerServices;
using Raster.Core.Math;

namespace Raster.Core.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    public static class Collision
    {

        /// <summary>
        ///  
        /// </summary>
        /// <param name="line0"></param>
        /// <param name="line1"></param>
        /// <param name="distance0"></param>
        /// <param name="distance1"></param>
        public static void ClosetPointLineLine(in Line line0, in Line line1, out float distance0, out float distance1)
        {
            Vector3.Subtract(line1.Origin, line0.Origin, out Vector3 sub);

            float dot0 = Vector3.Dot(sub, line1.Direction);
            float dot1 = Vector3.Dot(line1.Direction, line0.Direction);
            float dot2 = Vector3.Dot(line1.Direction, line1.Direction);
            float dot3 = Vector3.Dot(sub, line0.Direction);
            float dot4 = Vector3.Dot(line0.Direction, line0.Direction);

            float denominator = dot4 * dot2 - dot1 * dot1;
            if (!MathHelper.IsZero(denominator))
            {
                distance0 = (dot0 * dot1 - dot3 * dot2) / denominator;
            }
            else
            {
                distance0 = 0.0f;
            }

            distance1 = (dot0 + distance0 * dot1) / dot2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line0"></param>
        /// <param name="line1"></param>
        /// <param name="distance0"></param>
        /// <param name="distance1"></param>
        /// <param name="result"></param>
        public static void ClosetPointLineLine(in Line line0, in Line line1, out float distance0, out float distance1, out Vector3 result)
        {
            ClosetPointLineLine(line0, line1, out distance0, out distance1);
            Line.PointAt(line0, distance0, out result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="segment"></param>
        /// <param name="distance0"></param>
        /// <param name="distance1"></param>
        public static void ClosetPointLineLineSegment(in Line line, in LineSegment segment, out float distance0, out float distance1, out Vector3 result)
        {
            Line line0 = new Line(segment);
            ClosetPointLineLine(line, line0, out distance0, out distance1);

            result = line.Origin + distance0 * line.Direction;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="segment"></param>
        /// <param name="distance0"></param>
        /// <param name="distance1"></param>
        public static void ClosetPointLineSegmentLineSegment(in LineSegment segment0, in LineSegment segment1, out float distance0, out float distance1, out Vector3 result)
        {
            Vector3.Subtract(segment0.End, segment0.Start, out Vector3 direction);

            Line line0 = new Line(segment0);
            Line line1 = new Line(segment1);

            ClosetPointLineLine(line0, line1, out distance0, out distance1);
            if (distance0 >= 0.0f && distance0 <= 1.0f && distance1 > 0.0f && distance1 <= 1.0f)
            {
                LineSegment.PointAt(segment0, distance0, out result);
                return;
            }
            else if (distance0 >= 0.0f && distance0 <= 1.0f)
            {
                if (distance1 < 0.0f)
                {
                    distance1 = 0.0f;
                    ClosetPointPointLineSegment(segment1.Start, segment0, out distance0, out result);
                }
                else
                {
                    distance1 = 1.0f;
                    ClosetPointPointLineSegment(segment1.End, segment1, out distance1, out result);
                }
            }
            else if (distance1 >= 0.0f && distance1 <= 1.0f)
            {
                if (distance0 < 0.0f)
                {
                    distance0 = 0.0f;
                    ClosetPointPointLineSegment(segment0.Start, segment0, out distance1, out result);
                    result = segment0.Start;
                }
                else
                {
                    distance0 = 1.0f;
                    ClosetPointPointLineSegment(segment0.End, segment0, out distance1, out result);
                    result = segment0.End;
                }
            }
            else
            {
                Vector3 point0, point1;

                if (distance0 < 0.0f)
                {
                    point0 = segment0.Start;
                    distance0 = 0.0f;
                }
                else
                {
                    point0 = segment0.End;
                    distance0 = 1.0f;
                }

                if (distance1 < 0.0f)
                {
                    point1 = segment1.Start;
                    distance1 = 0.0f;
                }
                else
                {
                    point1 = segment1.End;
                    distance1 = 1.0f;
                }

                ClosetPointPointLineSegment(point1, segment0, out float temp0, out Vector3 point2);
                ClosetPointPointLineSegment(point0, segment0, out float temp1, out Vector3 point3);

                if (Vector3.Distance(point2, point1) <= Vector3.Distance(point3, point0))
                {
                    distance0 = temp0;
                    result = point2;
                }
                else
                {
                    distance1 = temp1;
                    result = point0;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="box"></param>
        /// <param name="point"></param>
        /// <param name="result"></param>
        public static void ClosetPointPointBox(in Vector3 point, in BoundingBox box, out Vector3 result)
        {
            Vector3.Max(point, box.Minimum, out Vector3 temp);
            Vector3.Min(temp, box.Maximum, out result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="line"></param>
        /// <param name="distance"></param>
        /// <param name="result"></param>
        public static void ClosetPointPointLine(in Vector3 point, in Line line, out float distance, out Vector3 result)
        {
            Vector3.Subtract(point, line.Origin, out Vector3 sub);
            distance = Vector3.Dot(sub, line.Direction);

            result = line.Origin + distance * line.Direction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="segment"></param>
        /// <param name="distance"></param>
        /// <param name="result"></param>
        public static void ClosetPointPointLineSegment(in Vector3 point, in LineSegment segment, out float distance, out Vector3 result)
        {
            Vector3 direction = segment.End - segment.Start;
            distance = Vector3.Dot(point - segment.Start, direction) / direction.LengthSquared;

            distance = MathF.Clamp(distance, 0.0f, 1.0f);
            result = segment.Start + distance * direction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plane"></param>
        /// <param name="point"></param>
        /// <param name="result"></param>
        public static void ClosetPointPointPlane(in Vector3 point, in Plane plane, out Vector3 result)
        {
            float dot = Vector3.Dot(plane.Normal, point);
            float t = dot - plane.Distance;

            result = point - (t * plane.Normal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="ray"></param>
        /// <param name="distance0"></param>
        /// <param name="result"></param>
        public static void ClosetPointPointRay(in Vector3 point, in Ray ray, out float distance, out Vector3 result)
        {
            distance = MathF.Max(Vector3.Dot(point - ray.Origin, ray.Direction), 0.0f);
            Ray.PointAt(ray, distance, out result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sphere"></param>
        /// <param name="point"></param>
        /// <param name="result"></param>
        public static void ClosetPointPointSphere(in Sphere sphere, in Vector3 point, out Vector3 result)
        {
            Vector3.Subtract(point, sphere.Center, out result);
            result.Normalize();

            result.Multiply(sphere.Radius);
            result.Add(sphere.Center);
        }

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

            Vector3.Subtract(point, triangle.Vertex2, out Vector3 edge2);
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
        /// <param name="ray"></param>
        /// <param name="line"></param>
        /// <param name="distance0"></param>
        /// <param name="distance1"></param>
        /// <param name="result"></param>
        public static void ClosetPointRayLine(in Ray ray, in Line line, out float distance0, out float distance1, out Vector3 result)
        {
            Line line0 = new Line(ray);
            ClosetPointLineLine(line, line0, out distance0, out distance1);

            if (distance0 < 0.0f)
            {
                distance0 = 0.0f;
                ClosetPointPointLine(ray.Origin, line, out distance1, out result);

                result = ray.Origin;
            }

            Ray.PointAt(ray, distance0, out result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="segment"></param>
        /// <param name="distance0"></param>
        /// <param name="distance1"></param>
        /// <param name="result"></param>
        public static void ClosetPointRayLineSegment(in Ray ray, in LineSegment segment, out float distance0, out float distance1, out Vector3 result)
        {
            Line line0 = new Line(ray);
            Line line1 = new Line(segment);

            ClosetPointLineLine(line0, line1, out distance0, out distance1);
            if (distance0 < 0.0f)
            {
                distance0 = 0.0f;
                if (distance1 > 0.0f && distance1 <= 1.0f)
                {
                    ClosetPointPointLineSegment(ray.Origin, segment, out distance0, out result);
                    result = ray.Origin;
                    return;
                }

                float temp = 0.0f;
                if (distance1 < 0.0f)
                {
                    result = segment.Start;
                    temp = 0.0f;
                }
                else
                {
                    result = segment.End;
                    temp = 1.0f;
                }

                ClosetPointPointRay(result, ray, out distance0, out Vector3 point0);
                ClosetPointPointLineSegment(ray.Origin, segment, out distance1, out Vector3 point1);

                if (Vector3.DistanceSquared(point0, result) <= Vector3.DistanceSquared(point1, ray.Origin))
                {
                    distance1 = temp;
                    result = point0;
                }
                else
                {
                    distance0 = 0.0f;
                    result = ray.Origin;
                }
            }
            else if (distance1 < 0.0f)
            {
                distance1 = 0.0f;
                ClosetPointPointRay(segment.Start, ray, out distance0, out result);
            }
            else if (distance1 > 1.0f)
            {
                distance1 = 1.0f;
                ClosetPointPointRay(segment.End, ray, out distance0, out result);
            }
            else
            {
                result = ray.Origin + distance0 * ray.Direction;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray0"></param>
        /// <param name="ray1"></param>
        /// <param name="distance0"></param>
        /// <param name="distance1"></param>
        /// <param name="result"></param>
        public static void ClosetPointRayRay(in Ray ray0, in Ray ray1, out float distance0, out float distance1, out Vector3 result)
        {
            Line line0 = new Line(ray0);
            Line line1 = new Line(ray1);

            ClosetPointLineLine(line0, line1, out distance0, out distance1);
            if (distance0 < 0.0f && distance1 < 0.0f)
            {
                ClosetPointPointRay(ray1.Origin, ray0, out distance0, out Vector3 point0);
                ClosetPointPointRay(ray0.Origin, ray1, out distance1, out Vector3 point1);

                if (Vector3.DistanceSquared(point0, ray1.Origin) <= Vector3.DistanceSquared(point1, ray0.Origin))
                {
                    distance1 = 0.0f;
                    result = point0;
                }
                else
                {
                    distance0 = 0.0f;
                    result = ray0.Origin;
                }
            }
            else if (distance0 < 0.0f)
            {
                distance0 = 0.0f;
                ClosetPointPointRay(ray0.Origin, ray1, out distance1, out result);
                distance1 = MathF.Max(0.0f, distance1);

                result = ray0.Origin;
            }
            else if (distance1 < 0.0f)
            {
                ClosetPointPointRay(ray1.Origin, ray0, out distance0, out result);
                distance0 = MathF.Max(0.0f, distance0);
                distance1 = 0.0f;
            }
            else
            {
                result = ray0.Origin + distance0 * ray0.Direction;
            }
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
        /// <param name="box"></param>
        /// <param name="point"></param>
        /// <returns></returns>
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
        /// <param name="line"></param>
        /// <param name="capsule"></param>
        /// <returns></returns>
        public static float DistanceLineCapsule(in Line line, in Capsule capsule)
        {
            float d = DistanceLineLineSegment(line, capsule.Segment, out float distance0, out float distance1);
            return MathF.Max(0.0f, d - capsule.Radius);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line0"></param>
        /// <param name="line1"></param>
        /// <param name="distance0"></param>
        /// <param name="distance1"></param>
        /// <returns></returns>
        public static float DistanceLineLine(in Line line0, in Line line1, out float distance0, out float distance1)
        {
            ClosetPointLineLine(line0, line1, out distance0, out distance1, out Vector3 point0);
            Line.PointAt(line1, distance1, out Vector3 point1);

            return Vector3.Distance(point0, point1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="segment"></param>
        /// <param name="distance0"></param>
        /// <param name="distance1"></param>
        /// <returns></returns>
        public static float DistanceLineLineSegment(in Line line, in LineSegment segment, out float distance0, out float distance1)
        {
            ClosetPointLineLineSegment(line, segment, out distance0, out distance1, out Vector3 point0);
            LineSegment.PointAt(segment, distance1, out Vector3 point1);

            return Vector3.Distance(point0, point1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="point"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static float DistanceLinePoint(in Line line, in Vector3 point, out float distance)
        {
            ClosetPointPointLine(point, line, out distance, out Vector3 result);
            return Vector3.Distance(point, result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="sphere"></param>
        /// <returns></returns>
        public static float DistanceLineSphere(in Line line, in Sphere sphere)
        {
            float d = DistanceLinePoint(line, sphere.Center, out float distance);
            return MathF.Max(0.0f, d - sphere.Radius);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="capsule"></param>
        /// <returns></returns>
        public static float DistanceLineSegmentCapsule(in LineSegment segment, in Capsule capsule)
        {
            float d = DistanceLineSegmentLineSegment(segment, capsule.Segment, out float distance0, out float distance1);
            return MathF.Max(0.0f, d - capsule.Radius);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment0"></param>
        /// <param name="segment1"></param>
        /// <param name="distance0"></param>
        /// <param name="distance1"></param>
        /// <returns></returns>
        public static float DistanceLineSegmentLineSegment(in LineSegment segment0, in LineSegment segment1, out float distance0, out float distance1)
        {
            ClosetPointLineSegmentLineSegment(segment0, segment1, out distance0, out distance1, out Vector3 result);
            LineSegment.PointAt(segment0, distance0, out Vector3 point0);
            LineSegment.PointAt(segment1, distance1, out Vector3 point1);

            return Vector3.Distance(point0, point1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="plane"></param>
        /// <returns></returns>
        public static float DistanceLineSegmentPlane(in LineSegment segment, in Plane plane)
        {
            float distance0 = Plane.SignedDistance(plane, segment.Start);
            float distance1 = Plane.SignedDistance(plane, segment.End);
            
            if (distance0 * distance1 < 0.0f)
            {
                return 0.0f;
            }

            return MathF.Min(MathF.Abs(distance0), MathF.Abs(distance1));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="point"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static float DistanceLineSegmentPoint(in LineSegment segment, in Vector3 point, out float distance)
        {
            ClosetPointPointLineSegment(point, segment, out distance, out Vector3 result);
            return Vector3.Distance(result, point);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="sphere"></param>
        /// <returns></returns>
        public static float DistanceLineSegmentSphere(in LineSegment segment, in Sphere sphere)
        {
            float d = DistanceLineSegmentPoint(segment, sphere.Center, out float distance);
            return MathF.Max(0.0f, d - sphere.Radius);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="capsule"></param>
        /// <returns></returns>
        public static float DistanceRayCapsule(in Ray ray, in Capsule capsule)
        {
            float distance = DistanceRayLineSegment(ray, capsule.Segment, out float distance0, out float distance1);
            return MathF.Max(0.0f, distance - capsule.Radius);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="line"></param>
        /// <param name="distance0"></param>
        /// <param name="distance1"></param>
        /// <returns></returns>
        public static float DistanceRayLine(in Ray ray, in Line line, out float distance0, out float distance1)
        {
            ClosetPointRayLine(ray, line, out distance0, out distance1, out Vector3 point0);
            Line.PointAt(line, distance1, out Vector3 point1);

            return Vector3.Distance(point0, point1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="segment"></param>
        /// <param name="distance0"></param>
        /// <param name="distance1"></param>
        /// <returns></returns>
        public static float DistanceRayLineSegment(in Ray ray, in LineSegment segment, out float distance0, out float distance1)
        {
            ClosetPointRayLineSegment(ray, segment, out distance0, out distance1, out Vector3 point0);
            LineSegment.PointAt(segment, distance1, out Vector3 point1);

            return Vector3.Distance(point0, point1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="point"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static float DistanceRayPoint(in Ray ray, in Vector3 point, out float distance)
        {
            ClosetPointPointRay(point, ray, out distance, out Vector3 result);
            return Vector3.Distance(result, point);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray0"></param>
        /// <param name="ray1"></param>
        /// <param name="distance0"></param>
        /// <param name="distance1"></param>
        /// <returns></returns>
        public static float DistanceRayRay(in Ray ray0, in Ray ray1, out float distance0, out float distance1)
        {
            ClosetPointRayRay(ray0, ray1, out distance0, out distance1, out Vector3 point0);
            Ray.PointAt(ray0, distance1, out Vector3 point1);

            return Vector3.Distance(point0, point1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="sphere"></param>
        /// <returns></returns>
        public static float DistanceRaySphere(in Ray ray, in Sphere sphere)
        {
            float distance = DistanceRayPoint(ray, sphere.Center, out float distance0);
            return MathF.Max(0.0f, distance - sphere.Radius);
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
        /// <param name="capsule"></param>
        /// <returns></returns>
        public static bool RayIntersectsCapsule(in Ray ray, in Capsule capsule)
        {
            float distance = DistanceRayLineSegment(ray, capsule.Segment, out float distance0, out float distance1);
            return distance <= capsule.Radius;
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
        public static bool RayIntersectsPlane(in Ray ray, in Plane plane, out float distance, out Vector3 point)
        {
            if (!RayIntersectsPlane(ray, plane, out distance))
            {
                point = Vector3.Zero;
                return false;
            }

            Ray.PointAt(ray, distance, out point);
            return true;
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
        /// <param name="box"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool RayIntersectsBox(in Ray ray, in BoundingBox box, out float distance)
        {
            distance = 0.0f;
            float tmax = float.MaxValue;

            if (MathHelper.IsZero(ray.Direction.X))
            {
                if (ray.Origin.X < box.Minimum.X || ray.Origin.X > box.Maximum.X)
                {
                    distance = 0.0f;
                    return false;
                }
            }
            else
            {
                float inverse = 1.0f / ray.Direction.X;
                float t1 = (box.Minimum.X - ray.Origin.X) * inverse;
                float t2 = (box.Maximum.X - ray.Origin.X) * inverse;

                if (t1 > t2)
                {
                    float temp = t1;
                    t1 = t2;
                    t2 = temp;
                }

                distance = MathF.Max(t1, distance);
                tmax = MathF.Min(t2, tmax);

                if (distance > tmax)
                {
                    distance = 0.0f;
                    return false;
                }
            }

            if (MathHelper.IsZero(ray.Direction.Y))
            {
                if (ray.Origin.Y < box.Minimum.Y || ray.Origin.Y > box.Maximum.Y)
                {
                    distance = 0.0f;
                    return false;
                }
            }
            else
            {
                float inverse = 1.0f / ray.Direction.Y;
                float t1 = (box.Minimum.Y - ray.Origin.Y) * inverse;
                float t2 = (box.Maximum.Y - ray.Origin.Y) * inverse;

                if (t1 > t2)
                {
                    float temp = t1;
                    t1 = t2;
                    t2 = temp;
                }

                distance = MathF.Max(t1, distance);
                tmax = MathF.Max(t2, tmax);

                if (distance > tmax)
                {
                    distance = 0.0f;
                    return false;
                }
            }

            if (MathHelper.IsZero(ray.Direction.Z))
            {
                if (ray.Origin.Z < box.Minimum.Z || ray.Origin.Z > box.Maximum.Z)
                {
                    distance = 0.0f;
                    return false;
                }
            }
            else
            {
                float inverse = 1.0f / ray.Direction.Z;
                float t1 = (box.Minimum.Z - ray.Origin.Z) * inverse;
                float t2 = (box.Maximum.Z - ray.Origin.Z) * inverse;

                if (t1 > t2)
                {
                    float temp = t1;
                    t1 = t2;
                    t2 = temp;
                }

                distance = MathF.Max(t1, distance);
                tmax = MathF.Min(t2, tmax);

                if (distance > tmax)
                {
                    distance = 0.0f;
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="box"></param>
        /// <param name="distance"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool RayIntersectsBox(in Ray ray, in BoundingBox box, out float distance, out Vector3 point)
        {
            if (!RayIntersectsBox(ray, box, out distance))
            {
                point = Vector3.Zero;
                return false;
            }

            Ray.PointAt(ray, distance, out point);
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
        public static bool RayIntersectsSphere(in Ray ray, in Sphere sphere, out float distance, out Vector3 point)
        {
            if (!RayIntersectsSphere(ray, sphere, out distance))
            {
                point = Vector3.Zero;
                return false;
            }

            Ray.PointAt(ray, distance, out point);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="triange"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool RayIntersectsTriangle(in Ray ray, in Triangle triange, out float distance)
        {
            Vector3.Subtract(triange.Vertex1, triange.Vertex0, out Vector3 edge0);
            Vector3.Subtract(triange.Vertex2, triange.Vertex0, out Vector3 edge1);

            Vector3 directionCrossEdge2;
            directionCrossEdge2.X = (ray.Direction.Y * edge1.Z) - (ray.Direction.Z * edge1.Y);
            directionCrossEdge2.Y = (ray.Direction.Z * edge1.X) - (ray.Direction.X * edge1.Z);
            directionCrossEdge2.Z = (ray.Direction.X * edge1.Y) - (ray.Direction.Y * edge1.X);

            float determinant = (edge0.X * directionCrossEdge2.X) + (edge0.Y * directionCrossEdge2.Y) +
                (edge0.Z * directionCrossEdge2.Z);

            if (MathHelper.IsZero(determinant))
            {
                distance = 0.0f;
                return false;
            }

            float inverseDeterminant = 1.0f / determinant;

            Vector3 distanceVector;
            distanceVector.X = ray.Origin.X - triange.Vertex0.X;
            distanceVector.Y = ray.Origin.Y - triange.Vertex0.Y;
            distanceVector.Z = ray.Origin.Z - triange.Vertex0.Z;

            float triangleU = (distanceVector.X * directionCrossEdge2.X) + (distanceVector.Y * directionCrossEdge2.Y) +
                              (distanceVector.Z * directionCrossEdge2.Z);
            triangleU *= inverseDeterminant;

            if (triangleU < 0.0f || triangleU > 1.0f)
            {
                distance = 0.0f;
                return false;
            }

            Vector3 distanceCrossEdge1;
            distanceCrossEdge1.X = (distanceVector.Y * edge0.Z) - (distanceVector.Z * edge0.Y);
            distanceCrossEdge1.Y = (distanceVector.Z * edge0.X) - (distanceVector.X * edge0.Z);
            distanceCrossEdge1.Z = (distanceVector.X * edge0.Y) - (distanceVector.Y * edge0.X);

            float triangleV = (ray.Direction.X * distanceCrossEdge1.X) + (ray.Direction.Y * distanceCrossEdge1.Y) +
                              (ray.Direction.Z * distanceCrossEdge1.Z);
            triangleV *= inverseDeterminant;

            if (triangleV < 0.0f || triangleU + triangleV > 1.0f)
            {
                distance = 0.0f;
                return false;
            }

            float rayDistance = (edge1.X * distanceCrossEdge1.X) + (edge1.Y * distanceCrossEdge1.Y) +
                                (edge1.Z * distanceCrossEdge1.Z);
            rayDistance *= inverseDeterminant;

            if (rayDistance < 0.0f)
            {
                distance = 0.0f;
                return false;
            }

            distance = rayDistance;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="triangle"></param>
        /// <param name="distance"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool RayIntersectsTriangle(in Ray ray, in Triangle triangle, out float distance, out Vector3 point)
        {
            if (!RayIntersectsTriangle(ray, triangle, out distance))
            {
                point = Vector3.Zero;
                return false;
            }

            Ray.PointAt(ray, distance, out point);
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
