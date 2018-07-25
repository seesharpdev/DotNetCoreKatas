using Moq;
using Xunit;

using DotNetCoreKatas.Core.Interfaces;
using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Persistence;
using DotNetCoreKatas.Query.Adapter.Handlers;
using DotNetCoreKatas.Query.Contracts.Models;

namespace DotNetCoreKatas.Query.Adapter.UnitTests
{
	public class QueryHandlerRegistryUnitTests
    {
		private static readonly Mock<IDotNetCoreKatasDbContext> DbContextMock = new Mock<IDotNetCoreKatasDbContext>();
		private static readonly Mock<IModelMapper<BookDomainModel, BookReadModel>> MapperMock = new Mock<IModelMapper<BookDomainModel, BookReadModel>>();

	    [Fact(Skip = "Work in progress!")]
	    public void QueryHandler_Should_Register_Handlers()
	    {
			// Arrange
		    IQueryHandlerRegistry registry = new QueryHandlerRegistry();
		    var handler = new GetAllBooksQueryHandler(DbContextMock.Object, MapperMock.Object);

			// Act
		    registry.Register(handler);

		    // Assert
	    }
    }
}
