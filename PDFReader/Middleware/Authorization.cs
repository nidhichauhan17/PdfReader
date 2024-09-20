using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PDFReader.Infrastructure.Settings;

namespace PDFReader.Middleware
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly AppSettings _appSettings;

        public AuthorizationFilter(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var extractedApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!_appSettings.UserAuthenticationKey.Equals(extractedApiKey))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }

    // This is just a marker attribute, no logic needed here
    public class AuthorizationAttribute : TypeFilterAttribute
    {
        public AuthorizationAttribute() : base(typeof(AuthorizationFilter))
        {
        }
    }
}
