using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using MediatorBenchmarks.Shared;
using MediatorBenchmarks.Support;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Wolverine;

namespace MediatorBenchmarks.Wolverine;

[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net10_0)]
[SimpleJob(RuntimeMoniker.Net11_0)]
[MemoryDiagnoser]
[Implementation("Wolverine")]
public class WolverineBenchmarks : IBenchmarks
{
	private readonly PingCommand _pingCommand = PingCommand.Instance;
	private readonly GetOrder _getOrder = GetOrder.Instance;
	private readonly GetFullQuery _getFullQuery = GetFullQuery.Instance;
	private readonly UserRegisteredEvent _userRegisteredEvent = UserRegisteredEvent.Instance;
	private readonly CreateOrder _createOrder = CreateOrder.Instance;
	private readonly GetCachedOrder _getCachedOrder = GetCachedOrder.Instance;

	private readonly IHost _host;
	private readonly IMessageBus _bus;

	public WolverineBenchmarks()
	{
		// Setup Wolverine
		_host = Host.CreateDefaultBuilder()
			.ConfigureLogging(logging => logging.ClearProviders())
			.UseWolverine(
				opts =>
				{
					_ = opts.Services.AddSingleton<IOrderService, OrderService>();

					// Only include Wolverine-specific handlers (disable auto-discovery to avoid other libraries' handlers)
					_ = opts.Discovery.DisableConventionalDiscovery()
						.IncludeType<WolverineCommandHandler>()
						.IncludeType<WolverineQueryHandler>()
						.IncludeType<WolverineEventHandler>()
						.IncludeType<WolverineEventHandler2>()
						.IncludeType<WolverineFullQueryHandler>()
						.IncludeType<WolverineCreateOrderHandler>()
						.IncludeType<WolverineOrderCreatedHandler1>()
						.IncludeType<WolverineOrderCreatedHandler2>()
						.IncludeType<WolverineShortCircuitHandler>();

					// Register short-circuit middleware for GetCachedOrder
					_ = opts.Policies.ForMessagesOfType<GetCachedOrder>().AddMiddleware(typeof(WolverineShortCircuitMiddleware));

					// Register timing middleware for GetFullQuery to match Foundatio's middleware
					_ = opts.Policies.ForMessagesOfType<GetFullQuery>().AddMiddleware(typeof(WolverineTimingMiddleware));

					opts.ApplicationAssembly = typeof(WolverineBenchmarks).Assembly;
					opts.CodeGeneration.TypeLoadMode = JasperFx.CodeGeneration.TypeLoadMode.Static;
				},
				ExtensionDiscovery.ManualOnly
			)
			.Build();

		_host.Start();

		_bus = _host.Services.GetRequiredService<IMessageBus>();
	}

	[Benchmark]
	[Scenario(Scenario.InvokeAsync)]
	public async ValueTask Command()
	{
		await _bus.InvokeAsync(_pingCommand);
	}

	[Benchmark]
	[Scenario(Scenario.InvokeAsyncT)]
	public async ValueTask<Order> Query()
	{
		return await _bus.InvokeAsync<Order>(_getOrder);
	}

	[Benchmark]
	[Scenario(Scenario.Publish)]
	public async ValueTask Publish()
	{
		await _bus.PublishAsync(_userRegisteredEvent);
	}

	[Benchmark]
	[Scenario(Scenario.InvokeAsyncTWithDI)]
	public async ValueTask<Order> FullQuery()
	{
		return await _bus.InvokeAsync<Order>(_getFullQuery);
	}

	[Benchmark]
	[Scenario(Scenario.CascadingMessages)]
	public async ValueTask<Order> CascadingMessages()
	{
		return await _bus.InvokeAsync<Order>(_createOrder);
	}

	[Benchmark]
	[Scenario(Scenario.ShortCircuit)]
	public async ValueTask<Order> ShortCircuit()
	{
		return await _bus.InvokeAsync<Order>(_getCachedOrder);
	}
}
