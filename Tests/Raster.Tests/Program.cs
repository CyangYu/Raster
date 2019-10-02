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

            EulerAngles eulerAngles = new EulerAngles(90.0f * MathF.Deg2Rad, 0.0f, 0.0f);
            Quaternion.FromEulerAnglesZXY(eulerAngles, out Quaternion rotation);

            Vector3 translation = new Vector3(10.0f, 10.0f, 10.0f);
            Vector3 scale = new Vector3(0.5f, 1.0f, 1.5f);

            Matrix4x4 matrix = new Matrix4x4(translation, rotation, scale);
            matrix.ExtractTranslationAndRotation(out translation, out rotation, out scale);

            EulerAngles.FromQuaternion(in rotation, out eulerAngles);
            eulerAngles.RadianToDegree();

            Console.WriteLine(translation);
            Console.WriteLine(eulerAngles);
            Console.WriteLine(scale);

            stopwatch.Stop();
        }
    }
}
