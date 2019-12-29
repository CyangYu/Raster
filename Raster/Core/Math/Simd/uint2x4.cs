using System;
using System.Runtime.CompilerServices;

#pragma warning disable 0660, 0661
namespace Raster.Core.Math.Simd
{
    [System.Serializable]
    public partial struct uint2x4 : System.IEquatable<uint2x4>, IFormattable
    {
        public uint2 c0;
        public uint2 c1;
        public uint2 c2;
        public uint2 c3;

        /// <summary>
        /// uint2x4 zero value.
        /// </summary>
        public static readonly uint2x4 zero;

        /// <summary>
        /// Constructs a uint2x4 matrix from four uint2 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x4(uint2 c0, uint2 c1, uint2 c2, uint2 c3)
        { 
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }
        /// <summary>
        /// Constructs a uint2x4 matrix from 8 uint values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x4(uint m00, uint m01, uint m02, uint m03,
                       uint m10, uint m11, uint m12, uint m13)
        { 
            this.c0 = new uint2(m00, m10);
            this.c1 = new uint2(m01, m11);
            this.c2 = new uint2(m02, m12);
            this.c3 = new uint2(m03, m13);
        }
        /// <summary>
        /// Constructs a uint2x4 matrix from a single uint value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x4(uint v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
            this.c3 = v;
        }
        /// <summary>
        /// Constructs a uint2x4 matrix from a single bool value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x4(bool v)
        {
            this.c0 = math.select(new uint2(0u), new uint2(1u), v);
            this.c1 = math.select(new uint2(0u), new uint2(1u), v);
            this.c2 = math.select(new uint2(0u), new uint2(1u), v);
            this.c3 = math.select(new uint2(0u), new uint2(1u), v);
        }
        /// <summary>
        /// Constructs a uint2x4 matrix from a bool2x4 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x4(bool2x4 v)
        {
            this.c0 = math.select(new uint2(0u), new uint2(1u), v.c0);
            this.c1 = math.select(new uint2(0u), new uint2(1u), v.c1);
            this.c2 = math.select(new uint2(0u), new uint2(1u), v.c2);
            this.c3 = math.select(new uint2(0u), new uint2(1u), v.c3);
        }
        /// <summary>
        /// Constructs a uint2x4 matrix from a single int value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x4(int v)
        {
            this.c0 = (uint2)v;
            this.c1 = (uint2)v;
            this.c2 = (uint2)v;
            this.c3 = (uint2)v;
        }
        /// <summary>
        /// Constructs a uint2x4 matrix from a int2x4 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x4(int2x4 v)
        {
            this.c0 = (uint2)v.c0;
            this.c1 = (uint2)v.c1;
            this.c2 = (uint2)v.c2;
            this.c3 = (uint2)v.c3;
        }
        /// <summary>
        /// Constructs a uint2x4 matrix from a single float value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x4(float v)
        {
            this.c0 = (uint2)v;
            this.c1 = (uint2)v;
            this.c2 = (uint2)v;
            this.c3 = (uint2)v;
        }
        /// <summary>
        /// Constructs a uint2x4 matrix from a float2x4 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x4(float2x4 v)
        {
            this.c0 = (uint2)v.c0;
            this.c1 = (uint2)v.c1;
            this.c2 = (uint2)v.c2;
            this.c3 = (uint2)v.c3;
        }
        /// <summary>
        /// Constructs a uint2x4 matrix from a single double value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x4(double v)
        {
            this.c0 = (uint2)v;
            this.c1 = (uint2)v;
            this.c2 = (uint2)v;
            this.c3 = (uint2)v;
        }
        /// <summary>
        /// Constructs a uint2x4 matrix from a double2x4 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x4(double2x4 v)
        {
            this.c0 = (uint2)v.c0;
            this.c1 = (uint2)v.c1;
            this.c2 = (uint2)v.c2;
            this.c3 = (uint2)v.c3;
        }

        /// <summary>
        /// Implicitly converts a single uint value to a uint2x4 matrix by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2x4(uint v) { return new uint2x4(v); }
        /// <summary>
        /// Explicitly converts a single bool value to a uint2x4 matrix by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x4(bool v) { return new uint2x4(v); }
        /// <summary>
        /// Explicitly converts a bool2x4 matrix to a uint2x4 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x4(bool2x4 v) { return new uint2x4(v); }
        /// <summary>
        /// Explicitly converts a single int value to a uint2x4 matrix by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x4(int v) { return new uint2x4(v); }
        /// <summary>
        /// Explicitly converts a int2x4 matrix to a uint2x4 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x4(int2x4 v) { return new uint2x4(v); }
        /// <summary>
        /// Explicitly converts a single float value to a uint2x4 matrix by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x4(float v) { return new uint2x4(v); }
        /// <summary>
        /// Explicitly converts a float2x4 matrix to a uint2x4 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x4(float2x4 v) { return new uint2x4(v); }
        /// <summary>
        /// Explicitly converts a single double value to a uint2x4 matrix by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x4(double v) { return new uint2x4(v); }
        /// <summary>
        /// Explicitly converts a double2x4 matrix to a uint2x4 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x4(double2x4 v) { return new uint2x4(v); }

        /// <summary>
        /// Returns the result of a componentwise multiplication operation on two uint2x4 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator * (uint2x4 lhs, uint2x4 rhs) { return new uint2x4 (lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2, lhs.c3 * rhs.c3); }
        /// <summary>
        /// Returns the result of a componentwise multiplication operation on a uint2x4 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator * (uint2x4 lhs, uint rhs) { return new uint2x4 (lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs, lhs.c3 * rhs); }
        /// <summary>
        /// Returns the result of a componentwise multiplication operation on a uint value and a uint2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator * (uint lhs, uint2x4 rhs) { return new uint2x4 (lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2, lhs * rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise addition operation on two uint2x4 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator + (uint2x4 lhs, uint2x4 rhs) { return new uint2x4 (lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2, lhs.c3 + rhs.c3); }
        /// <summary>
        /// Returns the result of a componentwise addition operation on a uint2x4 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator + (uint2x4 lhs, uint rhs) { return new uint2x4 (lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs, lhs.c3 + rhs); }
        /// <summary>
        /// Returns the result of a componentwise addition operation on a uint value and a uint2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator + (uint lhs, uint2x4 rhs) { return new uint2x4 (lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2, lhs + rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise subtraction operation on two uint2x4 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator - (uint2x4 lhs, uint2x4 rhs) { return new uint2x4 (lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2, lhs.c3 - rhs.c3); }
        /// <summary>
        /// Returns the result of a componentwise subtraction operation on a uint2x4 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator - (uint2x4 lhs, uint rhs) { return new uint2x4 (lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs, lhs.c3 - rhs); }
        /// <summary>
        /// Returns the result of a componentwise subtraction operation on a uint value and a uint2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator - (uint lhs, uint2x4 rhs) { return new uint2x4 (lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2, lhs - rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise division operation on two uint2x4 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator / (uint2x4 lhs, uint2x4 rhs) { return new uint2x4 (lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2, lhs.c3 / rhs.c3); }
        /// <summary>
        /// Returns the result of a componentwise division operation on a uint2x4 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator / (uint2x4 lhs, uint rhs) { return new uint2x4 (lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs, lhs.c3 / rhs); }
        /// <summary>
        /// Returns the result of a componentwise division operation on a uint value and a uint2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator / (uint lhs, uint2x4 rhs) { return new uint2x4 (lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2, lhs / rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise modulus operation on two uint2x4 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator % (uint2x4 lhs, uint2x4 rhs) { return new uint2x4 (lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2, lhs.c3 % rhs.c3); }
        /// <summary>
        /// Returns the result of a componentwise modulus operation on a uint2x4 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator % (uint2x4 lhs, uint rhs) { return new uint2x4 (lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs, lhs.c3 % rhs); }
        /// <summary>
        /// Returns the result of a componentwise modulus operation on a uint value and a uint2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator % (uint lhs, uint2x4 rhs) { return new uint2x4 (lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2, lhs % rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise increment operation on a uint2x4 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator ++ (uint2x4 val) { return new uint2x4 (++val.c0, ++val.c1, ++val.c2, ++val.c3); }

        /// <summary>
        /// Returns the result of a componentwise decrement operation on a uint2x4 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator -- (uint2x4 val) { return new uint2x4 (--val.c0, --val.c1, --val.c2, --val.c3); }

        /// <summary>
        /// Returns the result of a componentwise less than operation on two uint2x4 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator < (uint2x4 lhs, uint2x4 rhs) { return new bool2x4 (lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2, lhs.c3 < rhs.c3); }
        /// <summary>
        /// Returns the result of a componentwise less than operation on a uint2x4 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator < (uint2x4 lhs, uint rhs) { return new bool2x4 (lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs, lhs.c3 < rhs); }
        /// <summary>
        /// Returns the result of a componentwise less than operation on a uint value and a uint2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator < (uint lhs, uint2x4 rhs) { return new bool2x4 (lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2, lhs < rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise less or equal operation on two uint2x4 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator <= (uint2x4 lhs, uint2x4 rhs) { return new bool2x4 (lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2, lhs.c3 <= rhs.c3); }
        /// <summary>
        /// Returns the result of a componentwise less or equal operation on a uint2x4 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator <= (uint2x4 lhs, uint rhs) { return new bool2x4 (lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs, lhs.c3 <= rhs); }
        /// <summary>
        /// Returns the result of a componentwise less or equal operation on a uint value and a uint2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator <= (uint lhs, uint2x4 rhs) { return new bool2x4 (lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2, lhs <= rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise greater than operation on two uint2x4 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator > (uint2x4 lhs, uint2x4 rhs) { return new bool2x4 (lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2, lhs.c3 > rhs.c3); }
        /// <summary>
        /// Returns the result of a componentwise greater than operation on a uint2x4 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator > (uint2x4 lhs, uint rhs) { return new bool2x4 (lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs, lhs.c3 > rhs); }
        /// <summary>
        /// Returns the result of a componentwise greater than operation on a uint value and a uint2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator > (uint lhs, uint2x4 rhs) { return new bool2x4 (lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2, lhs > rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on two uint2x4 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator >= (uint2x4 lhs, uint2x4 rhs) { return new bool2x4 (lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2, lhs.c3 >= rhs.c3); }
        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on a uint2x4 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator >= (uint2x4 lhs, uint rhs) { return new bool2x4 (lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs, lhs.c3 >= rhs); }
        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on a uint value and a uint2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator >= (uint lhs, uint2x4 rhs) { return new bool2x4 (lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2, lhs >= rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise unary minus operation on a uint2x4 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator - (uint2x4 val) { return new uint2x4 (-val.c0, -val.c1, -val.c2, -val.c3); }

        /// <summary>
        /// Returns the result of a componentwise unary plus operation on a uint2x4 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator + (uint2x4 val) { return new uint2x4 (+val.c0, +val.c1, +val.c2, +val.c3); }

        /// <summary>Returns the result of a componentwise left shift operation on a uint2x4 matrix by a number of bits specified by a single int.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator << (uint2x4 x, int n) { return new uint2x4 (x.c0 << n, x.c1 << n, x.c2 << n, x.c3 << n); }
        /// <summary>Returns the result of a componentwise right shift operation on a uint2x4 matrix by a number of bits specified by a single int.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator >> (uint2x4 x, int n) { return new uint2x4 (x.c0 >> n, x.c1 >> n, x.c2 >> n, x.c3 >> n); }
        /// <summary>
        /// Returns the result of a componentwise equality operation on two uint2x4 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator == (uint2x4 lhs, uint2x4 rhs) { return new bool2x4 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2, lhs.c3 == rhs.c3); }
        /// <summary>
        /// Returns the result of a componentwise equality operation on a uint2x4 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator == (uint2x4 lhs, uint rhs) { return new bool2x4 (lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs, lhs.c3 == rhs); }
        /// <summary>
        /// Returns the result of a componentwise equality operation on a uint value and a uint2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator == (uint lhs, uint2x4 rhs) { return new bool2x4 (lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2, lhs == rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on two uint2x4 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator != (uint2x4 lhs, uint2x4 rhs) { return new bool2x4 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2, lhs.c3 != rhs.c3); }
        /// <summary>
        /// Returns the result of a componentwise not equal operation on a uint2x4 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator != (uint2x4 lhs, uint rhs) { return new bool2x4 (lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs, lhs.c3 != rhs); }
        /// <summary>
        /// Returns the result of a componentwise not equal operation on a uint value and a uint2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator != (uint lhs, uint2x4 rhs) { return new bool2x4 (lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2, lhs != rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise bitwise not operation on a uint2x4 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator ~ (uint2x4 val) { return new uint2x4 (~val.c0, ~val.c1, ~val.c2, ~val.c3); }

        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on two uint2x4 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator & (uint2x4 lhs, uint2x4 rhs) { return new uint2x4 (lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2, lhs.c3 & rhs.c3); }
        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on a uint2x4 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator & (uint2x4 lhs, uint rhs) { return new uint2x4 (lhs.c0 & rhs, lhs.c1 & rhs, lhs.c2 & rhs, lhs.c3 & rhs); }
        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on a uint value and a uint2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator & (uint lhs, uint2x4 rhs) { return new uint2x4 (lhs & rhs.c0, lhs & rhs.c1, lhs & rhs.c2, lhs & rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on two uint2x4 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator | (uint2x4 lhs, uint2x4 rhs) { return new uint2x4 (lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2, lhs.c3 | rhs.c3); }
        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on a uint2x4 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator | (uint2x4 lhs, uint rhs) { return new uint2x4 (lhs.c0 | rhs, lhs.c1 | rhs, lhs.c2 | rhs, lhs.c3 | rhs); }
        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on a uint value and a uint2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator | (uint lhs, uint2x4 rhs) { return new uint2x4 (lhs | rhs.c0, lhs | rhs.c1, lhs | rhs.c2, lhs | rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on two uint2x4 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator ^ (uint2x4 lhs, uint2x4 rhs) { return new uint2x4 (lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2, lhs.c3 ^ rhs.c3); }
        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on a uint2x4 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator ^ (uint2x4 lhs, uint rhs) { return new uint2x4 (lhs.c0 ^ rhs, lhs.c1 ^ rhs, lhs.c2 ^ rhs, lhs.c3 ^ rhs); }
        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on a uint value and a uint2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 operator ^ (uint lhs, uint2x4 rhs) { return new uint2x4 (lhs ^ rhs.c0, lhs ^ rhs.c1, lhs ^ rhs.c2, lhs ^ rhs.c3); }


        /// <summary>
        /// Returns the uint2 element at a specified index.
        /// </summary>
        unsafe public ref uint2 this[int index]
        {
            get
            {
#if ENABLE_RASTER_COLLECTIONS_CHECKS
                if ((uint)index >= 4)
                    throw new System.ArgumentException("index must be between[0...3]");
#endif
                fixed (uint2x4* array = &this) { return ref ((uint2*)array)[index]; }
            }
        }

        /// <summary>
        /// Returns true if the uint2x4 is equal to a given uint2x4, false otherwise.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(uint2x4 rhs) { return c0.Equals(rhs.c0) && c1.Equals(rhs.c1) && c2.Equals(rhs.c2) && c3.Equals(rhs.c3); }
        /// <summary>
        /// Returns true if the uint2x4 is equal to a given uint2x4, false otherwise.
        /// </summary>
        public override bool Equals(object o) { return Equals((uint2x4)o); }

        /// <summary>
        /// Returns a hash code for the uint2x4.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() { return (int)math.hash(this); }

        /// <summary>
        /// Returns a string representation of the uint2x4.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("uint2x4({0}, {1}, {2}, {3},  {4}, {5}, {6}, {7})", c0.x, c1.x, c2.x, c3.x, c0.y, c1.y, c2.y, c3.y);
        }
        /// <summary>
        /// Returns a string representation of the uint2x4 using a specified format and culture-specific format information.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("uint2x4({0}, {1}, {2}, {3},  {4}, {5}, {6}, {7})", c0.x.ToString(format, formatProvider), c1.x.ToString(format, formatProvider), c2.x.ToString(format, formatProvider), c3.x.ToString(format, formatProvider), c0.y.ToString(format, formatProvider), c1.y.ToString(format, formatProvider), c2.y.ToString(format, formatProvider), c3.y.ToString(format, formatProvider));
        }
    }
    public static partial class math
    {
        /// <summary>
        /// Returns a uint2x4 matrix constructed from four uint2 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 uint2x4(uint2 c0, uint2 c1, uint2 c2, uint2 c3) { return new uint2x4(c0, c1, c2, c3); }
        /// <summary>
        /// Returns a uint2x4 matrix constructed from from 8 uint values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 uint2x4(uint m00, uint m01, uint m02, uint m03,
                                      uint m10, uint m11, uint m12, uint m13)
        {
            return new uint2x4(m00, m01, m02, m03,
                               m10, m11, m12, m13);
        }
        /// <summary>
        /// Returns a uint2x4 matrix constructed from a single uint value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 uint2x4(uint v) { return new uint2x4(v); }
        /// <summary>
        /// Returns a uint2x4 matrix constructed from a single bool value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 uint2x4(bool v) { return new uint2x4(v); }
        /// <summary>
        /// Return a uint2x4 matrix constructed from a bool2x4 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 uint2x4(bool2x4 v) { return new uint2x4(v); }
        /// <summary>
        /// Returns a uint2x4 matrix constructed from a single int value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 uint2x4(int v) { return new uint2x4(v); }
        /// <summary>
        /// Return a uint2x4 matrix constructed from a int2x4 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 uint2x4(int2x4 v) { return new uint2x4(v); }
        /// <summary>
        /// Returns a uint2x4 matrix constructed from a single float value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 uint2x4(float v) { return new uint2x4(v); }
        /// <summary>
        /// Return a uint2x4 matrix constructed from a float2x4 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 uint2x4(float2x4 v) { return new uint2x4(v); }
        /// <summary>
        /// Returns a uint2x4 matrix constructed from a single double value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 uint2x4(double v) { return new uint2x4(v); }
        /// <summary>
        /// Return a uint2x4 matrix constructed from a double2x4 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x4 uint2x4(double2x4 v) { return new uint2x4(v); }
        /// <summary>
        /// Return the uint4x2 transpose of a uint2x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 transpose(uint2x4 v)
        {
            return uint4x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y,
                v.c2.x, v.c2.y,
                v.c3.x, v.c3.y);
        }
        /// <summary>Returns a uint hash code of a uint2x4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(uint2x4 v)
        {
            return csum(v.c0 * uint2(0x9DF50593u, 0xF18EEB85u) + 
                        v.c1 * uint2(0x9E19BFC3u, 0x8196B06Fu) + 
                        v.c2 * uint2(0xD24EFA19u, 0x7D8048BBu) + 
                        v.c3 * uint2(0x713BD06Fu, 0x753AD6ADu)) + 0xD19764C7u;
        }
        /// <summary>
        /// Returns a uint2 vector hash code of a uint2x4 vector.
        /// When multiple elements are to be hashes together, it can more efficient to calculate and combine wide hash
        /// that are only reduced to a narrow uint hash at the very end instead of at every step.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(uint2x4 v)
        {
            return (v.c0 * uint2(0xB5D0BF63u, 0xF9102C5Fu) + 
                    v.c1 * uint2(0x9881FB9Fu, 0x56A1530Du) + 
                    v.c2 * uint2(0x804B722Du, 0x738E50E5u) + 
                    v.c3 * uint2(0x4FC93C25u, 0xCD0445A5u)) + 0xD2B90D9Bu;
        }
    }
}