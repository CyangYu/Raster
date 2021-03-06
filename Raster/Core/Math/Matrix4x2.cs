﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Raster.Core.Math
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Matrix4x2 : IEquatable<Matrix4x2>
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

        /// <summary>
        /// 
        /// </summary>
        public float M30;
        /// <summary>
        /// 
        /// </summary>
        public float M31;
        #endregion

        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly Matrix4x2 Zero = new Matrix4x2(0.0f, 0.0f,
                                                              0.0f, 0.0f,
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

        // <summary>
        /// 
        /// </summary>
        public Vector2 Row3
        {
            get { return new Vector2(M30, M31); }
            set
            {
                M30 = value.X;
                M31 = value.Y;
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
        /// <returns></returns>        
        public bool IsZero
        {
            get
            {
                return (M00 == 0.0f && M01 == 0.0f &&
                        M10 == 0.0f && M11 == 0.0f &&
                        M20 == 0.0f && M21 == 0.0f &&
                        M30 == 0.0f && M31 == 0.0f);
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
                    case 4: return M20;
                    case 5: return M21;
                    case 6: return M30;
                    case 7: return M31;
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
                    case 6: M30 = value; break;
                    case 7: M31 = value; break;
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

                if (column < 0 || column > 1)
                {
                    throw new ArgumentOutOfRangeException("row", "Row and column from 0 to 3");
                }

                return this[row * 2 + column];
            }

            set
            {
                if (row < 0 || row > 3)
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
        public Matrix4x2(float value)
        {
            M00 = value;
            M01 = value;

            M10 = value;
            M11 = value;

            M20 = value;
            M21 = value;

            M30 = value;
            M31 = value;
        }

        public Matrix4x2(in Matrix4x2 other)
        {
            M00 = other.M00;
            M01 = other.M01;

            M10 = other.M10;
            M11 = other.M11;

            M20 = other.M20;
            M21 = other.M21;

            M30 = other.M30;
            M31 = other.M31;
        }

        public Matrix4x2(float m00, float m01,
                         float m10, float m11,
                         float m20, float m21,
                         float m30, float m31)
        {
            M00 = m00;
            M01 = m01;

            M10 = m10;
            M11 = m11;

            M20 = m20;
            M21 = m21;

            M30 = m30;
            M31 = m31;
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
            if (obj is Matrix4x2)
            {
                return Equals((Matrix4x2)obj);
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
                       M20.GetHashCode() + M21.GetHashCode() +
                       M30.GetHashCode() + M31.GetHashCode();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Matrix4x2: [[{0}, {1}], " +
                                             "[{4}, {5}], " +
                                             "[{8}, {9}], " +
                                             "[{10},{11}]]",
                                 M00, M01, M10, M11, M20, M21, M30, M31);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>        
        public bool Equals(Matrix4x2 other) { return this == other; }

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

            M30 = value;
            M31 = value;
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

            M30 = 0.0f;
            M31 = 0.0f;
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
        public float[] ToArray()
        {
            return new float[]
            {
                M00, M01,
                M10, M11,
                M20, M21,
                M30, M31
            };
        }
        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix2x4 Transpose(in Matrix4x2 matrix)
        {
            Transpose(matrix, out Matrix2x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>       
        public static void Transpose(in Matrix4x2 matrix, out Matrix2x4 result)
        {
            result.M00 = matrix.M00;
            result.M01 = matrix.M10;
            result.M02 = matrix.M20;
            result.M03 = matrix.M30;

            result.M10 = matrix.M01;
            result.M11 = matrix.M11;
            result.M12 = matrix.M21;
            result.M13 = matrix.M31;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Add(in Matrix4x2 left, float right, out Matrix4x2 result)
        {
            result.M00 = left.M00 + right;
            result.M01 = left.M01 + right;

            result.M10 = left.M10 + right;
            result.M11 = left.M11 + right;

            result.M20 = left.M20 + right;
            result.M21 = left.M21 + right;

            result.M30 = left.M30 + right;
            result.M31 = left.M31 + right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Add(in Matrix4x2 left, in Matrix4x2 right, out Matrix4x2 result)
        {
            result.M00 = left.M00 + right.M00;
            result.M01 = left.M01 + right.M01;

            result.M10 = left.M10 + right.M10;
            result.M11 = left.M11 + right.M11;

            result.M20 = left.M20 + right.M20;
            result.M21 = left.M21 + right.M21;

            result.M30 = left.M30 + right.M30;
            result.M31 = left.M31 + right.M31;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Subtract(in Matrix4x2 left, float right, out Matrix4x2 result)
        {
            result.M00 = left.M00 - right;
            result.M01 = left.M01 - right;

            result.M10 = left.M10 - right;
            result.M11 = left.M11 - right;

            result.M20 = left.M20 - right;
            result.M21 = left.M21 - right;

            result.M30 = left.M30 - right;
            result.M31 = left.M31 - right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Subtract(in Matrix4x2 left, in Matrix4x2 right, out Matrix4x2 result)
        {
            result.M00 = left.M00 - right.M00;
            result.M01 = left.M01 - right.M01;

            result.M10 = left.M10 - right.M10;
            result.M11 = left.M11 - right.M11;

            result.M20 = left.M20 - right.M20;
            result.M21 = left.M21 - right.M21;

            result.M30 = left.M30 - right.M30;
            result.M31 = left.M31 - right.M31;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Multiply(in Matrix4x2 left, float right, out Matrix4x2 result)
        {
            result.M00 = left.M00 * right;
            result.M01 = left.M01 * right;

            result.M10 = left.M10 * right;
            result.M11 = left.M11 * right;

            result.M20 = left.M20 * right;
            result.M21 = left.M21 * right;

            result.M30 = left.M30 * right;
            result.M31 = left.M31 * right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Multiply(in Matrix4x2 left, in Matrix2x2 right, out Matrix4x2 result)
        {
            result.M00 = left.M00 * right.M00 + left.M01 * right.M10;
            result.M01 = left.M00 * right.M01 + left.M01 * right.M11;

            result.M10 = left.M10 * right.M00 + left.M11 * right.M10;
            result.M11 = left.M10 * right.M01 + left.M11 * right.M11;

            result.M20 = left.M20 * right.M00 + left.M21 * right.M10;
            result.M21 = left.M20 * right.M01 + left.M21 * right.M11;

            result.M30 = left.M30 * right.M00 + left.M31 * right.M10;
            result.M31 = left.M30 * right.M01 + left.M31 * right.M11;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Multiply(in Matrix4x2 left, in Matrix2x3 right, out Matrix4x3 result)
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

            result.M30 = left.M30 * right.M00 + left.M31 * right.M10;
            result.M31 = left.M30 * right.M01 + left.M31 * right.M11;
            result.M32 = left.M30 * right.M02 + left.M31 * right.M12;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Multiply(in Matrix4x2 left, in Matrix2x4 right, out Matrix4x4 result)
        {
            result.M00 = left.M00 * right.M00 + left.M01 * right.M10;
            result.M01 = left.M00 * right.M01 + left.M01 * right.M11;
            result.M02 = left.M00 * right.M02 + left.M01 * right.M12;
            result.M03 = left.M00 * right.M03 + left.M01 * right.M13;

            result.M10 = left.M10 * right.M00 + left.M11 * right.M10;
            result.M11 = left.M10 * right.M01 + left.M11 * right.M11;
            result.M12 = left.M10 * right.M02 + left.M11 * right.M12;
            result.M13 = left.M10 * right.M03 + left.M01 * right.M13;

            result.M20 = left.M20 * right.M00 + left.M21 * right.M10;
            result.M21 = left.M20 * right.M01 + left.M21 * right.M11;
            result.M22 = left.M20 * right.M02 + left.M21 * right.M12;
            result.M23 = left.M20 * right.M03 + left.M21 * right.M13;

            result.M30 = left.M30 * right.M00 + left.M31 * right.M10;
            result.M31 = left.M30 * right.M01 + left.M31 * right.M11;
            result.M32 = left.M30 * right.M02 + left.M31 * right.M12;
            result.M33 = left.M30 * right.M03 + left.M31 * right.M13;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Multiply(in Matrix4x2 left, in Vector2 right, out Vector4 result)
        {
            result.X = left.M00 * right.X + left.M01 * right.Y;
            result.Y = left.M10 * right.X + left.M11 * right.Y;
            result.Z = left.M20 * right.X + left.M21 * right.Y;
            result.W = left.M30 * right.X + left.M31 * right.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Multiply(in Vector4 left, in Matrix4x2 right, out Vector2 result)
        {
            result.X = left.X * right.M00 + left.Y * right.M10 + 
                       left.Z * right.M20 + left.W * right.M30;
            result.Y = left.X * right.M01 + left.Y * right.M11 + 
                       left.Z * right.M21 + left.W * right.M31;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        public static void Negate(in Matrix4x2 matrix, out Matrix4x2 result)
        {
            result.M00 = -matrix.M00;
            result.M01 = -matrix.M01;

            result.M10 = -matrix.M10;
            result.M11 = -matrix.M11;

            result.M20 = -matrix.M20;
            result.M21 = -matrix.M21;

            result.M30 = -matrix.M30;
            result.M31 = -matrix.M31;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Divide(in Matrix4x2 left, float right, out Matrix4x2 result)
        {
            if (right == 0.0f)
            {
                result = Matrix4x2.Zero;
                return;
            }

            float inv = 1.0f / right;

            result.M00 = left.M00 * inv;
            result.M01 = left.M01 * inv;

            result.M10 = left.M10 * inv;
            result.M11 = left.M11 * inv;

            result.M20 = left.M20 * inv;
            result.M21 = left.M21 * inv;

            result.M30 = left.M30 * inv;
            result.M31 = left.M31 * inv;
        }

        #endregion Public Static Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>       
        public static Matrix4x2 operator +(in Matrix4x2 left, in Matrix4x2 right)
        {
            Add(left, right, out Matrix4x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix4x2 operator +(in Matrix4x2 left, float right)
        {
            Add(left, right, out Matrix4x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix4x2 operator -(in Matrix4x2 matrix)
        {
            Negate(matrix, out Matrix4x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix4x2 operator -(in Matrix4x2 left, float right)
        {
            Subtract(left, right, out Matrix4x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix4x2 operator -(in Matrix4x2 left, in Matrix4x2 right)
        {
            Subtract(left, right, out Matrix4x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix4x2 operator *(float left, in Matrix4x2 right)
        {
            Multiply(right, left, out Matrix4x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix4x2 operator *(in Matrix4x2 left, float right)
        {
            Subtract(left, right, out Matrix4x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix4x2 operator *(in Matrix4x2 left, in Matrix2x2 right)
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
        public static Matrix4x3 operator *(in Matrix4x2 left, in Matrix2x3 right)
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
        
        public static Matrix4x4 operator *(in Matrix4x2 left, in Matrix2x4 right)
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
        public static Vector4 operator *(in Matrix4x2 left, in Vector2 right)
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
        public static Vector2 operator *(in Vector4 left, in Matrix4x2 right)
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
        public static Matrix4x2 operator /(in Matrix4x2 left, float right)
        {
            Divide(left, right, out Matrix4x2 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Matrix4x2 left, in Matrix4x2 right)
        {
            return (left.M00 == right.M00 && left.M01 == right.M01 &&
                    left.M10 == right.M10 && left.M11 == right.M11 &&
                    left.M20 == right.M20 && left.M21 == right.M21 &&
                    left.M30 == right.M30 && left.M31 == right.M31);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Matrix4x2 left, in Matrix4x2 right)
        {
            return (left.M00 != right.M00 || left.M01 != right.M01 ||
                    left.M10 != right.M10 || left.M11 != right.M11 ||
                    left.M20 != right.M20 || left.M21 != right.M21 ||
                    left.M30 != right.M30 || left.M31 != right.M31);
        }

        #endregion Operator Overload
    }
}