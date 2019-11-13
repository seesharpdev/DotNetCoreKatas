using Autofac.Extras.Moq;
using Xunit;

using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Query.Contracts.Queries;

namespace DotNetCoreKatas.Query.Adapter.UnitTests
{
    public class QueryProcessorUnitTests : IClassFixture<QueryProcessorFixture>
    {
        private QueryProcessorFixture _fixture;

        public QueryProcessorUnitTests(QueryProcessorFixture fixture)
        {
            _fixture = fixture;
        }

	    [Fact(Skip = "Cannot mock extension methods: 'ILifetimeScope.Resolve'.")]
	    public void QueryProcessor_Should_Process_Query()
	    {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                mock.Provide(_fixture.DbContextMock.Object);

                //_fixture.ContainerMock.Setup(_ => _.Resolve(It.IsAny<Type>()))
                //    .Returns(_fixture.QueryHandlerMock.Object);
                mock.Provide(_fixture.ContainerMock.Object);

                IQueryProcessor queryProcessor = mock.Create<QueryProcessor>();

                // Act
                var result = queryProcessor.Process(new AllBooksQuery());

                // Assert
                Assert.NotNull(result);
            }
		}
    }
}
