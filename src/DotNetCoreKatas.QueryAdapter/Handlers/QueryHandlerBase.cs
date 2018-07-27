using DotNetCoreKatas.Core.Interfaces;
using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Persistence;
using DotNetCoreKatas.Query.Contracts.Models;

namespace DotNetCoreKatas.Query.Adapter.Handlers
{
	public class QueryHandlerBase
	{
		public QueryHandlerBase(
			IDotNetCoreKatasDbContext dbContext,
			IModelMapper<BookDomainModel, BookReadModel> mapper)
		{
			DbContext = dbContext;
			Mapper = mapper;
		}

		public IDotNetCoreKatasDbContext DbContext { get; }

		public IModelMapper<BookDomainModel, BookReadModel> Mapper { get; }
	}
}