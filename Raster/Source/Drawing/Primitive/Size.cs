﻿using System;
using Raster.Private;

namespace Raster.Drawing
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct Size : IEquatable<Size>
    {
        #region Public Fields
        public int Width;
        public int Height;
        #endregion

        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static Size Empty = new Size(0, 0);

        #endregion Public Static Fields

        #region Constructor
        public Size(in Size other)
            : this(other.Width, other.Height)
        {
        }

        public Size(int width, int height)
        {
            Width  = width;
            Height = height;
        }

        #endregion Constructor

        #region Public Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
        public override int GetHashCode() =>
            HashHelpers.Combine(Width, Height);
            
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
        public bool Equals(Size other) => this == other;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => Width == 0 && Height == 0;

        #endregion Public Instance Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Size operator +(in Size left, in Size right) =>
            new Size(left.Width + right.Width, left.Height + right.Height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Size operator -(in Size left, in Size right) =>
            new Size(left.Width - right.Width, left.Height - right.Height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Size operator *(in Size left, int right) =>
            new Size(left.Width * right, left.Height * right);

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

        #endregion Operator Overload
    }
}
