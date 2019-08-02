using FreeTime.Web.Application.Models.Entities.Identity;
using System.Linq;
using System.Security.Claims;

namespace FreeTime.Web.Application.Extensions
{
    public static class SecurityExtensions
    {
        public static User CurrentUser(this Claim claims)
        {
            return new User();
        }
        public static int UserId(this ClaimsPrincipal claims)
        {
            // return claims.Claims.Where(c=>c.Type==)
            var claim = claims.Claims.First(p => p.Type == ClaimTypes.NameIdentifier);
            return int.Parse(claim.Value);
        }
    }
}
