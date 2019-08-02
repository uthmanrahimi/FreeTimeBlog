using FreeTime.Web.Application.Services;
using FreeTime.Web.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FreeTime.Web.Application.Extensions
{
    public static class RegisterServicesExtensionMethod
    {
        public static void RegsiterServices(this IServiceCollection services)
        {
            //TODO:do this by DI Library
            services.AddTransient<IPostService, PostService>();
        }
    }
}
