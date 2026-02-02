using System.Diagnostics;
using MassTransit;
using MediatorBenchmarks.Shared;

namespace MediatorBenchmarks.MassTransit;

// Scenario 1: Command handler (InvokeAsync without response)
public sealed class MassTransitCommandConsumer : IConsumer<PingCommand>
{
	public async Task Consume(ConsumeContext<PingCommand> context)
	{
		// Simulate minimal work
	}
}

// Scenario 2: Query handler (InvokeAsync<T>) - No DI for baseline comparison
public sealed class MassTransitQueryConsumer : IConsumer<GetOrder>
{
	public async Task Consume(ConsumeContext<GetOrder> context)
	{
		await context.RespondAsync(new Order(context.Message.Id, 99.99m, DateTime.UtcNow));
	}
}

// Scenario 3: Event handlers (PublishAsync with multiple handlers)
public sealed class MassTransitEventConsumer : IConsumer<UserRegisteredEvent>
{
	public async Task Consume(ConsumeContext<UserRegisteredEvent> context)
	{
		// Simulate minimal event handling work
	}
}

public sealed class MassTransitEventConsumer2 : IConsumer<UserRegisteredEvent>
{
	public async Task Consume(ConsumeContext<UserRegisteredEvent> context)
	{
		// Second handler listening for the same event
	}
}

// Scenario 4: Query handler with dependency injection
public sealed class MassTransitFullQueryConsumer(IOrderService orderService) : IConsumer<GetFullQuery>
{
	public async Task Consume(ConsumeContext<GetFullQuery> context)
	{
		var order = await orderService.GetOrderAsync(context.Message.Id);
		await context.RespondAsync(order);
	}
}

// MassTransit timing filter for FullQuery benchmark (equivalent to Foundatio's TimingMiddleware)
public sealed class MassTransitTimingFilter<T> : IFilter<ConsumeContext<T>> where T : class
{
	public async Task Send(ConsumeContext<T> context, IPipe<ConsumeContext<T>> next)
	{
		var stopwatch = Stopwatch.StartNew();
		try
		{
			await next.Send(context);
		}
		finally
		{
			stopwatch.Stop();
			// In real middleware, you'd log here - we just stop the timer for the benchmark
		}
	}

	public void Probe(ProbeContext context)
	{
		_ = context.CreateFilterScope("timing");
	}
}

// Scenario 5: Cascading messages - MassTransit requires manual publish of events
public sealed class MassTransitCreateOrderConsumer : IConsumer<CreateOrder>
{
	public async Task Consume(ConsumeContext<CreateOrder> context)
	{
		var order = new Order(1, context.Message.Amount, DateTime.UtcNow);
		await context.Publish(new OrderCreatedEvent(order.Id, context.Message.CustomerId));
		await context.RespondAsync(order);
	}
}

// Handlers for the cascaded OrderCreatedEvent
public sealed class MassTransitOrderCreatedConsumer1 : IConsumer<OrderCreatedEvent>
{
	public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
	{
		// First handler for order created event
	}
}

public sealed class MassTransitOrderCreatedConsumer2 : IConsumer<OrderCreatedEvent>
{
	public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
	{
		// Second handler for order created event
	}
}

// Scenario 6: Short-circuit handler - MassTransit uses a filter to short-circuit before reaching the consumer.
public sealed class MassTransitShortCircuitConsumer : IConsumer<GetCachedOrder>
{
	public async Task Consume(ConsumeContext<GetCachedOrder> context)
	{
		// This should never be called - filter short-circuits before reaching consumer
		throw new InvalidOperationException("Short-circuit filter should have prevented this call");
	}
}

// MassTransit short-circuit filter - returns cached value without calling the consumer
// Must be generic for UseConsumeFilter registration, but only short-circuits GetCachedOrder
public sealed class MassTransitShortCircuitFilter<T> : IFilter<ConsumeContext<T>> where T : class
{
	private readonly Order _cachedOrder = new(999, 49.99m, DateTime.UtcNow);

	public async Task Send(ConsumeContext<T> context, IPipe<ConsumeContext<T>> next)
	{
		// Only short-circuit for GetCachedOrder messages
		if (context.Message is GetCachedOrder)
		{
			// Short-circuit by responding with cached value - never calls next()
			await context.NotifyConsumed(context.ReceiveContext.ElapsedTime, TypeCache<MassTransitShortCircuitFilter<T>>.ShortName);
			await context.RespondAsync(_cachedOrder);
			return;
		}

		// Pass through for all other message types
		await next.Send(context);
	}

	public void Probe(ProbeContext context)
	{
		_ = context.CreateFilterScope("short-circuit");
	}
}
