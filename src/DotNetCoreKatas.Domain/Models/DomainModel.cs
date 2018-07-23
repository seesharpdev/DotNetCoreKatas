using DotNetCoreKatas.Core.Domain;
using DotNetCoreKatas.Core.Interfaces;

namespace DotNetCoreKatas.Domain.Models
{
	public class DomainModel<T> : AggregateRoot<T> where T : new()
	{
		public static class Factory
		{
			public static IAggregateRoot<T> New<T>(T id) where T : new()
			{
				return new DomainModel<T>(id);
			}
		}

		private DomainModel(T id)
		{
			Id = id;
		}
	}
}