using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Foundatio.Mediator;
using MediatorBenchmarks.Shared;
using MediatorBenchmarks.Support;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorBenchmarks.FoundatioMediator;

[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net10_0)]
[SimpleJob(RuntimeMoniker.Net11_0)]
[MemoryDiagnoser]
[Implementation("Foundatio.Mediator")]
public class FoundatioMediatorBenchmarks : IBenchmarks
{
	private readonly PingCommand _pingCommand = PingCommand.Instance;
	private readonly GetOrder _getOrder = GetOrder.Instance;
	private readonly GetFullQuery _getFullQuery = GetFullQuery.Instance;
	private readonly UserRegisteredEvent _userRegisteredEvent = UserRegisteredEvent.Instance;
	private readonly CreateOrder _createOrder = CreateOrder.Instance;
	private readonly GetCachedOrder _getCachedOrder = GetCachedOrder.Instance;
	private readonly GetStreamQuery _getStreamQuery = GetStreamQuery.Instance;

	private readonly IServiceProvider _services;
	private readonly IMediator _mediator;

	public FoundatioMediatorBenchmarks()
	{
		var services = new ServiceCollection()
			.AddSingleton<IOrderService, OrderService>();

		_ = MediatorExtensions.AddMediator(services);

		_services = services.BuildServiceProvider();

		_mediator = _services.GetRequiredService<IMediator>();
	}

	[Benchmark]
	[Scenario(Scenario.Command)]
	public async ValueTask Command()
	{
		await _mediator.InvokeAsync(_pingCommand);
	}

	[Benchmark]
	[Scenario(Scenario.Query)]
	public async ValueTask<Order> Query()
	{
		return await _mediator.InvokeAsync<Order>(_getOrder);
	}

	[Benchmark]
	[Scenario(Scenario.Publish)]
	public async ValueTask Publish()
	{
		await _mediator.PublishAsync(_userRegisteredEvent);
	}

	[Benchmark]
	[Scenario(Scenario.FullQuery)]
	public async ValueTask<Order> FullQuery()
	{
		return await _mediator.InvokeAsync<Order>(_getFullQuery);
	}

	[Benchmark]
	[Scenario(Scenario.CascadingMessages)]
	public async ValueTask<Order> CascadingMessages()
	{
		return await _mediator.InvokeAsync<Order>(_createOrder);
	}

	[Benchmark]
	[Scenario(Scenario.ShortCircuit)]
	public async ValueTask<Order> ShortCircuit()
	{
		return await _mediator.InvokeAsync<Order>(_getCachedOrder);
	}

	[Benchmark]
	[Scenario(Scenario.StreamQuery)]
	public async ValueTask StreamQuery()
	{
		await foreach (var _ in await _mediator.InvokeAsync<IAsyncEnumerable<Order>>(_getStreamQuery))
		{
		}
	}

	[Scenario(Scenario.StreamFullQuery)]
	public async ValueTask StreamFullQuery()
	{
		throw new NotSupportedException("Unsure if supported in Foundatio");
	}
}
