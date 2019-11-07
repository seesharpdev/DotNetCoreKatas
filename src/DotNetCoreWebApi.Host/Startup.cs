using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace DotNetCoreWebApi.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
	        services.AddMvc(option => option.EnableEndpointRouting = false)
	            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

	        // Uncomment to enable CORS
	        //ConfigureCors(services);

	        ConfigureAuthentication(services);
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
	        if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

			// TODO: Do we need to configure upfront?
	        app.UseMiddleware<ExceptionHandlerMiddleware>();

	        app.UseHttpsRedirection();
	        app.UseStaticFiles();
	        app.UseAuthentication(); // Must come after UseStaticFiles and before UseMvc!
			//app.UseMvc();

			// TODO: Test the Web Api using HTTP response compression
			//app.UseResponseCompression();
		}
    }
}
