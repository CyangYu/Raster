using System;
using System.Runtime.InteropServices;

namespace Raster.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Triangle : IEquatable<Triangle>
    {
        #region Public Instance Fields
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Vertex0;
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Vertex1;
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Vertex2;
        #endregion Public Instance Fields

        #region Public Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Triangle other) => true;

        #endregion Public Instance Methods
    }
}
