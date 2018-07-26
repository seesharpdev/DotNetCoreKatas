using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

using DotNetCoreKatas.Core.Interfaces;
using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Persistence;
using DotNetCoreKatas.Query.Adapter.Adapters;
using DotNetCoreKatas.Query.Contracts.Models;

namespace DotNetCoreKatas.Query.Adapter.UnitTests.Adapters
{
	public class BooksQueryAdapterUnitTests
	{
		private static readonly Mock<DotNetCoreKatasDbContext> DbContextMock = new Mock<DotNetCoreKatasDbContext>();
		private static readonly Mock<DbSet<BookDomainModel>> DbSetMock = new Mock<DbSet<BookDomainModel>>(MockBehavior.Strict);
		private static readonly Mock<IModelMapper<BookDomainModel, BookReadModel>> MapperMock =
			new Mock<IModelMapper<BookDomainModel, BookReadModel>>();

		private static readonly Mock<IQueryProcessor> QueryProcessorMock = new Mock<IQueryProcessor>();

		private static class Factory
	    {
			internal static IQueryAdapter<BookReadModel, int> New()
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

			    QueryProcessorMock.Setup(_ => _.Process(It.IsAny<IQuery<IEnumerable<BookReadModel>>>()))
				    .Returns(new[] { new BookReadModel { Id = 1 }, new BookReadModel { Id = 2 }, new BookReadModel { Id = 3 } });

				return new BooksQueryAdapter(DbContextMock.Object, MapperMock.Object, QueryProcessorMock.Object);
		    }
		}
		
	    [Fact]
	    public void QueryAdapter_Should_ReturnAllItems()
	    {
			// Arrange
		    var adapter = Factory.New();

		    // Act
		    var response = adapter.GetAll();

		    // Assert
			Assert.NotNull(response);
		    var books = Assert.IsAssignableFrom<IEnumerable<BookReadModel>>(response.Result);
			Assert.Equal(3, books.Count());
	    }

	    [Fact]
	    public void QueryAdapter_Should_ReturnById()
	    {
			// Arrange
		    var adapter = Factory.New();
		    const int bookId = 1;

		    // Act
		    var response = adapter.GetById(bookId);

		    // Assert
		    Assert.NotNull(response);
		    Assert.IsAssignableFrom<BookReadModel>(response.Result);
			Assert.Equal(bookId, response.Result.Id);
		}

		[Fact]
		public void QueryAdapter_Should_FindBy()
		{
			// Arrange
			var adapter = Factory.New();
			const int bookId = 1;

			// Act
			var response = adapter.FindBy(book => book.Id == 1);

			// Assert
			Assert.NotNull(response);
			Assert.IsAssignableFrom<BookReadModel>(response.Result);
			Assert.Equal(bookId, response.Result.Id);
		}
	}
}
