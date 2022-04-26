using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FastInverseSquareRoot.UnitTests
{
    public class FloatTests
    {
        private const int N = 1_000_000;
        private List<float> data;

        [SetUp]
        public void Setup()
        {
            data = new List<float>();

            for(int i = 0; i < N; i++)
            {
                data.Add(NextFloat(0.0001f, float.MaxValue));
            }
        }

        static float NextFloat(float min, float max)
        {
            System.Random random = new System.Random();
            double val = (random.NextDouble() * (max - min) + min);
            return (float)val;
        }

        [Test]
        public void PrecisionTest()
        {
            foreach(var number in data)
            {
                var regular = 1 / MathF.Sqrt(number);
                var fast = number.FastInverseSqrt();
                var diff = MathF.Abs(regular - fast);

                Assert.True(diff < 0.0001f, "|{0} - {1}| = {2}", @regular, @fast, @diff);
            }
        }
    }
}