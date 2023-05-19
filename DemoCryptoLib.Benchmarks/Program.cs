using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using DemoCryptoLib.Benchmarks;

ManualConfig config = DefaultConfig.Instance
    .AddDiagnoser(MemoryDiagnoser.Default)
    .AddColumnProvider(DefaultColumnProviders.Instance)
    .AddJob(Job.Default
        .WithGcServer(true)
        .WithGcConcurrent(true)
    );

Summary summary = BenchmarkRunner.Run<PasswordHashGeneratorBenchmark>(config);