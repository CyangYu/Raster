using System;
using System.Diagnostics;

namespace Raster.Tests
{
    using Raster.Math;
    
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            EulerAngles eulerAngles = new EulerAngles(MathF.DegToRad(270.0f), 0.0f, 0.0f);
            Quaternion quaternion = Quaternion.FromEulerAnglesZYX(eulerAngles);

            Matrix3x3 rot3x3 = new Matrix3x3(0.98757f, 0.0f, -0.49379f,
                                             0.0f,      0.0f,  1.0f,
                                             0.0f,     -1.0f,  0.0f);


            float len0 = rot3x3.Column0.Length;
            rot3x3.M00 /= len0;

            float len2 = rot3x3.Column2.Length;
            rot3x3.M02 /= len2;
            rot3x3.M22 /= len2;

            EulerAngles.FromRotationMatrixToZXY(rot3x3, out eulerAngles);

            Console.WriteLine(eulerAngles);
            Console.WriteLine(quaternion);

            stopwatch.Stop();
        }
    }
}
