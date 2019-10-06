using System;
using System.Runtime.InteropServices;

namespace Raster.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct LineSegment : IEquatable<LineSegment>
    {
        #region Public Instance Fields
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Start;
        /// <summary>
        /// 
        /// </summary>
        public Vector3 End;
        #endregion Public Instance Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Direction
        {
            get
            {
                Vector3.Subtract(End, Start, out Vector3 direction);
                direction.Normalize();
                return direction;
            }
        }
        #endregion Public Instance Properties

        #region Public Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is LineSegment)
            {
                return Equals((LineSegment)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("LineSegment: Start = {{ X = {0}, Y = {1}, Z = {2} }; End = {{ X = {3}, Y = {4}, Z = {5} }",
                                 Start.X, Start.Y, Start.Z, End.X, End.Y, End.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(LineSegment other)
        {
            return this.Start.X == other.Start.X &&
                   this.End == other.End;
        }

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="distance"></param>
        /// <param name="result"></param>
        public static void PointAt(in LineSegment segment, float distance, out Vector3 result)
        {
            result.X = segment.Start.X + (segment.End.X - segment.Start.X) * distance;
            result.Y = segment.Start.Y + (segment.End.Y - segment.Start.Y) * distance;
            result.Z = segment.Start.Z + (segment.End.Z - segment.Start.Z) * distance;
        }

        #endregion Public Static Methods

        #region Operator Overload
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(in LineSegment left, in LineSegment right)
        {
            return left.Start == right.Start &&
                   left.End == right.End;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(in LineSegment left, in LineSegment right)
        {
            return left.Start != right.Start ||
                   left.End != right.End;
        }
        #endregion Operator Overload
    }
}
