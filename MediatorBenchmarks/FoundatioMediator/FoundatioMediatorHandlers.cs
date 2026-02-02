using System.Diagnostics;
using Foundatio.Mediator;
using MediatorBenchmarks.Shared;

namespace MediatorBenchmarks.FoundatioMediator;

// Scenario 1: Command handler (InvokeAsync without response)
[Handler]
public sealed class FoundatioCommandHandler
{
	public async ValueTask HandleAsync(PingCommand command, CancellationToken cancellationToken = default)
	{
		// Simulate minimal work
		await ValueTask.CompletedTask;
	}
}

// Scenario 2: Query handler (InvokeAsync<T>)
[Handler]
public sealed class FoundatioQueryHandler
{
	public async ValueTask<Order> HandleAsync(GetOrder query, CancellationToken cancellationToken = default)
	{
		return await ValueTask.FromResult(new Order(query.Id, 99.99m, DateTime.UtcNow));
	}
}

// Scenario 3: Event handlers (PublishAsync with multiple handlers)
[Handler]
public sealed class FoundatioEventHandler
{
	public async ValueTask HandleAsync(UserRegisteredEvent notification, CancellationToken cancellationToken = default)
	{
		// Simulate minimal event handling work
		await ValueTask.CompletedTask;
	}
}

[Handler]
public sealed class FoundatioSecondEventHandler
{
	public async ValueTask HandleAsync(UserRegisteredEvent notification, CancellationToken cancellationToken = default)
	{
		// Second handler listening for the same event
		await ValueTask.CompletedTask;
	}
}

// Scenario 4: Query handler with dependency injection
[Handler]
public class FoundatioFullQueryHandler(IOrderService orderService)
{
	public async ValueTask<Order> HandleAsync(GetFullQuery query, CancellationToken cancellationToken = default)
	{
		return await orderService.GetOrderAsync(query.Id, cancellationToken);
	}
}

// Scenario 5: Cascading messages - returns tuple with result + events that auto-publish
[Handler]
public sealed class FoundatioCreateOrderHandler
{
	public async ValueTask<(Order order, OrderCreatedEvent evt)> HandleAsync(CreateOrder command, CancellationToken cancellationToken = default)
	{
		var order = new Order(1, command.Amount, DateTime.UtcNow);
		return await ValueTask.FromResult((order, new OrderCreatedEvent(order.Id, command.CustomerId)));
	}
}

// Handlers for the cascaded OrderCreatedEvent
[Handler]
public sealed class FoundatioFirstOrderCreatedHandler
{
	public async ValueTask HandleAsync(OrderCreatedEvent notification, CancellationToken cancellationToken = default)
	{
		// First handler for order created event
		await ValueTask.CompletedTask;
	}
}

[Handler]
public class FoundatioSecondOrderCreatedHandler
{
	public async ValueTask HandleAsync(OrderCreatedEvent notification, CancellationToken cancellationToken = default)
	{
		// Second handler for order created event
		await ValueTask.CompletedTask;
	}
}

// Scenario 6: Short-circuit handler (never actually called due to ShortCircuitMiddleware)
[Handler]
public class FoundatioShortCircuitHandler
{
	public async ValueTask<Order> HandleAsync(GetCachedOrder query, CancellationToken cancellationToken = default)
	{
		// This should never be called - middleware short-circuits before reaching handler
		throw new InvalidOperationException("Short-circuit middleware should have prevented this call");
	}
}

/// <summary>
/// Simple timing middleware for benchmarking - simulates real-world logging/timing middleware.
/// Only applies to GetFullQuery (FullQuery benchmark).
/// </summary>
[Middleware]
public static class TimingMiddleware
{
	public static Stopwatch Before(GetFullQuery message)
	{
		return Stopwatch.StartNew();
	}

	public static void Finally(GetFullQuery message, Stopwatch? stopwatch)
	{
		stopwatch?.Stop();
		// In real middleware, you'd log here - we just stop the timer for the benchmark
	}
}

/// <summary>
/// Short-circuit middleware that immediately returns a cached result without calling the handler.
/// This demonstrates middleware returning early (cache hit, validation success with cached result, etc.)
/// </summary>
[Middleware]
public static class ShortCircuitMiddleware
{
	private static readonly Order CachedOrder = new(999, 49.99m, DateTime.UtcNow);

	public static async ValueTask<HandlerResult<Order>> BeforeAsync(GetCachedOrder message)
	{
		// Always short-circuit with cached result - simulates cache hit scenario
		return await ValueTask.FromResult(HandlerResult.ShortCircuit(CachedOrder));
	}
}
