using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreKatas.QueryAdapter.Interfaces
{
	// TODO: Move to DotNetCoreKatas.Core.Interfaces.Querying
	public interface IQueryAdapter<TType, in TKey> 
		where TType : class
		where TKey : new()
	{
		Task<IEnumerable<TType>> GetAll();
		Task<TType> GetById(TKey id);
		Task<TType> FindBy(Predicate<TType> predicate);
	}
}