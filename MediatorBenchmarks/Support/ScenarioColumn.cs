using System.Reflection;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace MediatorBenchmarks.Support;

public sealed class ScenarioColumn : IColumn
{
	public string Id => nameof(ScenarioColumn);
	public string ColumnName => "Scenario";

	public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;

	public string GetValue(Summary summary, BenchmarkCase benchmarkCase) =>
		benchmarkCase.Descriptor.WorkloadMethod.GetCustomAttribute<ScenarioAttribute>()?.Scenario.ToString()
		?? throw new InvalidOperationException($"Missing `[Scenario]` Attribute on method `{benchmarkCase.Descriptor.WorkloadMethodDisplayInfo}`");

	public bool IsAvailable(Summary summary) => true;
	public bool AlwaysShow => true;
	public ColumnCategory Category => ColumnCategory.Job;
	public int PriorityInCategory => 20;
	public bool IsNumeric => false;
	public UnitType UnitType => UnitType.Dimensionless;
	public string Legend => "Mediator Pattern Scenario";
	public string GetValue(Summary summary, BenchmarkCase benchmarkCase, SummaryStyle style) => GetValue(summary, benchmarkCase);
}

[AttributeUsage(AttributeTargets.Method)]
internal sealed class ScenarioAttribute(Scenario scenario) : Attribute
{
	public Scenario Scenario => scenario;
}

public enum Scenario
{
	None,

	// single response
	Command,
	Query,
	Publish,
	FullQuery,
	CascadingMessages,
	ShortCircuit,

	// stream response
	StreamQuery,
	StreamFullQuery,
}
