using System.IO;

using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace DotNetCoreWebApi.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
               var host = new HostBuilder()
                   .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                   .ConfigureWebHostDefaults(webHostBuilder =>
                       {
                           webHostBuilder.UseContentRoot(Directory.GetCurrentDirectory())
                               .UseIISIntegration()
                               .UseStartup<Startup>();
                       })
                   .Build();

               host.Run();
        }
    }
}
