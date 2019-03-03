﻿using System;
using System.Runtime.InteropServices;

namespace Raster.Math
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Matrix3x4 : IEquatable<Matrix3x4>
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
        #endregion

        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly Matrix3x4 Zero = new Matrix3x4(0.0f, 0.0f, 0.0f, 0.0f,
                                                              0.0f, 0.0f, 0.0f, 0.0f,
                                                              0.0f, 0.0f, 0.0f, 0.0f);
        #endregion Public Static Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public Vector4 Row0 => new Vector4(M00, M01, M02, M03);

        /// <summary>
        /// 
        /// </summary>
        public Vector4 Row1 => new Vector4(M10, M11, M12, M13);

        /// <summary>
        /// 
        /// </summary>
        public Vector4 Row2 => new Vector4(M20, M21, M22, M23);

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Column0 => new Vector3(M00, M10, M20);

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Column1 => new Vector3(M01, M11, M21);

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Column2 => new Vector3(M02, M12, M22);

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Column3 => new Vector3(M03, M13, M23);

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

        #endregion Public Instance Properties

        #region Constructor
        public Matrix3x4(float value)
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
        }

        public Matrix3x4(Matrix2x2 other)
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
        }

        public Matrix3x4(Matrix2x3 other)
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
        }

        public Matrix3x4(Matrix2x4 other)
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
        }

        public Matrix3x4(Matrix3x2 other)
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
        }

        public Matrix3x4(Matrix3x3 other)
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
        }

        public Matrix3x4(Matrix3x4 other)
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
        }

        public Matrix3x4(float m00, float m01, float m02, float m03,
                         float m10, float m11, float m12, float m13,
                         float m20, float m21, float m22, float m23)
        {
            M00 = m00;
            M01 = m01;
            M02 = m02;
            M03 = m03;

            M10 = m10;
            M11 = m11;
            M12 = m12;
            M13 = m13;

            M20 = m20;
            M21 = m21;
            M22 = m22;
            M23 = m23;
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
            if (obj is Matrix3x4)
            {
                return Equals((Matrix3x4)obj);
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
                return M00.GetHashCode() + M01.GetHashCode() + M02.GetHashCode() + M03.GetHashCode() + 
                       M10.GetHashCode() + M11.GetHashCode() + M12.GetHashCode() + M13.GetHashCode() +
                       M20.GetHashCode() + M21.GetHashCode() + M22.GetHashCode() + M23.GetHashCode();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Matrix3x4: [[{0}, {1}, {2}, {3}], " +
                                             "[{4}, {5}, {6}, {7}], " +
                                             "[{8}, {9}, {10},{11}]",
                                 M00, M01, M02, M03, M10, M11, M12, M13, M20, M21, M22, M23);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>       
        public bool Equals(Matrix3x4 other) => this == other;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsZero()
        {
            return (M00 == 0.0f && M01 == 0.0f && M02 == 0.0f && M03 == 0.0f &&
                    M10 == 0.0f && M11 == 0.0f && M12 == 0.0f && M13 == 0.0f &&
                    M20 == 0.0f && M21 == 0.0f && M22 == 0.0f && M23 == 0.0f);
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
            M03 = value;

            M10 = value;
            M11 = value;
            M12 = value;
            M13 = value;

            M20 = value;
            M21 = value;
            M22 = value;
            M23 = value;
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
        }

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix4x3 Transpose(in Matrix3x4 matrix)
        {
            Transpose(matrix, out Matrix4x3 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param> 
        public static void Transpose(in Matrix3x4 matrix, out Matrix4x3 result)
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

            result.M30 = matrix.M03;
            result.M31 = matrix.M13;
            result.M32 = matrix.M23;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Add(in Matrix3x4 left, float right, out Matrix3x4 result)
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Add(in Matrix3x4 left, in Matrix3x4 right, out Matrix3x4 result)
        {
            result.M00 = left.M00 + right.M00;
            result.M01 = left.M01 + right.M01;
            result.M02 = left.M02 + right.M02;
            result.M03 = left.M03 + right.M03;

            result.M10 = left.M10 + right.M10;
            result.M11 = left.M11 + right.M11;
            result.M12 = left.M12 + right.M12;
            result.M13 = left.M13 + right.M13;

            result.M20 = left.M20 + right.M20;
            result.M21 = left.M21 + right.M21;
            result.M22 = left.M22 + right.M22;
            result.M23 = left.M23 + right.M23;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Subtract(in Matrix3x4 left, float right, out Matrix3x4 result)
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Subtract(in Matrix3x4 left, in Matrix3x4 right, out Matrix3x4 result)
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Multiply(in Matrix3x4 left, float right, out Matrix3x4 result)
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Multiply(in Matrix3x4 left, in Matrix4x2 right, out Matrix3x2 result)
        {
            result.M00 = left.M00 * right.M00 + left.M01 * right.M10 + 
                         left.M02 * right.M20 + left.M03 * right.M30;
            result.M01 = left.M00 * right.M01 + left.M01 * right.M11 + 
                         left.M02 * right.M21 + left.M03 * right.M31;

            result.M10 = left.M10 * right.M00 + left.M11 * right.M10 + 
                         left.M12 * right.M20 + left.M13 * right.M30;
            result.M11 = left.M10 * right.M01 + left.M11 * right.M11 + 
                         left.M12 * right.M21 + left.M13 * right.M31;
    
            result.M20 = left.M20 * right.M00 + left.M21 * right.M10 + 
                         left.M22 * right.M20 + left.M23 * right.M30;
            result.M21 = left.M20 * right.M01 + left.M21 * right.M11 + 
                         left.M22 * right.M21 + left.M23 * right.M31;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Multiply(in Matrix3x4 left, in Matrix4x3 right, out Matrix3x3 result)
        {
            result.M00 = left.M00 * right.M00 + left.M01 * right.M10 + 
                         left.M02 * right.M20 + left.M03 * right.M30;
            result.M01 = left.M00 * right.M01 + left.M01 * right.M11 + 
                         left.M02 * right.M21 + left.M03 * right.M31;
            result.M02 = left.M00 * right.M02 + left.M01 * right.M12 + 
                         left.M02 * right.M22 + left.M03 * right.M32;
         
            result.M10 = left.M10 * right.M00 + left.M11 * right.M10 + 
                         left.M12 * right.M20 + left.M13 * right.M30;
            result.M11 = left.M10 * right.M01 + left.M11 * right.M11 + 
                         left.M12 * right.M21 + left.M13 * right.M31;
            result.M12 = left.M10 * right.M02 + left.M11 * right.M12 + 
                         left.M12 * right.M22 + left.M13 * right.M32;
           
            result.M20 = left.M20 * right.M00 + left.M21 * right.M10 + 
                         left.M22 * right.M20 + left.M23 * right.M30;
            result.M21 = left.M20 * right.M01 + left.M21 * right.M11 + 
                         left.M22 * right.M21 + left.M23 * right.M31;
            result.M22 = left.M20 * right.M02 + left.M21 * right.M12 + 
                         left.M22 * right.M22 + left.M23 * right.M32;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Multiply(in Matrix3x4 left, in Matrix4x4 right, out Matrix3x4 result)
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
                         left.M12 * right.M20 + left.M13 * right.M30;
            result.M11 = left.M10 * right.M01 + left.M11 * right.M11 + 
                         left.M12 * right.M21 + left.M13 * right.M31;
            result.M12 = left.M10 * right.M02 + left.M11 * right.M12 + 
                         left.M12 * right.M22 + left.M13 * right.M32;
            result.M13 = left.M10 * right.M03 + left.M11 * right.M13 + 
                         left.M12 * right.M23 + left.M13 * right.M33;

            result.M20 = left.M20 * right.M00 + left.M21 * right.M10 + 
                         left.M22 * right.M20 + left.M23 * right.M30;
            result.M21 = left.M20 * right.M01 + left.M21 * right.M11 + 
                         left.M22 * right.M21 + left.M23 * right.M31;
            result.M22 = left.M20 * right.M02 + left.M21 * right.M12 + 
                         left.M22 * right.M22 + left.M23 * right.M32;
            result.M23 = left.M20 * right.M03 + left.M21 * right.M13 + 
                         left.M12 * right.M23 + left.M23 * right.M33;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>       
        public static void Multiply(in Matrix3x4 left, in Vector4 right, out Vector3 result)
        {
            result.X = left.M00 * right.X + left.M01 * right.Y + left.M02 * right.Z + left.M03 * right.W;
            result.Y = left.M10 * right.X + left.M11 * right.Y + left.M12 * right.Z + left.M13 * right.W;
            result.Z = left.M20 * right.X + left.M21 * right.Y + left.M22 * right.Z + left.M23 * right.W;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        
        public static void Multiply(in Vector3 left, in Matrix3x4 right, out Vector4 result)
        {
            result.X = left.X * right.M00 + left.Y * right.M10 + left.Z * right.M20;
            result.Y = left.X * right.M01 + left.Y * right.M11 + left.Z * right.M21;
            result.Z = left.X * right.M02 + left.Y * right.M12 + left.Z * right.M22;
            result.W = left.X * right.M03 + left.Y * right.M13 + left.Z * right.M23;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        public static void Negate(in Matrix3x4 matrix, out Matrix3x4 result)
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>        
        public static void Divide(in Matrix3x4 left, float right, out Matrix3x4 result)
        {
            if (right == 0.0f)
            {
                result = Matrix3x4.Zero;
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
        }

        #endregion Public Static Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix3x4 operator +(in Matrix3x4 left, in Matrix3x4 right)
        {
            Add(left, right, out Matrix3x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix3x4 operator +(in Matrix3x4 left, float right)
        {
            Add(left, right, out Matrix3x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix3x4 operator -(in Matrix3x4 matrix)
        {
            Negate(matrix, out Matrix3x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix3x4 operator -(in Matrix3x4 left, float right)
        {
            Subtract(left, right, out Matrix3x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix3x4 operator -(in Matrix3x4 left, in Matrix3x4 right)
        {
            Subtract(left, right, out Matrix3x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>        
        public static Matrix3x4 operator *(in Matrix3x4 left, float right)
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
        public static Matrix3x4 operator *(float left, in Matrix3x4 right)
        {
            Multiply(right, left, out Matrix3x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>       
        public static Matrix3x2 operator *(in Matrix3x4 left, in Matrix4x2 right)
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
        public static Matrix3x3 operator *(in Matrix3x4 left, in Matrix4x3 right)
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
        public static Matrix3x4 operator *(in Matrix3x4 left, in Matrix4x4 right)
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
        public static Vector3 operator *(in Matrix3x4 left, in Vector4 right)
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
        public static Vector4 operator *(in Vector3 left, in Matrix3x4 right)
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
        public static Matrix3x4 operator /(in Matrix3x4 left, float right)
        {
            Divide(left, right, out Matrix3x4 result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Matrix3x4 left, in Matrix3x4 right)
        {
            return (left.M00 == right.M00 && left.M01 == right.M01 && 
                    left.M02 == right.M02 && left.M03 == right.M03 &&
                    left.M10 == right.M10 && left.M11 == right.M11 && 
                    left.M12 == right.M12 && left.M13 == right.M13 &&
                    left.M20 == right.M20 && left.M21 == right.M21 && 
                    left.M22 == right.M22 && left.M23 == right.M23);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Matrix3x4 left, in Matrix3x4 right)
        {
            return (left.M00 != right.M00 || left.M01 != right.M01 || 
                    left.M02 != right.M02 || left.M03 != right.M03 ||
                    left.M10 != right.M10 || left.M11 != right.M11 || 
                    left.M12 != right.M12 || left.M13 != right.M13 ||
                    left.M20 != right.M20 || left.M21 != right.M21 || 
                    left.M22 != right.M22 || left.M23 != right.M23);
        }

        #endregion Operator Overload
    }
}
