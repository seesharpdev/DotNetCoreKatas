using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using DotNetCoreKatas.Command.Adapter.Infrastructure;
using DotNetCoreKatas.Query.Adapter.Infrastructure;
using DotNetCoreKatas.Core;
using DotNetCoreKatas.Persistence;

namespace DotNetCoreWebApi.Host
{
    public class Startup
    {
        public Startup(IHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
                .AddUserSecrets<Startup>()
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.Configure<ServiceBusOptions>(Configuration.GetSection("ServiceBusOptions"));

            //services.AddMvc(option => option.EnableEndpointRouting = false)
            //    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllers();

	        // TODO: Move to a Mvc specific Startup.cs in a Mvc App [Uncomment to enable CORS]
	        //ConfigureCors(services);

	        ConfigureAuthentication(services);

            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = ".Net Core 3 Demo Api", Version = "v1" });
                });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var serviceBusOptions = Configuration.GetSection("ServiceBusOptions").Get<ServiceBusOptions>();

            builder.Register(c => new QueueClient(
                    serviceBusOptions.ConnectionString,
                    serviceBusOptions.QueueName))
                .As<IQueueClient>();

            builder.RegisterType<DotNetCoreKatasDbContext>()
                .As<IDotNetCoreKatasDbContext>();

            builder.RegisterModule<QueryAdapterModule>();
            builder.RegisterModule<CommandAdapterModule>();
        }

        private static void ConfigureCors(IServiceCollection services)
	    {
		    services.AddCors(options =>
			    {
				    options.AddPolicy("CorsPolicy",
					    builder => builder.AllowAnyOrigin()
						    .AllowAnyMethod()
						    .AllowAnyHeader()
						    .AllowCredentials());
			    });
	    }

	    private static void ConfigureAuthentication(IServiceCollection services)
	    {
		    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			    .AddJwtBearer(options =>
				    {
					    options.TokenValidationParameters = new TokenValidationParameters
						    {
							    // Configuration in here
						    };
				    });
	    }

	    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

	        if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(new DeveloperExceptionPageOptions());
            }
            else
            {
                // TODO: Do we need to configure upfront?
                app.UseMiddleware<ExceptionHandlerMiddleware>();
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", ".Net Core 3 Demo Api");
                });

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication(); // Must come after UseStaticFiles and before UseMvc!
            //app.UseMvc();
            app.UseEndpoints(c => { c.MapControllers(); });

            // TODO: Test the Web Api using HTTP response compression
            //app.UseResponseCompression();
        }
    }
}
