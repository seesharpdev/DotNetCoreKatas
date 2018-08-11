using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetCoreWebApi.Host.Infrastructure.Filters
{
	/// <summary>
	/// A custom ActionFilterAttribute that invokes the Model.IsValid method to validate the model.
	/// </summary>
	public class ModelValidationAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if (!context.ModelState.IsValid)
			{
				context.Result = new BadRequestObjectResult(context.ModelState);
			}
		}
	}
}
