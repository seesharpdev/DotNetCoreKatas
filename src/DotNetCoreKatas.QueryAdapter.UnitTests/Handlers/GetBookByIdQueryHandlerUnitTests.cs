using System.Collections.Generic;
using System.Linq;

using Xunit;
using Moq;

using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Query.Adapter.Handlers;
using DotNetCoreKatas.Query.Contracts.Models;
using DotNetCoreKatas.Query.Contracts.Queries;

namespace DotNetCoreKatas.Query.Adapter.UnitTests.Handlers
{
	public class GetBookByIdQueryHandlerUnitTests : QueryHandlerUnitTests
	{
	    private static class Factory
	    {
		    internal static IQueryHandler<GetBookByIdQuery, BookReadModel> New()
		    {
			    var data = new List<BookDomainModel>
				    {
					    new BookDomainModel(1),
					    new BookDomainModel(2),
					    new BookDomainModel(3)
				    }.AsQueryable();

			    DbSetMock.As<IQueryable<BookDomainModel>>().Setup(m => m.Provider).Returns(data.Provider);
			    DbSetMock.As<IQueryable<BookDomainModel>>().Setup(m => m.Expression).Returns(data.Expression);
			    DbSetMock.As<IQueryable<BookDomainModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
			    DbSetMock.As<IQueryable<BookDomainModel>>().Setup(m => m.GetEnumerator())
				    .Returns(() => data.GetEnumerator());

			    DbContextMock.Setup(c => c.Books)
				    .Returns(DbSetMock.Object);
			    DbSetMock.Setup(_ => _.Find(It.IsAny<object[]>()))
				    .Returns(data.FirstOrDefault());

			    MapperMock.Setup(_ => _.Map(It.Is<BookDomainModel>(model => model.Id == 1)))
				    .Returns(new BookReadModel { Id = 1 });

				return new GetBookByIdQueryHandler(DbContextMock.Object, MapperMock.Object);
		    }
		}

	    [Fact]
	    public void GetBookById_Should_Handle()
	    {
		    // Arrange
		    var handler = Factory.New();
		    var query = new GetBookByIdQuery { Id = 1 };

		    // Act
		    var result = handler.Handle(query);

		    // Assert
		    Assert.NotNull(result);
		    Assert.IsAssignableFrom<BookReadModel>(result);
	    }
	}
}
