using Mediator;

namespace MediatorBenchmarks.Shared;

// Scenario 1: Simple command for InvokeAsync without response
public sealed partial record PingCommand : ICommand;

// Scenario 2: Query with return value for InvokeAsync<T>
public sealed partial record GetOrder : IQuery<Order>;

// Scenario 3: Notification for PublishAsync with multiple handlers
public sealed partial record UserRegisteredEvent : INotification;

// Scenario 4: FullQuery - Query with dependency injection
public sealed partial record GetFullQuery : IQuery<Order>;

// Scenario 5: Cascading messages - command that returns result and triggers events
public sealed partial record CreateOrder : IRequest<Order>;

public sealed partial record OrderCreatedEvent : INotification;

// Scenario 6: Short-circuit / Cache-hit - tests middleware that returns early without calling handler
// Each library implements this with their idiomatic approach:
public sealed partial record GetCachedOrder : IQuery<Order>;
