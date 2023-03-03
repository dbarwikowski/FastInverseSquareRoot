using BenchmarkDotNet.Attributes;


namespace FastInverseSquareRoot.Benchmarks
{
    [MarkdownExporter, HtmlExporter]
    public class Benchmarks
    {
        private Random random;
        private const int N = 1_000_000;
        private List<float> data;

        public Benchmarks()
        {
            data = new List<float>();
            random = new Random();
            
            for(int i = 0; i < N; i++)
            {
                data.Add(NextFloat(0.0001f, float.MaxValue));
            }
        }

        [Benchmark(Baseline = true)]
        public List<float> float_standard()
        {
            var result = new List<float>();
            foreach(float value in data)
            {
                result.Add(1f / MathF.Sqrt(value));
            }

            return result;
        }

        [Benchmark]
        public List<float> float_FastInverseSqrt()
        {
            var result = new List<float>();
            foreach (float value in data)
            {
                result.Add(value.FastInverseSqrt());
            }

            return result;
        }

        private float NextFloat(float min, float max)
        {
            double val = (random.NextDouble() * (max - min) + min);
            return (float)val;
        }

    }
}
