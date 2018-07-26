using System.Collections.Generic;
using System.Linq;

using Autofac.Extras.Moq;
using Moq;
using Xunit;

using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Query.Adapter.Adapters;
using DotNetCoreKatas.Query.Contracts.Models;
using DotNetCoreKatas.Query.Contracts.Queries;

namespace DotNetCoreKatas.Query.Adapter.UnitTests.Adapters
{
	public class BooksQueryAdapterUnitTests
	{
		private static readonly IEnumerable<BookReadModel> BookReadModels = new[]
			{
				new BookReadModel { Id = 1 },
				new BookReadModel { Id = 2 },
				new BookReadModel { Id = 3 }
			};
		
	    [Fact]
	    public void QueryAdapter_Should_ReturnAllItems()
	    {
		    using (var mock = AutoMock.GetStrict())
		    {
				// Arrange
				mock.Mock<IQueryProcessor>()
					.Setup(x => x.Process(It.IsAny<AllBooksQuery>()))
					.Returns(BookReadModels);

				var adapter = mock.Create<BooksQueryAdapter>();

				// Act
				var response = adapter.GetAll();

				// Assert
				Assert.NotNull(response);
				var books = Assert.IsAssignableFrom<IEnumerable<BookReadModel>>(response.Result);
				Assert.Equal(3, books.Count());
			    mock.Mock<IQueryProcessor>().VerifyAll();
			}
		}

		[Fact]
		public void QueryAdapter_Should_GetById()
		{
			using (var mock = AutoMock.GetStrict())
			{
				// Arrange
				const int bookId = 1;
				mock.Mock<IQueryProcessor>()
					.Setup(x => x.Process(It.Is<BookByIdQuery>(q => q.Id == 1)))
					.Returns(BookReadModels.FirstOrDefault(b => b.Id == 1));

				var adapter = mock.Create<BooksQueryAdapter>();

				// Act
				var response = adapter.GetById(bookId);

				// Assert
				Assert.NotNull(response);
				Assert.IsAssignableFrom<BookReadModel>(response.Result);
				Assert.Equal(bookId, response.Result.Id);
				mock.Mock<IQueryProcessor>().VerifyAll();
			}
		}

		[Fact]
		public void QueryAdapter_Should_FindByPredicate()
		{
			using (var mock = AutoMock.GetStrict())
			{
				// Arrange
				const int bookId = 2;
				mock.Mock<IQueryProcessor>()
					.Setup(x => x.Process(It.IsAny<FindBookQuery>()))
					.Returns(BookReadModels.FirstOrDefault(b => b.Id == bookId));

				var adapter = mock.Create<BooksQueryAdapter>();

				// Act
				var response = adapter.FindBy(book => book.Id == bookId);

				// Assert
				Assert.NotNull(response);
				Assert.IsAssignableFrom<BookReadModel>(response.Result);
				Assert.Equal(bookId, response.Result.Id);
				mock.Mock<IQueryProcessor>().VerifyAll();
			}
		}

	}
}
