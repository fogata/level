using Level.Application.Common;
using Microsoft.AspNetCore.Http;

namespace Level.Application.Extension
{
    public static class HttpContextExtensions
    {
        public static DefaultHeaders GetDefaultHeaders(this HttpContext httpContext)
        {
            return httpContext.Items["DefaultHeaders"] as DefaultHeaders;
        }
    }
}
