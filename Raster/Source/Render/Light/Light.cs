using System;
using Raster.Math;
using Raster.Drawing.Primitive;

namespace Raster.Render.Light
{
    /// <summary>
    /// 
    /// </summary>
    public struct Light
    {
        #region Public Fields
        /// <summary>
        /// 
        /// </summary>
        public Color Color;
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Direction;
        #endregion Public Fields

        #region Constructor
        public Light(in Light other)
            : this(other.Direction, other.Color)
        {
        }

        public Light(in Vector3 direction, in Color color)
        {
            Color = color;
            Direction = direction.Normalized;
            
        }
        #endregion Constructor

        #region Public Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void SetLightDirection(float x, float y, float z)
        {
            Direction.R = x;
            Direction.Y = y;
            Direction.Z = z;
            Direction.Normalize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="right"></param>
        /// <param name="left"></param>
        public void SetLightColor(float r, float g, float b, float a) =>
            Color.SetColor(r, g, b, a);

        #endregion Public Instance Methods
    }
}
