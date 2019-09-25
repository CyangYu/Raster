using System;
using System.Runtime.CompilerServices;

namespace Raster.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    public struct HitInfo
    {
        #region Public Instance Fields
        /// <summary>
        /// Specifies the result of the intersection test
        /// </summary>
        public HitResult Result;
        /// <summary>
        /// Stores the point of intersection
        /// </summary>
        public Vector3 Point;
        /// <summary>
        /// Specifies the surface normal of the 'this' object at the point of intersection.
        /// </summary>
        public Vector3 NormalA;
        /// <summary>
        /// Specifies the surface normal of the other object at the point of intersection.
        /// </summary>
        public Vector3 NormalB;
        #endregion Public Instance Fields

        #region Constructor
        public HitInfo(HitResult result, in Vector3 point, in Vector3 normalA, in Vector3 normalB)
        {
            Result  = result;
            Point   = point;
            NormalA = normalA;
            NormalB = normalB;
        }

        #endregion Constructor
    }
}
