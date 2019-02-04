using System;
using System.Runtime.CompilerServices;
using Raster.Private;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct Quaternion : IEquatable<Quaternion>
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
        #endregion Public Fields

        #region Public Static Properties
        /// <summary>
        /// 
        /// </summary>
        public static readonly Quaternion Identity = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);

        #endregion Public Static Properties
		
        public Quaternion Conjugated
        {
            get { return new Quaternion(-X, -Y, -Z, W); }
        }
		
		#region Constructor
		public Quaternion(in Quaternion quat)
			: this(quat.X, quat.Y, quat.Z, quat.W)
		{
		}
		
		public Quaternion(in Vector4 vec4)
			: this(vec4.X, vec4.Y, vec4.Z, vec4.W)
		{
		}
		
        public Quaternion(float x, float y, float z, float w)
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
            if (obj is Quaternion)
            {
                return Equals((Quaternion)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash1 = HashHelpers.Combine(X.GetHashCode(), Y.GetHashCode());
            int hash2 = HashHelpers.Combine(Z.GetHashCode(), W.GetHashCode());
            return HashHelpers.Combine(hash1, hash2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            string.Format("Quaternion: X = {0}, Y = [1}, Z = {2}, W = {3} ", X, Y, Z, W);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Quaternion other) => this == other;
        /// <summary>
        /// 
        /// </summary>
        public void Conjugate() => W = -W;

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion FromAxisAngle(in Vector3 axis, float angle)
        {
            Quaternion quaternion = new Quaternion();
            return quaternion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pitch"></param>
        /// <param name="roll"></param>
        /// <param name="yaw"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion FromEulerAngles(float pitch, float roll, float yaw)
        {
            Quaternion quaternion = new Quaternion();
            return quaternion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion FromRotationMatrix(Matrix4x4 matrix)
        {
            Quaternion quaternion = new Quaternion();
            return quaternion;
        }


        #endregion Public Static Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="q1"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in Quaternion left, in Quaternion right) => 
            left.X == right.X && left.Y == right.Y && left.Z == right.Z && left.W == right.W;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="q1"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in Quaternion left, in Quaternion right) =>
			left.X != right.X || left.Y != right.Y || left.Z != right.Z || left.W != right.W ;

        #endregion Operator Overload                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
    }
}
