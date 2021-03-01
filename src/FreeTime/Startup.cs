using FluentValidation.AspNetCore;
using FreeTime.Application;
using FreeTime.Application.Common.Interfaces;
using FreeTime.Application.Features.Posts.Commands;
using FreeTime.Infrastructure;
using FreeTime.Web.Application;
using FreeTime.Web.Application.Core;
using FreeTime.Web.Application.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FreeTime
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddInfrastructureServices(Configuration);
            services.AddApplicationServices();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddSwaggerGen();


            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Security/Login";
                options.LogoutPath = "/Security/Logout";
                options.AccessDeniedPath = "/Security/AccessDenied";
                options.SlidingExpiration = true;
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".Freetime",
                    Path = "/",
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest
                };
            });
            services.Configure<BlogSettings>(Configuration.GetSection("Blog"));
            services.AddHealthChecks();
            services.AddRazorPages();
            services.AddControllersWithViews().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<CreatePostCommand>());
            services.AddSingleton<IApplicationConfiguration, ApplicationConfiguration>();
        }

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
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseStaticFiles();
            app.UseMiddleware<PageNotFoundMiddleware>();
            app.UseAuthentication();
            app.UseRouting();
    
            app.UseAuthorization();
      
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
              name: "admin",
              pattern: "{area=Admin}/{controller}/{action}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Blog}/{action=Index}/{id?}");

             
            });
        }
    }
}