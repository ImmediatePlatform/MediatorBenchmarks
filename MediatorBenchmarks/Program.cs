#if RELEASE && NET10_0
using System.Reflection;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using RhoMicro.BdnLogging;

BenchmarkRunner.Run(
	Assembly.GetExecutingAssembly(),
	SpotlightConfig.Instance
		.HideColumns(["Job", "StdDev", "RatioSD", "Alloc Ratio"])
);

#elif !RELEASE
// TODO: Add code for unit testing
Console.WriteLine("Benchmarks must be run in `RELEASE`");

#elif !NET10_0
Console.WriteLine("Benchmarks must be run in `net10.0`");

#endif
