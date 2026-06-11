using Axent.Abstractions.Attributes;
using Axent.Abstractions.Models;
using Axent.Abstractions.Requests;

namespace MediatorBenchmarks.Shared;

// Scenario 1: Simple command for InvokeAsync without response
[Axent]
public sealed partial record PingCommand : IRequest<Unit>;

// Scenario 2: Query with return value for InvokeAsync<T>
[Axent]
public sealed partial record GetOrder : IRequest<Order>;

// Scenario 3: Notification for PublishAsync with multiple handlers
/* Unsupported */

// Scenario 4: FullQuery - Query with dependency injection
[Axent]
public sealed partial record GetFullQuery : IRequest<Order>;

// Scenario 5: Cascading messages - command that returns result and triggers events
/* Unsupported */

// Scenario 6: Short-circuit / Cache-hit - tests middleware that returns early without calling handler
// Each library implements this with their idiomatic approach:
[Axent]
public sealed partial record GetCachedOrder : IRequest<Order>;
