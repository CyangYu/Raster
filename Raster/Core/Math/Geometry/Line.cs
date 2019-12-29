using System;
using System.Runtime.InteropServices;

namespace Raster.Core.Math.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Line : IEquatable<Line>
    {
        #region Public Fields
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Origin;
        /// <summary>
        /// 
        /// </summary>
        public Vector3 Direction;
        #endregion Public Fields

        #region Public Instance Fields
        /// <summary>
        /// 
        /// </summary>
        public bool IsInfinity
        {
            get { return Origin.IsInfinity; }
        }

        #endregion Public Instance Fields

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="direction"></param>
        public Line(in Vector3 origin, in Vector3 direction)
        {
            Origin = origin;
            Direction = direction;
            Direction.Normalize();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        public Line(in Line line)
            : this(line.Origin, line.Direction)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        public Line(in LineSegment segment)
            : this(segment.Start, segment.Direction)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        public Line(in Ray ray)
            : this(ray.Origin, ray.Direction)
        {
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
            if (obj is Ray)
            {
                return Equals((Ray)obj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Ray: Origin X = {0}, Y = {1}, Z = {2}; Direction: X = {3}, Y = {4}, Z = {5}",
                                 Origin.X, Origin.Y, Origin.Z, Direction.X, Direction.Y, Direction.Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Line other)
        {
            return this.Origin == other.Origin &&
                   this.Direction == other.Direction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Vector3 ClosetPoint(in Vector3 point)
        {
            Collision.ClosetPointPointLine(point, this, out float distance, out Vector3 result);
            return result;
        }

        #endregion Public Instance Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static void PointAt(in Line line, float distance, out Vector3 result)
        {
            result.X = line.Origin.X + distance * line.Direction.X;
            result.Y = line.Origin.Y + distance * line.Direction.Y;
            result.Z = line.Origin.Z + distance * line.Direction.Z;
        }

        #endregion Public Static Methods
    }
}
