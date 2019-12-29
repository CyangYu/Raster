using System;
using System.Runtime.InteropServices;

namespace Raster.Core.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Polygon : IEquatable<Polygon>
    {
        #region Public Instance Methods
        public bool Equals(Polygon polygon)
        {
            return true;
        }
        #endregion Public Instance Methods
    }
}
