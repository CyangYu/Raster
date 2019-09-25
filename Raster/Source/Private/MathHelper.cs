using System;
using System.Runtime.CompilerServices;
using SysMath = System.Math;

namespace Raster.Math
{
    /// <summary>
    /// 
    /// </summary>
    public static class MathHelper
    {
        #region Private Static Fields
        /// <summary>
        /// 
        /// </summary>
        private const int SINE_TABLE_SIZE = 256;
        /// <summary>
        /// 
        /// </summary>
        private static float[] sine_table = new float[256]
        {
            0.0f,                   0.02454122852291228f,   0.04906767432741801f,   0.07356456359966742f,
            0.098017140329560604f,  0.1224106751992162f,    0.14673047445536175f,   0.17096188876030122f,
            0.19509032201612825f,   0.2191012401568698f,    0.24298017990326387f,   0.26671275747489837f,
            0.29028467725446233f,   0.31368174039889152f,   0.33688985339222005f,   0.35989503653498811f,
            0.38268343236508978f,   0.40524131400498986f,   0.42755509343028208f,   0.44961132965460654f,
            0.47139673682599764f,   0.49289819222978404f,   0.51410274419322166f,   0.53499761988709715f,
            0.55557023301960218f,   0.57580819141784534f,   0.59569930449243336f,   0.61523159058062682f,
            0.63439328416364549f,   0.65317284295377676f,   0.67155895484701833f,   0.68954054473706683f,
            0.70710678118654746f,   0.72424708295146689f,   0.74095112535495911f,   0.75720884650648446f,
            0.77301045336273699f,   0.78834642762660623f,   0.80320753148064483f,   0.81758481315158371f,
            0.83146961230254524f,   0.84485356524970701f,   0.85772861000027212f,   0.87008699110871135f,
            0.88192126434835494f,   0.89322430119551532f,   0.90398929312344334f,   0.91420975570353069f,
            0.92387953251128674f,   0.93299279883473885f,   0.94154406518302081f,   0.94952818059303667f,
            0.95694033573220894f,   0.96377606579543984f,   0.97003125319454397f,   0.97570213003852857f,
            0.98078528040323043f,   0.98527764238894122f,   0.98917650996478101f,   0.99247953459870997f,
            0.99518472667219682f,   0.99729045667869021f,   0.99879545620517241f,   0.99969881869620425f,
            1.0f,                   0.99969881869620425f,   0.99879545620517241f,   0.99729045667869021f,
            0.99518472667219693f,   0.99247953459870997f,   0.98917650996478101f,   0.98527764238894122f,
            0.98078528040323043f,   0.97570213003852857f,   0.97003125319454397f,   0.96377606579543984f,
            0.95694033573220894f,   0.94952818059303667f,   0.94154406518302081f,   0.93299279883473885f,
            0.92387953251128674f,   0.91420975570353069f,   0.90398929312344345f,   0.89322430119551521f,
            0.88192126434835505f,   0.87008699110871146f,   0.85772861000027212f,   0.84485356524970723f,
            0.83146961230254546f,   0.81758481315158371f,   0.80320753148064494f,   0.78834642762660634f,
            0.7730104533627371f,    0.75720884650648468f,   0.74095112535495899f,   0.72424708295146689f,
            0.70710678118654757f,   0.68954054473706705f,   0.67155895484701855f,   0.65317284295377664f,
            0.63439328416364549f,   0.61523159058062693f,   0.59569930449243347f,   0.57580819141784545f,
            0.55557023301960218f,   0.53499761988709715f,   0.51410274419322177f,   0.49289819222978415f,
            0.47139673682599786f,   0.44961132965460687f,   0.42755509343028203f,   0.40524131400498992f,
            0.38268343236508989f,   0.35989503653498833f,   0.33688985339222033f,   0.31368174039889141f,
            0.29028467725446239f,   0.26671275747489848f,   0.24298017990326407f,   0.21910124015687005f,
            0.19509032201612861f,   0.17096188876030122f,   0.1467304744553618f,    0.12241067519921635f,
            0.098017140329560826f,  0.07356456359966773f,   0.04906767432741796f,   0.02454122852291232f,
            0.0f,                  -0.02454122852291208f,  -0.04906767432741772f,  -0.07356456359966749f,
           -0.09801714032956059f,  -0.1224106751992161f,   -0.14673047445536158f,  -0.17096188876030097f,
           -0.19509032201612836f,  -0.2191012401568698f,   -0.24298017990326382f,  -0.26671275747489825f,
           -0.29028467725446211f,  -0.31368174039889118f,  -0.33688985339222011f,  -0.35989503653498811f,
           -0.38268343236508967f,  -0.40524131400498969f,  -0.42755509343028181f,  -0.44961132965460665f,
           -0.47139673682599764f,  -0.49289819222978393f,  -0.51410274419322155f,  -0.53499761988709693f,
           -0.55557023301960196f,  -0.57580819141784534f,  -0.59569930449243325f,  -0.61523159058062671f,
           -0.63439328416364527f,  -0.65317284295377653f,  -0.67155895484701844f,  -0.68954054473706683f,
           -0.70710678118654746f,  -0.72424708295146678f,  -0.74095112535495888f,  -0.75720884650648423f,
           -0.77301045336273666f,  -0.78834642762660589f,  -0.80320753148064505f,  -0.81758481315158382f,
           -0.83146961230254524f,  -0.84485356524970701f,  -0.85772861000027201f,  -0.87008699110871135f,
           -0.88192126434835494f,  -0.89322430119551521f,  -0.90398929312344312f,  -0.91420975570353047f,
           -0.92387953251128652f,  -0.93299279883473896f,  -0.94154406518302081f,  -0.94952818059303667f,
           -0.95694033573220882f,  -0.96377606579543984f,  -0.97003125319454397f,  -0.97570213003852846f,
           -0.98078528040323032f,  -0.98527764238894111f,  -0.9891765099647809f,   -0.99247953459871008f,
           -0.99518472667219693f,  -0.99729045667869021f,  -0.99879545620517241f,  -0.99969881869620425f,
           -1.0f,                  -0.9996988186962042f,   -0.99879545620517241f,  -0.9972904566786902f,
           -0.99518472667219693f,  -0.99247953459871008f,  -0.9891765099647809f,   -0.98527764238894122f,
           -0.98078528040323043f,  -0.97570213003852857f,  -0.97003125319454397f,  -0.96377606579543995f,
           -0.95694033573220894f,  -0.94952818059303679f,  -0.94154406518302092f,  -0.93299279883473907f,
           -0.92387953251128663f,  -0.91420975570353058f,  -0.90398929312344334f,  -0.89322430119551532f,
           -0.88192126434835505f,  -0.87008699110871146f,  -0.85772861000027223f,  -0.84485356524970723f,
           -0.83146961230254546f,  -0.81758481315158404f,  -0.80320753148064528f,  -0.78834642762660612f,
           -0.77301045336273688f,  -0.75720884650648457f,  -0.74095112535495911f,  -0.724247082951467f,
           -0.70710678118654768f,  -0.68954054473706716f,  -0.67155895484701866f,  -0.65317284295377709f,
           -0.63439328416364593f,  -0.61523159058062737f,  -0.59569930449243325f,  -0.57580819141784523f,
           -0.55557023301960218f,  -0.53499761988709726f,  -0.51410274419322188f,  -0.49289819222978426f,
           -0.47139673682599792f,  -0.44961132965460698f,  -0.42755509343028253f,  -0.40524131400499042f,
           -0.38268343236509039f,  -0.359895036534988f,    -0.33688985339222f,     -0.31368174039889152f,
           -0.2902846772544625f,   -0.26671275747489859f,  -0.24298017990326418f,  -0.21910124015687016f,
           -0.19509032201612872f,  -0.17096188876030177f,  -0.14673047445536239f,  -0.12241067519921603f,
           -0.09801714032956050f,  -0.07356456359966741f,  -0.04906767432741809f,  -0.02454122852291244f
        };

        #endregion Private Static Methods

        #region Public Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly float ZeroTolerance = 0.000001f;
        #endregion Public Static Fields

        #region Private Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private unsafe static int FloatToInt32Bits(float f) => *((int*)&f);
        
        #endregion Private Static Methods

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static long BinomialCoefficient(int n, int k)
        {
            return Factorial(n) / Factorial(k) * Factorial(n - k);
        }
            

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Factorial(int n)
        {
            long result = 1;

            for (; n > 1; n--)
            {
                result *= n;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rad"></param>
        /// <returns></returns>
        public static float FastSine(float rad)
        {
            int si = (int)(rad * (0.5f * SINE_TABLE_SIZE / MathF.PI));
            int ci = si + SINE_TABLE_SIZE / 4;
            float d = rad - si * (2.0f * MathF.PI / SINE_TABLE_SIZE);

            si &= SINE_TABLE_SIZE - 1;
            ci &= SINE_TABLE_SIZE - 1;
            return sine_table[si] + (sine_table[ci] - 0.5f * sine_table[si] * d) * d;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rad"></param>
        /// <returns></returns>
        public static float FastCosine(float rad)
        {
            int ci = (int)(rad * (0.5f * SINE_TABLE_SIZE / MathF.PI));
            int si = ci + SINE_TABLE_SIZE / 4;
            float d = rad - ci * (2.0f * MathF.PI / SINE_TABLE_SIZE);

            si &= SINE_TABLE_SIZE - 1;
            ci &= SINE_TABLE_SIZE - 1;
            return sine_table[si] + (sine_table[ci] - 0.5f * sine_table[si] * d) * d;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static float FastSqrtInverse(float f)
        {
            float xhalf = 0.5f * f;
            int i = *(int*)&f;
            i = 0x5f375a86 - (i >> 1);
            f = *(float*)&i;
            f = f * (1.5f - (xhalf * f * f));
            return f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amplitude"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="centerX"></param>
        /// <param name="centerY"></param>
        /// <param name="sigmaX"></param>
        /// <param name="sigmaY"></param>
        /// <returns></returns>
        public static float Gaussian(float amplitude, float x, float y, float centerX, float centerY, float sigmaX, float sigmaY) =>
            (float)Gaussian((float)amplitude, (float)x, (float)y, (float)centerX, (float)centerY, (float)sigmaX, (float)sigmaY);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amplitude"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="centerX"></param>
        /// <param name="Y"></param>
        /// <param name="sigmaX"></param>
        /// <param name="sigmaY"></param>
        /// <returns></returns>
        public static double Gaussian(double amplitude, double x, double y, double centerX, double centerY, double sigmaX, double sigmaY)
        {
            double cx = x - centerX;
            double cy = y - centerY;

            double componentX = (cx * cx) / (2.0f * sigmaX * sigmaX);
            double componentY = (cy * cy) / (2.0f * sigmaY * sigmaY);

            return amplitude * SysMath.Exp(-(componentX + componentY));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsZero(float num) => MathF.Abs(num) < ZeroTolerance;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOne(float num) => IsZero(num - 1.0f);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public unsafe static bool NearEqual(float a, float b)
        {
            if (IsZero(a - b))
            {
                return false;
            }

            int aInt = *(int*)&a;
            int bInt = *(int*)&b;

            if ((aInt < 0) != (bInt < 0))
            {
                return false;
            }

            int ulp = SysMath.Abs(aInt - bInt);

            const int maxUp = 4;
            return (ulp <= maxUp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int NextPowerOfTwo(int n) => 
            (int)NextPowerOfTwo((uint)n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long NextPowerOfTwo(long n) =>
            (long)NextPowerOfTwo((ulong)n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static uint NextPowerOfTwo(uint n)
        {
            n |= n >> 1;
            n |= n >> 2;
            n |= n >> 4;
            n |= n >> 8;
            n |= n >> 16;
            ++n;
            return n;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static ulong NextPowerOfTwo(ulong n)
        {
            n |= n >> 1;
            n |= n >> 2;
            n |= n >> 4;
            n |= n >> 8;
            n |= n >> 16;
            n |= n >> 32;
            ++n;
            return n;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float NextPowerOfTwo(float n) =>
            (float)SysMath.Pow(2.0, SysMath.Ceiling(SysMath.Log((double)n, 2.0)));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double NextPowerOfTwo(double n) =>
            (double)SysMath.Pow(2.0, SysMath.Ceiling(SysMath.Log(n, 2.0)));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Square(float num) => (float)(num * num);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(ref float a, ref float b)
        {
            float temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool WithinEpsilon(float a, float b, float epsilon)
        {
            float diff = a - b;
            return ((-epsilon <= diff) && (diff <= epsilon));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Wrap(int value, int min, int max)
        {
            int range_size = max - min + 1;

            if (value < min)
            {
                value += range_size * ((min - value) / range_size + 1);
            }

            return min + (value - min) % range_size;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float Wrap(float value, float min, float max)
        {
            if (NearEqual(min, max))
            {
                return min;
            }

            double mind = min;
            double maxd = max;
            double valued = value;

            double range_size = maxd - mind;
            return (float)(mind + (valued - mind) - (range_size * SysMath.Floor((valued - mind) / range_size)));
        }

        #endregion Public Static Methods
    }
}
