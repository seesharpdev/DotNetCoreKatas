using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DotNetCoreKatas.Core.Interfaces; // => IModelMapper
using DotNetCoreKatas.Core.Interfaces.Querying; // => IQueryProcessor
using DotNetCoreKatas.Domain.Models; // => Can be removed!
using DotNetCoreKatas.Persistence; // => Can be removed!
using DotNetCoreKatas.Query.Contracts.Models; // => ReadModels
using DotNetCoreKatas.Query.Contracts.Queries;

namespace DotNetCoreKatas.Query.Adapter.Adapters
{
	public class BooksQueryAdapter : IQueryAdapter<BookReadModel, int>
	{
		// TODO: Break dependency on EF/ORM by introducing a QueryProcessor<IEnumerable<QueryHandler<T>>>
		private readonly IDotNetCoreKatasDbContext _dbContext;
		private readonly IModelMapper<BookDomainModel, BookReadModel> _mapper;
		private readonly IQueryProcessor _queryProcessor;

		public BooksQueryAdapter(
			IDotNetCoreKatasDbContext dbContext, 
			IModelMapper<BookDomainModel, BookReadModel> mapper,
			IQueryProcessor queryProcessor)
		{
			_dbContext = dbContext;
			_mapper = mapper;
			_queryProcessor = queryProcessor;
		}

		public async Task<IEnumerable<BookReadModel>> GetAll()
		{
			var query = new AllBooksQuery();
			var books = await Task.FromResult(_queryProcessor.Process(query));

			return books;
		}

		public async Task<BookReadModel> GetById(int id)
		{
			var model = await _dbContext.Books.FindAsync(id);
			var readModel = _mapper.Map(model);

			return readModel;
		}

		public async Task<BookReadModel> FindBy(Predicate<BookReadModel> predicate)
		{
			var model = await Task.Run(() => _dbContext.Books.Find(predicate));
			var readModel = _mapper.Map(model);

			return readModel;
		}
	}
}