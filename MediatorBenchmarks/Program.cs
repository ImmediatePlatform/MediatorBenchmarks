#if RELEASE && NET10_0
using System.Reflection;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using MediatorBenchmarks.Support;
using RhoMicro.BdnLogging;

BenchmarkRunner.Run(
	Assembly.GetExecutingAssembly(),
	SpotlightConfig.Instance
		.HideColumns(["Job", "StdDev", "RatioSD", "Alloc Ratio"])
		.AddColumn(new ImplementationColumn())
		.AddColumn(new ScenarioColumn())
		.WithOptions(ConfigOptions.JoinSummary)
		.WithCategoryDiscoverer(new CategoryDiscoverer())
		.AddLogicalGroupRules([BenchmarkLogicalGroupRule.ByCategory])
);

#elif !RELEASE
using MediatorBenchmarks.Direct;
using MediatorBenchmarks.FoundatioMediator;
using MediatorBenchmarks.ImmediateHandlers;
using MediatorBenchmarks.MediatorNet;
using MediatorBenchmarks.MediatR;
using MediatorBenchmarks.Shared;

var benchmarks = new List<IBenchmarks>()
{
	new DirectBenchmarks(),
	new FoundatioMediatorBenchmarks(),
	new ImmediateHandlersBenchmarks(),
	new MediatorNetBenchmarks(),
	new MediatRBenchmarks(),
};

foreach (var benchmark in benchmarks)
{
	await benchmark.Command();
	await benchmark.Query();
	await benchmark.Publish();
	await benchmark.FullQuery();
	await benchmark.CascadingMessages();
	await benchmark.ShortCircuit();
}

Console.WriteLine("All Benchmarks operate successfully. Switch to `RELEASE` to benchmark.");

#elif !NET10_0
Console.WriteLine("Benchmarks must be run in `net10.0`");

#endif
