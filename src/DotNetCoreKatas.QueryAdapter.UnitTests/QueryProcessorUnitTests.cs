using System.Collections.Generic;

using Autofac;
using Xunit;

using DotNetCoreKatas.Core.Interfaces;
using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Persistence;
using DotNetCoreKatas.Query.Adapter.Handlers;
using DotNetCoreKatas.Query.Adapter.Mappers;
using DotNetCoreKatas.Query.Contracts.Models;
using DotNetCoreKatas.Query.Contracts.Queries;

namespace DotNetCoreKatas.Query.Adapter.UnitTests
{
	public class QueryProcessorUnitTests
    {
	    private static class Factory
	    {
		    public static QueryProcessor New()
		    {
				// TODO: Introduce Package Autofac.Integration.Moq
			    var builder = new ContainerBuilder();
			    builder.RegisterType<DotNetCoreKatasDbContext>()
				    .As<IDotNetCoreKatasDbContext>();

			    builder.RegisterType<BookModelMapper>()
				    .As<IModelMapper<BookDomainModel, BookReadModel>>();

			    builder.RegisterType<AllBooksQueryHandler>()
				    .As<IQueryHandler<AllBooksQuery, IEnumerable<BookReadModel>>>();

				var container = builder.Build();
				
				return new QueryProcessor(container);
		    }
		}
	    [Fact]
	    public void QueryProcessor_Should_Process_Query()
	    {
			// Arrange
		    IQueryProcessor queryProcessor = Factory.New();

		    // Act
		    var result = queryProcessor.Process(new AllBooksQuery());

			// Assert
			Assert.NotNull(result);

		}
    }
}
