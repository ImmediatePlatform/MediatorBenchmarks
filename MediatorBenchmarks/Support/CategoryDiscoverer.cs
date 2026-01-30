using System.Reflection;
using BenchmarkDotNet.Running;

namespace MediatorBenchmarks.Support;

public sealed class CategoryDiscoverer : ICategoryDiscoverer
{
	public string[] GetCategories(MethodInfo method) =>
		[
			method.DeclaringType!.GetCustomAttribute<ImplementationAttribute>()?.Implementation
				?? "",
			method.GetCustomAttribute<ScenarioAttribute>()?.Scenario.ToString()
				?? "",
		];
}
