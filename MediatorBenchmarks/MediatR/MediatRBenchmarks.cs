using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using MediatorBenchmarks.Shared;
using MediatorBenchmarks.Support;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorBenchmarks.MediatR;

[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net10_0)]
[MemoryDiagnoser]
[Implementation("MediatR")]
public class MediatRBenchmarks : IBenchmarks
{
	private readonly PingCommand _pingCommand = PingCommand.Instance;
	private readonly GetOrder _getOrder = GetOrder.Instance;
	private readonly GetFullQuery _getFullQuery = GetFullQuery.Instance;
	private readonly UserRegisteredEvent _userRegisteredEvent = UserRegisteredEvent.Instance;
	private readonly CreateOrder _createOrder = CreateOrder.Instance;
	private readonly GetCachedOrder _getCachedOrder = GetCachedOrder.Instance;

	private readonly IServiceProvider _services;
	private readonly IMediator _mediator;

	public MediatRBenchmarks()
	{
		// Setup MediatR
		_services = new ServiceCollection()
			.AddSingleton<IOrderService, OrderService>()
			.AddMediatR(cfg =>
			{
				_ = cfg.RegisterServicesFromAssemblyContaining<MediatRBenchmarks>();
				_ = cfg.AddBehavior<IPipelineBehavior<GetFullQuery, Order>, TimingBehavior<GetFullQuery, Order>>();
				_ = cfg.AddBehavior<IPipelineBehavior<GetCachedOrder, Order>, ShortCircuitBehavior>();
			})
			.BuildServiceProvider();

		_mediator = _services.GetRequiredService<IMediator>();
	}

	[Benchmark]
	[Scenario(Scenario.InvokeAsync)]
	public async ValueTask Command()
	{
		await _mediator.Send(_pingCommand);
	}

	[Benchmark]
	[Scenario(Scenario.InvokeAsyncT)]
	public async ValueTask<Order> Query()
	{
		return await _mediator.Send(_getOrder);
	}

	[Benchmark]
	[Scenario(Scenario.Publish)]
	public async ValueTask Publish()
	{
		await _mediator.Publish(_userRegisteredEvent);
	}

	[Benchmark]
	[Scenario(Scenario.InvokeAsyncTWithDI)]
	public async ValueTask<Order> FullQuery()
	{
		return await _mediator.Send(_getFullQuery);
	}

	[Benchmark]
	[Scenario(Scenario.CascadingMessages)]
	public async ValueTask<Order> CascadingMessages()
	{
		return await _mediator.Send(_createOrder);
	}

	[Benchmark]
	[Scenario(Scenario.ShortCircuit)]
	public async ValueTask<Order> ShortCircuit()
	{
		return await _mediator.Send(_getCachedOrder);
	}
}
