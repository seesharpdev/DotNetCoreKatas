using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DotNetCoreKatas.Core.Interfaces.Querying;

namespace DotNetCoreKatas.Query.Adapter.Adapters
{
	[Obsolete("Assess the need/use of this!")]
	public abstract class QueryAdapter<TType, TKey> : IQueryAdapter<TType, TKey> 
		where TType : class 
		where TKey : new()
	{
		public abstract Task<IEnumerable<TType>> GetAll();

		public abstract Task<TType> GetById(TKey id);

		public abstract Task<TType> FindBy(Predicate<TType> predicate);
	}
}
