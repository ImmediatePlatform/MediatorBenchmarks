using System.Globalization;
using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.EventProcessors;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Filters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using RhoMicro.BdnLogging;

namespace MediatorBenchmarks.Support;

internal sealed class BenchmarkConfig : IConfig
{
	public static BenchmarkConfig Instance { get; } = new();

	public IOrderer? Orderer => DefaultConfig.Instance.Orderer;

	public ICategoryDiscoverer? CategoryDiscoverer => DefaultConfig.Instance.CategoryDiscoverer;

	public SummaryStyle? SummaryStyle => DefaultConfig.Instance.SummaryStyle;

	public ConfigUnionRule UnionRule => DefaultConfig.Instance.UnionRule;

	public string? ArtifactsPath => DefaultConfig.Instance.ArtifactsPath;

	public CultureInfo? CultureInfo => DefaultConfig.Instance.CultureInfo;

	public ConfigOptions Options => DefaultConfig.Instance.Options;

	public TimeSpan BuildTimeout => DefaultConfig.Instance.BuildTimeout;

	public WakeLockType WakeLock => DefaultConfig.Instance.WakeLock;

	public IReadOnlyList<Conclusion> ConfigAnalysisConclusion => DefaultConfig.Instance.ConfigAnalysisConclusion;

	public IEnumerable<IColumnProvider> GetColumnProviders()
	{
		return DefaultConfig.Instance.GetColumnProviders();
	}

	public IEnumerable<IExporter> GetExporters()
	{
		return DefaultConfig.Instance.GetExporters();
	}

	public IEnumerable<ILogger> GetLoggers()
	{
		return DefaultConfig.Instance.GetLoggers()
			.Select(l => l is ConsoleLogger ? SpotlitLogger.Instance : l);
	}

	public IEnumerable<IDiagnoser> GetDiagnosers()
	{
		return DefaultConfig.Instance.GetDiagnosers();
	}

	public IEnumerable<IAnalyser> GetAnalysers()
	{
		return DefaultConfig.Instance.GetAnalysers();
	}

	public IEnumerable<Job> GetJobs()
	{
		return DefaultConfig.Instance.GetJobs();
	}

	public IEnumerable<IValidator> GetValidators()
	{
		return DefaultConfig.Instance.GetValidators();
	}

	public IEnumerable<HardwareCounter> GetHardwareCounters()
	{
		return DefaultConfig.Instance.GetHardwareCounters();
	}

	public IEnumerable<IFilter> GetFilters()
	{
		return DefaultConfig.Instance.GetFilters();
	}

	public IEnumerable<BenchmarkLogicalGroupRule> GetLogicalGroupRules()
	{
		return DefaultConfig.Instance.GetLogicalGroupRules();
	}

	public IEnumerable<EventProcessor> GetEventProcessors()
	{
		return DefaultConfig.Instance.GetEventProcessors();
	}

	public IEnumerable<IColumnHidingRule> GetColumnHidingRules()
	{
		return DefaultConfig.Instance.GetColumnHidingRules();
	}
}
