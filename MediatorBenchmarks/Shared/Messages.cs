namespace MediatorBenchmarks.Shared;

// Scenario 1: Simple command for InvokeAsync without response
public sealed record PingCommand(string Id)
{
	public static PingCommand Instance { get; } = new("test-123");
}

// Scenario 2: Query with return value for InvokeAsync<T>
public sealed record GetOrder(int Id)
{
	public static GetOrder Instance { get; } = new(42);
}

// Scenario 3: Notification for PublishAsync with multiple handlers
public sealed record UserRegisteredEvent(string UserId, string Email)
{
	public static UserRegisteredEvent Instance { get; } = new("User-456", "test@example.com");
}

// Scenario 4: FullQuery - Query with dependency injection
public record GetFullQuery(int Id)
{
	public static GetFullQuery Instance { get; } = new(42);
}

// Scenario 5: Cascading messages - command that returns result and triggers events
public sealed record CreateOrder(int CustomerId, decimal Amount)
{
	public static CreateOrder Instance { get; } = new(123, 99.99m);
}

public sealed record OrderCreatedEvent(int OrderId, int CustomerId);

// Scenario 6: Short-circuit / Cache-hit - tests middleware that returns early without calling handler
// Each library implements this with their idiomatic approach:
public record GetCachedOrder(int Id)
{
	public static GetCachedOrder Instance { get; } = new(42);
}
