using System;
using System.Runtime.CompilerServices;
using Raster.Math;

namespace Raster.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    public static class Collision
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="sphere"></param>
        /// <returns></returns>
        public static bool RayIntersectSphere(in Ray ray, in Sphere sphere)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sphere0"></param>
        /// <param name="sphere1"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static bool SphereIntersectSphere(in Sphere sphere0, in Sphere sphere1, float tolerance = 0.000001f)
        { 
             return Vector3.DistanceSquared(sphere0.Center, sphere1.Center) <= 
                    MathHelper.Square(MathF.Max(0.0f, sphere0.Radius + sphere1.Radius + tolerance));
        }
    }
}
