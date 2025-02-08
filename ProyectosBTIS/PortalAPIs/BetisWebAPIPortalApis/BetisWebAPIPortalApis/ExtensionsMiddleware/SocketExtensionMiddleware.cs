using Microsoft.AspNetCore.WebSockets;

namespace BetisWebAPIPortalApis.ExtensionsMiddleware
{
    public static class WebSocketExtensionMiddlware
    {
        public static IApplicationBuilder UseSocket(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WebSocketMiddleware>();
        }
    }
}
