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
        [Fact]
        public void Get_WhenCalled_ReturnsActionResult()
        {
			// Arrange
	        var controller = new ValuesController();

	        // Act
	        var result = controller.Get();

	        // Assert
	        Assert.IsType<ActionResult<IEnumerable<string>>>(result);
			Assert.IsAssignableFrom<IEnumerable<string>>(result.Value);
		}

	    [Fact]
	    public void Get_WhenCalled_ReturnsAllItems()
	    {
		    // Arrange
		    var controller = new ValuesController();

		    // Act
		    var result = controller.Get();

		    // Assert
		    var items = Assert.IsAssignableFrom<IEnumerable<string>>(result.Value);
			Assert.Equal(2, items.Count());
		}
    }
}
