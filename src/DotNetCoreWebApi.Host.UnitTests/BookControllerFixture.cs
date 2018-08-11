using System;
using System.Collections.Generic;

using DotNetCoreKatas.Query.Contracts.Models;

namespace DotNetCoreWebApi.Host.UnitTests
{
	public class BookControllerFixture : IDisposable
	{
		public BookControllerFixture()
		{
			ReadModels = new[]
				{
					new BookReadModel { Id = 1 }
				};
		}

	    public IEnumerable<BookReadModel> ReadModels { get; }

		public void Dispose()
	    {
	    }
    }
}
