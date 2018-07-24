using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;

using DotNetCoreKatas.QueryAdapter.Interfaces;
using DotNetCoreKatas.QueryAdapter.Contracts;
using DotNetCoreWebApi.Host.Controllers;

namespace DotNetCoreWebApi.Host.UnitTests
{
	[ExcludeFromCodeCoverage]
    public class BooksControllerUnitTests
	{
		private static readonly Mock<IBooksQueryAdapter> AdapterMock = new Mock<IBooksQueryAdapter>();

		private static class Factory
	    {
			internal static BooksController New()
			{
				IEnumerable<BookReadModel> bookReadModels = new[] { new BookReadModel { Id = 1 } };

				AdapterMock.Setup(_ => _.GetAll())
					.Returns(Task.FromResult(bookReadModels));

				AdapterMock.Setup(_ => _.GetById(It.IsAny<int>()))
					.ReturnsAsync(bookReadModels.FirstOrDefault);

				return new BooksController(AdapterMock.Object);
		    }
	    }

	    [Fact]
	    public void Get_WhenCalled_ReturnsOkObjectResult()
	    {
		    // Arrange
		    var controller = Factory.New();

		    // Act
		    var response = controller.Get().Result as OkObjectResult;

			// Assert
			Assert.IsAssignableFrom<OkObjectResult>(response);
			Assert.IsAssignableFrom<IEnumerable<BookReadModel>>(response.Value);
		}

		[Fact]
	    public void Get_WhenCalled_ReturnsAllItems()
	    {
			// Arrange
		    var controller = Factory.New();

			// Act
			var response = controller.Get().Result as OkObjectResult;

			// Assert
			var items = Assert.IsAssignableFrom<IEnumerable<BookReadModel>>(response?.Value);
		    Assert.Single(items);
	    }

	    [Fact]
	    public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
	    {
			// Arrange
		    var controller = Factory.New();

			// Act
		    var result = controller.Get(0).Result;

		    // Assert
		    Assert.IsType<NotFoundResult>(result);
	    }

	    [Fact]
	    public void GetById_ExistingIdPassed_ReturnsOkResult()
	    {
			// Arrange
		    var controller = Factory.New();
		    const int testId = 1;

		    // Act
		    var result = controller.Get(testId).Result;

		    // Assert
		    Assert.IsType<OkObjectResult>(result);
	    }

	    [Fact]
	    public void GetById_ExistingIdPassed_ReturnsRightItem()
	    {
			// Arrange
		    var controller = Factory.New();
		    const int modelId = 1;

		    // Act
		    var result = controller.Get(modelId).Result as OkObjectResult;

		    // Assert
		    Assert.IsType<BookReadModel>(result?.Value);
		    Assert.Equal(modelId, (result.Value as BookReadModel).Id);
	    }

	    [Fact]
	    public void Post_InvalidObjectPassed_ReturnsBadRequest()
	    {
			// Arrange
		    var controller = Factory.New();
			controller.ModelState.AddModelError("Value", "Required");

		    // Act
		    var response = controller.Post(null);

		    // Assert
		    Assert.IsType<BadRequestObjectResult>(response);
	    }

	    [Fact]
	    public void Post_ValidObjectPassed_ReturnsCreatedResponse()
	    {
			// Arrange
		    var controller = Factory.New();
		    var model = new BookReadModel { Id = 1 };

		    // Act
		    var response = controller.Post(model);

		    // Assert
		    Assert.IsType<CreatedAtActionResult>(response);
	    }

	    [Fact]
	    public void Post_ValidObjectPassed_ReturnedResponseHasCreatedItem()
	    {
			// Arrange
			var controller = Factory.New();
		    var model = new BookReadModel { Id = 1 };

		    // Act
		    var response = controller.Post(model) as CreatedAtActionResult;
		    var book = response?.Value as BookReadModel;

			// Assert
			Assert.IsType<BookReadModel>(book);
			Assert.NotNull(book);
		}

	    [Fact]
	    public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
	    {
			// Arrange
		    var controller = Factory.New();

		    // Act
		    var response = controller.Delete(0);

		    // Assert
		    Assert.IsType<NotFoundResult>(response);
	    }

	    [Fact]
	    public void Remove_ExistingGuidPassed_ReturnsOkResult()
	    {
			// Arrange
		    var controller = Factory.New();
			const int existingId = 1;

		    // Act
		    var response = controller.Delete(existingId);

		    // Assert
		    Assert.IsType<OkResult>(response);
	    }

		[Fact(Skip = "Service need to be mocked and expectations verified.")]
		public void Remove_ExistingGuidPassed_RemovesOneItem()
	    {
			// Arrange
		    var controller = Factory.New();
			const int existingId = 1;

		    // Act
		    var okResponse = controller.Delete(existingId);

			// Assert
			//Assert.Equal(2, _service.GetAllItems().Count());
		}
	}
}