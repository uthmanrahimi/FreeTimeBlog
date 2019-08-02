using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FreeTime.Web.Application.Models.Entities.Identity
{
    public class Role : IdentityRole<int>
    {
        public string Description { get; set; }

        public virtual ICollection<UserRole> Users { get; set; }

        public virtual ICollection<RoleClaim> Claims { get; set; }
    }
}
