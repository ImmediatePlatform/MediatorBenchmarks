using System.Reflection;
using Axent.Abstractions.Models;
using Axent.Abstractions.Services;
using Axent.Core.DependencyInjection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using MediatorBenchmarks.Shared;
using MediatorBenchmarks.Support;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorBenchmarks.Axent;

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
	private readonly IRequestSender<PingCommand, Unit> _axentCommandHandler;
	private readonly IRequestSender<GetOrder, Order> _axentQueryHander;
	private readonly IRequestSender<GetFullQuery, Order> _axentFullQueryHandler;
	private readonly IRequestSender<GetCachedOrder, Order> _axentShortCircuitHandler;

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

		_axentCommandHandler = _services.GetRequiredService<IRequestSender<PingCommand, Unit>>();
		_axentQueryHander = _services.GetRequiredService<IRequestSender<GetOrder, Order>>();
		_axentFullQueryHandler = _services.GetRequiredService<IRequestSender<GetFullQuery, Order>>();
		_axentShortCircuitHandler = _services.GetRequiredService<IRequestSender<GetCachedOrder, Order>>();
	}

	[Benchmark]
	[Scenario(Scenario.Command)]
	public async ValueTask Command()
	{
		_ = await _axentCommandHandler.SendAsync(_pingCommand, default);
	}

	[Benchmark]
	[Scenario(Scenario.Query)]
	public async ValueTask<Order> Query()
	{
		return (await _axentQueryHander.SendAsync(_getOrder, default)).Value!;
	}

	public async ValueTask Publish()
	{
		throw new NotSupportedException("Unsupported in Axent");
	}

	[Benchmark]
	[Scenario(Scenario.FullQuery)]
	public async ValueTask<Order> FullQuery()
	{
		return (await _axentFullQueryHandler.SendAsync(_getFullQuery, default)).Value!;
	}

	public async ValueTask<Order> CascadingMessages()
	{
		throw new NotSupportedException("Unsupported in Axent");
	}

	[Benchmark]
	[Scenario(Scenario.ShortCircuit)]
	public async ValueTask<Order> ShortCircuit()
	{
		return (await _axentShortCircuitHandler.SendAsync(_getCachedOrder, default)).Value!;
	}

	[Scenario(Scenario.StreamQuery)]
	public async ValueTask StreamQuery()
	{
		throw new NotSupportedException("Unsupported in Axent");
	}

	[Scenario(Scenario.StreamFullQuery)]
	public async ValueTask StreamFullQuery()
	{
		throw new NotSupportedException("Unsupported in Axent");
	}
}
