using Axent.Abstractions.Models;
using Axent.Abstractions.Pipelines;
using Axent.Abstractions.Services;
using MediatorBenchmarks.Shared;

namespace MediatorBenchmarks.Axent;

// Scenario 1: Command handler (InvokeAsync without response)
public sealed class AxentCommandHandler : IRequestHandler<PingCommand, Unit>
{
	public async ValueTask<Response<Unit>> HandleAsync(RequestContext<PingCommand> context, CancellationToken cancellationToken = default)
	{
		// Simulate minimal work
		await ValueTask.CompletedTask;
		return Response.Success(Unit.Value);
	}
}

// Scenario 2: Query handler (InvokeAsync<T>) - No DI for baseline comparison
public sealed class AxentQueryHandler : IRequestHandler<GetOrder, Order>
{
	public async ValueTask<Response<Order>> HandleAsync(RequestContext<GetOrder> context, CancellationToken cancellationToken = default)
	{
		return Response.Success(new Order(context.Request.Id, 99.99m, DateTime.UtcNow));
	}
}

// Scenario 3: Event handlers (PublishAsync with multiple handlers)
/* Unsupported */

// Scenario 4: InvokeAsync<T> with DI (Query with dependency injection and middleware)
public sealed class AxentFullQueryHandler(IOrderService orderService) : IRequestHandler<GetFullQuery, Order>
{
	public async ValueTask<Response<Order>> HandleAsync(RequestContext<GetFullQuery> context, CancellationToken cancellationToken = default)
	{
		return Response.Success(await orderService.GetOrderAsync(context.Request.Id, cancellationToken));
	}
}

public sealed class TimingBehavior : IAxentPipe<GetFullQuery, Order>
{
	public async ValueTask<Response<Order>> ProcessAsync(IPipelineChain<GetFullQuery, Order> chain, RequestContext<GetFullQuery> context, CancellationToken cancellationToken = default)
	{
		var stopwatch = System.Diagnostics.Stopwatch.StartNew();
		try
		{
			return await chain.NextAsync(context, cancellationToken);
		}
		finally
		{
			stopwatch.Stop();
			// In real middleware, you'd log here
		}
	}
}

// Scenario 5: Cascading messages - Axent requires manual publish of events
/* Unsupported */

// Scenario 6: Short-circuit handler - Axent uses IPipelineBehavior to short-circuit
public sealed class AxentShortCircuitHandler : IRequestHandler<GetCachedOrder, Order>
{
	public async ValueTask<Response<Order>> HandleAsync(RequestContext<GetCachedOrder> context, CancellationToken cancellationToken = default)
	{
		// This should never be called - pipeline behavior short-circuits before reaching handler
		throw new InvalidOperationException("Short-circuit behavior should have prevented this call");
	}
}

// Axent short-circuit behavior - returns cached value without calling handler
public sealed class ShortCircuitBehavior : IAxentPipe<GetCachedOrder, Order>
{
	private readonly Order _cachedOrder = new(999, 49.99m, DateTime.UtcNow);

	public async ValueTask<Response<Order>> ProcessAsync(IPipelineChain<GetCachedOrder, Order> chain, RequestContext<GetCachedOrder> context, CancellationToken cancellationToken = default)
	{
		// Short-circuit by returning cached value - never calls next()
		return Response.Success(_cachedOrder);
	}
}
