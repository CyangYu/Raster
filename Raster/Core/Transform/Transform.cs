using System;
using Raster.Core.Math;

namespace Raster.Transform
{
    /// <summary>
    /// 
    /// </summary>
    public class Transform
    {
        #region Private Instance Fields
        /// <summary>
        /// 
        /// </summary>
        private Matrix4x4 transform;
        #endregion Public Instance Fields

        #region Public Instance Properties

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Position
        {
            get { return new Vector3(transform.M30, transform.M31, transform.M32); }
            set
            {
                transform.M30 = value.X;
                transform.M31 = value.Y;
                transform.M32 = value.Z;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Quaternion Rotation
        {
            get 
            {
                return Quaternion.Identity;
            }
            set
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 LocalScale
        {
            get 
            { 
                return Vector3.Zero;
            }
            set
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Forward
        {
            get 
            { 
             
            }
            set 
            {
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Right
        {
            get 
            { 
            }
            set
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Up
        {
            get 
            { 
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
        public void LookAt(Transform target)
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
        /// <param name="translation"></param>
        public void Translate(in Vector3 translation)
        {
            transform.M30 += translation.X;
            transform.M31 += translation.Y;
            transform.M32 += translation.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void Translate(float x, float y, float z)
        {
            transform.M30 += x;
            transform.M31 += y;
            transform.M32 += z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="axisAngle"></param>
        public void Rotate(in AxisAngle axisAngle)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="angle"></param>
        public void Rotate(in Vector3 axis, float angle)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        public void Rotate(in EulerAngles eulerAngles)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="order"></param>
        public void Rotate(in EulerAngles eulerAngles, MathF.RotationOrder order)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void Rotate(float x, float y, float z)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="rotation"></param>
        public void Rotate(in Quaternion rotation)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scale"></param>
        public void Scale(in Vector3 scale)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void Scale(float x, float y, float z)
        {
        }
        
        #endregion Public Instance Methods
    }
}
