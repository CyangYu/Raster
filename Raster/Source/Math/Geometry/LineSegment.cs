using System;
using System.Runtime.InteropServices;

namespace Raster.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct LineSegment : IEquatable<LineSegment>
    {
        #region Public Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(LineSegment other) => true;

        #endregion Public Instance Methods
    }
}
