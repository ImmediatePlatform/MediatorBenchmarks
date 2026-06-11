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

#elif !RELEASE
using MediatorBenchmarks.Shared;

var benchmarks = new List<IBenchmarks>()
{
#if NET10_0_OR_GREATER
	new MediatorBenchmarks.Axent.AxentBenchmarks(),
#endif
	new MediatorBenchmarks.Direct.DirectBenchmarks(),
	new MediatorBenchmarks.DispatchR.DispatchRBenchmarks(),
	new MediatorBenchmarks.FoundatioMediator.FoundatioMediatorBenchmarks(),
	new MediatorBenchmarks.ImmediateHandlers.ImmediateHandlersBenchmarks(),
	new MediatorBenchmarks.MassTransit.MassTransitBenchmarks(),
	new MediatorBenchmarks.MediatorNet.MediatorNetBenchmarks(),
	new MediatorBenchmarks.MediatR.MediatRBenchmarks(),
#if NET10_0_OR_GREATER
	new MediatorBenchmarks.Wolverine.WolverineBenchmarks(),
#endif
};

foreach (var benchmark in benchmarks)
	await benchmark.Validate();

Console.WriteLine("All Benchmarks operate successfully. Switch to `RELEASE` to benchmark.");

#elif !NET10_0_OR_GREATER
Console.WriteLine("Benchmarks must be run in `net10.0`");

#endif
