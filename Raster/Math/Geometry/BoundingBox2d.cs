using System;

namespace Raster.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    public struct BoundingBox2d : IEquatable<BoundingBox2d>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is BoundingBox2d)
            {
                return Equals((BoundingBox2d)obj);
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
            return string.Format("BoundingBox2d: ");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(BoundingBox2d other) => true;
    }
}
