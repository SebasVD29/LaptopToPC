using BetisWebAPIPortalApis.CustomMiddleware;

namespace BetisWebAPIPortalApis.ExtensionsMiddleware
{
    public static class CultureExtensionMiddlware
    {
        public static IApplicationBuilder UseRequestCulture(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CultureMiddleware>();
        }
    }
}
