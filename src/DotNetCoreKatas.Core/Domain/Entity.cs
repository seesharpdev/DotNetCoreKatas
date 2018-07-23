using DotNetCoreKatas.Core.Interfaces;

namespace DotNetCoreKatas.Core.Domain
{
	public class Entity<T> : IEntity<T> where T : new()
	{
		public virtual T Id { get; set; }
		public int Version { get; set; }
	}
}