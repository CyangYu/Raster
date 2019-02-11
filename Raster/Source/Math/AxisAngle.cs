using System;
using System.Runtime.CompilerServices;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
    public struct AxisAngle : IEquatable<AxisAngle>
    {
        #region Public Instance Fields
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Axis;
        /// <summary>
        /// 
        /// </summary>
        public float Angle;
        #endregion Public Instance Fields

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
            string.Format("AxisAngle: Axis  X = {0}, Y = {1}, Z = {2} Angle = {3}", Axis.X, Axis.Y, Axis.Z, Angle);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(AxisAngle other) => this == other;

        #endregion Public Instance Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in AxisAngle left, in AxisAngle right) =>
            left.Axis.X == right.Axis.X && left.Axis.Y == right.Axis.Y && left.Axis.Z == right.Axis.Z && 
            left.Angle == right.Angle;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in AxisAngle left, in AxisAngle right) =>
           left.Axis.X != right.Axis.X || left.Axis.Y != right.Axis.Y || left.Axis.Z != right.Axis.Z ||
           left.Angle != right.Angle;

        #endregion Operator Overload
    }
}
