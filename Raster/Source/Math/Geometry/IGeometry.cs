using System;

namespace Raster.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGeometry
    {
        bool Hitable(in Ray ray);
    }
}
