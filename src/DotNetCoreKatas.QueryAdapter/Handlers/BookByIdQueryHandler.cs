﻿using DotNetCoreKatas.Core.Interfaces;
using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Persistence;
using DotNetCoreKatas.Query.Contracts.Models;
using DotNetCoreKatas.Query.Contracts.Queries;

namespace DotNetCoreKatas.Query.Adapter.Handlers
{
	public class BookByIdQueryHandler : QueryHandlerBase, IQueryHandler<BookByIdQuery, BookReadModel>
	{
		public BookByIdQueryHandler(
			IDotNetCoreKatasDbContext dbContext, 
			IModelMapper<BookDomainModel, BookReadModel> mapper)
		: base(dbContext, mapper)
		{
		}

		public BookReadModel Handle(BookByIdQuery query)
		{
			var model = DbContext.Books.Find(query.Id);
			var book = Mapper.Map(model);

			return book;
		}
	}
}