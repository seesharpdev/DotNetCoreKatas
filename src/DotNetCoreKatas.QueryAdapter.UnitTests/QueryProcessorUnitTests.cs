using System;

using Autofac.Extras.Moq;
using Moq;
using Xunit;

using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Query.Contracts.Queries;

namespace DotNetCoreKatas.Query.Adapter.UnitTests
{
    public class QueryProcessorUnitTests : IClassFixture<QueryProcessorFixture>
    {
        private readonly QueryProcessorFixture _fixture;

        public QueryProcessorUnitTests(QueryProcessorFixture fixture)
        {
            _fixture = fixture;
        }

	    [Fact()]
	    //[Fact(Skip = "Cannot mock extension methods: 'ILifetimeScope.Resolve'.")]
	    public void QueryProcessor_Should_Process_Query()
	    {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                mock.Provide(_fixture.DbContextMock.Object);

                // WIP: Replacing ILifetimeScope with IQueryHandlerRegistry
                //_fixture.ContainerMock.Setup(_ => _.Resolve(It.IsAny<Type>()))
                //    .Returns(_fixture.QueryHandlerMock.Object);
                //mock.Provide(_fixture.ContainerMock.Object);
                //_fixture.QueryHandlerRegistryMock.Setup(_ => _.Resolve<>(It.IsAny<Type>()));
                mock.Provide(_fixture.QueryHandlerRegistryMock.Object);

                IQueryProcessor queryProcessor = mock.Create<QueryProcessor>();

                // Act
                var result = queryProcessor.Process(new AllBooksQuery());

                // Assert
                Assert.NotNull(result);
            }
		}
    }
}
