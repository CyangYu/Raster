using System;
using System.Runtime.CompilerServices;

#pragma warning disable 0660, 0661
namespace Raster.Core.Math.Simd
{
    [System.Serializable]
    public partial struct bool2x2 : System.IEquatable<bool2x2>
    {
        public bool2 c0;
        public bool2 c1;


        /// <summary>
        /// Constructs a bool2x2 matrix from two bool2 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x2(bool2 c0, bool2 c1)
        { 
            this.c0 = c0;
            this.c1 = c1;
        }
        /// <summary>
        /// Constructs a bool2x2 matrix from 4 bool values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x2(bool m00, bool m01,
                       bool m10, bool m11)
        { 
            this.c0 = new bool2(m00, m10);
            this.c1 = new bool2(m01, m11);
        }
        /// <summary>
        /// Constructs a bool2x2 matrix from a single bool value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x2(bool v)
        {
            this.c0 = v;
            this.c1 = v;
        }

        /// <summary>
        /// Implicitly converts a single bool value to a bool2x2 matrix by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool2x2(bool v) { return new bool2x2(v); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on two bool2x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator == (bool2x2 lhs, bool2x2 rhs) { return new bool2x2 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise equality operation on a bool2x2 matrix and a bool value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator == (bool2x2 lhs, bool rhs) { return new bool2x2 (lhs.c0 == rhs, lhs.c1 == rhs); }
        /// <summary>
        /// Returns the result of a componentwise equality operation on a bool value and a bool2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator == (bool lhs, bool2x2 rhs) { return new bool2x2 (lhs == rhs.c0, lhs == rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on two bool2x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator != (bool2x2 lhs, bool2x2 rhs) { return new bool2x2 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise not equal operation on a bool2x2 matrix and a bool value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator != (bool2x2 lhs, bool rhs) { return new bool2x2 (lhs.c0 != rhs, lhs.c1 != rhs); }
        /// <summary>
        /// Returns the result of a componentwise not equal operation on a bool value and a bool2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator != (bool lhs, bool2x2 rhs) { return new bool2x2 (lhs != rhs.c0, lhs != rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise not operation on a bool2x2 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator ! (bool2x2 val) { return new bool2x2 (!val.c0, !val.c1); }

        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on two bool2x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator & (bool2x2 lhs, bool2x2 rhs) { return new bool2x2 (lhs.c0 & rhs.c0, lhs.c1 & rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on a bool2x2 matrix and a bool value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator & (bool2x2 lhs, bool rhs) { return new bool2x2 (lhs.c0 & rhs, lhs.c1 & rhs); }
        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on a bool value and a bool2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator & (bool lhs, bool2x2 rhs) { return new bool2x2 (lhs & rhs.c0, lhs & rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on two bool2x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator | (bool2x2 lhs, bool2x2 rhs) { return new bool2x2 (lhs.c0 | rhs.c0, lhs.c1 | rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on a bool2x2 matrix and a bool value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator | (bool2x2 lhs, bool rhs) { return new bool2x2 (lhs.c0 | rhs, lhs.c1 | rhs); }
        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on a bool value and a bool2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator | (bool lhs, bool2x2 rhs) { return new bool2x2 (lhs | rhs.c0, lhs | rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on two bool2x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator ^ (bool2x2 lhs, bool2x2 rhs) { return new bool2x2 (lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on a bool2x2 matrix and a bool value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator ^ (bool2x2 lhs, bool rhs) { return new bool2x2 (lhs.c0 ^ rhs, lhs.c1 ^ rhs); }
        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on a bool value and a bool2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator ^ (bool lhs, bool2x2 rhs) { return new bool2x2 (lhs ^ rhs.c0, lhs ^ rhs.c1); }


        /// <summary>
        /// Returns the bool2 element at a specified index.
        /// </summary>
        unsafe public ref bool2 this[int index]
        {
            get
            {
#if ENABLE_RASTER_COLLECTIONS_CHECKS
                if ((uint)index >= 2)
                    throw new System.ArgumentException("index must be between[0...1]");
#endif
                fixed (bool2x2* array = &this) { return ref ((bool2*)array)[index]; }
            }
        }

        /// <summary>
        /// Returns true if the bool2x2 is equal to a given bool2x2, false otherwise.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(bool2x2 rhs) { return c0.Equals(rhs.c0) && c1.Equals(rhs.c1); }
        /// <summary>
        /// Returns true if the bool2x2 is equal to a given bool2x2, false otherwise.
        /// </summary>
        public override bool Equals(object o) { return Equals((bool2x2)o); }

        /// <summary>
        /// Returns a hash code for the bool2x2.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() { return (int)math.hash(this); }

        /// <summary>
        /// Returns a string representation of the bool2x2.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("bool2x2({0}, {1},  {2}, {3})", c0.x, c1.x, c0.y, c1.y);
        }
    }
    public static partial class math
    {
        /// <summary>
        /// Returns a bool2x2 matrix constructed from two bool2 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 bool2x2(bool2 c0, bool2 c1) { return new bool2x2(c0, c1); }
        /// <summary>
        /// Returns a bool2x2 matrix constructed from from 4 bool values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 bool2x2(bool m00, bool m01,
                                      bool m10, bool m11)
        {
            return new bool2x2(m00, m01,
                               m10, m11);
        }
        /// <summary>
        /// Returns a bool2x2 matrix constructed from a single bool value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 bool2x2(bool v) { return new bool2x2(v); }
        /// <summary>
        /// Return the bool2x2 transpose of a bool2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 transpose(bool2x2 v)
        {
            return bool2x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y);
        }
        /// <summary>Returns a uint hash code of a bool2x2 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(bool2x2 v)
        {
            return csum(select(uint2(0x7AF32C49u, 0xAE131389u), uint2(0x5D1B165Bu, 0x87096CD7u), v.c0) + 
                        select(uint2(0x4C7F6DD1u, 0x4822A3E9u), uint2(0xAAC3C25Du, 0xD21D0945u), v.c1));
        }
        /// <summary>
        /// Returns a uint2 vector hash code of a bool2x2 vector.
        /// When multiple elements are to be hashes together, it can more efficient to calculate and combine wide hash
        /// that are only reduced to a narrow uint hash at the very end instead of at every step.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(bool2x2 v)
        {
            return (select(uint2(0x88FCAB2Du, 0x614DA60Du), uint2(0x5BA2C50Bu, 0x8C455ACBu), v.c0) + 
                    select(uint2(0xCD266C89u, 0xF1852A33u), uint2(0x77E35E77u, 0x863E3729u), v.c1));
        }
    }
}