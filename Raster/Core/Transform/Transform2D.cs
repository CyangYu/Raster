using System;
using Raster.Core.Math;

namespace Raster.Core.Transform
{
    public class Transform2D
    {
        private Matrix3x3 transform;

        #region Public Instance Properties
        
        /// <summary>
        /// 
        /// </summary>
        public Vector2 Position
        {
            get { return new Vector2(transform.M20, transform.M21); }
            set
            {
                transform.M20 = value.X;
                transform.M21 = value.Y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector2 Scale
        {
            get 
            {
                return Vector2.Zero;
            }
            set
            {

            }
        }
        #endregion Public Instance Properties

        #region Public Instance Methods
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        public void Rotate(float angle)
        {
            transform.Rotate(angle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="translation"></param>
        public void Translate(in Vector2 translation)
        {
            transform.M20 += translation.X;
            transform.M21 += translation.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Translate(float x, float y)
        {
            transform.M20 += x;
            transform.M21 += y;
        }

        #endregion Public Instance Methods
    }
}
