using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DotNetCoreKatas.Core.Interfaces;
using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Persistence;
using DotNetCoreKatas.Persistence.Extensions;
using DotNetCoreKatas.Query.Contracts.Adapters;
using DotNetCoreKatas.Query.Contracts.Models;

namespace DotNetCoreKatas.Query.Adapter.Adapters
{
	public class BooksQueryAdapter : QueryAdapter<BookReadModel, int>, IBooksQueryAdapter
	{
		// TODO: Break dependency on EF/ORM by introducing a QueryHandlerRegistry<IEnumerable<QueryHandler<T>>>
		private readonly IDotNetCoreKatasDbContext _dbContext;
		private readonly IModelMapper<BookDomainModel, BookReadModel> _mapper;

		public BooksQueryAdapter(
			IDotNetCoreKatasDbContext dbContext, 
			IModelMapper<BookDomainModel, BookReadModel> mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		// TODO: Implement and inject a IQueryHandlerRegistry to resolve GetAllBooksQueryHandler and execute it.
		public override async Task<IEnumerable<BookReadModel>> GetAll()
		{
			var models = await _dbContext.Books.AsNoTrackingQueryable();
			var readModels = models.Select(m => _mapper.Map(m))
				.AsEnumerable();

			return readModels;
		}

		public override async Task<BookReadModel> GetById(int id)
		{
			var model = await _dbContext.Books.FindAsync(id);
			var readModel = _mapper.Map(model);

			return readModel;
		}

		public override async Task<BookReadModel> FindBy(Predicate<BookReadModel> predicate)
		{
			var model = await Task.Run(() => _dbContext.Books.Find(predicate));
			var readModel = _mapper.Map(model);

			return readModel;
		}
	}
}