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
        /// 
        /// </summary>
        public float Pitch;
        /// <summary>
        /// 
        /// </summary>
        public float Roll;
        /// <summary>
        /// 
        /// </summary>
        public float Yaw;
		#endregion Public Fields
		
		#region Constructor
        public EulerAngles(Vector3 vec3)
            : this(vec3.X, vec3.Y, vec3.Z)
        {
        }
		
		public EulerAngles(in EulerAngles euler)
			: this(euler.Pitch, euler.Roll, euler.Yaw)
		{
		}
		
        public EulerAngles(float pitch, float roll, float yaw)
        {
            Pitch = pitch;
            Roll  = roll;
            Yaw   = yaw;
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
        public override string ToString() =>
            string.Format("EulerAngles: Pitch = {0}, Roll = {1}, Yaw = {2}", Pitch, Roll, Yaw);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(EulerAngles other) => this == other;

        #endregion Public Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="axisAngle"></param>
        /// <returns></returns>
        public static EulerAngles FromAxisAngle(in AxisAngle axis)
        {
            FromAxisAngle(axis, out EulerAngles result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quaternion"></param>
        /// <returns></returns>
        public static EulerAngles FromQuaternion(in Quaternion quaternion)
        {
            FromQuaternion(quaternion.X, quaternion.Y, quaternion.Z, quaternion.W, out EulerAngles result);
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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="angle"></param>
        /// <param name="euler"></param>
        public static void FromAxisAngle(in AxisAngle axis, out EulerAngles result)
        {
            result.Pitch = 0.0f;
            result.Roll = 0.0f;
            result.Yaw = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="w"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static void FromQuaternion(float x, float y, float z, float w, out EulerAngles result)
        {
            float xx = x * x;
            float xy = x * y;
            float xz = x * z;
            float xw = x * w;
            float yy = y * y;
            float yz = y * z;
            float yw = y * w;
            float zz = z * z;
            float zw = z * w;

            float lenSqr = xx + yy + zz + w * w;
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
            result.Pitch = MathF.Asin(matrix.M02);
            if (result.Pitch < MathF.Half_PI)
            {
                if (result.Pitch > -MathF.Half_PI)
                {
                    result.Roll = MathF.Atan2(-matrix.M01, matrix.M00);
                    result.Yaw  = MathF.Atan2(-matrix.M12, matrix.M22);
                }
                else
                {
                    result.Roll = 0.0f;
                    result.Yaw  = -MathF.Atan2(matrix.M10, matrix.M11);
                }
            }
            else
            {
                result.Roll = 0.0f;
                result.Yaw  = MathF.Atan2(matrix.M10, matrix.M11);
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToXZY(in Matrix3x3 matrix, out EulerAngles result)
        { 
            result.Pitch = MathF.Asin(-matrix.M01);
            if (result.Pitch < -MathF.Half_PI)
            {
                if (result.Pitch > -MathF.Half_PI)
                {
                    result.Roll = MathF.Atan2(matrix.M02, matrix.M00);
                    result.Yaw  = MathF.Atan2(matrix.M21, matrix.M11);
                }
                else
                {
                    result.Roll = 0.0f;
                    result.Yaw  = -MathF.Atan2(-matrix.M20, matrix.M22);
                }
            }
            else
            {
                result.Roll = 0.0f;
                result.Yaw  = MathF.Atan2(-matrix.M20, matrix.M22);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToYXZ(in Matrix3x3 matrix, out EulerAngles result)
        {
            result.Pitch = MathF.Asin(-matrix.M12);
            if (result.Pitch < -MathF.Half_PI)
            {
                if (result.Pitch > -MathF.Half_PI)
                {
                    result.Roll = MathF.Atan2(matrix.M10, matrix.M11);
                    result.Yaw  = MathF.Atan2(matrix.M02, matrix.M22);
                }
                else
                {
                    result.Roll = 0.0f;
                    result.Yaw  = -MathF.Atan2(-matrix.M01, matrix.M00);
                }
            }
            else
            {
                result.Roll = 0.0f;
                result.Yaw  = MathF.Atan2(-matrix.M01, matrix.M00);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static bool FromRotationMatrixToYZX(in Matrix3x3 matrix, out EulerAngles result)
        {
            result.Pitch = MathF.Asin(matrix.M10);
            if (result.Pitch < -MathF.Half_PI)
            {
                if (result.Pitch > -MathF.Half_PI)
                {
                    result.Roll = MathF.Atan2(-matrix.M12, matrix.M11);
                    result.Yaw  = MathF.Atan2(-matrix.M20, matrix.M00);
                    return true;
                }
                else
                {
                    result.Roll = 0.0f;
                    result.Yaw  = -MathF.Atan2(matrix.M21, matrix.M22);
                    return false;
                }
            }
            else
            {
                result.Roll = 0.0f;
                result.Yaw = MathF.Atan2(-matrix.M21, matrix.M22);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToZXY(in Matrix3x3 matrix, out EulerAngles result)
        {
            result.Pitch = MathF.Asin(matrix.M21);
            if (result.Pitch < -MathF.Half_PI)
            {
                if (result.Pitch > -MathF.Half_PI)
                {
                    result.Roll = MathF.Atan2(-matrix.M20, matrix.M22);
                    result.Yaw  = MathF.Atan2(-matrix.M01, matrix.M11);
                }
                else
                {
                    result.Roll = 0.0f;
                    result.Yaw  = -MathF.Atan2(matrix.M02, matrix.M00);
                }
            }
            else
            {
                result.Roll = 0.0f;
                result.Yaw  = MathF.Atan2(matrix.M02, matrix.M00);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToZYX(in Matrix3x3 matrix, out EulerAngles result)
        {
            result.Pitch = MathF.Asin(-matrix.M20);
            if (result.Pitch < -MathF.Half_PI)
            {
                if (result.Pitch > -MathF.Half_PI)
                {
                    result.Roll = MathF.Atan2(matrix.M21, matrix.M22);
                    result.Yaw  = MathF.Atan2(matrix.M10, matrix.M00);
                }
                else
                {
                    result.Roll = 0.0f;
                    result.Yaw  = -MathF.Atan2(-matrix.M01, matrix.M02);
                }
            }
            else
            {
                result.Roll = 0.0f;
                result.Yaw  = MathF.Atan2(-matrix.M01, matrix.M02);
            }
        }

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in EulerAngles left, in EulerAngles right) =>
            left.Pitch == right.Pitch && left.Roll == right.Roll && left.Yaw == right.Yaw;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in EulerAngles left, in EulerAngles right) =>
           left.Pitch != right.Pitch || left.Roll != right.Roll || left.Yaw != right.Yaw;

        #endregion Operator Overload
    }
}
