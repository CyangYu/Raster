using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Raster.Private;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct EulerAngles : IEquatable<EulerAngles>
    {
		#region Public Fields
        /// <summary>
        /// Rotate about x-Axis
        /// </summary>
        public float Pitch;
        /// <summary>
        /// Rotate abount y-Axis
        /// </summary>
        public float Yaw;
        /// <summary>
        /// Rotate abount z-Axis
        /// </summary>
        public float Roll;
		#endregion Public Fields
		
		#region Constructor
        public EulerAngles(Vector3 vec3)
            : this(vec3.X, vec3.Y, vec3.Z)
        {
        }
		
		public EulerAngles(in EulerAngles euler)
			: this(euler.Pitch, euler.Yaw, euler.Roll)
		{
		}
		
        public EulerAngles(float pitch, float yaw, float roll)
        {
            Pitch = pitch;
            Yaw = yaw;
            Roll  = roll;
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
            if (obj is EulerAngles)
            {
                return Equals((EulerAngles)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = HashHelpers.Combine(Pitch.GetHashCode(), Roll.GetHashCode());
            return HashHelpers.Combine(hash, Yaw.GetHashCode());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("EulerAngles: Pitch = {0}, Yaw = {1}, Roll = {2}", Pitch, Yaw, Roll);
        }
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(EulerAngles other)
        {
            return this.Pitch == other.Pitch && this.Yaw == other.Yaw &&
                   this.Roll == other.Roll;
        }

        /// <summary>
        /// 
        /// </summary>
        public void RadianToDegree()
        {
            Pitch   *= MathF.Rad2Deg;
            Yaw     *= MathF.Rad2Deg;
            Roll    *= MathF.Rad2Deg;
        }

        /// <summary>
        /// 
        /// </summary>
        public void DegreeToRadian()
        {
            Pitch   *= MathF.Deg2Rad;
            Yaw     *= MathF.Deg2Rad;
            Roll    *= MathF.Deg2Rad;
        }

        #endregion Public Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="quaternion"></param>
        /// <returns></returns>
        public static EulerAngles FromQuaternion(in Quaternion quaternion)
        {
            FromQuaternion(in quaternion, out EulerAngles result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static EulerAngles FromRotationMatrixToXYZ(in Matrix3x3 matrix)
        {
            FromRotationMatrixToXYZ(matrix, out EulerAngles result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="w"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static void FromQuaternion(in Quaternion quaternion, out EulerAngles result)
        {
            float xx = quaternion.X * quaternion.X;
            float xy = quaternion.X * quaternion.Y;
            float xz = quaternion.X * quaternion.Z;
            float xw = quaternion.X * quaternion.W;
            float yy = quaternion.Y * quaternion.Y;
            float yz = quaternion.Y * quaternion.Z;
            float yw = quaternion.Y * quaternion.W;
            float zz = quaternion.Z * quaternion.Z;
            float zw = quaternion.Z * quaternion.W;

            float lenSqr = xx + yy + zz + quaternion.W * quaternion.W;
            if (!MathHelper.IsOne(lenSqr) && !MathHelper.IsZero(lenSqr))
            {
                xx /= lenSqr;
                xy /= lenSqr;
                xz /= lenSqr;
                xw /= lenSqr;
                yy /= lenSqr;
                yz /= lenSqr;
                yw /= lenSqr;
                zz /= lenSqr;
                zw /= lenSqr;
            }

            result.Pitch = MathF.Asin(-2.0f * (yz - xw));
            if (result.Pitch < MathF.PI_2)
            {
                if (result.Pitch > -MathF.PI_2)
                {
                    result.Yaw = MathF.Atan2(2.0f * (xz + yw), 1.0f - 2.0f * (xx + yy));
                    result.Roll = MathF.Atan2(2.0f * (xy + zw), 1.0f - 2.0f * (xx + zz));
                } 
                else
                {
                    result.Roll = 0.0f;
                    result.Yaw = -MathF.Atan2(-2.0f * (xy - zw), 1.0f - 2.0f * (yy + zz));
                }
            }
            else
            {
                result.Roll = 0.0f;
                result.Yaw = MathF.Atan2(-2.0f * (xy - zw), 1.0f - 2.0f * (yy + zz));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToXYZ(in Matrix3x3 matrix, out EulerAngles result)
        {
            result.Yaw = MathF.Asin(matrix);
            if (result.Pitch < MathF.PI_2)
            {
                if (result.Pitch > -MathF.PI_2)
                {
                    result.Yaw = MathF.Atan2(2.0f * (xz + yw), 1.0f - 2.0f * (xx + yy));
                    result.Roll = MathF.Atan2(2.0f * (xy + zw), 1.0f - 2.0f * (xx + zz));
                }
                else
                {
                    result.Roll = 0.0f;
                    result.Yaw = -MathF.Atan2(-2.0f * (xy - zw), 1.0f - 2.0f * (yy + zz));
                }
            }
            else
            {
                result.Roll = 0.0f;
                result.Yaw = MathF.Atan2(-2.0f * (xy - zw), 1.0f - 2.0f * (yy + zz));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToXZY(in Matrix3x3 matrix, out EulerAngles result)
        {
            result.Pitch = MathF.Asin(-2.0f * (yz - xw));
            if (result.Pitch < MathF.PI_2)
            {
                if (result.Pitch > -MathF.PI_2)
                {
                    result.Yaw = MathF.Atan2(2.0f * (xz + yw), 1.0f - 2.0f * (xx + yy));
                    result.Roll = MathF.Atan2(2.0f * (xy + zw), 1.0f - 2.0f * (xx + zz));
                }
                else
                {
                    result.Roll = 0.0f;
                    result.Yaw = -MathF.Atan2(-2.0f * (xy - zw), 1.0f - 2.0f * (yy + zz));
                }
            }
            else
            {
                result.Roll = 0.0f;
                result.Yaw = MathF.Atan2(-2.0f * (xy - zw), 1.0f - 2.0f * (yy + zz));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToYXZ(in Matrix3x3 matrix, out EulerAngles result)
        {
            result.Pitch = MathF.Asin(-2.0f * (yz - xw));
            if (result.Pitch < MathF.PI_2)
            {
                if (result.Pitch > -MathF.PI_2)
                {
                    result.Yaw = MathF.Atan2(2.0f * (xz + yw), 1.0f - 2.0f * (xx + yy));
                    result.Roll = MathF.Atan2(2.0f * (xy + zw), 1.0f - 2.0f * (xx + zz));
                }
                else
                {
                    result.Roll = 0.0f;
                    result.Yaw = -MathF.Atan2(-2.0f * (xy - zw), 1.0f - 2.0f * (yy + zz));
                }
            }
            else
            {
                result.Roll = 0.0f;
                result.Yaw = MathF.Atan2(-2.0f * (xy - zw), 1.0f - 2.0f * (yy + zz));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static bool FromRotationMatrixToYZX(in Matrix3x3 matrix, out EulerAngles result)
        {
            result.Pitch = MathF.Asin(-2.0f * (yz - xw));
            if (result.Pitch < MathF.PI_2)
            {
                if (result.Pitch > -MathF.PI_2)
                {
                    result.Yaw = MathF.Atan2(2.0f * (xz + yw), 1.0f - 2.0f * (xx + yy));
                    result.Roll = MathF.Atan2(2.0f * (xy + zw), 1.0f - 2.0f * (xx + zz));
                }
                else
                {
                    result.Roll = 0.0f;
                    result.Yaw = -MathF.Atan2(-2.0f * (xy - zw), 1.0f - 2.0f * (yy + zz));
                }
            }
            else
            {
                result.Roll = 0.0f;
                result.Yaw = MathF.Atan2(-2.0f * (xy - zw), 1.0f - 2.0f * (yy + zz));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToZXY(in Matrix3x3 matrix, out EulerAngles result)
        {
            result.Pitch = MathF.Asin(-2.0f * (yz - xw));
            if (result.Pitch < MathF.PI_2)
            {
                if (result.Pitch > -MathF.PI_2)
                {
                    result.Yaw = MathF.Atan2(2.0f * (xz + yw), 1.0f - 2.0f * (xx + yy));
                    result.Roll = MathF.Atan2(2.0f * (xy + zw), 1.0f - 2.0f * (xx + zz));
                }
                else
                {
                    result.Roll = 0.0f;
                    result.Yaw = -MathF.Atan2(-2.0f * (xy - zw), 1.0f - 2.0f * (yy + zz));
                }
            }
            else
            {
                result.Roll = 0.0f;
                result.Yaw = MathF.Atan2(-2.0f * (xy - zw), 1.0f - 2.0f * (yy + zz));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToZYX(in Matrix3x3 matrix, out EulerAngles result)
        {
            result.Pitch = MathF.Asin(-2.0f * (yz - xw));
            if (result.Pitch < MathF.PI_2)
            {
                if (result.Pitch > -MathF.PI_2)
                {
                    result.Yaw = MathF.Atan2(2.0f * (xz + yw), 1.0f - 2.0f * (xx + yy));
                    result.Roll = MathF.Atan2(2.0f * (xy + zw), 1.0f - 2.0f * (xx + zz));
                }
                else
                {
                    result.Roll = 0.0f;
                    result.Yaw = -MathF.Atan2(-2.0f * (xy - zw), 1.0f - 2.0f * (yy + zz));
                }
            }
            else
            {
                result.Roll = 0.0f;
                result.Yaw = MathF.Atan2(-2.0f * (xy - zw), 1.0f - 2.0f * (yy + zz));
            }
        }

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in EulerAngles left, in EulerAngles right)
        {
            return left.Pitch == right.Pitch && left.Roll == right.Roll &&
                   left.Yaw == right.Yaw;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in EulerAngles left, in EulerAngles right)
        {
            return left.Pitch != right.Pitch || left.Roll != right.Roll || 
                   left.Yaw != right.Yaw;
        }
        #endregion Operator Overload
    }
}
