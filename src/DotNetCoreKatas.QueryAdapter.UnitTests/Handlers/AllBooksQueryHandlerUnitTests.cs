using System.Collections.Generic;
using System.Linq;

using Moq;
using Xunit;

using DotNetCoreKatas.Core.Interfaces.Querying;
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

			    DbSetMock.Setup(_ => _.FindAsync(It.IsAny<object[]>()))
				    .ReturnsAsync(data.FirstOrDefault());

			    DbSetMock.Setup(_ => _.Find(It.IsAny<object[]>()))
				    .Returns(data.FirstOrDefault());

				MapperMock.Setup(_ => _.Map(It.Is<BookDomainModel>(model => model.Id == 1)))
					.Returns(new BookReadModel { Id = 1 });

				return new AllBooksQueryHandler(DbContextMock.Object, new BookModelMapper());
		    }
		}

	    [Fact]
	    public void GetAllBooks_Should_Handle()
	    {
			// Arrange
			IQueryHandler<AllBooksQuery, IEnumerable<BookReadModel>> handler = Factory.New();

		    // Act
		    var result = handler.Handle(new AllBooksQuery());

			// Assert
		    Assert.NotNull(result);
			var bookCount = Assert.IsAssignableFrom<IEnumerable<BookReadModel>>(result);
			Assert.Equal(3, bookCount.Count());
	    }
    }
}
