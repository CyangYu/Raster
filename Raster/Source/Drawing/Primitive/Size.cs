using System;

namespace Raster.Drawing
{
    public struct Size
    {
        #region Public Fields
        public int Width;
        public int Height;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public static Size Empty = new Size(0, 0);

        public Size(int width, int height)
        {
            Width  = width;
            Height = height;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Size left, in Size right) =>
            left.Width == right.Width && left.Height == right.Height;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Size left, in Size right) =>
            left.Width != right.Width || left.Height != right.Height;

        public override bool Equals(object obj)
        {
            if (obj is Size)
            {
                return Equals((Size)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Width.GetHashCode() ^ Height.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            string.Format("SizeF: Width = {0}, Height = {1}", Width, Height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(SizeF other) => this == other;
    }
}
