using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using DispatchR;
using DispatchR.Extensions;
using MediatorBenchmarks.Shared;
using MediatorBenchmarks.Support;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorBenchmarks.DispatchR;

[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net10_0)]
[MemoryDiagnoser]
[Implementation("DispatchR")]
public class DispatchRBenchmarks : IBenchmarks
{
	private readonly PingCommand _pingCommand = PingCommand.Instance;
	private readonly GetOrder _getOrder = GetOrder.Instance;
	private readonly GetFullQuery _getFullQuery = GetFullQuery.Instance;
	private readonly UserRegisteredEvent _userRegisteredEvent = UserRegisteredEvent.Instance;
	private readonly CreateOrder _createOrder = CreateOrder.Instance;
	private readonly GetCachedOrder _getCachedOrder = GetCachedOrder.Instance;

	private readonly IServiceProvider _services;
	private readonly IMediator _mediator;

	public DispatchRBenchmarks()
	{
		// Setup MediatR
		_services = new ServiceCollection()
			.AddSingleton<IOrderService, OrderService>()
			.AddDispatchR(cfg =>
			{
				cfg.Assemblies.Add(typeof(DispatchRBenchmarks).Assembly);
				cfg.RegisterPipelines = true;
				cfg.RegisterNotifications = true;
			})
			.BuildServiceProvider();

		_mediator = _services.GetRequiredService<IMediator>();
	}

	[Benchmark]
	[Scenario(Scenario.InvokeAsync)]
	public async ValueTask Command()
	{
		await _mediator.Send(_pingCommand, default);
	}

	[Benchmark]
	[Scenario(Scenario.InvokeAsyncT)]
	public async ValueTask<Order> Query()
	{
		return await _mediator.Send(_getOrder, default);
	}

	[Benchmark]
	[Scenario(Scenario.Publish)]
	public async ValueTask Publish()
	{
		await _mediator.Publish(_userRegisteredEvent, default);
	}

	[Benchmark]
	[Scenario(Scenario.InvokeAsyncTWithDI)]
	public async ValueTask<Order> FullQuery()
	{
		return await _mediator.Send(_getFullQuery, default);
	}

	[Benchmark]
	[Scenario(Scenario.CascadingMessages)]
	public async ValueTask<Order> CascadingMessages()
	{
		return await _mediator.Send(_createOrder, default);
	}

	[Benchmark]
	[Scenario(Scenario.ShortCircuit)]
	public async ValueTask<Order> ShortCircuit()
	{
		return await _mediator.Send(_getCachedOrder, default);
	}
}
