using System;
using System.Runtime.CompilerServices;

#pragma warning disable 0660, 0661
namespace Raster.Core.Math.Simd
{
    [System.Serializable]
    public partial struct bool4x4 : System.IEquatable<bool4x4>
    {
        public bool4 c0;
        public bool4 c1;
        public bool4 c2;
        public bool4 c3;


        /// <summary>
        /// Constructs a bool4x4 matrix from four bool4 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(bool4 c0, bool4 c1, bool4 c2, bool4 c3)
        { 
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        /// <summary>
        /// Constructs a bool4x4 matrix from 16 bool values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(bool m00, bool m01, bool m02, bool m03,
                       bool m10, bool m11, bool m12, bool m13,
                       bool m20, bool m21, bool m22, bool m23,
                       bool m30, bool m31, bool m32, bool m33)
        { 
            this.c0 = new bool4(m00, m10, m20, m30);
            this.c1 = new bool4(m01, m11, m21, m31);
            this.c2 = new bool4(m02, m12, m22, m32);
            this.c3 = new bool4(m03, m13, m23, m33);
        }

        /// <summary>
        /// Constructs a bool4x4 matrix from a single bool value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x4(bool v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
            this.c3 = v;
        }

        /// <summary>
        /// Implicitly converts a single bool value to a bool4x4 matrix by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool4x4(bool v) { return new bool4x4(v); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on two bool4x4 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator == (bool4x4 lhs, bool4x4 rhs) { return new bool4x4 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2, lhs.c3 == rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on a bool4x4 matrix and a bool value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator == (bool4x4 lhs, bool rhs) { return new bool4x4 (lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs, lhs.c3 == rhs); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on a bool value and a bool4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator == (bool lhs, bool4x4 rhs) { return new bool4x4 (lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2, lhs == rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on two bool4x4 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator != (bool4x4 lhs, bool4x4 rhs) { return new bool4x4 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2, lhs.c3 != rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on a bool4x4 matrix and a bool value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator != (bool4x4 lhs, bool rhs) { return new bool4x4 (lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs, lhs.c3 != rhs); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on a bool value and a bool4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator != (bool lhs, bool4x4 rhs) { return new bool4x4 (lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2, lhs != rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise not operation on a bool4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator ! (bool4x4 val) { return new bool4x4 (!val.c0, !val.c1, !val.c2, !val.c3); }

        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on two bool4x4 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator & (bool4x4 lhs, bool4x4 rhs) { return new bool4x4 (lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2, lhs.c3 & rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on a bool4x4 matrix and a bool value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator & (bool4x4 lhs, bool rhs) { return new bool4x4 (lhs.c0 & rhs, lhs.c1 & rhs, lhs.c2 & rhs, lhs.c3 & rhs); }

        /// <summary>
        /// Returns the result of a componentwise bitwise and operation on a bool value and a bool4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator & (bool lhs, bool4x4 rhs) { return new bool4x4 (lhs & rhs.c0, lhs & rhs.c1, lhs & rhs.c2, lhs & rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on two bool4x4 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator | (bool4x4 lhs, bool4x4 rhs) { return new bool4x4 (lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2, lhs.c3 | rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on a bool4x4 matrix and a bool value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator | (bool4x4 lhs, bool rhs) { return new bool4x4 (lhs.c0 | rhs, lhs.c1 | rhs, lhs.c2 | rhs, lhs.c3 | rhs); }

        /// <summary>
        /// Returns the result of a componentwise bitwise or operation on a bool value and a bool4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator | (bool lhs, bool4x4 rhs) { return new bool4x4 (lhs | rhs.c0, lhs | rhs.c1, lhs | rhs.c2, lhs | rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on two bool4x4 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator ^ (bool4x4 lhs, bool4x4 rhs) { return new bool4x4 (lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2, lhs.c3 ^ rhs.c3); }

        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on a bool4x4 matrix and a bool value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator ^ (bool4x4 lhs, bool rhs) { return new bool4x4 (lhs.c0 ^ rhs, lhs.c1 ^ rhs, lhs.c2 ^ rhs, lhs.c3 ^ rhs); }

        /// <summary>
        /// Returns the result of a componentwise bitwise exclusive or operation on a bool value and a bool4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator ^ (bool lhs, bool4x4 rhs) { return new bool4x4 (lhs ^ rhs.c0, lhs ^ rhs.c1, lhs ^ rhs.c2, lhs ^ rhs.c3); }


        /// <summary>
        /// Returns the bool4 element at a specified index.
        /// </summary>
        unsafe public ref bool4 this[int index]
        {
            get
            {
#if ENABLE_RASTER_COLLECTIONS_CHECKS
                if ((uint)index >= 4)
                    throw new System.ArgumentException("index must be between[0...3]");
#endif
                fixed (bool4x4* array = &this) { return ref ((bool4*)array)[index]; }
            }
        }

        /// <summary>
        /// Returns true if the bool4x4 is equal to a given bool4x4, false otherwise.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(bool4x4 rhs) { return c0.Equals(rhs.c0) && c1.Equals(rhs.c1) && c2.Equals(rhs.c2) && c3.Equals(rhs.c3); }

        /// <summary>
        /// Returns true if the bool4x4 is equal to a given bool4x4, false otherwise.
        /// </summary>
        public override bool Equals(object o) { return Equals((bool4x4)o); }

        /// <summary>
        /// Returns a hash code for the bool4x4.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() { return (int)math.hash(this); }

        /// <summary>
        /// Returns a string representation of the bool4x4.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("bool4x4({0}, {1}, {2}, {3},  {4}, {5}, {6}, {7},  {8}, {9}, {10}, {11},  {12}, {13}, {14}, {15})", c0.x, c1.x, c2.x, c3.x, c0.y, c1.y, c2.y, c3.y, c0.z, c1.z, c2.z, c3.z, c0.w, c1.w, c2.w, c3.w);
        }
    }
    public static partial class math
    {
        /// <summary>
        /// Returns a bool4x4 matrix constructed from four bool4 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 bool4x4(bool4 c0, bool4 c1, bool4 c2, bool4 c3) { return new bool4x4(c0, c1, c2, c3); }

        /// <summary>
        /// Returns a bool4x4 matrix constructed from from 16 bool values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 bool4x4(bool m00, bool m01, bool m02, bool m03,
                                      bool m10, bool m11, bool m12, bool m13,
                                      bool m20, bool m21, bool m22, bool m23,
                                      bool m30, bool m31, bool m32, bool m33)
        {
            return new bool4x4(m00, m01, m02, m03,
                               m10, m11, m12, m13,
                               m20, m21, m22, m23,
                               m30, m31, m32, m33);
        }

        /// <summary>
        /// Returns a bool4x4 matrix constructed from a single bool value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 bool4x4(bool v) { return new bool4x4(v); }

        /// <summary>
        /// Return the bool4x4 transpose of a bool4x4 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 transpose(bool4x4 v)
        {
            return bool4x4(
                v.c0.x, v.c0.y, v.c0.z, v.c0.w,
                v.c1.x, v.c1.y, v.c1.z, v.c1.w,
                v.c2.x, v.c2.y, v.c2.z, v.c2.w,
                v.c3.x, v.c3.y, v.c3.z, v.c3.w);
        }

        /// <summary>Returns a uint hash code of a bool4x4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(bool4x4 v)
        {
            return csum(select(uint4(0xD19764C7u, 0xB5D0BF63u, 0xF9102C5Fu, 0x9881FB9Fu), uint4(0x56A1530Du, 0x804B722Du, 0x738E50E5u, 0x4FC93C25u), v.c0) + 
                        select(uint4(0xCD0445A5u, 0xD2B90D9Bu, 0xD35C9B2Du, 0xA10D9E27u), uint4(0x568DAAA9u, 0x7530254Fu, 0x9F090439u, 0x5E9F85C9u), v.c1) + 
                        select(uint4(0x8C4CA03Fu, 0xB8D969EDu, 0xAC5DB57Bu, 0xA91A02EDu), uint4(0xB3C49313u, 0xF43A9ABBu, 0x84E7E01Bu, 0x8E055BE5u), v.c2) + 
                        select(uint4(0x6E624EB7u, 0x7383ED49u, 0xDD49C23Bu, 0xEBD0D005u), uint4(0x91475DF7u, 0x55E84827u, 0x90A285BBu, 0x5D19E1D5u), v.c3));
        }

        /// <summary>
        /// Returns a uint4 vector hash code of a bool4x4 vector.
        /// When multiple elements are to be hashes together, it can more efficient to calculate and combine wide hash
        /// that are only reduced to a narrow uint hash at the very end instead of at every step.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 hashwide(bool4x4 v)
        {
            return (select(uint4(0xFAAF07DDu, 0x625C45BDu, 0xC9F27FCBu, 0x6D2523B1u), uint4(0x6E2BF6A9u, 0xCC74B3B7u, 0x83B58237u, 0x833E3E29u), v.c0) + 
                    select(uint4(0xA9D919BFu, 0xC3EC1D97u, 0xB8B208C7u, 0x5D3ED947u), uint4(0x4473BBB1u, 0xCBA11D5Fu, 0x685835CFu, 0xC3D32AE1u), v.c1) + 
                    select(uint4(0xB966942Fu, 0xFE9856B3u, 0xFA3A3285u, 0xAD55999Du), uint4(0xDCDD5341u, 0x94DDD769u, 0xA1E92D39u, 0x4583C801u), v.c2) + 
                    select(uint4(0x9536A0F5u, 0xAF816615u, 0x9AF8D62Du, 0xE3600729u), uint4(0x5F17300Du, 0x670D6809u, 0x7AF32C49u, 0xAE131389u), v.c3));
        }
    }
}
