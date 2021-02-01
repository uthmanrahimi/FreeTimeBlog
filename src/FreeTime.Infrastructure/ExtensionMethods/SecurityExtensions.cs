using FreeTime.Infrastructure.Identity;
using System.Linq;
using System.Security.Claims;

namespace FreeTime.Infrastructure.ExtensionMethods
{
    public static class SecurityExtensions
    {
        public static User CurrentUser(this Claim claims)
        {
            return new User();
        }
        public static int UserId(this ClaimsPrincipal claims)
        {
            var claim = claims.Claims.First(p => p.Type == ClaimTypes.NameIdentifier);
            return int.Parse(claim.Value);
        }
    }
}
