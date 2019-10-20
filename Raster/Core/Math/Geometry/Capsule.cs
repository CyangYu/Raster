using System;
using System.Runtime.CompilerServices;

namespace Raster.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    public struct Capsule : IEquatable<Capsule>
    {
        #region Public Instance Fields
        /// <summary>
        /// 
        /// </summary>
        public LineSegment Segment;
        /// <summary>
        /// 
        /// </summary>
        public float Radius;
        #endregion Public Instance Fields

        #region Public Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Capsule)
            {
                return Equals((Capsule)obj);
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
            return string.Format("Capsule: Segment = {}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Capsule other)
        {
            return this.Segment == other.Segment &&
                   this.Radius == other.Radius;
        }

        #endregion Public Instance Methods
    }
}
