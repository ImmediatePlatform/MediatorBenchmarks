using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
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
		return new Order(query.Id, 99.99m);
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
		var order = new Order(1, command.Amount);
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

// Scenario 7: Stream Query Handler
public sealed class DirectStreamQueryHandler
{
	public async IAsyncEnumerable<Order> HandleAsync(GetStreamQuery query, [EnumeratorCancellation] CancellationToken cancellationToken = default)
	{
		foreach (var _ in Enumerable.Range(1, 3))
			yield return new Order(query.Id, 99.99m);
	}
}

// Scenario 8: Stream Query handler with dependency injection
public sealed class DirectStreamFullQueryHandler(IOrderService orderService)
{
	private readonly TextWriter _writer = TextWriter.Null;

	[SuppressMessage("Usage", "MA0040:Forward the CancellationToken parameter to methods that take one", Justification = "WriteLineAsync() doesn't have a proper method")]
	[SuppressMessage("Reliability", "CA2016:Forward the 'CancellationToken' parameter to methods", Justification = "WriteLineAsync() doesn't have a proper method")]
	public async IAsyncEnumerable<Order> HandleAsync(GetStreamFullQuery query, [EnumeratorCancellation] CancellationToken cancellationToken = default)
	{
		await _writer.WriteLineAsync("-- Handling StreamRequest");

		await foreach (var response in GetStream(query, cancellationToken))
		{
			await _writer.WriteLineAsync($"-- Process Item {response}");
			yield return response;
		}

		await _writer.WriteLineAsync("-- Finished StreamRequest");
	}

	private async IAsyncEnumerable<Order> GetStream(GetStreamFullQuery query, [EnumeratorCancellation] CancellationToken cancellationToken = default)
	{
		foreach (var _ in Enumerable.Range(1, 3))
			yield return await orderService.GetOrderAsync(query.Id, cancellationToken);
	}
}
