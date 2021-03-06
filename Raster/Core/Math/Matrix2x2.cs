﻿using System;
using System.Runtime.InteropServices;

namespace Raster.Core.Math
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Matrix2x2 : IEquatable<Matrix2x2>
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

        public float M10;
        /// <summary>
        /// 
        /// </summary>
        public float M11;
        #endregion

        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly Matrix2x2 Zero = new Matrix2x2(0.0f, 0.0f,
                                                              0.0f, 0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Matrix2x2 Identity = new Matrix2x2(1.0f, 0.0f,
                                                                  0.0f, 1.0f);

        #endregion Public Static Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public Vector2 Row0
        {
            get { return new Vector2(M00, M01); }

            set
            {
                M00 = value.X;
                M01 = value.Y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector2 Row1
        {
            get { return new Vector2(M10, M11); }

            set
            {
                M10 = value.X;
                M11 = value.Y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector2 Column0
        {
            get { return new Vector2(M00, M10); }

            set
            {
                M00 = value.X;
                M10 = value.Y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector2 Column1
        {
            get { return new Vector2(M01, M11); }

            set
            {
                M01 = value.X;
                M11 = value.Y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float Determinant
        {
            get { return M00 * M11 - M01 * M10; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsZero
        {
            get
            {
                return (M00 == 0.0f && M01 == 0.0f &&
                        M10 == 0.0f && M11 == 0.0f);
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
                return (M00 == 1.0f && M01 == 0.0f &&
                        M10 == 0.0f && M11 == 1.0f);
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
                    case 0: return M00;
                    case 1: return M01;
                    case 2: return M10;
                    case 3: return M11;
                }

                throw new ArgumentOutOfRangeException("index");
            }

            set
            {
                switch (index)
                {
                    case 0: M00 = value; break;
                    case 1: M01 = value; break;
                    case 2: M10 = value; break;
                    case 3: M11 = value; break;
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
                if (row < 0 || row > 1)
                {
                    throw new ArgumentOutOfRangeException("row", "Row 0 to 1");
                }

                if (column < 0 || column > 1)
                {
                    throw new ArgumentOutOfRangeException("row", "Row 0 to 1");
                }

                return this[row * 2 + column];
            }

            set
            {
                if (row < 0 || row > 1)
                {
                    throw new ArgumentOutOfRangeException("row", "Row and column from 0 to 3");
                }

                if (column < 0 || column > 1)
                {
                    throw new ArgumentOutOfRangeException("row", "Row and column from 0 to 3");
                }

                this[row * 2 + column] = value;
            }
        }
        #endregion Public Instance Properties

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Matrix2x2(float value)
        {
            M00 = value; M01 = value;
            M10 = value; M11 = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public Matrix2x2(Matrix2x2 other)
        {
            M00 = other.M00; M01 = other.M01;
            M10 = other.M10; M11 = other.M11;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m00"></param>
        /// <param name="m01"></param>
        /// <param name="m10"></param>
        /// <param name="m11"></param>
        public Matrix2x2(float m00, float m01,
                         float m10, float m11)
        {
            M00 = m00; M01 = m01;
            M10 = m10; M11 = m11;
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
            if (obj is Matrix2x2)
            {
                return Equals((Matrix2x2)obj);
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
                return M00.GetHashCode() + M01.GetHashCode() +
                       M10.GetHashCode() + M11.GetHashCode();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Matrix2x2: [[M00 = {0}, M01 = {1}], " +
                                             "[M10 = {3}, M11 = {4}]]",
                                 M00, M01, M10, M11);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Matrix2x2 other)
        {
            return this == other;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Fill(float value)
        {
            M00 = value; M01 = value;
            M10 = value; M11 = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetToZero()
        {
            M00 = 0.0f; M01 = 0.0f;
            M10 = 0.0f; M11 = 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetToIdentity()
        {
            M00 = 1.0f; M01 = 0.0f;
            M10 = 0.0f; M11 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Transpose()
        {
            MathHelper.Swap(ref M01, ref M10);
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

            this[secondRow, 0] = this[firstRow, 0];
            this[secondRow, 1] = this[firstRow, 1];

            this[firstRow, 0] = temp0;
            this[firstRow, 1] = temp1;

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

            this[0, secondColumn] = this[0, firstColumn];
            this[1, secondColumn] = this[1, firstColumn];

            this[0, firstColumn] = temp0;
            this[1, firstColumn] = temp1;
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
                    M00, M01,
                    M10, M11
                };
            }
            else
            {
                return new float[]
                {
                    M00, M10,
                    M01, M11
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public void Add(in Matrix2x2 other)
        {
            M00 += other.M00; M01 += other.M01;
            M10 += other.M10; M11 += other.M11;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public void Subtract(in Matrix2x2 other)
        {
            M00 -= other.M00; M01 -= other.M01;
            M10 -= other.M10; M11 -= other.M11;
        }
        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix2x2 Transpose(in Matrix2x2 matrix)
        {
            Transpose(matrix, out Matrix2x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        public static void Inverse(in Matrix2x2 matrix, out Matrix2x2 result)
        {
            float det = matrix.Determinant;

            if (det == 0.0f)
            {
                result = Matrix2x2.Identity;
            }

            float invDet = 1.0f / det;

            result.M00 =  matrix.M11 * invDet;
            result.M01 = -matrix.M01 * invDet;
            result.M10 = -matrix.M10 * invDet;
            result.M11 =  matrix.M00 * invDet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        public static void Transpose(in Matrix2x2 matrix, out Matrix2x2 result)
        {
            result.M00 = matrix.M00;
            result.M01 = matrix.M10;

            result.M10 = matrix.M01;
            result.M11 = matrix.M11;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Add(in Matrix2x2 left, float right, out Matrix2x2 result)
        {
            result.M00 = left.M00 + right;
            result.M01 = left.M01 + right;

            result.M10 = left.M10 + right;
            result.M11 = left.M11 + right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Add(in Matrix2x2 left, in Matrix2x2 right, out Matrix2x2 result)
        {
            result.M00 = left.M00 + right.M00;
            result.M01 = left.M01 + right.M01;

            result.M10 = left.M10 + right.M10;
            result.M11 = left.M11 + right.M11;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Subtract(in Matrix2x2 left, float right, out Matrix2x2 result)
        {
            result.M00 = left.M00 - right;
            result.M01 = left.M01 - right;

            result.M10 = left.M10 - right;
            result.M11 = left.M11 - right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Subtract(in Matrix2x2 left, in Matrix2x2 right, out Matrix2x2 result)
        {
            result.M00 = left.M00 - right.M00;
            result.M01 = left.M01 - right.M01;

            result.M10 = left.M10 - right.M10;
            result.M11 = left.M11 - right.M11;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Multiply(in Matrix2x2 left, float right, out Matrix2x2 result)
        {
            // First Row
            result.M00 = left.M00 * right;
            result.M01 = left.M01 * right;

            // Second Row
            result.M10 = left.M10 * right;
            result.M11 = left.M11 * right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Multiply(in Matrix2x2 left, in Matrix2x2 right, out Matrix2x2 result)
        {
            result.M00 = left.M00 * right.M00 + left.M01 * right.M10;
            result.M01 = left.M00 * right.M01 + left.M01 * right.M11;

            result.M10 = left.M10 * right.M00 + left.M11 * right.M10;
            result.M11 = left.M10 * right.M01 + left.M11 * right.M11;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Multiply(in Matrix2x2 left, in Matrix2x3 right, out Matrix2x3 result)
        {
            result.M00 = left.M00 * right.M00 + left.M01 * right.M10;
            result.M01 = left.M00 * right.M01 + left.M01 * right.M11;
            result.M02 = left.M00 * right.M02 + left.M01 * right.M12;

            result.M10 = left.M10 * right.M00 + left.M11 * right.M10;
            result.M11 = left.M10 * right.M01 + left.M11 * right.M11;
            result.M12 = left.M10 * right.M02 + left.M11 * right.M12;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Multiply(in Matrix2x2 left, in Matrix2x4 right, out Matrix2x4 result)
        {
            result.M00 = left.M00 * right.M00 + left.M01 * right.M10;
            result.M01 = left.M00 * right.M01 + left.M01 * right.M11;
            result.M02 = left.M00 * right.M02 + left.M01 * right.M12;
            result.M03 = left.M00 * right.M03 + left.M01 * right.M13;

            result.M10 = left.M10 * right.M00 + left.M11 * right.M10;
            result.M11 = left.M10 * right.M01 + left.M11 * right.M11;
            result.M12 = left.M10 * right.M02 + left.M11 * right.M12;
            result.M13 = left.M10 * right.M03 + left.M01 * right.M13;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Multiply(in Matrix2x2 left, in Vector2 right, out Vector2 result)
        {
            result.X = left.M00 * right.X + left.M01 * right.Y;
            result.Y = left.M00 * right.X + left.M01 * right.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Multiply(in Vector2 left, in Matrix2x2 right, out Vector2 result)
        {
            result.X = left.X * right.M00 + left.Y * right.M10;
            result.Y = left.X * right.M01 + left.Y * right.M11;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        public static void Negate(in Matrix2x2 matrix, out Matrix2x2 result)
        {
            result.M00 = -matrix.M00;
            result.M01 = -matrix.M01;

            result.M10 = -matrix.M10;
            result.M11 = -matrix.M11;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Divide(in Matrix2x2 left, float right, out Matrix2x2 result)
        {
            if (right == 0.0f)
            {
                result = Matrix2x2.Zero;
                return;
            }

            right = 1.0f / right;

            result.M00 = left.M00 * right;
            result.M01 = left.M01 * right;

            result.M10 = left.M10 * right;
            result.M11 = left.M11 * right;
        }

        #endregion Public Static Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Matrix2x2 operator +(in Matrix2x2 left, in Matrix2x2 right)
        {
            Add(left, right, out Matrix2x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Matrix2x2 operator +(in Matrix2x2 left, float right)
        {
            Add(left, right, out Matrix2x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix2x2 operator -(in Matrix2x2 matrix)
        {
            Negate(matrix, out Matrix2x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Matrix2x2 operator -(in Matrix2x2 left, float right)
        {
            Subtract(left, right, out Matrix2x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Matrix2x2 operator -(in Matrix2x2 left, in Matrix2x2 right)
        {
            Subtract(left, right, out Matrix2x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Matrix2x2 operator *(in Matrix2x2 left, float right)
        {
            Subtract(left, right, out Matrix2x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Matrix2x2 operator *(float left, in Matrix2x2 right)
        {
            Multiply(right, left, out Matrix2x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Matrix2x2 operator *(in Matrix2x2 left, in Matrix2x2 right)
        {
            Multiply(left, right, out Matrix2x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Matrix2x3 operator *(in Matrix2x2 left, in Matrix2x3 right)
        {
            Multiply(left, right, out Matrix2x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Matrix2x4 operator *(in Matrix2x2 left, in Matrix2x4 right)
        {
            Multiply(left, right, out Matrix2x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator *(in Matrix2x2 left, in Vector2 right)
        {
            Multiply(left, right, out Vector2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator *(in Vector2 left, in Matrix2x2 right)
        {
            Multiply(left, right, out Vector2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Matrix2x2 operator /(in Matrix2x2 left, float right)
        {
            Divide(left, right, out Matrix2x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Matrix2x2 left, in Matrix2x2 right)
        {
            return (left.M00 == right.M00 && left.M01 == right.M01 &&
                    left.M10 == right.M10 && left.M11 == right.M11);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Matrix2x2 left, in Matrix2x2 right)
        {
            return (left.M00 != right.M00 || left.M01 != right.M01 ||
                    left.M10 != right.M10 || left.M11 != right.M11);
        }

        #endregion Operator Overload
    }
}
