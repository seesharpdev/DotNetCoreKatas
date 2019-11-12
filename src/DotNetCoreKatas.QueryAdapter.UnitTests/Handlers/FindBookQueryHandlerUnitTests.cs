using System.Linq;

using Autofac.Extras.Moq;
using Moq;
using Xunit;

using DotNetCoreKatas.Persistence;
using DotNetCoreKatas.Query.Adapter.Handlers;
using DotNetCoreKatas.Query.Contracts.Models;
using DotNetCoreKatas.Query.Contracts.Queries;

namespace DotNetCoreKatas.Query.Adapter.UnitTests.Handlers
{
	public class FindBookQueryHandlerUnitTests : IClassFixture<QueryHandlersFixture>
    {
	    private readonly QueryHandlersFixture _fixture;

	    public FindBookQueryHandlerUnitTests(QueryHandlersFixture fixture)
	    {
		    _fixture = fixture;
	    }

	    [Fact]
	    public void FindBookQueryHandler_Should_ReturnTheCorrectItem()
	    {
		    using (var mock = AutoMock.GetStrict())
		    {
				// Arrange
			    const int bookId = 1;
			    _fixture.DbSetMock
				    .Setup(_ => _.Find(It.IsAny<object[]>()))
				    .Returns(_fixture.BookDomainModels.FirstOrDefault());

				mock.Provide(_fixture.DbContextMock.Object);
			    mock.Provide(_fixture.MapperMock.Object);

				var handler = mock.Create<FindBookQueryHandler>();
			    var query = new FindBookQuery { Predicate = model => model.Id == bookId };

				// Act
				var result = handler.Handle(query);

				// Assert
			    Assert.NotNull(result);
			    var book = Assert.IsAssignableFrom<BookReadModel>(result);
			    Assert.Equal(bookId, book.Id);
			}
	    }
    }
}
