using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.QueryAdapter.Contracts;
using DotNetCoreKatas.QueryAdapter.Interfaces;
using DotNetCoreKatas.QueryAdapter.Mappers;
using DotNetCoreKatas.Persistence;
using DotNetCoreKatas.Persistence.Extensions;

namespace DotNetCoreKatas.QueryAdapter.Adapters
{
	public class BooksQueryAdapter : QueryAdapter<BookReadModel, int>, IBooksQueryAdapter
	{
		// TODO: Break dependency on EF/ORM by introducing a QueryHandlerRegistry<IEnumerable<QueryHandler<T>>>
		private readonly IDotNetCoreKatasDbContext _dbContext;
		private readonly IModelMapper<BookDomainModel, BookReadModel> _mapper;

		public BooksQueryAdapter(IDotNetCoreKatasDbContext dbContext, IModelMapper<BookDomainModel, BookReadModel> mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public override Task<IEnumerable<BookReadModel>> GetAll()
		{
			var models = _dbContext.Books.AsNoTrackingQueryable();
			var readModels = models.Select(m => _mapper.Map(m)).AsEnumerable();

			return Task.FromResult(readModels);
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