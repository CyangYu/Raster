using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Raster.Core.Math
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Matrix3x3 : IEquatable<Matrix3x3>
    {
        #region Public Fields
        /// <summary>
        /// 
        /// </summary>
        public float M00;
        /// <summary>
        /// 
        /// </summary>
        public float M01;
        /// <summary>
        /// 
        /// </summary>
        public float M02;

        /// <summary>
        /// 
        /// </summary>
        public float M10;
        /// <summary>
        /// 
        /// </summary>
        public float M11;
        /// <summary>
        /// 
        /// </summary>
        public float M12;

        /// <summary>
        /// 
        /// </summary>
        public float M20;
        /// <summary>
        /// 
        /// </summary>
        public float M21;
        /// <summary>
        /// 
        /// </summary>
        public float M22;
        #endregion

        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly Matrix3x3 Zero = new Matrix3x3(0.0f, 0.0f, 0.0f,
                                                                    0.0f, 0.0f, 0.0f,
                                                                    0.0f, 0.0f, 0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Matrix3x3 Identity = new Matrix3x3(1.0f, 0.0f, 0.0f,
                                                                    0.0f, 1.0f, 0.0f,
                                                                    0.0f, 0.0f, 1.0f);

        #endregion Public Static Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Row0
        {
            get { return new Vector3(M00, M01, M02); }
            set
            {
                M00 = value.X;
                M01 = value.Y;
                M02 = value.Z;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Row1
        {
            get { return new Vector3(M10, M11, M12); }
            set
            {
                M10 = value.X;
                M11 = value.Y;
                M12 = value.Z;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Row2
        {
            get { return new Vector3(M20, M21, M22); }
            set
            {
                M20 = value.X;
                M21 = value.Y;
                M22 = value.Z;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Column0
        {
            get { return new Vector3(M00, M10, M20); }
            set
            {
                M00 = value.X;
                M10 = value.Y;
                M20 = value.Z;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Column1
        {
            get { return new Vector3(M01, M11, M21); }
            set
            {
                M01 = value.X;
                M11 = value.Y;
                M21 = value.Z;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Column2
        {
            get { return new Vector3(M02, M12, M22); }
            set
            {
                M02 = value.X;
                M12 = value.Y;
                M22 = value.Z;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float Determinant
        {
            get
            {
                return (M00 * M11 * M22) + (M01 * M12 * M20) + (M02 * M10 * M21) -
                       (M02 * M11 * M20) - (M00 * M12 * M21) - (M01 * M10 * M22);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>       
        public bool IsZero
        {
            get
            {
                return (M00 == 0.0f && M01 == 0.0f && M02 == 0.0f &&
                        M10 == 0.0f && M11 == 0.0f && M12 == 0.0f &&
                        M20 == 0.0f && M21 == 0.0f && M22 == 0.0f);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>        
        public bool IsIdentity
        {
            get
            {
                return (M00 == 1.0f && M01 == 0.0f && M02 == 0.0f &&
                        M10 == 0.0f && M11 == 1.0f && M12 == 0.0f &&
                        M20 == 0.0f && M21 == 0.0f && M22 == 1.0f);
            }
        }
        #endregion Public Instance Properties

        #region Constructor
        public Matrix3x3(float value)
        {
            M00 = value;
            M01 = value;
            M02 = value;

            M10 = value;
            M11 = value;
            M12 = value;

            M20 = value;
            M21 = value;
            M22 = value;
        }

        public Matrix3x3(Matrix2x2 other)
        {
            M00 = other.M00;
            M01 = other.M01;
            M02 = 0.0f;

            M10 = other.M10;
            M11 = other.M11;
            M12 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = 0.0f;
        }

        public Matrix3x3(Matrix2x3 other)
        {
            M00 = other.M00;
            M01 = other.M01;
            M02 = other.M02;

            M10 = other.M10;
            M11 = other.M11;
            M12 = other.M12;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = 0.0f;
        }

        public Matrix3x3(Matrix3x2 other)
        {
            M00 = other.M00;
            M01 = other.M01;
            M02 = 0.0f;

            M10 = other.M10;
            M11 = other.M11;
            M12 = 0.0f;

            M20 = other.M20;
            M21 = other.M21;
            M22 = 0.0f;
        }

        public Matrix3x3(Matrix3x3 other)
        {
            M00 = other.M00;
            M01 = other.M01;
            M02 = other.M02;

            M10 = other.M10;
            M11 = other.M11;
            M12 = other.M12;

            M20 = other.M20;
            M21 = other.M21;
            M22 = other.M22;
        }

        public Matrix3x3(float m00, float m01, float m02,
                         float m10, float m11, float m12,
                         float m20, float m21, float m22)
        {
            M00 = m00;
            M01 = m01;
            M02 = m02;

            M10 = m10;
            M11 = m11;
            M12 = m12;

            M20 = m20;
            M21 = m21;
            M22 = m22;
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
            if (obj is Matrix3x3)
            {
                return Equals((Matrix3x3)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return M00.GetHashCode() + M01.GetHashCode() + M02.GetHashCode() +
                       M10.GetHashCode() + M11.GetHashCode() + M12.GetHashCode() +
                       M20.GetHashCode() + M21.GetHashCode() + M22.GetHashCode();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Matrix3x3: [[{0}, {1}, {2}], " +
                                             "[{3}, {4}, {5}], " +
                                             "[{6}, {7}, {8}]]",
                                 M00, M01, M02, M10, M11, M12, M20, M21, M22);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>

        public bool Equals(Matrix3x3 other)
        {
            return this == other;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>        
        public void Fill(float value)
        {
            M00 = value;
            M01 = value;
            M02 = value;

            M10 = value;
            M11 = value;
            M12 = value;

            M20 = value;
            M21 = value;
            M22 = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetToIdentity()
        {
            M00 = 1.0f;
            M01 = 0.0f;
            M02 = 0.0f;

            M10 = 0.0f;
            M11 = 1.0f;
            M12 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetToZero()
        {
            M00 = 0.0f;
            M01 = 0.0f;
            M02 = 0.0f;

            M10 = 0.0f;
            M11 = 0.0f;
            M12 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>       
        public void Transpose()
        {
            MathHelper.Swap(ref M01, ref M10);
            MathHelper.Swap(ref M02, ref M20);
            MathHelper.Swap(ref M12, ref M21);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>       
        public void Rotate(float angle)
        {
            float s = MathF.Sin(angle);
            float c = MathF.Cos(angle);
            float temp = 0.0f;

            M00 = (temp = M00) * c + M10 * s;
            M10 = M10 * c - temp * s;

            M01 = (temp = M01) * c + M11 * s;
            M11 = M11 * c - temp * s;

            M02 = (temp = M02) * c + M12 * s;
            M12 = M12 * c - temp * s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>       
        public void Scale(float sx, float sy)
        {
            M00 *= sx;
            M01 *= sx;
            M02 *= sx;
            M10 *= sy;
            M11 *= sy;
            M12 *= sy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>       
        public void Shear(float x, float y)
        {
            float temp = 0.0f;
                        
            M00 = (temp = M00) + M01  * x;
            M01 += temp * y;

            M10 += (temp = M10) + M11 * x;
            M11 += temp * y;

            M20 += (temp = M20) * x;
            M21 += temp * y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scale"></param>        
        public void Scale(in Vector2 scale) => Scale(scale.X, scale.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>        
        public void Translate(float dx, float dy)
        {
            M20 += M00 * dx + M10 * dy;
            M21 += M01 * dx + M11 * dy;
            M22 += M02 * dx + M12 * dy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="translate"></param>       
        public void Translate(in Vector2 translate) => Translate(translate.X, translate.Y);

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="axisAngle"></param>
        /// <returns></returns>
        public static Matrix3x3 FromAxisAngle(in AxisAngle axisAngle)
        {
            FromAxisAngle(axisAngle, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static Matrix3x3 FromEulerAngles(in EulerAngles eulerAngles, MathF.RotationOrder order)
        {
            FromEulerAngles(eulerAngles, order, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix3x3 FromEulerAnglesXYZ(in EulerAngles eulerAngles)
        {
            FromEulerAnglesXYZ(eulerAngles, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix3x3 FromEulerAnglesXZY(in EulerAngles eulerAngles)
        {
            FromEulerAnglesXZY(eulerAngles, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix3x3 FromEulerAnglesYXZ(in EulerAngles eulerAngles)
        {
            FromEulerAnglesYXZ(eulerAngles, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix3x3 FromEulerAnglesYZX(in EulerAngles eulerAngles)
        {
            FromEulerAnglesYXZ(eulerAngles, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix3x3 FromEulerAnglesZXY(in EulerAngles eulerAngles)
        {
            FromEulerAnglesZXY(eulerAngles, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix3x3 FromEulerAnglesZYX(in EulerAngles eulerAngles)
        {
            FromEulerAnglesZYX(eulerAngles, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix3x3 FromEulerAnglesXYX(in EulerAngles eulerAngles)
        {
            FromEulerAnglesXYX(eulerAngles, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix3x3 FromEulerAnglesXZX(in EulerAngles eulerAngles)
        {
            FromEulerAnglesXZX(eulerAngles, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix3x3 FromEulerAnglesYXY(in EulerAngles eulerAngles)
        {
            FromEulerAnglesYXY(eulerAngles, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix3x3 FromEulerAnglesYZY(in EulerAngles eulerAngles)
        {
            FromEulerAnglesYXY(eulerAngles, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix3x3 FromEulerAnglesZXZ(in EulerAngles eulerAngles)
        {
            FromEulerAnglesZXZ(eulerAngles, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix3x3 FromEulerAnglesZYZ(in EulerAngles eulerAngles)
        {
            FromEulerAnglesZYZ(eulerAngles, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quaternion"></param>
        /// <returns></returns>
        public static Matrix3x3 FromQuaternion(in Quaternion quaternion)
        {
            FromQuaternion(in quaternion, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix3x3 Transpose(in Matrix3x3 matrix)
        {
            Transpose(matrix, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static void FromEulerAngles(in EulerAngles eulerAngles, MathF.RotationOrder order, out Matrix3x3 result)
        {
            switch (order)
            {
                case MathF.RotationOrder.XYZ:
                    FromEulerAnglesXYZ(eulerAngles, out result);
                    break;

                case MathF.RotationOrder.XZY:
                    FromEulerAnglesXZY(eulerAngles, out result);
                    break;

                case MathF.RotationOrder.YXZ:
                    FromEulerAnglesYXZ(eulerAngles, out result);
                    break;

                case MathF.RotationOrder.YZX:
                    FromEulerAnglesYZX(eulerAngles, out result);
                    break;

                case MathF.RotationOrder.ZXY:
                    FromEulerAnglesZXY(eulerAngles, out result);
                    break;

                case MathF.RotationOrder.ZYX:
                    FromEulerAnglesZYX(eulerAngles, out result);
                    break;

                case MathF.RotationOrder.XYX:
                    FromEulerAnglesXYX(eulerAngles, out result);
                    break;

                case MathF.RotationOrder.XZX:
                    FromEulerAnglesXZX(eulerAngles, out result);
                    break;

                case MathF.RotationOrder.YXY:
                    FromEulerAnglesYXY(eulerAngles, out result);
                    break;

                case MathF.RotationOrder.YZY:
                    FromEulerAnglesYZY(eulerAngles, out result);
                    break;

                case MathF.RotationOrder.ZXZ:
                    FromEulerAnglesZXZ(eulerAngles, out result);
                    break;

                case MathF.RotationOrder.ZYZ:
                    FromEulerAnglesZYZ(eulerAngles, out result);
                    break;

                default:
                    FromEulerAnglesZXY(eulerAngles, out result);
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="axisAngle"></param>
        /// <param name="result"></param>
        public static void FromAxisAngle(in AxisAngle axisAngle, out Matrix3x3 result)
        {
            float cos = MathF.Cos(axisAngle.Angle);
            float sin = MathF.Sin(axisAngle.Angle);

            float c0 = 1.0f - cos;
            float x2 = axisAngle.Axis.X * axisAngle.Axis.X;
            float y2 = axisAngle.Axis.Y * axisAngle.Axis.Y;
            float z2 = axisAngle.Axis.Z * axisAngle.Axis.Z;

            float xy = axisAngle.Axis.X * axisAngle.Axis.Y;
            float xz = axisAngle.Axis.X * axisAngle.Axis.Z;
            float yz = axisAngle.Axis.Y * axisAngle.Axis.Z;

            float xs = axisAngle.Axis.X * sin;
            float ys = axisAngle.Axis.Y * sin;
            float zs = axisAngle.Axis.Z * sin;

            result.M00 = cos + c0 * x2;
            result.M10 = c0 * xy - zs;
            result.M20 = c0 * xz + ys;

            result.M01 = c0 * xy + zs;
            result.M11 = cos + c0 * y2;
            result.M21 = c0 * yz - xs;

            result.M02 = c0 * xz - ys;
            result.M12 = c0 * yz + xs;
            result.M22 = cos + c0 * z2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="euler"></param>
        /// <param name="result"></param>
        public static void FromEulerAnglesXYZ(in EulerAngles eulerAngles, out Matrix3x3 result)
        {
            float cp = MathF.Cos(eulerAngles.Pitch);
            float sp = MathF.Sin(eulerAngles.Pitch);
            float cy = MathF.Cos(eulerAngles.Yaw);
            float sy = MathF.Sin(eulerAngles.Yaw);
            float cr = MathF.Cos(eulerAngles.Roll);
            float sr = MathF.Sin(eulerAngles.Roll);

            result.M00 = cy * cr;
            result.M01 = -cy * sr;
            result.M02 = sy;

            result.M10 = cr * sp * sy + cp * sr;
            result.M11 = cp * cr - sp * sy * sr;
            result.M12 = -cy * sp;

            result.M20 = -cp * cr * sy + sp * sr;
            result.M21 = cr * sp + cp * sy * sr;
            result.M22 = cp * cy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="euler"></param>
        /// <param name="result"></param>
        public static void FromEulerAnglesXZY(in EulerAngles eulerAngles, out Matrix3x3 result)
        {
            float cp = MathF.Cos(eulerAngles.Pitch);
            float sp = MathF.Sin(eulerAngles.Pitch);
            float cy = MathF.Cos(eulerAngles.Yaw);
            float sy = MathF.Sin(eulerAngles.Yaw);
            float cr = MathF.Cos(eulerAngles.Roll);
            float sr = MathF.Sin(eulerAngles.Roll);

            result.M00 = cy * cr;
            result.M01 = -sr;
            result.M02 = cr * sy;

            result.M10 = sp * sy + cp * cy * sr;
            result.M11 = cp * cr;
            result.M12 = cy * sp + cp * sy * sr;

            result.M20 = cp * sy + cy * sp * sr;
            result.M21 = -cr * sp;
            result.M22 = cp * cy - sp * sy * sr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="euler"></param>
        /// <param name="result"></param>
        public static void FromEulerAnglesYXZ(in EulerAngles eulerAngles, out Matrix3x3 result)
        {
            float cp = MathF.Cos(eulerAngles.Pitch);
            float sp = MathF.Sin(eulerAngles.Pitch);
            float cy = MathF.Cos(eulerAngles.Yaw);
            float sy = MathF.Sin(eulerAngles.Yaw);
            float cr = MathF.Cos(eulerAngles.Roll);
            float sr = MathF.Sin(eulerAngles.Roll);

            result.M00 = cy * cr + sp * sy * sr;
            result.M01 = cp * sp * sy - cy * sr;
            result.M02 = cp * sy;

            result.M10 = cp * sr;
            result.M11 = cp * cr;
            result.M12 = -sp;

            result.M20 = -cr * sy + cy * sp * sr;
            result.M21 = cy * cr * sp + sy * sr;
            result.M22 = cp * cy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="euler"></param>
        /// <param name="result"></param>
        public static void FromEulerAnglesYZX(in EulerAngles eulerAngles, out Matrix3x3 result)
        {
            float cp = MathF.Cos(eulerAngles.Pitch);
            float sp = MathF.Sin(eulerAngles.Pitch);
            float cy = MathF.Cos(eulerAngles.Yaw);
            float sy = MathF.Sin(eulerAngles.Yaw);
            float cr = MathF.Cos(eulerAngles.Roll);
            float sr = MathF.Sin(eulerAngles.Roll);

            result.M00 = cy * cr;
            result.M01 = sp * sy - cp * cy * sr;
            result.M02 = cp * sy + cy * sp * sr;

            result.M10 = sr;
            result.M11 = cp * cr;
            result.M12 = -cr * sp;

            result.M20 = -cp * sy;
            result.M21 = cy * sp + cp * sy * sr;
            result.M22 = cp * cy - sp * sy * sr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="euler"></param>
        /// <param name="result"></param>
        public static void FromEulerAnglesZXY(in EulerAngles eulerAngles, out Matrix3x3 result)
        {
            float cp = MathF.Cos(eulerAngles.Pitch);
            float sp = MathF.Sin(eulerAngles.Pitch);
            float cy = MathF.Cos(eulerAngles.Yaw);
            float sy = MathF.Sin(eulerAngles.Yaw);
            float cr = MathF.Cos(eulerAngles.Roll);
            float sr = MathF.Sin(eulerAngles.Roll);

            result.M00 = cy * cr - sp * sy * sr;
            result.M01 = -cp * sr;
            result.M02 = cr * sy + cy * sp * sr;

            result.M10 = cp * sp * sy + cy * sr;
            result.M11 = cp * cr;
            result.M12 = -cy * cr * sp + sy * sr;

            result.M20 = -cp * sy;
            result.M21 = sp;
            result.M22 = cp * cy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="euler"></param>
        /// <param name="result"></param>
        public static void FromEulerAnglesZYX(in EulerAngles eulerAngles, out Matrix3x3 result)
        {
            float cp = MathF.Cos(eulerAngles.Pitch);
            float sp = MathF.Sin(eulerAngles.Pitch);
            float cy = MathF.Cos(eulerAngles.Yaw);
            float sy = MathF.Sin(eulerAngles.Yaw);
            float cr = MathF.Cos(eulerAngles.Roll);
            float sr = MathF.Sin(eulerAngles.Roll);

            result.M00 = cy * cr;
            result.M01 = cr * sp * sy - cp * sr;
            result.M02 = cp * cr * sy + sp * sr;

            result.M10 = cy * cr;
            result.M11 = cp * cr + sp * sy * sr;
            result.M12 = -cr * sp + cp * sy * sr;

            result.M20 = -sy;
            result.M21 = cy * sp;
            result.M22 = cp * cy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="quaternion"></param>
        public static void FromEulerAnglesXYX(in EulerAngles eulerAngles, out Matrix3x3 result)
        {
            float cp = MathF.Cos(eulerAngles.Pitch);
            float sp = MathF.Sin(eulerAngles.Pitch);
            float cy = MathF.Cos(eulerAngles.Yaw);
            float sy = MathF.Sin(eulerAngles.Yaw);
            float cr = MathF.Cos(eulerAngles.Roll);
            float sr = MathF.Sin(eulerAngles.Roll);

            result.M00 = cy;
            result.M01 = sy * sr;
            result.M02 = sy * cr;

            result.M10 = sy * sp;
            result.M11 = cp * cr - cy * sp * sr;
            result.M12 = -cy * cr * sp - cp * sr;

            result.M20 = -sy * cp;
            result.M21 = cr * sp + cy * cp * sr;
            result.M22 = cy * cp * cr - sp * sr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="quaternion"></param>
        public static void FromEulerAnglesXZX(in EulerAngles eulerAngles, out Matrix3x3 result)
        {
            float cp = MathF.Cos(eulerAngles.Pitch);
            float sp = MathF.Sin(eulerAngles.Pitch);
            float cy = MathF.Cos(eulerAngles.Yaw);
            float sy = MathF.Sin(eulerAngles.Yaw);
            float cr = MathF.Cos(eulerAngles.Roll);
            float sr = MathF.Sin(eulerAngles.Roll);

            result.M00 = cr;
            result.M01 = -sr * cy;
            result.M02 = sr * sy;

            result.M10 = sr * cp;
            result.M11 = cr * cp * cy - sp * sy;
            result.M12 = -cy * sp - cr * cp * sy;

            result.M20 = sr * sp;
            result.M21 = cr * cy * sp + cp * sy;
            result.M22 = cp * cy - cr * sp * sy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="quaternion"></param>
        public static void FromEulerAnglesYXY(in EulerAngles eulerAngles, out Matrix3x3 result)
        {
            float cp = MathF.Cos(eulerAngles.Pitch);
            float sp = MathF.Sin(eulerAngles.Pitch);
            float cy = MathF.Cos(eulerAngles.Yaw);
            float sy = MathF.Sin(eulerAngles.Yaw);
            float cr = MathF.Cos(eulerAngles.Roll);
            float sr = MathF.Sin(eulerAngles.Roll);

            result.M00 = cy * cr - cp * sy * sr;
            result.M01 = sp * sy;
            result.M02 = cp * cr * sp + cy * sr;

            result.M10 = sp * sr;
            result.M11 = cp;
            result.M12 = -sp * cr;

            result.M20 = -cr * sr - cp * cy * sr;
            result.M21 = sp * cy;
            result.M22 = cp * cy * cr - sy * sr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="quaternion"></param>
        public static void FromEulerAnglesYZY(in EulerAngles eulerAngles, out Matrix3x3 result)
        {
            float cp = MathF.Cos(eulerAngles.Pitch);
            float sp = MathF.Sin(eulerAngles.Pitch);
            float cy = MathF.Cos(eulerAngles.Yaw);
            float sy = MathF.Sin(eulerAngles.Yaw);
            float cr = MathF.Cos(eulerAngles.Roll);
            float sr = MathF.Sin(eulerAngles.Roll);

            result.M00 = cr * cy * cp - sy * sp;
            result.M01 = -sr * cy;
            result.M02 = cp * sy + cr * cy * sp;

            result.M10 = sr * cp;
            result.M11 = cr;
            result.M12 = sr * sp;

            result.M20 = -cr * cp * sy - cy * sp;
            result.M21 = sr * sy;
            result.M22 = cy * cp - cr * sy * sp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="quaternion"></param>
        public static void FromEulerAnglesZXZ(in EulerAngles eulerAngles, out Matrix3x3 result)
        {
            // yaw = z1;
            float cp = MathF.Cos(eulerAngles.Pitch);
            float sp = MathF.Sin(eulerAngles.Pitch);
            float cy = MathF.Cos(eulerAngles.Yaw);
            float sy = MathF.Sin(eulerAngles.Yaw);
            float cr = MathF.Cos(eulerAngles.Roll);
            float sr = MathF.Sin(eulerAngles.Roll);

            result.M00 = cr * cy - cp * sr * sy;
            result.M01 = -cp * cy * sr - cr * sy;
            result.M02 = sp * sr;

            result.M10 = cy * sr + cp * cr * sy;
            result.M11 = cp * cr * cy - sr * sy;
            result.M12 = -sp * cr;

            result.M20 = sp * sy;
            result.M21 = sp * cy;
            result.M22 = cp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="quaternion"></param>
        public static void FromEulerAnglesZYZ(in EulerAngles eulerAngles, out Matrix3x3 result)
        {
            float cp = MathF.Cos(eulerAngles.Pitch);
            float sp = MathF.Sin(eulerAngles.Pitch);
            float cy = MathF.Cos(eulerAngles.Yaw);
            float sy = MathF.Sin(eulerAngles.Yaw);
            float cr = MathF.Cos(eulerAngles.Roll);
            float sr = MathF.Sin(eulerAngles.Roll);

            result.M00 = cy * cr * cp - sr * sp;
            result.M01 = -cp * sr - cy * cr * sp;
            result.M02 = sy * cr;

            result.M10 = cy * cp * sr;
            result.M11 = cr * cp - cy * sr * sp;
            result.M12 = sy * sr;

            result.M20 = -sy * cp;
            result.M21 = sy * sp;
            result.M22 = cy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quaternion"></param>
        /// <param name="result"></param>
        public static void FromQuaternion(in Quaternion quaternion, out Matrix3x3 result)
        {
            // Compute rotation matrix
            float x2 = quaternion.X + quaternion.Y;
            float y2 = quaternion.Y + quaternion.Y;
            float z2 = quaternion.Z + quaternion.Z;

            float wx2 = quaternion.W * x2;
            float wy2 = quaternion.W * y2;
            float wz2 = quaternion.W * z2;
            float xx2 = quaternion.X * x2;
            float xy2 = quaternion.X * y2;
            float xz2 = quaternion.X * z2;
            float yy2 = quaternion.Y * y2;
            float yz2 = quaternion.Y * z2;
            float zz2 = quaternion.Z * z2;

            result.M00 = 1.0f - yy2 - zz2;
            result.M10 = xy2 - wz2;
            result.M20 = xz2 + wy2;

            result.M01 = xy2 + wz2;
            result.M11 = 1.0f - xx2 - zz2;
            result.M21 = yz2 - wx2;

            result.M02 = xz2 - wy2;
            result.M12 = yz2 + wx2;
            result.M22 = 1.0f - xx2 - yy2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        public static bool Inverse(in Matrix3x3 matrix, out Matrix3x3 result)
        {
            result.M00 = matrix.M11 * matrix.M22 - matrix.M12 * matrix.M21;
            result.M01 = matrix.M02 * matrix.M21 - matrix.M01 * matrix.M22;
            result.M02 = matrix.M01 * matrix.M12 - matrix.M02 * matrix.M11;

            result.M10 = matrix.M12 * matrix.M20 - matrix.M10 * matrix.M22;
            result.M11 = matrix.M00 * matrix.M22 - matrix.M02 * matrix.M20;
            result.M12 = matrix.M02 * matrix.M10 - matrix.M00 * matrix.M12;

            result.M20 = matrix.M10 * matrix.M21 - matrix.M11 * matrix.M20;
            result.M21 = matrix.M01 * matrix.M20 - matrix.M00 * matrix.M21;
            result.M22 = matrix.M00 * matrix.M11 - matrix.M01 * matrix.M10;

            float det = matrix.M00 * result.M00 + matrix.M01 * result.M10 +
                        matrix.M02 * result.M20;

            if (MathF.Abs(det) <= MathF.Epsilon)
            {
                return false;
            }

            float invDet = 1.0f * det;

            result.M00 *= invDet;
            result.M01 *= invDet;
            result.M02 *= invDet;

            result.M10 *= invDet;
            result.M11 *= invDet;
            result.M12 *= invDet;

            result.M20 *= invDet;
            result.M21 *= invDet;
            result.M22 *= invDet;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>       
        public static void Transpose(in Matrix3x3 matrix, out Matrix3x3 result)
        {
            result.M00 = matrix.M00;
            result.M01 = matrix.M10;
            result.M02 = matrix.M20;

            result.M10 = matrix.M01;
            result.M11 = matrix.M11;
            result.M12 = matrix.M21;

            result.M20 = matrix.M02;
            result.M21 = matrix.M12;
            result.M22 = matrix.M22;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Add(in Matrix3x3 left, float right, out Matrix3x3 result)
        {
            result.M00 = left.M00 + right;
            result.M01 = left.M01 + right;
            result.M02 = left.M02 + right;

            result.M10 = left.M10 + right;
            result.M11 = left.M11 + right;
            result.M12 = left.M12 + right;

            result.M20 = left.M20 + right;
            result.M21 = left.M21 + right;
            result.M22 = left.M22 + right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Add(in Matrix3x3 left, in Matrix3x3 right, out Matrix3x3 result)
        {
            result.M00 = left.M00 + right.M00;
            result.M01 = left.M01 + right.M01;
            result.M02 = left.M02 + right.M02;

            result.M10 = left.M10 + right.M10;
            result.M11 = left.M11 + right.M11;
            result.M12 = left.M12 + right.M12;

            result.M20 = left.M20 + right.M20;
            result.M21 = left.M21 + right.M21;
            result.M22 = left.M22 + right.M22;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Subtract(in Matrix3x3 left, float right, out Matrix3x3 result)
        {
            result.M00 = left.M00 - right;
            result.M01 = left.M01 - right;
            result.M02 = left.M02 - right;

            result.M10 = left.M10 - right;
            result.M11 = left.M11 - right;
            result.M12 = left.M12 - right;

            result.M20 = left.M20 - right;
            result.M21 = left.M21 - right;
            result.M22 = left.M22 - right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Subtract(in Matrix3x3 left, in Matrix3x3 right, out Matrix3x3 result)
        {
            result.M00 = left.M00 - right.M00;
            result.M01 = left.M01 - right.M01;
            result.M02 = left.M02 - right.M02;

            result.M10 = left.M10 - right.M10;
            result.M11 = left.M11 - right.M11;
            result.M12 = left.M12 - right.M12;

            result.M20 = left.M20 - right.M20;
            result.M21 = left.M21 - right.M21;
            result.M22 = left.M22 - right.M22;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Multiply(in Matrix3x3 left, float right, out Matrix3x3 result)
        {
            result.M00 = left.M00 * right;
            result.M01 = left.M01 * right;
            result.M02 = left.M02 * right;

            result.M10 = left.M10 * right;
            result.M11 = left.M11 * right;
            result.M12 = left.M12 * right;

            result.M20 = left.M20 * right;
            result.M21 = left.M21 * right;
            result.M22 = left.M22 * right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Multiply(in Matrix3x3 left, in Matrix3x2 right, out Matrix3x2 result)
        {
            result.M00 = left.M00 * right.M00 + left.M01 * right.M10 + 
                         left.M02 * right.M20;
            result.M01 = left.M00 * right.M01 + left.M01 * right.M11 + 
                         left.M02 * right.M21;

            result.M10 = left.M10 * right.M00 + left.M11 * right.M10 + 
                         left.M12 * right.M20;
            result.M11 = left.M10 * right.M01 + left.M11 * right.M11 + 
                         left.M12 * right.M21;

            result.M20 = left.M20 * right.M00 + left.M21 * right.M10 + 
                         left.M22 * right.M20;
            result.M21 = left.M20 * right.M01 + left.M21 * right.M11 + 
                         left.M22 * right.M21;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Multiply(in Matrix3x3 left, in Matrix3x3 right, out Matrix3x3 result)
        {
            result.M00 = left.M00 * right.M00 + left.M01 * right.M10 + 
                         left.M02 * right.M20;
            result.M01 = left.M00 * right.M01 + left.M01 * right.M11 + 
                         left.M02 * right.M21;
            result.M02 = left.M00 * right.M02 + left.M01 * right.M12 + 
                         left.M02 * right.M22;

            result.M10 = left.M10 * right.M00 + left.M11 * right.M10 + 
                         left.M12 * right.M20;
            result.M11 = left.M10 * right.M01 + left.M11 * right.M11 + 
                         left.M12 * right.M21;
            result.M12 = left.M10 * right.M02 + left.M11 * right.M12 + 
                         left.M12 * right.M22;

            result.M20 = left.M20 * right.M00 + left.M21 * right.M10 + 
                         left.M22 * right.M20;
            result.M21 = left.M20 * right.M01 + left.M21 * right.M11 + 
                         left.M22 * right.M21;
            result.M22 = left.M20 * right.M02 + left.M21 * right.M12 + 
                         left.M22 * right.M22;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Multiply(in Matrix3x3 left, in Matrix3x4 right, out Matrix3x4 result)
        {
            result.M00 = left.M00 * right.M00 + left.M01 * right.M10 + 
                         left.M02 * right.M20;
            result.M01 = left.M00 * right.M01 + left.M01 * right.M11 + 
                         left.M02 * right.M21;
            result.M02 = left.M00 * right.M02 + left.M01 * right.M12 + 
                         left.M02 * right.M22;
            result.M03 = left.M00 * right.M03 + left.M01 * right.M13 + 
                         left.M02 * right.M23;

            result.M10 = left.M10 * right.M00 + left.M11 * right.M10 + 
                         left.M12 * right.M20;
            result.M11 = left.M10 * right.M01 + left.M11 * right.M11 + 
                         left.M12 * right.M21;
            result.M12 = left.M10 * right.M02 + left.M11 * right.M12 + 
                         left.M12 * right.M22;
            result.M13 = left.M10 * right.M02 + left.M11 * right.M13 + 
                         left.M02 * right.M23;

            result.M20 = left.M20 * right.M00 + left.M21 * right.M10 + 
                         left.M22 * right.M20;
            result.M21 = left.M20 * right.M01 + left.M21 * right.M11 + 
                         left.M22 * right.M21;
            result.M22 = left.M20 * right.M02 + left.M21 * right.M12 + 
                         left.M22 * right.M22;
            result.M23 = left.M20 * right.M03 + left.M21 * right.M13 + 
                         left.M02 * right.M23;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Multiply(in Matrix3x3 left, in Vector3 right, out Vector3 result)
        {
            result.X = left.M00 * right.X + left.M01 * right.Y + 
                       left.M02 * right.Z;
            result.Y = left.M10 * right.X + left.M11 * right.Y + 
                       left.M12 * right.Z;
            result.Z = left.M20 * right.X + left.M21 * right.Y + 
                       left.M22 * right.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Multiply(in Vector3 left, in Matrix3x3 right, out Vector3 result)
        {
            result.X = left.X * right.M00 + left.Y * right.M10 + 
                       left.Z * right.M20;
            result.Y = left.X * right.M01 + left.Y * right.M11 + 
                       left.Z * right.M21;
            result.Z = left.X * right.M02 + left.Y * right.M12 + 
                       left.Z * right.M22;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        public static void Negate(in Matrix3x3 matrix, out Matrix3x3 result)
        {
            result.M00 = -matrix.M00;
            result.M01 = -matrix.M01;
            result.M02 = -matrix.M02;

            result.M10 = -matrix.M10;
            result.M11 = -matrix.M11;
            result.M12 = -matrix.M12;

            result.M20 = -matrix.M20;
            result.M21 = -matrix.M21;
            result.M22 = -matrix.M22;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Divide(in Matrix3x3 left, float right, out Matrix3x3 result)
        {
            if (right == 0.0f)
            {
                result = Matrix3x3.Zero;
                return;
            }

            right = 1.0f / right;

            result.M00 = left.M00 * right;
            result.M01 = left.M01 * right;
            result.M02 = left.M02 * right;

            result.M10 = left.M10 * right;
            result.M11 = left.M11 * right;
            result.M12 = left.M12 * right;

            result.M20 = left.M20 * right;
            result.M21 = left.M21 * right;
            result.M22 = left.M22 * right;
        }

        #endregion Public Static Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>       
        public static Matrix3x3 operator +(in Matrix3x3 left, in Matrix3x3 right)
        {
            Add(left, right, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>       
        public static Matrix3x3 operator +(in Matrix3x3 left, float right)
        {
            Add(left, right, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix3x3 operator -(in Matrix3x3 matrix)
        {
            Negate(matrix, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix3x3 operator -(in Matrix3x3 left, float right)
        {
            Subtract(left, right, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>       
        public static Matrix3x3 operator -(in Matrix3x3 left, in Matrix3x3 right)
        {
            Subtract(left, right, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        
        public static Matrix3x3 operator *(in Matrix3x3 left, float right)
        {
            Subtract(left, right, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>       
        public static Matrix3x3 operator *(float left, in Matrix3x3 right)
        {
            Multiply(right, left, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix3x2 operator *(in Matrix3x3 left, in Matrix3x2 right)
        {
            Multiply(left, right, out Matrix3x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix3x3 operator *(in Matrix3x3 left, in Matrix3x3 right)
        {
            Multiply(left, right, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>       
        public static Matrix3x4 operator *(in Matrix3x3 left, in Matrix3x4 right)
        {
            Multiply(left, right, out Matrix3x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>       
        public static Vector3 operator *(in Matrix3x3 left, in Vector3 right)
        {
            Multiply(left, right, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Vector3 operator *(in Vector3 left, in Matrix3x3 right)
        {
            Multiply(left, right, out Vector3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix3x3 operator /(in Matrix3x3 left, float right)
        {
            Divide(left, right, out Matrix3x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Matrix3x3 left, in Matrix3x3 right)
        {
            return (left.M00 == right.M00 && left.M01 == right.M01 && 
                    left.M02 == right.M02 &&
                    left.M10 == right.M10 && left.M11 == right.M11 && 
                    left.M12 == right.M12 &&
                    left.M20 == right.M20 && left.M21 == right.M21 && 
                    left.M22 == right.M22);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Matrix3x3 left, in Matrix3x3 right)
        {
            return (left.M00 != right.M00 || left.M01 != right.M01 || 
                    left.M02 != right.M02 ||
                    left.M10 != right.M10 || left.M11 != right.M11 || 
                    left.M12 != right.M12 ||
                    left.M20 != right.M20 || left.M21 != right.M21 || 
                    left.M22 != right.M22);
        }

        #endregion Operator Overload
    }
}
