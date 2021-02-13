using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FreeTime.Web.Application.Middlewares
{
    public class PageNotFoundMiddleware
    {
        private readonly RequestDelegate _next;

        public PageNotFoundMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            await _next(httpContext);
            if (httpContext.Response.StatusCode == 404 && !httpContext.Response.HasStarted)
            {
                httpContext.Request.Path = "/error/404/";
                await _next(httpContext);
            }
        }
    }
}
