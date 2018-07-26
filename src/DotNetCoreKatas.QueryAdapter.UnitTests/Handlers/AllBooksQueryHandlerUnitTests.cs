using System.Collections.Generic;
using System.Linq;

using Moq;
using Xunit;

using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Query.Adapter.Handlers;
using DotNetCoreKatas.Query.Adapter.Mappers;
using DotNetCoreKatas.Query.Contracts.Models;
using DotNetCoreKatas.Query.Contracts.Queries;

namespace DotNetCoreKatas.Query.Adapter.UnitTests.Handlers
{
	public class AllBooksQueryHandlerUnitTests : QueryHandlerUnitTests
	{
		private static class Factory
	    {
		    public static AllBooksQueryHandler New()
		    {
			    DbSetMock.As<IQueryable<BookDomainModel>>().Setup(m => m.Provider).Returns(BookDomainModels.Provider);
			    DbSetMock.As<IQueryable<BookDomainModel>>().Setup(m => m.Expression).Returns(BookDomainModels.Expression);
			    DbSetMock.As<IQueryable<BookDomainModel>>().Setup(m => m.ElementType).Returns(BookDomainModels.ElementType);
			    DbSetMock.As<IQueryable<BookDomainModel>>().Setup(m => m.GetEnumerator())
				    .Returns(() => BookDomainModels.GetEnumerator());

			    DbContextMock.Setup(c => c.Books)
				    .Returns(DbSetMock.Object);
				
				MapperMock.Setup(_ => _.Map(It.Is<BookDomainModel>(model => model.Id == 1)))
					.Returns(new BookReadModel { Id = 1 });

				return new AllBooksQueryHandler(DbContextMock.Object, new BookModelMapper());
		    }
		}

	    [Fact]
	    public void AllBooksQueryHandler_Should_ReturnAllItems()
	    {
			// Arrange
		    AllBooksQueryHandler handler = Factory.New();

		    // Act
		    var result = handler.Handle(new AllBooksQuery());

			// Assert
		    Assert.NotNull(result);
			var bookCount = Assert.IsAssignableFrom<IEnumerable<BookReadModel>>(result);
			Assert.Equal(3, bookCount.Count());
	    }
    }
}
