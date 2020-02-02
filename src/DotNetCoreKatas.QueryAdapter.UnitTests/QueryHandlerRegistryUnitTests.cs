using Xunit;

using DotNetCoreKatas.Query.Adapter.Handlers;
using DotNetCoreKatas.Query.Contracts.Queries;

namespace DotNetCoreKatas.Query.Adapter.UnitTests
{
    public class QueryHandlerRegistryUnitTests : IClassFixture<QueryHandlerRegistryFixture>
    {
        private readonly QueryHandlerRegistryFixture _fixture;

        public QueryHandlerRegistryUnitTests(QueryHandlerRegistryFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void QueryHandlerRegistry_ShouldRegister_QueryHandler()
        {
            // Arrange
            var queryHandlerRegistry = new QueryHandlerRegistry();

            // Act
            queryHandlerRegistry.Register<AllBooksQuery, AllBooksQueryHandler>();

            // Assert
        }

        [Fact]
        public void QueryHandlerRegistry_ShouldResolve_QueryHandler()
        {
            // Arrange
            var queryHandlerRegistry = new QueryHandlerRegistry();

            // Act
            queryHandlerRegistry.Register<AllBooksQuery, AllBooksQueryHandler>();

            // Assert
            var resolved = queryHandlerRegistry.Resolve<AllBooksQuery>();
            Assert.NotNull(resolved);
            Assert.Equal(nameof(AllBooksQueryHandler), resolved.Name);
        }
    }
}
