using System.Linq;

using Xunit;
using Moq;

using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Query.Adapter.Handlers;
using DotNetCoreKatas.Query.Contracts.Models;
using DotNetCoreKatas.Query.Contracts.Queries;

namespace DotNetCoreKatas.Query.Adapter.UnitTests.Handlers
{
	public class BookByIdQueryHandlerUnitTests : QueryHandlerUnitTests
	{
	    private static class Factory
	    {
		    internal static BookByIdQueryHandler New()
		    {
			    DbSetMock.As<IQueryable<BookDomainModel>>().Setup(m => m.Provider).Returns(BookDomainModels.Provider);
			    DbSetMock.As<IQueryable<BookDomainModel>>().Setup(m => m.Expression).Returns(BookDomainModels.Expression);
			    DbSetMock.As<IQueryable<BookDomainModel>>().Setup(m => m.ElementType).Returns(BookDomainModels.ElementType);
			    DbSetMock.As<IQueryable<BookDomainModel>>().Setup(m => m.GetEnumerator())
				    .Returns(() => BookDomainModels.GetEnumerator());

			    DbContextMock.Setup(c => c.Books)
				    .Returns(DbSetMock.Object);

			    DbSetMock.Setup(_ => _.Find(It.IsAny<object[]>()))
				    .Returns(BookDomainModels.FirstOrDefault());

			    MapperMock.Setup(_ => _.Map(It.Is<BookDomainModel>(model => model.Id == 1)))
				    .Returns(new BookReadModel { Id = 1 });

				return new BookByIdQueryHandler(DbContextMock.Object, MapperMock.Object);
		    }
		}

	    [Fact]
	    public void GetBookById_Should_Handle()
	    {
		    // Arrange
		    var handler = Factory.New();
		    var query = new BookByIdQuery { Id = 1 };

		    // Act
		    var result = handler.Handle(query);

		    // Assert
		    Assert.NotNull(result);
		    Assert.IsAssignableFrom<BookReadModel>(result);
	    }
	}
}
