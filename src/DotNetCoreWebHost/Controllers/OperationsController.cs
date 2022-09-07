using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace DotNetCoreWebHost.Controllers
{
    public class OperationsController : Controller
    {
        #region Private Members

        private readonly IAuthorizationService _authorizationService;

        #endregion

        #region Ctor's

        public OperationsController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        #endregion

        //[Authorize(Policy = nameof(UserAgentOperations.Read))]
        public async Task<IActionResult> Index()
        {
            //var requirement = new OperationAuthorizationRequirement
            //    {
            //        Name = UserAgentOperations.Read
            //    };

            var result = await _authorizationService.AuthorizeAsync(
                User, 
                Request.Headers[HeaderNames.UserAgent].ToString(),
                //requirement);
                OperationAuthorization.Read);
            
            return result.Succeeded ? View() : (IActionResult)Unauthorized();
        }
    }
}