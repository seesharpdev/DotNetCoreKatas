using DotNetCoreKatas.Core.Interfaces;
using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Persistence;
using DotNetCoreKatas.Query.Contracts.Models;
using DotNetCoreKatas.Query.Contracts.Queries;

namespace DotNetCoreKatas.Query.Adapter.Handlers
{
	public class GetBookByIdQueryHandler : IQueryHandler<GetBookByIdQuery, BookReadModel>
	{
		private readonly IDotNetCoreKatasDbContext _dbContext;
		private readonly IModelMapper<BookDomainModel, BookReadModel> _mapper;

		public GetBookByIdQueryHandler(
			IDotNetCoreKatasDbContext dbContext, 
			IModelMapper<BookDomainModel, BookReadModel> mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public BookReadModel Handle(GetBookByIdQuery query)
		{
			var model = _dbContext.Books.Find(query.Id);
			var book = _mapper.Map(model);

			return book;
		}
	}
}