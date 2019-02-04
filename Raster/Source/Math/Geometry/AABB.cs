using System;
using Raster.Math;

namespace Raster.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct AABB : IEquatable<AABB>
    {
        #region Public Fields
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Min;
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Max;
        #endregion Public Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Center 
		{
			get {
				return new Vector3((Max.X - Min.X) / 2.0f + Min.X,
							       (Max.Y - Min.Y) / 2.0f + Min.Y,
							       (Max.Z - Min.Z) / 2.0f + Min.Z);
			}
		}

        #region Constructor
        public AABB(Vector3 min, Vector3 max)
        {
            Min = min;
            Max = max;
        }
		
		public AABB(float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
		{
			Min = new Vector3(xMin, yMin, zMin);
			Max = new Vector3(xMax, yMax, zMax);
		}
        #endregion

        #region Public Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is AABB)
            {
                return Equals((AABB)obj);
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
        public override string ToString() =>
            string.Format("AABB XMin = {0}, YMin = {1}, ZMin = {2}, XMax = {3}, YMax = {4}, ZMax = {5}",
                          Min.X, Min.Y, Min.Z, Max.X, Max.Y, Max.Z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(AABB other) => this == other;

        #endregion Public Instance Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in AABB left, in AABB right) =>
            left.Min.X == right.Min.X && left.Min.Y == right.Min.Y && left.Min.Z == right.Min.Z &&
            left.Max.X == right.Max.X && left.Max.Y == right.Max.Y && left.Max.Z == right.Max.Z;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in AABB left, in AABB right) =>
            left.Min.X != right.Min.X || left.Min.Y != right.Min.Y || left.Min.Z != right.Min.Z ||
            left.Max.X != right.Max.X || left.Max.Y != right.Max.Y || left.Max.Z != right.Max.Z;

        #endregion
    }
}
