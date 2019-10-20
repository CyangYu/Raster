using System;
using System.Runtime.CompilerServices;

namespace Raster.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    public struct Frustum : IEquatable<Frustum>
    {
        #region Public Instance Fields
        /// <summary>
        /// 
        /// </summary>
        private Matrix4x4 m_Matrix;
        /// <summary>
        /// 
        /// </summary>
        private Plane m_Near;
        /// <summary>
        /// 
        /// </summary>
        private Plane m_Far;
        /// <summary>
        /// 
        /// </summary>
        private Plane m_Left;
        /// <summary>
        /// 
        /// </summary>
        private Plane m_Right;
        /// <summary>
        /// 
        /// </summary>
        private Plane m_Top;
        /// <summary>
        /// 
        /// </summary>
        private Plane m_Bottom;
        #endregion Public Instance Fields

        #region Public Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Frustum other) => true;

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cameraPos"></param>
        /// <param name="lookDir"></param>
        /// <param name="upDir"></param>
        /// <param name="fov"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        /// <param name="aspect"></param>
        /// <param name="result"></param>
        public static void FromCamera(in Vector3 cameraPos, in Vector3 lookDir, in Vector3 upDir,
                                      float fov, float zNear, float zFar, float aspect,
                                      out Frustum result)
        {
            Vector3.Normalize(lookDir, out Vector3 lookDirection);
            Vector3.Normalize(upDir, out Vector3 upDirection);

            Vector3 nearCenter = cameraPos + lookDirection * zNear;
            Vector3 farCenter = cameraPos + lookDirection * zFar;

            float nearHalfHeight = zNear * MathF.Tan(fov * 0.5f);
            float farHalfHeight = zFar * MathF.Tan(fov * 0.5f);
            float nearHalfWidth = nearHalfHeight * aspect;
            float farHalfWidth = farHalfHeight * aspect;

            Vector3.Cross(upDirection, lookDirection, out Vector3 rightDirection);
            rightDirection.Normalize();

            Vector3 near0 = nearCenter - nearHalfHeight * upDirection + nearHalfWidth * rightDirection;
            Vector3 near1 = nearCenter + nearHalfHeight * upDirection + nearHalfWidth * rightDirection;
            Vector3 near2 = nearCenter + nearHalfHeight * upDirection - nearHalfWidth * rightDirection;
            Vector3 near3 = nearCenter - nearHalfHeight * upDirection - nearHalfWidth * rightDirection;
            Vector3 far0 = farCenter - farHalfHeight * upDirection + farHalfWidth * rightDirection;
            Vector3 far1 = farCenter + farHalfHeight * upDirection + farHalfWidth * rightDirection;
            Vector3 far2 = farCenter + farHalfHeight * upDirection - farHalfWidth * rightDirection;
            Vector3 far3 = farCenter - farHalfHeight * upDirection - farHalfWidth * rightDirection;

            result.m_Near = new Plane(near0, near1, near2);
            result.m_Far = new Plane(far2, far1, far0);
            result.m_Left = new Plane(near3, near2, far2);
            result.m_Right = new Plane(far0, far1, near1);
            result.m_Top = new Plane(near1, far1, far2);
            result.m_Bottom = new Plane(far3, far0, near0);

            result.m_Matrix = Matrix4x4.Identity;
        }
        #endregion Public Static Methods
    }
}
