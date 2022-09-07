using Microsoft.AspNetCore.Authorization;

namespace DotNetCoreWebHost.Authorization
{
    public class RequireClaimType : IAuthorizationRequirement
    {
        public RequireClaimType(string claimType)
        {
            ClaimType = claimType;
        }

        public string ClaimType { get; }
    }
}
