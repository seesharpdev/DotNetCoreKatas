using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Xunit;

using DotNetCoreKatas.Command.Adapter.Contracts;
using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Query.Contracts.Models;
using DotNetCoreWebApi.Host.Controllers;
using DotNetCoreWebApi.Host.Infrastructure.Filters;

namespace DotNetCoreWebApi.Host.UnitTests.Infrastructure.Filters
{
	public class ModelValidationAttributeUnitTests
    {
	    [Fact]
	    public void Should_Invoke_Next_When_Model_Is_Valid()
	    {
		    using (var mock = AutoMock.GetLoose())
		    {
				// Arrange
				var filter = new ModelValidationAttribute();
				var modelStateDictionary = new ModelStateDictionary();
				modelStateDictionary.AddModelError("Id", "Id must not be null.");
			    var actionDescriptor = new ActionDescriptor();
				var actionContext = new ActionContext(
					new DefaultHttpContext(),
					new RouteData(),
					actionDescriptor,
					modelStateDictionary);

				var controller = mock.Create<BooksController>();
				var actionExecutingContext = new ActionExecutingContext(
					actionContext,
					new List<IFilterMetadata>(),
					new Dictionary<string, object>(),
					controller);

				// Act
				filter.OnActionExecuting(actionExecutingContext);

				// Assert
				Assert.IsType<BadRequestObjectResult>(actionExecutingContext.Result);
			}
		}
    }
}
