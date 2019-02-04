using System;
using System.Runtime.CompilerServices;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct EulerAngles : IEquatable<EulerAngles>
    {
		#region Public Fields
        /// <summary>
        /// 
        /// </summary>
        public float Pitch;
        /// <summary>
        /// 
        /// </summary>
        public float Roll;
        /// <summary>
        /// 
        /// </summary>
        public float Yaw;
		#endregion Public Fields
		
		#region Constructor
        public EulerAngles(Vector3 vec3)
            : this(vec3.X, vec3.Y, vec3.Z)
        {
        }
		
		public EulerAngles(in EulerAngles euler)
			: this(euler.Pitch, euler.Roll, euler.Yaw)
		{
		}
		
        public EulerAngles(float pitch, float roll, float yaw)
        {
            Pitch = pitch;
            Roll  = roll;
            Yaw   = yaw;
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
            if (obj is EulerAngles)
            {
                return Equals((EulerAngles)obj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override string ToString() =>
            string.Format("EulerAngles: Pitch = {0}, Roll = {1}, Yaw = {2}", Pitch, Roll, Yaw);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(EulerAngles other) => this == other;

        #endregion Public Instance Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="w"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static EulerAngles FromQuaternion(float w, float x, float y, float z)
        {
            EulerAngles euler = new EulerAngles(0.0f, 0.0f, 0.0f);
            return euler;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quat"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static EulerAngles FromQuaternion(in Quaternion quat)
        {
            return FromQuaternion(quat.W, quat.X, quat.Y, quat.Z);
        }

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in EulerAngles left, in EulerAngles right) =>
            left.Pitch == right.Pitch && left.Roll == right.Roll && left.Yaw == right.Yaw;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in EulerAngles left, in EulerAngles right) =>
           left.Pitch != right.Pitch || left.Roll != right.Roll || left.Yaw != right.Yaw;

        #endregion Operator Overload
    }
}
