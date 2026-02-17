using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using MassTransit;
using MassTransit.Mediator;
using MediatorBenchmarks.Shared;
using MediatorBenchmarks.Support;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorBenchmarks.MassTransit;

[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net10_0)]
[MemoryDiagnoser]
[Implementation("MassTransit")]
public class MassTransitBenchmarks : IBenchmarks
{
	private readonly PingCommand _pingCommand = PingCommand.Instance;
	private readonly GetOrder _getOrder = GetOrder.Instance;
	private readonly GetFullQuery _getFullQuery = GetFullQuery.Instance;
	private readonly UserRegisteredEvent _userRegisteredEvent = UserRegisteredEvent.Instance;
	private readonly CreateOrder _createOrder = CreateOrder.Instance;
	private readonly GetCachedOrder _getCachedOrder = GetCachedOrder.Instance;

	private readonly IServiceProvider _services;
	private readonly IMediator _mediator;
	private readonly IRequestClient<GetOrder> _masstransitQueryClient;
	private readonly IRequestClient<GetFullQuery> _masstransitFullQueryClient;
	private readonly IRequestClient<CreateOrder> _masstransitCascadingMessagesClient;
	private readonly IRequestClient<GetCachedOrder> _masstransitShortCircuitClient;

	public MassTransitBenchmarks()
	{
		// Setup MassTransit
		_services = DependencyInjectionRegistrationExtensions
			.AddMediator(
				new ServiceCollection()
					.AddSingleton<IOrderService, OrderService>(),
				cfg =>
				{
					_ = cfg.AddConsumer<MassTransitCommandConsumer>();
					_ = cfg.AddConsumer<MassTransitQueryConsumer>();
					_ = cfg.AddConsumer<MassTransitEventConsumer>();
					_ = cfg.AddConsumer<MassTransitEventConsumer2>();
					_ = cfg.AddConsumer<MassTransitFullQueryConsumer>();
					_ = cfg.AddConsumer<MassTransitCreateOrderConsumer>();
					_ = cfg.AddConsumer<MassTransitOrderCreatedConsumer1>();
					_ = cfg.AddConsumer<MassTransitOrderCreatedConsumer2>();
					_ = cfg.AddConsumer<MassTransitShortCircuitConsumer>();

					cfg.ConfigureMediator((context, mcfg) =>
						{
							mcfg.UseConsumeFilter(typeof(MassTransitTimingFilter<>), context);
							mcfg.UseConsumeFilter(typeof(MassTransitShortCircuitFilter<>), context);
						});
				}
			)
			.BuildServiceProvider();

		_mediator = _services.GetRequiredService<IMediator>();
		_masstransitQueryClient = _mediator.CreateRequestClient<GetOrder>();
		_masstransitFullQueryClient = _mediator.CreateRequestClient<GetFullQuery>();
		_masstransitCascadingMessagesClient = _mediator.CreateRequestClient<CreateOrder>();
		_masstransitShortCircuitClient = _mediator.CreateRequestClient<GetCachedOrder>();
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
		var response = await _masstransitQueryClient.GetResponse<Order>(_getOrder);
		return response.Message;
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
		var response = await _masstransitFullQueryClient.GetResponse<Order>(_getFullQuery);
		return response.Message;
	}

	[Benchmark]
	[Scenario(Scenario.CascadingMessages)]
	public async ValueTask<Order> CascadingMessages()
	{
		var response = await _masstransitCascadingMessagesClient.GetResponse<Order>(_createOrder);
		return response.Message;
	}

	[Benchmark]
	[Scenario(Scenario.ShortCircuit)]
	public async ValueTask<Order> ShortCircuit()
	{
		var response = await _masstransitShortCircuitClient.GetResponse<Order>(_getCachedOrder);
		return response.Message;
	}
}
