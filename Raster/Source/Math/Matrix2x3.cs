﻿using System;
using System.Runtime.CompilerServices;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
    public struct Matrix2x3 : IEquatable<Matrix2x3>
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
        #endregion

        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly Matrix2x3 Zero = new Matrix2x3(0.0f, 0.0f, 0.0f,
                                                              0.0f, 0.0f, 0.0f);

        #endregion Public Static Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public float[] RawData
        {
            get
            {
                return new float[2 * 3]
                {
                    M00, M01, M02,
                    M10, M11, M12
                };
            }
        }

        #endregion Public Instance Properties

        #region Constructor
        public Matrix2x3(float value)
        {
            M00 = value;
            M01 = value;
            M02 = value;

            M10 = value;
            M11 = value;
            M12 = value;
        }

        public Matrix2x3(Matrix2x2 other)
        {
            M00 = other.M00;
            M01 = other.M01;
            M02 = 0.0f;

            M10 = other.M10;
            M11 = other.M11;
            M12 = 0.0f;
        }

        public Matrix2x3(Matrix2x3 other)
        {
            M00 = other.M00;
            M01 = other.M01;
            M02 = other.M02;

            M10 = other.M10;
            M11 = other.M11;
            M12 = other.M12;
        }

        public Matrix2x3(float m00, float m01, float m02,
                         float m10, float m11, float m12)
        {
            M00 = m00;
            M01 = m01;
            M02 = m02;

            M10 = m10;
            M11 = m11;
            M12 = m12;
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
            if (obj is Matrix2x3)
            {
                return Equals((Matrix2x3)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Matrix2x3: M00 = {0}, M01 = {1}, M02 = {2}, " +
                                            "M10 = {3}, M11 = {4}, M12 = {5} ",
                                            M00, M01, M02, M10, M11, M12);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Matrix2x3 other) => this == other;

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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsZero()
        {
            return (M00 == 0.0f && M01 == 0.0f && M02 == 0.0f &&
                    M10 == 0.0f && M11 == 0.0f && M12 == 0.0f);

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

                default:
                    throw new IndexOutOfRangeException("");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 Column(int column)
        {
            switch (column)
            {
                case 0:
                    return new Vector2(M00, M10);

                case 1:
                    return new Vector2(M01, M11);

                case 2:
                    return new Vector2(M02, M12);

                default:
                    throw new IndexOutOfRangeException("");
            }
        }

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add(in Matrix2x3 left, float right, out Matrix2x3 result)
        {
            result.M00 = left.M00 + right;
            result.M01 = left.M01 + right;
            result.M02 = left.M02 + right;

            result.M10 = left.M10 + right;
            result.M11 = left.M11 + right;
            result.M12 = left.M12 + right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add(in Matrix2x3 left, in Matrix2x3 right, out Matrix2x3 result)
        {
            result.M00 = left.M00 + right.M00;
            result.M01 = left.M01 + right.M01;
            result.M02 = left.M02 + right.M02;

            result.M10 = left.M10 + right.M10;
            result.M11 = left.M11 + right.M11;
            result.M12 = left.M12 + right.M12;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Subtract(in Matrix2x3 left, float right, out Matrix2x3 result)
        {
            result.M00 = left.M00 - right;
            result.M01 = left.M01 - right;
            result.M02 = left.M02 - right;

            result.M10 = left.M10 - right;
            result.M11 = left.M11 - right;
            result.M12 = left.M12 - right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Subtract(in Matrix2x3 left, in Matrix2x3 right, out Matrix2x3 result)
        {
            result.M00 = left.M00 - right.M00;
            result.M01 = left.M01 - right.M01;
            result.M02 = left.M02 - right.M02;

            result.M10 = left.M10 - right.M10;
            result.M11 = left.M11 - right.M11;
            result.M12 = left.M12 - right.M12;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Multiply(in Matrix2x3 left, float right, out Matrix2x3 result)
        {
            result.M00 = left.M00 * right;
            result.M01 = left.M01 * right;
            result.M02 = left.M02 * right;

            result.M10 = left.M10 * right;
            result.M11 = left.M11 * right;
            result.M12 = left.M12 * right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Multiply(in Matrix2x3 left, in Matrix3x2 right, out Matrix2x2 result)
        {
            result.M00 = left.M00 * right.M00 + left.M01 * right.M10 + left.M02 * right.M20;
            result.M01 = left.M00 * right.M01 + left.M01 * right.M11 + left.M02 * right.M21;

            result.M10 = left.M10 * right.M00 + left.M11 * right.M10 + left.M12 * right.M20;
            result.M11 = left.M10 * right.M01 + left.M11 * right.M11 + left.M12 * right.M21;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Multiply(in Matrix2x3 left, in Matrix3x3 right, out Matrix2x3 result)
        {
            result.M00 = left.M00 * right.M00 + left.M01 * right.M10 + left.M02 * right.M20;
            result.M01 = left.M00 * right.M01 + left.M01 * right.M11 + left.M02 * right.M21;
            result.M02 = left.M00 * right.M02 + left.M01 * right.M12 + left.M02 * right.M22;

            result.M10 = left.M10 * right.M00 + left.M11 * right.M10 + left.M12 * right.M20;
            result.M11 = left.M10 * right.M01 + left.M11 * right.M11 + left.M12 * right.M21;
            result.M12 = left.M10 * right.M02 + left.M11 * right.M12 + left.M12 * right.M22;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Multiply(in Matrix2x3 left, in Matrix3x4 right, out Matrix2x4 result)
        {
            result.M00 = left.M00 * right.M00 + left.M01 * right.M10 + left.M02 * right.M20;
            result.M01 = left.M00 * right.M01 + left.M01 * right.M11 + left.M02 * right.M21;
            result.M02 = left.M00 * right.M02 + left.M01 * right.M12 + left.M02 * right.M22;
            result.M03 = left.M00 * right.M03 + left.M01 * right.M13 + left.M02 * right.M23;

            result.M10 = left.M10 * right.M00 + left.M11 * right.M10 + left.M12 * right.M20;
            result.M11 = left.M10 * right.M01 + left.M11 * right.M11 + left.M12 * right.M21;
            result.M12 = left.M10 * right.M02 + left.M11 * right.M12 + left.M12 * right.M22;
            result.M13 = left.M00 * right.M03 + left.M01 * right.M13 + left.M02 * right.M23;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Multiply(in Matrix2x3 left, in Vector3 right, out Vector2 result)
        {
            result.X = left.M00 * right.X + left.M01 * right.Y + left.M02 * right.Z;
            result.Y = left.M10 * right.X + left.M11 * right.Y + left.M12 * right.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Multiply(in Vector2 left, in Matrix2x3 right, out Vector3 result)
        {
            result.X = left.X * right.M00 + left.Y * right.M10;
            result.Y = left.X * right.M01 + left.Y * right.M11;
            result.Z = left.X * right.M02 + left.Y * right.M12;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Divide(in Matrix2x3 left, float right, out Matrix2x3 result)
        {
            if (right == 0.0f)
            {
                result = Matrix2x3.Zero;
                return;
            }

            right = 1.0f / right;

            result.M00 = left.M00 * right;
            result.M01 = left.M01 * right;
            result.M02 = left.M02 * right;

            result.M10 = left.M10 * right;
            result.M11 = left.M11 * right;
            result.M12 = left.M12 * right;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Transpose(in Matrix2x3 matrix, out Matrix3x2 result)
        {
            result.M00 = matrix.M00;
            result.M01 = matrix.M10;

            result.M10 = matrix.M01;
            result.M11 = matrix.M11;

            result.M20 = matrix.M02;
            result.M21 = matrix.M12;
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
        public static Matrix2x3 operator +(in Matrix2x3 left, in Matrix2x3 right)
        {
            Matrix2x3 result;
            Add(left, right, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2x3 operator +(in Matrix2x3 left, float right)
        {
            Matrix2x3 result;
            Add(left, right, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2x3 operator -(in Matrix2x3 left, float right)
        {
            Matrix2x3 result;
            Subtract(left, right, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2x3 operator -(in Matrix2x3 left, in Matrix2x3 right)
        {
            Matrix2x3 result;
            Subtract(left, right, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2x3 operator *(in Matrix2x3 left, float right)
        {
            Matrix2x3 result;
            Subtract(left, right, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2x3 operator *(float left, in Matrix2x3 right)
        {
            Matrix2x3 result;
            Multiply(right, left, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2x2 operator *(in Matrix2x3 left, in Matrix3x2 right)
        {
            Matrix2x2 result;
            Multiply(left, right, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2x3 operator *(in Matrix2x3 left, in Matrix3x3 right)
        {
            Matrix2x3 result;
            Multiply(left, right, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2x4 operator *(in Matrix2x3 left, in Matrix3x4 right)
        {
            Matrix2x4 result;
            Multiply(left, right, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
       public static Vector2 operator *(in Matrix2x3 left, in Vector3 right)
        {
            Vector2 result;
            Multiply(left, right, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator *(in Vector2 left, in Matrix2x3 right)
        {
            Vector3 result;
            Multiply(left, right, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2x3 operator /(in Matrix2x3 left, float right)
        {
            Matrix2x3 result;
            Divide(left, right, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Matrix2x3 left, in Matrix2x3 right)
        {
            return (left.M00 == right.M00 && left.M01 == right.M01 && left.M02 == right.M02 && 
                    left.M10 == right.M10 && left.M11 == right.M11 && left.M12 == right.M12);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Matrix2x3 left, in Matrix2x3 right)
        {
            return (left.M00 != right.M00 || left.M01 != right.M01 || left.M02 != right.M02 ||
                    left.M10 != right.M10 || left.M11 != right.M11 || left.M12 != right.M12);
        }

        #endregion Operator Overload
    }
}
