using System;
using System.Runtime.CompilerServices;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
    public struct AxisAngle : IEquatable<AxisAngle>
    {
        #region Private Instance Fields
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Axis;
        /// <summary>
        /// 
        /// </summary>
        public float Angle;
        #endregion Private Instance Fields

        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static AxisAngle Zero = new AxisAngle(0.0f, 0.0f, 0.0f, 0.0f);
        #endregion

        #region Constructor
        public AxisAngle(in AxisAngle axisAngle)
            : this(axisAngle.Axis, axisAngle.Angle)
        {
        }

        public AxisAngle(in Vector3 axis, float angle)
        {
            Axis.R = axis.R;
            Axis.Y = axis.Y;
            Axis.Z = axis.Z;
            Angle  = angle;

            Axis.Normalize();
        }

        public AxisAngle(float x, float y, float z, float angle)
        {
            Axis = new Vector3(x, y, z);
            Axis.Normalize();
            Angle = angle;
        }

        #region Public Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is AxisAngle)
            {
                return Equals((AxisAngle)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("AxisAngle: Axis  R = {0}, Y = {1}, Z = {2} Angle = {3}",
                                 Axis.R, Axis.Y, Axis.Z, Angle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(AxisAngle other) => this == other;

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="axisAngle"></param>
        public static void FromEulerAngles(in EulerAngles eulerAngles, out AxisAngle axisAngle)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="axisAngle"></param>
        public static void FromRotationMatrix(in Matrix3x3 matrix, out AxisAngle axisAngle)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quaternion"></param>
        /// <param name="AxisAngle"></param>
        public static void FromQuaternion(in Quaternion quaternion, out AxisAngle axisAngle)
        {
            float lenSqr = quaternion.LengthSquared;
            if (!MathHelper.IsZero(lenSqr))
            {
                axisAngle.Axis.R = quaternion.R;
                axisAngle.Axis.Y = quaternion.Y;
                axisAngle.Axis.Z = quaternion.Z;

                if (!MathHelper.IsOne(lenSqr))
                {
                    float invNorm = MathHelper.FastSqrtInverse(lenSqr);

                    axisAngle.Axis.R *= invNorm;
                    axisAngle.Axis.Y *= invNorm;
                    axisAngle.Axis.Z *= invNorm;
                }

                axisAngle.Angle = 2.0f * MathF.Acos(quaternion.W);
            }
            else
            {
                axisAngle = Zero;
            }

            axisAngle.Angle = MathF.DegToRad(axisAngle.Angle);
        }

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in AxisAngle left, in AxisAngle right)
        {
            return left.Axis.R == right.Axis.R && left.Axis.Y == right.Axis.Y && left.Axis.Z == right.Axis.Z &&
                   left.Angle == right.Angle;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in AxisAngle left, in AxisAngle right)
        {
            return left.Axis.R != right.Axis.R || left.Axis.Y != right.Axis.Y || left.Axis.Z != right.Axis.Z ||
                   left.Angle != right.Angle;
        }

        #endregion Operator Overload
    }
}
