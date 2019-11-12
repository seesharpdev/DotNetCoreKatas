using System;

using Autofac;
using Autofac.Core.Lifetime;
using Moq;

using DotNetCoreKatas.Persistence;
using DotNetCoreKatas.Query.Adapter.Handlers;

namespace DotNetCoreKatas.Query.Adapter.UnitTests
{
    public class QueryProcessorFixture : IDisposable
    {
        private readonly Mock<IDotNetCoreKatasDbContext> DbContext = new Mock<IDotNetCoreKatasDbContext>();
        private readonly Mock<ILifetimeScope> Container = new Mock<ILifetimeScope>();

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

        public Mock<ILifetimeScope> ContainerMock => Container;

        public Mock<AllBooksQueryHandler> QueryHandlerMock => QueryHandler;

        public void Dispose()
        {
        }
    }
}
