﻿using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Persistence;
using DotNetCoreKatas.QueryAdapter.Adapters;
using DotNetCoreKatas.QueryAdapter.Contracts;
using DotNetCoreKatas.QueryAdapter.Interfaces;
using DotNetCoreKatas.QueryAdapter.Mappers;

namespace DotNetCoreKatas.QueryAdapter.UnitTests.Adapters
{
	public class BooksQueryAdapterUnitTests
	{
		#region Private Members

		private static readonly Mock<DotNetCoreKatasDbContext> DbContextMock = new Mock<DotNetCoreKatasDbContext>();
		private static readonly Mock<DbSet<BookDomainModel>> DbSetMock = new Mock<DbSet<BookDomainModel>>(MockBehavior.Strict);
		private static readonly Mock<IModelMapper<BookDomainModel, BookReadModel>> MapperMock = 
			new Mock<IModelMapper<BookDomainModel, BookReadModel>>();

		private static class Factory
	    {
			internal static IBooksQueryAdapter New()
		    {
			    var data = new List<BookDomainModel>
				    {
					    new BookDomainModel(1),
					    new BookDomainModel(2),
						new BookDomainModel(3)
				    }.AsQueryable();

				DbSetMock.As<IQueryable<BookDomainModel>>().Setup(m => m.Provider).Returns(data.Provider);
				DbSetMock.As<IQueryable<BookDomainModel>>().Setup(m => m.Expression).Returns(data.Expression);
				DbSetMock.As<IQueryable<BookDomainModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
				DbSetMock.As<IQueryable<BookDomainModel>>().Setup(m => m.GetEnumerator())
					.Returns(() => data.GetEnumerator());

			    DbContextMock.Setup(c => c.Books)
					.Returns(DbSetMock.Object);

			    DbSetMock.Setup(_ => _.FindAsync(It.IsAny<object[]>()))
				    .ReturnsAsync(data.FirstOrDefault());

			    DbSetMock.Setup(_ => _.Find(It.IsAny<object[]>()))
				    .Returns(data.FirstOrDefault());

				MapperMock.Setup(_ => _.Map(It.Is<BookDomainModel>(model => model.Id == 1)))
				    .Returns(new BookReadModel { Id = 1 });

				return new BooksQueryAdapter(DbContextMock.Object, MapperMock.Object);
		    }
		}

		#endregion

	    [Fact]
	    public void QueryAdapter_Should_ReturnAllItems()
	    {
			// Arrange
		    IBooksQueryAdapter adapter = Factory.New();

		    // Act
		    var response = adapter.GetAll();

		    // Assert
			Assert.NotNull(response);
		    var books = Assert.IsAssignableFrom<IEnumerable<BookReadModel>>(response.Result);
			Assert.Equal(3, books.Count());
	    }

	    [Fact]
	    public void QueryAdapter_Should_ReturnById()
	    {
			// Arrange
		    IBooksQueryAdapter adapter = Factory.New();
		    const int bookId = 1;

		    // Act
		    var response = adapter.GetById(bookId);

		    // Assert
		    Assert.NotNull(response);
		    Assert.IsAssignableFrom<BookReadModel>(response.Result);
			Assert.Equal(bookId, response.Result.Id);
		}

		[Fact]
		public void QueryAdapter_Should_FindBy()
		{
			// Arrange
			IBooksQueryAdapter adapter = Factory.New();
			const int bookId = 1;

			// Act
			var response = adapter.FindBy(book => book.Id == 1);

			// Assert
			Assert.NotNull(response);
			Assert.IsAssignableFrom<BookReadModel>(response.Result);
			Assert.Equal(bookId, response.Result.Id);
		}
	}
}