using Microsoft.AspNetCore.Authorization.Infrastructure;

using DotNetCoreWebHost.Authorization;

namespace DotNetCoreWebHost.Controllers
{
    public static class OperationAuthorization
    {
        public static OperationAuthorizationRequirement Create = new OperationAuthorizationRequirement
        {
            Name = UserAgentOperations.Create
        };

        public static OperationAuthorizationRequirement Read = new OperationAuthorizationRequirement
        {
            Name = UserAgentOperations.Read
        };

        public static OperationAuthorizationRequirement Update = new OperationAuthorizationRequirement
        {
            Name = UserAgentOperations.Update
        };

        public static OperationAuthorizationRequirement Delete = new OperationAuthorizationRequirement
        {
            Name = UserAgentOperations.Delete
        };
    }
}