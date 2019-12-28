using System;
using System.Runtime.CompilerServices;

#pragma warning disable 0660, 0661

namespace Raster.Math.Simd
{
    [System.Serializable]
    public partial struct uint4x3 : System.IEquatable<uint4x3>, IFormattable
    {
        public uint4 c0;
        public uint4 c1;
        public uint4 c2;

        /// <summary>
        /// uint4x3 zero value.
        /// </summary>
        public static readonly uint4x3 zero;

        /// <summary>
        /// Constructs a uint4x3 matrix from three uint4 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x3(uint4 c0, uint4 c1, uint4 c2)
        { 
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        /// <summary>
        /// Constructs a uint4x3 matrix from 12 uint values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x3(uint m00, uint m01, uint m02,
                       uint m10, uint m11, uint m12,
                       uint m20, uint m21, uint m22,
                       uint m30, uint m31, uint m32)
        { 
            this.c0 = new uint4(m00, m10, m20, m30);
            this.c1 = new uint4(m01, m11, m21, m31);
            this.c2 = new uint4(m02, m12, m22, m32);
        }

        /// <summary>
        /// Constructs a uint4x3 matrix from a single uint value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x3(uint v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }

        /// <summary>
        /// Constructs a uint4x3 matrix from a single bool value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x3(bool v)
        {
            this.c0 = math.select(new uint4(0u), new uint4(1u), v);
            this.c1 = math.select(new uint4(0u), new uint4(1u), v);
            this.c2 = math.select(new uint4(0u), new uint4(1u), v);
        }

        /// <summary>
        /// Constructs a uint4x3 matrix from a bool4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x3(bool4x3 v)
        {
            this.c0 = math.select(new uint4(0u), new uint4(1u), v.c0);
            this.c1 = math.select(new uint4(0u), new uint4(1u), v.c1);
            this.c2 = math.select(new uint4(0u), new uint4(1u), v.c2);
        }

        /// <summary>
        /// Constructs a uint4x3 matrix from a single int value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x3(int v)
        {
            this.c0 = (uint4)v;
            this.c1 = (uint4)v;
            this.c2 = (uint4)v;
        }

        /// <summary>
        /// Constructs a uint4x3 matrix from a int4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x3(int4x3 v)
        {
            this.c0 = (uint4)v.c0;
            this.c1 = (uint4)v.c1;
            this.c2 = (uint4)v.c2;
        }

        /// <summary>
        /// Constructs a uint4x3 matrix from a single float value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x3(float v)
        {
            this.c0 = (uint4)v;
            this.c1 = (uint4)v;
            this.c2 = (uint4)v;
        }

        /// <summary>
        /// Constructs a uint4x3 matrix from a float4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x3(float4x3 v)
        {
            this.c0 = (uint4)v.c0;
            this.c1 = (uint4)v.c1;
            this.c2 = (uint4)v.c2;
        }

        /// <summary>
        /// Constructs a uint4x3 matrix from a single double value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x3(double v)
        {
            this.c0 = (uint4)v;
            this.c1 = (uint4)v;
            this.c2 = (uint4)v;
        }

        /// <summary>
        /// Constructs a uint4x3 matrix from a double4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x3(double4x3 v)
        {
            this.c0 = (uint4)v.c0;
            this.c1 = (uint4)v.c1;
            this.c2 = (uint4)v.c2;
        }


        /// <summary>
        /// Implicitly converts a single uint value to a uint4x3 matrix by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4x3(uint v) { return new uint4x3(v); }

        /// <summary>
        /// Explicitly converts a single bool value to a uint4x3 matrix by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x3(bool v) { return new uint4x3(v); }

        /// <summary>
        /// Explicitly converts a bool4x3 matrix to a uint4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x3(bool4x3 v) { return new uint4x3(v); }

        /// <summary>
        /// Explicitly converts a single int value to a uint4x3 matrix by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x3(int v) { return new uint4x3(v); }

        /// <summary>
        /// Explicitly converts a int4x3 matrix to a uint4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x3(int4x3 v) { return new uint4x3(v); }

        /// <summary>
        /// Explicitly converts a single float value to a uint4x3 matrix by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x3(float v) { return new uint4x3(v); }

        /// <summary>
        /// Explicitly converts a float4x3 matrix to a uint4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x3(float4x3 v) { return new uint4x3(v); }

        /// <summary>
        /// Explicitly converts a single double value to a uint4x3 matrix by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x3(double v) { return new uint4x3(v); }

        /// <summary>
        /// Explicitly converts a double4x3 matrix to a uint4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x3(double4x3 v) { return new uint4x3(v); }


        /// <summary>
        /// Returns the result of a componentwise multiplication operation on two uint4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator * (uint4x3 lhs, uint4x3 rhs) { return new uint4x3 (lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise multiplication operation on a uint4x3 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator * (uint4x3 lhs, uint rhs) { return new uint4x3 (lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs); }

        /// <summary>
        /// Returns the result of a componentwise multiplication operation on a uint value and a uint4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator * (uint lhs, uint4x3 rhs) { return new uint4x3 (lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2); }


        /// <summary>
        /// Returns the result of a componentwise addition operation on two uint4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator + (uint4x3 lhs, uint4x3 rhs) { return new uint4x3 (lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise addition operation on a uint4x3 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator + (uint4x3 lhs, uint rhs) { return new uint4x3 (lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs); }

        /// <summary>
        /// Returns the result of a componentwise addition operation on a uint value and a uint4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator + (uint lhs, uint4x3 rhs) { return new uint4x3 (lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2); }


        /// <summary>
        /// Returns the result of a componentwise subtraction operation on two uint4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator - (uint4x3 lhs, uint4x3 rhs) { return new uint4x3 (lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise subtraction operation on a uint4x3 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator - (uint4x3 lhs, uint rhs) { return new uint4x3 (lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs); }

        /// <summary>
        /// Returns the result of a componentwise subtraction operation on a uint value and a uint4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator - (uint lhs, uint4x3 rhs) { return new uint4x3 (lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2); }


        /// <summary>
        /// Returns the result of a componentwise division operation on two uint4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator / (uint4x3 lhs, uint4x3 rhs) { return new uint4x3 (lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise division operation on a uint4x3 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator / (uint4x3 lhs, uint rhs) { return new uint4x3 (lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs); }

        /// <summary>
        /// Returns the result of a componentwise division operation on a uint value and a uint4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator / (uint lhs, uint4x3 rhs) { return new uint4x3 (lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2); }


        /// <summary>
        /// Returns the result of a componentwise modulus operation on two uint4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator % (uint4x3 lhs, uint4x3 rhs) { return new uint4x3 (lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise modulus operation on a uint4x3 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator % (uint4x3 lhs, uint rhs) { return new uint4x3 (lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs); }

        /// <summary>
        /// Returns the result of a componentwise modulus operation on a uint value and a uint4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator % (uint lhs, uint4x3 rhs) { return new uint4x3 (lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2); }


        /// <summary>
        /// Returns the result of a componentwise increment operation on a uint4x3 matrix.
/t/t/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator ++ (uint4x3 val) { return new uint4x3 (++val.c0, ++val.c1, ++val.c2); }


        /// <summary>
        /// Returns the result of a componentwise decrement operation on a uint4x3 matrix.
/t/t/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator -- (uint4x3 val) { return new uint4x3 (--val.c0, --val.c1, --val.c2); }


        /// <summary>
        /// Returns the result of a componentwise less than operation on two uint4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator < (uint4x3 lhs, uint4x3 rhs) { return new bool4x3 (lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise less than operation on a uint4x3 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator < (uint4x3 lhs, uint rhs) { return new bool4x3 (lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs); }

        /// <summary>
        /// Returns the result of a componentwise less than operation on a uint value and a uint4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator < (uint lhs, uint4x3 rhs) { return new bool4x3 (lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2); }


        /// <summary>
        /// Returns the result of a componentwise less or equal operation on two uint4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator <= (uint4x3 lhs, uint4x3 rhs) { return new bool4x3 (lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise less or equal operation on a uint4x3 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator <= (uint4x3 lhs, uint rhs) { return new bool4x3 (lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs); }

        /// <summary>
        /// Returns the result of a componentwise less or equal operation on a uint value and a uint4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator <= (uint lhs, uint4x3 rhs) { return new bool4x3 (lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2); }


        /// <summary>
        /// Returns the result of a componentwise greater than operation on two uint4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator > (uint4x3 lhs, uint4x3 rhs) { return new bool4x3 (lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise greater than operation on a uint4x3 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator > (uint4x3 lhs, uint rhs) { return new bool4x3 (lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs); }

        /// <summary>
        /// Returns the result of a componentwise greater than operation on a uint value and a uint4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator > (uint lhs, uint4x3 rhs) { return new bool4x3 (lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2); }


        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on two uint4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator >= (uint4x3 lhs, uint4x3 rhs) { return new bool4x3 (lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on a uint4x3 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator >= (uint4x3 lhs, uint rhs) { return new bool4x3 (lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs); }

        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on a uint value and a uint4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator >= (uint lhs, uint4x3 rhs) { return new bool4x3 (lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2); }


        /// <summary>
        /// Returns the result of a componentwise unary minus operation on a uint4x3 matrix.
/t/t/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator - (uint4x3 val) { return new uint4x3 (-val.c0, -val.c1, -val.c2); }


        /// <summary>
        /// Returns the result of a componentwise unary plus operation on a uint4x3 matrix.
/t/t/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator + (uint4x3 val) { return new uint4x3 (+val.c0, +val.c1, +val.c2); }


        /// <summary>Returns the result of a componentwise left shift operation on a uint4x3 matrix by a number of bits specified by a single int.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator << (uint4x3 x, int n) { return new uint4x3 (x.c0 << n, x.c1 << n, x.c2 << n); }

        /// <summary>Returns the result of a componentwise right shift operation on a uint4x3 matrix by a number of bits specified by a single int.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator >> (uint4x3 x, int n) { return new uint4x3 (x.c0 >> n, x.c1 >> n, x.c2 >> n); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on two uint4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator == (uint4x3 lhs, uint4x3 rhs) { return new bool4x3 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on a uint4x3 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator == (uint4x3 lhs, uint rhs) { return new bool4x3 (lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on a uint value and a uint4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator == (uint lhs, uint4x3 rhs) { return new bool4x3 (lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2); }


        /// <summary>
        /// Returns the result of a componentwise not equal operation on two uint4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator != (uint4x3 lhs, uint4x3 rhs) { return new bool4x3 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on a uint4x3 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator != (uint4x3 lhs, uint rhs) { return new bool4x3 (lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on a uint value and a uint4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator != (uint lhs, uint4x3 rhs) { return new bool4x3 (lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2); }


        /// <summary>
        /// Returns the result of a componentwise bitwise not operation on a uint4x3 matrix.
/t/t/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator ~ (uint4x3 val) { return new uint4x3 (~val.c0, ~val.c1, ~val.c2); }


        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on two uint4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator & (uint4x3 lhs, uint4x3 rhs) { return new uint4x3 (lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on a uint4x3 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator & (uint4x3 lhs, uint rhs) { return new uint4x3 (lhs.c0 & rhs, lhs.c1 & rhs, lhs.c2 & rhs); }

        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on a uint value and a uint4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator & (uint lhs, uint4x3 rhs) { return new uint4x3 (lhs & rhs.c0, lhs & rhs.c1, lhs & rhs.c2); }


        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on two uint4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator | (uint4x3 lhs, uint4x3 rhs) { return new uint4x3 (lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on a uint4x3 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator | (uint4x3 lhs, uint rhs) { return new uint4x3 (lhs.c0 | rhs, lhs.c1 | rhs, lhs.c2 | rhs); }

        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on a uint value and a uint4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator | (uint lhs, uint4x3 rhs) { return new uint4x3 (lhs | rhs.c0, lhs | rhs.c1, lhs | rhs.c2); }


        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on two uint4x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator ^ (uint4x3 lhs, uint4x3 rhs) { return new uint4x3 (lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on a uint4x3 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator ^ (uint4x3 lhs, uint rhs) { return new uint4x3 (lhs.c0 ^ rhs, lhs.c1 ^ rhs, lhs.c2 ^ rhs); }

        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on a uint value and a uint4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator ^ (uint lhs, uint4x3 rhs) { return new uint4x3 (lhs ^ rhs.c0, lhs ^ rhs.c1, lhs ^ rhs.c2); }



        /// <summary>
        /// Returns the uint4 element at a specified index.
        /// </summary>
        unsafe public ref uint4 this[int index]
        {
            get
            {
#if ENABLE_RASTER_COLLECTIONS_CHECKS
                if ((uint)index >= 3)
                    throw new System.ArgumentException("index must be between[0...2]");
#endif
                fixed (uint4x3* array = &this) { return ref ((uint4*)array)[index]; }
            }
        }

        /// <summary>
        /// Returns true if the uint4x3 is equal to a given uint4x3, false otherwise.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(uint4x3 rhs) { return c0.Equals(rhs.c0) && c1.Equals(rhs.c1) && c2.Equals(rhs.c2); }

        /// <summary>
        /// Returns true if the uint4x3 is equal to a given uint4x3, false otherwise.
        /// </summary>
        public override bool Equals(object o) { return Equals((uint4x3)o); }


        /// <summary>
        /// Returns a hash code for the uint4x3.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() { return (int)math.hash(this); }


        /// <summary>
        /// Returns a string representation of the uint4x3.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("uint4x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8},  {9}, {10}, {11})", c0.x, c1.x, c2.x, c0.y, c1.y, c2.y, c0.z, c1.z, c2.z, c0.w, c1.w, c2.w);
        }

        /// <summary>
        /// Returns a string representation of the uint4x3 using a specified format and culture-specific format information.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("uint4x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8},  {9}, {10}, {11})", c0.x.ToString(format, formatProvider), c1.x.ToString(format, formatProvider), c2.x.ToString(format, formatProvider), c0.y.ToString(format, formatProvider), c1.y.ToString(format, formatProvider), c2.y.ToString(format, formatProvider), c0.z.ToString(format, formatProvider), c1.z.ToString(format, formatProvider), c2.z.ToString(format, formatProvider), c0.w.ToString(format, formatProvider), c1.w.ToString(format, formatProvider), c2.w.ToString(format, formatProvider));
        }

    }

    public static partial class math
    {
        /// <summary>
        /// Returns a uint4x3 matrix constructed from three uint4 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 uint4x3(uint4 c0, uint4 c1, uint4 c2) { return new uint4x3(c0, c1, c2); }

        /// <summary>
        /// Returns a uint4x3 matrix constructed from from 12 uint values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 uint4x3(uint m00, uint m01, uint m02,
                                      uint m10, uint m11, uint m12,
                                      uint m20, uint m21, uint m22,
                                      uint m30, uint m31, uint m32)
        {
            return new uint4x3(m00, m01, m02,
                               m10, m11, m12,
                               m20, m21, m22,
                               m30, m31, m32);
        }

        /// <summary>
        /// Returns a uint4x3 matrix constructed from a single uint value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 uint4x3(uint v) { return new uint4x3(v); }

        /// <summary>
        /// Returns a uint4x3 matrix constructed from a single bool value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 uint4x3(bool v) { return new uint4x3(v); }

        /// <summary>
        /// Return a uint4x3 matrix constructed from a bool4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 uint4x3(bool4x3 v) { return new uint4x3(v); }

        /// <summary>
        /// Returns a uint4x3 matrix constructed from a single int value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 uint4x3(int v) { return new uint4x3(v); }

        /// <summary>
        /// Return a uint4x3 matrix constructed from a int4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 uint4x3(int4x3 v) { return new uint4x3(v); }

        /// <summary>
        /// Returns a uint4x3 matrix constructed from a single float value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 uint4x3(float v) { return new uint4x3(v); }

        /// <summary>
        /// Return a uint4x3 matrix constructed from a float4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 uint4x3(float4x3 v) { return new uint4x3(v); }

        /// <summary>
        /// Returns a uint4x3 matrix constructed from a single double value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 uint4x3(double v) { return new uint4x3(v); }

        /// <summary>
        /// Return a uint4x3 matrix constructed from a double4x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 uint4x3(double4x3 v) { return new uint4x3(v); }

        /// <summary>
        /// Return the uint3x4 transpose of a uint4x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 transpose(uint4x3 v)
        {
            return uint3x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                v.c2.x, v.c2.y, v.c2.z, v.c2.w);
        }

        /// <summary>Returns a uint hash code of a uint4x3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(uint4x3 v)
        {
            return csum(v.c0 * uint4(0xE7579997u, 0xEF7D56C7u, 0x66F38F0Bu, 0x624256A3u) + 
                        v.c1 * uint4(0x5292ADE1u, 0xD2E590E5u, 0xF25BE857u, 0x9BC17CE7u) + 
                        v.c2 * uint4(0xC8B86851u, 0x64095221u, 0xADF428FFu, 0xA3977109u)) + 0x745ED837u;
        }

        /// <summary>
        /// Returns a uint4 vector hash code of a uint4x3 vector.
        /// When multiple elements are to be hashes together, it can more efficient to calculate and combine wide hash
        /// that are only reduced to a narrow uint hash at the very end instead of at every step.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(uint4x3 v)
        {
            return (v.c0 * uint4(0x9CDC88F5u, 0xFA62D721u, 0x7E4DB1CFu, 0x68EEE0F5u) + 
                    v.c1 * uint4(0xBC3B0A59u, 0x816EFB5Du, 0xA24E82B7u, 0x45A22087u) + 
                    v.c2 * uint4(0xFC104C3Bu, 0x5FFF6B19u, 0x5E6CBF3Bu, 0xB546F2A5u)) + 0xBBCF63E7u;
        }

    }
}
