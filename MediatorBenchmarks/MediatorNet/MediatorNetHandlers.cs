using System.Diagnostics;
using MediatorBenchmarks.Shared;
using Mediator;

namespace MediatorBenchmarks.MediatorNet;

// Scenario 1: Command handler (InvokeAsync without response)
public sealed class MediatorNetCommandHandler : ICommandHandler<PingCommand>
{
	public async ValueTask<Unit> Handle(PingCommand command, CancellationToken cancellationToken)
	{
		// Simulate minimal work
		return Unit.Value;
	}
}

// Scenario 2: Query handler (InvokeAsync<T>) - No DI for baseline comparison
public sealed class MediatorNetQueryHandler : IQueryHandler<GetOrder, Order>
{
	public async ValueTask<Order> Handle(GetOrder query, CancellationToken cancellationToken)
	{
		return await ValueTask.FromResult(new Order(query.Id, 99.99m, DateTime.UtcNow));
	}
}

// Scenario 3: Notification handlers (PublishAsync with multiple handlers)
public sealed class MediatorNetEventHandler : INotificationHandler<UserRegisteredEvent>
{
	public async ValueTask Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
	{
		// Simulate minimal event handling work
	}
}

public sealed class MediatorNetEventHandler2 : INotificationHandler<UserRegisteredEvent>
{
	public async ValueTask Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
	{
		// Second handler listening for the same event
	}
}

// Scenario 4: Query handler with dependency injection
public sealed class MediatorNetFullQueryHandler(IOrderService orderService) : IQueryHandler<GetFullQuery, Order>
{
	public async ValueTask<Order> Handle(GetFullQuery query, CancellationToken cancellationToken)
	{
		return await orderService.GetOrderAsync(query.Id, cancellationToken);
	}
}

// MediatorNet timing behavior for FullQuery benchmark (equivalent to Foundatio's TimingMiddleware)
public sealed class MediatorNetTimingBehavior : IPipelineBehavior<GetFullQuery, Order>
{
	public async ValueTask<Order> Handle(GetFullQuery message, MessageHandlerDelegate<GetFullQuery, Order> next, CancellationToken cancellationToken)
	{
		var stopwatch = Stopwatch.StartNew();
		try
		{
			return await next(message, cancellationToken);
		}
		finally
		{
			stopwatch.Stop();
			// In real middleware, you'd log here - we just stop the timer for the benchmark
		}
	}
}

// Scenario 5: Cascading messages - MediatorNet requires manual publish of events
public sealed class MediatorNetCreateOrderHandler(IMediator mediator) : IRequestHandler<CreateOrder, Order>
{
	public async ValueTask<Order> Handle(CreateOrder request, CancellationToken cancellationToken)
	{
		var order = new Order(1, request.Amount, DateTime.UtcNow);
		await mediator.Publish(new OrderCreatedEvent(order.Id, request.CustomerId), cancellationToken);
		return order;
	}
}

// Handlers for the cascaded OrderCreatedEvent
public sealed class MediatorNetOrderCreatedHandler1 : INotificationHandler<OrderCreatedEvent>
{
	public async ValueTask Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
	{
		// First handler for order created event
	}
}

public sealed class MediatorNetOrderCreatedHandler2 : INotificationHandler<OrderCreatedEvent>
{
	public async ValueTask Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
	{
		// Second handler for order created event
	}
}

// Scenario 6: Short-circuit handler - MediatorNet uses IPipelineBehavior to short-circuit
public sealed class MediatorNetShortCircuitHandler : IQueryHandler<GetCachedOrder, Order>
{
	public async ValueTask<Order> Handle(GetCachedOrder query, CancellationToken cancellationToken)
	{
		// This should never be called - pipeline behavior short-circuits before reaching handler
		throw new InvalidOperationException("Short-circuit behavior should have prevented this call");
	}
}

// MediatorNet short-circuit behavior - returns cached value without calling handler
public sealed class MediatorNetShortCircuitBehavior : IPipelineBehavior<GetCachedOrder, Order>
{
	private readonly Order _cachedOrder = new(999, 49.99m, DateTime.UtcNow);

	public async ValueTask<Order> Handle(GetCachedOrder message, MessageHandlerDelegate<GetCachedOrder, Order> next, CancellationToken cancellationToken)
	{
		// Short-circuit by returning cached value - never calls next()
		return _cachedOrder;
	}
}
