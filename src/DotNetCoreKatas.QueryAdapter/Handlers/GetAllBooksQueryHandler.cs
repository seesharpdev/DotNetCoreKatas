using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DotNetCoreKatas.Core.Interfaces;
using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Persistence;
using DotNetCoreKatas.Persistence.Extensions;
using DotNetCoreKatas.Query.Contracts.Models;

namespace DotNetCoreKatas.Query.Adapter.Handlers
{
	public class GetAllBooksQueryHandler : IQueryHandler<IEnumerable<BookReadModel>>
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

		public async Task<IEnumerable<BookReadModel>> Handle(IQuery<IEnumerable<BookReadModel>> query)
		{
			var models = await _dbContext.Books.AsNoTrackingQueryable();
			var readModels = models.Select(m => _mapper.Map(m))
				.AsEnumerable();

			return readModels;
		}
	}
}