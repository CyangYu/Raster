using System;
using Raster.Drawing;
using Raster.Drawing.Primitive;

namespace Raster.Drawing.Drawing2D
{
    public class Surface
    {
        #region Private Fields
        /// <summary>
        /// 
        /// </summary>
        private int width;
        /// <summary>
        /// 
        /// </summary>
		private int height;
        /// <summary>
        /// 
        /// </summary>
        private int refCount;

        /// <summary>
        /// 
        /// </summary>
        private byte[] pixels;

        /// <summary>
        /// 
        /// </summary>
        private Rectangle clipRect;
        /// <summary>
        /// 
        /// </summary>
        private PixelFormat format;
        #endregion Private Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public int Width 
		{
			get 
			{
				return width;
			}
			
		}
		
        /// <summary>
        /// 
        /// </summary>
		public int Height
		{
			get 
			{
				return height;
			}
		}

        /// <summary>
        /// 
        /// </summary>
        public Rectangle ClipRect 
		{
			get 
			{
				return clipRect;
			}
		}

        /// <summary>
        /// 
        /// </summary>
        public int RefCount
        {
            get
            {
                return refCount;
            }
        }

        #endregion Public Instance Properties

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public static int MapRGBA(PixelFormat format, byte red, byte green, byte blue, byte alpha)
		{
			return 0;
		}
		
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="rgba"></param>
        /// <returns></returns>
		public static int MapRGBA(PixelFormat format, in Rgba rgba) =>
            MapRGBA(format, rgba.R, rgba.G, rgba.B, rgba.A);

        #endregion Public Static Methods
    }
}
