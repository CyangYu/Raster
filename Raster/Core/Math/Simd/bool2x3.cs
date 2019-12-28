using System;
using System.Runtime.CompilerServices;

#pragma warning disable 0660, 0661

namespace Raster.Math.Simd
{
    [System.Serializable]
    public partial struct bool2x3 : System.IEquatable<bool2x3>
    {
        public bool2 c0;
        public bool2 c1;
        public bool2 c2;


        /// <summary>
        /// Constructs a bool2x3 matrix from three bool2 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(bool2 c0, bool2 c1, bool2 c2)
        { 
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        /// <summary>
        /// Constructs a bool2x3 matrix from 6 bool values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(bool m00, bool m01, bool m02,
                       bool m10, bool m11, bool m12)
        { 
            this.c0 = new bool2(m00, m10);
            this.c1 = new bool2(m01, m11);
            this.c2 = new bool2(m02, m12);
        }

        /// <summary>
        /// Constructs a bool2x3 matrix from a single bool value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2x3(bool v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }


        /// <summary>
        /// Implicitly converts a single bool value to a bool2x3 matrix by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool2x3(bool v) { return new bool2x3(v); }


        /// <summary>
        /// Returns the result of a componentwise equality operation on two bool2x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator == (bool2x3 lhs, bool2x3 rhs) { return new bool2x3 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on a bool2x3 matrix and a bool value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator == (bool2x3 lhs, bool rhs) { return new bool2x3 (lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on a bool value and a bool2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator == (bool lhs, bool2x3 rhs) { return new bool2x3 (lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2); }


        /// <summary>
        /// Returns the result of a componentwise not equal operation on two bool2x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator != (bool2x3 lhs, bool2x3 rhs) { return new bool2x3 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on a bool2x3 matrix and a bool value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator != (bool2x3 lhs, bool rhs) { return new bool2x3 (lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on a bool value and a bool2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator != (bool lhs, bool2x3 rhs) { return new bool2x3 (lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2); }


        /// <summary>
        /// Returns the result of a componentwise not operation on a bool2x3 matrix.
/t/t/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator ! (bool2x3 val) { return new bool2x3 (!val.c0, !val.c1, !val.c2); }


        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on two bool2x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator & (bool2x3 lhs, bool2x3 rhs) { return new bool2x3 (lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on a bool2x3 matrix and a bool value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator & (bool2x3 lhs, bool rhs) { return new bool2x3 (lhs.c0 & rhs, lhs.c1 & rhs, lhs.c2 & rhs); }

        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on a bool value and a bool2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator & (bool lhs, bool2x3 rhs) { return new bool2x3 (lhs & rhs.c0, lhs & rhs.c1, lhs & rhs.c2); }


        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on two bool2x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator | (bool2x3 lhs, bool2x3 rhs) { return new bool2x3 (lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on a bool2x3 matrix and a bool value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator | (bool2x3 lhs, bool rhs) { return new bool2x3 (lhs.c0 | rhs, lhs.c1 | rhs, lhs.c2 | rhs); }

        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on a bool value and a bool2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator | (bool lhs, bool2x3 rhs) { return new bool2x3 (lhs | rhs.c0, lhs | rhs.c1, lhs | rhs.c2); }


        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on two bool2x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator ^ (bool2x3 lhs, bool2x3 rhs) { return new bool2x3 (lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on a bool2x3 matrix and a bool value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator ^ (bool2x3 lhs, bool rhs) { return new bool2x3 (lhs.c0 ^ rhs, lhs.c1 ^ rhs, lhs.c2 ^ rhs); }

        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on a bool value and a bool2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator ^ (bool lhs, bool2x3 rhs) { return new bool2x3 (lhs ^ rhs.c0, lhs ^ rhs.c1, lhs ^ rhs.c2); }



        /// <summary>
        /// Returns the bool2 element at a specified index.
        /// </summary>
        unsafe public ref bool2 this[int index]
        {
            get
            {
#if ENABLE_RASTER_COLLECTIONS_CHECKS
                if ((uint)index >= 3)
                    throw new System.ArgumentException("index must be between[0...2]");
#endif
                fixed (bool2x3* array = &this) { return ref ((bool2*)array)[index]; }
            }
        }

        /// <summary>
        /// Returns true if the bool2x3 is equal to a given bool2x3, false otherwise.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(bool2x3 rhs) { return c0.Equals(rhs.c0) && c1.Equals(rhs.c1) && c2.Equals(rhs.c2); }

        /// <summary>
        /// Returns true if the bool2x3 is equal to a given bool2x3, false otherwise.
        /// </summary>
        public override bool Equals(object o) { return Equals((bool2x3)o); }


        /// <summary>
        /// Returns a hash code for the bool2x3.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() { return (int)math.hash(this); }


        /// <summary>
        /// Returns a string representation of the bool2x3.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("bool2x3({0}, {1}, {2},  {3}, {4}, {5})", c0.x, c1.x, c2.x, c0.y, c1.y, c2.y);
        }

    }

    public static partial class math
    {
        /// <summary>
        /// Returns a bool2x3 matrix constructed from three bool2 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 bool2x3(bool2 c0, bool2 c1, bool2 c2) { return new bool2x3(c0, c1, c2); }

        /// <summary>
        /// Returns a bool2x3 matrix constructed from from 6 bool values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 bool2x3(bool m00, bool m01, bool m02,
                                      bool m10, bool m11, bool m12)
        {
            return new bool2x3(m00, m01, m02,
                               m10, m11, m12);
        }

        /// <summary>
        /// Returns a bool2x3 matrix constructed from a single bool value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 bool2x3(bool v) { return new bool2x3(v); }

        /// <summary>
        /// Return the bool3x2 transpose of a bool2x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 transpose(bool2x3 v)
        {
            return bool3x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y,
                v.c2.x, v.c2.y);
        }

        /// <summary>Returns a uint hash code of a bool2x3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(bool2x3 v)
        {
            return csum(select(uint2(0x7BE39F3Bu, 0xFAB9913Fu), uint2(0xB4501269u, 0xE04B89FDu), v.c0) + 
                        select(uint2(0xDB3DE101u, 0x7B6D1B4Bu), uint2(0x58399E77u, 0x5EAC29C9u), v.c1) + 
                        select(uint2(0xFC6014F9u, 0x6BF6693Fu), uint2(0x9D1B1D9Bu, 0xF842F5C1u), v.c2));
        }

        /// <summary>
        /// Returns a uint2 vector hash code of a bool2x3 vector.
        /// When multiple elements are to be hashes together, it can more efficient to calculate and combine wide hash
        /// that are only reduced to a narrow uint hash at the very end instead of at every step.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(bool2x3 v)
        {
            return (select(uint2(0xA47EC335u, 0xA477DF57u), uint2(0xC4B1493Fu, 0xBA0966D3u), v.c0) + 
                    select(uint2(0xAFBEE253u, 0x5B419C01u), uint2(0x515D90F5u, 0xEC9F68F3u), v.c1) + 
                    select(uint2(0xF9EA92D5u, 0xC2FAFCB9u), uint2(0x616E9CA1u, 0xC5C5394Bu), v.c2));
        }

    }
}
