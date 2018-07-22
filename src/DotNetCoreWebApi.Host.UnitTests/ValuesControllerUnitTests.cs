using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Xunit;

using DotNetCoreWebApi.Host.Controllers;

namespace DotNetCoreWebApi.Host.UnitTests
{
	[ExcludeFromCodeCoverage]
    public class ValuesControllerUnitTests
    {
	    private static class Factory
	    {
		    internal static ValuesController New()
		    {
				return new ValuesController();
		    }
	    }

	    [Fact]
	    public void Get_WhenCalled_ReturnsOkObjectResult()
	    {
		    // Arrange
		    var controller = Factory.New();

		    // Act
		    var response = controller.Get();

		    // Assert
		    Assert.IsType<ActionResult<IEnumerable<string>>>(response);
		    Assert.IsAssignableFrom<OkObjectResult>(response.Result);
	    }

	    [Fact]
	    public void Get_WhenCalled_ReturnsAllItems()
	    {
			// Arrange
		    var controller = Factory.New();

			// Act
			var response = controller.Get().Result as OkObjectResult;

		    // Assert
		    var items = Assert.IsAssignableFrom<IEnumerable<string>>(response.Value);
		    Assert.Equal(2, items.Count());
	    }

	    [Fact]
	    public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
	    {
			// Arrange
		    var controller = Factory.New();

			// Act
		    var notFoundResult = controller.Get(0);

		    // Assert
		    Assert.IsType<NotFoundResult>(notFoundResult.Result);
	    }

	    [Fact]
	    public void GetById_ExistingIdPassed_ReturnsOkResult()
	    {
			// Arrange
		    var controller = Factory.New();
		    var testId = 1;

		    // Act
		    var okResult = controller.Get(testId);

		    // Assert
		    Assert.IsType<OkObjectResult>(okResult.Result);
	    }

	    [Fact]
	    public void GetById_ExistingIdPassed_ReturnsRightItem()
	    {
			// Arrange
		    var controller = Factory.New();
		    var testId = 1;

		    // Act
		    var okResult = controller.Get(testId).Result as OkObjectResult;

		    // Assert
		    Assert.IsType<string>(okResult.Value);
		    Assert.Equal("value", okResult.Value as string);
	    }

	    [Fact]
	    public void Add_InvalidObjectPassed_ReturnsBadRequest()
	    {
			// Arrange
		    var controller = Factory.New();
			controller.ModelState.AddModelError("Value", "Required");

		    // Act
		    var badResponse = controller.Post(string.Empty);

		    // Assert
		    Assert.IsType<BadRequestObjectResult>(badResponse);
	    }

	    [Fact]
	    public void Add_ValidObjectPassed_ReturnsCreatedResponse()
	    {
			// Arrange
		    var controller = Factory.New();

		    // Act
		    var createdResponse = controller.Post("testValue");

		    // Assert
		    Assert.IsType<CreatedAtActionResult>(createdResponse);
	    }

	    [Fact]
	    public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
	    {
			// Arrange
			var controller = Factory.New();
		    var testValue = "testValue";

		    // Act
		    var createdResponse = controller.Post(testValue) as CreatedAtActionResult;
		    var item = createdResponse.Value as string;

		    // Assert
		    Assert.IsType<string>(item);
			Assert.Equal(testValue, item);
		}

	    [Fact]
	    public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
	    {
			// Arrange
		    var controller = Factory.New();
			const int notExistingId = 0;

		    // Act
		    var badResponse = controller.Delete(notExistingId);

		    // Assert
		    Assert.IsType<NotFoundResult>(badResponse);
	    }

	    [Fact]
	    public void Remove_ExistingGuidPassed_ReturnsOkResult()
	    {
			// Arrange
		    var controller = Factory.New();
			const int existingId = 1;

		    // Act
		    var okResponse = controller.Delete(existingId);

		    // Assert
		    Assert.IsType<OkResult>(okResponse);
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
