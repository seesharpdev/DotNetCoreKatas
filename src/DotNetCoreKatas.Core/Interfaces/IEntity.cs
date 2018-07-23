namespace DotNetCoreKatas.Core.Interfaces
{
	public interface IEntity<T> where T : new()
	{
		T Id { get; set; }
		int Version { get; set; }
	}
}