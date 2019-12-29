using System;
using System.Runtime.CompilerServices;

#pragma warning disable 0660, 0661
namespace Raster.Core.Math.Simd
{
    [System.Serializable]
    public partial struct double3x2 : System.IEquatable<double3x2>, IFormattable
    {
        public double3 c0;
        public double3 c1;

        /// <summary>
        /// double3x2 zero value.
        /// </summary>
        public static readonly double3x2 zero;

        /// <summary>
        /// Constructs a double3x2 matrix from two double3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x2(double3 c0, double3 c1)
        { 
            this.c0 = c0;
            this.c1 = c1;
        }
        /// <summary>
        /// Constructs a double3x2 matrix from 6 double values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x2(double m00, double m01,
                         double m10, double m11,
                         double m20, double m21)
        { 
            this.c0 = new double3(m00, m10, m20);
            this.c1 = new double3(m01, m11, m21);
        }
        /// <summary>
        /// Constructs a double3x2 matrix from a single double value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x2(double v)
        {
            this.c0 = v;
            this.c1 = v;
        }
        /// <summary>
        /// Constructs a double3x2 matrix from a single bool value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x2(bool v)
        {
            this.c0 = math.select(new double3(0.0), new double3(1.0), v);
            this.c1 = math.select(new double3(0.0), new double3(1.0), v);
        }
        /// <summary>
        /// Constructs a double3x2 matrix from a bool3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x2(bool3x2 v)
        {
            this.c0 = math.select(new double3(0.0), new double3(1.0), v.c0);
            this.c1 = math.select(new double3(0.0), new double3(1.0), v.c1);
        }
        /// <summary>
        /// Constructs a double3x2 matrix from a single int value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x2(int v)
        {
            this.c0 = v;
            this.c1 = v;
        }
        /// <summary>
        /// Constructs a double3x2 matrix from a int3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x2(int3x2 v)
        {
            this.c0 = v.c0;
            this.c1 = v.c1;
        }
        /// <summary>
        /// Constructs a double3x2 matrix from a single uint value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x2(uint v)
        {
            this.c0 = v;
            this.c1 = v;
        }
        /// <summary>
        /// Constructs a double3x2 matrix from a uint3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x2(uint3x2 v)
        {
            this.c0 = v.c0;
            this.c1 = v.c1;
        }
        /// <summary>
        /// Constructs a double3x2 matrix from a single float value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x2(float v)
        {
            this.c0 = v;
            this.c1 = v;
        }
        /// <summary>
        /// Constructs a double3x2 matrix from a float3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x2(float3x2 v)
        {
            this.c0 = v.c0;
            this.c1 = v.c1;
        }

        /// <summary>
        /// Implicitly converts a single double value to a double3x2 matrix by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x2(double v) { return new double3x2(v); }
        /// <summary>
        /// Explicitly converts a single bool value to a double3x2 matrix by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3x2(bool v) { return new double3x2(v); }
        /// <summary>
        /// Explicitly converts a bool3x2 matrix to a double3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3x2(bool3x2 v) { return new double3x2(v); }
        /// <summary>
        /// Implicitly converts a single int value to a double3x2 matrix by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x2(int v) { return new double3x2(v); }
        /// <summary>
        /// Implicitly converts a int3x2 matrix to a double3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x2(int3x2 v) { return new double3x2(v); }
        /// <summary>
        /// Implicitly converts a single uint value to a double3x2 matrix by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x2(uint v) { return new double3x2(v); }
        /// <summary>
        /// Implicitly converts a uint3x2 matrix to a double3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x2(uint3x2 v) { return new double3x2(v); }
        /// <summary>
        /// Implicitly converts a single float value to a double3x2 matrix by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x2(float v) { return new double3x2(v); }
        /// <summary>
        /// Implicitly converts a float3x2 matrix to a double3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x2(float3x2 v) { return new double3x2(v); }

        /// <summary>
        /// Returns the result of a componentwise multiplication operation on two double3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator * (double3x2 lhs, double3x2 rhs) { return new double3x2 (lhs.c0 * rhs.c0, lhs.c1 * rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise multiplication operation on a double3x2 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator * (double3x2 lhs, double rhs) { return new double3x2 (lhs.c0 * rhs, lhs.c1 * rhs); }
        /// <summary>
        /// Returns the result of a componentwise multiplication operation on a double value and a double3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator * (double lhs, double3x2 rhs) { return new double3x2 (lhs * rhs.c0, lhs * rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise addition operation on two double3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator + (double3x2 lhs, double3x2 rhs) { return new double3x2 (lhs.c0 + rhs.c0, lhs.c1 + rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise addition operation on a double3x2 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator + (double3x2 lhs, double rhs) { return new double3x2 (lhs.c0 + rhs, lhs.c1 + rhs); }
        /// <summary>
        /// Returns the result of a componentwise addition operation on a double value and a double3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator + (double lhs, double3x2 rhs) { return new double3x2 (lhs + rhs.c0, lhs + rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise subtraction operation on two double3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator - (double3x2 lhs, double3x2 rhs) { return new double3x2 (lhs.c0 - rhs.c0, lhs.c1 - rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise subtraction operation on a double3x2 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator - (double3x2 lhs, double rhs) { return new double3x2 (lhs.c0 - rhs, lhs.c1 - rhs); }
        /// <summary>
        /// Returns the result of a componentwise subtraction operation on a double value and a double3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator - (double lhs, double3x2 rhs) { return new double3x2 (lhs - rhs.c0, lhs - rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise division operation on two double3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator / (double3x2 lhs, double3x2 rhs) { return new double3x2 (lhs.c0 / rhs.c0, lhs.c1 / rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise division operation on a double3x2 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator / (double3x2 lhs, double rhs) { return new double3x2 (lhs.c0 / rhs, lhs.c1 / rhs); }
        /// <summary>
        /// Returns the result of a componentwise division operation on a double value and a double3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator / (double lhs, double3x2 rhs) { return new double3x2 (lhs / rhs.c0, lhs / rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise modulus operation on two double3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator % (double3x2 lhs, double3x2 rhs) { return new double3x2 (lhs.c0 % rhs.c0, lhs.c1 % rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise modulus operation on a double3x2 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator % (double3x2 lhs, double rhs) { return new double3x2 (lhs.c0 % rhs, lhs.c1 % rhs); }
        /// <summary>
        /// Returns the result of a componentwise modulus operation on a double value and a double3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator % (double lhs, double3x2 rhs) { return new double3x2 (lhs % rhs.c0, lhs % rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise increment operation on a double3x2 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator ++ (double3x2 val) { return new double3x2 (++val.c0, ++val.c1); }

        /// <summary>
        /// Returns the result of a componentwise decrement operation on a double3x2 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator -- (double3x2 val) { return new double3x2 (--val.c0, --val.c1); }

        /// <summary>
        /// Returns the result of a componentwise less than operation on two double3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator < (double3x2 lhs, double3x2 rhs) { return new bool3x2 (lhs.c0 < rhs.c0, lhs.c1 < rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise less than operation on a double3x2 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator < (double3x2 lhs, double rhs) { return new bool3x2 (lhs.c0 < rhs, lhs.c1 < rhs); }
        /// <summary>
        /// Returns the result of a componentwise less than operation on a double value and a double3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator < (double lhs, double3x2 rhs) { return new bool3x2 (lhs < rhs.c0, lhs < rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise less or equal operation on two double3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator <= (double3x2 lhs, double3x2 rhs) { return new bool3x2 (lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise less or equal operation on a double3x2 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator <= (double3x2 lhs, double rhs) { return new bool3x2 (lhs.c0 <= rhs, lhs.c1 <= rhs); }
        /// <summary>
        /// Returns the result of a componentwise less or equal operation on a double value and a double3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator <= (double lhs, double3x2 rhs) { return new bool3x2 (lhs <= rhs.c0, lhs <= rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise greater than operation on two double3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator > (double3x2 lhs, double3x2 rhs) { return new bool3x2 (lhs.c0 > rhs.c0, lhs.c1 > rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise greater than operation on a double3x2 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator > (double3x2 lhs, double rhs) { return new bool3x2 (lhs.c0 > rhs, lhs.c1 > rhs); }
        /// <summary>
        /// Returns the result of a componentwise greater than operation on a double value and a double3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator > (double lhs, double3x2 rhs) { return new bool3x2 (lhs > rhs.c0, lhs > rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on two double3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator >= (double3x2 lhs, double3x2 rhs) { return new bool3x2 (lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on a double3x2 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator >= (double3x2 lhs, double rhs) { return new bool3x2 (lhs.c0 >= rhs, lhs.c1 >= rhs); }
        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on a double value and a double3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator >= (double lhs, double3x2 rhs) { return new bool3x2 (lhs >= rhs.c0, lhs >= rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise unary minus operation on a double3x2 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator - (double3x2 val) { return new double3x2 (-val.c0, -val.c1); }

        /// <summary>
        /// Returns the result of a componentwise unary plus operation on a double3x2 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator + (double3x2 val) { return new double3x2 (+val.c0, +val.c1); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on two double3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator == (double3x2 lhs, double3x2 rhs) { return new bool3x2 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise equality operation on a double3x2 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator == (double3x2 lhs, double rhs) { return new bool3x2 (lhs.c0 == rhs, lhs.c1 == rhs); }
        /// <summary>
        /// Returns the result of a componentwise equality operation on a double value and a double3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator == (double lhs, double3x2 rhs) { return new bool3x2 (lhs == rhs.c0, lhs == rhs.c1); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on two double3x2 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator != (double3x2 lhs, double3x2 rhs) { return new bool3x2 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1); }
        /// <summary>
        /// Returns the result of a componentwise not equal operation on a double3x2 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator != (double3x2 lhs, double rhs) { return new bool3x2 (lhs.c0 != rhs, lhs.c1 != rhs); }
        /// <summary>
        /// Returns the result of a componentwise not equal operation on a double value and a double3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator != (double lhs, double3x2 rhs) { return new bool3x2 (lhs != rhs.c0, lhs != rhs.c1); }


        /// <summary>
        /// Returns the double3 element at a specified index.
        /// </summary>
        unsafe public ref double3 this[int index]
        {
            get
            {
#if ENABLE_RASTER_COLLECTIONS_CHECKS
                if ((uint)index >= 2)
                    throw new System.ArgumentException("index must be between[0...1]");
#endif
                fixed (double3x2* array = &this) { return ref ((double3*)array)[index]; }
            }
        }

        /// <summary>
        /// Returns true if the double3x2 is equal to a given double3x2, false otherwise.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(double3x2 rhs) { return c0.Equals(rhs.c0) && c1.Equals(rhs.c1); }
        /// <summary>
        /// Returns true if the double3x2 is equal to a given double3x2, false otherwise.
        /// </summary>
        public override bool Equals(object o) { return Equals((double3x2)o); }

        /// <summary>
        /// Returns a hash code for the double3x2.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() { return (int)math.hash(this); }

        /// <summary>
        /// Returns a string representation of the double3x2.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("double3x2({0}, {1},  {2}, {3},  {4}, {5})", c0.x, c1.x, c0.y, c1.y, c0.z, c1.z);
        }
        /// <summary>
        /// Returns a string representation of the double3x2 using a specified format and culture-specific format information.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("double3x2({0}, {1},  {2}, {3},  {4}, {5})", c0.x.ToString(format, formatProvider), c1.x.ToString(format, formatProvider), c0.y.ToString(format, formatProvider), c1.y.ToString(format, formatProvider), c0.z.ToString(format, formatProvider), c1.z.ToString(format, formatProvider));
        }
    }
    public static partial class math
    {
        /// <summary>
        /// Returns a double3x2 matrix constructed from two double3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 double3x2(double3 c0, double3 c1) { return new double3x2(c0, c1); }
        /// <summary>
        /// Returns a double3x2 matrix constructed from from 6 double values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 double3x2(double m00, double m01,
                                          double m10, double m11,
                                          double m20, double m21)
        {
            return new double3x2(m00, m01,
                                 m10, m11,
                                 m20, m21);
        }
        /// <summary>
        /// Returns a double3x2 matrix constructed from a single double value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 double3x2(double v) { return new double3x2(v); }
        /// <summary>
        /// Returns a double3x2 matrix constructed from a single bool value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 double3x2(bool v) { return new double3x2(v); }
        /// <summary>
        /// Return a double3x2 matrix constructed from a bool3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 double3x2(bool3x2 v) { return new double3x2(v); }
        /// <summary>
        /// Returns a double3x2 matrix constructed from a single int value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 double3x2(int v) { return new double3x2(v); }
        /// <summary>
        /// Return a double3x2 matrix constructed from a int3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 double3x2(int3x2 v) { return new double3x2(v); }
        /// <summary>
        /// Returns a double3x2 matrix constructed from a single uint value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 double3x2(uint v) { return new double3x2(v); }
        /// <summary>
        /// Return a double3x2 matrix constructed from a uint3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 double3x2(uint3x2 v) { return new double3x2(v); }
        /// <summary>
        /// Returns a double3x2 matrix constructed from a single float value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 double3x2(float v) { return new double3x2(v); }
        /// <summary>
        /// Return a double3x2 matrix constructed from a float3x2 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 double3x2(float3x2 v) { return new double3x2(v); }
        /// <summary>
        /// Return the double2x3 transpose of a double3x2 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 transpose(double3x2 v)
        {
            return double2x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z);
        }
        /// <summary>Returns a uint hash code of a double3x2 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(double3x2 v)
        {
            return csum(fold_to_uint(v.c0) * uint3(0xEE390C97u, 0x9C8A2F05u, 0x4DDC6509u) + 
                        fold_to_uint(v.c1) * uint3(0x7CF083CBu, 0x5C4D6CEDu, 0xF9137117u)) + 0xE857DCE1u;
        }
        /// <summary>
        /// Returns a uint3 vector hash code of a double3x2 vector.
        /// When multiple elements are to be hashes together, it can more efficient to calculate and combine wide hash
        /// that are only reduced to a narrow uint hash at the very end instead of at every step.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(double3x2 v)
        {
            return (fold_to_uint(v.c0) * uint3(0xF62213C5u, 0x9CDAA959u, 0xAA269ABFu) + 
                    fold_to_uint(v.c1) * uint3(0xD54BA36Fu, 0xFD0847B9u, 0x8189A683u)) + 0xB139D651u;
        }
    }
}
