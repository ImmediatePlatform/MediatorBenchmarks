using System.Diagnostics;
using MediatorBenchmarks.Shared;

namespace MediatorBenchmarks.Direct;

// Scenario 1: Command handler (InvokeAsync without response)
public sealed class DirectCommandHandler
{
	public async ValueTask HandleAsync(PingCommand command, CancellationToken cancellationToken = default)
	{
		// Simulate minimal work
	}
}

// Scenario 2: Query handler (InvokeAsync<T>)
public sealed class DirectQueryHandler
{
	public async ValueTask<Order> HandleAsync(GetOrder query, CancellationToken cancellationToken = default)
	{
		return new Order(query.Id, 99.99m, DateTime.UtcNow);
	}
}

// Scenario 3: Event handlers (PublishAsync with multiple handlers)
public sealed class DirectEventHandler
{
	public async ValueTask HandleAsync(UserRegisteredEvent notification, CancellationToken cancellationToken = default)
	{
		// Simulate minimal event handling work
	}
}

public sealed class DirectSecondEventHandler
{
	public async ValueTask HandleAsync(UserRegisteredEvent notification, CancellationToken cancellationToken = default)
	{
		// Second handler listening for the same event
	}
}

// Scenario 4: Query handler with dependency injection
public sealed class DirectFullQueryHandler(IOrderService orderService)
{
	public async ValueTask<Order> HandleAsync(GetFullQuery query, CancellationToken cancellationToken = default)
	{
		var stopwatch = Stopwatch.StartNew();

		try
		{
			return await orderService.GetOrderAsync(query.Id, cancellationToken);
		}
		finally
		{
			stopwatch.Stop();
		}
	}
}

// Scenario 5: Cascading messages - returns tuple with result + events that auto-publish
public sealed class DirectCreateOrderHandler
{
	public async ValueTask<(Order order, OrderCreatedEvent evt)> HandleAsync(CreateOrder command, CancellationToken cancellationToken = default)
	{
		var order = new Order(1, command.Amount, DateTime.UtcNow);
		return (order, new OrderCreatedEvent(order.Id, command.CustomerId));
	}
}

// Handlers for the cascaded OrderCreatedEvent
public sealed class DirectFirstOrderCreatedHandler
{
	public async ValueTask HandleAsync(OrderCreatedEvent notification, CancellationToken cancellationToken = default)
	{
		// First handler for order created event
	}
}

public sealed class DirectSecondOrderCreatedHandler
{
	public async ValueTask HandleAsync(OrderCreatedEvent notification, CancellationToken cancellationToken = default)
	{
		// Second handler for order created event
	}
}

// Scenario 6: Short-circuit handler (never actually called due to ShortCircuitMiddleware)
public sealed class DirectShortCircuitHandler
{
	public async ValueTask<Order> HandleAsync(GetCachedOrder query, CancellationToken cancellationToken = default)
	{
		// This should never be called - middleware short-circuits before reaching handler
		throw new InvalidOperationException("Short-circuit middleware should have prevented this call");
	}
}
