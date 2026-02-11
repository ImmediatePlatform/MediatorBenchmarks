using System.Reflection;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace MediatorBenchmarks.Support;

public sealed class ImplementationColumn : IColumn
{
	public string Id => nameof(ImplementationColumn);
	public string ColumnName => "Implementation";

	public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;

	public string GetValue(Summary summary, BenchmarkCase benchmarkCase) =>
		benchmarkCase.Descriptor.Type.GetCustomAttribute<ImplementationAttribute>()?.Implementation
		?? throw new InvalidOperationException($"Missing `[Implementation]` Attribute on type `{benchmarkCase.Descriptor.Type.FullName}`");

	public bool IsAvailable(Summary summary) => true;
	public bool AlwaysShow => true;
	public ColumnCategory Category => ColumnCategory.Job;
	public int PriorityInCategory => 20;
	public bool IsNumeric => false;
	public UnitType UnitType => UnitType.Dimensionless;
	public string Legend => "Mediator Pattern Implementation";
	public string GetValue(Summary summary, BenchmarkCase benchmarkCase, SummaryStyle style) => GetValue(summary, benchmarkCase);
}

[AttributeUsage(AttributeTargets.Class)]
internal sealed class ImplementationAttribute(string implementation) : Attribute
{
	public string Implementation => implementation;
}
