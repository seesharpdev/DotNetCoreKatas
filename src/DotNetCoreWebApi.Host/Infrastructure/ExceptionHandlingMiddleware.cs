using System;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace DotNetCoreWebApi.Host.Infrastructure
{
	public class ExceptionHandlingMiddleware
	{
		private readonly RequestDelegate _next;

		public ExceptionHandlingMiddleware(RequestDelegate next)
		{
			_next = next;
		}
 
		public async Task Invoke(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (Exception ex)
			{
				// TODO: Log error message and handle exception
				//_logger.LogError("Unhandled exception ...", ex);
				await HandleExceptionAsync(httpContext, ex);
			}
		}

		private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
		{
			httpContext.Response.ContentType = "application/json";
			httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			var errorDetails = new ErrorDetails()
				{
					StatusCode = httpContext.Response.StatusCode,
					Message = "Internal Server Error from the custom middleware."
				};

			return httpContext.Response.WriteAsync(errorDetails.ToString());
		}
	}
}
