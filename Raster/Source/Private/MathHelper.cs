using System;
using System.Runtime.CompilerServices;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
    public class MathHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuickSqrtInv(float f)
        {
            unsafe
            {
                float xhalf = 0.5f * f;
                int i = *(int*)&f;
                i = 0x5f375a86 - (i >> 1);
                f = *(float*)&i;
                f = f * (1.5f - (xhalf * f * f));
                return f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(ref float a, ref float b)
        {
            float temp = a;
            a = b;
            b = temp;
        }
    }
}
