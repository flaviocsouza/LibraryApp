using LibraryBusiness.Interface.Request;
using System.Security.Claims;

namespace LibraryApi.Extensions
{
    public class AppUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly ClaimsPrincipal _user;

        public AppUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _user = accessor.HttpContext.User;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _user.Claims;
        }

        public string GetUserEMail()
        {
            return IsAuthenticated() ? _user.GetUserEMail() : String.Empty;
        }

        public Guid GetUserId()
        {
            return IsAuthenticated() ? Guid.Parse(_user.GetUserId()): Guid.Empty;
        }

        public bool IsAuthenticated()
        {
            return IsAuthenticated();
        }

        public bool IsInRole(string role)
        {
            return _user.IsInRole(role);
        }
    }

    public static class ClaimsInfoExtentions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if(principal == null)
                throw new ArgumentException(nameof(principal));

            var claim = principal.FindFirst(ClaimTypes.NameIdentifier);
            
            return claim?.Value;
        }

        public static string GetUserEMail(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(nameof(principal));

            var claim = principal.FindFirst(ClaimTypes.Email);
            return claim?.Value;
        }
    }

}
