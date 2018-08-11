using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;

using DotNetCoreKatas.Command.Adapter.Contracts;
using DotNetCoreKatas.Command.Contracts;
using DotNetCoreKatas.Query.Contracts.Models;
using DotNetCoreWebApi.Host.Controllers;
using DotNetCoreKatas.Core.Interfaces.Querying;

namespace DotNetCoreWebApi.Host.UnitTests
{
	[ExcludeFromCodeCoverage]
    public class BooksControllerUnitTests : IClassFixture<BookControllerFixture>
	{
		private readonly BookControllerFixture _fixture;
		
		public BooksControllerUnitTests(BookControllerFixture fixture)
		{
			_fixture = fixture;
		}

	    [Fact]
	    public void Get_WhenCalled_ReturnsOkObjectResult()
	    {
		    using (var mock = AutoMock.GetStrict())
		    {
				// Arrange
			    mock.Mock<IQueryAdapter<BookReadModel, int>>()
				    .Setup(_ => _.GetAll())
				    .Returns(Task.FromResult(_fixture.ReadModels));

				var controller = mock.Create<BooksController>();

				// Act
				var response = controller.Get().Result as OkObjectResult;

			    // Assert
			    Assert.IsAssignableFrom<OkObjectResult>(response);
			    Assert.IsAssignableFrom<IEnumerable<BookReadModel>>(response.Value);
		    }
		}

		[Fact]
	    public void Get_WhenCalled_ReturnsAllItems()
	    {
		    using (var mock = AutoMock.GetStrict())
		    {
				// Arrange
				mock.Mock<IQueryAdapter<BookReadModel, int>>()
					.Setup(_ => _.GetAll())
					.Returns(Task.FromResult(_fixture.ReadModels));

				var controller = mock.Create<BooksController>();

				// Act
				var response = controller.Get().Result as OkObjectResult;

			    // Assert
			    var items = Assert.IsAssignableFrom<IEnumerable<BookReadModel>>(response?.Value);
			    Assert.Single(items);
			    mock.Mock<IQueryAdapter<BookReadModel, int>>()
				    .VerifyAll();
			}
	    }

	    [Fact]
	    public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
	    {
		    using (var mock = AutoMock.GetStrict())
		    {
				// Arrange
				var controller = mock.Create<BooksController>();

				// Act
				var result = controller.Get(0).Result;

			    // Assert
			    Assert.IsType<NotFoundResult>(result);
		    }
	    }

	    [Fact]
	    public void GetById_ExistingIdPassed_ReturnsOkResult()
	    {
		    using (var mock = AutoMock.GetStrict())
		    {
				// Arrange
			    mock.Mock<IQueryAdapter<BookReadModel, int>>()
				    .Setup(_ => _.GetById(It.IsAny<int>()))
				    .ReturnsAsync(_fixture.ReadModels.FirstOrDefault);

				var controller = mock.Create<BooksController>();
				const int testId = 1;

			    // Act
			    var result = controller.Get(testId).Result;

			    // Assert
			    Assert.IsType<OkObjectResult>(result);
			    mock.Mock<IQueryAdapter<BookReadModel, int>>()
				    .VerifyAll();
			}
	    }

	    [Fact]
	    public void GetById_ExistingIdPassed_ReturnsRightItem()
	    {
		    using (var mock = AutoMock.GetStrict())
		    {
				// Arrange
			    mock.Mock<IQueryAdapter<BookReadModel, int>>()
				    .Setup(_ => _.GetById(It.IsAny<int>()))
				    .ReturnsAsync(_fixture.ReadModels.FirstOrDefault);

				var controller = mock.Create<BooksController>();
				const int modelId = 1;

			    // Act
			    var result = controller.Get(modelId).Result as OkObjectResult;

			    // Assert
			    Assert.IsType<BookReadModel>(result?.Value);
			    Assert.Equal(modelId, (result.Value as BookReadModel).Id);
			    mock.Mock<IQueryAdapter<BookReadModel, int>>()
				    .VerifyAll();
			}
	    }

	    [Fact(Skip = "Since we're using ActionFilter's to validate the Model (Model.IsValid()) we need to revisit this test.")]
	    public void Post_InvalidObjectPassed_ReturnsBadRequest()
	    {
		    using (var mock = AutoMock.GetStrict())
		    {
				// Arrange
				var controller = mock.Create<BooksController>();
				controller.ModelState.AddModelError("Id", "Required");

				// Act
				var response = controller.Post(new BookReadModel());

				// Assert
				Assert.IsType<BadRequestObjectResult>(response);
			}
	    }

	    [Fact]
	    public void Post_ValidObjectPassed_ReturnsCreatedResponse()
	    {
		    using (var mock = AutoMock.GetStrict())
		    {
				// Arrange
			    mock.Mock<IBooksCommandAdapter>()
				    .Setup(_ => _.CreateBook(It.IsAny<ICreateBookCommand>()))
				    .Returns(Task.CompletedTask);

			    var controller = mock.Create<BooksController>();
			    var model = new BookReadModel { Id = 1 };

			    // Act
			    var response = controller.Post(model);

			    // Assert
			    Assert.IsType<CreatedAtActionResult>(response);
			    mock.Mock<IBooksCommandAdapter>().VerifyAll();
		    }
	    }

	    [Fact]
	    public void Post_ValidObjectPassed_ReturnedResponseHasCreatedItem()
	    {
		    using (var mock = AutoMock.GetStrict())
		    {
				// Arrange
			    mock.Mock<IBooksCommandAdapter>()
				    .Setup(_ => _.CreateBook(It.IsAny<ICreateBookCommand>()))
				    .Returns(Task.CompletedTask);

				var controller = mock.Create<BooksController>();
				var model = new BookReadModel { Id = 1 };

			    // Act
			    var response = controller.Post(model) as CreatedAtActionResult;
			    var book = response?.Value as BookReadModel;

			    // Assert
			    Assert.IsType<BookReadModel>(book);
			    Assert.NotNull(book);
			    mock.Mock<IBooksCommandAdapter>().VerifyAll();
			}
		}

	    [Fact]
	    public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
	    {
		    using (var mock = AutoMock.GetStrict())
		    {
				// Arrange
				var controller = mock.Create<BooksController>();

				// Act
				var response = controller.Delete(0);

			    // Assert
			    Assert.IsType<NotFoundResult>(response);
		    }
	    }

	    [Fact]
	    public void Remove_ExistingGuidPassed_ReturnsOkResult()
	    {
		    using (var mock = AutoMock.GetStrict())
		    {
				// Arrange
			    mock.Mock<IBooksCommandAdapter>()
				    .Setup(_ => _.DeleteBook(It.IsAny<IDeleteBookCommand>()))
				    .Returns(Task.CompletedTask);

				var controller = mock.Create<BooksController>();
				const int existingId = 1;

			    // Act
			    var response = controller.Delete(existingId);

			    // Assert
			    Assert.IsType<OkResult>(response);
			    mock.Mock<IBooksCommandAdapter>().VerifyAll();
		    }
		}
	}
}