using System;

namespace Raster.Core.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    public enum HitResult : byte
    {
        NoHit     = 0x00,
        Intersect = 0x01,
        AInsideB  = 0x02,
        BInsideA  = 0x03
    }
}
