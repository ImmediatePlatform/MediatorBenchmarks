using MediatorBenchmarks.Shared;
using MediatR;

namespace MediatorBenchmarks.MediatR;

// Scenario 1: Command handler (InvokeAsync without response)
public sealed class MediatRCommandHandler : IRequestHandler<PingCommand>
{
	public async Task Handle(PingCommand request, CancellationToken cancellationToken)
	{
		// Simulate minimal work
		await Task.CompletedTask;
	}
}

// Scenario 2: Query handler (InvokeAsync<T>) - No DI for baseline comparison
public sealed class MediatRQueryHandler : IRequestHandler<GetOrder, Order>
{
	public async Task<Order> Handle(GetOrder request, CancellationToken cancellationToken)
	{
		// No async state machine
		return await Task.FromResult(new Order(request.Id, 99.99m, DateTime.UtcNow));
	}
}

// Scenario 3: Event handlers (PublishAsync with multiple handlers)
public sealed class MediatREventHandler : INotificationHandler<UserRegisteredEvent>
{
	public async Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
	{
		// Simulate minimal event handling work
		await Task.CompletedTask;
	}
}

public sealed class MediatREventHandler2 : INotificationHandler<UserRegisteredEvent>
{
	public async Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
	{
		// Second handler listening for the same event
		await Task.CompletedTask;
	}
}

// Scenario 4: Query handler with dependency injection
public sealed class MediatRFullQueryHandler(IOrderService orderService) : IRequestHandler<GetFullQuery, Order>
{
	public async Task<Order> Handle(GetFullQuery request, CancellationToken cancellationToken)
	{
		return await orderService.GetOrderAsync(request.Id, cancellationToken).AsTask();
	}
}

// Scenario 5: Cascading messages - MediatR requires manual publish of events
public sealed class MediatRCreateOrderHandler(IMediator mediator) : IRequestHandler<CreateOrder, Order>
{
	public async Task<Order> Handle(CreateOrder request, CancellationToken cancellationToken)
	{
		var order = new Order(1, request.Amount, DateTime.UtcNow);
		await mediator.Publish(new OrderCreatedEvent(order.Id, request.CustomerId), cancellationToken);
		return order;
	}
}

// Handlers for the cascaded OrderCreatedEvent
public sealed class MediatROrderCreatedHandler1 : INotificationHandler<OrderCreatedEvent>
{
	public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
	{
		// First handler for order created event
		await Task.CompletedTask;
	}
}

public sealed class MediatROrderCreatedHandler2 : INotificationHandler<OrderCreatedEvent>
{
	public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
	{
		// Second handler for order created event
		await Task.CompletedTask;
	}
}

// MediatR pipeline behavior for timing (equivalent to Foundatio's middleware)
public sealed class TimingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : notnull
{
	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		var stopwatch = System.Diagnostics.Stopwatch.StartNew();
		try
		{
			return await next(cancellationToken);
		}
		finally
		{
			stopwatch.Stop();
			// In real middleware, you'd log here
		}
	}
}

// Scenario 6: Short-circuit handler - MediatR uses IPipelineBehavior to short-circuit
public sealed class MediatRShortCircuitHandler : IRequestHandler<GetCachedOrder, Order>
{
	public async Task<Order> Handle(GetCachedOrder request, CancellationToken cancellationToken)
	{
		// This should never be called - pipeline behavior short-circuits before reaching handler
		throw new InvalidOperationException("Short-circuit behavior should have prevented this call");
	}
}

// MediatR short-circuit behavior - returns cached value without calling handler
public sealed class ShortCircuitBehavior : IPipelineBehavior<GetCachedOrder, Order>
{
	private readonly Order _cachedOrder = new(999, 49.99m, DateTime.UtcNow);

	public async Task<Order> Handle(GetCachedOrder request, RequestHandlerDelegate<Order> next, CancellationToken cancellationToken)
	{
		// Short-circuit by returning cached value - never calls next()
		return await Task.FromResult(_cachedOrder);
	}
}
