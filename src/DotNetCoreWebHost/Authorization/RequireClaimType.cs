namespace DotNetCoreWebHost.Authorization
{
	using Microsoft.AspNetCore.Authorization;

	public class RequireClaimType : IAuthorizationRequirement
    {
        public RequireClaimType(string claimType)
        {
            ClaimType = claimType;
        }

        public string ClaimType { get; }
    }
}
