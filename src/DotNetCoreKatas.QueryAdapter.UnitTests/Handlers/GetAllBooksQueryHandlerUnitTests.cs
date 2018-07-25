using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

using DotNetCoreKatas.Core.Interfaces;
using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Persistence;
using DotNetCoreKatas.Query.Adapter.Handlers;
using DotNetCoreKatas.Query.Adapter.Mappers;
using DotNetCoreKatas.Query.Contracts.Models;
using DotNetCoreKatas.Query.Contracts.Queries;

namespace DotNetCoreKatas.Query.Adapter.UnitTests.Handlers
{
	public class GetAllBooksQueryHandlerUnitTests
    {
	    private static readonly Mock<DotNetCoreKatasDbContext> DbContextMock = new Mock<DotNetCoreKatasDbContext>();
	    private static readonly Mock<DbSet<BookDomainModel>> DbSetMock = new Mock<DbSet<BookDomainModel>>(MockBehavior.Strict);
		private static readonly Mock<IModelMapper<BookDomainModel, BookReadModel>> MapperMock =
			new Mock<IModelMapper<BookDomainModel, BookReadModel>>();

		private static class Factory
	    {
		    public static GetAllBooksQueryHandler New()
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

				return new GetAllBooksQueryHandler(DbContextMock.Object, new BookModelMapper());
		    }
		}

	    [Fact]
	    public void GetAllBooks_Should_Handler()
	    {
			// Arrange
			IQueryHandler<IEnumerable<BookReadModel>> handler = Factory.New();

		    // Act
		    var result = handler.Handle(new GetAllBookQuery());

			// Assert
		    Assert.NotNull(result);
			var bookCount = Assert.IsAssignableFrom<IEnumerable<BookReadModel>>(result.Result);
			Assert.Equal(3, bookCount.Count());
	    }
    }
}
