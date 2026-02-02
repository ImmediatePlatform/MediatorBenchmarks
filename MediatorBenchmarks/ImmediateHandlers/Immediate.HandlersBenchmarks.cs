using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using MediatorBenchmarks.Shared;
using MediatorBenchmarks.Support;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorBenchmarks.ImmediateHandlers;

[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net10_0)]
[MemoryDiagnoser]
[Implementation("Immediate.Handlers")]
public class ImmediateHandlersBenchmarks : IBenchmarks
{
	private readonly PingCommand _pingCommand = PingCommand.Instance;
	private readonly GetOrder _getOrder = GetOrder.Instance;
	private readonly GetFullQuery _getFullQuery = GetFullQuery.Instance;
	private readonly UserRegisteredEvent _userRegisteredEvent = UserRegisteredEvent.Instance;
	private readonly CreateOrder _createOrder = CreateOrder.Instance;
	private readonly GetCachedOrder _getCachedOrder = GetCachedOrder.Instance;

	private readonly IServiceProvider _services;
	private readonly ImmediateHandlersCommandHandler.Handler _immediateHandlersCommandHandler;
	private readonly ImmediateHandlersQueryHandler.Handler _immediateHandlersQueryHandler;
	private readonly Publisher<UserRegisteredEvent> _immediateHandlersEventHandler;
	private readonly ImmediateHandlersFullQuery.Handler _immediateHandlersFullQueryHandler;
	private readonly ImmediateHandlersCreateOrderConsumer.Handler _immediateHandlersCreateOrderConsumer;
	private readonly ImmediateHandlersShortCircuitHandler.Handler _immediateHandlersShortCircuitHandler;

	public ImmediateHandlersBenchmarks()
	{
		// Setup IH
		_services = new ServiceCollection()
			.AddMediatorBenchmarksBehaviors()
			.AddMediatorBenchmarksHandlers()
			.AddSingleton<IOrderService, OrderService>()
			.AddScoped(typeof(Publisher<>))
			.BuildServiceProvider();

		_immediateHandlersCommandHandler = _services.GetRequiredService<ImmediateHandlersCommandHandler.Handler>();
		_immediateHandlersQueryHandler = _services.GetRequiredService<ImmediateHandlersQueryHandler.Handler>();
		_immediateHandlersEventHandler = _services.GetRequiredService<Publisher<UserRegisteredEvent>>();
		_immediateHandlersFullQueryHandler = _services.GetRequiredService<ImmediateHandlersFullQuery.Handler>();
		_immediateHandlersCreateOrderConsumer = _services.GetRequiredService<ImmediateHandlersCreateOrderConsumer.Handler>();
		_immediateHandlersShortCircuitHandler = _services.GetRequiredService<ImmediateHandlersShortCircuitHandler.Handler>();
	}

	[Benchmark]
	[Scenario(Scenario.InvokeAsync)]
	public async ValueTask Command()
	{
		_ = await _immediateHandlersCommandHandler.HandleAsync(_pingCommand);
	}

	[Benchmark]
	[Scenario(Scenario.InvokeAsyncT)]
	public async ValueTask<Order> Query()
	{
		return await _immediateHandlersQueryHandler.HandleAsync(_getOrder);
	}

	[Benchmark]
	[Scenario(Scenario.Publish)]
	public async ValueTask Publish()
	{
		await _immediateHandlersEventHandler.Publish(_userRegisteredEvent);
	}

	[Benchmark]
	[Scenario(Scenario.InvokeAsyncTWithDI)]
	public async ValueTask<Order> FullQuery()
	{
		return await _immediateHandlersFullQueryHandler.HandleAsync(_getFullQuery);
	}

	[Benchmark]
	[Scenario(Scenario.CascadingMessages)]
	public async ValueTask<Order> CascadingMessages()
	{
		return await _immediateHandlersCreateOrderConsumer.HandleAsync(_createOrder);
	}

	[Benchmark]
	[Scenario(Scenario.ShortCircuit)]
	public async ValueTask<Order> ShortCircuit()
	{
		return await _immediateHandlersShortCircuitHandler.HandleAsync(_getCachedOrder);
	}
}
