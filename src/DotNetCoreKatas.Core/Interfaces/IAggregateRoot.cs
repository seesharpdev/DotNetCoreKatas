namespace DotNetCoreKatas.Core.Interfaces
{
	/// <summary>
	/// Represents a Bounded Context Aggregate Root contract.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IAggregateRoot<out T>
	{
		T Id { get; }
	}
}