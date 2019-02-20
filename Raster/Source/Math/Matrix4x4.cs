using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Raster.Drawing.Primitive;
using Raster.Math.Geometry;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
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
        public float[] RawData
        {
            get
            {
                return new float[4 * 4]
                {
                    M00, M01, M02, M03,
                    M10, M11, M12, M13,
                    M20, M21, M22, M23,
                    M30, M31, M32, M33
                };
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
        /// <param name="row"></param>
        /// <returns></returns>
        
        public Vector4 Row(int row)
        {
            switch (row)
            {
                case 0:
                    return new Vector4(M00, M01, M02, M03);

                case 1:
                    return new Vector4(M10, M11, M12, M13);

                case 2:
                    return new Vector4(M20, M21, M22, M23);

                case 3:
                    return new Vector4(M30, M31, M32, M33);

                default:
                    throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        
        public Vector4 Column(int column)
        {
            switch (column)
            {
                case 0:
                    return new Vector4(M00, M10, M20, M30);

                case 1:
                    return new Vector4(M01, M11, M21, M31);

                case 2:
                    return new Vector4(M02, M12, M22, M32);

                case 3:
                    return new Vector4(M03, M13, M23, M33);

                default:
                    throw new IndexOutOfRangeException();
            }
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
        /// <param name="angle"></param>
        
        public void RotateX(float angle)
        {
            float rad = MathF.Sin(angle);
            float s = MathF.Sin(rad);
            float c = MathF.Cos(rad);
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
            float rad = MathF.Sin(angle);
            float s = MathF.Sin(rad);
            float c = MathF.Cos(rad);
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
            float rad = MathF.Sin(angle);
            float s = MathF.Sin(rad);
            float c = MathF.Cos(rad);
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
                Matrix4x4 rotation;
                FromAxisAngle(x, y, z, angle, out rotation);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="angle"></param> 
        public void Rotate(in Vector3 axis, float angle) =>
            Rotate(axis.X, axis.Y, axis.Z, angle);

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
        public void Scale(in Vector3 scale) => Scale(scale.X, scale.Y, scale.Z);

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
        public void Translate(in Vector3 translate) => Translate(translate.X, translate.Y, translate.Z);

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
        /// <param name="eyeX"></param>
        /// <param name="eyeY"></param>
        /// <param name="eyeZ"></param>
        /// <param name="centerX"></param>
        /// <param name="centerY"></param>
        /// <param name="centerZ"></param>
        /// <param name="upX"></param>
        /// <param name="upY"></param>
        /// <param name="upZ"></param>
        public void LookAt(float eyeX, float eyeY, float eyeZ,
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
            M33 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eye"></param>
        /// <param name="center"></param>
        /// <param name="up"></param>
        public void LookAt(in Vector3 eye, in Vector3 center, in Vector3 up) =>
            LookAt(eye.X, eye.Y, eye.Z, center.X, center.Y, center.Z, up.X, up.Y, up.Z);

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
        public void Viewport(RectangleF rect, float zNear, float zFar) =>
            Viewport(rect.Left, rect.Right, rect.Width, rect.Height, zNear, zFar);

        public void BillboardMatrix(in Vector3 objectPos, in Vector3 cameraPos, in Vector3 cameraUp, in Vector3 cameraForward)
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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public Matrix4x4 FromAxisAngle(in AxisAngle axisAngle)
        {
            Matrix4x4 result;
            FromAxisAngle(axisAngle.Axis.X, axisAngle.Axis.Y, axisAngle.Axis.Z, axisAngle.Angle, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="axisAngle"></param>
        /// <param name="result"></param>
        public void FromAxisAngle(float x, float y, float z, float angle, out Matrix4x4 result)
        {
            float rad = MathF.DegToRad(angle);
            float s = MathF.Sin(rad);
            float c = MathF.Cos(rad);

            float invNorm = MathHelper.FastSqrtInverse(x * x + y * y + z * z);
            if (!MathHelper.IsZero(invNorm)
            {
                x *= invNorm;
                y *= invNorm;
                z *= invNorm;
            }
            else
            {
                result = Matrix4x4.Identity;
            }

            float c0 = 1.0f - c;
            float x2 = x * x;
            float y2 = y * y;
            float z2 = z * z;

            float xy = x * y;
            float xz = x * z;
            float yz = y * z;

            float xs = x * s;
            float ys = y * s;
            float zs = z * s;

            result.M00 = c + c0 * x2;
            result.M10 = c0 * xy - zs;
            result.M20 = c0 * xz + ys;
            result.M30 = 0.0f;

            result.M01 = c0 * xy + zs;
            result.M11 = c + c0 * y2;
            result.M21 = c0 * yz - xs;
            result.M31 = 0.0f;

            result.M02 = c0 * xz - ys;
            result.M12 = c0 * yz + xs;
            result.M22 = c + c0 * z2;
            result.M32 = 0.0f;

            result.M03 = 0.0f;
            result.M13 = 0.0f;
            result.M23 = 0.0f;
            result.M33 = 1.0f;
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
            Matrix4x4 result;;
            Add(left, right, out result);
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
            Matrix4x4 result;;
            Add(left, right, out result);
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
            Matrix4x4 result;;
            Subtract(left, right, out result);
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
            Matrix4x4 result;;
            Subtract(left, right, out result);
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
            Matrix4x4 result;;
            Subtract(left, right, out result);
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
            Matrix4x4 result;;
            Multiply(right, left, out result);
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
            Matrix4x2 result;
            Multiply(left, right, out result);
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
            Matrix4x3 result;
            Multiply(left, right, out result);
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
            Matrix4x4 result;
            Multiply(left, right, out result);
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
            Vector4 result;
            Multiply(left, right, out result);
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
            Vector4 result;
            Multiply(left, right, out result);
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
            Matrix4x4 result;;
            Divide(left, right, out result);
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
