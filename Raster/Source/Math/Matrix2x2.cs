﻿using System;
using System.Runtime.CompilerServices;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
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
        public static readonly Matrix2x2 Zero       = new Matrix2x2(0.0f, 0.0f,
                                                                    0.0f, 0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Matrix2x2 Identity   = new Matrix2x2(1.0f, 0.0f,
                                                                    0.0f, 1.0f);

        #endregion Public Static Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public float[] RawData
        {
            get
            {
                return new float[2 * 2]
                {
                    M00, M01,
                    M10, M11
                };
            }
        }

        #endregion Public Instance Properties

        #region Constructor
        public Matrix2x2(float value)
        {
            M00 = value;
            M01 = value;

            M10 = value;
            M11 = value;
        }

        public Matrix2x2(Matrix2x2 other)
        {
            M00 = other.M00;
            M01 = other.M01;

            M10 = other.M10;
            M11 = other.M11;
        }

        public Matrix2x2(float m00, float m01,
                         float m10, float m11)
        {
            M00 = m00;
            M01 = m01;

            M10 = m10;
            M11 = m11;
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
            return string.Format("Matrix2x2: M00 = {0}, M01 = {1}," +
                                            "M10 = {3}, M11 = {4}",
                                            M00, M01, M10, M11);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Matrix2x2 other) => this == other;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Fill(float value)
        {
            M00 = value;
            M01 = value;

            M10 = value;
            M11 = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsZero()
        {
            return (M00 == 0.0f && M01 == 0.0f &&
                    M10 == 0.0f && M11 == 0.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsIdentity()
        {
            return (M00 == 1.0f && M01 == 0.0f &&
                    M10 == 0.0f && M11 == 1.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetIdentity()
        {
            M00 = 1.0f;
            M01 = 0.0f;

            M10 = 0.0f;
            M11 = 1.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 Row(int row)
        {
            switch (row)
            {
                case 0:
                    return new Vector2(M00, M01);

                case 1:
                    return new Vector2(M10, M11);

                default:
                    throw new IndexOutOfRangeException();
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

                default:
                    throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Transpose() => MathHelper.Swap(ref M01, ref M10);

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Multiply(in Vector2 left, in Matrix2x2 right, out Vector2 result)
        {
            result.X = left.X * right.M00 + left.Y * right.M10;
            result.Y = left.X * right.M01 + left.Y * right.M11;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Transpose(in Matrix2x2 matrix, out Matrix2x2 result)
        {
            result.M00 = matrix.M00;
            result.M01 = matrix.M10;

            result.M10 = matrix.M01;
            result.M11 = matrix.M11;
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
            Matrix2x2 result;
            Add(left, right, out result);
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
            Matrix2x2 result;
            Add(left, right, out result);
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
            Matrix2x2 result;
            Subtract(left, right, out result);
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
            Matrix2x2 result;
            Subtract(left, right, out result);
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
            Matrix2x2 result;
            Subtract(left, right, out result);
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
            Matrix2x2 result;
            Multiply(right, left, out result);
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
        public static Matrix2x3 operator *(in Matrix2x2 left, in Matrix2x3 right)
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
        public static Matrix2x4 operator *(in Matrix2x2 left, in Matrix2x4 right)
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
        public static Vector2 operator *(in Matrix2x2 left, in Vector2 right)
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
        public static Vector2 operator *(in Vector2 left, in Matrix2x2 right)
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
        public static Matrix2x2 operator /(in Matrix2x2 left, float right)
        {
            Matrix2x2 result;
            Divide(left, right, out result);
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
