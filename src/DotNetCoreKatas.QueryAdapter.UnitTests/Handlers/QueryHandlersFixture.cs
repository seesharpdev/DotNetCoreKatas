using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Moq;

using DotNetCoreKatas.Core.Interfaces;
using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Persistence;
using DotNetCoreKatas.Query.Contracts.Models;

namespace DotNetCoreKatas.Query.Adapter.UnitTests.Handlers
{
	public class QueryHandlersFixture : IDisposable
    {
	    private readonly Mock<IDotNetCoreKatasDbContext> DbContext = new Mock<IDotNetCoreKatasDbContext>();
	    private readonly Mock<DbSet<BookDomainModel>> DbSet = new Mock<DbSet<BookDomainModel>>(MockBehavior.Strict);
	    private readonly Mock<IModelMapper<BookDomainModel, BookReadModel>> Mapper =
		    new Mock<IModelMapper<BookDomainModel, BookReadModel>>();

	    public QueryHandlersFixture()
	    {
			DbSetMock.As<IQueryable<BookDomainModel>>().Setup(m => m.Provider).Returns(BookDomainModels.Provider);
		    DbSetMock.As<IQueryable<BookDomainModel>>().Setup(m => m.Expression).Returns(BookDomainModels.Expression);
		    DbSetMock.As<IQueryable<BookDomainModel>>().Setup(m => m.ElementType).Returns(BookDomainModels.ElementType);
		    DbSetMock.As<IQueryable<BookDomainModel>>().Setup(m => m.GetEnumerator())
			    .Returns(() => BookDomainModels.GetEnumerator());

		    DbContextMock.Setup(c => c.Books)
			    .Returns(DbSetMock.Object);

			MapperMock.Setup(_ => _.Map(It.Is<BookDomainModel>(model => model.Id == 1)))
			    .Returns(new BookReadModel { Id = 1 });
		}

	    public readonly IQueryable<BookDomainModel> BookDomainModels = new List<BookDomainModel>
		    {
			    BookDomainModel.Create(1),
			    BookDomainModel.Create(2),
			    BookDomainModel.Create(3)
		    }.AsQueryable();

	    public Mock<IDotNetCoreKatasDbContext> DbContextMock => DbContext;

	    public Mock<DbSet<BookDomainModel>> DbSetMock => DbSet;

	    public Mock<IModelMapper<BookDomainModel, BookReadModel>> MapperMock => Mapper;

	    public void Dispose()
	    {
	    }
    }
}
