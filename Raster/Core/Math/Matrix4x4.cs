using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Raster.Core.Math.Geometry;

namespace Raster.Core.Math
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Matrix4x4 : IEquatable<Matrix4x4>
    {
        #region Private Instance Fields
        /// <summary>
        /// 
        /// </summary>
        private const float BillboardEpsilon    = 1e-4f;
        /// <summary>
        /// 
        /// </summary>
        private const float BillboardMinAngle   = 1.0f - (0.1f * (MathF.PI / 180.0f));

        #endregion Private Instance Fields

        #region Public Instance Fields
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
        public float M03;

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
        public float M13;

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
        /// <summary>
        /// 
        /// </summary>
        public float M23;

        /// <summary>
        /// 
        /// </summary>
        public float M30;
        /// <summary>
        /// 
        /// </summary>
        public float M31;
        /// <summary>
        /// 
        /// </summary>
        public float M32;
        /// <summary>
        /// 
        /// </summary>
        public float M33;
        #endregion

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        public static readonly Matrix4x4 Zero       = new Matrix4x4(0.0f, 0.0f, 0.0f, 0.0f,
                                                                    0.0f, 0.0f, 0.0f, 0.0f,
                                                                    0.0f, 0.0f, 0.0f, 0.0f,
                                                                    0.0f, 0.0f, 0.0f, 0.0f);

        public static readonly Matrix4x4 Identity   = new Matrix4x4(1.0f, 0.0f, 0.0f, 0.0f,
                                                                    0.0f, 1.0f, 0.0f, 0.0f,
                                                                    0.0f, 0.0f, 1.0f, 0.0f,
                                                                    0.0f, 0.0f, 0.0f, 1.0f);

        #endregion Public Static Methods

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public Vector4 Row0
        {
            get { return new Vector4(M00, M01, M02, M03); }
            set
            {
                M00 = value.X;
                M01 = value.Y;
                M02 = value.Z;
                M03 = value.W;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector4 Row1
        {
            get { return new Vector4(M10, M11, M12, M13); }
            set
            {
                M10 = value.X;
                M11 = value.Y;
                M12 = value.Z;
                M13 = value.W;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector4 Row2
        {
            get { return new Vector4(M20, M21, M22, M23); }
            set
            {
                M20 = value.X;
                M21 = value.Y;
                M22 = value.Z;
                M23 = value.W;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector4 Row3
        {
            get { return new Vector4(M30, M31, M32, M33); }
            set
            {
                M30 = value.X;
                M31 = value.Y;
                M32 = value.Z;
                M33 = value.W;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector4 Column0
        {
            get { return new Vector4(M00, M10, M20, M30); }
            set
            {
                M00 = value.X;
                M10 = value.Y;
                M20 = value.Z;
                M30 = value.W;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector4 Column1
        {
            get { return new Vector4(M01, M11, M21, M31); }
            set
            {
                M01 = value.X;
                M11 = value.Y;
                M21 = value.Z;
                M31 = value.W;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector4 Column2
        {
            get { return new Vector4(M02, M12, M22, M32); }
            set
            {
                M02 = value.X;
                M12 = value.Y;
                M22 = value.Z;
                M32 = value.W;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector4 Column3
        {
            get { return new Vector4(M03, M13, M23, M33); }
            set
            {
                M03 = value.X;
                M13 = value.Y;
                M23 = value.Z;
                M33 = value.W;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Up
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
        public Vector3 Down
        {
            get { return new Vector3(-M10, -M11, -M12); }
            set
            {
                M10 = -value.X;
                M11 = -value.Y;
                M12 = -value.Z;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Left
        {
            get { return new Vector3(-M00, -M01, -M02); }
            set
            {
                M00 = -value.X;
                M01 = -value.Y;
                M02 = -value.Z;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Right
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
        public Vector3 Forward
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
        public Vector3 Backward
        {
            get { return new Vector3(-M20, -M21, -M22); }
            set
            {
                M20 = -value.X;
                M21 = -value.Y;
                M22 = -value.Z;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Quaternion Rotation
        {
            get { return Quaternion.Identity; }
            set
            {

            }
        }




        /// <summary>
        /// 
        /// </summary>
        public Vector3 Scale
        {
            get 
            {
                return new Vector3(
                    MathF.Sqrt(M00 * M00 + M01 * M01 + M02 * M02),
                    MathF.Sqrt(M10 * M10 + M11 * M11 + M12 * M12),
                    MathF.Sqrt(M20 * M20 + M21 * M21 + M22 * M22));
            }
            set
            {
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Translation
        {
            get { return new Vector3(M30, M31, M32); }
            set
            {
                M30 = value.X;
                M31 = value.Y;
                M32 = value.Z;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float Determinant
        {
            get
            {
                // a = M00, b = M01, c = M02, d = M03,
                // e = M10, f = M11, g = M12, h = M13,
                // i = M20, j = M21, k = M22, l = M23,
                // m = M30, n = M31, o = M32, p = M33
                float kp_lo = M22 * M33 - M23 * M32;
                float jp_ln = M21 * M33 - M23 * M31;
                float jo_kn = M21 * M32 - M22 * M31;
                float ip_lm = M20 * M33 - M23 * M30;
                float io_km = M20 * M32 - M22 * M30;
                float in_jm = M20 * M31 - M21 * M30;

                return M00 * (M11 * kp_lo - M12 * jp_ln + M13 * jo_kn) -
                       M01 * (M10 * kp_lo - M12 * ip_lm + M13 * io_km) +
                       M02 * (M10 * jp_ln - M11 * ip_lm + M13 * in_jm) -
                       M03 * (M10 * jo_kn - M11 * io_km + M12 * in_jm);
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
                return (M00 == 0.0f && M01 == 0.0f && M02 == 0.0f && M03 == 0.0f &&
                        M10 == 0.0f && M11 == 0.0f && M12 == 0.0f && M13 == 0.0f &&
                        M20 == 0.0f && M21 == 0.0f && M22 == 0.0f && M23 == 0.0f &&
                        M30 == 0.0f && M31 == 0.0f && M32 == 0.0f && M33 == 0.0f);
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
                return (M00 == 1.0f && M01 == 0.0f && M02 == 0.0f && M03 == 0.0f &&
                        M10 == 0.0f && M11 == 1.0f && M12 == 0.0f && M13 == 0.0f &&
                        M20 == 0.0f && M21 == 0.0f && M22 == 1.0f && M23 == 0.0f &&
                        M30 == 0.0f && M31 == 0.0f && M32 == 0.0f && M33 == 1.0f);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Matrix4x4 Inverted
        {
            get
            {
                Matrix4x4.Invert(this, out Matrix4x4 result);
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:  return M00;
                    case 1:  return M01;
                    case 2:  return M02;
                    case 3:  return M03;
                    case 4:  return M10;
                    case 5:  return M11;
                    case 6:  return M12;
                    case 7:  return M13;
                    case 8:  return M20;
                    case 9:  return M21;
                    case 10: return M22;
                    case 11: return M23;
                    case 12: return M30;
                    case 13: return M31;
                    case 14: return M32;
                    case 15: return M33;
                }

                throw new ArgumentOutOfRangeException("index");
            }

            set
            {
                switch (index)
                {
                    case 0:  M00 = value; break;
                    case 1:  M01 = value; break;
                    case 2:  M02 = value; break;
                    case 3:  M03 = value; break;
                    case 4:  M10 = value; break;
                    case 5:  M11 = value; break;
                    case 6:  M12 = value; break;
                    case 7:  M13 = value; break;
                    case 8:  M20 = value; break;
                    case 9:  M21 = value; break;
                    case 10: M22 = value; break;
                    case 11: M23 = value; break;
                    case 12: M30 = value; break;
                    case 13: M31 = value; break;
                    case 14: M32 = value; break;
                    case 15: M33 = value; break;
                    default: throw new ArgumentOutOfRangeException("index");
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public float this[int row, int column]
        {
            get
            {
                if (row < 0 || row > 3)
                {
                    throw new ArgumentOutOfRangeException("row", "Row and column from 0 to 3");
                }

                if (column < 0 || column > 3)
                {
                    throw new ArgumentOutOfRangeException("row", "Row and column from 0 to 3");
                }

                return this[row * 4 + column];
            }

            set
            {
                if (row < 0 || row > 3)
                {
                    throw new ArgumentOutOfRangeException("row", "Row and column from 0 to 3");
                }

                if (column < 0 || column > 3)
                {
                    throw new ArgumentOutOfRangeException("row", "Row and column from 0 to 3");
                }

                this[row * 4 + column] = value;
            }
        }

        #endregion Public Instance Properties

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Matrix4x4(float value)
        {
            M00 = value; M01 = value; M02 = value; M03 = value;
            M10 = value; M11 = value; M12 = value; M13 = value;
            M20 = value; M21 = value; M22 = value; M23 = value;
            M30 = value; M31 = value; M32 = value; M33 = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public Matrix4x4(in Matrix4x4 other)
        {
            M00 = other.M00; M01 = other.M01; M02 = other.M02; M03 = other.M03;
            M10 = other.M10; M11 = other.M11; M12 = other.M12; M13 = other.M13;
            M20 = other.M20; M21 = other.M21; M22 = other.M22; M23 = other.M23;
            M30 = other.M30; M31 = other.M31; M32 = other.M32; M33 = other.M33;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m00"></param>
        /// <param name="m01"></param>
        /// <param name="m02"></param>
        /// <param name="m03"></param>
        /// <param name="m10"></param>
        /// <param name="m11"></param>
        /// <param name="m12"></param>
        /// <param name="m13"></param>
        /// <param name="m20"></param>
        /// <param name="m21"></param>
        /// <param name="m22"></param>
        /// <param name="m23"></param>
        /// <param name="m30"></param>
        /// <param name="m31"></param>
        /// <param name="m32"></param>
        /// <param name="m33"></param>
        public Matrix4x4(float m00, float m01, float m02, float m03,
                         float m10, float m11, float m12, float m13,
                         float m20, float m21, float m22, float m23,
                         float m30, float m31, float m32, float m33)
        {
            M00 = m00; M01 = m01; M02 = m02; M03 = m03;
            M10 = m10; M11 = m11; M12 = m12; M13 = m12;
            M20 = m20; M21 = m21; M22 = m22; M23 = m23;
            M30 = m30; M31 = m31; M32 = m32; M33 = m33;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        public Matrix4x4(in Vector3 translation, in Quaternion rotation, in Vector3 scale)
        {
            float x2 = rotation.X + rotation.X;
            float y2 = rotation.Y + rotation.Y;
            float z2 = rotation.Z + rotation.Z;

            float wx2 = rotation.W * x2;
            float wy2 = rotation.W * y2;
            float wz2 = rotation.W * z2;
            float xx2 = rotation.X * x2;
            float xy2 = rotation.X * y2;
            float xz2 = rotation.X * z2;
            float yy2 = rotation.Y * y2;
            float yz2 = rotation.Y * z2;
            float zz2 = rotation.Z * z2;

            M00 = (1.0f - yy2 - zz2) * scale.X; 
            M01 = (xy2 + wz2) * scale.X;        
            M02 = (xz2 - wy2) * scale.X;        
            M03 = 0.0f;
            
            M10 = (xy2 - wz2) * scale.Y;        
            M11 = (1.0f - xx2 - zz2) * scale.Y; 
            M12 = (yz2 + wx2) * scale.Y;        
            M13 = 0.0f;
            
            M20 = (xz2 + wy2) * scale.Z;        
            M21 = (yz2 - wx2) * scale.Z;        
            M22 = (1.0f - xx2 - yy2) * scale.Z; 
            M23 = 0.0f;
            
            M30 = translation.X;                
            M31 = translation.Y;                
            M32 = translation.Z;                
            M33 = 1.0f;
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
            if (obj is Matrix4x4)
            {
                return Equals((Matrix4x4)obj);
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
                return M00.GetHashCode() + M01.GetHashCode() + M02.GetHashCode() + M02.GetHashCode() +
                       M10.GetHashCode() + M11.GetHashCode() + M12.GetHashCode() + M12.GetHashCode() +
                       M20.GetHashCode() + M21.GetHashCode() + M22.GetHashCode() + M22.GetHashCode() +
                       M30.GetHashCode() + M31.GetHashCode() + M32.GetHashCode() + M32.GetHashCode();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Matrix4x4: [[{0}, {1}, {2},  {3}], " +
                                             "[{4}, {5}, {6},  {7}], " +
                                             "[{8}, {9}, {10}, {11}], " +
                                             "[{12},{13}, {14}, {15}]]",
                                 M00, M01, M02, M03, M10, M11, M12, M13, M20, M21, M22, M23, M30, M31, M32, M33);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>

        public bool Equals(Matrix4x4 other)
        {
            return this == other;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public void Add(float value)
        {
            M00 += value; M01 += value; M02 += value; M03 += value;
            M10 += value; M11 += value; M12 += value; M13 += value;
            M20 += value; M21 += value; M22 += value; M23 += value;
            M30 += value; M31 += value; M32 += value; M33 += value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public void Add(in Matrix4x4 other)
        {
            M00 += other.M00; M01 += other.M01; M02 += other.M02; M03 += other.M03;
            M10 += other.M10; M11 += other.M11; M12 += other.M12; M13 += other.M13;
            M20 += other.M20; M21 += other.M21; M22 += other.M22; M23 += other.M23;
            M30 += other.M30; M31 += other.M31; M32 += other.M32; M33 += other.M33;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Subtract(float value)
        {
            M00 -= value; M01 -= value; M02 -= value; M03 -= value;
            M10 -= value; M11 -= value; M12 -= value; M13 -= value;
            M20 -= value; M21 -= value; M22 -= value; M23 -= value;
            M30 -= value; M31 -= value; M32 -= value; M33 -= value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public void Subtract(in Matrix4x4 other)
        {
            M00 -= other.M00; M01 -= other.M01; M02 -= other.M02; M03 -= other.M03;
            M10 -= other.M10; M11 -= other.M11; M12 -= other.M12; M13 -= other.M13;
            M20 -= other.M20; M21 -= other.M21; M22 -= other.M22; M23 -= other.M23;
            M30 -= other.M30; M31 -= other.M31; M32 -= other.M32; M33 -= other.M33;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Multiply(float value)
        {
            M00 *= value; M01 *= value; M02 *= value; M03 *= value;
            M10 *= value; M11 *= value; M12 *= value; M13 *= value;
            M20 *= value; M21 *= value; M22 *= value; M23 *= value;
            M30 *= value; M31 *= value; M32 *= value; M33 *= value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public void Multiply(in Matrix4x4 other)
        {
            float m0, m1, m2;

            m0 = other.M00 * M00
                    + other.M01 * M10
                    + other.M02 * M20
                    + other.M03 * M30;
            m1 = other.M10 * M00
                    + other.M11 * M10
                    + other.M12 * M20
                    + other.M13 * M30;
            m2 = other.M20 * M00
                    + other.M21 * M10
                    + other.M22 * M20
                    + other.M23 * M30;
            M30 = other.M30 * M00
                    + other.M31 * M10
                    + other.M32 * M20
                    + other.M33 * M30;
            M00 = m0;
            M10 = m1;
            M20 = m2;

            m0 = other.M00 * M01
                    + other.M01 * M11
                    + other.M02 * M21
                    + other.M03 * M31;
            m1 = other.M10 * M01
                    + other.M11 * M11
                    + other.M12 * M21
                    + other.M13 * M31;
            m2 = other.M20 * M01
                    + other.M21 * M11
                    + other.M22 * M21
                    + other.M23 * M31;
            M31 = other.M30 * M01
                    + other.M31 * M11
                    + other.M32 * M21
                    + other.M33 * M31;
            M01 = m0;
            M11 = m1;
            M21 = m2;

            m0 = other.M00 * M02
                    + other.M01 * M12
                    + other.M02 * M22
                    + other.M03 * M32;
            m1 = other.M10 * M02
                    + other.M11 * M12
                    + other.M12 * M22
                    + other.M13 * M32;
            m2 = other.M20 * M02
                    + other.M21 * M12
                    + other.M22 * M22
                    + other.M23 * M32;
            M32 = other.M30 * M02
                    + other.M31 * M12
                    + other.M32 * M22
                    + other.M33 * M32;
            M02 = m0;
            M12 = m1;
            M22 = m2;

            m0 = other.M00 * M03
                    + other.M01 * M13
                    + other.M02 * M23
                    + other.M03 * M33;
            m1 = other.M10 * M03
                    + other.M11 * M13
                    + other.M12 * M23
                    + other.M13 * M33;
            m2 = other.M20 * M03
                    + other.M21 * M13
                    + other.M22 * M23
                    + other.M23 * M33;
            M33 = other.M30 * M03
                    + other.M31 * M13
                    + other.M32 * M23
                    + other.M33 * M33;
            M03 = m0;
            M13 = m1;
            M23 = m2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Fill(float value)
        {
            M00 = value; M01 = value; M02 = value; M03 = value;
            M10 = value; M11 = value; M12 = value; M13 = value;
            M20 = value; M21 = value; M22 = value; M23 = value;
            M30 = value; M31 = value; M32 = value; M33 = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetToIdentity()
        {
            M00 = 1.0f; M01 = 0.0f; M02 = 0.0f; M03 = 0.0f;
            M10 = 0.0f; M11 = 1.0f; M12 = 0.0f; M13 = 0.0f;
            M20 = 0.0f; M21 = 0.0f; M22 = 1.0f; M23 = 0.0f;
            M30 = 0.0f; M31 = 0.0f; M32 = 0.0f; M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetToZero()
        {
            M00 = 0.0f; M01 = 0.0f; M02 = 0.0f; M03 = 0.0f;
            M10 = 0.0f; M11 = 0.0f; M12 = 0.0f; M13 = 0.0f;
            M20 = 0.0f; M21 = 0.0f; M22 = 0.0f; M23 = 0.0f;
            M30 = 0.0f; M31 = 0.0f; M32 = 0.0f; M33 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Transpose()
        {
            MathHelper.Swap(ref M01, ref M10);
            MathHelper.Swap(ref M02, ref M20);
            MathHelper.Swap(ref M03, ref M30);
            MathHelper.Swap(ref M12, ref M21);
            MathHelper.Swap(ref M13, ref M31);
            MathHelper.Swap(ref M23, ref M32);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstRow"></param>
        /// <param name="secondRow"></param>
        public void ExchangeRows(int firstRow, int secondRow)
        {
            if (firstRow == secondRow)
            {
                return;
            }

            float temp0 = this[secondRow, 0];
            float temp1 = this[secondRow, 1];
            float temp2 = this[secondRow, 2];
            float temp3 = this[secondRow, 3];

            this[secondRow, 0] = this[firstRow, 0];
            this[secondRow, 1] = this[firstRow, 1];
            this[secondRow, 2] = this[firstRow, 2];
            this[secondRow, 3] = this[firstRow, 3];

            this[firstRow, 0] = temp0;
            this[firstRow, 1] = temp1;
            this[firstRow, 2] = temp2;
            this[firstRow, 3] = temp3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstColumn"></param>
        /// <param name="secondColumn"></param>
        public void ExchangeColumns(int firstColumn, int secondColumn)
        {
            if (firstColumn == secondColumn)
            {
                return;
            }

            float temp0 = this[0, secondColumn];
            float temp1 = this[1, secondColumn];
            float temp2 = this[2, secondColumn];
            float temp3 = this[3, secondColumn];

            this[0, secondColumn] = this[0, firstColumn];
            this[1, secondColumn] = this[1, firstColumn];
            this[2, secondColumn] = this[2, firstColumn];
            this[3, secondColumn] = this[3, firstColumn];

            this[0, firstColumn] = temp0;
            this[1, firstColumn] = temp1;
            this[2, firstColumn] = temp2;
            this[3, firstColumn] = temp3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float[] ToArray(bool rowMajor)
        {
            if (rowMajor == true)
            {
                return new float[]
                {
                    M00, M01, M02, M03,
                    M10, M11, M12, M13,
                    M20, M21, M22, M23,
                    M30, M31, M32, M33
                };
            }
            else
            {
                return new float[]
                {
                    M00, M10, M20, M30,
                    M01, M11, M21, M31,
                    M02, M12, M22, M32,
                    M03, M13, M23, M33
                };
            }
        }

        #region Decompose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="translation"></param>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public bool DecomposeTRS(out Vector3 translation, out Quaternion rotation, out Vector3 scale)
        {
            translation.X = M30;
            translation.Y = M31;
            translation.Z = M32;

            scale.X = MathF.Sqrt(M00 * M00 + M01 * M01 + M02 * M02);
            scale.Y = MathF.Sqrt(M10 * M10 + M11 * M11 + M12 * M12);
            scale.Z = MathF.Sqrt(M20 * M20 + M21 * M21 + M22 * M22);

            if (MathHelper.IsZero(scale.X) || MathHelper.IsZero(scale.Y) ||
                MathHelper.IsZero(scale.Z))
            {
                rotation = Quaternion.Identity;
                return false;
            }

            float invScaleX = 1.0f / scale.X;
            float invScaleY = 1.0f / scale.Y;
            float invScaleZ = 1.0f / scale.Z;

            M00 *= invScaleX; M01 *= invScaleX; M02 *= invScaleX;
            M10 *= invScaleY; M11 *= invScaleY; M12 *= invScaleY;
            M20 *= invScaleZ; M21 *= invScaleZ; M22 *= invScaleZ;

            Quaternion.FromRotationMatrix(this, out rotation);

            M00 *= scale.X; M01 *= scale.X; M02 *= scale.X;
            M10 *= scale.Y; M11 *= scale.Y; M12 *= scale.Y;
            M20 *= scale.Z; M21 *= scale.Z; M22 *= scale.Z;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="Q"></param>
        public void DecomposeLQ(out Matrix4x4 L, out Matrix4x4 Q)
        {
            Matrix4x4.Orthonormalize(this, out Q);

            L.M00 = Q.M00 * M00 + Q.M01 * M01 + Q.M02 * M02 + Q.M03 * M03;

            L.M10 = Q.M00 * M10 + Q.M01 * M11 + Q.M02 * M12 + Q.M03 * M13;
            L.M11 = Q.M10 * M10 + Q.M11 * M11 + Q.M12 * M12 + Q.M13 * M13;

            L.M20 = Q.M00 * M20 + Q.M01 * M21 + Q.M02 * M22 + Q.M03 * M23;
            L.M21 = Q.M10 * M20 + Q.M11 * M21 + Q.M12 * M22 + Q.M13 * M23;
            L.M22 = Q.M20 * M20 + Q.M21 * M21 + Q.M22 * M22 + Q.M23 * M23;

            L.M30 = Q.M00 * M30 + Q.M01 * M31 + Q.M02 * M32 + Q.M03 * M33;
            L.M31 = Q.M01 * M30 + Q.M11 * M31 + Q.M12 * M32 + Q.M13 * M33;
            L.M32 = Q.M02 * M30 + Q.M21 * M31 + Q.M22 * M32 + Q.M23 * M33;
            L.M33 = Q.M03 * M30 + Q.M31 * M31 + Q.M32 * M32 + Q.M33 * M33;

            L.M01 = L.M02 = L.M03 = 0.0f;
            L.M12 = L.M13 = 0.0f;
            L.M23 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Q"></param>
        /// <param name="R"></param>
        public void DecomposeQR(out Matrix4x4 Q, out Matrix4x4 R)
        {
            Matrix4x4.Transpose(this, out Matrix4x4 temp);
            Matrix4x4.Orthonormalize(temp, out Q);

            Q.Transpose();

            R.M00 = Q.M00 * M00 + Q.M10 * M10 + Q.M20 * M20 + Q.M30 * M30;
            R.M01 = Q.M00 * M01 + Q.M10 * M11 + Q.M20 * M21 + Q.M30 * M31;
            R.M02 = Q.M00 * M02 + Q.M10 * M12 + Q.M20 * M22 + Q.M30 * M32;
            R.M03 = Q.M00 * M03 + Q.M10 * M13 + Q.M20 * M23 + Q.M30 * M33;

            R.M11 = Q.M01 * M01 + Q.M11 * M11 + Q.M21 * M21 + Q.M31 * M31;
            R.M12 = Q.M01 * M02 + Q.M11 * M12 + Q.M21 * M22 + Q.M31 * M32;
            R.M13 = Q.M01 * M03 + Q.M11 * M13 + Q.M21 * M23 + Q.M31 * M33;

            R.M22 = Q.M02 * M02 + Q.M12 * M12 + Q.M22 * M22 + Q.M32 * M32;
            R.M23 = Q.M02 * M03 + Q.M12 * M13 + Q.M22 * M23 + Q.M32 * M22;

            R.M33 = Q.M03 * M03 + Q.M13 * M13 + Q.M23 * M23 + Q.M33 * M33;

            R.M10 = 0.0f;
            R.M20 = R.M21 = 0.0f;
            R.M30 = R.M31 = R.M32 = 0.0f;
        }

        #endregion Decompose

        #region Affine Transform
   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        public void RotateX(float angle)
        {
            // [  1  0  0  0 ]
            // [  0  c  s  0 ]
            // [  0 -s  c  0 ]
            // [  0  0  0  1 ]

            float temp = 0.0f;
            MathF.SinCos(angle, out float s, out float c);

            M10 = (temp = M10) * c + M20 * s;
            M20 = M20 * c - temp * s;

            M11 = (temp = M11) * c + M21 * s;
            M21 = M21 * c - temp * s;

            M12 = (temp = M12) * c + M22 * s;
            M22 = M22 * c - temp * s;

            M13 = (temp = M13) * c + M23 * s;
            M23 = M23 * c - temp * s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="centerPoint"></param>
        public void RotateX(float angle, in Vector3 centerPoint)
        {
            // [  1  0  0  0 ]
            // [  0  c  s  0 ]
            // [  0 -s  c  0 ]
            // [  0  y  z  1 ]

            MathF.SinCos(angle, out float s, out float c);

            float y = centerPoint.Y * (1.0f - c) + centerPoint.Z * s;
            float z = centerPoint.Z * (1.0f - c) - centerPoint.Y * s;

            float m10 = M00;
            float m11 = M11;
            float m12 = M12;
            float m13 = M13;

            M10 = m10 * c + M20 * s;
            M20 = M20 * c - m10 * s;

            M11 = m11 * c + M21 * s;
            M21 = M21 * c - m11 * s;

            M12 = m12 * c + M22 * s;
            M22 = M22 * c - m12 * s;

            M13 = m13 * c + M23 * s;
            M23 = M23 * c - m13 * s;

            M30 += m10 * y + M20 * z;
            M31 += m11 * y + M21 * z;
            M32 += m12 * y + M22 * z;
            M33 += m13 * y + M23 * z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>   
        public void RotateY(float angle)
        {
            // [  c  0 -s  0 ]
            // [  0  1  0  0 ]
            // [  s  0  c  0 ]
            // [  0  0  0  1 ]

            float temp = 0.0f;
            MathF.SinCos(angle, out float s, out float c);

            M20 = (temp = M20) * c + M00 * s;
            M00 = M00 * c - temp * s;

            M21 = (temp = M21) * c + M01 * s;
            M01 = M01 * c - temp * s;

            M22 = (temp = M22) * c + M02 * s;
            M02 = M02 * c - temp * s;

            M23 = (temp = M23) * c + M03 * s;
            M03 = M03 * c - temp * s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="centerPoint"></param>
        public void RotateY(float angle, in Vector3 centerPoint)
        {
            // [  c  0 -s  0 ]
            // [  0  1  0  0 ]
            // [  s  0  c  0 ]
            // [  x  0  z  1 ]

            MathF.SinCos(angle, out float s, out float c);

            float x = centerPoint.X * (1.0f - c) + centerPoint.Z * s;
            float z = centerPoint.Z * (1.0f - c) - centerPoint.X * s;

            float m20 = M20;
            float m21 = M21;
            float m22 = M22;
            float m23 = M23;

            M20 = m20 * c + M00 * s;
            M00 = M00 * c - m20 * s;

            M21 = m21 * c + M01 * s;
            M01 = M01 * c - m21 * s;

            M22 = m22 * c + M02 * s;
            M02 = M02 * c - m22 * s;

            M23 = m23 * c + M03 * s;
            M03 = M03 * c - m23 * s;

            M30 += M00 * x + m20 * z;
            M31 += M01 * x + m21 * z;
            M32 += M02 * x + m22 * z;
            M33 += M03 * x + m23 * z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        public void RotateZ(float angle)
        {
            // [  c  s  0  0 ]
            // [ -s  c  0  0 ]
            // [  0  0  0  0 ]
            // [  0  0  0  1 ]

            float temp = 0.0f;
            MathF.SinCos(angle, out float s, out float c);

            M00 = (temp = M00) * c + M10 * s;
            M10 = M10 * c - temp * s;

            M01 = (temp = M01) * c + M11 * s;
            M11 = M11 * c - temp * s;

            M02 = (temp = M02) * c + M12 * s;
            M12 = M12 * c - temp * s;

            M03 = (temp = M03) * c + M13 * s;
            M13 = M13 * c - temp * s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="centerPoint"></param>
        public void RotateZ(float angle, in Vector3 centerPoint)
        {
            // [  c  s  0  0 ]
            // [ -s  c  0  0 ]
            // [  0  0  1  0 ]
            // [  x  y  0  1 ]

            MathF.SinCos(angle, out float s, out float c);

            float x = centerPoint.X * (1.0f - c) + centerPoint.Y * s;
            float y = centerPoint.Y * (1.0f - c) - centerPoint.X * s;

            float m00 = M00;
            float m01 = M01;
            float m02 = M02;
            float m03 = M03;

            M00 = m00 * c + M10 * s;
            M10 = M10 * c - m00 * s;

            M01 = m01 * c + M11 * s;
            M11 = M11 * c - m01 * s;

            M02 = m02 * c + M12 * s;
            M12 = M12 * c - m02 * s;

            M03 = m03 * c + M13 * s;
            M13 = M13 * c - m03 * s;

            M30 += m00 * x + M10 * y;
            M31 += m01 * x + M11 * y;
            M32 += m02 * x + M12 * y;
            M33 += m03 * x + M13 * y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="angle"></param> 
        public void Rotate(in AxisAngle axisAngle) 
        {
            Vector3 axis = axisAngle.Axis;
            float angle = axisAngle.Angle;

            if (axis.X != 0.0f && axis.Y == 0.0f && axis.Z == 0.0f)
                RotateX(angle);
            else if (axis.X == 0.0f && axis.Y != 0.0f && axis.Z == 0.0f)
                RotateY(angle);
            else if (axis.X == 0.0f && axis.Y == 0.0f && axis.Z != 0.0f)
                RotateZ(angle);
            else
            {
                FromAxisAngle(new AxisAngle(axis, angle), out Matrix4x4 result);
                Multiply(result);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        public void Rotate(in EulerAngles eulerAngles)
        {
            FromEulerAnglesZXY(eulerAngles, out Matrix4x4 result);
            Multiply(result);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="quaternion"></param>
        public void Rotate(in Quaternion quaternion)
        {
            FromQuaternion(quaternion, out Matrix4x4 result);
            Multiply(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <param name="sz"></param>
        public void Scale(float sx, float sy, float sz)
        {
            // [  sx 0  0  0  ]
            // [  0  sy 0  0  ]
            // [  0  0  sz 0  ]
            // [  0  0  0  1  ]
            M00 *= sx; M01 *= sx; M02 *= sx; M03 *= sx;
            M10 *= sy; M11 *= sy; M12 *= sy; M13 *= sy;
            M20 *= sz; M21 *= sz; M22 *= sz; M23 *= sz;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scale"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Scale(in Vector3 scale) 
        { 
            Scale(scale.X, scale.Y, scale.Z); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="yFactor"></param>
        /// <param name="zFactor"></param>
        public void ShearX(float yFactor, float zFactor)
        {
            // [  1  y  z  0  ]
            // [  0  1  0  0  ]
            // [  0  0  1  0  ]
            // [  0  0  0  1  ]
            M00 += yFactor * M10 + zFactor * M20;
            M01 += yFactor * M11 + zFactor * M21;
            M02 += yFactor * M12 + zFactor * M22;
            M03 += yFactor * M13 + zFactor * M23;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xFactor"></param>
        /// <param name="zFactor"></param>
        public void ShearY(float xFactor, float zFactor)
        {
            // [  1  0  0  0  ]
            // [  x  1  z  0  ]
            // [  0  0  1  0  ]
            // [  0  0  0  1  ]
            M10 += xFactor * M00 + zFactor * M20;
            M11 += xFactor * M01 + zFactor * M21;
            M12 += xFactor * M02 + zFactor * M22;
            M13 += xFactor * M03 + zFactor * M23;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xFactor"></param>
        /// <param name="yFactor"></param>
        public void ShearZ(float xFactor, float yFactor)
        {
            // [  1  0  0  0  ]
            // [  0  1  0  0  ]
            // [  x  y  1  0  ]
            // [  0  0  0  1  ]
            M20 += xFactor * M00 + yFactor * M10;
            M21 += xFactor * M01 + yFactor * M11;
            M22 += xFactor * M02 + yFactor * M12;
            M23 += xFactor * M03 + yFactor * M13;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="dz"></param>
        public void Translate(float dx, float dy, float dz)
        {
            // [ 1  0  0  0 ]
            // [ 0  1  0  0 ]
            // [ 0  0  1  0 ]
            // [ dx dy dz 1 ]
            M30 += M00 * dx + M10 * dy + M20 * dz;
            M31 += M01 * dx + M11 * dy + M21 * dz;
            M32 += M02 * dx + M12 * dy + M22 * dz;
            M33 += M03 * dx + M13 * dy + M23 * dz;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="translate"></param>
        public void Translate(in Vector3 translation) 
        { 
            Translate(translation.X, translation.Y, translation.Z); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scaling"></param>
        /// <param name="rotation"></param>
        /// <param name="translation"></param>
        public void AffineTransformation(in Vector3 scaling, in Quaternion rotation, in Vector3 translation)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scaling"></param>
        /// <param name="rotationCenter"></param>
        /// <param name="rotation"></param>
        /// <param name="translation"></param>
        public void AffineTransformation(in Vector3 scaling, in Vector3 rotationCenter, in Quaternion rotation, in Vector3 translation)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scalingCenter"></param>
        /// <param name="scalingOrientation"></param>
        /// <param name="scaling"></param>
        /// <param name="rotationCenter"></param>
        /// <param name="rotation"></param>
        /// <param name="translation"></param>
        public void AffineTransformation(in Vector3 scalingCenter, in Quaternion scalingOrientation, in Vector3 scaling, in Vector3 rotationCenter, in Quaternion rotation, in Vector3 translation)
        {

        }

        #endregion Affine Transform

        #region View Transform

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eye"></param>
        /// <param name="center"></param>
        /// <param name="up"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void LookAt(in Vector3 eye, in Vector3 center, in Vector3 up)
        {
#if RASTER_USE_LEFT_HAND
            LookAtLH(eye.X, eye.Y, eye.Z, center.X, center.Y, center.Z, up.X, up.Y, up.Z);
#else
            LookAtRH(eye.X, eye.Y, eye.Z, center.X, center.Y, center.Z, up.X, up.Y, up.Z);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eye"></param>
        /// <param name="center"></param>
        /// <param name="up"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void LookAtLH(in Vector3 eye, in Vector3 center, in Vector3 up)
        {
            LookAtLH(eye.X, eye.Y, eye.Z, center.X, center.Y, center.Z, up.X, up.Y, up.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eye"></param>
        /// <param name="center"></param>
        /// <param name="up"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void LookAtRH(in Vector3 eye, in Vector3 center, in Vector3 up)
        {
            LookAtRH(eye.X, eye.Y, eye.Z, center.X, center.Y, center.Z, up.X, up.Y, up.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eyeX"></param>
        /// <param name="eyeY"></param>
        /// <param name="eyeZ"></param>
        /// <param name="centerX"></param>
        /// <param name="centerY"></param>
        /// <param name="centerZ"></param>
        /// <param name="upX"></param>
        /// <param name="upY"></param>
        /// <param name="upZ"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void LookAt(float eyeX, float eyeY, float eyeZ,
                   float centerX, float centerY, float centerZ,
                   float upX, float upY, float upZ)
        {
#if RASTER_USE_LEFT_HAND
            LookAtLH(eyeX, eyeY, eyeZ, centerX, centerY, centerZ, upX, upY, upZ);
#else
            LookAtRH(eyeX, eyeY, eyeZ, centerX, centerY, centerZ, upX, upY, upZ);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eyeR"></param>
        /// <param name="eyeY"></param>
        /// <param name="eyeZ"></param>
        /// <param name="centerR"></param>
        /// <param name="centerY"></param>
        /// <param name="centerZ"></param>
        /// <param name="upR"></param>
        /// <param name="upY"></param>
        /// <param name="upZ"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void LookAtLH(float eyeX, float eyeY, float eyeZ,
                             float centerX, float centerY, float centerZ,
                             float upX, float upY, float upZ)
        {
            float forwardX = eyeX - centerX;
            float forwardY = eyeY - centerY;
            float forwardZ = eyeZ - centerZ;

            float lenSqr = forwardX * forwardX + forwardY * forwardY + forwardZ * forwardZ;
            float invNorm = MathHelper.FastSqrtInverse(lenSqr);

            forwardX *= invNorm;
            forwardY *= invNorm;
            forwardZ *= invNorm;

            float sideX = upY * forwardZ - upZ * forwardY;
            float sideY = upX * forwardZ - upZ * forwardX;
            float sideZ = upX * forwardY - upY * forwardX;

            lenSqr = sideX * sideX + sideY * sideY + sideZ * sideZ;
            invNorm = MathHelper.FastSqrtInverse(lenSqr);

            sideX *= invNorm;
            sideY *= invNorm;
            sideZ *= invNorm;

            float uX = sideY * forwardZ - sideZ * forwardY;
            float uY = sideZ * forwardX - sideX * forwardZ;
            float uZ = sideX * forwardY - sideY * forwardX;

            M00 = sideX;
            M01 = uX;
            M02 = forwardX;
            M03 = 0.0f;

            M10 = sideY;
            M11 = uY;
            M12 = forwardY;
            M13 = 0.0f;

            M20 = sideZ;
            M21 = uZ;
            M22 = forwardZ;
            M23 = 0.0f;

            M30 = -(sideX * eyeX + sideY * eyeY + sideZ * eyeZ);
            M31 = -(uX * eyeX + uY * eyeY + uZ * eyeZ);
            M32 = -(forwardX * eyeX + forwardY * eyeY + forwardZ * eyeZ);
            M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eyeX"></param>
        /// <param name="eyeY"></param>
        /// <param name="eyeZ"></param>
        /// <param name="centerX"></param>
        /// <param name="centerY"></param>
        /// <param name="centerZ"></param>
        /// <param name="upX"></param>
        /// <param name="upY"></param>
        /// <param name="upZ"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void LookAtRH(float eyeX, float eyeY, float eyeZ,
                             float centerX, float centerY, float centerZ,
                             float upX, float upY, float upZ)
        {
            float forwardX = centerX - eyeX;
            float forwardY = centerY - eyeY;
            float forwardZ = centerZ - eyeZ;

            float lenSqr = forwardX * forwardX + forwardY * forwardY + forwardZ * forwardZ;
            float invNorm = MathHelper.FastSqrtInverse(lenSqr);

            forwardX *= invNorm;
            forwardY *= invNorm;
            forwardZ *= invNorm;

            float sideX = forwardY * upZ - forwardZ * upY;
            float sideY = forwardX * upZ - forwardZ * upX;
            float sideZ = forwardX * upY - forwardY * upX;

            lenSqr = sideX * sideX + sideY * sideY + sideZ * sideZ;
            invNorm = MathHelper.FastSqrtInverse(lenSqr);

            sideX *= invNorm;
            sideY *= invNorm;
            sideZ *= invNorm;

            float uX = sideY * forwardZ - sideZ * forwardY;
            float uY = sideZ * forwardX - sideX * forwardZ;
            float uZ = sideX * forwardY - sideY * forwardX;

            M00 = sideX;
            M01 = uX;
            M02 = -forwardX;
            M03 = 0.0f;

            M10 = sideY;
            M11 = uY;
            M12 = -forwardY;
            M13 = 0.0f;

            M20 = sideZ;
            M21 = uZ;
            M22 = -forwardZ;
            M23 = 0.0f;

            M30 = -(sideX * eyeX + sideY * eyeY + sideZ * eyeZ);
            M31 = -(uX * eyeX + uY * eyeY + uZ * eyeZ);
            M32 = (forwardX * eyeX + forwardY * eyeY + forwardZ * eyeZ);
            M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eye"></param>
        /// <param name="center"></param>
        /// <param name="up"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void LookTo(in Vector3 eye, in Vector3 forward, in Vector3 up)
        {
#if RASTER_USE_LEFT_HAND
            LookAtLH(eye.X, eye.Y, eye.Z, forward.X, forward.Y, forward.Z, up.X, up.Y, up.Z);
#else
            LookAtRH(eye.X, eye.Y, eye.Z, forward.X, forward.Y, forward.Z, up.X, up.Y, up.Z);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eye"></param>
        /// <param name="center"></param>
        /// <param name="up"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void LookToLH(in Vector3 eye, in Vector3 forward, in Vector3 up)
        {
            LookAtLH(eye.X, eye.Y, eye.Z, forward.X, forward.Y, forward.Z, up.X, up.Y, up.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eye"></param>
        /// <param name="center"></param>
        /// <param name="up"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void LookToRH(in Vector3 eye, in Vector3 forward, in Vector3 up)
        {
            LookAtRH(eye.X, eye.Y, eye.Z, forward.X, forward.Y, forward.Z, up.X, up.Y, up.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eyeX"></param>
        /// <param name="eyeY"></param>
        /// <param name="eyeZ"></param>
        /// <param name="centerX"></param>
        /// <param name="centerY"></param>
        /// <param name="centerZ"></param>
        /// <param name="upX"></param>
        /// <param name="upY"></param>
        /// <param name="upZ"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void LookTo(float eyeX, float eyeY, float eyeZ,
                   float forwardX, float forwardY, float forwardZ,
                   float upX, float upY, float upZ)
        {
#if RASTER_USE_LEFT_HAND
            LookAtLH(eyeX, eyeY, eyeZ, forwardX, forwardY, forwardZ, upX, upY, upZ);
#else
            LookAtRH(eyeX, eyeY, eyeZ, forwardX, forwardY, forwardZ, upX, upY, upZ);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eyeR"></param>
        /// <param name="eyeY"></param>
        /// <param name="eyeZ"></param>
        /// <param name="centerR"></param>
        /// <param name="centerY"></param>
        /// <param name="centerZ"></param>
        /// <param name="upR"></param>
        /// <param name="upY"></param>
        /// <param name="upZ"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void LookToLH(float eyeX, float eyeY, float eyeZ,
                             float forwardX, float forwardY, float forwardZ,
                             float upX, float upY, float upZ)
        {
            float lenSqr = forwardX * forwardX + forwardY * forwardY + forwardZ * forwardZ;
            float invNorm = MathHelper.FastSqrtInverse(lenSqr);

            forwardX *= invNorm;
            forwardY *= invNorm;
            forwardZ *= invNorm;

            float sideX = upY * forwardZ - upZ * forwardY;
            float sideY = upX * forwardZ - upZ * forwardX;
            float sideZ = upX * forwardY - upY * forwardX;

            lenSqr = sideX * sideX + sideY * sideY + sideZ * sideZ;
            invNorm = MathHelper.FastSqrtInverse(lenSqr);

            sideX *= invNorm;
            sideY *= invNorm;
            sideZ *= invNorm;

            float uX = sideY * forwardZ - sideZ * forwardY;
            float uY = sideZ * forwardX - sideX * forwardZ;
            float uZ = sideX * forwardY - sideY * forwardX;

            M00 = sideX;
            M01 = uX;
            M02 = forwardX;
            M03 = 0.0f;

            M10 = sideY;
            M11 = uY;
            M12 = forwardY;
            M13 = 0.0f;

            M20 = sideZ;
            M21 = uZ;
            M22 = forwardZ;
            M23 = 0.0f;

            M30 = -(sideX * eyeX + sideY * eyeY + sideZ * eyeZ);
            M31 = -(uX * eyeX + uY * eyeY + uZ * eyeZ);
            M32 = -(forwardX * eyeX + forwardY * eyeY + forwardZ * eyeZ);
            M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eyeX"></param>
        /// <param name="eyeY"></param>
        /// <param name="eyeZ"></param>
        /// <param name="centerX"></param>
        /// <param name="centerY"></param>
        /// <param name="centerZ"></param>
        /// <param name="upX"></param>
        /// <param name="upY"></param>
        /// <param name="upZ"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void LookToRH(float eyeX, float eyeY, float eyeZ,
                             float forwardX, float forwardY, float forwardZ,
                             float upX, float upY, float upZ)
        {
            float lenSqr = forwardX * forwardX + forwardY * forwardY + forwardZ * forwardZ;
            float invNorm = MathHelper.FastSqrtInverse(lenSqr);

            forwardX *= invNorm;
            forwardY *= invNorm;
            forwardZ *= invNorm;

            float sideX = forwardY * upZ - forwardZ * upY;
            float sideY = forwardX * upZ - forwardZ * upX;
            float sideZ = forwardX * upY - forwardY * upX;

            lenSqr = sideX * sideX + sideY * sideY + sideZ * sideZ;
            invNorm = MathHelper.FastSqrtInverse(lenSqr);

            sideX *= invNorm;
            sideY *= invNorm;
            sideZ *= invNorm;

            float uX = sideY * forwardZ - sideZ * forwardY;
            float uY = sideZ * forwardX - sideX * forwardZ;
            float uZ = sideX * forwardY - sideY * forwardX;

            M00 = sideX;
            M01 = uX;
            M02 = -forwardX;
            M03 = 0.0f;

            M10 = sideY;
            M11 = uY;
            M12 = -forwardY;
            M13 = 0.0f;

            M20 = sideZ;
            M21 = uZ;
            M22 = -forwardZ;
            M23 = 0.0f;

            M30 = -(sideX * eyeX + sideY * eyeY + sideZ * eyeZ);
            M31 = -(uX * eyeX + uY * eyeY + uZ * eyeZ);
            M32 = (forwardX * eyeX + forwardY * eyeY + forwardZ * eyeZ);
            M33 = 1.0f;
        }
        #endregion View Transform

        #region Projection Transform
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void Frustum(float left, float right, float bottom, float top, float zNear, float zFar)
        {
#if RASTER_USE_LEFT_HAND_AND_NEGATE_NDC
            FrustrumLH_NO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_LEFT_HAND_AND_ZERO_NDC
            FrustrumLH_ZO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND_AND_NEGATE_NDC
            FrustrumRH_NO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND_AND_ZERO_NDC
            FrustrumRH_ZO(left, right, bottom, top, zNear, zFar);
#else 
            FrustrumRH_NO(left, right, bottom, top, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void FrustumLH(float left, float right, float bottom, float top, float zNear, float zFar)
        {
#if RASTER_USE_NEGATE_NDC
            FrustrumLH_NO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_ZERO_NDC 
            FrustrumLH_ZO(left, right, bottom, top, zNear, zFar);
#else
            FrustrumLH_NO(left, right, bottom, top, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void FrustumRH(float left, float right, float bottom, float top, float zNear, float zFar)
        {
#if RASTER_USE_NEGATE_NDC
            FrustrumRH_NO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_ZERO_NDC 
            FrustrumRH_ZO(left, right, bottom, top, zNear, zFar);
#else
            FrustrumRH_NO(left, right, bottom, top, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void FrustumNO(float left, float right, float bottom, float top, float zNear, float zFar)
        {
#if RASTER_USE_LEFT_HAND
            FrustrumLH_NO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND 
            FrustrumRH_NO(left, right, bottom, top, zNear, zFar);
#else
            FrustrumRH_NO(left, right, bottom, top, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void FrustumZO(float left, float right, float bottom, float top, float zNear, float zFar)
        {
#if RASTER_USE_LEFT_HAND
            FrustrumLH_ZO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND 
            FrustrumRH_ZO(left, right, bottom, top, zNear, zFar);
#else
            FrustrumRH_ZO(left, right, bottom, top, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="top"></param>
        /// <param name="bottom"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void FrustrumLH_NO(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            float invWidth = 1.0f / (right - left);
            float invHeight = 1.0f / (top - bottom);
            float invClip = 1.0f / (zFar - zNear);

            M00 = 2.0f * zNear * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * zNear * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = (left + right) * invWidth;
            M21 = (top + bottom) * invHeight;
            M22 = (zNear + zFar) * invClip;
            M23 = 1.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = -(2.0f * zNear * zFar) * invClip;
            M33 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="top"></param>
        /// <param name="bottom"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void FrustrumLH_ZO(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            float invWidth = 1.0f / (right - left);
            float invHeight = 1.0f / (top - bottom);
            float invClip = 1.0f / (zFar - zNear);

            M00 = 2.0f * zNear * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * zNear * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = (left + right) * invWidth;
            M21 = (top + bottom) * invHeight;
            M22 = zFar * invClip;
            M23 = 1.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = -(zFar * zNear) * invClip;
            M33 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="top"></param>
        /// <param name="bottom"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void FrustrumRH_NO(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            float invWidth = 1.0f / (right - left);
            float invHeight = 1.0f / (top - bottom);
            float invClip = 1.0f / (zFar - zNear);

            M00 = 2.0f * zNear * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * zNear * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = (left + right) * invWidth;
            M21 = (top + bottom) * invHeight;
            M22 = -(zNear + zFar) * invClip;
            M23 = -1.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = -(2.0f * zNear * zFar) * invClip;
            M33 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="top"></param>
        /// <param name="bottom"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void FrustrumRH_ZO(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            float invWidth = 1.0f / (right - left);
            float invHeight = 1.0f / (top - bottom);
            float invClip = 1.0f / (zFar - zNear);

            M00 = 2.0f * zNear * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * zNear * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = (left + right) * invWidth;
            M21 = (top + bottom) * invHeight;
            M22 = zFar * invClip;
            M23 = -1.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = -(zNear * zFar) * invClip;
            M33 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Orthographic(float width, float height, float zNear, float zFar)
        {
#if RASTER_USE_LEFT_HAND_AND_NEGATE_NDC
            OrthographicLH_NO(width, height, zNear, zFar);
#elif RASTER_USE_LEFT_HAND_AND_ZERO_NDC
            OrthographicLH_ZO(width, height, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND_AND_NEGATE_NDC
            OrthographicRH_NO(width, height, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND_AND_ZERO_NDC
            OrthographicRH_ZO(width, height, zNear, zFar);
#else 
            OrthographicRH_NO(width, height, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OrthographicLH(float width, float height, float zNear, float zFar)
        {
#if RASTER_USE_NEGATE_NDC
            OrthographicLH_NO(width, height, zNear, zFar);
#elif RASTER_USE_ZERO_NDC
            OrthographicLH_ZO(width, height, zNear, zFar);
#else 
            OrthographicLH_NO(width, height, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OrthographicRH(float width, float height, float zNear, float zFar)
        {
#if RASTER_USE_NEGATE_NDC
            OrthographicRH_NO(width, height, zNear, zFar);
#elif RASTER_USE_ZERO_NDC
            OrthographicRH_ZO(width, height, zNear, zFar);
#else
            OrthographicRH_NO(width, height, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OrthographicNO(float width, float height, float zNear, float zFar)
        {
#if RASTER_USE_LEFT_HAND
            OrthographicLH_NO(width, height, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND 
            OrthographicRH_NO(width, height, zNear, zFar);
#else
            OrthographicRH_NO(width, height, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OrthographicZO(float width, float height, float zNear, float zFar)
        {
#if RASTER_USE_LEFT_HAND
            OrthographicLH_ZO(width, height, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND 
            OrthographicRH_ZO(width, height, zNear, zFar);
#else
            OrthographicRH_ZO(width, height, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void OrthographicLH_NO(float width, float height, float zNear, float zFar)
        {
            float invWidth = 1.0f / width;
            float invHeight = 1.0f / height;
            float zRange = 1.0f / (zFar - zNear);

            M00 = 2.0f * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = 2.0f * zRange;
            M23 = 0.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = -zRange * (zNear + zFar);
            M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void OrthographicLH_ZO(float width, float height, float zNear, float zFar)
        {
            float invWidth = 1.0f / width;
            float invHeight = 1.0f / height;
            float zRange = 1.0f / (zFar - zNear);

            M00 = 2.0f * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = zRange;
            M23 = 0.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = -zRange * zNear;
            M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void OrthographicRH_NO(float width, float height, float zNear, float zFar)
        {
            float invWidth = 1.0f / width;
            float invHeight = 1.0f / height;
            float zRange = 1.0f / (zFar - zNear);

            M00 = 2.0f * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = -2.0f * zRange;
            M23 = 0.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = -zRange * (zNear + zFar);
            M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void OrthographicRH_ZO(float width, float height, float zNear, float zFar)
        {
            float invWidth = 1.0f / width;
            float invHeight = 1.0f / height;
            float zRange = 1.0f / (zFar - zNear);

            M00 = 2.0f * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = -zRange;
            M23 = 0.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = -zRange * zNear;
            M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OrthographicOffCenter(float left, float right, float bottom, float top, float zNear, float zFar)
        {
#if RASTER_USE_LEFT_HAND_AND_NEGATE_NDC
            OrthographicOffCenterLH_NO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_LEFT_HAND_AND_ZERO_NDC
            OrthographicOffcenterLH_ZO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND_AND_NEGATE_NDC
            OrthographicOffCenterRH_NO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND_AND_ZERO_NDC
            OrthographicOffcenterRH_ZO(left, right, bottom, top, zNear, zFar);
#else 
            OrthographicOffCenterRH_NO(left, right, bottom, top, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OrthographicOffCenterLH(float left, float right, float bottom, float top, float zNear, float zFar)
        {
#if RASTER_USE_NEGATE_NDC
            OrthographicOffCenterLH_NO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_ZERO_NDC
            OrthographicOffCenterLH_ZO(left, right, bottom, top, zNear, zFar);
#else 
            OrthographicOffCenterLH_NO(left, right, bottom, top, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OrthographicOffcenterRH(float left, float right, float bottom, float top, float zNear, float zFar)
        {
#if RASTER_USE_NEGATE_NDC
            OrthographicOffCenterRH_NO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_ZERO_NDC 
            OrthographicOffCenterRH_ZO(left, right, bottom, top, zNear, zFar);
#else
            OrthographicOffCenterRH_NO(left, right, bottom, top, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OrthographicOffCenterNO(float left, float right, float bottom, float top, float zNear, float zFar)
        {
#if RASTER_USE_LEFT_HAND
            OrthographicOffCenterLH_NO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND 
            OrthographicOffCenterRH_NO(left, right, bottom, top, zNear, zFar);
#else
            OrthographicOffCenterRH_NO(left, right, bottom, top, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OrthographicOffCenterZO(float left, float right, float bottom, float top, float zNear, float zFar)
        {
#if RASTER_USE_LEFT_HAND
            OrthographicOffCenterLH_ZO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND 
            OrthographicOffCenterRH_ZO(left, right, bottom, top, zNear, zFar);
#else
            OrthographicOffCenterRH_ZO(left, right, bottom, top, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void OrthographicOffCenterLH_NO(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            float invWidth  = 1.0f / (right - left);
            float invHeight = 1.0f / (top - bottom);
            float zRange    = 1.0f / (zFar - zNear);

            M00 = 2.0f * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = 2.0f * zRange;
            M23 = 0.0f;

            M30 = -(left + right) * invWidth;
            M31 = -(top + bottom) * invHeight;
            M32 = -zRange * (zNear + zFar);
            M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void OrthographicOffCenterLH_ZO(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            float invWidth = 1.0f / (right - left);
            float invHeight = 1.0f / (top - bottom);
            float zRange = 1.0f / (zFar - zNear);

            M00 = 2.0f * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = zRange;
            M23 = 0.0f;

            M30 = -(left + right) * invWidth;
            M31 = -(top + bottom) * invHeight;
            M32 = -zRange * zNear;
            M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void OrthographicOffCenterRH_NO(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            float invWidth = 1.0f / (right - left);
            float invHeight = 1.0f / (top - bottom);
            float zRange = 1.0f / (zFar - zNear);

            M00 = 2.0f * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = -2.0f * zRange;
            M23 = 0.0f;

            M30 = -(left + right) * invWidth;
            M31 = -(top + bottom) * invHeight;
            M32 = -zRange * (zNear + zFar);
            M33 = 1.0f;
        }
        
            /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void OrthographicOffCenterRH_ZO(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            float invWidth = 1.0f / (right - left);
            float invHeight = 1.0f / (top - bottom);
            float zRange = 1.0f / (zFar - zNear);

            M00 = 2.0f * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = -zRange;
            M23 = 0.0f;

            M30 = -(left + right) * invWidth;
            M31 = -(top + bottom) * invHeight;
            M32 = -zRange * zNear;
            M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Perspective(float width, float height, float zNear, float zFar)
        {
#if RASTER_USE_LEFT_HAND_AND_NEGATE_NDC
        PerspectiveLH_NO(width, height, zNear, zFar);
#elif RASTER_USE_LEFT_HAND_AND_ZERO_NDC
        PerspectiveLH_ZO(width, height, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND_AND_NEGATE_NDC
        PerspectiveRH_NO(width, height, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND_AND_NEGATE_NDC
        PerspectiveRH_ZO(width, height, zNear, zFar);
#else
        PerspectiveRH_NO(width, height, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PerspectiveLH(float width, float height, float zNear, float zFar)
        {
#if RASTER_USE_NEGATE_NDC
            PerspectiveLH_NO(width, height, zNear, zFar);
#elif RASTER_USE_ZERO_NDC 
            PerspectiveLH_ZO(width, height, zNear, zFar);
#else
            PerspectiveLH_NO(width, height, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PerspectiveRH(float width, float height, float zNear, float zFar)
        {
#if RASTER_USE_NEGATE_NDC
            PerspectiveRH_NO(width, height, zNear, zFar);
#elif RASTER_USE_ZERO_NDC 
            PerspectiveRH_ZO(width, height, zNear zFar);
#else 
            PerspectiveRH_NO(width, height, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PerspectiveNO(float width, float height, float zNear, float zFar)
        {
#if RASTER_USE_LEFT_HAND
            PerspectiveLH_NO(width, height, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND 
            PerspectiveRH_NO(width, height, zNear, zFar);
#else
            PerspectiveRH_NO(width, height, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PerspectiveZO(float width, float height, float zNear, float zFar)
        {
#if RASTER_USE_LEFT_HAND
            PerspectiveLH_ZO(width, height, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND 
            PerspectiveRH_ZO(width, height, zNear zFar);
#else
            PerspectiveRH_ZO(width, height, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PerspectiveLH_NO(float width, float height, float zNear, float zFar)
        {
            float invWidth = 1.0f / width;
            float invHeight = 1.0f / height;
            float zRange = 1.0f / (zFar - zNear);

            M00 = 2.0f * zNear * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * zNear * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = zRange * (zNear + zFar);
            M23 = 1.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = -zRange * (2.0f * zNear * zFar);
            M33 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void PerspectiveLH_ZO(float width, float height, float zNear, float zFar)
        {
            float invWidth = 1.0f / width;
            float invHeight = 1.0f / height;
            float zRange = 1.0f / (zFar - zNear);

            M00 = 2.0f * zNear * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * zNear * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = zRange * zFar;
            M23 = 1.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = -zRange * (zNear * zFar);
            M33 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void PerspectiveRH_NO(float width, float height, float zNear, float zFar)
        {
            float invWidth = 1.0f / width;
            float invHeight = 1.0f / height;
            float zRange = 1.0f / (zFar - zNear);

            M00 = 2.0f * zNear * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * zNear * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = -zRange * (zNear + zFar);
            M23 = -1.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = -zRange * (2.0f * zNear * zFar);
            M33 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void PerspectiveRH_ZO(float width, float height, float zNear, float zFar)
        {
            float invWidth = 1.0f / width;
            float invHeight = 1.0f / height;
            float zRange = 1.0f / (zFar - zNear);

            M00 = 2.0f * zNear * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * zNear * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = zRange * zFar;
            M23 = -1.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = zRange * (zNear * zFar);
            M33 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fov"></param>
        /// <param name="aspect"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PerspectiveFov(float fov, float aspect, float zNear, float zFar)
        {
#if RASTER_USE_LEFT_HAND_AND_NEGATE_NDC
            PerspectiveFovLH_NO(fov, aspect, zNear, zFar);
#elif RASTER_USE_LEFT_HAND_AND_ZERO_NDC
            PerspectiveFovLH_ZO(fov, aspect, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND_AND_NEGATE_NDC
            PerspectiveFovRH_NO(fov, aspect, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND_AND_ZERO_NDC
            PerspectiveFovRH_ZO(fov, aspect, zNear, zFar);
#else 
            PerspectiveFovRH_NO(fov, aspect, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fov"></param>
        /// <param name="aspect"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PerspectiveFovLH(float fov, float aspect, float zNear, float zFar)
        {
#if RASTER_USE_NEGATE_NDC
            PerspectiveFovLH_NO(fov, aspect, zNear, zFar);
#elif RASTER_USE_ZERO_NDC
            PerspectiveFovLH_ZO(fov, aspect, zNear, zFar);
#else 
            PerspectiveFovLH_NO(fov, aspect, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fov"></param>
        /// <param name="aspect"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PerspectiveFovRH(float fov, float aspect, float zNear, float zFar)
        {
#if RASTER_USE_NEGATE_NDC
            PerspectiveFovRH_NO(fov, aspect, zNear, zFar);
#elif RASTER_USE_ZERO_NDC 
            PerspectiveFovRH_ZO(fov, aspect, zNear, zFar);
#else
            PerspectiveFovRH_ZO(fov, aspect, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fov"></param>
        /// <param name="aspect"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PerspectiveFovNO(float fov, float aspect, float zNear, float zFar)
        {
#if RASTER_USE_LEFT_HAND
            PerspectiveFovLH_NO(fov, aspect, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND
            PerspectiveFovRH_NO(fov, aspect, zNear, zFar);
#else 
            PerspectiveFovRH_NO(fov, aspect, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fov"></param>
        /// <param name="aspect"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PerspectiveFovZO(float fov, float aspect, float zNear, float zFar)
        {
#if RASTER_USE_LEFT_HAND
            PerspectiveFovLH_ZO(fov, aspect, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND 
            PerspectiveFovRH_ZO(fov, aspect, zNear, zFar);
#else
            PerspectiveFovRH_ZO(fov, aspect, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fov"></param>
        /// <param name="aspect"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void PerspectiveFovLH_NO(float fov, float aspect, float zNear, float zFar)
        {
            float cot = 1.0f / MathF.Tan(0.5f * MathF.Deg2Rad * fov);
            float zRange = 1.0f / (zFar - zNear);

            M00 = cot / aspect;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = cot;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = zRange * (zNear + zFar);
            M23 = 1.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = -zRange * (2.0f * zNear * zFar);
            M33 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fov"></param>
        /// <param name="aspect"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void PerspectiveFovLH_ZO(float fov, float aspect, float zNear, float zFar)
        {
            float cot = 1.0f / MathF.Tan(0.5f * fov * MathF.Deg2Rad);
            float zRange = 1.0f / (zFar - zNear);

            M00 = cot / aspect;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = cot;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = zRange * zFar;
            M23 = 1.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = -zRange * (zNear * zFar);
            M33 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fov"></param>
        /// <param name="aspect"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void PerspectiveFovRH_NO(float fov, float aspect, float zNear, float zFar)
        {
            float cot = 1.0f / MathF.Tan(0.5f * MathF.Deg2Rad * fov);
            float zRange = 1.0f / (zFar - zNear);

            M00 = cot / aspect;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = cot;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = -zRange * (zNear + zFar);
            M23 = -1.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = -zRange * (2.0f * zNear * zFar);
            M33 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fov"></param>
        /// <param name="aspect"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void PerspectiveFovRH_ZO(float fov, float aspect, float zNear, float zFar)
        {
            float cot = 1.0f / MathF.Tan(0.5f * fov * MathF.Deg2Rad);
            float zRange = 1.0f / (zFar - zNear);

            M00 = cot / aspect;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = cot;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = -zRange * zFar;
            M23 = -1.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = -zRange * (zNear * zFar);
            M33 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PerspectiveOffCenter(float left, float right, float bottom, float top, float zNear, float zFar)
        {
#if RASTER_USE_LEFT_HAND_AND_NEGATE_NDC
            PerspectiveOffCenterLH_NO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_LEFT_HAND_AND_ZERO_NDC
            PerspectiveOffCenterLH_ZO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND_AND_NEGATE_NDC
            PerspectiveOffCenterRH_NO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND_AND_ZERO_NDC
            PerspectiveOffCenterRH_ZO(left, right, bottom, top, zNear, zFar);
#else 
            PerspectiveOffCenterRH_NO(left, right, bottom, top, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PerspectiveOffCenterLH(float left, float right, float bottom, float top, float zNear, float zFar)
        {
#if RASTER_USE_NEGATE_NDC
            PerspectiveOffCenterLH_NO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_ZERO_NDC
            PerspectiveOffCenterRH_ZO(left, right, bottom, top, zNear, zFar);
#else
            PerspectiveOffCenterRH_NO(left, right, bottom, top, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PerspectiveOffCenterRH(float left, float right, float bottom, float top, float zNear, float zFar)
        {
#if RASTER_USE_NEGATE_NDC
            PerspectiveOffCenterRH_NO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_ZERO_NDC
            PerspectiveOffCenterRH_ZO(left, right, bottom, top, zNear, zFar);
#else
            PerspectiveOffCenterRH_NO(left, right, bottom, top, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PerspectiveOffCenterNO(float left, float right, float bottom, float top, float zNear, float zFar)
        {
#if RASTER_USE_LEFT_HAND
            PerspectiveOffCenterLH_NO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND
            PerspectiveOffCenterRH_NO(left, right, bottom, top, zNear, zFar);
#else
            PerspectiveOffCenterRH_NO(left, right, bottom, top, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PerspectiveOffCenterZO(float left, float right, float bottom, float top, float zNear, float zFar)
        {
#if RASTER_USE_LEFT_HAND
            PerspectiveOffCenterLH_ZO(left, right, bottom, top, zNear, zFar);
#elif RASTER_USE_RIGHT_HAND
            PerspectiveOffCenterRH_ZO(left, right, bottom, top, zNear, zFar);
#else
            PerspectiveOffCenterRH_ZO(left, right, bottom, top, zNear, zFar);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PerspectiveOffCenterLH_NO(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            float invWidth = 1.0f / (right - left);
            float invHeight = 1.0f / (top - bottom);
            float zRange = 1.0f / (zFar - zNear);

            M00 = 2.0f * zNear * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * zNear * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = -(left + right) * invWidth;
            M21 = -(top + bottom) * invHeight;
            M22 = zRange * zFar;
            M23 = 1.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = -zRange * (zNear * zFar);
            M33 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void PerspectiveOffCenterLH_ZO(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            float invWidth = 1.0f / (right - left);
            float invHeight = 1.0f / (top - bottom);
            float zRange = 1.0f / (zFar - zNear);

            M00 = 2.0f * zNear * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * zNear * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = -(left + right) * invWidth;
            M21 = -(top + bottom) * invHeight;
            M22 = zRange * zFar;
            M23 = 1.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = -zRange * (zNear * zFar);
            M33 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void PerspectiveOffCenterRH_NO(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            float invWidth = 1.0f / (right - left);
            float invHeight = 1.0f / (top - bottom);
            float zRange = 1.0f / (zFar - zNear);

            M00 = 2.0f * zNear * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * zNear * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = (left + right) * invWidth;
            M21 = (top + bottom) * invHeight;
            M22 = -zRange * (zNear + zFar);
            M23 = -1.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = -zRange * (2.0f * zNear * zFar);
            M33 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void PerspectiveOffCenterRH_ZO(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            float invWidth = 1.0f / (right - left);
            float invHeight = 1.0f / (top - bottom);
            float zRange = 1.0f / (zFar - zNear);

            M00 = 2.0f * zNear * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * zNear * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = (left + right) * invWidth;
            M21 = (top + bottom) * invHeight;
            M22 = zRange * zFar;
            M23 = -1.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = zRange * (zNear * zFar);
            M33 = 0.0f;
        }

        #endregion Projection Transform

        #region View Transform

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="bottom"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void Viewport(float left, float bottom, float width, float height, float zNear, float zFar)
        {
            float w2 = width / 2.0f;
            float h2 = height / 2.0f;

            M00 = w2;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = h2;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = (zFar - zNear) / 2.0f;
            M23 = 0.0f;

            M30 = left + w2;
            M31 = bottom + h2;
            M32 = (zNear + zFar) / 2.0f;
            M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewport"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Viewport(in ViewportF viewport)
        {
            Viewport(viewport.Bounds.X, viewport.Bounds.Y, viewport.Bounds.Width, viewport.Bounds.Height, viewport.MinDepth, viewport.MaxDepth);
        }
        
#endregion View Transform

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectPos"></param>
        /// <param name="cameraPos"></param>
        /// <param name="cameraUp"></param>
        /// <param name="cameraForward"></param>
        public void BillboardMatrixLH(in Vector3 objectPos, in Vector3 cameraPos, in Vector3 cameraUp, in Vector3 cameraForward)
        {
            float zAxisX = cameraPos.X - objectPos.X;
            float zAxisY = cameraPos.Y - objectPos.Y;
            float zAxisZ = cameraPos.Z - objectPos.Z;

            float lenSqr = zAxisX * zAxisX + zAxisY * zAxisY +
                           zAxisZ * zAxisZ;
            float invNorm = 0.0f;

            if (lenSqr < BillboardEpsilon)
            {
                zAxisX = -cameraForward.X;
                zAxisY = -cameraForward.Y;
                zAxisZ = -cameraForward.Z;
            }
            else
            {
                invNorm = MathHelper.FastSqrtInverse(lenSqr);

                zAxisX *= invNorm;
                zAxisY *= invNorm;
                zAxisZ *= invNorm;
            }


            float tempX = cameraUp.Y * zAxisZ - cameraUp.Z * zAxisY;
            float tempY = cameraUp.X * zAxisZ - cameraUp.Z * zAxisX;
            float tempZ = cameraUp.X * zAxisY - cameraUp.Y * zAxisX;

            lenSqr = tempX * tempX + tempY * tempY + tempZ * tempZ;
            invNorm = MathHelper.FastSqrtInverse(lenSqr);

            float xAxisX = tempX * invNorm;
            float xAxisY = tempY * invNorm;
            float xAxisZ = tempZ * invNorm;

            float yAxisX = zAxisY * xAxisZ - zAxisZ * xAxisY;
            float yAxisY = zAxisX * xAxisZ - zAxisZ * xAxisX;
            float yAxisZ = zAxisX * xAxisY - zAxisY * xAxisX;

            M00 = xAxisX;
            M01 = xAxisY;
            M02 = xAxisZ;
            M03 = 0.0f;

            M10 = yAxisX;
            M11 = yAxisY;
            M12 = yAxisZ;
            M13 = 0.0f;

            M20 = zAxisX;
            M21 = zAxisY;
            M22 = zAxisZ;
            M23 = 0.0f;

            M30 = objectPos.X;
            M31 = objectPos.Y;
            M32 = objectPos.Z;
            M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectPos"></param>
        /// <param name="cameraPos"></param>
        /// <param name="cameraUp"></param>
        /// <param name="cameraForward"></param>
        public void BillboardMatrixRH(in Vector3 objectPos, in Vector3 cameraPos, in Vector3 cameraUp, in Vector3 cameraForward)
        {
            float zAxisX = objectPos.X - cameraPos.X;
            float zAxisY = objectPos.Y - cameraPos.Y;
            float zAxisZ = objectPos.Z - cameraPos.Z;

            float lenSqr = zAxisX * zAxisX + zAxisY * zAxisY +
                           zAxisZ * zAxisZ;
            float invNorm = 0.0f;

            if (lenSqr < BillboardEpsilon)
            {
                zAxisX = -cameraForward.X;
                zAxisY = -cameraForward.Y;
                zAxisZ = -cameraForward.Z;
            }
            else
            {
                invNorm = MathHelper.FastSqrtInverse(lenSqr);

                zAxisX *= invNorm;
                zAxisY *= invNorm;
                zAxisZ *= invNorm;
            }


            float tempX = cameraUp.Y * zAxisZ - cameraUp.Z * zAxisY;
            float tempY = cameraUp.X * zAxisZ - cameraUp.Z * zAxisX;
            float tempZ = cameraUp.X * zAxisY - cameraUp.Y * zAxisX;

            lenSqr = tempX * tempX + tempY * tempY + tempZ * tempZ;
            invNorm = MathHelper.FastSqrtInverse(lenSqr);

            float xAxisX = tempX * invNorm;
            float xAxisY = tempY * invNorm;
            float xAxisZ = tempZ * invNorm;

            float yAxisX = zAxisY * xAxisZ - zAxisZ * xAxisY;
            float yAxisY = zAxisX * xAxisZ - zAxisZ * xAxisX;
            float yAxisZ = zAxisX * xAxisY - zAxisY * xAxisX;

            M00 = xAxisX;
            M01 = xAxisY;
            M02 = xAxisZ;
            M03 = 0.0f;

            M10 = yAxisX;
            M11 = yAxisY;
            M12 = yAxisZ;
            M13 = 0.0f;

            M20 = zAxisX;
            M21 = zAxisY;
            M22 = zAxisZ;
            M23 = 0.0f;

            M30 = objectPos.X;
            M31 = objectPos.Y;
            M32 = objectPos.Z;
            M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void ReflectionMatrix(in Plane value)
        {
            Plane.Normalize(value, out Plane p);

            float fx = -2.0f * p.Normal.X;
            float fy = -2.0f * p.Normal.Y;
            float fz = -2.0f * p.Normal.Z;

            M00 = fx * p.Normal.X + 1.0f;
            M01 = fy * p.Normal.X;
            M02 = fz * p.Normal.X;
            M03 = 0.0f;

            M10 = fx * p.Normal.Y;
            M11 = fy * p.Normal.Y + 1.0f;
            M12 = fz * p.Normal.Z;
            M13 = 0.0f;

            M20 = fx * p.Normal.Z;
            M21 = fy * p.Normal.Z;
            M22 = fz * p.Normal.Z + 1.0f;
            M23 = 0.0f;

            M30 = fx * p.Distance;
            M31 = fy * p.Distance;
            M32 = fz * p.Distance;
            M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lightDirection"></param>
        /// <param name="plane"></param>
        public void ShadowMatrix(in Vector3 lightDirection, in Plane plane)
        {
            Plane p = Plane.Normalize(plane);

            float dot = Vector3.Dot(p.Normal, lightDirection);
            float x = -p.Normal.X;
            float y = -p.Normal.Y;
            float z = -p.Normal.Z;
            float d = -p.Distance;

            M00 = x * lightDirection.X + dot;
            M01 = x * lightDirection.Y;
            M02 = x * lightDirection.Z;
            M03 = 0.0f;

            M10 = y * lightDirection.X;
            M11 = y * lightDirection.Y + dot;
            M12 = y * lightDirection.Z;
            M13 = 0.0f;

            M20 = z * lightDirection.X;
            M21 = z * lightDirection.Z;
            M22 = z * lightDirection.Z + dot;
            M23 = 0.0f;

            M30 = d * lightDirection.X;
            M31 = d * lightDirection.Y;
            M32 = d * lightDirection.Z;
            M33 = dot;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="forward"></param>
        /// <param name="up"></param>
        public void WorldMatrix(in Vector3 position, in Vector3 forward, in Vector3 up)
        {
            Vector3.Normalize(-forward, out Vector3 zAxis);
            Vector3.Cross(up, zAxis, out Vector3 xAxis);
            
            xAxis.Normalize();
            Vector3.Cross(zAxis, xAxis, out Vector3 yAxis);

            M00 = xAxis.X;
            M01 = xAxis.Y;
            M02 = xAxis.Z;
            M03 = 0.0f;

            M10 = yAxis.X;
            M11 = yAxis.Y;
            M12 = yAxis.Z;
            M13 = 0.0f;

            M20 = zAxis.X;
            M21 = zAxis.Y;
            M22 = zAxis.Z;
            M23 = 0.0f;

            M30 = position.X;
            M31 = position.Y;
            M32 = position.Z;
            M33 = 1.0f;
        }

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="axisAngle"></param>
        /// <returns></returns>
        public static Matrix4x4 FromAxisAngle(in AxisAngle axisAngle)
        {
            FromAxisAngle(axisAngle, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static Matrix4x4 FromEulerAngles(in EulerAngles eulerAngles, MathF.RotationOrder order)
        {
            FromEulerAngles(eulerAngles, order, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix4x4 FromEulerAnglesXYZ(in EulerAngles eulerAngles)
        {
            FromEulerAnglesXYZ(eulerAngles, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix4x4 FromEulerAnglesXZY(in EulerAngles eulerAngles)
        {
            FromEulerAnglesXZY(eulerAngles, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix4x4 FromEulerAnglesYXZ(in EulerAngles eulerAngles)
        {
            FromEulerAnglesYXZ(eulerAngles, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix4x4 FromEulerAnglesYZX(in EulerAngles eulerAngles)
        {
            FromEulerAnglesYXZ(eulerAngles, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix4x4 FromEulerAnglesZXY(in EulerAngles eulerAngles)
        {
            FromEulerAnglesZXY(eulerAngles, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix4x4 FromEulerAnglesZYX(in EulerAngles eulerAngles)
        {
            FromEulerAnglesZYX(eulerAngles, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix4x4 FromEulerAnglesXYX(in EulerAngles eulerAngles)
        {
            FromEulerAnglesXYX(eulerAngles, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix4x4 FromEulerAnglesXZX(in EulerAngles eulerAngles)
        {
            FromEulerAnglesXZX(eulerAngles, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix4x4 FromEulerAnglesYXY(in EulerAngles eulerAngles)
        {
            FromEulerAnglesYXY(eulerAngles, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix4x4 FromEulerAnglesYZY(in EulerAngles eulerAngles)
        {
            FromEulerAnglesYXY(eulerAngles, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix4x4 FromEulerAnglesZXZ(in EulerAngles eulerAngles)
        {
            FromEulerAnglesZXZ(eulerAngles, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <returns></returns>
        public static Matrix4x4 FromEulerAnglesZYZ(in EulerAngles eulerAngles)
        {
            FromEulerAnglesZYZ(eulerAngles, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quaternion"></param>
        /// <returns></returns>
        public static Matrix4x4 FromQuaternion(in Quaternion quaternion)
        {
            FromQuaternion(in quaternion, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        public static Matrix4x4 FromTRS(in Vector3 translation, in Quaternion rotation, in Vector3 scaling)
        {
            FromTRS(translation, rotation, scaling, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix4x4 Invert(in Matrix4x4 matrix)
        {
            Invert(matrix, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public static Matrix4x4 Transform(in Matrix4x4 matrix, in Quaternion rotation)
        {
            Transform(matrix, rotation, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix4x4 Transpose(in Matrix4x4 matrix)
        {
            Transpose(matrix, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="axisAngle"></param>
        /// <param name="result"></param>
        public static void FromAxisAngle(in AxisAngle axisAngle, out Matrix4x4 result)
        {
            MathF.SinCos(axisAngle.Angle, out float sin, out float cos);

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
            result.M30 = 0.0f;

            result.M01 = c0 * xy + zs;
            result.M11 = cos + c0 * y2;
            result.M21 = c0 * yz - xs;
            result.M31 = 0.0f;

            result.M02 = c0 * xz - ys;
            result.M12 = c0 * yz + xs;
            result.M22 = cos + c0 * z2;
            result.M32 = 0.0f;

            result.M03 = 0.0f;
            result.M13 = 0.0f;
            result.M23 = 0.0f;
            result.M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static void FromEulerAngles(in EulerAngles eulerAngles, MathF.RotationOrder order, out Matrix4x4 result)
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
        /// <param name="euler"></param>
        /// <param name="result"></param>
        public static void FromEulerAnglesXYZ(in EulerAngles eulerAngles, out Matrix4x4 result)
        {
            MathF.SinCos(eulerAngles.Pitch, out float sp, out float cp);
            MathF.SinCos(eulerAngles.Yaw, out float sy, out float cy);
            MathF.SinCos(eulerAngles.Roll, out float sr, out float cr);

            result.M00 = cy * cr;
            result.M01 = -cy * sr;
            result.M02 = sy;
            result.M03 = 0.0f;

            result.M10 = cr * sp * sy + cp * sr;
            result.M11 = cp * cr - sp * sy * sr;
            result.M12 = -cy * sp;
            result.M13 = 0.0f;

            result.M20 = -cp * cr * sy + sp * sr;
            result.M21 = cr * sp + cp * sy * sr;
            result.M22 = cp * cy;
            result.M23 = 0.0f;

            result.M30 = 0.0f;
            result.M31 = 0.0f;
            result.M32 = 0.0f;
            result.M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="euler"></param>
        /// <param name="result"></param>
        public static void FromEulerAnglesXZY(in EulerAngles eulerAngles, out Matrix4x4 result)
        {
            MathF.SinCos(eulerAngles.Pitch, out float sp, out float cp);
            MathF.SinCos(eulerAngles.Yaw, out float sy, out float cy);
            MathF.SinCos(eulerAngles.Roll, out float sr, out float cr);

            result.M00 = cy * cr;
            result.M01 = -sr;
            result.M02 = cr * sy;
            result.M03 = 0.0f;

            result.M10 = sp * sy + cp * cy * sr;
            result.M11 = cp * cr;
            result.M12 = cy * sp + cp * sy * sr;
            result.M13 = 0.0f;

            result.M20 = cp * sy + cy * sp * sr;
            result.M21 = -cr * sp;
            result.M22 = cp * cy - sp * sy * sr;
            result.M23 = 0.0f;

            result.M30 = 0.0f;
            result.M31 = 0.0f;
            result.M32 = 0.0f;
            result.M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="euler"></param>
        /// <param name="result"></param>
        public static void FromEulerAnglesYXZ(in EulerAngles eulerAngles, out Matrix4x4 result)
        {
            MathF.SinCos(eulerAngles.Pitch, out float sp, out float cp);
            MathF.SinCos(eulerAngles.Yaw, out float sy, out float cy);
            MathF.SinCos(eulerAngles.Roll, out float sr, out float cr);

            result.M00 = cy * cr + sp * sy * sr;
            result.M01 = cp * sp * sy - cy * sr;
            result.M02 = cp * sy;
            result.M03 = 0.0f;

            result.M10 = cp * sr;
            result.M11 = cp * cr;
            result.M12 = -sp;
            result.M13 = 0.0f;

            result.M20 = -cr * sy + cy * sp * sr;
            result.M21 = cy * cr * sp + sy * sr;
            result.M22 = cp * cy;
            result.M23 = 0.0f;

            result.M30 = 0.0f;
            result.M31 = 0.0f;
            result.M32 = 0.0f;
            result.M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="euler"></param>
        /// <param name="result"></param>
        public static void FromEulerAnglesYZX(in EulerAngles eulerAngles, out Matrix4x4 result)
        {
            MathF.SinCos(eulerAngles.Pitch, out float sp, out float cp);
            MathF.SinCos(eulerAngles.Yaw, out float sy, out float cy);
            MathF.SinCos(eulerAngles.Roll, out float sr, out float cr);

            result.M00 = cy * cr;
            result.M01 = sp * sy - cp * cy * sr;
            result.M02 = cp * sy + cy * sp * sr;
            result.M03 = 0.0f;

            result.M10 = sr;
            result.M11 = cp * cr;
            result.M12 = -cr * sp;
            result.M13 = 0.0f;

            result.M20 = -cp * sy;
            result.M21 = cy * sp + cp * sy * sr;
            result.M22 = cp * cy - sp * sy * sr;
            result.M23 = 0.0f;

            result.M30 = 0.0f;
            result.M31 = 0.0f;
            result.M32 = 0.0f;
            result.M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="euler"></param>
        /// <param name="result"></param>
        public static void FromEulerAnglesZXY(in EulerAngles eulerAngles, out Matrix4x4 result)
        {
            MathF.SinCos(eulerAngles.Pitch, out float sp, out float cp);
            MathF.SinCos(eulerAngles.Yaw, out float sy, out float cy);
            MathF.SinCos(eulerAngles.Roll, out float sr, out float cr);

            result.M00 = cy * cr - sp * sy * sr;
            result.M01 = -cp * sr;
            result.M02 = cr * sy + cy * sp * sr;
            result.M03 = 0.0f;

            result.M10 = cp * sp * sy + cy * sr;
            result.M11 = cp * cr;
            result.M12 = -cy * cr * sp + sy * sr;
            result.M13 = 0.0f;

            result.M20 = -cp * sy;
            result.M21 = sp;
            result.M22 = cp * cy;
            result.M23 = 0.0f;

            result.M30 = 0.0f;
            result.M31 = 0.0f;
            result.M32 = 0.0f;
            result.M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="euler"></param>
        /// <param name="result"></param>
        public static void FromEulerAnglesZYX(in EulerAngles eulerAngles, out Matrix4x4 result)
        {
            MathF.SinCos(eulerAngles.Pitch, out float sp, out float cp);
            MathF.SinCos(eulerAngles.Yaw, out float sy, out float cy);
            MathF.SinCos(eulerAngles.Roll, out float sr, out float cr);

            result.M00 = cy * cr;
            result.M01 = cr * sp * sy - cp * sr;
            result.M02 = cp * cr * sy + sp * sr;
            result.M03 = 0.0f;

            result.M10 = cy * cr;
            result.M11 = cp * cr + sp * sy * sr;
            result.M12 = -cr * sp + cp * sy * sr;
            result.M13 = 0.0f;

            result.M20 = -sy;
            result.M21 = cy * sp;
            result.M22 = cp * cy;
            result.M23 = 0.0f;

            result.M30 = 0.0f;
            result.M31 = 0.0f;
            result.M32 = 0.0f;
            result.M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="quaternion"></param>
        public static void FromEulerAnglesXYX(in EulerAngles eulerAngles, out Matrix4x4 result)
        {
            MathF.SinCos(eulerAngles.Pitch, out float sp, out float cp);
            MathF.SinCos(eulerAngles.Yaw, out float sy, out float cy);
            MathF.SinCos(eulerAngles.Roll, out float sr, out float cr);

            result.M00 = cy;
            result.M01 = sy * sr;
            result.M02 = sy * cr;
            result.M03 = 0.0f;

            result.M10 = sy * sp;
            result.M11 = cp * cr - cy * sp * sr;
            result.M12 = -cy * cr * sp - cp * sr;
            result.M13 = 0.0f;
            
            result.M20 = -sy * cp;
            result.M21 = cr * sp + cy * cp * sr;
            result.M22 = cy * cp * cr - sp * sr;
            result.M23 = 0.0f;

            result.M30 = 0.0f;
            result.M31 = 0.0f;
            result.M32 = 0.0f;
            result.M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="quaternion"></param>
        public static void FromEulerAnglesXZX(in EulerAngles eulerAngles, out Matrix4x4 result)
        {
            MathF.SinCos(eulerAngles.Pitch, out float sp, out float cp);
            MathF.SinCos(eulerAngles.Yaw, out float sy, out float cy);
            MathF.SinCos(eulerAngles.Roll, out float sr, out float cr);

            result.M00 = cr;
            result.M01 = -sr * cy;
            result.M02 = sr * sy;
            result.M03 = 0.0f;

            result.M10 = sr * cp;
            result.M11 = cr * cp * cy - sp * sy;
            result.M12 = -cy * sp - cr * cp * sy;
            result.M13 = 0.0f;

            result.M20 = sr * sp;
            result.M21 = cr * cy * sp + cp * sy;
            result.M22 = cp * cy - cr * sp * sy;
            result.M23 = 0.0f;

            result.M30 = 0.0f;
            result.M31 = 0.0f;
            result.M32 = 0.0f;
            result.M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="quaternion"></param>
        public static void FromEulerAnglesYXY(in EulerAngles eulerAngles, out Matrix4x4 result)
        {
            MathF.SinCos(eulerAngles.Pitch, out float sp, out float cp);
            MathF.SinCos(eulerAngles.Yaw, out float sy, out float cy);
            MathF.SinCos(eulerAngles.Roll, out float sr, out float cr);

            result.M00 = cy * cr - cp * sy * sr;
            result.M01 = sp * sy;
            result.M02 = cp * cr * sp + cy * sr;
            result.M03 = 0.0f;

            result.M10 = sp * sr;
            result.M11 = cp;
            result.M12 = -sp * cr;
            result.M13 = 0.0f;

            result.M20 = -cr * sr - cp * cy * sr;
            result.M21 = sp * cy;
            result.M22 = cp * cy * cr - sy * sr;
            result.M23 = 0.0f;

            result.M30 = 0.0f;
            result.M31 = 0.0f;
            result.M32 = 0.0f;
            result.M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="quaternion"></param>
        public static void FromEulerAnglesYZY(in EulerAngles eulerAngles, out Matrix4x4 result)
        {
            MathF.SinCos(eulerAngles.Pitch, out float sp, out float cp);
            MathF.SinCos(eulerAngles.Yaw, out float sy, out float cy);
            MathF.SinCos(eulerAngles.Roll, out float sr, out float cr);

            result.M00 = cr * cy * cp - sy * sp;
            result.M01 = -sr * cy;
            result.M02 = cp * sy + cr * cy * sp;
            result.M03 = 0.0f;

            result.M10 = sr * cp;
            result.M11 = cr;
            result.M12 = sr * sp;
            result.M13 = 0.0f;

            result.M20 = -cr * cp * sy - cy * sp;
            result.M21 = sr * sy;
            result.M22 = cy * cp - cr * sy * sp;
            result.M23 = 0.0f;

            result.M30 = 0.0f;
            result.M31 = 0.0f;
            result.M32 = 0.0f;
            result.M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="quaternion"></param>
        public static void FromEulerAnglesZXZ(in EulerAngles eulerAngles, out Matrix4x4 result)
        {
            // yaw = z1;
            MathF.SinCos(eulerAngles.Pitch, out float sp, out float cp);
            MathF.SinCos(eulerAngles.Yaw, out float sy, out float cy);
            MathF.SinCos(eulerAngles.Roll, out float sr, out float cr);

            result.M00 = cr * cy - cp * sr * sy;
            result.M01 = -cp * cy * sr - cr * sy;
            result.M02 = sp * sr;
            result.M03 = 0.0f;

            result.M10 = cy * sr + cp * cr * sy;
            result.M11 = cp * cr * cy - sr * sy;
            result.M12 = -sp * cr;
            result.M13 = 0.0f;

            result.M20 = sp * sy;
            result.M21 = sp * cy;
            result.M22 = cp;
            result.M23 = 0.0f;

            result.M30 = 0.0f;
            result.M31 = 0.0f;
            result.M32 = 0.0f;
            result.M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eulerAngles"></param>
        /// <param name="quaternion"></param>
        public static void FromEulerAnglesZYZ(in EulerAngles eulerAngles, out Matrix4x4 result)
        {
            MathF.SinCos(eulerAngles.Pitch, out float sp, out float cp);
            MathF.SinCos(eulerAngles.Yaw, out float sy, out float cy);
            MathF.SinCos(eulerAngles.Roll, out float sr, out float cr);

            result.M00 = cy * cr * cp - sr * sp;
            result.M01 = -cp * sr - cy * cr * sp;
            result.M02 = sy * cr;
            result.M03 = 0.0f;

            result.M10 = cy * cp * sr;
            result.M11 = cr * cp - cy * sr * sp;
            result.M12 = sy * sr;
            result.M13 = 0.0f;

            result.M20 = -sy * cp;
            result.M21 = sy * sp;
            result.M22 = cy;
            result.M23 = 0.0f;

            result.M30 = 0.0f;
            result.M31 = 0.0f;
            result.M32 = 0.0f;
            result.M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quaternion"></param>
        /// <param name="result"></param>
        public static void FromQuaternion(in Quaternion quaternion, out Matrix4x4 result)
        {
            // Compute rotation matrix
            float x2 = quaternion.X + quaternion.X;
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
            result.M30 = 0.0f;

            result.M01 = xy2 + wz2;
            result.M11 = 1.0f - xx2 - zz2;
            result.M21 = yz2 - wx2;
            result.M31 = 0.0f;

            result.M02 = xz2 - wy2;
            result.M12 = yz2 + wx2;
            result.M22 = 1.0f - xx2 - yy2;
            result.M32 = 0.0f;

            result.M03 = 0.0f;
            result.M13 = 0.0f;
            result.M23 = 0.0f;
            result.M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="translation"></param>
        /// <param name="rotation"></param>
        /// <param name="scaling"></param>
        /// <param name="result"></param>
        public static void FromTRS(in Vector3 translation, in Quaternion rotation, in Vector3 scaling, out Matrix4x4 result)
        {
            float x2 = rotation.X + rotation.X;
            float y2 = rotation.Y + rotation.Y;
            float z2 = rotation.Z + rotation.Z;

            float wx2 = rotation.W * x2;
            float wy2 = rotation.W * y2;
            float wz2 = rotation.W * z2;
            float xx2 = rotation.X * x2;
            float xy2 = rotation.X * y2;
            float xz2 = rotation.X * z2;
            float yy2 = rotation.Y * y2;
            float yz2 = rotation.Y * z2;
            float zz2 = rotation.Z * z2;

            result.M00 = (1.0f - yy2 - zz2) * scaling.X;
            result.M01 = (xy2 + wz2) * scaling.X;
            result.M02 = (xz2 - wy2) * scaling.X;
            result.M03 = 0.0f;

            result.M10 = (xy2 - wz2) * scaling.Y;
            result.M11 = (1.0f - xx2 - zz2) * scaling.Y;
            result.M12 = (yz2 + wx2) * scaling.Y;
            result.M13 = 0.0f;

            result.M20 = (xz2 + wy2) * scaling.Z;
            result.M21 = (yz2 - wx2) * scaling.Z;
            result.M22 = (1.0f - xx2 - yy2) * scaling.Z;
            result.M23 = 0.0f;

            result.M30 = translation.X;
            result.M31 = translation.Y;
            result.M32 = translation.Z;
            result.M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        public static bool Invert(in Matrix4x4 matrix, out Matrix4x4 result)
        {
            //                                       -1
            // If you have matrix M, inverse Matrix M   can compute
            //
            //     -1       1      
            //    M   = --------- A
            //            det(M)
            //
            // A is adjugate (adjoint) of M, where,
            //
            //      T
            // A = C
            //
            // C is Cofactor matrix of M, where,
            //           i + j
            // C   = (-1)      * det(M  )
            //  ij                    ij
            //
            //     [ a b c d ]
            // M = [ e f g h ]
            //     [ i j k l ]
            //     [ m n o p ]
            //
            // First Row
            //           2 | f g h |
            // C   = (-1)  | j k l | = + ( f ( kp - lo ) - g ( jp - ln ) + h ( jo - kn ) )
            //  11         | n o p |
            //
            //           3 | e g h |
            // C   = (-1)  | i k l | = - ( e ( kp - lo ) - g ( ip - lm ) + h ( io - km ) )
            //  12         | m o p |
            //
            //           4 | e f h |
            // C   = (-1)  | i j l | = + ( e ( jp - ln ) - f ( ip - lm ) + h ( in - jm ) )
            //  13         | m n p |
            //
            //           5 | e f g |
            // C   = (-1)  | i j k | = - ( e ( jo - kn ) - f ( io - km ) + g ( in - jm ) )
            //  14         | m n o |
            //
            // Second Row
            //           3 | b c d |
            // C   = (-1)  | j k l | = - ( b ( kp - lo ) - c ( jp - ln ) + d ( jo - kn ) )
            //  21         | n o p |
            //
            //           4 | a c d |
            // C   = (-1)  | i k l | = + ( a ( kp - lo ) - c ( ip - lm ) + d ( io - km ) )
            //  22         | m o p |
            //
            //           5 | a b d |
            // C   = (-1)  | i j l | = - ( a ( jp - ln ) - b ( ip - lm ) + d ( in - jm ) )
            //  23         | m n p |
            //
            //           6 | a b c |
            // C   = (-1)  | i j k | = + ( a ( jo - kn ) - b ( io - km ) + c ( in - jm ) )
            //  24         | m n o |
            //
            // Third Row
            //           4 | b c d |
            // C   = (-1)  | f g h | = + ( b ( gp - ho ) - c ( fp - hn ) + d ( fo - gn ) )
            //  31         | n o p |
            //
            //           5 | a c d |
            // C   = (-1)  | e g h | = - ( a ( gp - ho ) - c ( ep - hm ) + d ( eo - gm ) )
            //  32         | m o p |
            //
            //           6 | a b d |
            // C   = (-1)  | e f h | = + ( a ( fp - hn ) - b ( ep - hm ) + d ( en - fm ) )
            //  33         | m n p |
            //
            //           7 | a b c |
            // C   = (-1)  | e f g | = - ( a ( fo - gn ) - b ( eo - gm ) + c ( en - fm ) )
            //  34         | m n o |
            //
            // Fourth Row
            //           5 | b c d |
            // C   = (-1)  | f g h | = - ( b ( gl - hk ) - c ( fl - hj ) + d ( fk - gj ) )
            //  41         | j k l |
            //
            //           6 | a c d |
            // C   = (-1)  | e g h | = + ( a ( gl - hk ) - c ( el - hi ) + d ( ek - gi ) )
            //  42         | i k l |
            //
            //           7 | a b d |
            // C   = (-1)  | e f h | = - ( a ( fl - hj ) - b ( el - hi ) + d ( ej - fi ) )
            //  43         | i j l |
            //
            //           8 | a b c |
            // C   = (-1)  | e f g | = + ( a ( fk - gj ) - b ( ek - gi ) + c ( ej - fi ) )
            //  44         | i j k |
            //
            // Cost of operation
            // 53 adds, 104 muls, and 1 div.

            // a = M00, b = M01, c = M02, d = M03,
            // e = M10, f = M11, g = M12, h = M13,
            // i = M20, j = M21, k = M22, l = M23,
            // m = M30, n = M31, o = M32, p = M33
            float kp_lo = matrix.M22 * matrix.M33 - matrix.M23 * matrix.M32;
            float jp_ln = matrix.M21 * matrix.M33 - matrix.M23 * matrix.M31;
            float jo_kn = matrix.M21 * matrix.M32 - matrix.M22 * matrix.M31;
            float ip_lm = matrix.M20 * matrix.M33 - matrix.M23 * matrix.M30;
            float io_km = matrix.M20 * matrix.M32 - matrix.M22 * matrix.M30;
            float in_jm = matrix.M20 * matrix.M31 - matrix.M21 * matrix.M30;

            float a00 = +(matrix.M11 * kp_lo - matrix.M12 * jp_ln + matrix.M13 * jo_kn);
            float a01 = -(matrix.M10 * kp_lo - matrix.M12 * ip_lm + matrix.M13 * io_km);
            float a02 = +(matrix.M10 * jp_ln - matrix.M11 * ip_lm + matrix.M13 * in_jm);
            float a03 = -(matrix.M10 * jo_kn - matrix.M11 * io_km + matrix.M12 * in_jm);

            float det = matrix.M00 * a00 + matrix.M01 * a01 +
                        matrix.M02 * a02 + matrix.M03 * a03;

            if (MathF.Abs(det) < float.Epsilon)
            {
                result = new Matrix4x4(float.NaN);
                return false;
            }

            float invDet = 1.0f / det;

            result.M00 = a00 * invDet;
            result.M10 = a01 * invDet;
            result.M20 = a02 * invDet;
            result.M30 = a03 * invDet;

            result.M01 = -(matrix.M01 * kp_lo - matrix.M02 * jp_ln + matrix.M03 * jo_kn) * invDet;
            result.M11 = +(matrix.M00 * kp_lo - matrix.M02 * ip_lm + matrix.M03 * io_km) * invDet;
            result.M21 = -(matrix.M00 * jp_ln - matrix.M01 * ip_lm + matrix.M03 * in_jm) * invDet;
            result.M31 = +(matrix.M00 * jo_kn - matrix.M01 * io_km + matrix.M02 * in_jm) * invDet;

            float gp_ho = matrix.M12 * matrix.M33 - matrix.M13 * matrix.M32;
            float fp_hn = matrix.M11 * matrix.M33 - matrix.M13 * matrix.M31;
            float fo_gn = matrix.M11 * matrix.M32 - matrix.M12 * matrix.M31;
            float ep_hm = matrix.M10 * matrix.M33 - matrix.M13 * matrix.M30;
            float eo_gm = matrix.M10 * matrix.M32 - matrix.M12 * matrix.M30;
            float en_fm = matrix.M10 * matrix.M31 - matrix.M11 * matrix.M30;

            result.M02 = +(matrix.M01 * gp_ho - matrix.M02 * fp_hn + matrix.M03 * fo_gn) * invDet;
            result.M12 = -(matrix.M00 * gp_ho - matrix.M02 * ep_hm + matrix.M03 * eo_gm) * invDet;
            result.M22 = +(matrix.M00 * fp_hn - matrix.M01 * ep_hm + matrix.M03 * en_fm) * invDet;
            result.M32 = -(matrix.M00 * fo_gn - matrix.M01 * eo_gm + matrix.M02 * en_fm) * invDet;

            float gl_hk = matrix.M12 * matrix.M23 - matrix.M13 * matrix.M22;
            float fl_hj = matrix.M11 * matrix.M23 - matrix.M13 * matrix.M21;
            float fk_gj = matrix.M11 * matrix.M22 - matrix.M12 * matrix.M21;
            float el_hi = matrix.M10 * matrix.M23 - matrix.M13 * matrix.M20;
            float ek_gi = matrix.M10 * matrix.M22 - matrix.M12 * matrix.M20;
            float ej_fi = matrix.M10 * matrix.M21 - matrix.M11 * matrix.M20;

            result.M03 = -(matrix.M01 * gl_hk - matrix.M02 * fl_hj + matrix.M03 * fk_gj) * invDet;
            result.M13 = +(matrix.M00 * gl_hk - matrix.M02 * el_hi + matrix.M03 * ek_gi) * invDet;
            result.M23 = -(matrix.M00 * fl_hj - matrix.M01 * el_hi + matrix.M03 * ej_fi) * invDet;
            result.M33 = +(matrix.M00 * fk_gj - matrix.M01 * ek_gi + matrix.M02 * ej_fi) * invDet;

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        public static void Orthogonalize(in Matrix4x4 matrix, out Matrix4x4 result)
        {
            result = matrix;

            float div0, div1, div2;
            float dot0, dot1, dot2, dot3, dot4, dot5;
           
            dot0 = result.M00 * result.M00 + result.M01 * result.M01 +
                   result.M02 * result.M02 + result.M03 * result.M03;
            dot1 = result.M10 * result.M10 + result.M11 * result.M11 +
                   result.M12 * result.M12 + result.M13 * result.M13;
            dot2 = result.M20 * result.M20 + result.M21 * result.M21 +
                   result.M22 * result.M22 + result.M23 * result.M23;

            dot3 = result.M00 * result.M10 + result.M01 * result.M11 +
                   result.M02 * result.M12 + result.M03 * result.M13;

            div0 = dot3 / dot0;

            result.M10 -= div0 * result.M00;
            result.M11 -= div0 * result.M01;
            result.M12 -= div0 * result.M02;
            result.M13 -= div0 * result.M03;

            dot3 = result.M00 * result.M20 + result.M01 * result.M21 +
                   result.M02 * result.M22 + result.M03 * result.M23;
            dot4 = result.M10 * result.M20 + result.M11 * result.M21 +
                   result.M12 * result.M22 + result.M13 * result.M23;

            div0 = dot3 / dot0;
            div1 = dot4 / dot1;

            result.M20 -= (div0 * result.M00 + div1 * result.M10);
            result.M21 -= (div0 * result.M01 + div1 * result.M11);
            result.M22 -= (div0 * result.M02 + div1 * result.M12);
            result.M23 -= (div0 * result.M03 + div1 * result.M13);

            dot3 = result.M00 * result.M30 + result.M01 * result.M31 +
                   result.M02 * result.M32 + result.M03 * result.M33;
            dot4 = result.M10 * result.M30 + result.M11 * result.M31 +
                   result.M12 * result.M32 + result.M13 * result.M33;
            dot5 = result.M20 * result.M30 + result.M21 * result.M31 +
                   result.M22 * result.M32 + result.M23 * result.M33;

            div0 = dot3 / dot0;
            div1 = dot4 / dot1;
            div2 = dot5 / dot2;

            result.M30 -= (div0 * result.M00 + div1 * result.M10 + div2 * result.M20);
            result.M31 -= (div0 * result.M01 + div1 * result.M11 + div2 * result.M21);
            result.M32 -= (div0 * result.M02 + div1 * result.M12 + div2 * result.M22);
            result.M33 -= (div0 * result.M03 + div1 * result.M13 + div2 * result.M23);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        public static void Orthonormalize(in Matrix4x4 matrix, out Matrix4x4 result)
        {
            result = matrix;

            float dot0, dot1, dot2;
            float invSqrt = MathHelper.FastSqrtInverse(result.M00 * result.M00 + result.M01 * result.M01 + 
                                                       result.M02 * result.M02 + result.M03 * result.M03);
            if (float.IsInfinity(invSqrt) == false)
            {
                result.M00 *= invSqrt;
                result.M01 *= invSqrt;
                result.M02 *= invSqrt;
                result.M03 *= invSqrt;
            }

            dot0 = (result.M00 * result.M10 + result.M01 * result.M11 +
                    result.M02 * result.M12 + result.M03 * result.M13);
            
            result.M10 -= dot0 * result.M00;
            result.M11 -= dot0 * result.M01;
            result.M12 -= dot0 * result.M02;
            result.M13 -= dot0 * result.M03;

            invSqrt = MathHelper.FastSqrtInverse(result.M10 * result.M10 + result.M11 * result.M11 +
                                                 result.M12 * result.M12 + result.M13 * result.M13);
            if (float.IsInfinity(invSqrt) == false)
            {
                result.M10 *= invSqrt;
                result.M11 *= invSqrt;
                result.M12 *= invSqrt;
                result.M13 *= invSqrt;
            }

            dot0 = (result.M00 * result.M20 + result.M01 * result.M21 +
                    result.M02 * result.M22 + result.M03 * result.M23);
            dot1 = (result.M10 * result.M20 + result.M11 * result.M21 +
                    result.M12 * result.M22 + result.M13 * result.M23);

            result.M20 -= dot0 * result.M00 + dot1 * result.M10;
            result.M21 -= dot0 * result.M01 + dot1 * result.M11;
            result.M22 -= dot0 * result.M02 + dot1 * result.M12;
            result.M23 -= dot0 * result.M03 + dot1 * result.M13;

            invSqrt = MathHelper.FastSqrtInverse(result.M20 * result.M20 + result.M21 * result.M21 +
                                                 result.M22 * result.M22 + result.M23 * result.M23);
            if (float.IsInfinity(invSqrt) == false)
            {
                result.M20 *= invSqrt;
                result.M21 *= invSqrt;
                result.M22 *= invSqrt;
                result.M23 *= invSqrt;
            }

            dot0 = (result.M00 * result.M30 + result.M01 * result.M31 +
                    result.M02 * result.M32 + result.M03 * result.M33);
            dot1 = (result.M10 * result.M30 + result.M11 * result.M31 +
                    result.M12 * result.M32 + result.M13 * result.M33);
            dot2 = (result.M20 * result.M30 + result.M21 * result.M31 +
                    result.M22 * result.M32 + result.M23 * result.M33);

            result.M30 -= dot0 * result.M00 + dot1 * result.M10 - dot2 * result.M30;
            result.M31 -= dot0 * result.M01 + dot1 * result.M11 - dot2 * result.M31;
            result.M32 -= dot0 * result.M02 + dot1 * result.M12 - dot2 * result.M32;
            result.M33 -= dot0 * result.M03 + dot1 * result.M13 - dot2 * result.M33;

            invSqrt = MathHelper.FastSqrtInverse(result.M30 * result.M30 + result.M31 * result.M31 +
                                                 result.M32 * result.M32 + result.M33 * result.M33);
            if (float.IsInfinity(invSqrt) == false)
            {
                result.M30 *= invSqrt;
                result.M31 *= invSqrt;
                result.M32 *= invSqrt;
                result.M33 *= invSqrt;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="rotation"></param>
        /// <param name="result"></param>
        public static void Transform(in Matrix4x4 matrix, in Quaternion rotation, out Matrix4x4 result)
        {
            // Compute rotation matrix.
            float x2 = rotation.X + rotation.X;
            float y2 = rotation.Y + rotation.Y;
            float z2 = rotation.Z + rotation.Z;

            float wx2 = rotation.W * x2;
            float wy2 = rotation.W * y2;
            float wz2 = rotation.W * z2;
            float xx2 = rotation.X * x2;
            float xy2 = rotation.X * y2;
            float xz2 = rotation.X * z2;
            float yy2 = rotation.Y * y2;
            float yz2 = rotation.Y * z2;
            float zz2 = rotation.Z * z2;

            float q11 = 1.0f - yy2 - zz2;
            float q21 = xy2 - wz2;
            float q31 = xz2 + wy2;

            float q12 = xy2 + wz2;
            float q22 = 1.0f - xx2 - zz2;
            float q32 = yz2 - wx2;

            float q13 = xz2 - wy2;
            float q23 = yz2 + wx2;
            float q33 = 1.0f - xx2 - yy2;

            // First row
            result.M00 = matrix.M00 * q11 + matrix.M01 * q21 + matrix.M02 * q31;
            result.M01 = matrix.M00 * q12 + matrix.M01 * q22 + matrix.M02 * q32;
            result.M02 = matrix.M00 * q13 + matrix.M01 * q23 + matrix.M02 * q33;
            result.M03 = matrix.M03;

            // Second row
            result.M10 = matrix.M10 * q11 + matrix.M11 * q21 + matrix.M12 * q31;
            result.M11 = matrix.M10 * q12 + matrix.M11 * q22 + matrix.M12 * q32;
            result.M12 = matrix.M10 * q13 + matrix.M11 * q23 + matrix.M12 * q33;
            result.M13 = matrix.M13;

            // Third row
            result.M20 = matrix.M20 * q11 + matrix.M21 * q21 + matrix.M22 * q31;
            result.M21 = matrix.M20 * q12 + matrix.M21 * q22 + matrix.M22 * q32;
            result.M22 = matrix.M20 * q13 + matrix.M21 * q23 + matrix.M22 * q33;
            result.M23 = matrix.M23;

            // Fourth row
            result.M30 = matrix.M30 * q11 + matrix.M31 * q21 + matrix.M32 * q31;
            result.M31 = matrix.M30 * q12 + matrix.M31 * q22 + matrix.M32 * q32;
            result.M32 = matrix.M30 * q13 + matrix.M31 * q23 + matrix.M32 * q33;
            result.M33 = matrix.M33;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        public static void Transpose(in Matrix4x4 matrix, out Matrix4x4 result)
        {
            result.M00 = matrix.M00;
            result.M01 = matrix.M10;
            result.M02 = matrix.M20;
            result.M03 = matrix.M30;

            result.M10 = matrix.M01;
            result.M11 = matrix.M11;
            result.M12 = matrix.M21;
            result.M13 = matrix.M31;

            result.M20 = matrix.M02;
            result.M21 = matrix.M12;
            result.M22 = matrix.M22;
            result.M23 = matrix.M32;

            result.M30 = matrix.M03;
            result.M31 = matrix.M13;
            result.M32 = matrix.M23;
            result.M33 = matrix.M32;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Add(in Matrix4x4 left, float right, out Matrix4x4 result)
        {
            result.M00 = left.M00 + right;
            result.M01 = left.M01 + right;
            result.M02 = left.M02 + right;
            result.M03 = left.M03 + right;

            result.M10 = left.M10 + right;
            result.M11 = left.M11 + right;
            result.M12 = left.M12 + right;
            result.M13 = left.M13 + right;

            result.M20 = left.M20 + right;
            result.M21 = left.M21 + right;
            result.M22 = left.M22 + right;
            result.M23 = left.M23 + right;

            result.M30 = left.M30 + right;
            result.M31 = left.M31 + right;
            result.M32 = left.M32 + right;
            result.M33 = left.M33 + right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>   
        public static void Add(in Matrix4x4 left, in Matrix4x4 right, out Matrix4x4 result)
        {
            result.M00 = left.M00 + right.M00;
            result.M01 = left.M01 + right.M01;
            result.M02 = left.M02 + right.M02;
            result.M03 = left.M03 + right.M03;

            result.M10 = left.M10 + right.M10;
            result.M11 = left.M11 + right.M11;
            result.M12 = left.M12 + right.M12;
            result.M13 = left.M03 + right.M03;

            result.M20 = left.M20 + right.M20;
            result.M21 = left.M21 + right.M21;
            result.M22 = left.M22 + right.M22;
            result.M23 = left.M23 + right.M23;

            result.M30 = left.M30 + right.M30;
            result.M31 = left.M31 + right.M31;
            result.M32 = left.M32 + right.M32;
            result.M33 = left.M33 + right.M33;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>     
        public static void Subtract(in Matrix4x4 left, float right, out Matrix4x4 result)
        {
            result.M00 = left.M00 - right;
            result.M01 = left.M01 - right;
            result.M02 = left.M02 - right;
            result.M03 = left.M03 - right;

            result.M10 = left.M10 - right;
            result.M11 = left.M11 - right;
            result.M12 = left.M12 - right;
            result.M13 = left.M13 - right;

            result.M20 = left.M20 - right;
            result.M21 = left.M21 - right;
            result.M22 = left.M22 - right;
            result.M23 = left.M23 - right;

            result.M30 = left.M30 - right;
            result.M31 = left.M31 - right;
            result.M32 = left.M32 - right;
            result.M33 = left.M33 - right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Subtract(in Matrix4x4 left, in Matrix4x4 right, out Matrix4x4 result)
        {
            result.M00 = left.M00 - right.M00;
            result.M01 = left.M01 - right.M01;
            result.M02 = left.M02 - right.M02;
            result.M03 = left.M03 - right.M03;

            result.M10 = left.M10 - right.M10;
            result.M11 = left.M11 - right.M11;
            result.M12 = left.M12 - right.M12;
            result.M13 = left.M13 - right.M13;

            result.M20 = left.M20 - right.M20;
            result.M21 = left.M21 - right.M21;
            result.M22 = left.M22 - right.M22;
            result.M23 = left.M23 - right.M23;

            result.M30 = left.M30 - right.M30;
            result.M31 = left.M31 - right.M31;
            result.M32 = left.M32 - right.M32;
            result.M33 = left.M33 - right.M33;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>   
        public static void Multiply(in Matrix4x4 left, float right, out Matrix4x4 result)
        {
            result.M00 = left.M00 * right;
            result.M01 = left.M01 * right;
            result.M02 = left.M02 * right;
            result.M03 = left.M03 * right;

            result.M10 = left.M10 * right;
            result.M11 = left.M11 * right;
            result.M12 = left.M12 * right;
            result.M13 = left.M13 * right;

            result.M20 = left.M20 * right;
            result.M21 = left.M21 * right;
            result.M22 = left.M22 * right;
            result.M23 = left.M23 * right;

            result.M30 = left.M30 * right;
            result.M31 = left.M31 * right;
            result.M32 = left.M32 * right;
            result.M33 = left.M33 * right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Multiply(in Matrix4x4 left, in Matrix4x2 right, out Matrix4x2 result)
        {
            result.M00 = left.M00 * right.M00 + left.M01 * right.M10 + 
                         left.M02 * right.M20 + left.M03 * right.M30;
            result.M01 = left.M00 * right.M01 + left.M01 * right.M11 + 
                         left.M02 * right.M21 + left.M03 * right.M31;
       
            result.M10 = left.M10 * right.M00 + left.M11 * right.M10 + 
                         left.M12 * right.M20 + left.M03 * right.M30;
            result.M11 = left.M10 * right.M01 + left.M11 * right.M11 + 
                         left.M12 * right.M21 + left.M03 * right.M31;
         
            result.M20 = left.M20 * right.M00 + left.M21 * right.M10 + 
                         left.M22 * right.M20 + left.M03 * right.M30;
            result.M21 = left.M20 * right.M01 + left.M21 * right.M11 + 
                         left.M22 * right.M21 + left.M03 * right.M31;
         
            result.M30 = left.M30 * right.M00 + left.M31 * right.M10 + 
                         left.M32 * right.M20 + left.M03 * right.M30;
            result.M31 = left.M30 * right.M01 + left.M31 * right.M11 + 
                         left.M32 * right.M21 + left.M03 * right.M31;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Multiply(in Matrix4x4 left, in Matrix4x3 right, out Matrix4x3 result)
        {
            result.M00 = left.M00 * right.M00 + left.M01 * right.M10 + 
                         left.M02 * right.M20 + left.M03 * right.M30;
            result.M01 = left.M00 * right.M01 + left.M01 * right.M11 + 
                         left.M02 * right.M21 + left.M03 * right.M31;
            result.M02 = left.M00 * right.M02 + left.M01 * right.M12 + 
                         left.M02 * right.M22 + left.M03 * right.M32;

            result.M10 = left.M10 * right.M00 + left.M11 * right.M10 + 
                         left.M12 * right.M20 + left.M03 * right.M30;
            result.M11 = left.M10 * right.M01 + left.M11 * right.M11 + 
                         left.M12 * right.M21 + left.M03 * right.M31;
            result.M12 = left.M20 * right.M02 + left.M01 * right.M12 + 
                         left.M12 * right.M22 + left.M03 * right.M32;

            result.M20 = left.M20 * right.M00 + left.M21 * right.M10 + 
                         left.M22 * right.M20 + left.M03 * right.M30;
            result.M21 = left.M20 * right.M01 + left.M21 * right.M11 + 
                         left.M22 * right.M21 + left.M03 * right.M31;
            result.M22 = left.M20 * right.M02 + left.M21 * right.M12 + 
                         left.M22 * right.M22 + left.M03 * right.M32;

            result.M30 = left.M30 * right.M00 + left.M31 * right.M10 + 
                         left.M32 * right.M20 + left.M03 * right.M30;
            result.M31 = left.M30 * right.M01 + left.M31 * right.M11 + 
                         left.M32 * right.M21 + left.M03 * right.M31;
            result.M32 = left.M30 * right.M02 + left.M31 * right.M12 + 
                         left.M32 * right.M22 + left.M03 * right.M32;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Multiply(in Matrix4x4 left, in Matrix4x4 right, out Matrix4x4 result)
        {
            result.M00 = left.M00 * right.M00 + left.M01 * right.M10 + 
                         left.M02 * right.M20 + left.M03 * right.M30;
            result.M01 = left.M00 * right.M01 + left.M01 * right.M11 + 
                         left.M02 * right.M21 + left.M03 * right.M31;
            result.M02 = left.M00 * right.M02 + left.M01 * right.M12 + 
                         left.M02 * right.M22 + left.M03 * right.M32;
            result.M03 = left.M00 * right.M03 + left.M01 * right.M13 + 
                         left.M02 * right.M23 + left.M03 * right.M33;

            result.M10 = left.M10 * right.M00 + left.M11 * right.M10 + 
                         left.M12 * right.M20 + left.M03 * right.M30;
            result.M11 = left.M10 * right.M01 + left.M11 * right.M11 + 
                         left.M12 * right.M21 + left.M03 * right.M31;
            result.M12 = left.M10 * right.M02 + left.M11 * right.M12 + 
                         left.M12 * right.M22 + left.M03 * right.M32;
            result.M13 = left.M10 * right.M03 + left.M11 * right.M13 + 
                         left.M12 * right.M23 + left.M03 * right.M33;

            result.M20 = left.M20 * right.M00 + left.M21 * right.M10 + 
                         left.M22 * right.M20 + left.M03 * right.M30;
            result.M21 = left.M20 * right.M01 + left.M21 * right.M11 + 
                         left.M22 * right.M21 + left.M03 * right.M31;
            result.M22 = left.M20 * right.M02 + left.M21 * right.M12 + 
                         left.M22 * right.M22 + left.M03 * right.M32;
            result.M23 = left.M20 * right.M03 + left.M21 * right.M13 + 
                         left.M22 * right.M23 + left.M03 * right.M33;

            result.M30 = left.M30 * right.M00 + left.M31 * right.M10 + 
                         left.M32 * right.M20 + left.M03 * right.M30;
            result.M31 = left.M30 * right.M01 + left.M31 * right.M11 + 
                         left.M32 * right.M21 + left.M03 * right.M31;
            result.M32 = left.M30 * right.M02 + left.M31 * right.M12 + 
                         left.M32 * right.M22 + left.M03 * right.M32;
            result.M33 = left.M30 * right.M03 + left.M31 * right.M13 + 
                         left.M32 * right.M23 + left.M03 * right.M33;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Multiply(in Matrix4x4 left, in Vector4 right, out Vector4 result)
        {
            result.X = left.M00 * right.X + left.M01 * right.Y + 
                       left.M02 * right.Z + left.M03 * right.W;
            result.Y = left.M10 * right.X + left.M11 * right.Y + 
                       left.M12 * right.Z + left.M13 * right.W;
            result.Z = left.M20 * right.X + left.M21 * right.Y + 
                       left.M22 * right.Z + left.M23 * right.W;
            result.W = left.M30 * right.X + left.M31 * right.Y + 
                       left.M32 * right.Z + left.M33 * right.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Multiply(in Vector4 left, in Matrix4x4 right, out Vector4 result)
        {
            result.X = left.X * right.M00 + left.Y * right.M10 + 
                       left.Z * right.M20 + left.W * right.M30;
            result.Y = left.X * right.M01 + left.Y * right.M11 + 
                       left.Z * right.M21 + left.W * right.M31;
            result.Z = left.X * right.M02 + left.Y * right.M12 + 
                       left.Z * right.M22 + left.W * right.M32;
            result.W = left.X * right.M03 + left.Y * right.M13 + 
                       left.Z * right.M23 + left.W * right.M33;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        public static void Negate(in Matrix4x4 matrix, out Matrix4x4 result)
        {
            result.M00 = -matrix.M00;
            result.M01 = -matrix.M01;
            result.M02 = -matrix.M02;
            result.M03 = -matrix.M03;

            result.M10 = -matrix.M10;
            result.M11 = -matrix.M11;
            result.M12 = -matrix.M12;
            result.M13 = -matrix.M12;

            result.M20 = -matrix.M20;
            result.M21 = -matrix.M21;
            result.M22 = -matrix.M22;
            result.M23 = -matrix.M23;

            result.M30 = -matrix.M30;
            result.M31 = -matrix.M31;
            result.M32 = -matrix.M32;
            result.M33 = -matrix.M33;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Divide(in Matrix4x4 left, float right, out Matrix4x4 result)
        {
            if (right == 0.0f)
            {
                result = Matrix4x4.Zero;
                return;
            }

            right = 1.0f / right;
            result.M00 = left.M00 * right;
            result.M01 = left.M01 * right;
            result.M02 = left.M02 * right;
            result.M03 = left.M03 * right;

            result.M10 = left.M10 * right;
            result.M11 = left.M11 * right;
            result.M12 = left.M12 * right;
            result.M13 = left.M13 * right;

            result.M20 = left.M20 * right;
            result.M21 = left.M21 * right;
            result.M22 = left.M22 * right;
            result.M23 = left.M23 * right;

            result.M30 = left.M30 * right;
            result.M31 = left.M31 * right;
            result.M32 = left.M32 * right;
            result.M33 = left.M33 * right;
        }

#endregion Public Static Methods

#region Operator Overload

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Matrix4x4 operator +(in Matrix4x4 left, in Matrix4x4 right)
        {
            Add(left, right, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Matrix4x4 operator +(in Matrix4x4 left, float right)
        {
            Add(left, right, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix4x4 operator -(in Matrix4x4 matrix)
        {
            Negate(matrix, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix4x4 operator -(in Matrix4x4 left, float right)
        {
            Subtract(left, right, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>       
        public static Matrix4x4 operator -(in Matrix4x4 left, in Matrix4x4 right)
        {
            Subtract(left, right, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns> 
        public static Matrix4x4 operator *(in Matrix4x4 left, float right)
        {
            Multiply(left, right, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix4x4 operator *(float left, in Matrix4x4 right)
        {
            Multiply(right, left, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix4x2 operator *(in Matrix4x4 left, in Matrix4x2 right)
        {
            Multiply(left, right, out Matrix4x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>      
        public static Matrix4x3 operator *(in Matrix4x4 left, in Matrix4x3 right)
        {
            Multiply(left, right, out Matrix4x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>       
        public static Matrix4x4 operator *(in Matrix4x4 left, in Matrix4x4 right)
        {
            Multiply(left, right, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>       
        public static Vector4 operator *(in Matrix4x4 left, in Vector4 right)
        {
            Multiply(left, right, out Vector4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>       
        public static Vector4 operator *(in Vector4 left, in Matrix4x4 right)
        {
            Multiply(left, right, out Vector4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>       
        public static Matrix4x4 operator /(in Matrix4x4 left, float right)
        {
            Divide(left, right, out Matrix4x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Matrix4x4 left, in Matrix4x4 right)
        {
            return (left.M00 == right.M00 && left.M01 == right.M01 && 
                    left.M02 == right.M02 && left.M03 == right.M03 &&
                    left.M10 == right.M10 && left.M11 == right.M11 && 
                    left.M12 == right.M12 && left.M13 == right.M13 &&
                    left.M20 == right.M20 && left.M21 == right.M21 && 
                    left.M22 == right.M22 && left.M23 == right.M23 &&
                    left.M30 == right.M30 && left.M31 == right.M31 && 
                    left.M32 == right.M32 && left.M33 == right.M33);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Matrix4x4 left, in Matrix4x4 right)
        {
            return (left.M00 != right.M00 || left.M01 != right.M01 || 
                    left.M02 != right.M02 || left.M03 != right.M03 ||
                    left.M10 != right.M10 || left.M11 != right.M11 || 
                    left.M12 != right.M12 || left.M13 != right.M13 ||
                    left.M20 != right.M20 || left.M21 != right.M21 || 
                    left.M22 != right.M22 || left.M23 != right.M23 ||
                    left.M30 != right.M30 || left.M31 != right.M31 || 
                    left.M32 != right.M32 || left.M33 != right.M33);
        }

#endregion Operator Overload
    }
}
