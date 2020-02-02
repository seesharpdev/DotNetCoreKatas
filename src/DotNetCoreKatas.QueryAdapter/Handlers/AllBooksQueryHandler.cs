using System.Collections.Generic;
using System.Linq;

using DotNetCoreKatas.Core.Interfaces;
using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Persistence;
using DotNetCoreKatas.Persistence.Extensions;
using DotNetCoreKatas.Query.Contracts.Models;
using DotNetCoreKatas.Query.Contracts.Queries;

namespace DotNetCoreKatas.Query.Adapter.Handlers
{
	public class AllBooksQueryHandler : QueryHandlerBase, IAllBooksQueryHandler
    {
		public AllBooksQueryHandler(
			IDotNetCoreKatasDbContext dbContext, 
			IModelMapper<BookDomainModel, BookReadModel> mapper)
			: base(dbContext, mapper)
		{
		}
		
		public IEnumerable<BookReadModel> Handle(AllBooksQuery query)
		{
			var models = DbContext.Books.AsNoTrackingQueryable().GetAwaiter().GetResult();
			var books = models.Select(model => Mapper.Map(model))
				.AsEnumerable();

			return books;
		}
    }
}