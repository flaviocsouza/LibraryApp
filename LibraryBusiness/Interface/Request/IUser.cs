using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Interface.Request
{
    public interface IUser
    {
        string Name { get; }
        Guid GetUserId();
        string GetUserEMail();
        bool IsAuthenticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();

    }
}
