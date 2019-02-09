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
        public static bool RayIntersectSphere(in Ray ray, in Sphere sphere, out float distance)
        {
            Vector3 vec3;
            Vector3.Subtract(ray.Origin, sphere.Center, out vec3);

            float a = Vector3.Dot(ray.Direction, ray.Direction);
            float b = Vector3.Dot(vec3, ray.Direction);
            float c = Vector3.Dot(vec3, vec3) - (sphere.Radius * sphere.Radius);

            float discriminant = b * b - 4.0f * a * c;
            return (discriminant - 0.0f) > MathF.Epsilon;
        }
    }
}
