namespace DotNetCoreKatas.Core.Interfaces
{
	public interface IAggregateRoot<out T>
	{
		T Id { get; }
	}
}