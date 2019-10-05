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
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static EulerAngles FromRotationMatrixToXZY(in Matrix3x3 matrix)
        {
            FromRotationMatrixToXZY(matrix, out EulerAngles result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static EulerAngles FromRotationMatrixToYXZ(in Matrix3x3 matrix)
        {
            FromRotationMatrixToYXZ(matrix, out EulerAngles result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static EulerAngles FromRotationMatrixToYZX(in Matrix3x3 matrix)
        {
            FromRotationMatrixToYZX(matrix, out EulerAngles result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static EulerAngles FromRotationMatrixToZXY(in Matrix3x3 matrix)
        {
            FromRotationMatrixToZXY(matrix, out EulerAngles result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static EulerAngles FromRotationMatrixToZYX(in Matrix3x3 matrix)
        {
            FromRotationMatrixToZYX(matrix, out EulerAngles result);
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
            if (matrix.M02 < 1.0f)
            {
                if (matrix.M02 > -1.0f)
                {
                    result.Yaw = MathF.Asin(matrix.M02);
                    result.Pitch = MathF.Atan2(-matrix.M12, matrix.M22);
                    result.Roll = MathF.Atan2(-matrix.M01, matrix.M00);
                }
                else
                {
                    result.Yaw = -MathF.PI * 0.5f;
                    result.Pitch = -MathF.Atan2(matrix.M10, matrix.M11);
                    result.Roll = 0.0f;
                }
            }
            else
            {
                result.Yaw = MathF.PI * 0.5f;
                result.Pitch = MathF.Atan2(matrix.M10, matrix.M11);
                result.Roll = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToXZY(in Matrix3x3 matrix, out EulerAngles result)
        {
            if (matrix.M01 < 1.0f)
            {
                if (matrix.M01 > -1.0f)
                {
                    result.Roll = MathF.Asin(-matrix.M01);
                    result.Pitch = MathF.Atan2(matrix.M21, matrix.M11);
                    result.Yaw = MathF.Atan2(matrix.M02, matrix.M00);
                }
                else
                {
                    result.Roll = MathF.PI * 0.5f;
                    result.Pitch =-MathF.Atan2(-matrix.M20, matrix.M22);
                    result.Yaw = 0.0f;
                }
            }
            else
            {
                result.Roll = -MathF.PI * 0.5f;
                result.Pitch = MathF.Atan2(-matrix.M20, matrix.M22);
                result.Yaw = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToYXZ(in Matrix3x3 matrix, out EulerAngles result)
        {
            if (matrix.M12 < 1.0f)
            {
                if (matrix.M12 > -1.0f)
                {
                    result.Pitch = MathF.Asin(-matrix.M12);
                    result.Yaw = MathF.Atan2(matrix.M02, matrix.M22);
                    result.Roll = MathF.Atan2(matrix.M10, matrix.M11);
                }
                else
                {
                    result.Pitch = MathF.PI * 0.5f;
                    result.Yaw = -MathF.Atan2(-matrix.M01, matrix.M00);
                    result.Roll = 0.0f;
                }
            }
            else
            {
                result.Pitch = -MathF.PI * 0.5f;
                result.Yaw = MathF.Atan2(-matrix.M01, matrix.M00);
                result.Roll = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToYZX(in Matrix3x3 matrix, out EulerAngles result)
        {
            if (matrix.M10 < 1.0f)
            {
                if (matrix.M10 > -1.0f)
                {
                    result.Roll = MathF.Asin(matrix.M10);
                    result.Yaw = MathF.Atan2(matrix.M20, matrix.M00);
                    result.Pitch = MathF.Atan2(matrix.M12, matrix.M11);
                }
                else
                {
                    result.Roll = -MathF.PI * 0.5f;
                    result.Yaw = -MathF.Atan2(matrix.M21, matrix.M22);
                    result.Pitch = 0.0f;
                }
            }
            else
            {
                result.Roll = MathF.PI * 0.5f;
                result.Yaw = MathF.Atan2(-matrix.M21, matrix.M22);
                result.Pitch = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToZXY(in Matrix3x3 matrix, out EulerAngles result)
        {
            if (matrix.M21 < 1.0f)
            {
                if (matrix.M21 > -1.0f)
                {
                    result.Pitch = MathF.Asin(matrix.M21);
                    result.Roll = MathF.Atan2(-matrix.M01, matrix.M11);
                    result.Yaw = MathF.Atan2(-matrix.M20, matrix.M22);
                }
                else
                {
                    result.Pitch = -MathF.PI * 0.5f;
                    result.Roll = -MathF.Atan2(-matrix.M02, matrix.M00);
                    result.Yaw = 0.0f;
                }
            }
            else
            {
                result.Pitch = MathF.PI * 0.5f;
                result.Roll = MathF.Atan2(matrix.M02, matrix.M00);
                result.Yaw = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToZYX(in Matrix3x3 matrix, out EulerAngles result)
        {
            if (matrix.M20 < 1.0f)
            {
                if (matrix.M20 > -1.0f)
                {
                    result.Yaw = MathF.Asin(-matrix.M20);
                    result.Roll = MathF.Atan2(matrix.M10, matrix.M00);
                    result.Pitch = MathF.Atan2(matrix.M21, matrix.M22);
                }
                else
                {
                    result.Yaw = MathF.PI * 0.5f;
                    result.Roll = -MathF.Atan2(-matrix.M12, matrix.M11);
                    result.Pitch = 0.0f; 
                }
            }
            else
            {
                result.Yaw = -MathF.PI * 0.5f;
                result.Roll = MathF.Atan2(-matrix.M12, matrix.M11);
                result.Pitch = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToXYX(in Matrix3x3 matrix, out EulerAngles result)
        {
            if (matrix.M00 < 1.0f)
            {
                if (matrix.M00 > -1.0f)
                {
                    result.Yaw = MathF.Acos(matrix.M00);
                    result.Pitch = MathF.Atan2(matrix.M10, -matrix.M20);
                    result.Roll = MathF.Atan2(matrix.M01, matrix.M02);
                }
                else
                {
                    result.Yaw = MathF.PI;
                    result.Pitch = -MathF.Atan2(-matrix.M12, matrix.M11);
                    result.Roll = 0.0f;
                }
            }
            else
            {
                result.Yaw = 0.0f;
                result.Pitch = MathF.Atan2(-matrix.M12, matrix.M11);
                result.Roll = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToXZX(in Matrix3x3 matrix, out EulerAngles result)
        {
            if (matrix.M00 < 1.0f)
            {
                if (matrix.M00 > -1.0f)
                {
                    result.Roll = MathF.Acos(matrix.M00);
                    result.Pitch = MathF.Atan2(matrix.M20, matrix.M10);
                    result.Yaw = MathF.Atan2(matrix.M02, -matrix.M01);
                }
                else
                {
                    result.Roll = MathF.PI;
                    result.Pitch = -MathF.Atan2(-matrix.M21, matrix.M22);
                    result.Yaw = 0.0f;
                }
            }
            else
            {
                result.Roll = 0.0f;
                result.Pitch = MathF.Atan2(matrix.M21, matrix.M22);
                result.Yaw = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToYXY(in Matrix3x3 matrix, out EulerAngles result)
        {
            if (matrix.M11 < 1.0f)
            {
                if (matrix.M11 > -1.0f)
                {
                    result.Pitch = MathF.Acos(matrix.M11);
                    result.Yaw = MathF.Atan2(matrix.M01, matrix.M21);
                    result.Roll = MathF.Atan2(matrix.M10, -matrix.M12);
                }
                else
                {
                    result.Pitch = MathF.PI;
                    result.Yaw = -MathF.Atan2(matrix.M02, matrix.M00);
                    result.Roll = 0.0f;
                }
            }
            else
            {
                result.Pitch = 0.0f;
                result.Yaw = MathF.Atan2(matrix.M20, matrix.M00);
                result.Roll = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToYZY(in Matrix3x3 matrix, out EulerAngles result)
        {
            if (matrix.M11 < 1.0f)
            {
                if (matrix.M11 > -1.0f)
                {
                    result.Roll = MathF.Acos(matrix.M11);
                    result.Yaw = MathF.Atan2(matrix.M21, -matrix.M01);
                    result.Pitch = MathF.Atan2(matrix.M12, matrix.M10);
                }
                else
                {
                    result.Roll = MathF.PI;
                    result.Yaw = -MathF.Atan2(matrix.M20, matrix.M22);
                    result.Pitch = 0.0f;
                }
            }
            else
            {
                result.Roll = 0.0f;
                result.Yaw = MathF.Atan2(-matrix.M20, matrix.M22);
                result.Pitch = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToZXZ(in Matrix3x3 matrix, out EulerAngles result)
        {
            if (matrix.M22 < 1.0f)
            {
                if (matrix.M22 > -1.0f)
                {
                    result.Pitch = MathF.Acos(matrix.M22);
                    result.Roll = MathF.Atan2(matrix.M02, -matrix.M12);
                    result.Yaw = MathF.Atan2(matrix.M20, matrix.M21);
                }
                else
                {
                    result.Pitch = MathF.PI;
                    result.Roll = -MathF.Atan2(-matrix.M01, matrix.M00);
                    result.Yaw = 0.0f;
                }
            }
            else
            {
                result.Pitch = 0.0f;
                result.Roll = MathF.Atan2(-matrix.M01, matrix.M00);
                result.Yaw = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToZYZ(in Matrix3x3 matrix, out EulerAngles result)
        {
            if (matrix.M22 < 1.0f)
            {
                if (matrix.M22 > -1.0f)
                {
                    result.Yaw = MathF.Acos(matrix.M22);
                    result.Roll = MathF.Atan2(matrix.M12, matrix.M02);
                    result.Pitch = MathF.Atan2(matrix.M21, -matrix.M20);
                }
                else
                {
                    result.Yaw = MathF.PI;
                    result.Roll = -MathF.Atan2(-matrix.M10, matrix.M11);
                    result.Pitch = 0.0f;
                }
            }
            else
            {
                result.Yaw = 0.0f;
                result.Roll = MathF.Atan2(matrix.M10, matrix.M11);
                result.Pitch = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToXYZ(in Matrix4x4 matrix, out EulerAngles result)
        {
            if (matrix.M02 < 1.0f)
            {
                if (matrix.M02 > -1.0f)
                {
                    result.Yaw = MathF.Asin(matrix.M02);
                    result.Pitch = MathF.Atan2(-matrix.M12, matrix.M22);
                    result.Roll = MathF.Atan2(-matrix.M01, matrix.M00);
                }
                else
                {
                    result.Yaw = -MathF.PI * 0.5f;
                    result.Pitch = -MathF.Atan2(matrix.M10, matrix.M11);
                    result.Roll = 0.0f;
                }
            }
            else
            {
                result.Yaw = MathF.PI * 0.5f;
                result.Pitch = MathF.Atan2(matrix.M10, matrix.M11);
                result.Roll = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToXZY(in Matrix4x4 matrix, out EulerAngles result)
        {
            if (matrix.M01 < 1.0f)
            {
                if (matrix.M01 > -1.0f)
                {
                    result.Roll = MathF.Asin(-matrix.M01);
                    result.Pitch = MathF.Atan2(matrix.M21, matrix.M11);
                    result.Yaw = MathF.Atan2(matrix.M02, matrix.M00);
                }
                else
                {
                    result.Roll = MathF.PI * 0.5f;
                    result.Pitch = -MathF.Atan2(-matrix.M20, matrix.M22);
                    result.Yaw = 0.0f;
                }
            }
            else
            {
                result.Roll = -MathF.PI * 0.5f;
                result.Pitch = MathF.Atan2(-matrix.M20, matrix.M22);
                result.Yaw = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToYXZ(in Matrix4x4 matrix, out EulerAngles result)
        {
            if (matrix.M12 < 1.0f)
            {
                if (matrix.M12 > -1.0f)
                {
                    result.Pitch = MathF.Asin(-matrix.M12);
                    result.Yaw = MathF.Atan2(matrix.M02, matrix.M22);
                    result.Roll = MathF.Atan2(matrix.M10, matrix.M11);
                }
                else
                {
                    result.Pitch = MathF.PI * 0.5f;
                    result.Yaw = -MathF.Atan2(-matrix.M01, matrix.M00);
                    result.Roll = 0.0f;
                }
            }
            else
            {
                result.Pitch = -MathF.PI * 0.5f;
                result.Yaw = MathF.Atan2(-matrix.M01, matrix.M00);
                result.Roll = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToYZX(in Matrix4x4 matrix, out EulerAngles result)
        {
            if (matrix.M10 < 1.0f)
            {
                if (matrix.M10 > -1.0f)
                {
                    result.Roll = MathF.Asin(matrix.M10);
                    result.Yaw = MathF.Atan2(matrix.M20, matrix.M00);
                    result.Pitch = MathF.Atan2(matrix.M12, matrix.M11);
                }
                else
                {
                    result.Roll = -MathF.PI * 0.5f;
                    result.Yaw = -MathF.Atan2(matrix.M21, matrix.M22);
                    result.Pitch = 0.0f;
                }
            }
            else
            {
                result.Roll = MathF.PI * 0.5f;
                result.Yaw = MathF.Atan2(-matrix.M21, matrix.M22);
                result.Pitch = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToZXY(in Matrix4x4 matrix, out EulerAngles result)
        {
            if (matrix.M21 < 1.0f)
            {
                if (matrix.M21 > -1.0f)
                {
                    result.Pitch = MathF.Asin(matrix.M21);
                    result.Roll = MathF.Atan2(-matrix.M01, matrix.M11);
                    result.Yaw = MathF.Atan2(-matrix.M20, matrix.M22);
                }
                else
                {
                    result.Pitch = -MathF.PI * 0.5f;
                    result.Roll = -MathF.Atan2(-matrix.M02, matrix.M00);
                    result.Yaw = 0.0f;
                }
            }
            else
            {
                result.Pitch = MathF.PI * 0.5f;
                result.Roll = MathF.Atan2(matrix.M02, matrix.M00);
                result.Yaw = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToZYX(in Matrix4x4 matrix, out EulerAngles result)
        {
            if (matrix.M20 < 1.0f)
            {
                if (matrix.M20 > -1.0f)
                {
                    result.Yaw = MathF.Asin(-matrix.M20);
                    result.Roll = MathF.Atan2(matrix.M10, matrix.M00);
                    result.Pitch = MathF.Atan2(matrix.M21, matrix.M22);
                }
                else
                {
                    result.Yaw = MathF.PI * 0.5f;
                    result.Roll = -MathF.Atan2(-matrix.M12, matrix.M11);
                    result.Pitch = 0.0f;
                }
            }
            else
            {
                result.Yaw = -MathF.PI * 0.5f;
                result.Roll = MathF.Atan2(-matrix.M12, matrix.M11);
                result.Pitch = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToXYX(in Matrix4x4 matrix, out EulerAngles result)
        {
            if (matrix.M02 < 1.0f)
            {
                if (matrix.M02 > -1.0f)
                {
                    result.Yaw = MathF.Asin(matrix.M02);
                    result.Pitch = MathF.Atan2(-matrix.M12, matrix.M22);
                    result.Roll = MathF.Atan2(-matrix.M01, matrix.M00);
                }
                else
                {
                    result.Yaw = -MathF.PI * 0.5f;
                    result.Pitch = -MathF.Atan2(matrix.M10, matrix.M11);
                    result.Roll = 0.0f;
                }
            }
            else
            {
                result.Yaw = MathF.PI * 0.5f;
                result.Pitch = MathF.Atan2(matrix.M10, matrix.M11);
                result.Roll = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToXZX(in Matrix4x4 matrix, out EulerAngles result)
        {
            if (matrix.M00 < 1.0f)
            {
                if (matrix.M00 > -1.0f)
                {
                    result.Roll = MathF.Acos(matrix.M00);
                    result.Pitch = MathF.Atan2(matrix.M20, matrix.M10);
                    result.Yaw = MathF.Atan2(matrix.M02, -matrix.M01);
                }
                else
                {
                    result.Roll = MathF.PI;
                    result.Pitch = -MathF.Atan2(-matrix.M21, matrix.M22);
                    result.Yaw = 0.0f;
                }
            }
            else
            {
                result.Roll = 0.0f;
                result.Pitch = MathF.Atan2(matrix.M21, matrix.M22);
                result.Yaw = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToYXY(in Matrix4x4 matrix, out EulerAngles result)
        {
            if (matrix.M11 < 1.0f)
            {
                if (matrix.M11 > -1.0f)
                {
                    result.Pitch = MathF.Acos(matrix.M11);
                    result.Yaw = MathF.Atan2(matrix.M01, matrix.M21);
                    result.Roll = MathF.Atan2(matrix.M10, -matrix.M12);
                }
                else
                {
                    result.Pitch = MathF.PI;
                    result.Yaw = -MathF.Atan2(matrix.M02, matrix.M00);
                    result.Roll = 0.0f;
                }
            }
            else
            {
                result.Pitch = 0.0f;
                result.Yaw = MathF.Atan2(matrix.M20, matrix.M00);
                result.Roll = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToYZY(in Matrix4x4 matrix, out EulerAngles result)
        {
            if (matrix.M11 < 1.0f)
            {
                if (matrix.M11 > -1.0f)
                {
                    result.Roll = MathF.Acos(matrix.M11);
                    result.Yaw = MathF.Atan2(matrix.M21, -matrix.M01);
                    result.Pitch = MathF.Atan2(matrix.M12, matrix.M10);
                }
                else
                {
                    result.Roll = MathF.PI;
                    result.Yaw = -MathF.Atan2(matrix.M20, matrix.M22);
                    result.Pitch = 0.0f;
                }
            }
            else
            {
                result.Roll = 0.0f;
                result.Yaw = MathF.Atan2(-matrix.M20, matrix.M22);
                result.Pitch = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToZXZ(in Matrix4x4 matrix, out EulerAngles result)
        {
            if (matrix.M22 < 1.0f)
            {
                if (matrix.M22 > -1.0f)
                {
                    result.Pitch = MathF.Acos(matrix.M22);
                    result.Roll = MathF.Atan2(matrix.M02, -matrix.M12);
                    result.Yaw = MathF.Atan2(matrix.M20, matrix.M21);
                }
                else
                {
                    result.Pitch = MathF.PI;
                    result.Roll = -MathF.Atan2(-matrix.M01, matrix.M00);
                    result.Yaw = 0.0f;
                }
            }
            else
            {
                result.Pitch = 0.0f;
                result.Roll = MathF.Atan2(-matrix.M01, matrix.M00);
                result.Yaw = 0.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="euler"></param>
        public static void FromRotationMatrixToZYZ(in Matrix4x4 matrix, out EulerAngles result)
        {
            if (matrix.M22 < 1.0f)
            {
                if (matrix.M22 > -1.0f)
                {
                    result.Yaw = MathF.Acos(matrix.M22);
                    result.Roll = MathF.Atan2(matrix.M12, matrix.M02);
                    result.Pitch = MathF.Atan2(matrix.M21, -matrix.M20);
                }
                else
                {
                    result.Yaw = MathF.PI;
                    result.Roll = -MathF.Atan2(-matrix.M10, matrix.M11);
                    result.Pitch = 0.0f;
                }
            }
            else
            {
                result.Yaw = 0.0f;
                result.Roll = MathF.Atan2(matrix.M10, matrix.M11);
                result.Pitch = 0.0f;
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
