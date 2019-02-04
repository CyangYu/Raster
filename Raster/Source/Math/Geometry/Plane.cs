using System;
using System.Runtime.CompilerServices;

namespace Raster.Math.Geometry
{
    [Serializable]
    public struct Plane : IGeometry, IEquatable<Plane>
    {
        #region Public Fields
        public Vector3 Normal;
        public float Distance;
        #endregion

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
            Normal = new Vector3(x, y, z);
            Distance = d;
        }
        #endregion Constructor

        /// <summary>
        /// Transforms a normalized Plane by a Matrix
        /// </summary>
        /// <param name="plane"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Plane Transform(Plane plane, Matrix4x4 matrix)
        {
            return default(Plane);
        }

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
        public override string ToString() => 
            string.Format("Plane: Normal X = {0}, Y = {1}, Z = {2} Distance = {3}", 
                          Normal.X, Normal.Y, Normal.Z, Distance);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Plane other) => this == other;
    }
}
