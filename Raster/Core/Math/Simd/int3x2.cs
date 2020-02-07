using System;
using System.Runtime.CompilerServices;

#pragma warning disable 0660, 0661
namespace Raster.Core.Math.Simd
{
    [System.Serializable]
    public partial struct int3x2 : System.IEquatable<int3x2>, IFormattable
    {
        public int3 c0;
        public int3 c1;

        /// <summary>
        /// int3x2 zero value.
        /// </summary>
        public static readonly int3x2 zero;

        /// <summary>
        /// Constructs a int3x2 matrix from two int3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(int3 c0, int3 c1)
        { 
            this.c0 = c0;
            this.c1 = c1;
        }

        /// <summary>
        /// Constructs a int3x2 matrix from 6 int values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(int m00, int m01,
                      int m10, int m11,
                      int m20, int m21)
        { 
            this.c0 = new int3(m00, m10, m20);
            this.c1 = new int3(m01, m11, m21);
        }

        /// <summary>
        /// Constructs a int3x2 matrix from a single int value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(int v)
        {
            this.c0 = v;
            this.c1 = v;
        }

        /// <summary>
        /// Constructs a int3x2 matrix from a single bool value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(bool v)
        {
            this.c0 = math.select(new int3(0), new int3(1), v);
            this.c1 = math.select(new int3(0), new int3(1), v);
        }

        /// <summary>
        /// Constructs a int3x2 matrix from a bool3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(bool3x2 v)
        {
            this.c0 = math.select(new int3(0), new int3(1), v.c0);
            this.c1 = math.select(new int3(0), new int3(1), v.c1);
        }

        /// <summary>
        /// Constructs a int3x2 matrix from a single uint value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(uint v)
        {
            this.c0 = (int3)v;
            this.c1 = (int3)v;
        }

        /// <summary>
        /// Constructs a int3x2 matrix from a uint3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(uint3x2 v)
        {
            this.c0 = (int3)v.c0;
            this.c1 = (int3)v.c1;
        }

        /// <summary>
        /// Constructs a int3x2 matrix from a single float value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(float v)
        {
            this.c0 = (int3)v;
            this.c1 = (int3)v;
        }

        /// <summary>
        /// Constructs a int3x2 matrix from a float3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(float3x2 v)
        {
            this.c0 = (int3)v.c0;
            this.c1 = (int3)v.c1;
        }

        /// <summary>
        /// Constructs a int3x2 matrix from a single double value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(double v)
        {
            this.c0 = (int3)v;
            this.c1 = (int3)v;
        }

        /// <summary>
        /// Constructs a int3x2 matrix from a double3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(double3x2 v)
        {
            this.c0 = (int3)v.c0;
            this.c1 = (int3)v.c1;
        }

        /// <summary>
        /// Implicitly converts a single int value to a int3x2 matrix by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3x2(int v) { return new int3x2(v); }

        /// <summary>
        /// Explicitly converts a single bool value to a int3x2 matrix by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(bool v) { return new int3x2(v); }

        /// <summary>
        /// Explicitly converts a bool3x2 matrix to a int3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(bool3x2 v) { return new int3x2(v); }

        /// <summary>
        /// Explicitly converts a single uint value to a int3x2 matrix by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(uint v) { return new int3x2(v); }

        /// <summary>
        /// Explicitly converts a uint3x2 matrix to a int3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(uint3x2 v) { return new int3x2(v); }

        /// <summary>
        /// Explicitly converts a single float value to a int3x2 matrix by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(float v) { return new int3x2(v); }

        /// <summary>
        /// Explicitly converts a float3x2 matrix to a int3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(float3x2 v) { return new int3x2(v); }

        /// <summary>
        /// Explicitly converts a single double value to a int3x2 matrix by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(double v) { return new int3x2(v); }

        /// <summary>
        /// Explicitly converts a double3x2 matrix to a int3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(double3x2 v) { return new int3x2(v); }

        /// <summary>
        /// Returns the result of a componentwise multiplication operation on two int3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (int3x2 lhs, int3x2 rhs) { return new int3x2 (lhs.c0 * rhs.c0, lhs.c1 * rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise multiplication operation on an int3x2 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (int3x2 lhs, int rhs) { return new int3x2 (lhs.c0 * rhs, lhs.c1 * rhs); }

        /// <summary>
        /// Returns the result of a componentwise multiplication operation on an int value and an int3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (int lhs, int3x2 rhs) { return new int3x2 (lhs * rhs.c0, lhs * rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise addition operation on two int3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (int3x2 lhs, int3x2 rhs) { return new int3x2 (lhs.c0 + rhs.c0, lhs.c1 + rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise addition operation on an int3x2 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (int3x2 lhs, int rhs) { return new int3x2 (lhs.c0 + rhs, lhs.c1 + rhs); }

        /// <summary>
        /// Returns the result of a componentwise addition operation on an int value and an int3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (int lhs, int3x2 rhs) { return new int3x2 (lhs + rhs.c0, lhs + rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise subtraction operation on two int3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (int3x2 lhs, int3x2 rhs) { return new int3x2 (lhs.c0 - rhs.c0, lhs.c1 - rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise subtraction operation on an int3x2 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (int3x2 lhs, int rhs) { return new int3x2 (lhs.c0 - rhs, lhs.c1 - rhs); }

        /// <summary>
        /// Returns the result of a componentwise subtraction operation on an int value and an int3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (int lhs, int3x2 rhs) { return new int3x2 (lhs - rhs.c0, lhs - rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise division operation on two int3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (int3x2 lhs, int3x2 rhs) { return new int3x2 (lhs.c0 / rhs.c0, lhs.c1 / rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise division operation on an int3x2 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (int3x2 lhs, int rhs) { return new int3x2 (lhs.c0 / rhs, lhs.c1 / rhs); }

        /// <summary>
        /// Returns the result of a componentwise division operation on an int value and an int3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (int lhs, int3x2 rhs) { return new int3x2 (lhs / rhs.c0, lhs / rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise modulus operation on two int3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (int3x2 lhs, int3x2 rhs) { return new int3x2 (lhs.c0 % rhs.c0, lhs.c1 % rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise modulus operation on an int3x2 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (int3x2 lhs, int rhs) { return new int3x2 (lhs.c0 % rhs, lhs.c1 % rhs); }

        /// <summary>
        /// Returns the result of a componentwise modulus operation on an int value and an int3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (int lhs, int3x2 rhs) { return new int3x2 (lhs % rhs.c0, lhs % rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise increment operation on an int3x2 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ++ (int3x2 val) { return new int3x2 (++val.c0, ++val.c1); }

        /// <summary>
        /// Returns the result of a componentwise decrement operation on an int3x2 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator -- (int3x2 val) { return new int3x2 (--val.c0, --val.c1); }

        /// <summary>
        /// Returns the result of a componentwise less than operation on two int3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator < (int3x2 lhs, int3x2 rhs) { return new bool3x2 (lhs.c0 < rhs.c0, lhs.c1 < rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise less than operation on an int3x2 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator < (int3x2 lhs, int rhs) { return new bool3x2 (lhs.c0 < rhs, lhs.c1 < rhs); }

        /// <summary>
        /// Returns the result of a componentwise less than operation on an int value and an int3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator < (int lhs, int3x2 rhs) { return new bool3x2 (lhs < rhs.c0, lhs < rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise less or equal operation on two int3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator <= (int3x2 lhs, int3x2 rhs) { return new bool3x2 (lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise less or equal operation on an int3x2 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator <= (int3x2 lhs, int rhs) { return new bool3x2 (lhs.c0 <= rhs, lhs.c1 <= rhs); }

        /// <summary>
        /// Returns the result of a componentwise less or equal operation on an int value and an int3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator <= (int lhs, int3x2 rhs) { return new bool3x2 (lhs <= rhs.c0, lhs <= rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise greater than operation on two int3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator > (int3x2 lhs, int3x2 rhs) { return new bool3x2 (lhs.c0 > rhs.c0, lhs.c1 > rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise greater than operation on an int3x2 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator > (int3x2 lhs, int rhs) { return new bool3x2 (lhs.c0 > rhs, lhs.c1 > rhs); }

        /// <summary>
        /// Returns the result of a componentwise greater than operation on an int value and an int3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator > (int lhs, int3x2 rhs) { return new bool3x2 (lhs > rhs.c0, lhs > rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on two int3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator >= (int3x2 lhs, int3x2 rhs) { return new bool3x2 (lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on an int3x2 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator >= (int3x2 lhs, int rhs) { return new bool3x2 (lhs.c0 >= rhs, lhs.c1 >= rhs); }

        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on an int value and an int3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator >= (int lhs, int3x2 rhs) { return new bool3x2 (lhs >= rhs.c0, lhs >= rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise unary minus operation on an int3x2 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (int3x2 val) { return new int3x2 (-val.c0, -val.c1); }

        /// <summary>
        /// Returns the result of a componentwise unary plus operation on an int3x2 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (int3x2 val) { return new int3x2 (+val.c0, +val.c1); }

        /// <summary>Returns the result of a componentwise left shift operation on an int3x2 matrix by a number of bits specified by a single int.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator << (int3x2 x, int n) { return new int3x2 (x.c0 << n, x.c1 << n); }

        /// <summary>Returns the result of a componentwise right shift operation on an int3x2 matrix by a number of bits specified by a single int.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator >> (int3x2 x, int n) { return new int3x2 (x.c0 >> n, x.c1 >> n); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on two int3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator == (int3x2 lhs, int3x2 rhs) { return new bool3x2 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on an int3x2 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator == (int3x2 lhs, int rhs) { return new bool3x2 (lhs.c0 == rhs, lhs.c1 == rhs); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on an int value and an int3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator == (int lhs, int3x2 rhs) { return new bool3x2 (lhs == rhs.c0, lhs == rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on two int3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator != (int3x2 lhs, int3x2 rhs) { return new bool3x2 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on an int3x2 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator != (int3x2 lhs, int rhs) { return new bool3x2 (lhs.c0 != rhs, lhs.c1 != rhs); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on an int value and an int3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator != (int lhs, int3x2 rhs) { return new bool3x2 (lhs != rhs.c0, lhs != rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise bitwise not operation on an int3x2 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ~ (int3x2 val) { return new int3x2 (~val.c0, ~val.c1); }

        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on two int3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (int3x2 lhs, int3x2 rhs) { return new int3x2 (lhs.c0 & rhs.c0, lhs.c1 & rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on an int3x2 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (int3x2 lhs, int rhs) { return new int3x2 (lhs.c0 & rhs, lhs.c1 & rhs); }

        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on an int value and an int3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (int lhs, int3x2 rhs) { return new int3x2 (lhs & rhs.c0, lhs & rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on two int3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (int3x2 lhs, int3x2 rhs) { return new int3x2 (lhs.c0 | rhs.c0, lhs.c1 | rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on an int3x2 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (int3x2 lhs, int rhs) { return new int3x2 (lhs.c0 | rhs, lhs.c1 | rhs); }

        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on an int value and an int3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (int lhs, int3x2 rhs) { return new int3x2 (lhs | rhs.c0, lhs | rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on two int3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (int3x2 lhs, int3x2 rhs) { return new int3x2 (lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on an int3x2 matrix and an int value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (int3x2 lhs, int rhs) { return new int3x2 (lhs.c0 ^ rhs, lhs.c1 ^ rhs); }

        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on an int value and an int3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (int lhs, int3x2 rhs) { return new int3x2 (lhs ^ rhs.c0, lhs ^ rhs.c1); }


        /// <summary>
        /// Returns the int3 element at a specified index.
        /// </summary>
        unsafe public ref int3 this[int index]
        {
            get
            {
#if ENABLE_RASTER_COLLECTIONS_CHECKS
                if ((uint)index >= 2)
                    throw new System.ArgumentException("index must be between[0...1]");
#endif
                fixed (int3x2* array = &this) { return ref ((int3*)array)[index]; }
            }
        }

        /// <summary>
        /// Returns true if the int3x2 is equal to a given int3x2, false otherwise.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(int3x2 rhs) { return c0.Equals(rhs.c0) && c1.Equals(rhs.c1); }

        /// <summary>
        /// Returns true if the int3x2 is equal to a given int3x2, false otherwise.
        /// </summary>
        public override bool Equals(object o) { return Equals((int3x2)o); }

        /// <summary>
        /// Returns a hash code for the int3x2.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() { return (int)math.hash(this); }

        /// <summary>
        /// Returns a string representation of the int3x2.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("int3x2({0}, {1},  {2}, {3},  {4}, {5})", c0.x, c1.x, c0.y, c1.y, c0.z, c1.z);
        }

        /// <summary>
        /// Returns a string representation of the int3x2 using a specified format and culture-specific format information.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("int3x2({0}, {1},  {2}, {3},  {4}, {5})", c0.x.ToString(format, formatProvider), c1.x.ToString(format, formatProvider), c0.y.ToString(format, formatProvider), c1.y.ToString(format, formatProvider), c0.z.ToString(format, formatProvider), c1.z.ToString(format, formatProvider));
        }
    }
    public static partial class math
    {
        /// <summary>
        /// Returns a int3x2 matrix constructed from two int3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 int3x2(int3 c0, int3 c1) { return new int3x2(c0, c1); }

        /// <summary>
        /// Returns a int3x2 matrix constructed from from 6 int values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 int3x2(int m00, int m01,
                                    int m10, int m11,
                                    int m20, int m21)
        {
            return new int3x2(m00, m01,
                              m10, m11,
                              m20, m21);
        }

        /// <summary>
        /// Returns a int3x2 matrix constructed from a single int value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 int3x2(int v) { return new int3x2(v); }

        /// <summary>
        /// Returns a int3x2 matrix constructed from a single bool value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 int3x2(bool v) { return new int3x2(v); }

        /// <summary>
        /// Return a int3x2 matrix constructed from a bool3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 int3x2(bool3x2 v) { return new int3x2(v); }

        /// <summary>
        /// Returns a int3x2 matrix constructed from a single uint value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 int3x2(uint v) { return new int3x2(v); }

        /// <summary>
        /// Return a int3x2 matrix constructed from a uint3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 int3x2(uint3x2 v) { return new int3x2(v); }

        /// <summary>
        /// Returns a int3x2 matrix constructed from a single float value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 int3x2(float v) { return new int3x2(v); }

        /// <summary>
        /// Return a int3x2 matrix constructed from a float3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 int3x2(float3x2 v) { return new int3x2(v); }

        /// <summary>
        /// Returns a int3x2 matrix constructed from a single double value by converting it to int and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 int3x2(double v) { return new int3x2(v); }

        /// <summary>
        /// Return a int3x2 matrix constructed from a double3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 int3x2(double3x2 v) { return new int3x2(v); }

        /// <summary>
        /// Return the int2x3 transpose of a int3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 transpose(int3x2 v)
        {
            return int2x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z);
        }

        /// <summary>Returns a uint hash code of a int3x2 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(int3x2 v)
        {
            return csum(asuint(v.c0) * uint3(0xDB3DE101u, 0x7B6D1B4Bu, 0x58399E77u) + 
                        asuint(v.c1) * uint3(0x5EAC29C9u, 0xFC6014F9u, 0x6BF6693Fu)) + 0x9D1B1D9Bu;
        }

        /// <summary>
        /// Returns a uint3 vector hash code of a int3x2 vector.
        /// When multiple elements are to be hashes together, it can more efficient to calculate and combine wide hash
        /// that are only reduced to a narrow uint hash at the very end instead of at every step.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(int3x2 v)
        {
            return (asuint(v.c0) * uint3(0xF842F5C1u, 0xA47EC335u, 0xA477DF57u) + 
                    asuint(v.c1) * uint3(0xC4B1493Fu, 0xBA0966D3u, 0xAFBEE253u)) + 0x5B419C01u;
        }
    }
}
