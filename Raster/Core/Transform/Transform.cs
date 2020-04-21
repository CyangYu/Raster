using System;
using Raster.Core.Math;

namespace Raster.Transform
{
    /// <summary>
    /// 
    /// </summary>
    public class Transform
    {
        #region Public Instance Fields

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Position;

        /// <summary>
        /// 
        /// </summary>
        public Quaternion Rotation;

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Scale;
        #endregion Public Instance Fields

        #region Public Instance Methods
        /// <summary>
        /// 
        /// </summary>
        public void LookAt()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="up"></param>
        public void LookAt(in Vector3 target, in Vector3 up)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void RotateAround()
        {
        }

        #endregion Public Instance Methods
    }
}
