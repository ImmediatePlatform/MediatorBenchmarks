using System.Reflection;
using Axent.Abstractions.Services;
using Axent.Core.DependencyInjection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using MediatorBenchmarks.Shared;
using MediatorBenchmarks.Support;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorBenchmarks.Axent;

[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net10_0)]
[SimpleJob(RuntimeMoniker.Net11_0)]
[MemoryDiagnoser]
[Implementation("Axent")]
public class AxentBenchmarks : IBenchmarks
{
	private readonly PingCommand _pingCommand = PingCommand.Instance;
	private readonly GetOrder _getOrder = GetOrder.Instance;
	private readonly GetFullQuery _getFullQuery = GetFullQuery.Instance;
	private readonly GetCachedOrder _getCachedOrder = GetCachedOrder.Instance;

	private readonly IServiceProvider _services;
	private readonly ISender _sender;

	public AxentBenchmarks()
	{
		// Setup Axent
		var services = new ServiceCollection()
			.AddSingleton<IOrderService, OrderService>();

		_ = services.AddAxent()
			.AddRequestHandlersFromAssembly(Assembly.GetExecutingAssembly())
			.AddPipe<TimingBehavior>()
			.AddPipe<ShortCircuitBehavior>();

		_services = services.BuildServiceProvider();

		_sender = _services.GetRequiredService<ISender>();
	}

	[Benchmark]
	[Scenario(Scenario.InvokeAsync)]
	public async ValueTask Command()
	{
		_ = await _sender.SendAsync(_pingCommand, default);
	}

	[Benchmark]
	[Scenario(Scenario.InvokeAsyncT)]
	public async ValueTask<Order> Query()
	{
		return (await _sender.SendAsync<Order>(_getOrder, default)).Value!;
	}

	public async ValueTask Publish()
	{
		throw new NotSupportedException("Unsupported in Axent");
	}

	[Benchmark]
	[Scenario(Scenario.InvokeAsyncTWithDI)]
	public async ValueTask<Order> FullQuery()
	{
		return (await _sender.SendAsync(_getFullQuery, default)).Value!;
	}

	public async ValueTask<Order> CascadingMessages()
	{
		throw new NotSupportedException("Unsupported in Axent");
	}

	[Benchmark]
	[Scenario(Scenario.ShortCircuit)]
	public async ValueTask<Order> ShortCircuit()
	{
		return (await _sender.SendAsync(_getCachedOrder, default)).Value!;
	}
}
