using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
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
            Axis = axis.Normalized;
            Angle  = angle;
        }

        public AxisAngle(float x, float y, float z, float angle)
        {
            Axis = new Vector3(x, y, z).Normalized;
            Angle = angle;
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
                                 Axis.X, Axis.Y, Axis.Z, Angle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(AxisAngle other)
        {
            return this.Axis.X == other.Axis.X &&
                   this.Axis.Y == other.Axis.Y &&
                   this.Axis.Z == other.Axis.Z &&
                   this.Angle == other.Angle;
        }
        #endregion Public Instance Methods

        #region Public Static Methods
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
                axisAngle.Axis.X = quaternion.X;
                axisAngle.Axis.Y = quaternion.Y;
                axisAngle.Axis.Z = quaternion.Z;

                if (!MathHelper.IsOne(lenSqr))
                {
                    float invNorm = MathHelper.FastSqrtInverse(lenSqr);

                    axisAngle.Axis.X *= invNorm;
                    axisAngle.Axis.Y *= invNorm;
                    axisAngle.Axis.Z *= invNorm;
                }

                axisAngle.Angle = 2.0f * MathF.Acos(quaternion.W);
            }
            else
            {
                axisAngle = Zero;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="axisAngle"></param>
        public static void FromRotationMatrix(in Matrix3x3 matrix, out AxisAngle axis)
        {
            float trace = matrix.M00 + matrix.M11 + matrix.M22;
            float cos = 0.5f * (trace - 1.0f);
            
            axis.Angle = MathF.Acos(cos);

            if (axis.Angle > 0.0f)
            {
                if (axis.Angle < MathF.PI)
                {
                    axis.Axis.X = matrix.M21 - matrix.M12;
                    axis.Axis.Y = matrix.M02 - matrix.M20;
                    axis.Axis.Z = matrix.M10 - matrix.M01;
                    axis.Axis.Normalize();
                }
                else
                {
                    float half_inverse = 0.0f;
                    if (matrix.M00 >= matrix.M11)
                    {
                        if (matrix.M00 >= matrix.M22)
                        {
                            axis.Axis.X = 0.5f - MathF.Sqrt(matrix.M00 - matrix.M11 - 
                                                            matrix.M22 + 1.0f);
                            half_inverse = 0.5f / axis.Axis.X;
                            axis.Axis.Y = half_inverse * matrix.M01;
                            axis.Axis.Z = half_inverse * matrix.M02;
                        }
                        else
                        {
                            axis.Axis.Z = 0.5f * MathF.Sqrt(matrix.M22 - matrix.M00 -
                                                            matrix.M11 + 1.0f);
                            half_inverse = 0.5f / axis.Axis.Z;
                            axis.Axis.X = half_inverse * matrix.M02;
                            axis.Axis.Y = half_inverse * matrix.M12;
                        }
                    }
                    else
                    {
                        // r11 > r00
                        if (matrix.M11 >= matrix.M22)
                        {
                            axis.Axis.Y = 0.5f * MathF.Sqrt(matrix.M11 - matrix.M00 - matrix.M22 + 1.0f);
                            half_inverse = 0.5f / axis.Axis.Y;
                            axis.Axis.X = half_inverse * matrix.M01;
                            axis.Axis.Z = half_inverse * matrix.M12;
                        }
                        else
                        {
                            axis.Axis.Z = 0.5f * MathF.Sqrt(matrix.M22 - matrix.M00 - matrix.M11 + 1.0f);
                            half_inverse = 0.5f / axis.Axis.Z;
                            axis.Axis.X = half_inverse * matrix.M02;
                            axis.Axis.Y = half_inverse * matrix.M12;
                        }
                    }
                }
            }
            else
            {
                axis.Axis = Vector3.Right;
            }

        }
        #endregion Public Static Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in AxisAngle left, in AxisAngle right)
        {
            return left.Axis.X == right.Axis.X && left.Axis.Y == right.Axis.Y && left.Axis.Z == right.Axis.Z &&
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
            return left.Axis.X != right.Axis.X || left.Axis.Y != right.Axis.Y || left.Axis.Z != right.Axis.Z ||
                   left.Angle != right.Angle;
        }

        #endregion Operator Overload
    }
}