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
        private Vector3 axis;
        /// <summary>
        /// 
        /// </summary>
        private float angle;
        #endregion Private Instance Fields

        #region Public Instance Properties
        /// <summary>
        /// The axis should be normalized vector
        /// </summary>
        public Vector3 Axis
        {
            get { return axis; }
            set { axis = Vector3.Normalize(value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public float Angle
        {
            get { return angle; }
            set { angle = value; }
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
        public override string ToString() =>
            string.Format("AxisAngle: Axis  X = {0}, Y = {1}, Z = {2} Angle = {3}", 
                          Axis.X, Axis.Y, Axis.Z, Angle);

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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        /// <param name="axisAngle"></param>
        public static void FromQuaternion(in Quaternion quaternion, out AxisAngle axisAngle)
        {
            axisAngle.axis.X = quaternion.X;
            axisAngle.axis.Y = quaternion.Y;
            axisAngle.axis.Z = quaternion.Z;
            axisAngle.angle  = quaternion.W;
        }

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in AxisAngle left, in AxisAngle right) =>
            left.axis.X == right.axis.X && left.axis.Y == right.axis.Y && left.axis.Z == right.axis.Z && 
            left.angle == right.angle;

        /// <summary>
        /// 009989099908866
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in AxisAngle left, in AxisAngle right) =>
           left.axis.X != right.axis.X || left.axis.Y != right.axis.Y || left.axis.Z != right.axis.Z ||
           left.angle != right.angle;

        #endregion Operator Overload
    }
}
