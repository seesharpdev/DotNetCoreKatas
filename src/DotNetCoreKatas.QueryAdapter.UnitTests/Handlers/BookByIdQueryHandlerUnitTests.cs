using Xunit;

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
	    public void GetBookById_Should_Handle()
	    {
		    // Arrange
		    var handler = new BookByIdQueryHandler(_fixture.DbContextMock.Object, _fixture.MapperMock.Object);
			var query = new BookByIdQuery { Id = 1 };

		    // Act
		    var result = handler.Handle(query);

		    // Assert
		    Assert.NotNull(result);
		    Assert.IsAssignableFrom<BookReadModel>(result);
	    }
	}
}
