using DotNetCoreKatas.Core.Interfaces;

namespace DotNetCoreKatas.Core.Domain
{
	public abstract class Entity<T> : IEntity<T> where T : new()
	{
		public virtual T Id { get; set; }
		public virtual int Version { get; set; }
	}
}