using System;

namespace FastInverseSquareRoot
{
    public static class FloatExtenstions
    {
        private static float threehalfs = 1.5f;
        private static long magicNumber = 0x5f3759df;

        public static unsafe float FastInverseSqrt(this float number)
        {
            long i;
            float x2, y;

            x2 = number * 0.5f;
            y = number;
            i = *(long*)&y;                         // evil floating point bit hack
            i = magicNumber - (i >> 1);             // WTF?
            y = *(float*)&i;
            y = y * (threehalfs - (x2 * y * y));    // 1st iteration
            y = y * (threehalfs - (x2 * y * y));    // 2nd iteration, if removed diff is greater than 0.0001f
            return y;
        }
    }
}
