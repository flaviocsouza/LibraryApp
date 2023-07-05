using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace LibraryApi.Extensions
{
    public class CustomAuthorization
    {
        public static bool CheckUserClaims(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated
                && context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
        }
    }

    public class ClaimsAuthorizationAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizationAttribute(string claimName, string claimValue) : base (typeof(CustomClaimFilter))
        {
            Arguments = new object[] { claimName, claimValue };
        }
    }

    public class CustomClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;
        public CustomClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            if (!CustomAuthorization.CheckUserClaims(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }

        }
    }
}
