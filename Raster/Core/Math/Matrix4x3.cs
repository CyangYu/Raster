﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Raster.Core.Math
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Matrix4x3 : IEquatable<Matrix4x3>
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
        #endregion

        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly Matrix4x3 Zero = new Matrix4x3(0.0f, 0.0f, 0.0f,
                                                              0.0f, 0.0f, 0.0f,
                                                              0.0f, 0.0f, 0.0f,
                                                              0.0f, 0.0f, 0.0f);
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
        public Vector3 Row3
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
                return 0.0f;
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
                        M20 == 0.0f && M21 == 0.0f && M22 == 0.0f &&
                        M30 == 0.0f && M31 == 0.0f && M32 == 0.0f);
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
                    case 3:  return M10;
                    case 4:  return M11;
                    case 5:  return M12;
                    case 6:  return M20;
                    case 7:  return M21;
                    case 8:  return M22;
                    case 9:  return M30;
                    case 10: return M31;
                    case 11: return M32;
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
                    case 3:  M10 = value; break;
                    case 4:  M11 = value; break;
                    case 5:  M12 = value; break;
                    case 6:  M20 = value; break;
                    case 7:  M21 = value; break;
                    case 8:  M22 = value; break;
                    case 9:  M30 = value; break;
                    case 10: M31 = value; break;
                    case 11: M32 = value; break;
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

                if (column < 0 || column > 2)
                {
                    throw new ArgumentOutOfRangeException("row", "Row and column from 0 to 3");
                }

                return this[row * 3 + column];
            }

            set
            {
                if (row < 0 || row > 3)
                {
                    throw new ArgumentOutOfRangeException("row", "Row and column from 0 to 3");
                }

                if (column < 0 || column > 2)
                {
                    throw new ArgumentOutOfRangeException("row", "Row and column from 0 to 3");
                }

                this[row * 3 + column] = value;
            }
        }
        #endregion Public Instance Fields

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Matrix4x3(float value)
        {
            M00 = value; M01 = value; M02 = value;
            M10 = value; M11 = value; M12 = value;
            M20 = value; M21 = value; M22 = value;
            M30 = value; M31 = value; M32 = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public Matrix4x3(in Matrix4x3 other)
        {
            M00 = other.M00; M01 = other.M01; M02 = other.M02;
            M10 = other.M10; M11 = other.M11; M12 = other.M12;
            M20 = other.M20; M21 = other.M21; M22 = other.M22;
            M30 = other.M30; M31 = other.M31; M32 = other.M32;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m00"></param>
        /// <param name="m01"></param>
        /// <param name="m02"></param>
        /// <param name="m10"></param>
        /// <param name="m11"></param>
        /// <param name="m12"></param>
        /// <param name="m20"></param>
        /// <param name="m21"></param>
        /// <param name="m22"></param>
        /// <param name="m30"></param>
        /// <param name="m31"></param>
        /// <param name="m32"></param>
        public Matrix4x3(float m00, float m01, float m02,
                         float m10, float m11, float m12,
                         float m20, float m21, float m22,
                         float m30, float m31, float m32)
        {
            M00 = m00; M01 = m01; M02 = m02;
            M10 = m10; M11 = m11; M12 = m12;
            M20 = m20; M21 = m21; M22 = m22;
            M30 = m30; M31 = m31; M32 = m32;
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
            if (obj is Matrix4x3)
            {
                return Equals((Matrix4x3)obj);
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
                       M20.GetHashCode() + M21.GetHashCode() + M22.GetHashCode() +
                       M30.GetHashCode() + M31.GetHashCode() + M32.GetHashCode();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Matrix4x3: [[{0}, {1},  {2}], " +
                                             "[{4}, {5},  {6}], " +
                                             "[{8}, {9},  {10}], " +
                                             "[{12},{13}, {14}]]",
                                 M00, M01, M02, M10, M11, M12, M20, M21, M22, M30, M31, M32);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Matrix4x3 other) { return this == other; }

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

            M30 = 0.0f;
            M31 = 0.0f;
            M32 = 0.0f;
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

            this[secondRow, 0] = this[firstRow, 0];
            this[secondRow, 1] = this[firstRow, 1];
            this[secondRow, 2] = this[firstRow, 2];

            this[firstRow, 0] = temp0;
            this[firstRow, 1] = temp1;
            this[firstRow, 2] = temp2;
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
                M00, M01, M02,
                M10, M11, M12,
                M20, M21, M22,
                M30, M31, M32,
            };
        }
        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix3x4 Transpose(in Matrix4x3 matrix)
        {
            Transpose(matrix, out Matrix3x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>       
        public static void Transpose(in Matrix4x3 matrix, out Matrix3x4 result)
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Add(in Matrix4x3 left, float right, out Matrix4x3 result)
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

            result.M30 = left.M30 + right;
            result.M31 = left.M31 + right;
            result.M32 = left.M32 + right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Add(in Matrix4x3 left, in Matrix4x3 right, out Matrix4x3 result)
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

            result.M30 = left.M30 + right.M30;
            result.M31 = left.M31 + right.M31;
            result.M32 = left.M32 + right.M32;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Subtract(in Matrix4x3 left, float right, out Matrix4x3 result)
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

            result.M30 = left.M30 - right;
            result.M31 = left.M31 - right;
            result.M32 = left.M32 - right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Subtract(in Matrix4x3 left, in Matrix4x3 right, out Matrix4x3 result)
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

            result.M30 = left.M30 - right.M30;
            result.M31 = left.M31 - right.M31;
            result.M32 = left.M32 - right.M32;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Multiply(in Matrix4x3 left, float right, out Matrix4x3 result)
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

            result.M30 = left.M30 * right;
            result.M31 = left.M31 * right;
            result.M32 = left.M32 * right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Multiply(in Matrix4x3 left, in Matrix3x2 right, out Matrix4x2 result)
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

            result.M30 = left.M30 * right.M00 + left.M31 * right.M10 + 
                         left.M32 * right.M20;
            result.M31 = left.M30 * right.M01 + left.M31 * right.M11 + 
                         left.M32 * right.M21;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Multiply(in Matrix4x3 left, in Matrix3x3 right, out Matrix4x3 result)
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
            
            result.M30 = left.M30 * right.M00 + left.M31 * right.M10 + 
                         left.M32 * right.M20;
            result.M31 = left.M30 * right.M01 + left.M31 * right.M11 + 
                         left.M32 * right.M21;
            result.M32 = left.M30 * right.M02 + left.M31 * right.M12 + 
                         left.M32 * right.M22;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Multiply(in Matrix4x3 left, in Matrix3x4 right, out Matrix4x4 result)
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
            result.M13 = left.M10 * right.M03 + left.M11 * right.M13 + 
                         left.M12 * right.M23;

            result.M20 = left.M20 * right.M00 + left.M21 * right.M10 + 
                         left.M22 * right.M20;
            result.M21 = left.M20 * right.M01 + left.M21 * right.M11 + 
                         left.M22 * right.M21;
            result.M22 = left.M20 * right.M02 + left.M21 * right.M12 + 
                         left.M22 * right.M22;
            result.M23 = left.M00 * right.M02 + left.M01 * right.M12 + 
                         left.M22 * right.M23;

            result.M30 = left.M30 * right.M00 + left.M31 * right.M10 + 
                         left.M32 * right.M20;
            result.M31 = left.M30 * right.M01 + left.M31 * right.M11 + 
                         left.M32 * right.M21;
            result.M32 = left.M30 * right.M02 + left.M31 * right.M12 + 
                         left.M32 * right.M22;
            result.M33 = left.M30 * right.M03 + left.M31 * right.M13 + 
                         left.M32 * right.M23;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Multiply(in Matrix4x3 left, in Vector3 right, out Vector4 result)
        {
            result.X = left.M00 * right.X + left.M01 * right.Y + 
                       left.M02 * right.Z;
            result.Y = left.M10 * right.X + left.M11 * right.Y + 
                       left.M12 * right.Z;
            result.Z = left.M20 * right.X + left.M21 * right.Y + 
                       left.M22 * right.Z;
            result.W = left.M30 * right.X + left.M31 * right.Y + 
                       left.M32 * right.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Multiply(in Vector4 left, in Matrix4x3 right, out Vector3 result)
        {
            result.X = left.X * right.M00 + left.Y * right.M10 + 
                       left.Z * right.M20 + left.W * right.M30;
            result.Y = left.X * right.M01 + left.Y * right.M11 + 
                       left.Z * right.M21 + left.W * right.M31;
            result.Z = left.X * right.M02 + left.Y * right.M12 + 
                       left.Z * right.M22 + left.W * right.M32;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        public static void Negate(in Matrix4x3 matrix, out Matrix4x3 result)
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

            result.M30 = -matrix.M30;
            result.M31 = -matrix.M31;
            result.M32 = -matrix.M32;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Divide(in Matrix4x3 left, float right, out Matrix4x3 result)
        {
            if (right == 0.0f)
            {
                result = Matrix4x3.Zero;
                return;
            }

            float inv = 1.0f / right;

            result.M00 = left.M00 * inv;
            result.M01 = left.M01 * inv;
            result.M02 = left.M02 * inv;
                                    
            result.M10 = left.M10 * inv;
            result.M11 = left.M11 * inv;
            result.M12 = left.M12 * inv;
                                    
            result.M20 = left.M20 * inv;
            result.M21 = left.M21 * inv;
            result.M22 = left.M22 * inv;
                                    
            result.M30 = left.M30 * inv;
            result.M31 = left.M31 * inv;
            result.M32 = left.M32 * inv;
        }

        #endregion Public Static Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix4x3 operator +(in Matrix4x3 left, in Matrix4x3 right)
        {
            Add(left, right, out Matrix4x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix4x3 operator +(in Matrix4x3 left, float right)
        {
            Add(left, right, out Matrix4x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix4x3 operator -(in Matrix4x3 matrix)
        {
            Negate(matrix, out Matrix4x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>       
        public static Matrix4x3 operator -(in Matrix4x3 left, float right)
        {
            Subtract(left, right, out Matrix4x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>       
        public static Matrix4x3 operator -(in Matrix4x3 left, in Matrix4x3 right)
        {
            Subtract(left, right, out Matrix4x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix4x3 operator *(in Matrix4x3 left, float right)
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
        public static Matrix4x3 operator *(float left, in Matrix4x3 right)
        {
            Multiply(right, left, out Matrix4x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix4x2 operator *(in Matrix4x3 left, in Matrix3x2 right)
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
        public static Matrix4x3 operator *(in Matrix4x3 left, in Matrix3x3 right)
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
        public static Matrix4x4 operator *(in Matrix4x3 left, in Matrix3x4 right)
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
        public static Vector4 operator *(in Matrix4x3 left, in Vector3 right)
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
        public static Vector3 operator *(in Vector4 left, in Matrix4x3 right)
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
        public static Matrix4x3 operator /(in Matrix4x3 left, float right)
        {
            Divide(left, right, out Matrix4x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Matrix4x3 left, in Matrix4x3 right)
        {
            return (left.M00 == right.M00 && left.M01 == right.M01 && 
                    left.M02 == right.M02 &&
                    left.M10 == right.M10 && left.M11 == right.M11 && 
                    left.M12 == right.M12 &&
                    left.M20 == right.M20 && left.M21 == right.M21 && 
                    left.M22 == right.M22 &&
                    left.M30 == right.M30 && left.M31 == right.M31 && 
                    left.M32 == right.M32);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Matrix4x3 left, in Matrix4x3 right)
        {
            return (left.M00 != right.M00 || left.M01 != right.M01 || 
                    left.M02 != right.M02 ||
                    left.M10 != right.M10 || left.M11 != right.M11 || 
                    left.M12 != right.M12 ||
                    left.M20 != right.M20 || left.M21 != right.M21 || 
                    left.M22 != right.M22 ||
                    left.M30 != right.M30 || left.M31 != right.M31 || 
                    left.M32 != right.M32);
        }

        #endregion Operator Overload
    }
}
