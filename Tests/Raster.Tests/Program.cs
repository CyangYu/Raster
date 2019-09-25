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

            Console.WriteLine(quaternion.ToString());
        }
    }
}
