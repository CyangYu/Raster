using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Raster.Math
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
        public static readonly Matrix3x3 Zero       = new Matrix3x3(0.0f, 0.0f, 0.0f,
                                                                    0.0f, 0.0f, 0.0f,
                                                                    0.0f, 0.0f, 0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Matrix3x3 Identity   = new Matrix3x3(1.0f, 0.0f, 0.0f,
                                                                    0.0f, 1.0f, 0.0f,
                                                                    0.0f, 0.0f, 1.0f);

        #endregion Public Static Fields

        #region Public Instance Properties
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Matrix3x3 other) => this == other;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsZero()
        {
            return (M00 == 0.0f && M01 == 0.0f && M02 == 0.0f &&
                    M10 == 0.0f && M11 == 0.0f && M12 == 0.0f &&
                    M20 == 0.0f && M21 == 0.0f && M22 == 0.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsIdentity()
        {
            return (M00 == 1.0f && M01 == 0.0f && M02 == 0.0f &&
                    M10 == 0.0f && M11 == 1.0f && M12 == 0.0f &&
                    M20 == 0.0f && M21 == 0.0f && M22 == 1.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetIdentity()
        {
            M00 = 1.0f;
            M01 = 0.0f;
            M02 = 0.0f;

            M10 = 0.0f;
            M11 = 1.0f;
            M12 = 0.0f;

            M20 = 0.0f;
            M21 = 0.0f;
            M22 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3 Row(int row)
        {
            switch (row)
            {
                case 0:
                    return new Vector3(M00, M01, M02);

                case 1:
                    return new Vector3(M10, M11, M12);

                case 2:
                    return new Vector3(M20, M21, M22);

                default:
                    throw new IndexOutOfRangeException("The index of row is greater than 2");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3 Column(int column)
        {
            switch (column)
            {
                case 0:
                    return new Vector3(M00, M10, M20);

                case 1:
                    return new Vector3(M01, M11, M21);

                case 2:
                    return new Vector3(M02, M12, M22);

                default:
                    throw new IndexOutOfRangeException("The index of column is greater than 2");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Rotate(float angle)
        {
            float rad = MathF.DegToRad(angle);
            float s = MathF.Sin(rad);
            float c = MathF.Cos(rad);
            float temp = 0.0f;

            temp = M00;
            M00 = temp * c + M10 * s;
            M10 = M10 * c - temp * s;

            temp = M01;
            M01 = temp * c + M11 * s;
            M11 = M11 * c - temp * s;

            temp = M02;
            M02 = temp * c + M12 * s;
            M12 = M12 * c - temp * s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Scale(in Vector2 scale) => Scale(scale.X, scale.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Translate(in Vector2 translate) => Translate(translate.X, translate.Y);

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        #endregion Public Static Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x3 operator +(in Matrix3x3 left, float right)
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
