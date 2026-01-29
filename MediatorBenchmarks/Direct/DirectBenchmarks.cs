using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using MediatorBenchmarks.Shared;

namespace MediatorBenchmarks.Direct;

[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net10_0)]
[MemoryDiagnoser]
[BenchmarkCategory("Direct")]
public class DirectBenchmarks
{
	private readonly PingCommand _pingCommand = PingCommand.Instance;
	private readonly GetOrder _getOrder = GetOrder.Instance;
	private readonly GetFullQuery _getFullQuery = GetFullQuery.Instance;
	private readonly UserRegisteredEvent _userRegisteredEvent = UserRegisteredEvent.Instance;
	private readonly CreateOrder _createOrder = CreateOrder.Instance;
	private readonly Order _cachedOrder = Order.Instance;

	private readonly DirectCommandHandler _directCommandHandler = new();
	private readonly DirectQueryHandler _directQueryHandler = new();
	private readonly DirectEventHandler _directEventHandler = new();
	private readonly DirectSecondEventHandler _directSecondEventHandler = new();
	private readonly DirectFullQueryHandler _directFullQueryHandler = new(new OrderService());
	private readonly DirectCreateOrderHandler _directCreateOrderHandler = new();
	private readonly DirectFirstOrderCreatedHandler _directFirstOrderCreatedHandler = new();
	private readonly DirectSecondOrderCreatedHandler _directSecondOrderCreatedHandler = new();

	// Scenario 1: InvokeAsync without response (Command)
	[Benchmark]
	[BenchmarkCategory("Command")]
	public async ValueTask Command()
	{
		await _directCommandHandler.HandleAsync(_pingCommand);
	}

	// Scenario 2: InvokeAsync<T> (Query)
	[Benchmark]
	[BenchmarkCategory("Query")]
	public async ValueTask<Order> Query()
	{
		return await _directQueryHandler.HandleAsync(_getOrder);
	}

	// Scenario 3: PublishAsync with a single handler
	[Benchmark]
	[BenchmarkCategory("Publish")]
	public async ValueTask Publish()
	{
		await _directEventHandler.HandleAsync(_userRegisteredEvent);
		await _directSecondEventHandler.HandleAsync(_userRegisteredEvent);
	}

	// Scenario 4: InvokeAsync<T> with DI (Query with dependency injection and middleware)
	[Benchmark]
	[BenchmarkCategory("Full Query")]
	public async ValueTask<Order> FullQuery()
	{
		return await _directFullQueryHandler.HandleAsync(_getFullQuery);
	}

	// Scenario 5: Cascading messages - invoke returns result and auto-publishes events to multiple handlers
	[Benchmark]
	[BenchmarkCategory("Cascading")]
	public async Task<Order> CascadingMessages()
	{
		var (order, evt) = await _directCreateOrderHandler.HandleAsync(_createOrder);
		await _directFirstOrderCreatedHandler.HandleAsync(evt);
		await _directSecondOrderCreatedHandler.HandleAsync(evt);
		return order;
	}

	// Scenario 6: Short-circuit middleware - returns cached result, handler is never invoked
	[Benchmark]
	[BenchmarkCategory("Short Circuit")]
	public async ValueTask<Order> ShortCircuit()
	{
		// Simulate ShortCircuitMiddleware.Before returning cached result
		// awaiting created `ValueTask<>` to remove async state machine as variance between
		// this test and others
		return _cachedOrder;
	}
}
