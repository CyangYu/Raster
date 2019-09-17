//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Runtime.CompilerServices;

#pragma warning disable 0660, 0661

namespace Raster.Math
{
    [System.Serializable]
    public partial struct float2x3 : System.IEquatable<float2x3>, IFormattable
    {
        public float2 c0;
        public float2 c1;
        public float2 c2;

        /// <summary>float2x3 zero value.</summary>
        public static readonly float2x3 zero;

        /// <summary>Constructs a float2x3 matrix from three float2 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(float2 c0, float2 c1, float2 c2)
        { 
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        /// <summary>Constructs a float2x3 matrix from 6 float values given in row-major order.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(float m00, float m01, float m02,
                        float m10, float m11, float m12)
        { 
            this.c0 = new float2(m00, m10);
            this.c1 = new float2(m01, m11);
            this.c2 = new float2(m02, m12);
        }

        /// <summary>Constructs a float2x3 matrix from a single float value by assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(float v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }

        /// <summary>Constructs a float2x3 matrix from a single bool value by converting it to float and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(bool v)
        {
            this.c0 = math.select(new float2(0.0f), new float2(1.0f), v);
            this.c1 = math.select(new float2(0.0f), new float2(1.0f), v);
            this.c2 = math.select(new float2(0.0f), new float2(1.0f), v);
        }

        /// <summary>Constructs a float2x3 matrix from a bool2x3 matrix by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(bool2x3 v)
        {
            this.c0 = math.select(new float2(0.0f), new float2(1.0f), v.c0);
            this.c1 = math.select(new float2(0.0f), new float2(1.0f), v.c1);
            this.c2 = math.select(new float2(0.0f), new float2(1.0f), v.c2);
        }

        /// <summary>Constructs a float2x3 matrix from a single int value by converting it to float and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(int v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }

        /// <summary>Constructs a float2x3 matrix from a int2x3 matrix by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(int2x3 v)
        {
            this.c0 = v.c0;
            this.c1 = v.c1;
            this.c2 = v.c2;
        }

        /// <summary>Constructs a float2x3 matrix from a single uint value by converting it to float and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(uint v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }

        /// <summary>Constructs a float2x3 matrix from a uint2x3 matrix by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(uint2x3 v)
        {
            this.c0 = v.c0;
            this.c1 = v.c1;
            this.c2 = v.c2;
        }

        /// <summary>Constructs a float2x3 matrix from a single double value by converting it to float and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(double v)
        {
            this.c0 = (float2)v;
            this.c1 = (float2)v;
            this.c2 = (float2)v;
        }

        /// <summary>Constructs a float2x3 matrix from a double2x3 matrix by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(double2x3 v)
        {
            this.c0 = (float2)v.c0;
            this.c1 = (float2)v.c1;
            this.c2 = (float2)v.c2;
        }


        /// <summary>Implicitly converts a single float value to a float2x3 matrix by assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(float v) { return new float2x3(v); }

        /// <summary>Explicitly converts a single bool value to a float2x3 matrix by converting it to float and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x3(bool v) { return new float2x3(v); }

        /// <summary>Explicitly converts a bool2x3 matrix to a float2x3 matrix by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x3(bool2x3 v) { return new float2x3(v); }

        /// <summary>Implicitly converts a single int value to a float2x3 matrix by converting it to float and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(int v) { return new float2x3(v); }

        /// <summary>Implicitly converts a int2x3 matrix to a float2x3 matrix by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(int2x3 v) { return new float2x3(v); }

        /// <summary>Implicitly converts a single uint value to a float2x3 matrix by converting it to float and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(uint v) { return new float2x3(v); }

        /// <summary>Implicitly converts a uint2x3 matrix to a float2x3 matrix by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(uint2x3 v) { return new float2x3(v); }

        /// <summary>Explicitly converts a single double value to a float2x3 matrix by converting it to float and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x3(double v) { return new float2x3(v); }

        /// <summary>Explicitly converts a double2x3 matrix to a float2x3 matrix by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x3(double2x3 v) { return new float2x3(v); }


        /// <summary>Returns the result of a componentwise multiplication operation on two float2x3 matrices.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, float2x3 rhs) { return new float2x3 (lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2); }

        /// <summary>Returns the result of a componentwise multiplication operation on a float2x3 matrix and a float value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, float rhs) { return new float2x3 (lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs); }

        /// <summary>Returns the result of a componentwise multiplication operation on a float value and a float2x3 matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float lhs, float2x3 rhs) { return new float2x3 (lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2); }


        /// <summary>Returns the result of a componentwise addition operation on two float2x3 matrices.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, float2x3 rhs) { return new float2x3 (lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2); }

        /// <summary>Returns the result of a componentwise addition operation on a float2x3 matrix and a float value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, float rhs) { return new float2x3 (lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs); }

        /// <summary>Returns the result of a componentwise addition operation on a float value and a float2x3 matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float lhs, float2x3 rhs) { return new float2x3 (lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2); }


        /// <summary>Returns the result of a componentwise subtraction operation on two float2x3 matrices.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, float2x3 rhs) { return new float2x3 (lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2); }

        /// <summary>Returns the result of a componentwise subtraction operation on a float2x3 matrix and a float value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, float rhs) { return new float2x3 (lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs); }

        /// <summary>Returns the result of a componentwise subtraction operation on a float value and a float2x3 matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float lhs, float2x3 rhs) { return new float2x3 (lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2); }


        /// <summary>Returns the result of a componentwise division operation on two float2x3 matrices.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, float2x3 rhs) { return new float2x3 (lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2); }

        /// <summary>Returns the result of a componentwise division operation on a float2x3 matrix and a float value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, float rhs) { return new float2x3 (lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs); }

        /// <summary>Returns the result of a componentwise division operation on a float value and a float2x3 matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float lhs, float2x3 rhs) { return new float2x3 (lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2); }


        /// <summary>Returns the result of a componentwise modulus operation on two float2x3 matrices.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, float2x3 rhs) { return new float2x3 (lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2); }

        /// <summary>Returns the result of a componentwise modulus operation on a float2x3 matrix and a float value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, float rhs) { return new float2x3 (lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs); }

        /// <summary>Returns the result of a componentwise modulus operation on a float value and a float2x3 matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float lhs, float2x3 rhs) { return new float2x3 (lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2); }


        /// <summary>Returns the result of a componentwise increment operation on a float2x3 matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator ++ (float2x3 val) { return new float2x3 (++val.c0, ++val.c1, ++val.c2); }


        /// <summary>Returns the result of a componentwise decrement operation on a float2x3 matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator -- (float2x3 val) { return new float2x3 (--val.c0, --val.c1, --val.c2); }


        /// <summary>Returns the result of a componentwise less than operation on two float2x3 matrices.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator < (float2x3 lhs, float2x3 rhs) { return new bool2x3 (lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2); }

        /// <summary>Returns the result of a componentwise less than operation on a float2x3 matrix and a float value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator < (float2x3 lhs, float rhs) { return new bool2x3 (lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs); }

        /// <summary>Returns the result of a componentwise less than operation on a float value and a float2x3 matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator < (float lhs, float2x3 rhs) { return new bool2x3 (lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2); }


        /// <summary>Returns the result of a componentwise less or equal operation on two float2x3 matrices.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator <= (float2x3 lhs, float2x3 rhs) { return new bool2x3 (lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2); }

        /// <summary>Returns the result of a componentwise less or equal operation on a float2x3 matrix and a float value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator <= (float2x3 lhs, float rhs) { return new bool2x3 (lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs); }

        /// <summary>Returns the result of a componentwise less or equal operation on a float value and a float2x3 matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator <= (float lhs, float2x3 rhs) { return new bool2x3 (lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2); }


        /// <summary>Returns the result of a componentwise greater than operation on two float2x3 matrices.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator > (float2x3 lhs, float2x3 rhs) { return new bool2x3 (lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2); }

        /// <summary>Returns the result of a componentwise greater than operation on a float2x3 matrix and a float value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator > (float2x3 lhs, float rhs) { return new bool2x3 (lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs); }

        /// <summary>Returns the result of a componentwise greater than operation on a float value and a float2x3 matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator > (float lhs, float2x3 rhs) { return new bool2x3 (lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2); }


        /// <summary>Returns the result of a componentwise greater or equal operation on two float2x3 matrices.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator >= (float2x3 lhs, float2x3 rhs) { return new bool2x3 (lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2); }

        /// <summary>Returns the result of a componentwise greater or equal operation on a float2x3 matrix and a float value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator >= (float2x3 lhs, float rhs) { return new bool2x3 (lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs); }

        /// <summary>Returns the result of a componentwise greater or equal operation on a float value and a float2x3 matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator >= (float lhs, float2x3 rhs) { return new bool2x3 (lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2); }


        /// <summary>Returns the result of a componentwise unary minus operation on a float2x3 matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 val) { return new float2x3 (-val.c0, -val.c1, -val.c2); }


        /// <summary>Returns the result of a componentwise unary plus operation on a float2x3 matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 val) { return new float2x3 (+val.c0, +val.c1, +val.c2); }


        /// <summary>Returns the result of a componentwise equality operation on two float2x3 matrices.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator == (float2x3 lhs, float2x3 rhs) { return new bool2x3 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2); }

        /// <summary>Returns the result of a componentwise equality operation on a float2x3 matrix and a float value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator == (float2x3 lhs, float rhs) { return new bool2x3 (lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs); }

        /// <summary>Returns the result of a componentwise equality operation on a float value and a float2x3 matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator == (float lhs, float2x3 rhs) { return new bool2x3 (lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2); }


        /// <summary>Returns the result of a componentwise not equal operation on two float2x3 matrices.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator != (float2x3 lhs, float2x3 rhs) { return new bool2x3 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2); }

        /// <summary>Returns the result of a componentwise not equal operation on a float2x3 matrix and a float value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator != (float2x3 lhs, float rhs) { return new bool2x3 (lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs); }

        /// <summary>Returns the result of a componentwise not equal operation on a float value and a float2x3 matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator != (float lhs, float2x3 rhs) { return new bool2x3 (lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2); }



        /// <summary>Returns the float2 element at a specified index.</summary>
        unsafe public ref float2 this[int index]
        {
            get
            {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                if ((uint)index >= 3)
                    throw new System.ArgumentException("index must be between[0...2]");
#endif
                fixed (float2x3* array = &this) { return ref ((float2*)array)[index]; }
            }
        }

        /// <summary>Returns true if the float2x3 is equal to a given float2x3, false otherwise.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(float2x3 rhs) { return c0.Equals(rhs.c0) && c1.Equals(rhs.c1) && c2.Equals(rhs.c2); }

        /// <summary>Returns true if the float2x3 is equal to a given float2x3, false otherwise.</summary>
        public override bool Equals(object o) { return Equals((float2x3)o); }


        /// <summary>Returns a hash code for the float2x3.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() { return (int)math.hash(this); }


        /// <summary>Returns a string representation of the float2x3.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("float2x3({0}f, {1}f, {2}f,  {3}f, {4}f, {5}f)", c0.x, c1.x, c2.x, c0.y, c1.y, c2.y);
        }

        /// <summary>Returns a string representation of the float2x3 using a specified format and culture-specific format information.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("float2x3({0}f, {1}f, {2}f,  {3}f, {4}f, {5}f)", c0.x.ToString(format, formatProvider), c1.x.ToString(format, formatProvider), c2.x.ToString(format, formatProvider), c0.y.ToString(format, formatProvider), c1.y.ToString(format, formatProvider), c2.y.ToString(format, formatProvider));
        }

    }

    public static partial class math
    {
        /// <summary>Returns a float2x3 matrix constructed from three float2 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 float2x3(float2 c0, float2 c1, float2 c2) { return new float2x3(c0, c1, c2); }

        /// <summary>Returns a float2x3 matrix constructed from from 6 float values given in row-major order.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 float2x3(float m00, float m01, float m02,
                                        float m10, float m11, float m12)
        {
            return new float2x3(m00, m01, m02,
                                m10, m11, m12);
        }

        /// <summary>Returns a float2x3 matrix constructed from a single float value by assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 float2x3(float v) { return new float2x3(v); }

        /// <summary>Returns a float2x3 matrix constructed from a single bool value by converting it to float and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 float2x3(bool v) { return new float2x3(v); }

        /// <summary>Return a float2x3 matrix constructed from a bool2x3 matrix by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 float2x3(bool2x3 v) { return new float2x3(v); }

        /// <summary>Returns a float2x3 matrix constructed from a single int value by converting it to float and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 float2x3(int v) { return new float2x3(v); }

        /// <summary>Return a float2x3 matrix constructed from a int2x3 matrix by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 float2x3(int2x3 v) { return new float2x3(v); }

        /// <summary>Returns a float2x3 matrix constructed from a single uint value by converting it to float and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 float2x3(uint v) { return new float2x3(v); }

        /// <summary>Return a float2x3 matrix constructed from a uint2x3 matrix by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 float2x3(uint2x3 v) { return new float2x3(v); }

        /// <summary>Returns a float2x3 matrix constructed from a single double value by converting it to float and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 float2x3(double v) { return new float2x3(v); }

        /// <summary>Return a float2x3 matrix constructed from a double2x3 matrix by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 float2x3(double2x3 v) { return new float2x3(v); }

        /// <summary>Return the float3x2 transpose of a float2x3 matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 transpose(float2x3 v)
        {
            return float3x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y,
                v.c2.x, v.c2.y);
        }

        /// <summary>Returns a uint hash code of a float2x3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(float2x3 v)
        {
            return csum(asuint(v.c0) * uint2(0xE857DCE1u, 0xF62213C5u) + 
                        asuint(v.c1) * uint2(0x9CDAA959u, 0xAA269ABFu) + 
                        asuint(v.c2) * uint2(0xD54BA36Fu, 0xFD0847B9u)) + 0x8189A683u;
        }

        /// <summary>
        /// Returns a uint2 vector hash code of a float2x3 vector.
        /// When multiple elements are to be hashes together, it can more efficient to calculate and combine wide hash
        /// that are only reduced to a narrow uint hash at the very end instead of at every step.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(float2x3 v)
        {
            return (asuint(v.c0) * uint2(0xB139D651u, 0xE7579997u) + 
                    asuint(v.c1) * uint2(0xEF7D56C7u, 0x66F38F0Bu) + 
                    asuint(v.c2) * uint2(0x624256A3u, 0x5292ADE1u)) + 0xD2E590E5u;
        }

    }
}
