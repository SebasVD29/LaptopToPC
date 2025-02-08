using BetisWebAPIPortalApis.Model;
using System.Globalization;
using System.Xml.Linq;

namespace BetisWebAPIPortalApis.CustomMiddleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Name name;

        public CultureMiddleware(RequestDelegate next, Name name)
        {
            _next = next;
            this.name = name;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var joko = this.name;
            var cultureQuery = context.Request.Query["culture"];
            if (!string.IsNullOrWhiteSpace(cultureQuery))
            {
                var culture = new CultureInfo(cultureQuery);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;

            }

            // Call the next delegate/middleware in the pipeline
            await _next(context);


        }


    }
}
