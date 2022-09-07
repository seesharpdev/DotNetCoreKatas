using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using DotNetCoreWebHost.Authorization;
using DotNetCoreWebHost.Data;

namespace DotNetCoreWebHost
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
            services.AddDbContext<AppDbContext>(config =>
                {
                    config.UseInMemoryDatabase(nameof(AppDbContext));
                });

            services.AddIdentity<IdentityUser, IdentityRole>(config =>
                {
                    config.Password.RequiredLength = 4;
                    config.Password.RequireDigit = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequireLowercase = false;
                })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config =>
                {
                    config.Cookie.Name = "AuthCookie";
                    config.LoginPath = "/Home/Login";
                    config.LogoutPath = "/Home/Logout";
                });

            #region Obsolete

            //services.AddAuthentication(AuthenticationScheme)
            //    .AddCookie(AuthenticationScheme, config =>
            //        {
            //            config.Cookie.Name = "AuthCookie";
            //            config.LoginPath = "/Home/Authenticate";
            //        });

            #endregion

            services.AddAuthorization(config =>
                {
                    #region Obsolete

                    //var defaultAuthBuilder = new AuthorizationPolicyBuilder();
                    //var defaultAuthPolicy = defaultAuthBuilder.RequireAuthenticatedUser()
                    //    .RequireClaim(ClaimTypes.DateOfBirth)
                    //    .Build();

                    //config.DefaultPolicy = defaultAuthPolicy;

                    #endregion

                    config.AddPolicy("DateOfBirth", policy =>
                        {
                            //policy.AddRequirements(new AddClaimTypeRequirement(ClaimTypes.DateOfBirth));
                            policy.AddClaimTypeRequirement(ClaimTypes.DateOfBirth);
                        });
                });

            services.AddScoped<IAuthorizationHandler, RequireCustomClaimHandler>();
            services.AddScoped<IAuthorizationHandler, UserAgentAuthorizationHandler>();

            services.AddControllersWithViews(config =>
                {
                    config.Filters.Add(new AuthorizeFilter());
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            
            app.UseRouting();
            
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapDefaultControllerRoute();
                });
        }
    }
}
