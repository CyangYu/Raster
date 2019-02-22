using System;
using System.Runtime.CompilerServices;
using Raster.Math;

namespace Raster.Math.Geometry
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
        public Plane(Vector4 vec4)
            : this(vec4.X, vec4.Y, vec4.Z, vec4.W)
        {
        }

        public Plane(Vector3 normal, float d)
            : this(normal.X, normal.Y, normal.Z, d)
        {
        }

        public Plane(float x, float y, float z, float d)
        {
            Normal.X = x;
            Normal.Y = y;
            Normal.Z = z;
            Distance = d;
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

        #endregion Public Instance Methods

        #region Public Static Methods

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
            Plane result;
            FromVertices(point1, point2, point3, out result);
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
            Plane result;
            Normalize(value, out result);
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
            Plane result;
            Transform(plane, matrix, out result);
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
            Plane result;
            Transform(plane, rotation, out result);
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