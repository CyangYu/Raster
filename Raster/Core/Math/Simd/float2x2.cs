using System;
using System.Runtime.CompilerServices;

#pragma warning disable 0660, 0661
namespace Raster.Core.Math.Simd
{
    [System.Serializable]
    public partial struct float2x2 : System.IEquatable<float2x2>, IFormattable
    {
        public float2 c0;
        public float2 c1;

        /// <summary>
        /// float2x2 identity transform.
        /// </summary>
        public static readonly float2x2 identity = new float2x2(1.0f, 0.0f,   0.0f, 1.0f);
        /// <summary>
        /// float2x2 zero value.
        /// </summary>
        public static readonly float2x2 zero;

        /// <summary>
        /// Constructs a float2x2 matrix from two float2 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(float2 c0, float2 c1)
        { 
            this.c0 = c0;
            this.c1 = c1;
        }

        /// <summary>
        /// Constructs a float2x2 matrix from 4 float values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(float m00, float m01,
                        float m10, float m11)
        { 
            this.c0 = new float2(m00, m10);
            this.c1 = new float2(m01, m11);
        }

        /// <summary>
        /// Constructs a float2x2 matrix from a single float value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(float v)
        {
            this.c0 = v;
            this.c1 = v;
        }

        /// <summary>
        /// Constructs a float2x2 matrix from a single bool value by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(bool v)
        {
            this.c0 = math.select(new float2(0.0f), new float2(1.0f), v);
            this.c1 = math.select(new float2(0.0f), new float2(1.0f), v);
        }

        /// <summary>
        /// Constructs a float2x2 matrix from a bool2x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(bool2x2 v)
        {
            this.c0 = math.select(new float2(0.0f), new float2(1.0f), v.c0);
            this.c1 = math.select(new float2(0.0f), new float2(1.0f), v.c1);
        }

        /// <summary>
        /// Constructs a float2x2 matrix from a single int value by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(int v)
        {
            this.c0 = v;
            this.c1 = v;
        }

        /// <summary>
        /// Constructs a float2x2 matrix from a int2x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(int2x2 v)
        {
            this.c0 = v.c0;
            this.c1 = v.c1;
        }

        /// <summary>
        /// Constructs a float2x2 matrix from a single uint value by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(uint v)
        {
            this.c0 = v;
            this.c1 = v;
        }

        /// <summary>
        /// Constructs a float2x2 matrix from a uint2x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(uint2x2 v)
        {
            this.c0 = v.c0;
            this.c1 = v.c1;
        }

        /// <summary>
        /// Constructs a float2x2 matrix from a single double value by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(double v)
        {
            this.c0 = (float2)v;
            this.c1 = (float2)v;
        }

        /// <summary>
        /// Constructs a float2x2 matrix from a double2x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(double2x2 v)
        {
            this.c0 = (float2)v.c0;
            this.c1 = (float2)v.c1;
        }

        /// <summary>
        /// Implicitly converts a single float value to a float2x2 matrix by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(float v) { return new float2x2(v); }

        /// <summary>
        /// Explicitly converts a single bool value to a float2x2 matrix by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x2(bool v) { return new float2x2(v); }

        /// <summary>
        /// Explicitly converts a bool2x2 matrix to a float2x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x2(bool2x2 v) { return new float2x2(v); }

        /// <summary>
        /// Implicitly converts a single int value to a float2x2 matrix by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(int v) { return new float2x2(v); }

        /// <summary>
        /// Implicitly converts a int2x2 matrix to a float2x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(int2x2 v) { return new float2x2(v); }

        /// <summary>
        /// Implicitly converts a single uint value to a float2x2 matrix by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(uint v) { return new float2x2(v); }

        /// <summary>
        /// Implicitly converts a uint2x2 matrix to a float2x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(uint2x2 v) { return new float2x2(v); }

        /// <summary>
        /// Explicitly converts a single double value to a float2x2 matrix by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x2(double v) { return new float2x2(v); }

        /// <summary>
        /// Explicitly converts a double2x2 matrix to a float2x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x2(double2x2 v) { return new float2x2(v); }

        /// <summary>
        /// Returns the result of a componentwise multiplication operation on two float2x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, float2x2 rhs) { return new float2x2 (lhs.c0 * rhs.c0, lhs.c1 * rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise multiplication operation on a float2x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, float rhs) { return new float2x2 (lhs.c0 * rhs, lhs.c1 * rhs); }

        /// <summary>
        /// Returns the result of a componentwise multiplication operation on a float value and a float2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float lhs, float2x2 rhs) { return new float2x2 (lhs * rhs.c0, lhs * rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise addition operation on two float2x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, float2x2 rhs) { return new float2x2 (lhs.c0 + rhs.c0, lhs.c1 + rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise addition operation on a float2x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, float rhs) { return new float2x2 (lhs.c0 + rhs, lhs.c1 + rhs); }

        /// <summary>
        /// Returns the result of a componentwise addition operation on a float value and a float2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float lhs, float2x2 rhs) { return new float2x2 (lhs + rhs.c0, lhs + rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise subtraction operation on two float2x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, float2x2 rhs) { return new float2x2 (lhs.c0 - rhs.c0, lhs.c1 - rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise subtraction operation on a float2x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, float rhs) { return new float2x2 (lhs.c0 - rhs, lhs.c1 - rhs); }

        /// <summary>
        /// Returns the result of a componentwise subtraction operation on a float value and a float2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float lhs, float2x2 rhs) { return new float2x2 (lhs - rhs.c0, lhs - rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise division operation on two float2x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, float2x2 rhs) { return new float2x2 (lhs.c0 / rhs.c0, lhs.c1 / rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise division operation on a float2x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, float rhs) { return new float2x2 (lhs.c0 / rhs, lhs.c1 / rhs); }

        /// <summary>
        /// Returns the result of a componentwise division operation on a float value and a float2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float lhs, float2x2 rhs) { return new float2x2 (lhs / rhs.c0, lhs / rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise modulus operation on two float2x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, float2x2 rhs) { return new float2x2 (lhs.c0 % rhs.c0, lhs.c1 % rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise modulus operation on a float2x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, float rhs) { return new float2x2 (lhs.c0 % rhs, lhs.c1 % rhs); }

        /// <summary>
        /// Returns the result of a componentwise modulus operation on a float value and a float2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float lhs, float2x2 rhs) { return new float2x2 (lhs % rhs.c0, lhs % rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise increment operation on a float2x2 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator ++ (float2x2 val) { return new float2x2 (++val.c0, ++val.c1); }

        /// <summary>
        /// Returns the result of a componentwise decrement operation on a float2x2 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator -- (float2x2 val) { return new float2x2 (--val.c0, --val.c1); }

        /// <summary>
        /// Returns the result of a componentwise less than operation on two float2x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator < (float2x2 lhs, float2x2 rhs) { return new bool2x2 (lhs.c0 < rhs.c0, lhs.c1 < rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise less than operation on a float2x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator < (float2x2 lhs, float rhs) { return new bool2x2 (lhs.c0 < rhs, lhs.c1 < rhs); }

        /// <summary>
        /// Returns the result of a componentwise less than operation on a float value and a float2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator < (float lhs, float2x2 rhs) { return new bool2x2 (lhs < rhs.c0, lhs < rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise less or equal operation on two float2x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator <= (float2x2 lhs, float2x2 rhs) { return new bool2x2 (lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise less or equal operation on a float2x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator <= (float2x2 lhs, float rhs) { return new bool2x2 (lhs.c0 <= rhs, lhs.c1 <= rhs); }

        /// <summary>
        /// Returns the result of a componentwise less or equal operation on a float value and a float2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator <= (float lhs, float2x2 rhs) { return new bool2x2 (lhs <= rhs.c0, lhs <= rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise greater than operation on two float2x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator > (float2x2 lhs, float2x2 rhs) { return new bool2x2 (lhs.c0 > rhs.c0, lhs.c1 > rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise greater than operation on a float2x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator > (float2x2 lhs, float rhs) { return new bool2x2 (lhs.c0 > rhs, lhs.c1 > rhs); }

        /// <summary>
        /// Returns the result of a componentwise greater than operation on a float value and a float2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator > (float lhs, float2x2 rhs) { return new bool2x2 (lhs > rhs.c0, lhs > rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on two float2x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator >= (float2x2 lhs, float2x2 rhs) { return new bool2x2 (lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on a float2x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator >= (float2x2 lhs, float rhs) { return new bool2x2 (lhs.c0 >= rhs, lhs.c1 >= rhs); }

        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on a float value and a float2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator >= (float lhs, float2x2 rhs) { return new bool2x2 (lhs >= rhs.c0, lhs >= rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise unary minus operation on a float2x2 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 val) { return new float2x2 (-val.c0, -val.c1); }

        /// <summary>
        /// Returns the result of a componentwise unary plus operation on a float2x2 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 val) { return new float2x2 (+val.c0, +val.c1); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on two float2x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator == (float2x2 lhs, float2x2 rhs) { return new bool2x2 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on a float2x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator == (float2x2 lhs, float rhs) { return new bool2x2 (lhs.c0 == rhs, lhs.c1 == rhs); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on a float value and a float2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator == (float lhs, float2x2 rhs) { return new bool2x2 (lhs == rhs.c0, lhs == rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on two float2x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator != (float2x2 lhs, float2x2 rhs) { return new bool2x2 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on a float2x2 matrix and a float value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator != (float2x2 lhs, float rhs) { return new bool2x2 (lhs.c0 != rhs, lhs.c1 != rhs); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on a float value and a float2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator != (float lhs, float2x2 rhs) { return new bool2x2 (lhs != rhs.c0, lhs != rhs.c1); }


        /// <summary>
        /// Returns the float2 element at a specified index.
        /// </summary>
        unsafe public ref float2 this[int index]
        {
            get
            {
#if ENABLE_RASTER_COLLECTIONS_CHECKS
                if ((uint)index >= 2)
                    throw new System.ArgumentException("index must be between[0...1]");
#endif
                fixed (float2x2* array = &this) { return ref ((float2*)array)[index]; }
            }
        }

        /// <summary>
        /// Returns true if the float2x2 is equal to a given float2x2, false otherwise.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(float2x2 rhs) { return c0.Equals(rhs.c0) && c1.Equals(rhs.c1); }

        /// <summary>
        /// Returns true if the float2x2 is equal to a given float2x2, false otherwise.
        /// </summary>
        public override bool Equals(object o) { return Equals((float2x2)o); }

        /// <summary>
        /// Returns a hash code for the float2x2.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() { return (int)math.hash(this); }

        /// <summary>
        /// Returns a string representation of the float2x2.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("float2x2({0}f, {1}f,  {2}f, {3}f)", c0.x, c1.x, c0.y, c1.y);
        }

        /// <summary>
        /// Returns a string representation of the float2x2 using a specified format and culture-specific format information.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("float2x2({0}f, {1}f,  {2}f, {3}f)", c0.x.ToString(format, formatProvider), c1.x.ToString(format, formatProvider), c0.y.ToString(format, formatProvider), c1.y.ToString(format, formatProvider));
        }
    }
    public static partial class math
    {
        /// <summary>
        /// Returns a float2x2 matrix constructed from two float2 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 float2x2(float2 c0, float2 c1) { return new float2x2(c0, c1); }

        /// <summary>
        /// Returns a float2x2 matrix constructed from from 4 float values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 float2x2(float m00, float m01,
                                        float m10, float m11)
        {
            return new float2x2(m00, m01,
                                m10, m11);
        }

        /// <summary>
        /// Returns a float2x2 matrix constructed from a single float value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 float2x2(float v) { return new float2x2(v); }

        /// <summary>
        /// Returns a float2x2 matrix constructed from a single bool value by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 float2x2(bool v) { return new float2x2(v); }

        /// <summary>
        /// Return a float2x2 matrix constructed from a bool2x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 float2x2(bool2x2 v) { return new float2x2(v); }

        /// <summary>
        /// Returns a float2x2 matrix constructed from a single int value by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 float2x2(int v) { return new float2x2(v); }

        /// <summary>
        /// Return a float2x2 matrix constructed from a int2x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 float2x2(int2x2 v) { return new float2x2(v); }

        /// <summary>
        /// Returns a float2x2 matrix constructed from a single uint value by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 float2x2(uint v) { return new float2x2(v); }

        /// <summary>
        /// Return a float2x2 matrix constructed from a uint2x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 float2x2(uint2x2 v) { return new float2x2(v); }

        /// <summary>
        /// Returns a float2x2 matrix constructed from a single double value by converting it to float and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 float2x2(double v) { return new float2x2(v); }

        /// <summary>
        /// Return a float2x2 matrix constructed from a double2x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 float2x2(double2x2 v) { return new float2x2(v); }

        /// <summary>
        /// Return the float2x2 transpose of a float2x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 transpose(float2x2 v)
        {
            return float2x2(
                v.c0.x, v.c0.y,
                v.c1.x, v.c1.y);
        }

        /// <summary>\n\t\t/// Returns the float2x2 full inverse of a float2x2 matrix.\n\t\t/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 inverse(float2x2 m)
        {
            float a = m.c0.x;
            float b = m.c1.x;
            float c = m.c0.y;
            float d = m.c1.y;

            float det = a * d - b * c;

            return float2x2(d, -b, -c, a) * (1.0f / det);
        }

        /// <summary>\n\t\t/// Returns the determinant of a float2x2 matrix.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float determinant(float2x2 m)
        {
            float a = m.c0.x;
            float b = m.c1.x;
            float c = m.c0.y;
            float d = m.c1.y;

            return a * d - b * c;
        }

        /// <summary>Returns a uint hash code of a float2x2 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(float2x2 v)
        {
            return csum(asuint(v.c0) * uint2(0x9C9F0823u, 0x5A9CA13Bu) + 
                        asuint(v.c1) * uint2(0xAFCDD5EFu, 0xA88D187Du)) + 0xCF6EBA1Du;
        }

        /// <summary>
        /// Returns a uint2 vector hash code of a float2x2 vector.
        /// When multiple elements are to be hashes together, it can more efficient to calculate and combine wide hash
        /// that are only reduced to a narrow uint hash at the very end instead of at every step.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 hashwide(float2x2 v)
        {
            return (asuint(v.c0) * uint2(0x9D88E5A1u, 0xEADF0775u) + 
                    asuint(v.c1) * uint2(0x747A9D7Bu, 0x4111F799u)) + 0xB5F05AF1u;
        }
    }
}
