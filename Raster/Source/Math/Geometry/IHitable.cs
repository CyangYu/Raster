using System;

namespace Raster.Math.Geometry
{
    public interface IHitable
    {
        bool Hit(in Ray ray);
    }
}
