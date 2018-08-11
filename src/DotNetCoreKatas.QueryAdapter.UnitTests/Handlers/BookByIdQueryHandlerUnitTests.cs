using System.Linq;

using Autofac.Extras.Moq;
using Xunit;
using Moq;

using DotNetCoreKatas.Persistence;
using DotNetCoreKatas.Query.Adapter.Handlers;
using DotNetCoreKatas.Query.Contracts.Models;
using DotNetCoreKatas.Query.Contracts.Queries;

namespace DotNetCoreKatas.Query.Adapter.UnitTests.Handlers
{
	public class BookByIdQueryHandlerUnitTests : IClassFixture<QueryHandlersFixture>
	{
		private readonly QueryHandlersFixture _fixture;

		public BookByIdQueryHandlerUnitTests(QueryHandlersFixture fixture)
		{
			_fixture = fixture;
		}

	    [Fact]
	    public void GetBookById_Should_ReturnTheCorrectItem()
	    {
		    using (var mock = AutoMock.GetStrict())
		    {
				// Arrange
				_fixture.DbSetMock
				    .Setup(_ => _.Find(It.IsAny<object[]>()))
				    .Returns(_fixture.BookDomainModels.FirstOrDefault());

				mock.Provide<IDotNetCoreKatasDbContext>(_fixture.DbContextMock.Object);
				mock.Provide(_fixture.MapperMock.Object);

				var handler = mock.Create<BookByIdQueryHandler>();
				var query = new BookByIdQuery { Id = 1 };

			    // Act
			    var result = handler.Handle(query);

			    // Assert
			    Assert.NotNull(result);
			    Assert.IsAssignableFrom<BookReadModel>(result);
		    }
	    }
	}
}
