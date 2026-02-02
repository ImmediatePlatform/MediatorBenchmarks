namespace MediatorBenchmarks.Shared;

public record Order(int Id, decimal Amount, DateTime Date)
{
	public static Order Instance { get; } = new(999, 49.99m, DateTime.UtcNow);
}

public interface IOrderService
{
	ValueTask<Order> GetOrderAsync(int id, CancellationToken cancellationToken = default);
}

public sealed class OrderService : IOrderService
{
	private readonly Order _cachedOrder = Order.Instance;

	public async ValueTask<Order> GetOrderAsync(int id, CancellationToken cancellationToken = default)
	{
		// Simulate minimal async work
		return _cachedOrder;
	}
}
