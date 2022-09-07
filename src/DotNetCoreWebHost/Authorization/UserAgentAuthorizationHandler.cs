using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using UAParser;

namespace DotNetCoreWebHost.Authorization
{
    public class UserAgentAuthorizationHandler
        : AuthorizationHandler<OperationAuthorizationRequirement, string>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            OperationAuthorizationRequirement requirement,
            string userAgent)
        {
            // TODO: Check if the User Agent is a browser
            if (requirement.Name == UserAgentOperations.Read)
            {
                var parser = Parser.GetDefault();
                var clientInfo = parser.Parse(userAgent);

                #region Examples

                //Console.WriteLine(clientInfo.UA.Family); // => "Mobile Safari"
                //Console.WriteLine(clientInfo.UA.Major);  // => "5"
                //Console.WriteLine(clientInfo.UA.Minor);  // => "1"

                //Console.WriteLine(clientInfo.OS.Family);        // => "iOS"
                //Console.WriteLine(clientInfo.OS.Major);         // => "5"
                //Console.WriteLine(clientInfo.OS.Minor);         // => "1"

                //Console.WriteLine(clientInfo.Device.Family);    // => "iPhone"

                #endregion

                if (clientInfo.Device.IsSpider == false)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}