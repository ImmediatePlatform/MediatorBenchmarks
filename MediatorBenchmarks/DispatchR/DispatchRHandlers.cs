using DispatchR;
using DispatchR.Abstractions.Notification;
using DispatchR.Abstractions.Send;
using MediatorBenchmarks.Shared;

namespace MediatorBenchmarks.DispatchR;

// Scenario 1: Command handler (InvokeAsync without response)
public sealed class DispatchRCommandHandler : IRequestHandler<PingCommand, ValueTask>
{
	public async ValueTask Handle(PingCommand request, CancellationToken cancellationToken)
	{
		// Simulate minimal work
		await ValueTask.CompletedTask;
	}
}

// Scenario 2: Query handler (InvokeAsync<T>) - No DI for baseline comparison
public sealed class DispatchRQueryHandler : IRequestHandler<GetOrder, ValueTask<Order>>
{
	public async ValueTask<Order> Handle(GetOrder request, CancellationToken cancellationToken)
	{
		// No async state machine
		return await ValueTask.FromResult(new Order(request.Id, 99.99m, DateTime.UtcNow));
	}
}

// Scenario 3: Event handlers (PublishAsync with multiple handlers)
public sealed class DispatchREventHandler : INotificationHandler<UserRegisteredEvent>
{
	public async ValueTask Handle(UserRegisteredEvent request, CancellationToken cancellationToken)
	{
		// Simulate minimal event handling work
		await ValueTask.CompletedTask;
	}
}

public sealed class DispatchREventHandler2 : INotificationHandler<UserRegisteredEvent>
{
	public async ValueTask Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
	{
		// Second handler listening for the same event
		await ValueTask.CompletedTask;
	}
}

// Scenario 4: Query handler with dependency injection
public sealed class DispatchRFullQueryHandler(IOrderService orderService) : IRequestHandler<GetFullQuery, ValueTask<Order>>
{
	public async ValueTask<Order> Handle(GetFullQuery request, CancellationToken cancellationToken)
	{
		return await orderService.GetOrderAsync(request.Id, cancellationToken).AsTask();
	}
}

// DispatchR pipeline behavior for timing (equivalent to Foundatio's middleware)
public sealed class TimingBehavior : IPipelineBehavior<GetFullQuery, ValueTask<Order>>
{
	public required IRequestHandler<GetFullQuery, ValueTask<Order>> NextPipeline { get; set; }

	public async ValueTask<Order> Handle(GetFullQuery request, CancellationToken cancellationToken)
	{
		var stopwatch = System.Diagnostics.Stopwatch.StartNew();
		try
		{
			return await NextPipeline.Handle(request, cancellationToken);
		}
		finally
		{
			stopwatch.Stop();
			// In real middleware, you'd log here
		}
	}
}

// Scenario 5: Cascading messages - DispatchR requires manual publish of events
public sealed class DispatchRCreateOrderHandler(IMediator mediator) : IRequestHandler<CreateOrder, ValueTask<Order>>
{
	public async ValueTask<Order> Handle(CreateOrder request, CancellationToken cancellationToken)
	{
		var order = new Order(1, request.Amount, DateTime.UtcNow);
		await mediator.Publish(new OrderCreatedEvent(order.Id, request.CustomerId), cancellationToken);
		return order;
	}
}

// Handlers for the cascaded OrderCreatedEvent
public sealed class DispatchROrderCreatedHandler1 : INotificationHandler<OrderCreatedEvent>
{
	public async ValueTask Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
	{
		// First handler for order created event - no async state machine
		await ValueTask.CompletedTask;
	}
}

public sealed class DispatchROrderCreatedHandler2 : INotificationHandler<OrderCreatedEvent>
{
	public async ValueTask Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
	{
		// Second handler for order created event - no async state machine
		await ValueTask.CompletedTask;
	}
}

// Scenario 6: Short-circuit handler - DispatchR uses IPipelineBehavior to short-circuit
public sealed class DispatchRShortCircuitHandler : IRequestHandler<GetCachedOrder, ValueTask<Order>>
{
	public async ValueTask<Order> Handle(GetCachedOrder request, CancellationToken cancellationToken)
	{
		// This should never be called - pipeline behavior short-circuits before reaching handler
		throw new InvalidOperationException("Short-circuit behavior should have prevented this call");
	}
}

// DispatchR short-circuit behavior - returns cached value without calling handler
public sealed class ShortCircuitBehavior : IPipelineBehavior<GetCachedOrder, ValueTask<Order>>
{
	private readonly Order _cachedOrder = new(999, 49.99m, DateTime.UtcNow);

	public required IRequestHandler<GetCachedOrder, ValueTask<Order>> NextPipeline { get; set; }

	public async ValueTask<Order> Handle(GetCachedOrder request, CancellationToken cancellationToken)
	{
		// Short-circuit by returning cached value - never calls next()
		return await ValueTask.FromResult(_cachedOrder);
	}
}
