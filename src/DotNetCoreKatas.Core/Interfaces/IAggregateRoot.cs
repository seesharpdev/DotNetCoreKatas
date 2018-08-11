namespace DotNetCoreKatas.Core.Interfaces
{
	/// <summary>
	/// Represents a Bounded Context Aggregate Root contract.
	/// </summary>
	/// <typeparam name="T">The Aggregate Root unique identifier type.</typeparam>
	public interface IAggregateRoot<T> : IEntity<T> where T : new()
	{
	}
}