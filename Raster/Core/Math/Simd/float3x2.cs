using System;
using System.Runtime.CompilerServices;

#pragma warning disable 0660, 0661

namespace Raster.Math.Simd
{
    [System.Serializable]
    public partial struct float3x2 : System.IEquatable<float3x2>, IFormattable
    {
        public float3 c0;
        public float3 c1;

        /// <summary>
        /// float3x2 zero value.
        /// </summary>
        public static readonly float3x2 zero;

        /// <summary>
        /// Constructs a float3x2 matrix from two float3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3x2(float3 c0, float3 c1)
        { 
            this.c0 = c0;
            this.c1 = c1;
        }

        /// <summary>
        /// Constructs a float3x2 matrix from 6 float values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3x2(float m00, float m01,
                        float m10, float m11,
                        float m20, float m21)
        { 
            this.c0 = new float3(m00, m10, m20);
            this.c1 = new float3(m01, m11, m21);
        }

        /// <summary>
        /// Constructs a float3x2 matrix from a single float value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3x2(float v)
        {
            this.c0 = v;
            this.c1 = v;
        }

        /// <summary>
        /// Constructs a float3x2 matrix from a single bool value by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3x2(bool v)
        {
            this.c0 = math.select(new float3(0.0f), new float3(1.0f), v);
            this.c1 = math.select(new float3(0.0f), new float3(1.0f), v);
        }

        /// <summary>
        /// Constructs a float3x2 matrix from a bool3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3x2(bool3x2 v)
        {
            this.c0 = math.select(new float3(0.0f), new float3(1.0f), v.c0);
            this.c1 = math.select(new float3(0.0f), new float3(1.0f), v.c1);
        }

        /// <summary>
        /// Constructs a float3x2 matrix from a single int value by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3x2(int v)
        {
            this.c0 = v;
            this.c1 = v;
        }

        /// <summary>
        /// Constructs a float3x2 matrix from a int3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3x2(int3x2 v)
        {
            this.c0 = v.c0;
            this.c1 = v.c1;
        }

        /// <summary>
        /// Constructs a float3x2 matrix from a single uint value by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3x2(uint v)
        {
            this.c0 = v;
            this.c1 = v;
        }

        /// <summary>
        /// Constructs a float3x2 matrix from a uint3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3x2(uint3x2 v)
        {
            this.c0 = v.c0;
            this.c1 = v.c1;
        }

        /// <summary>
        /// Constructs a float3x2 matrix from a single double value by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3x2(double v)
        {
            this.c0 = (float3)v;
            this.c1 = (float3)v;
        }

        /// <summary>
        /// Constructs a float3x2 matrix from a double3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3x2(double3x2 v)
        {
            this.c0 = (float3)v.c0;
            this.c1 = (float3)v.c1;
        }


        /// <summary>
        /// Implicitly converts a single float value to a float3x2 matrix by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3x2(float v) { return new float3x2(v); }

        /// <summary>
        /// Explicitly converts a single bool value to a float3x2 matrix by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float3x2(bool v) { return new float3x2(v); }

        /// <summary>
        /// Explicitly converts a bool3x2 matrix to a float3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float3x2(bool3x2 v) { return new float3x2(v); }

        /// <summary>
        /// Implicitly converts a single int value to a float3x2 matrix by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3x2(int v) { return new float3x2(v); }

        /// <summary>
        /// Implicitly converts a int3x2 matrix to a float3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3x2(int3x2 v) { return new float3x2(v); }

        /// <summary>
        /// Implicitly converts a single uint value to a float3x2 matrix by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3x2(uint v) { return new float3x2(v); }

        /// <summary>
        /// Implicitly converts a uint3x2 matrix to a float3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3x2(uint3x2 v) { return new float3x2(v); }

        /// <summary>
        /// Explicitly converts a single double value to a float3x2 matrix by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float3x2(double v) { return new float3x2(v); }

        /// <summary>
        /// Explicitly converts a double3x2 matrix to a float3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float3x2(double3x2 v) { return new float3x2(v); }


        /// <summary>
        /// Returns the result of a componentwise multiplication operation on two float3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator * (float3x2 lhs, float3x2 rhs) { return new float3x2 (lhs.c0 * rhs.c0, lhs.c1 * rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise multiplication operation on a float3x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator * (float3x2 lhs, float rhs) { return new float3x2 (lhs.c0 * rhs, lhs.c1 * rhs); }

        /// <summary>
        /// Returns the result of a componentwise multiplication operation on a float value and a float3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator * (float lhs, float3x2 rhs) { return new float3x2 (lhs * rhs.c0, lhs * rhs.c1); }


        /// <summary>
        /// Returns the result of a componentwise addition operation on two float3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator + (float3x2 lhs, float3x2 rhs) { return new float3x2 (lhs.c0 + rhs.c0, lhs.c1 + rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise addition operation on a float3x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator + (float3x2 lhs, float rhs) { return new float3x2 (lhs.c0 + rhs, lhs.c1 + rhs); }

        /// <summary>
        /// Returns the result of a componentwise addition operation on a float value and a float3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator + (float lhs, float3x2 rhs) { return new float3x2 (lhs + rhs.c0, lhs + rhs.c1); }


        /// <summary>
        /// Returns the result of a componentwise subtraction operation on two float3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator - (float3x2 lhs, float3x2 rhs) { return new float3x2 (lhs.c0 - rhs.c0, lhs.c1 - rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise subtraction operation on a float3x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator - (float3x2 lhs, float rhs) { return new float3x2 (lhs.c0 - rhs, lhs.c1 - rhs); }

        /// <summary>
        /// Returns the result of a componentwise subtraction operation on a float value and a float3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator - (float lhs, float3x2 rhs) { return new float3x2 (lhs - rhs.c0, lhs - rhs.c1); }


        /// <summary>
        /// Returns the result of a componentwise division operation on two float3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator / (float3x2 lhs, float3x2 rhs) { return new float3x2 (lhs.c0 / rhs.c0, lhs.c1 / rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise division operation on a float3x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator / (float3x2 lhs, float rhs) { return new float3x2 (lhs.c0 / rhs, lhs.c1 / rhs); }

        /// <summary>
        /// Returns the result of a componentwise division operation on a float value and a float3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator / (float lhs, float3x2 rhs) { return new float3x2 (lhs / rhs.c0, lhs / rhs.c1); }


        /// <summary>
        /// Returns the result of a componentwise modulus operation on two float3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator % (float3x2 lhs, float3x2 rhs) { return new float3x2 (lhs.c0 % rhs.c0, lhs.c1 % rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise modulus operation on a float3x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator % (float3x2 lhs, float rhs) { return new float3x2 (lhs.c0 % rhs, lhs.c1 % rhs); }

        /// <summary>
        /// Returns the result of a componentwise modulus operation on a float value and a float3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator % (float lhs, float3x2 rhs) { return new float3x2 (lhs % rhs.c0, lhs % rhs.c1); }


        /// <summary>
        /// Returns the result of a componentwise increment operation on a float3x2 matrix.
/t/t/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator ++ (float3x2 val) { return new float3x2 (++val.c0, ++val.c1); }


        /// <summary>
        /// Returns the result of a componentwise decrement operation on a float3x2 matrix.
/t/t/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator -- (float3x2 val) { return new float3x2 (--val.c0, --val.c1); }


        /// <summary>
        /// Returns the result of a componentwise less than operation on two float3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator < (float3x2 lhs, float3x2 rhs) { return new bool3x2 (lhs.c0 < rhs.c0, lhs.c1 < rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise less than operation on a float3x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator < (float3x2 lhs, float rhs) { return new bool3x2 (lhs.c0 < rhs, lhs.c1 < rhs); }

        /// <summary>
        /// Returns the result of a componentwise less than operation on a float value and a float3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator < (float lhs, float3x2 rhs) { return new bool3x2 (lhs < rhs.c0, lhs < rhs.c1); }


        /// <summary>
        /// Returns the result of a componentwise less or equal operation on two float3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator <= (float3x2 lhs, float3x2 rhs) { return new bool3x2 (lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise less or equal operation on a float3x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator <= (float3x2 lhs, float rhs) { return new bool3x2 (lhs.c0 <= rhs, lhs.c1 <= rhs); }

        /// <summary>
        /// Returns the result of a componentwise less or equal operation on a float value and a float3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator <= (float lhs, float3x2 rhs) { return new bool3x2 (lhs <= rhs.c0, lhs <= rhs.c1); }


        /// <summary>
        /// Returns the result of a componentwise greater than operation on two float3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator > (float3x2 lhs, float3x2 rhs) { return new bool3x2 (lhs.c0 > rhs.c0, lhs.c1 > rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise greater than operation on a float3x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator > (float3x2 lhs, float rhs) { return new bool3x2 (lhs.c0 > rhs, lhs.c1 > rhs); }

        /// <summary>
        /// Returns the result of a componentwise greater than operation on a float value and a float3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator > (float lhs, float3x2 rhs) { return new bool3x2 (lhs > rhs.c0, lhs > rhs.c1); }


        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on two float3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator >= (float3x2 lhs, float3x2 rhs) { return new bool3x2 (lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on a float3x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator >= (float3x2 lhs, float rhs) { return new bool3x2 (lhs.c0 >= rhs, lhs.c1 >= rhs); }

        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on a float value and a float3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator >= (float lhs, float3x2 rhs) { return new bool3x2 (lhs >= rhs.c0, lhs >= rhs.c1); }


        /// <summary>
        /// Returns the result of a componentwise unary minus operation on a float3x2 matrix.
/t/t/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator - (float3x2 val) { return new float3x2 (-val.c0, -val.c1); }


        /// <summary>
        /// Returns the result of a componentwise unary plus operation on a float3x2 matrix.
/t/t/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator + (float3x2 val) { return new float3x2 (+val.c0, +val.c1); }


        /// <summary>
        /// Returns the result of a componentwise equality operation on two float3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator == (float3x2 lhs, float3x2 rhs) { return new bool3x2 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on a float3x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator == (float3x2 lhs, float rhs) { return new bool3x2 (lhs.c0 == rhs, lhs.c1 == rhs); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on a float value and a float3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator == (float lhs, float3x2 rhs) { return new bool3x2 (lhs == rhs.c0, lhs == rhs.c1); }


        /// <summary>
        /// Returns the result of a componentwise not equal operation on two float3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator != (float3x2 lhs, float3x2 rhs) { return new bool3x2 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on a float3x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator != (float3x2 lhs, float rhs) { return new bool3x2 (lhs.c0 != rhs, lhs.c1 != rhs); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on a float value and a float3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator != (float lhs, float3x2 rhs) { return new bool3x2 (lhs != rhs.c0, lhs != rhs.c1); }



        /// <summary>
        /// Returns the float3 element at a specified index.
        /// </summary>
        unsafe public ref float3 this[int index]
        {
            get
            {
#if ENABLE_RASTER_COLLECTIONS_CHECKS
                if ((uint)index >= 2)
                    throw new System.ArgumentException("index must be between[0...1]");
#endif
                fixed (float3x2* array = &this) { return ref ((float3*)array)[index]; }
            }
        }

        /// <summary>
        /// Returns true if the float3x2 is equal to a given float3x2, false otherwise.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(float3x2 rhs) { return c0.Equals(rhs.c0) && c1.Equals(rhs.c1); }

        /// <summary>
        /// Returns true if the float3x2 is equal to a given float3x2, false otherwise.
        /// </summary>
        public override bool Equals(object o) { return Equals((float3x2)o); }


        /// <summary>
        /// Returns a hash code for the float3x2.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() { return (int)math.hash(this); }


        /// <summary>
        /// Returns a string representation of the float3x2.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("float3x2({0}f, {1}f,  {2}f, {3}f,  {4}f, {5}f)", c0.x, c1.x, c0.y, c1.y, c0.z, c1.z);
        }

        /// <summary>
        /// Returns a string representation of the float3x2 using a specified format and culture-specific format information.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("float3x2({0}f, {1}f,  {2}f, {3}f,  {4}f, {5}f)", c0.x.ToString(format, formatProvider), c1.x.ToString(format, formatProvider), c0.y.ToString(format, formatProvider), c1.y.ToString(format, formatProvider), c0.z.ToString(format, formatProvider), c1.z.ToString(format, formatProvider));
        }

    }

    public static partial class math
    {
        /// <summary>
        /// Returns a float3x2 matrix constructed from two float3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 float3x2(float3 c0, float3 c1) { return new float3x2(c0, c1); }

        /// <summary>
        /// Returns a float3x2 matrix constructed from from 6 float values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 float3x2(float m00, float m01,
                                        float m10, float m11,
                                        float m20, float m21)
        {
            return new float3x2(m00, m01,
                                m10, m11,
                                m20, m21);
        }

        /// <summary>
        /// Returns a float3x2 matrix constructed from a single float value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 float3x2(float v) { return new float3x2(v); }

        /// <summary>
        /// Returns a float3x2 matrix constructed from a single bool value by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 float3x2(bool v) { return new float3x2(v); }

        /// <summary>
        /// Return a float3x2 matrix constructed from a bool3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 float3x2(bool3x2 v) { return new float3x2(v); }

        /// <summary>
        /// Returns a float3x2 matrix constructed from a single int value by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 float3x2(int v) { return new float3x2(v); }

        /// <summary>
        /// Return a float3x2 matrix constructed from a int3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 float3x2(int3x2 v) { return new float3x2(v); }

        /// <summary>
        /// Returns a float3x2 matrix constructed from a single uint value by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 float3x2(uint v) { return new float3x2(v); }

        /// <summary>
        /// Return a float3x2 matrix constructed from a uint3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 float3x2(uint3x2 v) { return new float3x2(v); }

        /// <summary>
        /// Returns a float3x2 matrix constructed from a single double value by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 float3x2(double v) { return new float3x2(v); }

        /// <summary>
        /// Return a float3x2 matrix constructed from a double3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 float3x2(double3x2 v) { return new float3x2(v); }

        /// <summary>
        /// Return the float2x3 transpose of a float3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 transpose(float3x2 v)
        {
            return float2x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z);
        }

        /// <summary>Returns a uint hash code of a float3x2 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(float3x2 v)
        {
            return csum(asuint(v.c0) * uint3(0xE121E6ADu, 0xC9CA1249u, 0x69B60C81u) + 
                        asuint(v.c1) * uint3(0xE0EB6C25u, 0xF648BEABu, 0x6BDB2B07u)) + 0xEF63C699u;
        }

        /// <summary>
        /// Returns a uint3 vector hash code of a float3x2 vector.
        /// When multiple elements are to be hashes together, it can more efficient to calculate and combine wide hash
        /// that are only reduced to a narrow uint hash at the very end instead of at every step.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(float3x2 v)
        {
            return (asuint(v.c0) * uint3(0x9001903Fu, 0xA895B9CDu, 0x9D23B201u) + 
                    asuint(v.c1) * uint3(0x4B01D3E1u, 0x7461CA0Du, 0x79725379u)) + 0xD6258E5Bu;
        }

    }
}
