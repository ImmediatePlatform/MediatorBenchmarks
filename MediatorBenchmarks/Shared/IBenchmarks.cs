namespace MediatorBenchmarks.Shared;

public interface IBenchmarks
{
	ValueTask<Order> CascadingMessages();
	ValueTask Command();
	ValueTask<Order> FullQuery();
	ValueTask Publish();
	ValueTask<Order> Query();
	ValueTask<Order> ShortCircuit();
}
