using System;
using System.Runtime.CompilerServices;
using Raster.Core.Math;

namespace Raster.Core.Math.Noise
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
        public static Vector2 Mod289(in Vector2 x) { return x - MathF.Floor(x * (1.0f / 289.0f)) * 289.0f; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 Mod289(in Vector3 x) { return x - MathF.Floor(x * (1.0f / 289.0f)) * 289.0f; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector4 Mod289(in Vector4 x) { return x - MathF.Floor(x * (1.0f / 289.0f)) * 289.0f; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 Mod7(in Vector3 x) { return x - MathF.Floor(x * (1.0f / 7.0f)) * 7.0f; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector4 Mod7(in Vector4 x) { return x - MathF.Floor(x * (1.0f / 7.0f)) * 7.0f; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Permute(float x) { return Mod289((34.0f * x + 1.0f) * x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 Permute(in Vector3 x) { return Mod289((34.0f * x + 1.0f) * x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector4 Permute(in Vector4 x) { return Mod289((34.0f * x + 1.0f) * x); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static float TaylorInvSqrt(float r) { return 1.79284291400159f - 0.85373472095314f * r; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static Vector4 TaylorInvSqrt(in Vector4 r) { return 1.79284291400159f - 0.85373472095314f * r; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector2 Fade(in Vector2 t) { return t * t * t * (t * (t * 6.0f - 15.0f) + 10.0f); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector3 Fade(in Vector3 t) { return t * t * t * (t * (t * 6.0f - 15.0f) + 10.0f); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector4 Fade(in Vector4 t) { return t * t * t * (t * (t * 6.0f - 15.0f) + 10.0f); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="j"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static Vector4 Grad4(float j, in Vector4 ip)
        {
            Vector4 ones = new Vector4(1.0f, 1.0f, 1.0f, -1.0f);
            Vector3 pxyz = MathF.Floor(MathF.Floor(new Vector3(j) * ip.ToVector3()) * 7.0f) * ip.Z - 1.0f;
            float pw = 1.5f - Vector3.Dot(MathF.Abs(pxyz), ones.ToVector3());
            Vector4 p = new Vector4(pxyz, pw);
            return p;
        }

        // Hashed 2-D gradients with an extra rotation.
        // (The constant 0.0243902439 is 1/41)
        static Vector2 RGrad2(in Vector2 p, float rot)
        {
            // For more isotropic gradients, math.sin/math.cos can be used instead.
            float u = Permute(Permute(p.X) + p.Y) * 0.0243902439f + rot; // Rotate by shift
            u = MathF.Frac(u) * 6.28318530718f; // 2*pi
            return new Vector2(MathF.Cos(u), MathF.Sin(u));
        }
    }
}