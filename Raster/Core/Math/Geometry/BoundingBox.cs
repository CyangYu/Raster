﻿using System;
using Raster.Core.Math;

namespace Raster.Core.Math.Geometry
{
    /// <summary>
    /// Axis-Aligned Bounding Box
    /// </summary>
    [Serializable]
    public struct BoundingBox : IEquatable<BoundingBox>
    {
        #region Public Fields
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Minimum;
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Maximum;
        #endregion Public Fields

        #region Constructor
        public BoundingBox(in BoundingBox other)
            : this(other.Minimum, other.Maximum)
        {
        }

        public BoundingBox(in Vector3 minimum, in Vector3 maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }
		
		public BoundingBox(float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
		{
			Minimum = new Vector3(xMin, yMin, zMin);
			Maximum = new Vector3(xMax, yMax, zMax);
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
            if (obj is BoundingBox)
            {
                return Equals((BoundingBox)obj);
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
            return string.Format("BoundingBox: XMin = {0}, YMin = {1}, ZMin = {2}, XMax = {3}, YMax = {4}, ZMax = {5}",
                                 Minimum.X, Minimum.Y, Minimum.Z, Maximum.X, Maximum.Y, Maximum.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(BoundingBox other)
        {
            return true;
        }

        #endregion Public Instance Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in BoundingBox left, in BoundingBox right)
        {
            return left.Minimum == right.Minimum &&
                   left.Maximum == right.Maximum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in BoundingBox left, in BoundingBox right)
        {
            return left.Minimum != right.Minimum ||
                   left.Maximum != right.Maximum;
        }

        #endregion Operator Overload
    }
}
