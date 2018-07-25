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
			    var builder = new ContainerBuilder();

			    builder.RegisterType<DotNetCoreKatasDbContext>()
				    .As<IDotNetCoreKatasDbContext>();

			    builder.RegisterType<BookModelMapper>()
				    .As<IModelMapper<BookDomainModel, BookReadModel>>();

			    builder.RegisterType<GetAllBooksQueryHandler>()
				    .As<IQueryHandler<GetAllBooksQuery, IEnumerable<BookReadModel>>>();

				var container = builder.Build();
				
				return new QueryProcessor(container);
		    }
		}
	    [Fact]
	    public void QueryHandler_Should_Resolve_Handler()
	    {
			// Arrange
		    IQueryProcessor queryProcessor = Factory.New();
		    IGetAllBooksQuery query = new GetAllBooksQuery();

		    // Act
		    var result = queryProcessor.Process(query);

			// Assert
			Assert.NotNull(result);

		}
    }
}
