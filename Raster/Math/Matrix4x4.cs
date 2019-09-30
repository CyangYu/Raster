using System;
using System.Runtime.InteropServices;
using Raster.Drawing.Primitive;
using Raster.Math.Geometry;

namespace Raster.Math
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

        #endregion Public Instance Properties

        #region Constructor
        public Matrix4x4(float value)
        {
            M00 = value;
            M01 = value;
            M02 = value;
            M03 = value;

            M10 = value;
            M11 = value;
            M12 = value;
            M13 = value;

            M20 = value;
            M21 = value;
            M22 = value;
            M23 = value;

            M30 = value;
            M31 = value;
            M32 = value;
            M33 = value;
        }

        public Matrix4x4(Matrix2x2 other)
        {
            M00 = other.M00;
            M01 = other.M01;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = other.M10;
            M11 = other.M11;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = 0.0f;
            M23 = 0.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = 0.0f;
            M33 = 0.0f;
        }

        public Matrix4x4(Matrix2x3 other)
        {
            M00 = other.M00;
            M01 = other.M01;
            M02 = other.M02;
            M03 = 0.0f;

            M10 = other.M10;
            M11 = other.M11;
            M12 = other.M12;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = 0.0f;
            M23 = 0.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = 0.0f;
            M33 = 0.0f;
        }

        public Matrix4x4(Matrix2x4 other)
        {
            M00 = other.M00;
            M01 = other.M01;
            M02 = other.M02;
            M03 = other.M03;

            M10 = other.M10;
            M11 = other.M11;
            M12 = other.M12;
            M13 = other.M13;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = 0.0f;
            M23 = 0.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = 0.0f;
            M33 = 0.0f;
        }

        public Matrix4x4(Matrix3x2 other)
        {
            M00 = other.M00;
            M01 = other.M01;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = other.M10;
            M11 = other.M11;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = other.M20;
            M21 = other.M21;
            M22 = 0.0f;
            M23 = 0.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = 0.0f;
            M33 = 0.0f;
        }

        public Matrix4x4(Matrix3x3 other)
        {
            M00 = other.M00;
            M01 = other.M01;
            M02 = other.M02;
            M03 = 0.0f;

            M10 = other.M10;
            M11 = other.M11;
            M12 = other.M12;
            M13 = 0.0f;

            M20 = other.M20;
            M21 = other.M21;
            M22 = other.M22;
            M23 = 0.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = 0.0f;
            M33 = 0.0f;
        }

        public Matrix4x4(Matrix3x4 other)
        {
            M00 = other.M00;
            M01 = other.M01;
            M02 = other.M02;
            M03 = other.M03;

            M10 = other.M10;
            M11 = other.M11;
            M12 = other.M12;
            M13 = other.M13;

            M20 = other.M20;
            M21 = other.M21;
            M22 = other.M22;
            M23 = other.M23;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = 0.0f;
            M33 = 0.0f;
        }

        public Matrix4x4(in Matrix4x2 other)
        {
            M00 = other.M00;
            M01 = other.M01;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = other.M10;
            M11 = other.M11;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = other.M20;
            M21 = other.M21;
            M22 = 0.0f;
            M23 = 0.0f;

            M30 = other.M30;
            M31 = other.M31;
            M32 = 0.0f;
            M33 = 0.0f;
        }

        public Matrix4x4(in Matrix4x3 other)
        {
            M00 = other.M00;
            M01 = other.M01;
            M02 = other.M02;
            M03 = 0.0f;

            M10 = other.M10;
            M11 = other.M11;
            M12 = other.M12;
            M13 = 0.0f;

            M20 = other.M20;
            M21 = other.M21;
            M22 = other.M22;
            M23 = 0.0f;

            M30 = other.M30;
            M31 = other.M31;
            M32 = other.M32;
            M33 = 0.0f;
        }

        public Matrix4x4(in Matrix4x4 other)
        {
            M00 = other.M00;
            M01 = other.M01;
            M02 = other.M02;
            M03 = other.M03;

            M10 = other.M10;
            M11 = other.M11;
            M12 = other.M12;
            M13 = other.M13;

            M20 = other.M20;
            M21 = other.M21;
            M22 = other.M22;
            M23 = other.M23;

            M30 = other.M30;
            M31 = other.M31;
            M32 = other.M32;
            M33 = other.M33;
        }

        public Matrix4x4(float m00, float m01, float m02, float m03,
                         float m10, float m11, float m12, float m13,
                         float m20, float m21, float m22, float m23,
                         float m30, float m31, float m32, float m33)
        {
            M00 = m00;
            M01 = m01;
            M02 = m02;
            M03 = m03;

            M10 = m10;
            M11 = m11;
            M12 = m12;
            M13 = m12;

            M20 = m20;
            M21 = m21;
            M22 = m22;
            M23 = m23;

            M30 = m30;
            M31 = m31;
            M32 = m32;
            M33 = m33;
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
        
        public bool Equals(Matrix4x4 other) => this == other;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public bool IsZero()
        {
            return (M00 == 0.0f && M01 == 0.0f && M02 == 0.0f && M03 == 0.0f &&
                    M10 == 0.0f && M11 == 0.0f && M12 == 0.0f && M13 == 0.0f &&
                    M20 == 0.0f && M21 == 0.0f && M22 == 0.0f && M23 == 0.0f &&
                    M30 == 0.0f && M31 == 0.0f && M32 == 0.0f && M33 == 0.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsIdentity()
        {
            return (M00 == 1.0f && M01 == 0.0f && M02 == 0.0f && M03 == 0.0f &&
                    M10 == 0.0f && M11 == 1.0f && M12 == 0.0f && M13 == 0.0f &&
                    M20 == 0.0f && M21 == 0.0f && M22 == 1.0f && M23 == 0.0f &&
                    M30 == 0.0f && M31 == 0.0f && M32 == 0.0f && M33 == 1.0f);
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

            M30 = value;
            M31 = value;
            M32 = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetIdentity()
        {
            M00 = 1.0f;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 1.0f;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = 0.0f;
            M23 = 0.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = 0.0f;
            M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetZero()
        {
            M00 = 0.0f;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 0.0f;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = 0.0f;
            M23 = 0.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = 0.0f;
            M33 = 0.0f;
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
        /// <param name="other"></param>
        public void CopyFrom(in Matrix4x4 other)
        {
            this.M00 = other.M00;
            this.M01 = other.M01;
            this.M02 = other.M02;
            this.M03 = other.M03;

            this.M10 = other.M10;
            this.M11 = other.M11;
            this.M12 = other.M12;
            this.M13 = other.M13;

            this.M20 = other.M20;
            this.M21 = other.M21;
            this.M22 = other.M22;
            this.M23 = other.M23;

            this.M30 = other.M30;
            this.M31 = other.M31;
            this.M32 = other.M32;
            this.M33 = other.M32;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        
        public void RotateX(float angle)
        {
            float s = MathF.Sin(angle);
            float c = MathF.Cos(angle);
            float temp = 0.0f;

            // [  1  0  0  0 ]
            // [  0  c  s  0 ]
            // [  0 -s  c  0 ]
            // [  0  0  0  1 ]
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
        public void RotateY(float angle)
        {
            float s = MathF.Sin(angle);
            float c = MathF.Cos(angle);
            float temp = 0.0f;

            // [  c  0 -s  0 ]
            // [  0  1  0  0 ]
            // [  s  0  c  0 ]
            // [  0  0  0  1 ]
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
        public void RotateZ(float angle)
        {
            float s = MathF.Sin(angle);
            float c = MathF.Cos(angle);
            float temp = 0.0f;

            // [  c  s  0  0 ]
            // [ -s  c  0  0 ]
            // [  0  0  0  0 ]
            // [  0  0  0  1 ]
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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="angle"></param>
        public void Rotate(float x, float y, float z, float angle)
        {
            if (x != 0.0f && y == 0.0f && z == 0.0f)
                RotateX(angle);
            else if (x == 0.0f && y != 0.0f && z == 0.0f)
                RotateY(angle);
            else if (x == 0.0f && y == 0.0f && z != 0.0f)
                RotateZ(angle);
            else
            {
                FromAxisAngle(new AxisAngle(x, y, z, angle), out Matrix4x4 rotate);
                Multiply(rotate, this, out Matrix4x4 temp);
                this.CopyFrom(temp);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="angle"></param> 
        public void Rotate(in Vector3 axis, float angle)
        {
            Rotate(axis.X, axis.Y, axis.Z, angle);
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
            M00 *= sx;
            M01 *= sx;
            M02 *= sx;
            M03 *= sx;

            M10 *= sy;
            M11 *= sy;
            M12 *= sy;
            M13 *= sy;

            M20 *= sz;
            M21 *= sz;
            M22 *= sz;
            M23 *= sz;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scale"></param>
        public void Scale(in Vector3 scale)
        {
            Scale(scale.X, scale.Y, scale.Z);
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
        public void Translate(in Vector3 translate)
        {
            Translate(translate.X, translate.Y, translate.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        public void SetPositionAndRotation(in Vector3 position, in Quaternion rotation, in Vector3 scale)
        {

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
        public void Frustrum(float left, float right, float top, float bottom, float zNear, float zFar)
        {
            if (left >= right || bottom >= top || zNear >= zFar)
            {
                return;
            }

            float invWidth  = 1.0f / (right - left);
            float invHeight = 1.0f / (top - bottom);
            float invClip   = 1.0f / (zFar - zNear);

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
            M32 = (-2.0f * zNear + zFar) * invClip;
            M33 = 0.0f;
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
        public void LookAt(float eyeR, float eyeY, float eyeZ,
                           float centerR, float centerY, float centerZ,
                           float upR, float upY, float upZ)
        {
            float forwardR = centerR - eyeR;
            float forwardY = centerY - eyeY;
            float forwardZ = centerZ - eyeZ;

            float lenSqr = forwardR * forwardR + forwardY * forwardY + forwardZ * forwardZ;
            float invNorm = MathHelper.FastSqrtInverse(lenSqr);

            forwardR *= invNorm;
            forwardY *= invNorm;
            forwardZ *= invNorm;

            float sideR = forwardY * upZ - forwardZ * upY;
            float sideY = forwardR * upZ - forwardZ * upR;
            float sideZ = forwardR * upY - forwardY * upR;

            lenSqr = sideR * sideR + sideY * sideY + sideZ * sideZ;
            invNorm = MathHelper.FastSqrtInverse(lenSqr);

            sideR *= invNorm;
            sideY *= invNorm;
            sideZ *= invNorm;

            float uR = sideY * forwardZ - sideZ * forwardY;
            float uY = sideZ * forwardR - sideR * forwardZ;
            float uZ = sideR * forwardY - sideY * forwardR;

            M00 = sideR;
            M01 = uR;
            M02 = -forwardR;
            M03 = 0.0f;

            M10 = sideY;
            M11 = uY;
            M12 = -forwardY;
            M13 = 0.0f;

            M20 = sideZ;
            M21 = uZ;
            M22 = -forwardZ;
            M23 = 0.0f;

            M30 = -(sideR * eyeR + sideY * eyeY + sideZ * eyeZ);
            M31 = -(uR * eyeR + uY * eyeY + uZ * eyeZ);
            M32 = (forwardR * eyeR + forwardY * eyeY + forwardZ * eyeZ);
            M33 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eye"></param>
        /// <param name="center"></param>
        /// <param name="up"></param>
        public void LookAt(in Vector3 eye, in Vector3 center, in Vector3 up)
        {
            LookAt(eye.X, eye.Y, eye.Z, center.X, center.Y, center.Z, up.X, up.Y, up.Z);
        }
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void Ortho(float width, float height, float zNear, float zFar)
        {
            float invClip = 1.0f / (zFar - zNear);

            M00 = 2.0f / width;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f / height;
            M12 = 0.0f;
            M23 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = -invClip;
            M23 = 0.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = -zNear * invClip;
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
        public void OrthoOffCenter(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            if (top >= bottom || left >= right || zNear >= zFar)
            {
                return;
            }

            float invWidth  = 1.0f / (right - left);
            float invHeight = 1.0f / (top - bottom);
            float invClip   = 1.0f / (zFar - zNear);

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
            M22 = -2.0f * invClip;
            M23 = 0.0f;

            M30 = -(left + right) * invWidth;
            M31 = -(top + bottom) * invHeight;
            M32 = -(zNear + zFar) * invClip;
            M33 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void Perspective(float width, float height, float zNear, float zFar)
        {
            if (zNear <= 0.0f || zFar <= 0.0f || zNear >= zFar)
            {
                return;
            }

            float negFarRange = float.IsPositiveInfinity(zFar) ?
                                             -1.0f :
                                             zFar / (zNear - zFar);

            M00 = 2.0f * zNear / width;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = 2.0f * zNear / height;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = negFarRange;
            M23 = -1.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = zNear * negFarRange;
            M33 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fov"></param>
        /// <param name="aspect"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void PerspectiveFOV(float fov, float aspect, float zNear, float zFar)
        {
            if (fov < 0.0f || fov > 180.0f)
            {
                return;
            }

            if (aspect == 0.0f || zNear <= 0.0f || zFar <= 0.0f || zNear >= zFar)
            {
                return;
            }

            float radian = MathF.DegToRad(fov * 0.5f);
            float sin = MathF.Sin(radian);

            if (sin == 0.0f)
            {
                return;
            }

            float cot = MathF.Cos(radian) / sin;
            float invClip = 1.0f / (zFar - zNear);

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
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public void PerspectiveOffCenter(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            if (zNear <= 0.0f || zFar <= 0.0f || zNear >= zFar)
            {
                return;
            }

            float invWidth = 1.0f / (right - left);
            float invHeight = 1.0f / (top - bottom);
            float negFarRange = float.IsPositiveInfinity(zFar) ?
                                            -1.0f :
                                            zFar / (zNear - zFar);

            M00 = 2.0f * zNear * invWidth;
            M01 = 0.0f;
            M02 = 0.0f;
            M03 = 0.0f;

            M10 = 0.0f;
            M11 = -2.0f * zNear * invHeight;
            M12 = 0.0f;
            M13 = 0.0f;

            M20 = (left + right) * invWidth;
            M21 = (top + bottom) * invHeight;
            M22 = negFarRange;
            M23 = -1.0f;

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = zNear * negFarRange;
            M33 = 0.0f;
        }

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
        /// <param name="rect"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>  
        public void Viewport(RectangleF rect, float zNear, float zFar)
        {
            Viewport(rect.Left, rect.Right, rect.Width, rect.Height, zNear, zFar);
        }
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectPos"></param>
        /// <param name="cameraPos"></param>
        /// <param name="cameraUp"></param>
        /// <param name="cameraForward"></param>
        public void BillboardMatrix(in Vector3 objectPos, in Vector3 cameraPos, in Vector3 cameraUp, in Vector3 cameraForward)
        {
            float zAxisR = objectPos.X - cameraPos.X;
            float zAxisY = objectPos.Y - cameraPos.Y;
            float zAxisZ = objectPos.Z - cameraPos.Z;

            float lenSqr = zAxisR * zAxisR + zAxisY * zAxisY +
                           zAxisZ * zAxisZ;
            float invNorm = 0.0f;

            if (lenSqr < BillboardEpsilon)
            {
                zAxisR = -cameraForward.X;
                zAxisY = -cameraForward.Y;
                zAxisZ = -cameraForward.Z;
            }
            else
            {
                invNorm = MathHelper.FastSqrtInverse(lenSqr);

                zAxisR *= invNorm;
                zAxisY *= invNorm;
                zAxisZ *= invNorm;
            }
           

            float tempR = cameraUp.Y * zAxisZ - cameraUp.Z * zAxisY;
            float tempY = cameraUp.X * zAxisZ - cameraUp.Z * zAxisR;
            float tempZ = cameraUp.X * zAxisY - cameraUp.Y * zAxisR;

            lenSqr = tempR * tempR + tempY * tempY + tempZ * tempZ;
            invNorm = MathHelper.FastSqrtInverse(lenSqr);

            float xAxisR = tempR * invNorm;
            float xAxisY = tempY * invNorm;
            float xAxisZ = tempZ * invNorm;

            float yAxisR = zAxisY * xAxisZ - zAxisZ * xAxisY;
            float yAxisY = zAxisR * xAxisZ - zAxisZ * xAxisR;
            float yAxisZ = zAxisR * xAxisY - zAxisY * xAxisR;

            M00 = xAxisR;
            M01 = xAxisY;
            M02 = xAxisZ;
            M03 = 0.0f;

            M10 = yAxisR;
            M11 = yAxisY;
            M12 = yAxisZ;
            M13 = 0.0f;

            M20 = zAxisR;
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
            Plane p;
            Plane.Normalize(value, out p);

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
            Vector3 zAxis = Vector3.Normalize(forward);
            Vector3 xAxis = Vector3.Normalize(Vector3.Cross(up, zAxis));
            Vector3 yAxis = Vector3.Cross(zAxis, xAxis);

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
        public static void FromAxisAngle(in AxisAngle axis, out Matrix4x4 result)
        {
            float cos = MathF.Cos(axis.Angle);
            float sin = MathF.Sin(axis.Angle);

            float c0 = 1.0f - cos;
            float x2 = axis.Axis.X * axis.Axis.X;
            float y2 = axis.Axis.Y * axis.Axis.Y;
            float z2 = axis.Axis.Z * axis.Axis.Z;

            float xy = axis.Axis.X * axis.Axis.Y;
            float xz = axis.Axis.X * axis.Axis.Z;
            float yz = axis.Axis.Y * axis.Axis.Z;

            float xs = axis.Axis.X * sin;
            float ys = axis.Axis.Y * sin;
            float zs = axis.Axis.Z * sin;

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
        /// <param name="euler"></param>
        /// <param name="result"></param>
        public static void FromEulerAnglesXYZ(in EulerAngles euler, out Matrix4x4 result)
        {
            float cp = MathF.Cos(euler.Pitch);
            float sp = MathF.Sin(euler.Pitch);
            float cy = MathF.Cos(euler.Yaw);
            float sy = MathF.Sin(euler.Yaw);
            float cr = MathF.Cos(euler.Roll);
            float sr = MathF.Sin(euler.Roll);

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
        public static void FromEulerAnglesXZY(in EulerAngles euler, out Matrix4x4 result)
        {
            float cp = MathF.Cos(euler.Pitch);
            float sp = MathF.Sin(euler.Pitch);
            float cy = MathF.Cos(euler.Yaw);
            float sy = MathF.Sin(euler.Yaw);
            float cr = MathF.Cos(euler.Roll);
            float sr = MathF.Sin(euler.Roll);

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
        public static void FromEulerAnglesYXZ(in EulerAngles euler, out Matrix4x4 result)
        {
            float cp = MathF.Cos(euler.Pitch);
            float sp = MathF.Sin(euler.Pitch);
            float cy = MathF.Cos(euler.Yaw);
            float sy = MathF.Sin(euler.Yaw);
            float cr = MathF.Cos(euler.Roll);
            float sr = MathF.Sin(euler.Roll);

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
        public static void FromEulerAnglesYZX(in EulerAngles euler, out Matrix4x4 result)
        {
            float cp = MathF.Cos(euler.Pitch);
            float sp = MathF.Sin(euler.Pitch);
            float cy = MathF.Cos(euler.Yaw);
            float sy = MathF.Sin(euler.Yaw);
            float cr = MathF.Cos(euler.Roll);
            float sr = MathF.Sin(euler.Roll);

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
        public static void FromEulerAnglesZXY(in EulerAngles euler, out Matrix4x4 result)
        {
            float cp = MathF.Cos(euler.Pitch);
            float sp = MathF.Sin(euler.Pitch);
            float cy = MathF.Cos(euler.Yaw);
            float sy = MathF.Sin(euler.Yaw);
            float cr = MathF.Cos(euler.Roll);
            float sr = MathF.Sin(euler.Roll);

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
        public static void FromEulerAnglesZYX(in EulerAngles euler, out Matrix4x4 result)
        {
            float cp = MathF.Cos(euler.Pitch);
            float sp = MathF.Sin(euler.Pitch);
            float cy = MathF.Cos(euler.Yaw);
            float sy = MathF.Sin(euler.Yaw);
            float cr = MathF.Cos(euler.Roll);
            float sr = MathF.Sin(euler.Roll);

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
        /// <param name="quaternion"></param>
        /// <param name="result"></param>
        public static void FromQuaternion(in Quaternion quaternion, out Matrix4x4 result)
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
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        public static bool Inverse(in Matrix4x4 matrix, out Matrix4x4 result)
        {
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
