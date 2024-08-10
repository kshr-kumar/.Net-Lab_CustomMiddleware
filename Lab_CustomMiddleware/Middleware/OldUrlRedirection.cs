using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Lab_CustomMiddleware.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class OldUrlRedirection
    {
        private readonly RequestDelegate _next;

        public OldUrlRedirection(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var url =  httpContext.Request.Path.Value;
            string redirectUrl = "";

            if(!string.IsNullOrEmpty(url))
            {
                url = url.ToLowerInvariant();
            }
            switch(url)
            {
                case "/home/privacy":
                    redirectUrl = "/privacy-policy";
                    break;

                case "/account/login":
                    redirectUrl = "/login";
                    break;
            }
            
            if(!string.IsNullOrEmpty(redirectUrl))
            {
                httpContext.Response.Redirect(redirectUrl);
                return;
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    //public static class OldUrlRedirectionExtensions
    //{
    //    public static IApplicationBuilder UseOldUrlRedirection(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<OldUrlRedirection>();
    //    }
    //}
}
