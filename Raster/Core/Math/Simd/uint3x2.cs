using System;
using System.Runtime.CompilerServices;

#pragma warning disable 0660, 0661
namespace Raster.Core.Math.Simd
{
    [System.Serializable]
    public partial struct uint3x2 : System.IEquatable<uint3x2>, IFormattable
    {
        public uint3 c0;
        public uint3 c1;

        /// <summary>
        /// uint3x2 zero value.
        /// </summary>
        public static readonly uint3x2 zero;

        /// <summary>
        /// Constructs a uint3x2 matrix from two uint3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(uint3 c0, uint3 c1)
        { 
            this.c0 = c0;
            this.c1 = c1;
        }
        /// <summary>
        /// Constructs a uint3x2 matrix from 6 uint values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(uint m00, uint m01,
                       uint m10, uint m11,
                       uint m20, uint m21)
        { 
            this.c0 = new uint3(m00, m10, m20);
            this.c1 = new uint3(m01, m11, m21);
        }
        /// <summary>
        /// Constructs a uint3x2 matrix from a single uint value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(uint v)
        {
            this.c0 = v;
            this.c1 = v;
        }
        /// <summary>
        /// Constructs a uint3x2 matrix from a single bool value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(bool v)
        {
            this.c0 = math.select(new uint3(0u), new uint3(1u), v);
            this.c1 = math.select(new uint3(0u), new uint3(1u), v);
        }
        /// <summary>
        /// Constructs a uint3x2 matrix from a bool3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(bool3x2 v)
        {
            this.c0 = math.select(new uint3(0u), new uint3(1u), v.c0);
            this.c1 = math.select(new uint3(0u), new uint3(1u), v.c1);
        }
        /// <summary>
        /// Constructs a uint3x2 matrix from a single int value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(int v)
        {
            this.c0 = (uint3)v;
            this.c1 = (uint3)v;
        }
        /// <summary>
        /// Constructs a uint3x2 matrix from a int3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(int3x2 v)
        {
            this.c0 = (uint3)v.c0;
            this.c1 = (uint3)v.c1;
        }
        /// <summary>
        /// Constructs a uint3x2 matrix from a single float value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(float v)
        {
            this.c0 = (uint3)v;
            this.c1 = (uint3)v;
        }
        /// <summary>
        /// Constructs a uint3x2 matrix from a float3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(float3x2 v)
        {
            this.c0 = (uint3)v.c0;
            this.c1 = (uint3)v.c1;
        }
        /// <summary>
        /// Constructs a uint3x2 matrix from a single double value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(double v)
        {
            this.c0 = (uint3)v;
            this.c1 = (uint3)v;
        }
        /// <summary>
        /// Constructs a uint3x2 matrix from a double3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(double3x2 v)
        {
            this.c0 = (uint3)v.c0;
            this.c1 = (uint3)v.c1;
        }

        /// <summary>
        /// Implicitly converts a single uint value to a uint3x2 matrix by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3x2(uint v) { return new uint3x2(v); }
        /// <summary>
        /// Explicitly converts a single bool value to a uint3x2 matrix by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(bool v) { return new uint3x2(v); }
        /// <summary>
        /// Explicitly converts a bool3x2 matrix to a uint3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(bool3x2 v) { return new uint3x2(v); }
        /// <summary>
        /// Explicitly converts a single int value to a uint3x2 matrix by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(int v) { return new uint3x2(v); }
        /// <summary>
        /// Explicitly converts a int3x2 matrix to a uint3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(int3x2 v) { return new uint3x2(v); }
        /// <summary>
        /// Explicitly converts a single float value to a uint3x2 matrix by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(float v) { return new uint3x2(v); }
        /// <summary>
        /// Explicitly converts a float3x2 matrix to a uint3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(float3x2 v) { return new uint3x2(v); }
        /// <summary>
        /// Explicitly converts a single double value to a uint3x2 matrix by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(double v) { return new uint3x2(v); }
        /// <summary>
        /// Explicitly converts a double3x2 matrix to a uint3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(double3x2 v) { return new uint3x2(v); }

        /// <summary>
        /// Returns the result of a componentwise multiplication operation on two uint3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator * (uint3x2 lhs, uint3x2 rhs) { return new uint3x2 (lhs.c0 * rhs.c0, lhs.c1 * rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise multiplication operation on a uint3x2 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator * (uint3x2 lhs, uint rhs) { return new uint3x2 (lhs.c0 * rhs, lhs.c1 * rhs); }
        /// <summary>
        /// Returns the result of a componentwise multiplication operation on a uint value and a uint3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator * (uint lhs, uint3x2 rhs) { return new uint3x2 (lhs * rhs.c0, lhs * rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise addition operation on two uint3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator + (uint3x2 lhs, uint3x2 rhs) { return new uint3x2 (lhs.c0 + rhs.c0, lhs.c1 + rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise addition operation on a uint3x2 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator + (uint3x2 lhs, uint rhs) { return new uint3x2 (lhs.c0 + rhs, lhs.c1 + rhs); }
        /// <summary>
        /// Returns the result of a componentwise addition operation on a uint value and a uint3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator + (uint lhs, uint3x2 rhs) { return new uint3x2 (lhs + rhs.c0, lhs + rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise subtraction operation on two uint3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator - (uint3x2 lhs, uint3x2 rhs) { return new uint3x2 (lhs.c0 - rhs.c0, lhs.c1 - rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise subtraction operation on a uint3x2 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator - (uint3x2 lhs, uint rhs) { return new uint3x2 (lhs.c0 - rhs, lhs.c1 - rhs); }
        /// <summary>
        /// Returns the result of a componentwise subtraction operation on a uint value and a uint3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator - (uint lhs, uint3x2 rhs) { return new uint3x2 (lhs - rhs.c0, lhs - rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise division operation on two uint3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator / (uint3x2 lhs, uint3x2 rhs) { return new uint3x2 (lhs.c0 / rhs.c0, lhs.c1 / rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise division operation on a uint3x2 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator / (uint3x2 lhs, uint rhs) { return new uint3x2 (lhs.c0 / rhs, lhs.c1 / rhs); }
        /// <summary>
        /// Returns the result of a componentwise division operation on a uint value and a uint3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator / (uint lhs, uint3x2 rhs) { return new uint3x2 (lhs / rhs.c0, lhs / rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise modulus operation on two uint3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator % (uint3x2 lhs, uint3x2 rhs) { return new uint3x2 (lhs.c0 % rhs.c0, lhs.c1 % rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise modulus operation on a uint3x2 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator % (uint3x2 lhs, uint rhs) { return new uint3x2 (lhs.c0 % rhs, lhs.c1 % rhs); }
        /// <summary>
        /// Returns the result of a componentwise modulus operation on a uint value and a uint3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator % (uint lhs, uint3x2 rhs) { return new uint3x2 (lhs % rhs.c0, lhs % rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise increment operation on a uint3x2 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator ++ (uint3x2 val) { return new uint3x2 (++val.c0, ++val.c1); }

        /// <summary>
        /// Returns the result of a componentwise decrement operation on a uint3x2 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator -- (uint3x2 val) { return new uint3x2 (--val.c0, --val.c1); }

        /// <summary>
        /// Returns the result of a componentwise less than operation on two uint3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator < (uint3x2 lhs, uint3x2 rhs) { return new bool3x2 (lhs.c0 < rhs.c0, lhs.c1 < rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise less than operation on a uint3x2 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator < (uint3x2 lhs, uint rhs) { return new bool3x2 (lhs.c0 < rhs, lhs.c1 < rhs); }
        /// <summary>
        /// Returns the result of a componentwise less than operation on a uint value and a uint3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator < (uint lhs, uint3x2 rhs) { return new bool3x2 (lhs < rhs.c0, lhs < rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise less or equal operation on two uint3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator <= (uint3x2 lhs, uint3x2 rhs) { return new bool3x2 (lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise less or equal operation on a uint3x2 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator <= (uint3x2 lhs, uint rhs) { return new bool3x2 (lhs.c0 <= rhs, lhs.c1 <= rhs); }
        /// <summary>
        /// Returns the result of a componentwise less or equal operation on a uint value and a uint3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator <= (uint lhs, uint3x2 rhs) { return new bool3x2 (lhs <= rhs.c0, lhs <= rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise greater than operation on two uint3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator > (uint3x2 lhs, uint3x2 rhs) { return new bool3x2 (lhs.c0 > rhs.c0, lhs.c1 > rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise greater than operation on a uint3x2 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator > (uint3x2 lhs, uint rhs) { return new bool3x2 (lhs.c0 > rhs, lhs.c1 > rhs); }
        /// <summary>
        /// Returns the result of a componentwise greater than operation on a uint value and a uint3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator > (uint lhs, uint3x2 rhs) { return new bool3x2 (lhs > rhs.c0, lhs > rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on two uint3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator >= (uint3x2 lhs, uint3x2 rhs) { return new bool3x2 (lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on a uint3x2 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator >= (uint3x2 lhs, uint rhs) { return new bool3x2 (lhs.c0 >= rhs, lhs.c1 >= rhs); }
        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on a uint value and a uint3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator >= (uint lhs, uint3x2 rhs) { return new bool3x2 (lhs >= rhs.c0, lhs >= rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise unary minus operation on a uint3x2 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator - (uint3x2 val) { return new uint3x2 (-val.c0, -val.c1); }

        /// <summary>
        /// Returns the result of a componentwise unary plus operation on a uint3x2 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator + (uint3x2 val) { return new uint3x2 (+val.c0, +val.c1); }

        /// <summary>Returns the result of a componentwise left shift operation on a uint3x2 matrix by a number of bits specified by a single int.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator << (uint3x2 x, int n) { return new uint3x2 (x.c0 << n, x.c1 << n); }
        /// <summary>Returns the result of a componentwise right shift operation on a uint3x2 matrix by a number of bits specified by a single int.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator >> (uint3x2 x, int n) { return new uint3x2 (x.c0 >> n, x.c1 >> n); }
        /// <summary>
        /// Returns the result of a componentwise equality operation on two uint3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator == (uint3x2 lhs, uint3x2 rhs) { return new bool3x2 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise equality operation on a uint3x2 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator == (uint3x2 lhs, uint rhs) { return new bool3x2 (lhs.c0 == rhs, lhs.c1 == rhs); }
        /// <summary>
        /// Returns the result of a componentwise equality operation on a uint value and a uint3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator == (uint lhs, uint3x2 rhs) { return new bool3x2 (lhs == rhs.c0, lhs == rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on two uint3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator != (uint3x2 lhs, uint3x2 rhs) { return new bool3x2 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise not equal operation on a uint3x2 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator != (uint3x2 lhs, uint rhs) { return new bool3x2 (lhs.c0 != rhs, lhs.c1 != rhs); }
        /// <summary>
        /// Returns the result of a componentwise not equal operation on a uint value and a uint3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator != (uint lhs, uint3x2 rhs) { return new bool3x2 (lhs != rhs.c0, lhs != rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise bitwise not operation on a uint3x2 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator ~ (uint3x2 val) { return new uint3x2 (~val.c0, ~val.c1); }

        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on two uint3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator & (uint3x2 lhs, uint3x2 rhs) { return new uint3x2 (lhs.c0 & rhs.c0, lhs.c1 & rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on a uint3x2 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator & (uint3x2 lhs, uint rhs) { return new uint3x2 (lhs.c0 & rhs, lhs.c1 & rhs); }
        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on a uint value and a uint3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator & (uint lhs, uint3x2 rhs) { return new uint3x2 (lhs & rhs.c0, lhs & rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on two uint3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator | (uint3x2 lhs, uint3x2 rhs) { return new uint3x2 (lhs.c0 | rhs.c0, lhs.c1 | rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on a uint3x2 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator | (uint3x2 lhs, uint rhs) { return new uint3x2 (lhs.c0 | rhs, lhs.c1 | rhs); }
        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on a uint value and a uint3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator | (uint lhs, uint3x2 rhs) { return new uint3x2 (lhs | rhs.c0, lhs | rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on two uint3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator ^ (uint3x2 lhs, uint3x2 rhs) { return new uint3x2 (lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on a uint3x2 matrix and a uint value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator ^ (uint3x2 lhs, uint rhs) { return new uint3x2 (lhs.c0 ^ rhs, lhs.c1 ^ rhs); }
        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on a uint value and a uint3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator ^ (uint lhs, uint3x2 rhs) { return new uint3x2 (lhs ^ rhs.c0, lhs ^ rhs.c1); }


        /// <summary>
        /// Returns the uint3 element at a specified index.
        /// </summary>
        unsafe public ref uint3 this[int index]
        {
            get
            {
#if ENABLE_RASTER_COLLECTIONS_CHECKS
                if ((uint)index >= 2)
                    throw new System.ArgumentException("index must be between[0...1]");
#endif
                fixed (uint3x2* array = &this) { return ref ((uint3*)array)[index]; }
            }
        }

        /// <summary>
        /// Returns true if the uint3x2 is equal to a given uint3x2, false otherwise.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(uint3x2 rhs) { return c0.Equals(rhs.c0) && c1.Equals(rhs.c1); }
        /// <summary>
        /// Returns true if the uint3x2 is equal to a given uint3x2, false otherwise.
        /// </summary>
        public override bool Equals(object o) { return Equals((uint3x2)o); }

        /// <summary>
        /// Returns a hash code for the uint3x2.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() { return (int)math.hash(this); }

        /// <summary>
        /// Returns a string representation of the uint3x2.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("uint3x2({0}, {1},  {2}, {3},  {4}, {5})", c0.x, c1.x, c0.y, c1.y, c0.z, c1.z);
        }
        /// <summary>
        /// Returns a string representation of the uint3x2 using a specified format and culture-specific format information.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("uint3x2({0}, {1},  {2}, {3},  {4}, {5})", c0.x.ToString(format, formatProvider), c1.x.ToString(format, formatProvider), c0.y.ToString(format, formatProvider), c1.y.ToString(format, formatProvider), c0.z.ToString(format, formatProvider), c1.z.ToString(format, formatProvider));
        }
    }
    public static partial class math
    {
        /// <summary>
        /// Returns a uint3x2 matrix constructed from two uint3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 uint3x2(uint3 c0, uint3 c1) { return new uint3x2(c0, c1); }
        /// <summary>
        /// Returns a uint3x2 matrix constructed from from 6 uint values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 uint3x2(uint m00, uint m01,
                                      uint m10, uint m11,
                                      uint m20, uint m21)
        {
            return new uint3x2(m00, m01,
                               m10, m11,
                               m20, m21);
        }
        /// <summary>
        /// Returns a uint3x2 matrix constructed from a single uint value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 uint3x2(uint v) { return new uint3x2(v); }
        /// <summary>
        /// Returns a uint3x2 matrix constructed from a single bool value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 uint3x2(bool v) { return new uint3x2(v); }
        /// <summary>
        /// Return a uint3x2 matrix constructed from a bool3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 uint3x2(bool3x2 v) { return new uint3x2(v); }
        /// <summary>
        /// Returns a uint3x2 matrix constructed from a single int value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 uint3x2(int v) { return new uint3x2(v); }
        /// <summary>
        /// Return a uint3x2 matrix constructed from a int3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 uint3x2(int3x2 v) { return new uint3x2(v); }
        /// <summary>
        /// Returns a uint3x2 matrix constructed from a single float value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 uint3x2(float v) { return new uint3x2(v); }
        /// <summary>
        /// Return a uint3x2 matrix constructed from a float3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 uint3x2(float3x2 v) { return new uint3x2(v); }
        /// <summary>
        /// Returns a uint3x2 matrix constructed from a single double value by converting it to uint and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 uint3x2(double v) { return new uint3x2(v); }
        /// <summary>
        /// Return a uint3x2 matrix constructed from a double3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 uint3x2(double3x2 v) { return new uint3x2(v); }
        /// <summary>
        /// Return the uint2x3 transpose of a uint3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 transpose(uint3x2 v)
        {
            return uint2x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z);
        }
        /// <summary>Returns a uint hash code of a uint3x2 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(uint3x2 v)
        {
            return csum(v.c0 * uint3(0x515D90F5u, 0xEC9F68F3u, 0xF9EA92D5u) + 
                        v.c1 * uint3(0xC2FAFCB9u, 0x616E9CA1u, 0xC5C5394Bu)) + 0xCAE78587u;
        }
        /// <summary>
        /// Returns a uint3 vector hash code of a uint3x2 vector.
        /// When multiple elements are to be hashes together, it can more efficient to calculate and combine wide hash
        /// that are only reduced to a narrow uint hash at the very end instead of at every step.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(uint3x2 v)
        {
            return (v.c0 * uint3(0x7A1541C9u, 0xF83BD927u, 0x6A243BCBu) + 
                    v.c1 * uint3(0x509B84C9u, 0x91D13847u, 0x52F7230Fu)) + 0xCF286E83u;
        }
    }
}
