using System;
using System.Runtime.CompilerServices;

#pragma warning disable 0660, 0661
namespace Raster.Core.Math.Simd
{
    [System.Serializable]
    public partial struct double3x3 : System.IEquatable<double3x3>, IFormattable
    {
        public double3 c0;
        public double3 c1;
        public double3 c2;

        /// <summary>
        /// double3x3 identity transform.
        /// </summary>
        public static readonly double3x3 identity = new double3x3(1.0, 0.0, 0.0,   0.0, 1.0, 0.0,   0.0, 0.0, 1.0);
        /// <summary>
        /// double3x3 zero value.
        /// </summary>
        public static readonly double3x3 zero;

        /// <summary>
        /// Constructs a double3x3 matrix from three double3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x3(double3 c0, double3 c1, double3 c2)
        { 
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }
        /// <summary>
        /// Constructs a double3x3 matrix from 9 double values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x3(double m00, double m01, double m02,
                         double m10, double m11, double m12,
                         double m20, double m21, double m22)
        { 
            this.c0 = new double3(m00, m10, m20);
            this.c1 = new double3(m01, m11, m21);
            this.c2 = new double3(m02, m12, m22);
        }
        /// <summary>
        /// Constructs a double3x3 matrix from a single double value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x3(double v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }
        /// <summary>
        /// Constructs a double3x3 matrix from a single bool value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x3(bool v)
        {
            this.c0 = math.select(new double3(0.0), new double3(1.0), v);
            this.c1 = math.select(new double3(0.0), new double3(1.0), v);
            this.c2 = math.select(new double3(0.0), new double3(1.0), v);
        }
        /// <summary>
        /// Constructs a double3x3 matrix from a bool3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x3(bool3x3 v)
        {
            this.c0 = math.select(new double3(0.0), new double3(1.0), v.c0);
            this.c1 = math.select(new double3(0.0), new double3(1.0), v.c1);
            this.c2 = math.select(new double3(0.0), new double3(1.0), v.c2);
        }
        /// <summary>
        /// Constructs a double3x3 matrix from a single int value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x3(int v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }
        /// <summary>
        /// Constructs a double3x3 matrix from a int3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x3(int3x3 v)
        {
            this.c0 = v.c0;
            this.c1 = v.c1;
            this.c2 = v.c2;
        }
        /// <summary>
        /// Constructs a double3x3 matrix from a single uint value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x3(uint v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }
        /// <summary>
        /// Constructs a double3x3 matrix from a uint3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x3(uint3x3 v)
        {
            this.c0 = v.c0;
            this.c1 = v.c1;
            this.c2 = v.c2;
        }
        /// <summary>
        /// Constructs a double3x3 matrix from a single float value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x3(float v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }
        /// <summary>
        /// Constructs a double3x3 matrix from a float3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x3(float3x3 v)
        {
            this.c0 = v.c0;
            this.c1 = v.c1;
            this.c2 = v.c2;
        }

        /// <summary>
        /// Implicitly converts a single double value to a double3x3 matrix by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x3(double v) { return new double3x3(v); }
        /// <summary>
        /// Explicitly converts a single bool value to a double3x3 matrix by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3x3(bool v) { return new double3x3(v); }
        /// <summary>
        /// Explicitly converts a bool3x3 matrix to a double3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3x3(bool3x3 v) { return new double3x3(v); }
        /// <summary>
        /// Implicitly converts a single int value to a double3x3 matrix by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x3(int v) { return new double3x3(v); }
        /// <summary>
        /// Implicitly converts a int3x3 matrix to a double3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x3(int3x3 v) { return new double3x3(v); }
        /// <summary>
        /// Implicitly converts a single uint value to a double3x3 matrix by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x3(uint v) { return new double3x3(v); }
        /// <summary>
        /// Implicitly converts a uint3x3 matrix to a double3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x3(uint3x3 v) { return new double3x3(v); }
        /// <summary>
        /// Implicitly converts a single float value to a double3x3 matrix by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x3(float v) { return new double3x3(v); }
        /// <summary>
        /// Implicitly converts a float3x3 matrix to a double3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x3(float3x3 v) { return new double3x3(v); }

        /// <summary>
        /// Returns the result of a componentwise multiplication operation on two double3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator * (double3x3 lhs, double3x3 rhs) { return new double3x3 (lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise multiplication operation on a double3x3 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator * (double3x3 lhs, double rhs) { return new double3x3 (lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs); }
        /// <summary>
        /// Returns the result of a componentwise multiplication operation on a double value and a double3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator * (double lhs, double3x3 rhs) { return new double3x3 (lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise addition operation on two double3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator + (double3x3 lhs, double3x3 rhs) { return new double3x3 (lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise addition operation on a double3x3 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator + (double3x3 lhs, double rhs) { return new double3x3 (lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs); }
        /// <summary>
        /// Returns the result of a componentwise addition operation on a double value and a double3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator + (double lhs, double3x3 rhs) { return new double3x3 (lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise subtraction operation on two double3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator - (double3x3 lhs, double3x3 rhs) { return new double3x3 (lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise subtraction operation on a double3x3 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator - (double3x3 lhs, double rhs) { return new double3x3 (lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs); }
        /// <summary>
        /// Returns the result of a componentwise subtraction operation on a double value and a double3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator - (double lhs, double3x3 rhs) { return new double3x3 (lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise division operation on two double3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator / (double3x3 lhs, double3x3 rhs) { return new double3x3 (lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise division operation on a double3x3 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator / (double3x3 lhs, double rhs) { return new double3x3 (lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs); }
        /// <summary>
        /// Returns the result of a componentwise division operation on a double value and a double3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator / (double lhs, double3x3 rhs) { return new double3x3 (lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise modulus operation on two double3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator % (double3x3 lhs, double3x3 rhs) { return new double3x3 (lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise modulus operation on a double3x3 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator % (double3x3 lhs, double rhs) { return new double3x3 (lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs); }
        /// <summary>
        /// Returns the result of a componentwise modulus operation on a double value and a double3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator % (double lhs, double3x3 rhs) { return new double3x3 (lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise increment operation on a double3x3 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator ++ (double3x3 val) { return new double3x3 (++val.c0, ++val.c1, ++val.c2); }

        /// <summary>
        /// Returns the result of a componentwise decrement operation on a double3x3 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator -- (double3x3 val) { return new double3x3 (--val.c0, --val.c1, --val.c2); }

        /// <summary>
        /// Returns the result of a componentwise less than operation on two double3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator < (double3x3 lhs, double3x3 rhs) { return new bool3x3 (lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise less than operation on a double3x3 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator < (double3x3 lhs, double rhs) { return new bool3x3 (lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs); }
        /// <summary>
        /// Returns the result of a componentwise less than operation on a double value and a double3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator < (double lhs, double3x3 rhs) { return new bool3x3 (lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise less or equal operation on two double3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator <= (double3x3 lhs, double3x3 rhs) { return new bool3x3 (lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise less or equal operation on a double3x3 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator <= (double3x3 lhs, double rhs) { return new bool3x3 (lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs); }
        /// <summary>
        /// Returns the result of a componentwise less or equal operation on a double value and a double3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator <= (double lhs, double3x3 rhs) { return new bool3x3 (lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise greater than operation on two double3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator > (double3x3 lhs, double3x3 rhs) { return new bool3x3 (lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise greater than operation on a double3x3 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator > (double3x3 lhs, double rhs) { return new bool3x3 (lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs); }
        /// <summary>
        /// Returns the result of a componentwise greater than operation on a double value and a double3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator > (double lhs, double3x3 rhs) { return new bool3x3 (lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on two double3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator >= (double3x3 lhs, double3x3 rhs) { return new bool3x3 (lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on a double3x3 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator >= (double3x3 lhs, double rhs) { return new bool3x3 (lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs); }
        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on a double value and a double3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator >= (double lhs, double3x3 rhs) { return new bool3x3 (lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise unary minus operation on a double3x3 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator - (double3x3 val) { return new double3x3 (-val.c0, -val.c1, -val.c2); }

        /// <summary>
        /// Returns the result of a componentwise unary plus operation on a double3x3 matrix.
        /// </summary>>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator + (double3x3 val) { return new double3x3 (+val.c0, +val.c1, +val.c2); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on two double3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator == (double3x3 lhs, double3x3 rhs) { return new bool3x3 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise equality operation on a double3x3 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator == (double3x3 lhs, double rhs) { return new bool3x3 (lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs); }
        /// <summary>
        /// Returns the result of a componentwise equality operation on a double value and a double3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator == (double lhs, double3x3 rhs) { return new bool3x3 (lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on two double3x3 matrices.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator != (double3x3 lhs, double3x3 rhs) { return new bool3x3 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2); }
        /// <summary>
        /// Returns the result of a componentwise not equal operation on a double3x3 matrix and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator != (double3x3 lhs, double rhs) { return new bool3x3 (lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs); }
        /// <summary>
        /// Returns the result of a componentwise not equal operation on a double value and a double3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator != (double lhs, double3x3 rhs) { return new bool3x3 (lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2); }


        /// <summary>
        /// Returns the double3 element at a specified index.
        /// </summary>
        unsafe public ref double3 this[int index]
        {
            get
            {
#if ENABLE_RASTER_COLLECTIONS_CHECKS
                if ((uint)index >= 3)
                    throw new System.ArgumentException("index must be between[0...2]");
#endif
                fixed (double3x3* array = &this) { return ref ((double3*)array)[index]; }
            }
        }

        /// <summary>
        /// Returns true if the double3x3 is equal to a given double3x3, false otherwise.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(double3x3 rhs) { return c0.Equals(rhs.c0) && c1.Equals(rhs.c1) && c2.Equals(rhs.c2); }
        /// <summary>
        /// Returns true if the double3x3 is equal to a given double3x3, false otherwise.
        /// </summary>
        public override bool Equals(object o) { return Equals((double3x3)o); }

        /// <summary>
        /// Returns a hash code for the double3x3.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() { return (int)math.hash(this); }

        /// <summary>
        /// Returns a string representation of the double3x3.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("double3x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8})", c0.x, c1.x, c2.x, c0.y, c1.y, c2.y, c0.z, c1.z, c2.z);
        }
        /// <summary>
        /// Returns a string representation of the double3x3 using a specified format and culture-specific format information.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("double3x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8})", c0.x.ToString(format, formatProvider), c1.x.ToString(format, formatProvider), c2.x.ToString(format, formatProvider), c0.y.ToString(format, formatProvider), c1.y.ToString(format, formatProvider), c2.y.ToString(format, formatProvider), c0.z.ToString(format, formatProvider), c1.z.ToString(format, formatProvider), c2.z.ToString(format, formatProvider));
        }
    }
    public static partial class math
    {
        /// <summary>
        /// Returns a double3x3 matrix constructed from three double3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 double3x3(double3 c0, double3 c1, double3 c2) { return new double3x3(c0, c1, c2); }
        /// <summary>
        /// Returns a double3x3 matrix constructed from from 9 double values given in row-major order.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 double3x3(double m00, double m01, double m02,
                                          double m10, double m11, double m12,
                                          double m20, double m21, double m22)
        {
            return new double3x3(m00, m01, m02,
                                 m10, m11, m12,
                                 m20, m21, m22);
        }
        /// <summary>
        /// Returns a double3x3 matrix constructed from a single double value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 double3x3(double v) { return new double3x3(v); }
        /// <summary>
        /// Returns a double3x3 matrix constructed from a single bool value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 double3x3(bool v) { return new double3x3(v); }
        /// <summary>
        /// Return a double3x3 matrix constructed from a bool3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 double3x3(bool3x3 v) { return new double3x3(v); }
        /// <summary>
        /// Returns a double3x3 matrix constructed from a single int value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 double3x3(int v) { return new double3x3(v); }
        /// <summary>
        /// Return a double3x3 matrix constructed from a int3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 double3x3(int3x3 v) { return new double3x3(v); }
        /// <summary>
        /// Returns a double3x3 matrix constructed from a single uint value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 double3x3(uint v) { return new double3x3(v); }
        /// <summary>
        /// Return a double3x3 matrix constructed from a uint3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 double3x3(uint3x3 v) { return new double3x3(v); }
        /// <summary>
        /// Returns a double3x3 matrix constructed from a single float value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 double3x3(float v) { return new double3x3(v); }
        /// <summary>
        /// Return a double3x3 matrix constructed from a float3x3 matrix by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 double3x3(float3x3 v) { return new double3x3(v); }
        /// <summary>
        /// Return the double3x3 transpose of a double3x3 matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 transpose(double3x3 v)
        {
            return double3x3(
                v.c0.x, v.c0.y, v.c0.z,
                v.c1.x, v.c1.y, v.c1.z,
                v.c2.x, v.c2.y, v.c2.z);
        }
        /// <summary>Returns the double3x3 full inverse of a double3x3 matrix.\n\t\t/// </summary>
        public static double3x3 inverse(double3x3 m)
        {
            double3 c0 = m.c0;
            double3 c1 = m.c1;
            double3 c2 = m.c2;

            double3 t0 = double3(c1.x, c2.x, c0.x);
            double3 t1 = double3(c1.y, c2.y, c0.y);
            double3 t2 = double3(c1.z, c2.z, c0.z);

            double3 m0 = t1 * t2.yzx - t1.yzx * t2;
            double3 m1 = t0.yzx * t2 - t0 * t2.yzx;
            double3 m2 = t0 * t1.yzx - t0.yzx * t1;

            double rcpDet = 1.0 / csum(t0.zxy * m0);
            return double3x3(m0, m1, m2) * rcpDet;
        }

        /// <summary>\n\t\t/// Returns the determinant of a double3x3 matrix.\n\t\t/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double determinant(double3x3 m)
        {
            double3 c0 = m.c0;
            double3 c1 = m.c1;
            double3 c2 = m.c2;

            double m00 = c1.y * c2.z - c1.z * c2.y;
            double m01 = c0.y * c2.z - c0.z * c2.y;
            double m02 = c0.y * c1.z - c0.z * c1.y;

            return c0.x * m00 - c1.x * m01 + c2.x * m02;
        }

        /// <summary>Returns a uint hash code of a double3x3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(double3x3 v)
        {
            return csum(fold_to_uint(v.c0) * uint3(0xAC5DB57Bu, 0xA91A02EDu, 0xB3C49313u) + 
                        fold_to_uint(v.c1) * uint3(0xF43A9ABBu, 0x84E7E01Bu, 0x8E055BE5u) + 
                        fold_to_uint(v.c2) * uint3(0x6E624EB7u, 0x7383ED49u, 0xDD49C23Bu)) + 0xEBD0D005u;
        }
        /// <summary>
        /// Returns a uint3 vector hash code of a double3x3 vector.
        /// When multiple elements are to be hashes together, it can more efficient to calculate and combine wide hash
        /// that are only reduced to a narrow uint hash at the very end instead of at every step.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(double3x3 v)
        {
            return (fold_to_uint(v.c0) * uint3(0x91475DF7u, 0x55E84827u, 0x90A285BBu) + 
                    fold_to_uint(v.c1) * uint3(0x5D19E1D5u, 0xFAAF07DDu, 0x625C45BDu) + 
                    fold_to_uint(v.c2) * uint3(0xC9F27FCBu, 0x6D2523B1u, 0x6E2BF6A9u)) + 0xCC74B3B7u;
        }
    }
}
