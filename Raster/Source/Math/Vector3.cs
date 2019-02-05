using System;
using System.Runtime.CompilerServices;
using Raster.Drawing.Primitive;
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
            get { return MathF.Sqrt(X * X + Y * Y + Z * Z); }
        }

        /// <summary>
        /// 
        /// </summary>
        public float LengthSquared
        {
            get { return X * X + Y * Y + Z * Z; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 MidPoint
        {
            get { return new Vector3(X / 2.0f, Y / 2.0f, Z / 2.0f); }
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
            hash = HashHelpers.Combine(hash, this.Z.GetHashCode());
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Normalize()
        {
            float lenSqr = X * X + Y * Y + Z * Z;
            float invNorm = MathHelper.QuickSqrtInv(lenSqr);

            X *= invNorm;
            Y *= invNorm;
            Z *= invNorm;
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
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Cross(in Vector3 value1, in Vector3 value2)
        {
            Vector3 result;
            Cross(value1, value2, out result);
            return result;
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
        /// <param name="value1"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Inverse(in Vector3 value)
        {
            Vector3 result;
            Inverse(value, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Lerp(in Vector3 begin, in Vector3 end, float factor)
        {
            Vector3 result;
            Lerp(begin, end, factor, out result);
            return result;
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
            Vector3 result;
            Max(value1, value2, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Min(in Vector3 value1, in Vector3 value2)
        {
            Vector3 result;
            Min(value1, value2, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Perpendicular(in Vector3 value)
        {
            Vector3 result;
            Perpendicular(value, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Normalize(in Vector3 value)
        {
            Vector3 result;
            Normalize(value, out result);
            return result;
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
            Vector3 result;
            Transform(position, matrix, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 TransformNormal(in Vector3 position, in Matrix4x4 matrix)
        {
            Vector3 result;
            TransformNormal(position, matrix, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Transform(in Vector3 position, in Quaternion rotation)
        {
            Vector3 result;
            Transform(position, rotation, out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec3"></param>
        /// <param name="normal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Reflect(in Vector3 vec3, in Vector3 normal)
        {
            Vector3 result;
            Reflect(vec3, normal, out result);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Clamp(in Vector3 value, in Vector3 min, in Vector3 max, out Vector3 result)
        {
            result.X = (min.X > value.X) ? min.X : value.X;
            result.X = (max.X < value.X) ? max.X : value.X;

            result.Y = (min.Y > value.Y) ? min.Y : value.Y;
            result.Y = (max.Y < value.Y) ? max.Y : value.Y;

            result.Z = (min.Z > value.Z) ? min.Z : value.Z;
            result.Z = (max.Z < value.Z) ? max.Z : value.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cross(in Vector3 value1, in Vector3 value2, out Vector3 result)
        {
            result.X = value1.Y * value2.Z - value1.Z * value2.Y;
            result.Y = value1.X * value2.Z - value1.Z * value2.X;
            result.Z = value1.X * value2.Y - value1.Y * value2.X;
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
        /// <param name="value"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Inverse(in Vector3 value, out Vector3 result)
        {
            float lenSqr = value.X * value.X + value.Y * value.Y +
                           value.Z * value.Z;
            float invNorm = 1.0f / lenSqr;

            result.X = value.X * invNorm;
            result.Y = value.Y * invNorm;
            result.Z = value.Z * invNorm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="factor"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Lerp(in Vector3 begin, in Vector3 end, float factor, out Vector3 result)
        {
            result.X = begin.X + (end.X - begin.X) * factor;
            result.Y = begin.Y + (end.Y - begin.Y) * factor;
            result.Z = begin.Z + (end.Z - begin.Z) * factor;
        }
                        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Min(in Vector3 value1, in Vector3 value2, out Vector3 result)
        {
            result.X = (value1.X < value2.X) ? value1.X : value2.X;
            result.Y = (value1.Y < value2.Y) ? value1.Y : value2.Y;
            result.Z = (value1.Z < value2.Z) ? value1.Z : value2.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Max(in Vector3 value1, in Vector3 value2, out Vector3 result)
        {
            result.X = (value1.X > value2.X) ? value1.X : value2.X;
            result.Y = (value1.Y > value2.Y) ? value1.Y : value2.Y;
            result.Z = (value1.Z > value2.Z) ? value1.Z : value2.Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Normalize(in Vector3 value, out Vector3 result)
        {
            float lenSqr = value.X * value.X + value.Y * value.Y +
                           value.Z * value.Z;
            float invNorm = MathHelper.QuickSqrtInv(lenSqr);

            result.X = value.X * invNorm;
            result.Y = value.Y * invNorm;
            result.Z = value.Z * invNorm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec3"></param>
        /// <param name="perp"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Perpendicular(in Vector3 vec3, out Vector3 result)
        {
            const float square_zero = (float)(1e-6 * 1e-6);

            // Cross perp with UnitX
            result.X = 0.0f;
            result.Y = -1.0f * vec3.Z;
            result.Z = -1.0f * vec3.Y;

            if (result.LengthSquared < square_zero)
            {
                // Cross perp with UnitY
                result.X = -1.0f * vec3.Z;
                result.Y = 0.0f;
                result.Z = 1.0f * vec3.X;
            }

            result.Normalize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Transform(in Vector3 position, in Matrix4x4 matrix, out Vector3 result)
        {
            result.X = position.X * matrix.M00 + position.Y * matrix.M10 + position.Z * matrix.M20 + matrix.M30;
            result.Y = position.Y * matrix.M01 + position.Y * matrix.M11 + position.Z * matrix.M21 + matrix.M31;
            result.Z = position.Z * matrix.M02 + position.Y * matrix.M12 + position.Z * matrix.M22 + matrix.M32;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="normal"></param>
        /// <param name="matrix"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TransformNormal(in Vector3 normal, in Matrix4x4 matrix, out Vector3 result)
        {
            result.X = normal.X * matrix.M00 + normal.Y * matrix.M10 + normal.Z * matrix.M20 + matrix.M30;
            result.Y = normal.Y * matrix.M01 + normal.Y * matrix.M11 + normal.Z * matrix.M21 + matrix.M31;
            result.Z = normal.Z * matrix.M02 + normal.Y * matrix.M12 + normal.Z * matrix.M22 + matrix.M32;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Transform(in Vector3 position, in Quaternion rotation, out Vector3 result)
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

            result.X = position.X * (1.0f - yy2 - zz2) + position.Y * (xy2 - wz2) + position.Z * (xz2 + wy2);
            result.Y = position.X * (xy2 + wz2) + position.Y * (1.0f - xx2 - zz2) + position.Z * (yz2 - wx2);
            result.Z = position.X * (xz2 - wy2) + position.Y * (yz2 + wx2) + position.Z * (1.0f - xx2 - yy2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec3"></param>
        /// <param name="normal"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Reflect(in Vector3 vec3, in Vector3 normal, out Vector3 result)
        {
            float dot = vec3.X + normal.X + vec3.Y * normal.Y + vec3.Z * normal.Z;
            result.X = vec3.X - 2.0f * dot * normal.X;
            result.Y = vec3.Y - 2.0f * dot * normal.Y;
            result.Z = vec3.Z - 2.0f * dot * normal.Z;
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
