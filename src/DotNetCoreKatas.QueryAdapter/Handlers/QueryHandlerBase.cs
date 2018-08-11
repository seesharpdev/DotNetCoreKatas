using DotNetCoreKatas.Core.Interfaces;
using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Persistence;
using DotNetCoreKatas.Query.Contracts.Models;

namespace DotNetCoreKatas.Query.Adapter.Handlers
{
	public abstract class QueryHandlerBase
	{
		internal QueryHandlerBase(
			IDotNetCoreKatasDbContext dbContext,
			IModelMapper<BookDomainModel, BookReadModel> mapper)
		{
			DbContext = dbContext;
			Mapper = mapper;
		}

		protected IDotNetCoreKatasDbContext DbContext { get; }

		protected IModelMapper<BookDomainModel, BookReadModel> Mapper { get; }
	}
}