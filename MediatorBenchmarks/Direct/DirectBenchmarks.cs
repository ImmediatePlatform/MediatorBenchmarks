using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using MediatorBenchmarks.Shared;
using MediatorBenchmarks.Support;

namespace MediatorBenchmarks.Direct;

[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net10_0)]
[MemoryDiagnoser]
[Implementation("Direct")]
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

	[Benchmark]
	[Scenario(Scenario.InvokeAsync)]
	public async ValueTask Command()
	{
		await _directCommandHandler.HandleAsync(_pingCommand);
	}

	[Benchmark]
	[Scenario(Scenario.InvokeAsyncT)]
	public async ValueTask<Order> Query()
	{
		return await _directQueryHandler.HandleAsync(_getOrder);
	}

	[Benchmark]
	[Scenario(Scenario.Publish)]
	public async ValueTask Publish()
	{
		await _directEventHandler.HandleAsync(_userRegisteredEvent);
		await _directSecondEventHandler.HandleAsync(_userRegisteredEvent);
	}

	[Benchmark]
	[Scenario(Scenario.InvokeAsyncTWithDI)]
	public async ValueTask<Order> FullQuery()
	{
		return await _directFullQueryHandler.HandleAsync(_getFullQuery);
	}

	[Benchmark]
	[Scenario(Scenario.CascadingMessages)]
	public async Task<Order> CascadingMessages()
	{
		var (order, evt) = await _directCreateOrderHandler.HandleAsync(_createOrder);
		await _directFirstOrderCreatedHandler.HandleAsync(evt);
		await _directSecondOrderCreatedHandler.HandleAsync(evt);
		return order;
	}

	[Benchmark]
	[Scenario(Scenario.ShortCircuit)]
	public async ValueTask<Order> ShortCircuit()
	{
		// Simulate ShortCircuitMiddleware.Before returning cached result
		// awaiting created `ValueTask<>` to remove async state machine as variance between
		// this test and others
		return _cachedOrder;
	}
}
