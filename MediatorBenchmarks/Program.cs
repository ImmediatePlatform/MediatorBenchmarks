#if RELEASE && NET10_0_OR_GREATER
using System.Reflection;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using MediatorBenchmarks.Support;

await BenchmarkRunner.RunAsync(
	Assembly.GetExecutingAssembly(),
	BenchmarkConfig.Instance
		.HideColumns(["Job", "StdDev", "RatioSD", "Alloc Ratio"])
		.AddColumn(new ImplementationColumn())
		.AddColumn(new ScenarioColumn())
		.WithOptions(ConfigOptions.JoinSummary)
		.WithCategoryDiscoverer(new CategoryDiscoverer())
		.AddLogicalGroupRules([BenchmarkLogicalGroupRule.ByCategory])
);

#elif !NET10_0_OR_GREATER
Console.WriteLine("Benchmarks must be run in `net10.0`");

#elif !RELEASE
using MediatorBenchmarks.Shared;

var benchmarks = new List<IBenchmarks>()
{
	new MediatorBenchmarks.Axent.AxentBenchmarks(),
	new MediatorBenchmarks.Direct.DirectBenchmarks(),
	new MediatorBenchmarks.DispatchR.DispatchRBenchmarks(),
	new MediatorBenchmarks.FoundatioMediator.FoundatioMediatorBenchmarks(),
	new MediatorBenchmarks.ImmediateHandlers.ImmediateHandlersBenchmarks(),
	new MediatorBenchmarks.MassTransit.MassTransitBenchmarks(),
	new MediatorBenchmarks.MediatorNet.MediatorNetBenchmarks(),
	new MediatorBenchmarks.MediatR.MediatRBenchmarks(),
	new MediatorBenchmarks.Wolverine.WolverineBenchmarks(),
};

foreach (var benchmark in benchmarks)
	await benchmark.Validate();

Console.WriteLine("All Benchmarks operate successfully. Switch to `RELEASE` to benchmark.");

#endif
