using MediatorBenchmarks.Shared;
using Wolverine;

namespace MediatorBenchmarks.Wolverine;

// Scenario 1: Command handler (InvokeAsync without response)
public sealed class WolverineCommandHandler
{
	public async ValueTask Handle(PingCommand command)
	{
		// Simulate minimal work
	}
}

// Scenario 2: Query handler (InvokeAsync<T>) - No DI for baseline comparison
public sealed class WolverineQueryHandler
{
	public async ValueTask<Order> Handle(GetOrder query)
	{
		return new Order(query.Id, 99.99m, DateTime.UtcNow);
	}
}

// Scenario 3: Event handlers (PublishAsync with multiple handlers)
public sealed class WolverineEventHandler
{
	public async ValueTask Handle(UserRegisteredEvent notification)
	{
		// Simulate minimal event handling work
	}
}

public sealed class WolverineEventHandler2
{
	public async ValueTask Handle(UserRegisteredEvent notification)
	{
		// Second handler listening for the same event
	}
}

// Scenario 4: Query handler with dependency injection
public sealed class WolverineFullQueryHandler
{
	public async ValueTask<Order> Handle(GetFullQuery query, IOrderService orderService)
	{
		return await orderService.GetOrderAsync(query.Id);
	}
}

// Wolverine timing middleware for FullQuery benchmark (equivalent to Foundatio's TimingMiddleware)
public static class WolverineTimingMiddleware
{
	public static System.Diagnostics.Stopwatch Before(GetFullQuery message)
	{
		return System.Diagnostics.Stopwatch.StartNew();
	}

	public static void Finally(GetFullQuery message, System.Diagnostics.Stopwatch? stopwatch)
	{
		stopwatch?.Stop();
		// In real middleware, you'd log here - we just stop the timer for the benchmark
	}
}

// Scenario 5: Cascading messages - Wolverine supports cascading via return values
public sealed class WolverineCreateOrderHandler
{
	public async ValueTask<(Order, OrderCreatedEvent)> Handle(CreateOrder command)
	{
		var order = new Order(1, command.Amount, DateTime.UtcNow);
		return (order, new OrderCreatedEvent(order.Id, command.CustomerId));
	}
}

// Handlers for the cascaded OrderCreatedEvent
public sealed class WolverineOrderCreatedHandler1
{
	public async ValueTask Handle(OrderCreatedEvent notification)
	{
		// First handler for order created event
	}
}

public sealed class WolverineOrderCreatedHandler2
{
	public async ValueTask Handle(OrderCreatedEvent notification)
	{
		// Second handler for order created event
	}
}

// Scenario 6: Short-circuit - Wolverine uses Before middleware with HandlerContinuation.Stop
public sealed class WolverineShortCircuitHandler
{
	public async ValueTask<Order> Handle(GetCachedOrder query)
	{
		// This should never be called - middleware short-circuits before reaching handler
		throw new InvalidOperationException("Short-circuit middleware should have prevented this call");
	}
}

// Wolverine short-circuit middleware - uses HandlerContinuation to stop processing
public static class WolverineShortCircuitMiddleware
{
	private static readonly Order CachedOrder = new(999, 49.99m, DateTime.UtcNow);

	// Wolverine Before method with async async ValueTask tuple return for short-circuit
	public static async ValueTask<(HandlerContinuation, Order)> BeforeAsync(GetCachedOrder message)
	{
		// Short-circuit by returning Stop with the cached value
		return (HandlerContinuation.Stop, CachedOrder);
	}
}
