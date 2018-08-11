namespace DotNetCoreKatas.Core.Interfaces
{
	public interface IEntity<T> : IEntity where T : new()
	{
		T Id { get; }
		int Version { get; }
	}

	public interface IEntity
	{
	}
}