using System;
using System.Runtime.CompilerServices;

#pragma warning disable 0660, 0661
namespace Raster.Core.Math.Simd
{
    [System.Serializable]
    public partial struct int4x3 : System.IEquatable<int4x3>, IFormattable
    {
        public int4 c0;
        public int4 c1;
        public int4 c2;

        /// <summary>
        /// int4x3 zero value.
        /// </summary>
        public static readonly int4x3 zero;

        /// <summary>
        /// Constructs a int4x3 matrix from three int4 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(int4 c0, int4 c1, int4 c2)
        { 
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }
        /// <summary>
        /// Constructs a int4x3 matrix from 12 int values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(int m00, int m01, int m02,
                      int m10, int m11, int m12,
                      int m20, int m21, int m22,
                      int m30, int m31, int m32)
        { 
            this.c0 = new int4(m00, m10, m20, m30);
            this.c1 = new int4(m01, m11, m21, m31);
            this.c2 = new int4(m02, m12, m22, m32);
        }
        /// <summary>
        /// Constructs a int4x3 matrix from a single int value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(int v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }
        /// <summary>
        /// Constructs a int4x3 matrix from a single bool value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(bool v)
        {
            this.c0 = math.select(new int4(0), new int4(1), v);
            this.c1 = math.select(new int4(0), new int4(1), v);
            this.c2 = math.select(new int4(0), new int4(1), v);
        }
        /// <summary>
        /// Constructs a int4x3 matrix from a bool4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(bool4x3 v)
        {
            this.c0 = math.select(new int4(0), new int4(1), v.c0);
            this.c1 = math.select(new int4(0), new int4(1), v.c1);
            this.c2 = math.select(new int4(0), new int4(1), v.c2);
        }
        /// <summary>
        /// Constructs a int4x3 matrix from a single uint value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(uint v)
        {
            this.c0 = (int4)v;
            this.c1 = (int4)v;
            this.c2 = (int4)v;
        }
        /// <summary>
        /// Constructs a int4x3 matrix from a uint4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(uint4x3 v)
        {
            this.c0 = (int4)v.c0;
            this.c1 = (int4)v.c1;
            this.c2 = (int4)v.c2;
        }
        /// <summary>
        /// Constructs a int4x3 matrix from a single float value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(float v)
        {
            this.c0 = (int4)v;
            this.c1 = (int4)v;
            this.c2 = (int4)v;
        }
        /// <summary>
        /// Constructs a int4x3 matrix from a float4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(float4x3 v)
        {
            this.c0 = (int4)v.c0;
            this.c1 = (int4)v.c1;
            this.c2 = (int4)v.c2;
        }
        /// <summary>
        /// Constructs a int4x3 matrix from a single double value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(double v)
        {
            this.c0 = (int4)v;
            this.c1 = (int4)v;
            this.c2 = (int4)v;
        }
        /// <summary>
        /// Constructs a int4x3 matrix from a double4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(double4x3 v)
        {
            this.c0 = (int4)v.c0;
            this.c1 = (int4)v.c1;
            this.c2 = (int4)v.c2;
        }

        /// <summary>
        /// Implicitly converts a single int value to a int4x3 matrix by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4x3(int v) { return new int4x3(v); }
        /// <summary>
        /// Explicitly converts a single bool value to a int4x3 matrix by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(bool v) { return new int4x3(v); }
        /// <summary>
        /// Explicitly converts a bool4x3 matrix to a int4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(bool4x3 v) { return new int4x3(v); }
        /// <summary>
        /// Explicitly converts a single uint value to a int4x3 matrix by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(uint v) { return new int4x3(v); }
        /// <summary>
        /// Explicitly converts a uint4x3 matrix to a int4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(uint4x3 v) { return new int4x3(v); }
        /// <summary>
        /// Explicitly converts a single float value to a int4x3 matrix by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(float v) { return new int4x3(v); }
        /// <summary>
        /// Explicitly converts a float4x3 matrix to a int4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(float4x3 v) { return new int4x3(v); }
        /// <summary>
        /// Explicitly converts a single double value to a int4x3 matrix by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(double v) { return new int4x3(v); }
        /// <summary>
        /// Explicitly converts a double4x3 matrix to a int4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(double4x3 v) { return new int4x3(v); }

        /// <summary>
        /// Returns the result of a componentwise multiplication operation on two int4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (int4x3 lhs, int4x3 rhs) { return new int4x3 (lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise multiplication operation on an int4x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (int4x3 lhs, int rhs) { return new int4x3 (lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs); }
        /// <summary>
        /// Returns the result of a componentwise multiplication operation on an int value and an int4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (int lhs, int4x3 rhs) { return new int4x3 (lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise addition operation on two int4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (int4x3 lhs, int4x3 rhs) { return new int4x3 (lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise addition operation on an int4x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (int4x3 lhs, int rhs) { return new int4x3 (lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs); }
        /// <summary>
        /// Returns the result of a componentwise addition operation on an int value and an int4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (int lhs, int4x3 rhs) { return new int4x3 (lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise subtraction operation on two int4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (int4x3 lhs, int4x3 rhs) { return new int4x3 (lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise subtraction operation on an int4x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (int4x3 lhs, int rhs) { return new int4x3 (lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs); }
        /// <summary>
        /// Returns the result of a componentwise subtraction operation on an int value and an int4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (int lhs, int4x3 rhs) { return new int4x3 (lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise division operation on two int4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (int4x3 lhs, int4x3 rhs) { return new int4x3 (lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise division operation on an int4x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (int4x3 lhs, int rhs) { return new int4x3 (lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs); }
        /// <summary>
        /// Returns the result of a componentwise division operation on an int value and an int4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (int lhs, int4x3 rhs) { return new int4x3 (lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise modulus operation on two int4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (int4x3 lhs, int4x3 rhs) { return new int4x3 (lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise modulus operation on an int4x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (int4x3 lhs, int rhs) { return new int4x3 (lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs); }
        /// <summary>
        /// Returns the result of a componentwise modulus operation on an int value and an int4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (int lhs, int4x3 rhs) { return new int4x3 (lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise increment operation on an int4x3 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ++ (int4x3 val) { return new int4x3 (++val.c0, ++val.c1, ++val.c2); }

        /// <summary>
        /// Returns the result of a componentwise decrement operation on an int4x3 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator -- (int4x3 val) { return new int4x3 (--val.c0, --val.c1, --val.c2); }

        /// <summary>
        /// Returns the result of a componentwise less than operation on two int4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator < (int4x3 lhs, int4x3 rhs) { return new bool4x3 (lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise less than operation on an int4x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator < (int4x3 lhs, int rhs) { return new bool4x3 (lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs); }
        /// <summary>
        /// Returns the result of a componentwise less than operation on an int value and an int4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator < (int lhs, int4x3 rhs) { return new bool4x3 (lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise less or equal operation on two int4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator <= (int4x3 lhs, int4x3 rhs) { return new bool4x3 (lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise less or equal operation on an int4x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator <= (int4x3 lhs, int rhs) { return new bool4x3 (lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs); }
        /// <summary>
        /// Returns the result of a componentwise less or equal operation on an int value and an int4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator <= (int lhs, int4x3 rhs) { return new bool4x3 (lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise greater than operation on two int4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator > (int4x3 lhs, int4x3 rhs) { return new bool4x3 (lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise greater than operation on an int4x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator > (int4x3 lhs, int rhs) { return new bool4x3 (lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs); }
        /// <summary>
        /// Returns the result of a componentwise greater than operation on an int value and an int4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator > (int lhs, int4x3 rhs) { return new bool4x3 (lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on two int4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator >= (int4x3 lhs, int4x3 rhs) { return new bool4x3 (lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on an int4x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator >= (int4x3 lhs, int rhs) { return new bool4x3 (lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs); }
        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on an int value and an int4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator >= (int lhs, int4x3 rhs) { return new bool4x3 (lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise unary minus operation on an int4x3 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (int4x3 val) { return new int4x3 (-val.c0, -val.c1, -val.c2); }

        /// <summary>
        /// Returns the result of a componentwise unary plus operation on an int4x3 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (int4x3 val) { return new int4x3 (+val.c0, +val.c1, +val.c2); }

        /// <summary>Returns the result of a componentwise left shift operation on an int4x3 matrix by a number of bits specified by a single int.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator << (int4x3 x, int n) { return new int4x3 (x.c0 << n, x.c1 << n, x.c2 << n); }
        /// <summary>Returns the result of a componentwise right shift operation on an int4x3 matrix by a number of bits specified by a single int.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator >> (int4x3 x, int n) { return new int4x3 (x.c0 >> n, x.c1 >> n, x.c2 >> n); }
        /// <summary>
        /// Returns the result of a componentwise equality operation on two int4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator == (int4x3 lhs, int4x3 rhs) { return new bool4x3 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise equality operation on an int4x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator == (int4x3 lhs, int rhs) { return new bool4x3 (lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs); }
        /// <summary>
        /// Returns the result of a componentwise equality operation on an int value and an int4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator == (int lhs, int4x3 rhs) { return new bool4x3 (lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on two int4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator != (int4x3 lhs, int4x3 rhs) { return new bool4x3 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise not equal operation on an int4x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator != (int4x3 lhs, int rhs) { return new bool4x3 (lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs); }
        /// <summary>
        /// Returns the result of a componentwise not equal operation on an int value and an int4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator != (int lhs, int4x3 rhs) { return new bool4x3 (lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise bitwise not operation on an int4x3 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ~ (int4x3 val) { return new int4x3 (~val.c0, ~val.c1, ~val.c2); }

        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on two int4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (int4x3 lhs, int4x3 rhs) { return new int4x3 (lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on an int4x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (int4x3 lhs, int rhs) { return new int4x3 (lhs.c0 & rhs, lhs.c1 & rhs, lhs.c2 & rhs); }
        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on an int value and an int4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (int lhs, int4x3 rhs) { return new int4x3 (lhs & rhs.c0, lhs & rhs.c1, lhs & rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on two int4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (int4x3 lhs, int4x3 rhs) { return new int4x3 (lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on an int4x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (int4x3 lhs, int rhs) { return new int4x3 (lhs.c0 | rhs, lhs.c1 | rhs, lhs.c2 | rhs); }
        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on an int value and an int4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (int lhs, int4x3 rhs) { return new int4x3 (lhs | rhs.c0, lhs | rhs.c1, lhs | rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on two int4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (int4x3 lhs, int4x3 rhs) { return new int4x3 (lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on an int4x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (int4x3 lhs, int rhs) { return new int4x3 (lhs.c0 ^ rhs, lhs.c1 ^ rhs, lhs.c2 ^ rhs); }
        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on an int value and an int4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (int lhs, int4x3 rhs) { return new int4x3 (lhs ^ rhs.c0, lhs ^ rhs.c1, lhs ^ rhs.c2); }


        /// <summary>
        /// Returns the int4 element at a specified index.
        /// </summary>
        unsafe public ref int4 this[int index]
        {
            get
            {
#if ENABLE_RASTER_COLLECTIONS_CHECKS
                if ((uint)index >= 3)
                    throw new System.ArgumentException("index must be between[0...2]");
#endif
                fixed (int4x3* array = &this) { return ref ((int4*)array)[index]; }
            }
        }

        /// <summary>
        /// Returns true if the int4x3 is equal to a given int4x3, false otherwise.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(int4x3 rhs) { return c0.Equals(rhs.c0) && c1.Equals(rhs.c1) && c2.Equals(rhs.c2); }
        /// <summary>
        /// Returns true if the int4x3 is equal to a given int4x3, false otherwise.
        /// </summary>
        public override bool Equals(object o) { return Equals((int4x3)o); }

        /// <summary>
        /// Returns a hash code for the int4x3.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() { return (int)math.hash(this); }

        /// <summary>
        /// Returns a string representation of the int4x3.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("int4x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8},  {9}, {10}, {11})", c0.x, c1.x, c2.x, c0.y, c1.y, c2.y, c0.z, c1.z, c2.z, c0.w, c1.w, c2.w);
        }
        /// <summary>
        /// Returns a string representation of the int4x3 using a specified format and culture-specific format information.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("int4x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8},  {9}, {10}, {11})", c0.x.ToString(format, formatProvider), c1.x.ToString(format, formatProvider), c2.x.ToString(format, formatProvider), c0.y.ToString(format, formatProvider), c1.y.ToString(format, formatProvider), c2.y.ToString(format, formatProvider), c0.z.ToString(format, formatProvider), c1.z.ToString(format, formatProvider), c2.z.ToString(format, formatProvider), c0.w.ToString(format, formatProvider), c1.w.ToString(format, formatProvider), c2.w.ToString(format, formatProvider));
        }
    }
    public static partial class math
    {
        /// <summary>
        /// Returns a int4x3 matrix constructed from three int4 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 int4x3(int4 c0, int4 c1, int4 c2) { return new int4x3(c0, c1, c2); }
        /// <summary>
        /// Returns a int4x3 matrix constructed from from 12 int values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 int4x3(int m00, int m01, int m02,
                                    int m10, int m11, int m12,
                                    int m20, int m21, int m22,
                                    int m30, int m31, int m32)
        {
            return new int4x3(m00, m01, m02,
                              m10, m11, m12,
                              m20, m21, m22,
                              m30, m31, m32);
        }
        /// <summary>
        /// Returns a int4x3 matrix constructed from a single int value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 int4x3(int v) { return new int4x3(v); }
        /// <summary>
        /// Returns a int4x3 matrix constructed from a single bool value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 int4x3(bool v) { return new int4x3(v); }
        /// <summary>
        /// Return a int4x3 matrix constructed from a bool4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 int4x3(bool4x3 v) { return new int4x3(v); }
        /// <summary>
        /// Returns a int4x3 matrix constructed from a single uint value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 int4x3(uint v) { return new int4x3(v); }
        /// <summary>
        /// Return a int4x3 matrix constructed from a uint4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 int4x3(uint4x3 v) { return new int4x3(v); }
        /// <summary>
        /// Returns a int4x3 matrix constructed from a single float value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 int4x3(float v) { return new int4x3(v); }
        /// <summary>
        /// Return a int4x3 matrix constructed from a float4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 int4x3(float4x3 v) { return new int4x3(v); }
        /// <summary>
        /// Returns a int4x3 matrix constructed from a single double value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 int4x3(double v) { return new int4x3(v); }
        /// <summary>
        /// Return a int4x3 matrix constructed from a double4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 int4x3(double4x3 v) { return new int4x3(v); }
        /// <summary>
        /// Return the int3x4 transpose of a int4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 transpose(int4x3 v)
        {
            return int3x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                v.c2.x, v.c2.y, v.c2.z, v.c2.w);
        }
        /// <summary>Returns a uint hash code of a int4x3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(int4x3 v)
        {
            return csum(asuint(v.c0) * uint4(0x69B60C81u, 0xE0EB6C25u, 0xF648BEABu, 0x6BDB2B07u) + 
                        asuint(v.c1) * uint4(0xEF63C699u, 0x9001903Fu, 0xA895B9CDu, 0x9D23B201u) + 
                        asuint(v.c2) * uint4(0x4B01D3E1u, 0x7461CA0Du, 0x79725379u, 0xD6258E5Bu)) + 0xEE390C97u;
        }
        /// <summary>
        /// Returns a uint4 vector hash code of a int4x3 vector.
        /// When multiple elements are to be hashes together, it can more efficient to calculate and combine wide hash
        /// that are only reduced to a narrow uint hash at the very end instead of at every step.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(int4x3 v)
        {
            return (asuint(v.c0) * uint4(0x9C8A2F05u, 0x4DDC6509u, 0x7CF083CBu, 0x5C4D6CEDu) + 
                    asuint(v.c1) * uint4(0xF9137117u, 0xE857DCE1u, 0xF62213C5u, 0x9CDAA959u) + 
                    asuint(v.c2) * uint4(0xAA269ABFu, 0xD54BA36Fu, 0xFD0847B9u, 0x8189A683u)) + 0xB139D651u;
        }
    }
}
