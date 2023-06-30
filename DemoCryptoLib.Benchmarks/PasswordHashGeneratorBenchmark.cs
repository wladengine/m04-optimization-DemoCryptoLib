using BenchmarkDotNet.Attributes;
using System.Text;

namespace DemoCryptoLib.Benchmarks;

public class PasswordHashGeneratorBenchmark
{
    [Params(100, 1000, 10000)]
    public int IterationCount;

    const string password = "dummyPassword";
    readonly byte[] salt = Encoding.UTF8.GetBytes("dummySalt01234567890");

    [Benchmark(Baseline = true)]
    public string Base()
    {
        return DemoCryptoLib.GeneratePasswordHashUsingSalt(password, salt);
    }

    [Benchmark]
    public string Optimized()
    {
        return DemoCryptoLib.GeneratePasswordHashUsingSaltOptimized(password, salt);
    }
}