using System;
using System.Runtime.CompilerServices;
using System.Diagnostics;

#pragma warning disable 0660, 0661

namespace Raster.Math.Simd
{
    [DebuggerTypeProxy(typeof(double3.DebuggerProxy))]
    [System.Serializable]
    public partial struct double3 : System.IEquatable<double3>, IFormattable
    {
        public double x;
        public double y;
        public double z;

        /// <summary>
        /// double3 zero value.
        /// </summary>
        public static readonly double3 zero;

        /// <summary>
        /// Constructs a double3 vector from three double values.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(double x, double y, double z)
        { 
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Constructs a double3 vector from a double value and a double2 vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(double x, double2 yz)
        { 
            this.x = x;
            this.y = yz.x;
            this.z = yz.y;
        }

        /// <summary>
        /// Constructs a double3 vector from a double2 vector and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(double2 xy, double z)
        { 
            this.x = xy.x;
            this.y = xy.y;
            this.z = z;
        }

        /// <summary>
        /// Constructs a double3 vector from a double3 vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(double3 xyz)
        { 
            this.x = xyz.x;
            this.y = xyz.y;
            this.z = xyz.z;
        }

        /// <summary>
        /// Constructs a double3 vector from a single double value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(double v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
        }

        /// <summary>
        /// Constructs a double3 vector from a single bool value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(bool v)
        {
            this.x = v ? 1.0 : 0.0;
            this.y = v ? 1.0 : 0.0;
            this.z = v ? 1.0 : 0.0;
        }

        /// <summary>
        /// Constructs a double3 vector from a bool3 vector by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(bool3 v)
        {
            this.x = v.x ? 1.0 : 0.0;
            this.y = v.y ? 1.0 : 0.0;
            this.z = v.z ? 1.0 : 0.0;
        }

        /// <summary>
        /// Constructs a double3 vector from a single int value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(int v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
        }

        /// <summary>
        /// Constructs a double3 vector from a int3 vector by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(int3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        /// Constructs a double3 vector from a single uint value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(uint v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
        }

        /// <summary>
        /// Constructs a double3 vector from a uint3 vector by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(uint3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        /// Constructs a double3 vector from a single half value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(half v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
        }

        /// <summary>
        /// Constructs a double3 vector from a half3 vector by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(half3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        /// Constructs a double3 vector from a single float value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(float v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
        }

        /// <summary>
        /// Constructs a double3 vector from a float3 vector by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(float3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }


        /// <summary>
        /// Implicitly converts a single double value to a double3 vector by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(double v) { return new double3(v); }

        /// <summary>
        /// Explicitly converts a single bool value to a double3 vector by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3(bool v) { return new double3(v); }

        /// <summary>
        /// Explicitly converts a bool3 vector to a double3 vector by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3(bool3 v) { return new double3(v); }

        /// <summary>
        /// Implicitly converts a single int value to a double3 vector by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(int v) { return new double3(v); }

        /// <summary>
        /// Implicitly converts a int3 vector to a double3 vector by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(int3 v) { return new double3(v); }

        /// <summary>
        /// Implicitly converts a single uint value to a double3 vector by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(uint v) { return new double3(v); }

        /// <summary>
        /// Implicitly converts a uint3 vector to a double3 vector by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(uint3 v) { return new double3(v); }

        /// <summary>
        /// Implicitly converts a single half value to a double3 vector by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(half v) { return new double3(v); }

        /// <summary>
        /// Implicitly converts a half3 vector to a double3 vector by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(half3 v) { return new double3(v); }

        /// <summary>
        /// Implicitly converts a single float value to a double3 vector by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(float v) { return new double3(v); }

        /// <summary>
        /// Implicitly converts a float3 vector to a double3 vector by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(float3 v) { return new double3(v); }


        /// <summary>
        /// Returns the result of a componentwise multiplication operation on two double3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, double3 rhs) { return new double3 (lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z); }

        /// <summary>
        /// Returns the result of a componentwise multiplication operation on a double3 vector and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double3 lhs, double rhs) { return new double3 (lhs.x * rhs, lhs.y * rhs, lhs.z * rhs); }

        /// <summary>
        /// Returns the result of a componentwise multiplication operation on a double value and a double3 vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (double lhs, double3 rhs) { return new double3 (lhs * rhs.x, lhs * rhs.y, lhs * rhs.z); }


        /// <summary>
        /// Returns the result of a componentwise addition operation on two double3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, double3 rhs) { return new double3 (lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z); }

        /// <summary>
        /// Returns the result of a componentwise addition operation on a double3 vector and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 lhs, double rhs) { return new double3 (lhs.x + rhs, lhs.y + rhs, lhs.z + rhs); }

        /// <summary>
        /// Returns the result of a componentwise addition operation on a double value and a double3 vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double lhs, double3 rhs) { return new double3 (lhs + rhs.x, lhs + rhs.y, lhs + rhs.z); }


        /// <summary>
        /// Returns the result of a componentwise subtraction operation on two double3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, double3 rhs) { return new double3 (lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z); }

        /// <summary>
        /// Returns the result of a componentwise subtraction operation on a double3 vector and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 lhs, double rhs) { return new double3 (lhs.x - rhs, lhs.y - rhs, lhs.z - rhs); }

        /// <summary>
        /// Returns the result of a componentwise subtraction operation on a double value and a double3 vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double lhs, double3 rhs) { return new double3 (lhs - rhs.x, lhs - rhs.y, lhs - rhs.z); }


        /// <summary>
        /// Returns the result of a componentwise division operation on two double3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, double3 rhs) { return new double3 (lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z); }

        /// <summary>
        /// Returns the result of a componentwise division operation on a double3 vector and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double3 lhs, double rhs) { return new double3 (lhs.x / rhs, lhs.y / rhs, lhs.z / rhs); }

        /// <summary>
        /// Returns the result of a componentwise division operation on a double value and a double3 vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (double lhs, double3 rhs) { return new double3 (lhs / rhs.x, lhs / rhs.y, lhs / rhs.z); }


        /// <summary>
        /// Returns the result of a componentwise modulus operation on two double3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, double3 rhs) { return new double3 (lhs.x % rhs.x, lhs.y % rhs.y, lhs.z % rhs.z); }

        /// <summary>
        /// Returns the result of a componentwise modulus operation on a double3 vector and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double3 lhs, double rhs) { return new double3 (lhs.x % rhs, lhs.y % rhs, lhs.z % rhs); }

        /// <summary>
        /// Returns the result of a componentwise modulus operation on a double value and a double3 vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (double lhs, double3 rhs) { return new double3 (lhs % rhs.x, lhs % rhs.y, lhs % rhs.z); }


        /// <summary>
        /// Returns the result of a componentwise increment operation on a double3 vector.
/t/t/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator ++ (double3 val) { return new double3 (++val.x, ++val.y, ++val.z); }


        /// <summary>
        /// Returns the result of a componentwise decrement operation on a double3 vector.
/t/t/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator -- (double3 val) { return new double3 (--val.x, --val.y, --val.z); }


        /// <summary>
        /// Returns the result of a componentwise less than operation on two double3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (double3 lhs, double3 rhs) { return new bool3 (lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z); }

        /// <summary>
        /// Returns the result of a componentwise less than operation on a double3 vector and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (double3 lhs, double rhs) { return new bool3 (lhs.x < rhs, lhs.y < rhs, lhs.z < rhs); }

        /// <summary>
        /// Returns the result of a componentwise less than operation on a double value and a double3 vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (double lhs, double3 rhs) { return new bool3 (lhs < rhs.x, lhs < rhs.y, lhs < rhs.z); }


        /// <summary>
        /// Returns the result of a componentwise less or equal operation on two double3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (double3 lhs, double3 rhs) { return new bool3 (lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z); }

        /// <summary>
        /// Returns the result of a componentwise less or equal operation on a double3 vector and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (double3 lhs, double rhs) { return new bool3 (lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs); }

        /// <summary>
        /// Returns the result of a componentwise less or equal operation on a double value and a double3 vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (double lhs, double3 rhs) { return new bool3 (lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z); }


        /// <summary>
        /// Returns the result of a componentwise greater than operation on two double3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (double3 lhs, double3 rhs) { return new bool3 (lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z); }

        /// <summary>
        /// Returns the result of a componentwise greater than operation on a double3 vector and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (double3 lhs, double rhs) { return new bool3 (lhs.x > rhs, lhs.y > rhs, lhs.z > rhs); }

        /// <summary>
        /// Returns the result of a componentwise greater than operation on a double value and a double3 vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (double lhs, double3 rhs) { return new bool3 (lhs > rhs.x, lhs > rhs.y, lhs > rhs.z); }


        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on two double3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (double3 lhs, double3 rhs) { return new bool3 (lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z); }

        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on a double3 vector and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (double3 lhs, double rhs) { return new bool3 (lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs); }

        /// <summary>
        /// Returns the result of a componentwise greater or equal operation on a double value and a double3 vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (double lhs, double3 rhs) { return new bool3 (lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z); }


        /// <summary>
        /// Returns the result of a componentwise unary minus operation on a double3 vector.
/t/t/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (double3 val) { return new double3 (-val.x, -val.y, -val.z); }


        /// <summary>
        /// Returns the result of a componentwise unary plus operation on a double3 vector.
/t/t/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (double3 val) { return new double3 (+val.x, +val.y, +val.z); }


        /// <summary>
        /// Returns the result of a componentwise equality operation on two double3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (double3 lhs, double3 rhs) { return new bool3 (lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on a double3 vector and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (double3 lhs, double rhs) { return new bool3 (lhs.x == rhs, lhs.y == rhs, lhs.z == rhs); }

        /// <summary>
        /// Returns the result of a componentwise equality operation on a double value and a double3 vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (double lhs, double3 rhs) { return new bool3 (lhs == rhs.x, lhs == rhs.y, lhs == rhs.z); }


        /// <summary>
        /// Returns the result of a componentwise not equal operation on two double3 vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (double3 lhs, double3 rhs) { return new bool3 (lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on a double3 vector and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (double3 lhs, double rhs) { return new bool3 (lhs.x != rhs, lhs.y != rhs, lhs.z != rhs); }

        /// <summary>
        /// Returns the result of a componentwise not equal operation on a double value and a double3 vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (double lhs, double3 rhs) { return new bool3 (lhs != rhs.x, lhs != rhs.y, lhs != rhs.z); }




        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, x, x, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, x, x, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, x, x, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, x, y, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, x, y, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, x, y, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, x, z, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, x, z, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, x, z, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, y, x, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, y, x, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, y, x, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, y, y, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, y, y, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, y, y, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, y, z, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, y, z, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, y, z, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, z, x, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, z, x, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, z, x, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, z, y, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, z, y, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, z, y, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, z, z, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, z, z, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 xzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(x, z, z, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, x, x, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, x, x, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, x, x, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, x, y, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, x, y, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, x, y, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, x, z, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, x, z, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, x, z, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, y, x, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, y, x, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, y, x, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, y, y, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, y, y, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, y, y, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, y, z, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, y, z, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, y, z, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, z, x, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, z, x, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, z, x, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, z, y, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, z, y, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, z, y, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, z, z, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, z, z, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 yzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(y, z, z, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, x, x, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, x, x, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, x, x, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, x, y, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, x, y, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, x, y, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, x, z, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, x, z, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, x, z, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, y, x, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, y, x, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, y, x, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, y, y, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, y, y, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, y, y, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, y, z, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, y, z, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, y, z, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, z, x, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, z, x, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, z, x, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, z, y, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, z, y, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, z, y, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, z, z, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, z, z, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double4 zzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double4(z, z, z, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(x, x, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(x, x, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 xxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(x, x, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(x, y, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(x, y, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 xyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(x, y, z); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { x = value.x; y = value.y; z = value.z; }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 xzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(x, z, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 xzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(x, z, y); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { x = value.x; z = value.y; y = value.z; }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 xzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(x, z, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(y, x, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(y, x, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 yxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(y, x, z); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { y = value.x; x = value.y; z = value.z; }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(y, y, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(y, y, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 yyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(y, y, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 yzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(y, z, x); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { y = value.x; z = value.y; x = value.z; }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 yzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(y, z, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 yzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(y, z, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 zxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(z, x, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 zxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(z, x, y); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { z = value.x; x = value.y; y = value.z; }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 zxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(z, x, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 zyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(z, y, x); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { z = value.x; y = value.y; x = value.z; }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 zyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(z, y, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 zyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(z, y, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 zzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(z, z, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 zzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(z, z, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double3 zzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double3(z, z, z); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double2(x, x); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double2(x, y); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { x = value.x; y = value.y; }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double2 xz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double2(x, z); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { x = value.x; z = value.y; }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double2(y, x); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { y = value.x; x = value.y; }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double2 yy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double2(y, y); }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double2 yz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double2(y, z); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { y = value.x; z = value.y; }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double2 zx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double2(z, x); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { z = value.x; x = value.y; }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double2 zy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double2(z, y); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { z = value.x; y = value.y; }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public double2 zz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new double2(z, z); }
        }



        /// <summary>
        /// Returns the double element at a specified index.
        /// </summary>
        unsafe public double this[int index]
        {
            get
            {
#if ENABLE_RASTER_COLLECTIONS_CHECKS
                if ((uint)index >= 3)
                    throw new System.ArgumentException("index must be between[0...2]");
#endif
                fixed (double3* array = &this) { return ((double*)array)[index]; }
            }
            set
            {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                if ((uint)index >= 3)
                    throw new System.ArgumentException("index must be between[0...2]");
#endif
                fixed (double* array = &x) { array[index] = value; }
            }
        }

        /// <summary>
        /// Returns true if the double3 is equal to a given double3, false otherwise.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(double3 rhs) { return x == rhs.x && y == rhs.y && z == rhs.z; }

        /// <summary>
        /// Returns true if the double3 is equal to a given double3, false otherwise.
        /// </summary>
        public override bool Equals(object o) { return Equals((double3)o); }


        /// <summary>
        /// Returns a hash code for the double3.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() { return (int)math.hash(this); }


        /// <summary>
        /// Returns a string representation of the double3.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("double3({0}, {1}, {2})", x, y, z);
        }

        /// <summary>
        /// Returns a string representation of the double3 using a specified format and culture-specific format information.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("double3({0}, {1}, {2})", x.ToString(format, formatProvider), y.ToString(format, formatProvider), z.ToString(format, formatProvider));
        }

        internal sealed class DebuggerProxy
        {
            public double x;
            public double y;
            public double z;
            public DebuggerProxy(double3 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
            }
        }

    }

    public static partial class math
    {
        /// <summary>
        /// Returns a double3 vector constructed from three double values.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 double3(double x, double y, double z) { return new double3(x, y, z); }

        /// <summary>
        /// Returns a double3 vector constructed from a double value and a double2 vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 double3(double x, double2 yz) { return new double3(x, yz); }

        /// <summary>
        /// Returns a double3 vector constructed from a double2 vector and a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 double3(double2 xy, double z) { return new double3(xy, z); }

        /// <summary>
        /// Returns a double3 vector constructed from a double3 vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 double3(double3 xyz) { return new double3(xyz); }

        /// <summary>
        /// Returns a double3 vector constructed from a single double value by assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 double3(double v) { return new double3(v); }

        /// <summary>
        /// Returns a double3 vector constructed from a single bool value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 double3(bool v) { return new double3(v); }

        /// <summary>
        /// Return a double3 vector constructed from a bool3 vector by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 double3(bool3 v) { return new double3(v); }

        /// <summary>
        /// Returns a double3 vector constructed from a single int value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 double3(int v) { return new double3(v); }

        /// <summary>
        /// Return a double3 vector constructed from a int3 vector by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 double3(int3 v) { return new double3(v); }

        /// <summary>
        /// Returns a double3 vector constructed from a single uint value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 double3(uint v) { return new double3(v); }

        /// <summary>
        /// Return a double3 vector constructed from a uint3 vector by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 double3(uint3 v) { return new double3(v); }

        /// <summary>
        /// Returns a double3 vector constructed from a single half value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 double3(half v) { return new double3(v); }

        /// <summary>
        /// Return a double3 vector constructed from a half3 vector by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 double3(half3 v) { return new double3(v); }

        /// <summary>
        /// Returns a double3 vector constructed from a single float value by converting it to double and assigning it to every component.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 double3(float v) { return new double3(v); }

        /// <summary>
        /// Return a double3 vector constructed from a float3 vector by componentwise conversion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 double3(float3 v) { return new double3(v); }

        /// <summary>Returns a uint hash code of a double3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(double3 v)
        {
            return csum(fold_to_uint(v) * uint3(0xAF0F3103u, 0xE4A056C7u, 0x841D8225u)) + 0xC9393C7Du;
        }

        /// <summary>
        /// Returns a uint3 vector hash code of a double3 vector.
        /// When multiple elements are to be hashes together, it can more efficient to calculate and combine wide hash
        /// that are only reduced to a narrow uint hash at the very end instead of at every step.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 hashwide(double3 v)
        {
            return (fold_to_uint(v) * uint3(0xD42EAFA3u, 0xD9AFD06Du, 0x97A65421u)) + 0x7809205Fu;
        }

        /// <summary>
        /// Returns the result of specified shuffling of the components from two double3 vectors into a double value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double shuffle(double3 a, double3 b, ShuffleComponent x)
        {
            return select_shuffle_component(a, b, x);
        }

        /// <summary>
        /// Returns the result of specified shuffling of the components from two double3 vectors into a double2 vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 shuffle(double3 a, double3 b, ShuffleComponent x, ShuffleComponent y)
        {
            return double2(
                select_shuffle_component(a, b, x),
                select_shuffle_component(a, b, y));
        }

        /// <summary>
        /// Returns the result of specified shuffling of the components from two double3 vectors into a double3 vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 shuffle(double3 a, double3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return double3(
                select_shuffle_component(a, b, x),
                select_shuffle_component(a, b, y),
                select_shuffle_component(a, b, z));
        }

        /// <summary>
        /// Returns the result of specified shuffling of the components from two double3 vectors into a double4 vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 shuffle(double3 a, double3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return double4(
                select_shuffle_component(a, b, x),
                select_shuffle_component(a, b, y),
                select_shuffle_component(a, b, z),
                select_shuffle_component(a, b, w));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double select_shuffle_component(double3 a, double3 b, ShuffleComponent component)
        {
            switch(component)
            {
                case ShuffleComponent.LeftX:
                    return a.x;
                case ShuffleComponent.LeftY:
                    return a.y;
                case ShuffleComponent.LeftZ:
                    return a.z;
                case ShuffleComponent.RightX:
                    return b.x;
                case ShuffleComponent.RightY:
                    return b.y;
                case ShuffleComponent.RightZ:
                    return b.z;
                default:
                    throw new System.ArgumentException("Invalid shuffle component: " + component);
            }
        }

    }
}
