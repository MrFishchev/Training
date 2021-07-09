using BenchmarkDotNet.Running;

namespace ValueTask.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmarks>();
        }
    }
}
