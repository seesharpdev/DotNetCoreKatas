using System;

using Moq;

using DotNetCoreKatas.Persistence;
using DotNetCoreKatas.Query.Adapter.Handlers;
using DotNetCoreKatas.Core.Interfaces.Querying;

namespace DotNetCoreKatas.Query.Adapter.UnitTests
{
    public class QueryProcessorFixture : IDisposable
    {
        private readonly Mock<IDotNetCoreKatasDbContext> DbContext = new Mock<IDotNetCoreKatasDbContext>();

        // WIP: Replacing ILifetimeScope with IQueryHandlerRegistry
        //private readonly Mock<ILifetimeScope> Container = new Mock<ILifetimeScope>();
        private readonly Mock<IQueryHandlerRegistry> QueryHandlerRegistry = new Mock<IQueryHandlerRegistry>();

        private readonly Mock<AllBooksQueryHandler> QueryHandler = new Mock<AllBooksQueryHandler>();

        public QueryProcessorFixture()
        {
            // TODO: Introduce Package Autofac.Integration.Moq
            //var builder = new ContainerBuilder();
            //builder.RegisterType<DotNetCoreKatasDbContext>()
            //.As<IDotNetCoreKatasDbContext>();

            //builder.RegisterType<BookModelMapper>()
            //.As<IModelMapper<BookDomainModel, BookReadModel>>();

            //builder.RegisterType<AllBooksQueryHandler>()
            //.As<IQueryHandler<AllBooksQuery, IEnumerable<BookReadModel>>>();

            //var container = builder.Build();

            //return new QueryProcessor(container);
        }

        public Mock<IDotNetCoreKatasDbContext> DbContextMock => DbContext;

        //public Mock<ILifetimeScope> ContainerMock => Container;
        public Mock<IQueryHandlerRegistry> QueryHandlerRegistryMock => QueryHandlerRegistry;

        public Mock<AllBooksQueryHandler> QueryHandlerMock => QueryHandler;

        public void Dispose()
        {
        }
    }
}
