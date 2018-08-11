using DotNetCoreKatas.Core.Interfaces;

namespace DotNetCoreKatas.Core.Domain
{
	public abstract class AggregateRoot<T> 
		: Entity<T>, IAggregateRoot<T> where T : new()
	{
	}
}