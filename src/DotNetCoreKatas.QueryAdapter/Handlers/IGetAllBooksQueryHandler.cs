using System.Collections.Generic;

using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Query.Contracts.Models;
using DotNetCoreKatas.Query.Contracts.Queries;

namespace DotNetCoreKatas.Query.Adapter.Handlers
{
	public interface IGetAllBooksQueryHandler : IQueryHandler<GetAllBooksQuery, IEnumerable<BookReadModel>>
	{
		
	}
}