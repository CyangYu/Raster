using System;

namespace Raster.Math.Geometry
{
    public interface IHitable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <returns></returns>
        bool Hit(in Ray ray);
    }
}
