using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCoreKatas.QueryAdapter.Contracts;
using DotNetCoreKatas.QueryAdapter.Interfaces;

namespace DotNetCoreKatas.QueryAdapter.Adapters
{
	public abstract class QueryAdapter<TType, TKey> : IQueryAdapter<TType, TKey> 
		where TType : class 
		where TKey : new()
	{
		public abstract Task<IEnumerable<TType>> GetAll();

		public abstract Task<TType> GetById(TKey id);

		public abstract Task<TType> FindBy(Predicate<TType> predicate);
	}
}
