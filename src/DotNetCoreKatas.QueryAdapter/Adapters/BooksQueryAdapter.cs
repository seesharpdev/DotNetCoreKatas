using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Query.Contracts.Models;
using DotNetCoreKatas.Query.Contracts.Queries;

namespace DotNetCoreKatas.Query.Adapter.Adapters
{
	public class BooksQueryAdapter : IQueryAdapter<BookReadModel, int>
	{
		private readonly IQueryProcessor _queryProcessor;

		public BooksQueryAdapter(IQueryProcessor queryProcessor)
		{
			_queryProcessor = queryProcessor;
		}

		public async Task<IEnumerable<BookReadModel>> GetAll()
		{
			var query = new AllBooksQuery();
			var books = await Task.Run(() => _queryProcessor.Process(query));

			return books;
		}

		public async Task<BookReadModel> GetById(int id)
		{
			var query = new BookByIdQuery { Id = id };
			var book = await Task.Run(() => _queryProcessor.Process(query));

			return book;
		}

		public async Task<BookReadModel> FindBy(Predicate<BookReadModel> predicate)
		{
			var query = new FindBookQuery { Predicate = predicate };
			var book = await Task.Run(() => _queryProcessor.Process(query));

			return book;
		}
	}
}