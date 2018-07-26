using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;

using DotNetCoreKatas.Core.Interfaces;
using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Persistence;
using DotNetCoreKatas.Query.Contracts.Models;

namespace DotNetCoreKatas.Query.Adapter.UnitTests.Handlers
{
	[SuppressMessage("ReSharper", "ConvertToAutoProperty")]
	public abstract class QueryHandlerUnitTests
    {
	    private static readonly Mock<DotNetCoreKatasDbContext> DbContext = new Mock<DotNetCoreKatasDbContext>();
	    private static readonly Mock<DbSet<BookDomainModel>> DbSet = new Mock<DbSet<BookDomainModel>>(MockBehavior.Strict);
	    private static readonly Mock<IModelMapper<BookDomainModel, BookReadModel>> Mapper =
		    new Mock<IModelMapper<BookDomainModel, BookReadModel>>();

		private static readonly Mock<IQueryProcessor> QueryProcessor = new Mock<IQueryProcessor>();

	    protected static readonly IQueryable<BookDomainModel> BookDomainModels = new List<BookDomainModel>
		    {
			    new BookDomainModel(1),
			    new BookDomainModel(2),
			    new BookDomainModel(3)
		    }.AsQueryable();

	    protected static Mock<DotNetCoreKatasDbContext> DbContextMock => DbContext;
	    protected static Mock<DbSet<BookDomainModel>> DbSetMock => DbSet;
	    protected static Mock<IModelMapper<BookDomainModel, BookReadModel>> MapperMock => Mapper;
	    protected static Mock<IQueryProcessor> QueryProcessorMock => QueryProcessor;
    }
}
