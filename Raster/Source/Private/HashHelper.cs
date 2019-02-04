using System;

namespace Raster.Private
{
    /// <summary>
    /// 
    /// </summary>
    public class HashHelpers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="h1"></param>
        /// <param name="h2"></param>
        /// <returns></returns>
        public static int Combine(int h1, int h2)
        {
            unchecked
            {
                uint rol5 = ((uint)h1 << 5) | ((uint)h1 >> 27);
                return ((int)rol5 + h1) ^ h2;
            }
        }
    }
}
