using System;
using Raster.Math;
using Raster.Drawing.Primitive;

namespace Raster.Render.Light
{
    /// <summary>
    /// 
    /// </summary>
    public class Light
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

        #endregion Public Instance Methods
    }
}
