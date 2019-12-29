using System;
using System.Runtime.CompilerServices;
using Raster.Core.Math;

namespace Raster.Core.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct Plane : IEquatable<Plane>
    {
        #region Public Fields
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Normal;
        /// <summary>
        /// 
        /// </summary>
        public float Distance;
        #endregion

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public static readonly Plane Zero = new Plane(0.0f, 0.0f, 0.0f, 0.0f);

        #endregion Public Instance Properties

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="d"></param>
        public Plane(float x, float y, float z, float d)
        {
            Normal.X = x;
            Normal.Y = y;
            Normal.Z = z;
            Distance = d;

            Normal.Normalize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec4"></param>
        public Plane(Vector4 vec4)
            : this(vec4.X, vec4.Y, vec4.Z, vec4.W)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="normal"></param>
        /// <param name="d"></param>
        public Plane(in Vector3 normal, float d)
            : this(normal.X, normal.Y, normal.Z, d)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="normal"></param>
        public Plane(in Vector3 point, in Vector3 normal)
        {
            Normal = normal;
            Distance = Vector3.Dot(point, normal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point0"></param>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        public Plane(in Vector3 point0, in Vector3 point1, in Vector3 point2)
        {
            float x0 = point1.X - point0.X;
            float y0 = point1.Y - point0.Y;
            float z0 = point1.Z - point0.Z;

            float x1 = point2.X - point0.X;
            float y1 = point2.Y - point0.Y;
            float z1 = point2.Z - point0.Z;

            float yz = (y0 * z1) - (z0 * y1);
            float xz = (z0 * x1) - (x0 * z1);
            float xy = (x0 * y1) - (y0 * x1);

            float invPyth = MathHelper.FastSqrtInverse((yz * yz) + (xz * xz) + (xy * xy));

            Normal.X = yz * invPyth;
            Normal.Y = xz * invPyth;
            Normal.Z = xy * invPyth;

            Distance = -((Normal.X * point0.X) + (Normal.Y * point0.Y) + (Normal.Z * point0.Z));
        }

        #endregion Constructor

        #region Public Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if (obj is Plane)
            {
                return Equals((Plane)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            return Normal.GetHashCode() ^ Distance.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Plane: Normal X = {0}, Y = {1}, Z = {2} Distance = {3}",
                          Normal.X, Normal.Y, Normal.Z, Distance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Plane other) => this == other;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <returns></returns>
        public bool Intersects(in Ray ray)
        {
            return Collision.RayIntersectsPlane(ray, this, out float distance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public bool Intersects(in Ray ray, out float distance)
        {
            return Collision.RayIntersectsPlane(ray, this, out distance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool Intersects(in Ray ray, out Vector3 point)
        {
            return Collision.RayIntersectsPlane(ray, this, out float distance, out point);
        }

        public bool Intersects(in Plane plane)
        {
            return Collision.PlaneIntersectsPlane(this, plane);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        public void Reflection(out Matrix4x4 result)
        {
            float x = this.Normal.X;
            float y = this.Normal.Y;
            float z = this.Normal.Z;
            float x2 = -2.0f * x;
            float y2 = -2.0f * y;
            float z2 = -2.0f * z;

            result.M00 = (x2 * x) + 1.0f;
            result.M01 = y2 * x;
            result.M02 = z2 * x;
            result.M03 = 0.0f;

            result.M10 = x2 * y;
            result.M11 = (y2 * y) + 1.0f;
            result.M12 = z2 * y;
            result.M13 = 0.0f;

            result.M20 = x2 * z;
            result.M21 = y2 * z;
            result.M22 = (z2 * z) + 1.0f;
            result.M23 = 0.0f;

            result.M30 = x2 * this.Distance;
            result.M31 = y2 * this.Distance;
            result.M32 = z2 * this.Distance;
            result.M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Matrix4x4 Reflection()
        {
            Reflection(out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lightDirection"></param>
        /// <param name="result"></param>
        public void Shadow(in Vector4 lightDirection, out Matrix4x4 result)
        {
            float dot = (this.Normal.X * lightDirection.X) + (this.Normal.Y * lightDirection.Y) +
                        (this.Normal.Z * lightDirection.Z) + (this.Distance * lightDirection.W);

            float x = -this.Normal.X;
            float y = -this.Normal.Y;
            float z = -this.Normal.Z;
            float d = -this.Distance;

            result.M00 = (x * lightDirection.X) + dot;
            result.M10 = y * lightDirection.X;
            result.M20 = z * lightDirection.X;
            result.M30 = d * lightDirection.X;

            result.M01 = x * lightDirection.Y;
            result.M11 = (y * lightDirection.Y) + dot;
            result.M21 = z * lightDirection.Y;
            result.M31 = d * lightDirection.Y;

            result.M02 = x * lightDirection.Z;
            result.M12 = y * lightDirection.Z;
            result.M22 = (z * lightDirection.Z) + dot;
            result.M32 = d * lightDirection.Z;

            result.M03 = x * lightDirection.W;
            result.M13 = y * lightDirection.W;
            result.M23 = z * lightDirection.W;
            result.M33 = (d * lightDirection.W) + dot;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lightDirection"></param>
        /// <returns></returns>
        public Matrix4x4 Shadow(in Vector4 lightDirection)
        {
            Shadow(lightDirection, out Matrix4x4 result);
            return result;
        }

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plane"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static float SignedDistance(in Plane plane, in Vector3 point)
        {
            return Vector3.Dot(plane.Normal, point) - plane.Distance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plane"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(in Plane plane, in Vector4 value)
        {
            return plane.Normal.X * value.X +
                   plane.Normal.Y + value.Y +
                   plane.Normal.Z * value.Z +
                   plane.Distance * value.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plane"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DotCoordinate(in Plane plane, in Vector4 value)
        {
            return plane.Normal.X * value.X +
                   plane.Normal.Y + value.Y +
                   plane.Normal.Z * value.Z +
                   plane.Distance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plane"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DotNormal(in Plane plane, in Vector4 value)
        {
            return plane.Normal.X * value.X +
                   plane.Normal.Y + value.Y +
                   plane.Normal.Z * value.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="point3"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Plane FromVertices(in Vector3 point1, in Vector3 point2, in Vector3 point3)
        {
            FromVertices(point1, point2, point3, out Plane result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Plane Normalize(in Plane value)
        {
            Normalize(value, out Plane result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lightDirection"></param>
        /// <param name="plane"></param>
        /// <returns></returns>
        public static Matrix3x3 Shadow(in Vector4 lightDirection, in Plane plane)
        {
            Shadow(lightDirection, plane, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plane"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Plane Transform(in Plane plane, in Matrix4x4 matrix)
        {
            Transform(plane, matrix, out Plane result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plane"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Plane Transform(in Plane plane, in Quaternion rotation)
        {
            Transform(plane, rotation, out Plane result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="point3"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FromVertices(in Vector3 point1, in Vector3 point2, in Vector3 point3, out Plane result)
        {
            float ax = point2.X - point1.X;
            float ay = point2.Y - point1.Y;
            float az = point2.Z - point1.Z;

            float bx = point3.X - point1.X;
            float by = point3.Y - point1.Y;
            float bz = point3.Z - point1.Z;

            float nx = ay * bz - az * by;
            float ny = az * bx - ax * bz;
            float nz = ax * by - ay * bx;

            float lenSqr = nx * nx + ny * ny + nz * nz;

            if (lenSqr != 0.0f)
            {
                float invNorm = MathHelper.FastSqrtInverse(lenSqr);

                result.Normal.X = nx * invNorm;
                result.Normal.Y = ny * invNorm;
                result.Normal.Z = nz * invNorm;
                result.Distance = -(result.Normal.X * point1.X + result.Normal.Y * point1.Y +
                                    result.Normal.Z * point1.Z);
            }
            else
            {
                result = Zero;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Normalize(in Plane value, out Plane result)
        {
            float lenSqr = value.Normal.X * value.Normal.X + 
                           value.Normal.Y * value.Normal.Y + 
                           value.Normal.Z * value.Normal.Z;

            if (MathF.Abs(lenSqr - 1.0f) < MathF.Epsilon)
            {
                result = value;
            }

            float lenInv = 1.0f / MathF.Sqrt(lenSqr);

            result.Normal.X = value.Normal.X * lenInv;
            result.Normal.Y = value.Normal.Y * lenInv;
            result.Normal.Z = value.Normal.Z * lenInv;
            result.Distance = value.Distance * lenInv;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lightDirection"></param>
        /// <param name="plane"></param>
        /// <param name="result"></param>
        public static void Shadow(in Vector4 lightDirection, in Plane plane, out Matrix3x3 result)
        {
            float dot = (plane.Normal.X * lightDirection.X) + (plane.Normal.Y * lightDirection.Y) +
                        (plane.Normal.Z * lightDirection.Z) + (plane.Distance * lightDirection.W);

            float x = -plane.Normal.X;
            float y = -plane.Normal.Y;
            float z = -plane.Normal.Z;
            float d = -plane.Distance;

            result.M00 = (x * lightDirection.X) + dot;
            result.M10 = y * lightDirection.X;
            result.M20 = z * lightDirection.X;

            result.M01 = x * lightDirection.Y;
            result.M11 = (y * lightDirection.Y) + dot;
            result.M21 = z * lightDirection.Y;

            result.M02 = x * lightDirection.Z;
            result.M12 = y * lightDirection.Z;
            result.M22 = (z * lightDirection.Z) + dot;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plane"></param>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Transform(in Plane plane, in Matrix4x4 matrix, out Plane result)
        {
            Matrix4x4 m = new Matrix4x4(0.0f);

            result.Normal.X = plane.Normal.X * m.M00 + plane.Normal.Y * m.M01 +
                              plane.Normal.Z * m.M02 + plane.Distance * m.M03;
            result.Normal.Y = plane.Normal.X * m.M10 + plane.Normal.Y * m.M11 +
                              plane.Normal.Z * m.M12 + plane.Distance * m.M13;
            result.Normal.Z = plane.Normal.X * m.M20 + plane.Normal.Y * m.M21 +
                              plane.Normal.Z * m.M22 + plane.Distance * m.M23;
            result.Distance = plane.Normal.X * m.M30 + plane.Normal.Y * m.M31 +
                              plane.Normal.Z * m.M32 + plane.Distance * m.M33;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plane"></param>
        /// <param name="rotation"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Transform(in Plane plane, in Quaternion rotation, out Plane result)
        {
            // Compute rotation matrix
            float x2 = rotation.X + rotation.X;
            float y2 = rotation.Y + rotation.Y;
            float z2 = rotation.Z + rotation.Z;

            float wx2 = rotation.W * x2;
            float wy2 = rotation.W * y2;
            float wz2 = rotation.W * z2;
            float xx2 = rotation.X * x2;
            float xy2 = rotation.X * y2;
            float xz2 = rotation.X * z2;
            float yy2 = rotation.Y * y2;
            float yz2 = rotation.Y * z2;
            float zz2 = rotation.Z * z2;

            float m11 = 1.0f - yy2 - zz2;
            float m21 = xy2 - wz2;
            float m31 = xz2 + wy2;

            float m12 = xy2 + wz2;
            float m22 = 1.0f - xx2 - zz2;
            float m32 = yz2 - wx2;

            float m13 = xz2 - wy2;
            float m23 = yz2 + wx2;
            float m33 = 1.0f - xx2 - yy2;

            result.Normal.X = plane.Normal.X * m11 + plane.Normal.Y * m21 + plane.Normal.Z * m31;
            result.Normal.Y = plane.Normal.X * m12 + plane.Normal.Y * m22 + plane.Normal.Z * m32;
            result.Normal.Z = plane.Normal.X * m13 + plane.Normal.Y * m23 + plane.Normal.Z * m33;
            result.Distance = plane.Distance;
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
        public static bool operator ==(in Plane left, in Plane right)
        {
            return (left.Normal.X == right.Normal.X &&
                    left.Normal.Y == right.Normal.Y &&
                    left.Normal.Y == right.Normal.Z &&
                    left.Distance == right.Distance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(in Plane left, in Plane right)
        {
            return (left.Normal.X != right.Normal.X ||
                    left.Normal.Y != right.Normal.Y ||
                    left.Normal.Y != right.Normal.Z ||
                    left.Distance != right.Distance);
        }
        
        #endregion Operator Overload
    }
}