using System.Collections.Generic;
using System.Linq;

using Autofac.Extras.Moq;
using DotNetCoreKatas.Persistence;
using Xunit;

using DotNetCoreKatas.Query.Adapter.Handlers;
using DotNetCoreKatas.Query.Contracts.Models;
using DotNetCoreKatas.Query.Contracts.Queries;

namespace DotNetCoreKatas.Query.Adapter.UnitTests.Handlers
{
	public class AllBooksQueryHandlerUnitTests : IClassFixture<QueryHandlersFixture>
	{
		private readonly QueryHandlersFixture _fixture;

		public AllBooksQueryHandlerUnitTests(QueryHandlersFixture fixture)
		{
			_fixture = fixture;
		}

		[Fact]
	    public void AllBooksQueryHandler_Should_ReturnAllItems()
	    {
		    using (var mock = AutoMock.GetStrict())
		    {
				// Arrange
			    mock.Provide(_fixture.DbContextMock.Object);
			    mock.Provide(_fixture.MapperMock.Object);

				var handler = mock.Create<AllBooksQueryHandler>();

                // Act
			    var result = handler.Handle(new AllBooksQuery());

			    // Assert
			    Assert.NotNull(result);
			    var bookCount = Assert.IsAssignableFrom<IEnumerable<BookReadModel>>(result);
			    Assert.Equal(_fixture.BookDomainModels.Count(), bookCount.Count());
		    }
	    }
    }
}
