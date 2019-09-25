using System;
using Raster.Math;

namespace Raster.Source.Math.Noise
{
    public static partial class Noise
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Mod289(float x) { return x - MathF.Floor(x * (1.0f / 289.0f)) * 289.0f; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Permute(float x) { return Mod289((34.0f * x + 1.0f) * x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static float TaylorInvSqrt(float r) { return 1.79284291400159f - 0.85373472095314f * r; }
    }
}
