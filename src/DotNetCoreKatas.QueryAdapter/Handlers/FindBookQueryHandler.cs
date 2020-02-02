using DotNetCoreKatas.Core.Interfaces;
using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Persistence;
using DotNetCoreKatas.Query.Contracts.Models;
using DotNetCoreKatas.Query.Contracts.Queries;

namespace DotNetCoreKatas.Query.Adapter.Handlers
{
	public class FindBookQueryHandler : QueryHandlerBase, 
        IQueryHandler<FindBookQuery, BookReadModel, BookReadModel>
	{
		public FindBookQueryHandler(
			IDotNetCoreKatasDbContext dbContext,
			IModelMapper<BookDomainModel, BookReadModel> mapper)
		: base(dbContext, mapper)
		{
		}

		public BookReadModel Handle(FindBookQuery query)
		{
			var model = DbContext.Books.Find(query.Predicate);
			var book = Mapper.Map(model);

			return book;
		}
	}
}