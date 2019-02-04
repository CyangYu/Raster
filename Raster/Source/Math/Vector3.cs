using System;
using System.Runtime.CompilerServices;
using Raster.Drawing;
using Raster.Private;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct Vector3
    {
        #region Public Fields
        /// <summary>
        /// 
        /// </summary>
        public float X;
        /// <summary>
        /// 
        /// </summary>
        public float Y;
        /// <summary>
        /// 
        /// </summary>
        public float Z;
        #endregion Public Fields

        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector3 Zero     = new Vector3( 0.0f,  0.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector3 Unit     = new Vector3( 1.0f,  1.0f,  1.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector3 UnitX    = new Vector3( 1.0f,  0.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector3 UnitY    = new Vector3( 0.0f,  1.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector3 UnitZ    = new Vector3( 0.0f,  0.0f,  1.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector3 NegUnit  = new Vector3(-1.0f, -1.0f, -1.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector3 NegUnitX = new Vector3(-1.0f,  0.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector3 NegUnitY = new Vector3( 0.0f, -1.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector3 NegUnitZ = new Vector3( 0.0f,  0.0f, -1.0f);
        #endregion Public Static Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public float Length
        {
            get
            {
                return MathF.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float LengthSquared
        {
            get
            {
                return X * X + Y * Y + Z * Z;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 MidPoint
        {
            get
            {
                return new Vector3(X / 2.0f, Y / 2.0f, Z / 2.0f);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Normalized
        {
            get
            {
                float len = X * X + Y * Y + Z * Z;
                if (len == 0.0f)
                {
                    return Vector3.Zero;
                }

                float inv = 1.0f / MathF.Sqrt(len);
                return new Vector3(X * inv, Y * inv, Z * inv);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 Inverted
        {
            get
            {
                float x = X != 0.0f ? 1.0f / X : 0.0f;
                float y = Y != 0.0f ? 1.0f / Y : 0.0f;
                float z = Z != 0.0f ? 1.0f / Z : 0.0f;
                return new Vector3(x, y, z);
            }
        }

        #endregion Public Instance Properties

        #region Constructor
        public Vector3(float value)
            : this(value, value, value)
        {
        }

        public Vector3(in Vector3 other)
            : this(other.X, other.Y, other.Z)
        {
        }

        public Vector3(in Vector2 vec2, float z)
            : this(vec2.X, vec2.Y, z)
        {
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        #endregion Constructor

        #region Public Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector3)
            {
                return Equals((Vector3)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = this.X.GetHashCode();
            hash = HashHelpers.Combine(hash, this.Y.GetHashCode());
            hash = HashHelpers.Combine(hash, this.Y.GetHashCode());
            return hash;
        }


        public override string ToString() =>
            string.Format("Vector3: X = {0}, Y = [1}, Z = {2}", X, Y, Z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vector3 other) =>
             X == other.X && Y == other.Y && Z == other.Z;

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Inverse()
        {
            if (X != 0.0f)
                X = 1.0f / X;

            if (Y != 0.0f)
                Y = 1.0f / Y;

            if (Z != 0.0f)
                Z = 1.0f / Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="view"></param>
        /// <param name="projection"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3 Project(Matrix4x4 model, Matrix4x4 view, Matrix4x4 projection, Rectangle rect)
        {
            Matrix4x4 tempMatrix = new Matrix4x4(0.0f);
            Matrix4x4.Multiply(projection, view, out tempMatrix);

            return Vector3.Unit;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="view"></param>
        /// <param name="projection"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3 Unproject(Matrix4x4 model, Matrix4x4 view, Matrix4x4 projection, Rectangle rect)
        {
            return Vector3.Unit;
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Normalize()
        {
            float lenSqr = X * X + Y * Y + Z * Z;

            if (lenSqr == 1.0f)
                return;

            float len = MathF.Sqrt(lenSqr);

            if (len != 0.0f)
            {
                float invLen = 1.0f / len;
                X *= invLen;
                Y *= invLen;
                Z *= invLen;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3 Perpendicular()
        {
            const float square_zero = (float)(1e-6 * 1e-6);
            Vector3 perp = Vector3.Cross(this, Vector3.UnitX);

            if (perp.LengthSquared < square_zero)
                perp = Vector3.Cross(this, Vector3.UnitY);

            perp.Normalize();
            return perp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 ToVector2() => new Vector2(X, Y);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4 ToVector4() => new Vector4(X, Y, Z, 1.0f);

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AngleBetween(in Vector3 left, in Vector3 right)
        {
            float dot = left.X * right.X + left.Y * right.Y + left.Z * right.Z;
            float lenA = left.Length;
            float lenB = right.Length;

            if (lenA == 0.0f || lenB == 0.0f)
                return 0.0f;

            return dot / (lenA * lenB);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Clamp(in Vector3 value1, in Vector3 min, in Vector3 max)
        {
            float x = value1.X;
            x = (min.X > x) ? min.X : x;
            x = (max.X < x) ? max.X : x;

            float y = value1.Y;
            y = (min.Y > y) ? min.Y : y;
            y = (max.Y < y) ? max.Y : y;

            float z = value1.Z;
            z = (min.Z > z) ? min.Z : z;
            z = (max.Z < z) ? max.Z : z;

            return new Vector3(x, y, z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Cross(in Vector3 left, in Vector3 right)
        {
            return new Vector3(left.Y * right.Z - left.Z * right.Y,
                               left.X * right.Z - left.Z * right.X,
                               left.X * right.Y - left.Y * right.X);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Distance(in Vector3 value1, in Vector3 value2)
        {
            float dx = value1.X - value2.X;
            float dy = value1.Y - value2.Y;
            float dz = value1.Z - value2.Z;
            return MathF.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float DistanceSquared(in Vector3 value1, in Vector3 value2)
        {
            float dx = value1.X - value2.X;
            float dy = value1.Y - value2.Y;
            float dz = value1.Z - value2.Z;
            return dx * dx + dy * dy + dz * dz;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(in Vector3 left, in Vector3 right) =>
            left.X * right.X + left.Y * right.Y + left.Z * right.Z;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Lerp(in Vector3 begin, in Vector3 end, float factor) =>
            new Vector3(begin.X + (end.X - begin.X) * factor,
                        begin.Y + (end.Y - begin.Y) * factor,
                        begin.Z + (end.Z - begin.Z) * factor);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Min(in Vector3 value1, in Vector3 value2)
        {
            return new Vector3(
                (value1.X < value2.X) ? value1.X : value2.X,
                (value1.Y < value2.Y) ? value1.Y : value2.Y,
                (value1.Z < value2.Z) ? value1.Z : value2.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Max(in Vector3 value1, in Vector3 value2)
        {
            return new Vector3(
                (value1.X > value2.X) ? value1.X : value2.X,
                (value1.Y > value2.Y) ? value1.Y : value2.Y,
                (value1.Z > value2.Z) ? value1.Z : value2.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Transform(in Vector3 position, in Matrix4x4 matrix)
        {
            return new Vector3(
                position.X * matrix.M00 + position.Y * matrix.M10 + position.Z * matrix.M20 + matrix.M30,
                position.Y * matrix.M01 + position.Y * matrix.M11 + position.Z * matrix.M21 + matrix.M31,
                position.Z * matrix.M02 + position.Y * matrix.M12 + position.Z * matrix.M22 + matrix.M32);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 TransformNormal(in Vector3 normal, in Matrix4x4 matrix)
        {
            return new Vector3(
                normal.X * matrix.M00 + normal.Y * matrix.M10 + normal.Z * matrix.M20 + matrix.M30,
                normal.Y * matrix.M01 + normal.Y * matrix.M11 + normal.Z * matrix.M21 + matrix.M31,
                normal.Z * matrix.M02 + normal.Y * matrix.M12 + normal.Z * matrix.M22 + matrix.M32);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Transform(in Vector3 position, in Quaternion rotation)
        {
            float x2 = rotation.X + rotation.X;
            float y2 = rotation.Y + rotation.Y;
            float z2 = rotation.Z + rotation.Z;

            float wx2 = rotation.W * x2;
            float wy2 = rotation.W * y2;
            float wz2 = rotation.W * z2;
            float xx2 = rotation.X * x2;
            float xy2 = rotation.X * y2;
            float xz2 = rotation.X * z2;
            float yy2 = rotation.Y * y2;
            float yz2 = rotation.Y * z2;
            float zz2 = rotation.Z * z2;

            return new Vector3(
                position.X * (1.0f - yy2 - zz2) + position.Y * (xy2 - wz2) + position.Z * (xz2 + wy2),
                position.X * (xy2 + wz2) + position.Y * (1.0f - xx2 - zz2) + position.Z * (yz2 - wx2),
                position.X * (xz2 - wy2) + position.Y * (yz2 + wx2) + position.Z * (1.0f - xx2 - yy2));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec2"></param>
        /// <param name="normal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Reflect(in Vector3 vec3, in Vector3 normal)
        {
            float dot = vec3.X + normal.X + vec3.Y * normal.Y + vec3.Z * normal.Z;
            return new Vector3(vec3.X - 2.0f * dot * normal.X,
                               vec3.Y - 2.0f * dot * normal.Y,
                               vec3.Z - 2.0f * dot * normal.Z);
        }

        #endregion Public Static Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator +(in Vector3 left, in Vector3 right) =>
            new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator -(in Vector3 left, in Vector3 right) =>
            new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="right"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator *(float left, in Vector3 right) =>
            new Vector3(left * right.X, left * right.Y, left * right.Z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator *(in Vector3 left, float right) =>
            new Vector3(left.X * right, left.Y * right, left.Z * right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator *(in Vector3 left, in Vector3 right) =>
            new Vector3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator /(in Vector3 left, in Vector3 right)
        {
            if (right.X == 0.0f || right.Y == 0.0f || right.Z == 0.0f)
                throw new DivideByZeroException("b contain zero component");

            return new Vector3(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator /(in Vector3 left, float right)
        {
            if (right == 0.0f)
                throw new DivideByZeroException("right is zero");

            return new Vector3(left.X / right, left.Y / right, left.Z / right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(in Vector3 left, in Vector3 right) =>
             left.X == right.X && left.Y == right.Y && left.Z == right.Z;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(in Vector3 left, in Vector3 right) =>
            left.X != right.X || left.Y != right.Y || left.Z != right.Z;

        #endregion Operator Overload   
    }
}
