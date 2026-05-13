namespace MediatorBenchmarks.Shared;

public interface IBenchmarks
{
	ValueTask<Order> CascadingMessages();
	ValueTask Command();
	ValueTask<Order> FullQuery();
	ValueTask Publish();
	ValueTask<Order> Query();
	ValueTask<Order> ShortCircuit();
}

public static class BenchmarkExtensions
{
	public static async ValueTask Validate(this IBenchmarks benchmark)
	{
		await Validate(benchmark.Command);
		await Validate(benchmark.Query);
		await Validate(benchmark.Publish);
		await Validate(benchmark.FullQuery);
		await Validate(benchmark.CascadingMessages);
		await Validate(benchmark.ShortCircuit);
	}

	private static async ValueTask Validate(Func<ValueTask> action)
	{
		try
		{
			await action();
		}
		catch (NotSupportedException) { }
	}

	private static async ValueTask Validate(Func<ValueTask<Order>> action)
	{
		try
		{
			_ = await action();
		}
		catch (NotSupportedException) { }
	}
}
