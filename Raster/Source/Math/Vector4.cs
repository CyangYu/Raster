using System;
using System.Runtime.CompilerServices;
using Raster.Private;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct Vector4 : IEquatable<Vector4>
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
        /// <summary>
        /// 
        /// </summary>
        public float W;
        #endregion

        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 Zero     = new Vector4( 0.0f,  0.0f,  0.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 Unit     = new Vector4( 1.0f,  1.0f,  1.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 UnitX    = new Vector4( 1.0f,  0.0f,  0.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 UnitY    = new Vector4( 0.0f,  1.0f,  0.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 UnitZ    = new Vector4( 0.0f,  0.0f,  1.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 UnitW    = new Vector4( 0.0f,  0.0f,  0.0f,  1.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 NegUnit  = new Vector4(-1.0f, -1.0f, -1.0f, -1.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 NegUnitX = new Vector4(-1.0f,  0.0f,  0.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 NegUnitY = new Vector4( 0.0f, -1.0f,  0.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 NegUnitZ = new Vector4( 0.0f,  0.0f, -1.0f,  0.0f);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Vector4 NegUnitW = new Vector4( 0.0f,  0.0f,  0.0f, -1.0f);
        #endregion Public Static Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public float Length
        {
            get
            {
                return MathF.Sqrt(LengthSquared);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float LengthSquared
        {
            get
            {
                return X * X + Y * Y + Z * Z + W * W;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector4 MidPoint
        {
            get
            {
                return new Vector4(X / 2.0f, Y / 2.0f, Z / 2.0f, W / 2.0f);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector4 Normalized
        {
            get
            {
                Vector4 ret = this;
                ret.Normalize();
                return ret;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector4 Inverted
        {
            get
            {
                Vector4 ret = this;
                ret.Inverse();
                return ret;
            }
        }
        #endregion Public Instance Properties

        #region Constructor
        public Vector4(float value)
            : this(value, value, value, value)
        {
        }

        public Vector4(in Vector4 other)
            : this(other.X, other.Y, other.Z, other.W)
        {
        }

        public Vector4(in Vector3 vec3, float w)
            : this(vec3.X, vec3.Y, vec3.Z, w)
        {
        }

        public Vector4(in Vector2 vec2, float z, float w)
            : this(vec2.X, vec2.Y, z, w)
        {
        }

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
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
            if (obj is Vector4)
            {
                return Equals((Vector4)obj);
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
            hash = HashHelpers.Combine(hash, this.Z.GetHashCode());
            hash = HashHelpers.Combine(hash, this.W.GetHashCode());
            return hash;
        }

        public override string ToString()
            => string.Format("Vector4: X = {0}, Y = [1}, Z = {2} W = {3}", X, Y, Z, W);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vector4 other) => this == other;

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

            if (W != 0.0f)
                W = 1.0f / W;
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Normalize()
        {
            if (LengthSquared == 1.0f)
                return;

            float length = Length;

            if (length == 0.0)
                return;

            float invLen = 1.0f / length;
            X *= invLen;
            Y *= invLen;
            Z *= invLen;
            W *= invLen;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3 ToVector3() => new Vector3(X, Y, Z);

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AngleBetween(in Vector4 left, in Vector4 right)
        {
            float dot = left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
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
        public static Vector4 Clamp(in Vector4 value1, in Vector4 min, in Vector4 max)
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

            float w = value1.W;
            z = (min.W > w) ? min.W : z;
            z = (max.W < w) ? max.W : z;

            return new Vector4(x, y, z, w);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Distance(in Vector4 value1, in Vector4 value2)
        {
            float dx = value1.X - value2.X;
            float dy = value1.Y - value2.Y;
            float dz = value1.Z - value2.Z;
            float dw = value1.W - value2.W;
            return MathF.Sqrt(dx * dx + dy * dy + dz * dz + dw * dw);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float DistanceSquared(in Vector4 value1, in Vector4 value2)
        {
            float dx = value1.X - value2.X;
            float dy = value1.Y - value2.Y;
            float dz = value1.Z - value2.Z;
            float dw = value1.W - value2.W;
            return dx * dx + dy * dy + dz * dz + dw * dw;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(in Vector4 left, in Vector4 right) =>
            left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Lerp(in Vector4 begin, in Vector4 end, float factor) =>
            new Vector4(begin.X + (end.X - begin.X) * factor,
                        begin.Y + (end.Y - begin.Y) * factor,
                        begin.Z + (end.Z - begin.Z) * factor,
                        begin.W + (end.W - begin.W) * factor);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Min(in Vector4 value1, in Vector4 value2)
        {
            return new Vector4(
                (value1.X < value2.X) ? value1.X : value2.X,
                (value1.Y < value2.Y) ? value1.Y : value2.Y,
                (value1.Z < value2.Z) ? value1.Z : value2.Z,
                (value1.W < value2.W) ? value1.W : value2.W);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Max(in Vector4 value1, in Vector4 value2)
        {
            return new Vector4(
                (value1.X > value2.X) ? value1.X : value2.X,
                (value1.Y > value2.Y) ? value1.Y : value2.Y,
                (value1.Z > value2.Z) ? value1.Z : value2.Z,
                (value1.W > value2.W) ? value1.W : value2.W);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Transform(in Vector2 position, in Matrix4x4 matrix)
        {
            return new Vector4(
                position.X * matrix.M00 + position.Y * matrix.M10 + matrix.M30,
                position.X * matrix.M01 + position.Y * matrix.M11 + matrix.M31,
                position.X * matrix.M02 + position.Y * matrix.M12 + matrix.M32,
                position.X * matrix.M03 + position.Y * matrix.M13 + matrix.M33);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Transform(in Vector3 position, in Matrix4x4 matrix)
        {
            return new Vector4(
                position.X * matrix.M00 + position.Y * matrix.M10 + position.Z * matrix.M20 + matrix.M30,
                position.X * matrix.M01 + position.Y * matrix.M11 + position.Z * matrix.M21 + matrix.M31,
                position.X * matrix.M02 + position.Y * matrix.M12 + position.Z * matrix.M22 + matrix.M32,
                position.X * matrix.M03 + position.Y * matrix.M13 + position.Z * matrix.M23 + matrix.M33);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Transform(in Vector4 position, in Matrix4x4 matrix)
        {
            return new Vector4(
               position.X * matrix.M00 + position.Y * matrix.M10 + position.Z * matrix.M20 + position.W * matrix.M30,
               position.X * matrix.M01 + position.Y * matrix.M11 + position.Z * matrix.M21 + position.W * matrix.M31,
               position.X * matrix.M02 + position.Y * matrix.M12 + position.Z * matrix.M22 + position.W * matrix.M32,
               position.X * matrix.M03 + position.Y * matrix.M13 + position.Z * matrix.M23 + position.W * matrix.M33);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Transform(in Vector2 position, in Quaternion rotation)
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

            return new Vector4(
                position.X * (1.0f - yy2 - zz2) + position.Y * (xy2 - wz2),
                position.X * (xy2 + wz2) + position.Y * (1.0f - xx2 - zz2),
                position.X * (xz2 - wy2) + position.Y * (yz2 + wx2),
                1.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Transform(in Vector3 position, in Quaternion rotation)
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

            return new Vector4(
                position.X * (1.0f - yy2 - zz2) + position.Y * (xy2 - wz2) + position.Z * (xz2 + wy2),
                position.X * (xy2 + wz2) + position.Y * (1.0f - xx2 - zz2) + position.Z * (yz2 - wx2),
                position.X * (xz2 - wy2) + position.Y * (yz2 + wx2) + position.Z * (1.0f - xx2 - yy2),
                1.0f);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Transform(in Vector4 position, in Quaternion rotation)
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

            return new Vector4(
                position.X * (1.0f - yy2 - zz2) + position.Y * (xy2 - wz2) + position.Z * (xz2 + wy2),
                position.X * (xy2 + wz2) + position.Y * (1.0f - xx2 - zz2) + position.Z * (yz2 - wx2),
                position.X * (xz2 - wy2) + position.Y * (yz2 + wx2) + position.Z * (1.0f - xx2 - yy2),
                position.W);
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
        public static Vector4 operator +(in Vector4 left, in Vector4 right) =>
            new Vector4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator -(in Vector4 left, in Vector4 right) =>
            new Vector4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator *(in Vector4 left, in Vector4 right) =>
             new Vector4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W + right.W);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator /(in Vector4 left, in Vector4 right)
        {
            if (right.X == 0.0f || right.Y == 0.0f || right.Z == 0.0f || right.W == 0.0f)
                throw new DivideByZeroException("b contain zero component");

            return new Vector4(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 operator /(in Vector4 left, float right)
        {
            if (right == 0.0f)
                throw new DivideByZeroException("right is zero");

            return new Vector4(left.X / right, left.Y / right, left.Z / right, left.W / right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(in Vector4 left, in Vector4 right) =>
             left.X == right.X && left.Y == right.Y && left.Z == right.Z && left.W == right.W;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(in Vector4 left, in Vector4 right) =>
            left.X != right.X || left.Y != right.Y || left.Z != right.Z || left.W != right.W;

        #endregion Operator Overload
    }
}
