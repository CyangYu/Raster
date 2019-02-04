﻿using System;
using System.Runtime.CompilerServices;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
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
        public float[] RawData
        {
            get
            {
                return new float[3 * 2]
                {
                    M00, M01,
                    M10, M11,
                    M20, M21
                };
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
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Matrix3x2: M00 = {0}, M01 = {1}, " +
                                            "M10 = {2}, M11 = {3}, " +
                                            "M20 = {4}, M21 = {5}  ",
                                            M00, M01, M10, M11, M20, M21);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Matrix3x2 other) => this == other;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsZero()
        {
            return (M00 == 0.0f && M01 == 0.0f &&
                    M10 == 0.0f && M11 == 0.0f &&
                    M20 == 0.0f && M21 == 0.0f);
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

                case 2:
                    return new Vector2(M20, M21);

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
        public Vector3 Column(int column)
        {
            switch (column)
            {
                case 0:
                    return new Vector3(M00, M10, M20);

                case 1:
                    return new Vector3(M01, M11, M21);

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2 operator +(in Matrix3x2 left, in Matrix3x2 right)
        {
            Matrix3x2 result = new Matrix3x2(0.0f);
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
        public static Matrix3x2 operator +(in Matrix3x2 left, float right)
        {
            Matrix3x2 result = new Matrix3x2(0.0f);
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
        public static Matrix3x2 operator -(in Matrix3x2 left, float right)
        {
            Matrix3x2 result = new Matrix3x2(0.0f);
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
        public static Matrix3x2 operator -(in Matrix3x2 left, in Matrix3x2 right)
        {
            Matrix3x2 result = new Matrix3x2(0.0f);
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
        public static Matrix3x2 operator *(in Matrix3x2 left, float right)
        {
            Matrix3x2 result = new Matrix3x2(0.0f);
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
        public static Matrix3x2 operator *(float left, in Matrix3x2 right)
        {
            Matrix3x2 result = new Matrix3x2(0.0f);
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
        public static Matrix3x2 operator *(in Matrix3x2 left, in Matrix2x2 right)
        {
            Matrix3x2 result = new Matrix3x2(0.0f);
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
        public static Matrix3x3 operator *(in Matrix3x2 left, in Matrix2x3 right)
        {
            Matrix3x3 result = new Matrix3x3(0.0f);
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
        public static Matrix3x4 operator *(in Matrix3x2 left, in Matrix2x4 right)
        {
            Matrix3x4 result = new Matrix3x4(0.0f);
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
        public static Vector3 operator *(in Matrix3x2 left, in Vector2 right)
        {
            Vector3 result = new Vector3(0.0f);
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
        public static Vector2 operator *(in Vector3 left, in Matrix3x2 right)
        {
            Vector2 result = new Vector2(0.0f);
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
        public static Matrix3x2 operator /(in Matrix3x2 left, float right)
        {
            Matrix3x2 result = new Matrix3x2();
            Divide(left, right, out result);
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
