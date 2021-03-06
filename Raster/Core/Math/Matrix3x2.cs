﻿using System;
using System.Runtime.InteropServices;

namespace Raster.Core.Math
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Matrix3x2 : IEquatable<Matrix3x2>
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

        /// <summary>
        /// 
        /// </summary>
        public float M20;
        /// <summary>
        /// 
        /// </summary>
        public float M21;
        #endregion

        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly Matrix3x2 Zero       = new Matrix3x2(0.0f, 0.0f,
                                                                    0.0f, 0.0f,
                                                                    0.0f, 0.0f);

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
        public Vector2 Row2
        {
            get { return new Vector2(M20, M21); }
            set
            {
                M20 = value.X;
                M21 = value.Y;
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
        public float Determinant
        {
            get { return 0.0f; }
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
                    case 4: return M20;
                    case 5: return M21;
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
                    case 4: M20 = value; break;
                    case 5: M21 = value; break;
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
                if (row < 0 || row > 2)
                {
                    throw new ArgumentOutOfRangeException("row", "Row and column from 0 to 3");
                }

                if (column < 0 || column > 1)
                {
                    throw new ArgumentOutOfRangeException("row", "Row and column from 0 to 3");
                }

                return this[row * 2 + column];
            }

            set
            {
                if (row < 0 || row > 2)
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsZero
        {
            get
            {
                return (M00 == 0.0f && M01 == 0.0f &&
                        M10 == 0.0f && M11 == 0.0f &&
                        M20 == 0.0f && M21 == 0.0f);
            }
        }
        #endregion Public Instance Properties

        #region Constructor
        public Matrix3x2(float value)
        {
            M00 = value;
            M01 = value;

            M10 = value;
            M11 = value;

            M20 = value;
            M21 = value;
        }

        public Matrix3x2(Matrix3x2 other)
        {
            M00 = other.M00;
            M01 = other.M01;

            M10 = other.M10;
            M11 = other.M11;

            M20 = other.M20;
            M21 = other.M21;
        }

        public Matrix3x2(float m00, float m01,
                         float m10, float m11,
                         float m20, float m21)
        {
            M00 = m00;
            M01 = m01;

            M10 = m10;
            M11 = m11;

            M20 = m20;
            M21 = m21;
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
            if (obj is Matrix2x4)
            {
                return Equals((Matrix3x2)obj);
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
                       M10.GetHashCode() + M11.GetHashCode() +
                       M20.GetHashCode() + M21.GetHashCode();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Matrix3x2: [[{0}, {1}], " +
                                             "[{2}, {3}], " +
                                             "[{4}, {5}]]",
                                 M00, M01, M10, M11, M20, M21);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Matrix3x2 other) { return this == other; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Fill(float value)
        {
            M00 = value;
            M01 = value;

            M10 = value;
            M11 = value;

            M20 = value;
            M21 = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetToZero()
        {
            M00 = 0.0f;
            M01 = 0.0f;
                
            M10 = 0.0f;
            M11 = 0.0f;
                  
            M20 = 0.0f;
            M21 = 0.0f;
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
            float temp2 = this[2, secondColumn];

            this[0, secondColumn] = this[0, firstColumn];
            this[1, secondColumn] = this[1, firstColumn];
            this[2, secondColumn] = this[2, firstColumn];

            this[0, firstColumn] = temp0;
            this[1, firstColumn] = temp1;
            this[2, firstColumn] = temp2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float[] ToArray()
        {
            return new float[]
            {
                M00, M01,
                M10, M11,
                M20, M21
            };
        }
        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix2x3 Transpose(in Matrix3x2 matrix)
        {
            Transpose(matrix, out Matrix2x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        public static void Transpose(in Matrix3x2 matrix, out Matrix2x3 result)
        {
            result.M00 = matrix.M00;
            result.M01 = matrix.M10;

            result.M02 = matrix.M20;
            result.M10 = matrix.M01;

            result.M11 = matrix.M11;
            result.M12 = matrix.M21;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Add(in Matrix3x2 left, float right, out Matrix3x2 result)
        {
            result.M00 = left.M00 + right;
            result.M01 = left.M01 + right;

            result.M10 = left.M10 + right;
            result.M11 = left.M11 + right;

            result.M20 = left.M20 + right;
            result.M21 = left.M21 + right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Add(in Matrix3x2 left, in Matrix3x2 right, out Matrix3x2 result)
        {
            result.M00 = left.M00 + right.M00;
            result.M01 = left.M01 + right.M01;

            result.M10 = left.M10 + right.M10;
            result.M11 = left.M11 + right.M11;

            result.M20 = left.M20 + right.M20;
            result.M21 = left.M21 + right.M21;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Subtract(in Matrix3x2 left, float right, out Matrix3x2 result)
        {
            result.M00 = left.M00 - right;
            result.M01 = left.M01 - right;

            result.M10 = left.M10 - right;
            result.M11 = left.M11 - right;

            result.M20 = left.M20 - right;
            result.M21 = left.M21 - right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Subtract(in Matrix3x2 left, in Matrix3x2 right, out Matrix3x2 result)
        {
            result.M00 = left.M00 - right.M00;
            result.M01 = left.M01 - right.M01;

            result.M10 = left.M10 - right.M10;
            result.M11 = left.M11 - right.M11;

            result.M20 = left.M20 - right.M20;
            result.M21 = left.M21 - right.M21;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Multiply(in Matrix3x2 left, float right, out Matrix3x2 result)
        {
            result.M00 = left.M00 * right;
            result.M01 = left.M01 * right;

            result.M10 = left.M10 * right;
            result.M11 = left.M11 * right;

            result.M20 = left.M20 * right;
            result.M21 = left.M21 * right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Multiply(in Matrix3x2 left, in Vector2 right, out Vector3 result)
        {
            result.X = left.M00 * right.X + left.M01 * right.Y;
            result.Y = left.M10 * right.X + left.M11 * right.Y;
            result.Z = left.M20 * right.X + left.M21 * right.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Multiply(in Vector3 left, in Matrix3x2 right, out Vector2 result)
        {
            result.X = left.X * right.M00 + left.Y * right.M10 + left.Z * right.M20;
            result.Y = left.X * right.M01 + left.Y * right.M11 + left.Z * right.M21;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Multiply(in Matrix3x2 left, in Matrix2x2 right, out Matrix3x2 result)
        {
            result.M00 = left.M00 * right.M00 + left.M01 * right.M10;
            result.M01 = left.M00 * right.M01 + left.M01 * right.M11;

            result.M10 = left.M10 * right.M00 + left.M11 * right.M10;
            result.M11 = left.M10 * right.M01 + left.M11 * right.M11;

            result.M20 = left.M20 * right.M00 + left.M21 * right.M10;
            result.M21 = left.M20 * right.M01 + left.M21 * right.M11;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Multiply(in Matrix3x2 left, in Matrix2x3 right, out Matrix3x3 result)
        {
            result.M00 = left.M00 * right.M00 + left.M01 * right.M10;
            result.M01 = left.M00 * right.M01 + left.M01 * right.M11;
            result.M02 = left.M00 * right.M02 + left.M01 * right.M12;

            result.M10 = left.M10 * right.M00 + left.M11 * right.M10;
            result.M11 = left.M10 * right.M01 + left.M11 * right.M11;
            result.M12 = left.M10 * right.M02 + left.M11 * right.M12;

            result.M20 = left.M20 * right.M00 + left.M21 * right.M10;
            result.M21 = left.M20 * right.M01 + left.M21 * right.M11;
            result.M22 = left.M20 * right.M02 + left.M21 * right.M12;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Multiply(in Matrix3x2 left, in Matrix2x4 right, out Matrix3x4 result)
        {
            result.M00 = left.M00 * right.M00 + left.M01 * right.M10;
            result.M01 = left.M00 * right.M01 + left.M01 * right.M11;
            result.M02 = left.M00 * right.M02 + left.M01 * right.M12;
            result.M03 = left.M00 * right.M03 + left.M01 * right.M13;

            result.M10 = left.M10 * right.M00 + left.M11 * right.M10;
            result.M11 = left.M10 * right.M01 + left.M11 * right.M11;
            result.M12 = left.M10 * right.M02 + left.M11 * right.M12;
            result.M13 = left.M10 * right.M03 + left.M11 * right.M13;

            result.M20 = left.M20 * right.M00 + left.M21 * right.M10;
            result.M21 = left.M20 * right.M01 + left.M21 * right.M11;
            result.M22 = left.M20 * right.M02 + left.M21 * right.M12;
            result.M23 = left.M20 * right.M02 + left.M21 * right.M13;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        public static void Negate(in Matrix3x2 matrix, out Matrix3x2 result)
        {
            result.M00 = -matrix.M00;
            result.M01 = -matrix.M01;

            result.M10 = -matrix.M10;
            result.M11 = -matrix.M11;

            result.M20 = -matrix.M20;
            result.M21 = -matrix.M21;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Divide(in Matrix3x2 left, float right, out Matrix3x2 result)
        {
            if (right == 0.0f)
            {
                result = Matrix3x2.Zero;
                return;
            }

            right = 1.0f / right;

            result.M00 = left.M00 * right;
            result.M01 = left.M01 * right;

            result.M10 = left.M10 * right;
            result.M11 = left.M11 * right;

            result.M20 = left.M20 * right;
            result.M21 = left.M21 * right;
        }

        #endregion Public Static Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Matrix3x2 operator +(in Matrix3x2 left, in Matrix3x2 right)
        {
            Add(left, right, out Matrix3x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Matrix3x2 operator +(in Matrix3x2 left, float right)
        {
            Add(left, right, out Matrix3x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix3x2 operator -(in Matrix3x2 matrix)
        {
            Negate(matrix, out Matrix3x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Matrix3x2 operator -(in Matrix3x2 left, float right)
        {
            Subtract(left, right, out Matrix3x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Matrix3x2 operator -(in Matrix3x2 left, in Matrix3x2 right)
        {
            Subtract(left, right, out Matrix3x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Matrix3x2 operator *(in Matrix3x2 left, float right)
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
        public static Matrix3x2 operator *(float left, in Matrix3x2 right)
        {
            Multiply(right, left, out Matrix3x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Matrix3x2 operator *(in Matrix3x2 left, in Matrix2x2 right)
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
        public static Matrix3x3 operator *(in Matrix3x2 left, in Matrix2x3 right)
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
        public static Matrix3x4 operator *(in Matrix3x2 left, in Matrix2x4 right)
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
        public static Vector3 operator *(in Matrix3x2 left, in Vector2 right)
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
        public static Vector2 operator *(in Vector3 left, in Matrix3x2 right)
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
        public static Matrix3x2 operator /(in Matrix3x2 left, float right)
        {
            Divide(left, right, out Matrix3x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Matrix3x2 left, in Matrix3x2 right)
        {
            return (left.M00 == right.M00 && left.M01 == right.M01 &&
                    left.M10 == right.M10 && left.M11 == right.M11 &&
                    left.M20 == right.M20 && left.M21 == right.M21);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Matrix3x2 left, in Matrix3x2 right)
        {
            return (left.M00 != right.M00 || left.M01 != right.M01 ||
                    left.M10 != right.M10 || left.M11 != right.M11 ||
                    left.M20 != right.M20 || left.M21 != right.M21); 
        }

        #endregion Operator Overload
    }
}
