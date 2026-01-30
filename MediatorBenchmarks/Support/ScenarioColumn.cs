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
	public string Legend => $"Mediator Pattern Scenario";
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

	// Message

	/// <summary>
	///		InvokeAsync without response (Command)
	/// </summary>
	InvokeAsync,

	/// <summary>
	///		InvokeAsync&lt;T&gt; (Query)
	/// </summary>
	InvokeAsyncT,

	/// <summary>
	///		PublishAsync with a single handler
	/// </summary>
	Publish,

	/// <summary>
	///		InvokeAsync&lt;T&gt; with DI and middleware
	/// </summary>
	InvokeAsyncTWithDI,

	/// <summary>
	///		Cascading messages - invoke returns result and auto-publishes events to multiple handlers
	/// </summary>
	CascadingMessages,

	/// <summary>
	///		Short-circuit middleware - returns cached result, handler is never invoked
	/// </summary>
	ShortCircuit,
}
