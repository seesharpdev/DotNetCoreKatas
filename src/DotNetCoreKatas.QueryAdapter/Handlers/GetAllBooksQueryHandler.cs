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
	public class GetAllBooksQueryHandler : IGetAllBooksQueryHandler //IQueryHandler<GetAllBooksQuery, IEnumerable<BookReadModel>>
	{
		private readonly IDotNetCoreKatasDbContext _dbContext;
		private readonly IModelMapper<BookDomainModel, BookReadModel> _mapper;

		public GetAllBooksQueryHandler(
			IDotNetCoreKatasDbContext dbContext, 
			IModelMapper<BookDomainModel, BookReadModel> mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}
		
		public IEnumerable<BookReadModel> Handle(GetAllBooksQuery query)
		{
			var models = _dbContext.Books.AsNoTrackingQueryable().Result;
			var readModels = models.Select(m => _mapper.Map(m))
				.AsEnumerable();

			return readModels;
		}
	}
}