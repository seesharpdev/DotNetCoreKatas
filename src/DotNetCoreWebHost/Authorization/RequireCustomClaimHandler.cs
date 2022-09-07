using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

namespace DotNetCoreWebHost.Authorization
{
    public class RequireCustomClaimHandler 
        : AuthorizationHandler<RequireClaimType>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            RequireClaimType requirement)
        {
            var hasClaim = context.User.Claims.Any(x => x.Type == requirement.ClaimType);
            if (hasClaim)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}