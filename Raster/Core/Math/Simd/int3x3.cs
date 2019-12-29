using System;
using System.Runtime.CompilerServices;

#pragma warning disable 0660, 0661
namespace Raster.Core.Math.Simd
{
    [System.Serializable]
    public partial struct int3x3 : System.IEquatable<int3x3>, IFormattable
    {
        public int3 c0;
        public int3 c1;
        public int3 c2;

        /// <summary>
        /// int3x3 identity transform.
        /// </summary>
        public static readonly int3x3 identity = new int3x3(1, 0, 0,   0, 1, 0,   0, 0, 1);
        /// <summary>
        /// int3x3 zero value.
        /// </summary>
        public static readonly int3x3 zero;

        /// <summary>
        /// Constructs a int3x3 matrix from three int3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x3(int3 c0, int3 c1, int3 c2)
        { 
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }
        /// <summary>
        /// Constructs a int3x3 matrix from 9 int values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x3(int m00, int m01, int m02,
                      int m10, int m11, int m12,
                      int m20, int m21, int m22)
        { 
            this.c0 = new int3(m00, m10, m20);
            this.c1 = new int3(m01, m11, m21);
            this.c2 = new int3(m02, m12, m22);
        }
        /// <summary>
        /// Constructs a int3x3 matrix from a single int value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x3(int v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }
        /// <summary>
        /// Constructs a int3x3 matrix from a single bool value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x3(bool v)
        {
            this.c0 = math.select(new int3(0), new int3(1), v);
            this.c1 = math.select(new int3(0), new int3(1), v);
            this.c2 = math.select(new int3(0), new int3(1), v);
        }
        /// <summary>
        /// Constructs a int3x3 matrix from a bool3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x3(bool3x3 v)
        {
            this.c0 = math.select(new int3(0), new int3(1), v.c0);
            this.c1 = math.select(new int3(0), new int3(1), v.c1);
            this.c2 = math.select(new int3(0), new int3(1), v.c2);
        }
        /// <summary>
        /// Constructs a int3x3 matrix from a single uint value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x3(uint v)
        {
            this.c0 = (int3)v;
            this.c1 = (int3)v;
            this.c2 = (int3)v;
        }
        /// <summary>
        /// Constructs a int3x3 matrix from a uint3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x3(uint3x3 v)
        {
            this.c0 = (int3)v.c0;
            this.c1 = (int3)v.c1;
            this.c2 = (int3)v.c2;
        }
        /// <summary>
        /// Constructs a int3x3 matrix from a single float value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x3(float v)
        {
            this.c0 = (int3)v;
            this.c1 = (int3)v;
            this.c2 = (int3)v;
        }
        /// <summary>
        /// Constructs a int3x3 matrix from a float3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x3(float3x3 v)
        {
            this.c0 = (int3)v.c0;
            this.c1 = (int3)v.c1;
            this.c2 = (int3)v.c2;
        }
        /// <summary>
        /// Constructs a int3x3 matrix from a single double value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x3(double v)
        {
            this.c0 = (int3)v;
            this.c1 = (int3)v;
            this.c2 = (int3)v;
        }
        /// <summary>
        /// Constructs a int3x3 matrix from a double3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x3(double3x3 v)
        {
            this.c0 = (int3)v.c0;
            this.c1 = (int3)v.c1;
            this.c2 = (int3)v.c2;
        }

        /// <summary>
        /// Implicitly converts a single int value to a int3x3 matrix by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3x3(int v) { return new int3x3(v); }
        /// <summary>
        /// Explicitly converts a single bool value to a int3x3 matrix by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x3(bool v) { return new int3x3(v); }
        /// <summary>
        /// Explicitly converts a bool3x3 matrix to a int3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x3(bool3x3 v) { return new int3x3(v); }
        /// <summary>
        /// Explicitly converts a single uint value to a int3x3 matrix by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x3(uint v) { return new int3x3(v); }
        /// <summary>
        /// Explicitly converts a uint3x3 matrix to a int3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x3(uint3x3 v) { return new int3x3(v); }
        /// <summary>
        /// Explicitly converts a single float value to a int3x3 matrix by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x3(float v) { return new int3x3(v); }
        /// <summary>
        /// Explicitly converts a float3x3 matrix to a int3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x3(float3x3 v) { return new int3x3(v); }
        /// <summary>
        /// Explicitly converts a single double value to a int3x3 matrix by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x3(double v) { return new int3x3(v); }
        /// <summary>
        /// Explicitly converts a double3x3 matrix to a int3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x3(double3x3 v) { return new int3x3(v); }

        /// <summary>
        /// Returns the result of a componentwise multiplication operation on two int3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator * (int3x3 lhs, int3x3 rhs) { return new int3x3 (lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise multiplication operation on an int3x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator * (int3x3 lhs, int rhs) { return new int3x3 (lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs); }
        /// <summary>
        /// Returns the result of a componentwise multiplication operation on an int value and an int3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator * (int lhs, int3x3 rhs) { return new int3x3 (lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise addition operation on two int3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator + (int3x3 lhs, int3x3 rhs) { return new int3x3 (lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise addition operation on an int3x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator + (int3x3 lhs, int rhs) { return new int3x3 (lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs); }
        /// <summary>
        /// Returns the result of a componentwise addition operation on an int value and an int3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator + (int lhs, int3x3 rhs) { return new int3x3 (lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise subtraction operation on two int3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator - (int3x3 lhs, int3x3 rhs) { return new int3x3 (lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise subtraction operation on an int3x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator - (int3x3 lhs, int rhs) { return new int3x3 (lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs); }
        /// <summary>
        /// Returns the result of a componentwise subtraction operation on an int value and an int3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator - (int lhs, int3x3 rhs) { return new int3x3 (lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise division operation on two int3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator / (int3x3 lhs, int3x3 rhs) { return new int3x3 (lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise division operation on an int3x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator / (int3x3 lhs, int rhs) { return new int3x3 (lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs); }
        /// <summary>
        /// Returns the result of a componentwise division operation on an int value and an int3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator / (int lhs, int3x3 rhs) { return new int3x3 (lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise modulus operation on two int3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator % (int3x3 lhs, int3x3 rhs) { return new int3x3 (lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise modulus operation on an int3x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator % (int3x3 lhs, int rhs) { return new int3x3 (lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs); }
        /// <summary>
        /// Returns the result of a componentwise modulus operation on an int value and an int3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator % (int lhs, int3x3 rhs) { return new int3x3 (lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise increment operation on an int3x3 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator ++ (int3x3 val) { return new int3x3 (++val.c0, ++val.c1, ++val.c2); }

        /// <summary>
        /// Returns the result of a componentwise decrement operation on an int3x3 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator -- (int3x3 val) { return new int3x3 (--val.c0, --val.c1, --val.c2); }

        /// <summary>
        /// Returns the result of a componentwise less than operation on two int3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator < (int3x3 lhs, int3x3 rhs) { return new bool3x3 (lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise less than operation on an int3x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator < (int3x3 lhs, int rhs) { return new bool3x3 (lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs); }
        /// <summary>
        /// Returns the result of a componentwise less than operation on an int value and an int3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator < (int lhs, int3x3 rhs) { return new bool3x3 (lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise less or equal operation on two int3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator <= (int3x3 lhs, int3x3 rhs) { return new bool3x3 (lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise less or equal operation on an int3x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator <= (int3x3 lhs, int rhs) { return new bool3x3 (lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs); }
        /// <summary>
        /// Returns the result of a componentwise less or equal operation on an int value and an int3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator <= (int lhs, int3x3 rhs) { return new bool3x3 (lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise greater than operation on two int3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator > (int3x3 lhs, int3x3 rhs) { return new bool3x3 (lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise greater than operation on an int3x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator > (int3x3 lhs, int rhs) { return new bool3x3 (lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs); }
        /// <summary>
        /// Returns the result of a componentwise greater than operation on an int value and an int3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator > (int lhs, int3x3 rhs) { return new bool3x3 (lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on two int3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator >= (int3x3 lhs, int3x3 rhs) { return new bool3x3 (lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on an int3x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator >= (int3x3 lhs, int rhs) { return new bool3x3 (lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs); }
        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on an int value and an int3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator >= (int lhs, int3x3 rhs) { return new bool3x3 (lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise unary minus operation on an int3x3 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator - (int3x3 val) { return new int3x3 (-val.c0, -val.c1, -val.c2); }

        /// <summary>
        /// Returns the result of a componentwise unary plus operation on an int3x3 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator + (int3x3 val) { return new int3x3 (+val.c0, +val.c1, +val.c2); }

        /// <summary>Returns the result of a componentwise left shift operation on an int3x3 matrix by a number of bits specified by a single int.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator << (int3x3 x, int n) { return new int3x3 (x.c0 << n, x.c1 << n, x.c2 << n); }
        /// <summary>Returns the result of a componentwise right shift operation on an int3x3 matrix by a number of bits specified by a single int.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator >> (int3x3 x, int n) { return new int3x3 (x.c0 >> n, x.c1 >> n, x.c2 >> n); }
        /// <summary>
        /// Returns the result of a componentwise equality operation on two int3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator == (int3x3 lhs, int3x3 rhs) { return new bool3x3 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise equality operation on an int3x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator == (int3x3 lhs, int rhs) { return new bool3x3 (lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs); }
        /// <summary>
        /// Returns the result of a componentwise equality operation on an int value and an int3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator == (int lhs, int3x3 rhs) { return new bool3x3 (lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on two int3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator != (int3x3 lhs, int3x3 rhs) { return new bool3x3 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise not equal operation on an int3x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator != (int3x3 lhs, int rhs) { return new bool3x3 (lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs); }
        /// <summary>
        /// Returns the result of a componentwise not equal operation on an int value and an int3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator != (int lhs, int3x3 rhs) { return new bool3x3 (lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise bitwise not operation on an int3x3 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator ~ (int3x3 val) { return new int3x3 (~val.c0, ~val.c1, ~val.c2); }

        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on two int3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator & (int3x3 lhs, int3x3 rhs) { return new int3x3 (lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on an int3x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator & (int3x3 lhs, int rhs) { return new int3x3 (lhs.c0 & rhs, lhs.c1 & rhs, lhs.c2 & rhs); }
        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on an int value and an int3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator & (int lhs, int3x3 rhs) { return new int3x3 (lhs & rhs.c0, lhs & rhs.c1, lhs & rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on two int3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator | (int3x3 lhs, int3x3 rhs) { return new int3x3 (lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on an int3x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator | (int3x3 lhs, int rhs) { return new int3x3 (lhs.c0 | rhs, lhs.c1 | rhs, lhs.c2 | rhs); }
        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on an int value and an int3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator | (int lhs, int3x3 rhs) { return new int3x3 (lhs | rhs.c0, lhs | rhs.c1, lhs | rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on two int3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator ^ (int3x3 lhs, int3x3 rhs) { return new int3x3 (lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on an int3x3 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator ^ (int3x3 lhs, int rhs) { return new int3x3 (lhs.c0 ^ rhs, lhs.c1 ^ rhs, lhs.c2 ^ rhs); }
        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on an int value and an int3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 operator ^ (int lhs, int3x3 rhs) { return new int3x3 (lhs ^ rhs.c0, lhs ^ rhs.c1, lhs ^ rhs.c2); }


        /// <summary>
        /// Returns the int3 element at a specified index.
        /// </summary>
        unsafe public ref int3 this[int index]
        {
            get
            {
#if ENABLE_RASTER_COLLECTIONS_CHECKS
                if ((uint)index >= 3)
                    throw new System.ArgumentException("index must be between[0...2]");
#endif
                fixed (int3x3* array = &this) { return ref ((int3*)array)[index]; }
            }
        }

        /// <summary>
        /// Returns true if the int3x3 is equal to a given int3x3, false otherwise.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(int3x3 rhs) { return c0.Equals(rhs.c0) && c1.Equals(rhs.c1) && c2.Equals(rhs.c2); }
        /// <summary>
        /// Returns true if the int3x3 is equal to a given int3x3, false otherwise.
        /// </summary>
        public override bool Equals(object o) { return Equals((int3x3)o); }

        /// <summary>
        /// Returns a hash code for the int3x3.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() { return (int)math.hash(this); }

        /// <summary>
        /// Returns a string representation of the int3x3.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("int3x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8})", c0.x, c1.x, c2.x, c0.y, c1.y, c2.y, c0.z, c1.z, c2.z);
        }
        /// <summary>
        /// Returns a string representation of the int3x3 using a specified format and culture-specific format information.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("int3x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8})", c0.x.ToString(format, formatProvider), c1.x.ToString(format, formatProvider), c2.x.ToString(format, formatProvider), c0.y.ToString(format, formatProvider), c1.y.ToString(format, formatProvider), c2.y.ToString(format, formatProvider), c0.z.ToString(format, formatProvider), c1.z.ToString(format, formatProvider), c2.z.ToString(format, formatProvider));
        }
    }
    public static partial class math
    {
        /// <summary>
        /// Returns a int3x3 matrix constructed from three int3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 int3x3(int3 c0, int3 c1, int3 c2) { return new int3x3(c0, c1, c2); }
        /// <summary>
        /// Returns a int3x3 matrix constructed from from 9 int values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 int3x3(int m00, int m01, int m02,
                                    int m10, int m11, int m12,
                                    int m20, int m21, int m22)
        {
            return new int3x3(m00, m01, m02,
                              m10, m11, m12,
                              m20, m21, m22);
        }
        /// <summary>
        /// Returns a int3x3 matrix constructed from a single int value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 int3x3(int v) { return new int3x3(v); }
        /// <summary>
        /// Returns a int3x3 matrix constructed from a single bool value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 int3x3(bool v) { return new int3x3(v); }
        /// <summary>
        /// Return a int3x3 matrix constructed from a bool3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 int3x3(bool3x3 v) { return new int3x3(v); }
        /// <summary>
        /// Returns a int3x3 matrix constructed from a single uint value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 int3x3(uint v) { return new int3x3(v); }
        /// <summary>
        /// Return a int3x3 matrix constructed from a uint3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 int3x3(uint3x3 v) { return new int3x3(v); }
        /// <summary>
        /// Returns a int3x3 matrix constructed from a single float value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 int3x3(float v) { return new int3x3(v); }
        /// <summary>
        /// Return a int3x3 matrix constructed from a float3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 int3x3(float3x3 v) { return new int3x3(v); }
        /// <summary>
        /// Returns a int3x3 matrix constructed from a single double value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 int3x3(double v) { return new int3x3(v); }
        /// <summary>
        /// Return a int3x3 matrix constructed from a double3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 int3x3(double3x3 v) { return new int3x3(v); }
        /// <summary>
        /// Return the int3x3 transpose of a int3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x3 transpose(int3x3 v)
        {
            return int3x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z,
                v.c2.x, v.c2.y, v.c2.z);
        }
        /// <summary>\n\t\t/// Returns the determinant of a int3x3 matrix.\n\t\t/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int determinant(int3x3 m)
        {
            int3 c0 = m.c0;
            int3 c1 = m.c1;
            int3 c2 = m.c2;

            int m00 = c1.y * c2.z - c1.z * c2.y;
            int m01 = c0.y * c2.z - c0.z * c2.y;
            int m02 = c0.y * c1.z - c0.z * c1.y;

            return c0.x * m00 - c1.x * m01 + c2.x * m02;
        }

        /// <summary>Returns a uint hash code of a int3x3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(int3x3 v)
        {
            return csum(asuint(v.c0) * uint3(0x93C30C2Bu, 0xDCAF0351u, 0x6E050B01u) + 
                        asuint(v.c1) * uint3(0x750FDBF5u, 0x7F3DD499u, 0x52EAAEBBu) + 
                        asuint(v.c2) * uint3(0x4599C793u, 0x83B5E729u, 0xC267163Fu)) + 0x67BC9149u;
        }
        /// <summary>
        /// Returns a uint3 vector hash code of a int3x3 vector.
        /// When multiple elements are to be hashes together, it can more efficient to calculate and combine wide hash
        /// that are only reduced to a narrow uint hash at the very end instead of at every step.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(int3x3 v)
        {
            return (asuint(v.c0) * uint3(0xAD7C5EC1u, 0x822A7D6Du, 0xB492BF15u) + 
                    asuint(v.c1) * uint3(0xD37220E3u, 0x7AA2C2BDu, 0xE16BC89Du) + 
                    asuint(v.c2) * uint3(0x7AA07CD3u, 0xAF642BA9u, 0xA8F2213Bu)) + 0x9F3FDC37u;
        }
    }
}
