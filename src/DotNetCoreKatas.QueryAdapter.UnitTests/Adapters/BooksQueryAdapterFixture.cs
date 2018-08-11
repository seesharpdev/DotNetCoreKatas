using System;
using System.Collections.Generic;

using DotNetCoreKatas.Query.Contracts.Models;

namespace DotNetCoreKatas.Query.Adapter.UnitTests.Adapters
{
	public class BooksQueryAdapterFixture : IDisposable
	{
		public BooksQueryAdapterFixture()
	    {
			BookReadModels = new[]
				{
					new BookReadModel { Id = 1 },
					new BookReadModel { Id = 2 },
					new BookReadModel { Id = 3 }
				};
		}

		public IEnumerable<BookReadModel> BookReadModels { get; }

		public void Dispose()
		{
		}
	}
}
