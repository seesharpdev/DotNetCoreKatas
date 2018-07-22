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
		    var response = controller.Get() as OkObjectResult;

			// Assert
			Assert.IsAssignableFrom<OkObjectResult>(response);
		    Assert.IsAssignableFrom<IEnumerable<string>>(response.Value);
		}

		[Fact]
	    public void Get_WhenCalled_ReturnsAllItems()
	    {
			// Arrange
		    var controller = Factory.New();

			// Act
			var response = controller.Get() as OkObjectResult;

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
		    var result = controller.Get(0);

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
		    var result = controller.Get(testId);

		    // Assert
		    Assert.IsType<OkObjectResult>(result);
	    }

	    [Fact]
	    public void GetById_ExistingIdPassed_ReturnsRightItem()
	    {
			// Arrange
		    var controller = Factory.New();
		    const int testId = 1;

		    // Act
		    var result = controller.Get(testId) as OkObjectResult;

		    // Assert
		    Assert.IsType<string>(result.Value);
		    Assert.Equal("value", result.Value as string);
	    }

	    [Fact]
	    public void Post_InvalidObjectPassed_ReturnsBadRequest()
	    {
			// Arrange
		    var controller = Factory.New();
			controller.ModelState.AddModelError("Value", "Required");

		    // Act
		    var response = controller.Post(string.Empty);

		    // Assert
		    Assert.IsType<BadRequestObjectResult>(response);
	    }

	    [Fact]
	    public void Post_ValidObjectPassed_ReturnsCreatedResponse()
	    {
			// Arrange
		    var controller = Factory.New();

		    // Act
		    var response = controller.Post("testValue");

		    // Assert
		    Assert.IsType<CreatedAtActionResult>(response);
	    }

	    [Fact]
	    public void Post_ValidObjectPassed_ReturnedResponseHasCreatedItem()
	    {
			// Arrange
			var controller = Factory.New();
		    const string testValue = "testValue";

		    // Act
		    var response = controller.Post(testValue) as CreatedAtActionResult;
		    var item = response?.Value as string;

			// Assert
			Assert.IsType<string>(item);
			Assert.Equal(testValue, item);
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
