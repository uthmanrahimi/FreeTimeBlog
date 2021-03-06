﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FreeTime.Infrastructure.Identity
{
    public class Role : IdentityRole<int>
    {
        public string Description { get; set; }

        public virtual ICollection<UserRole> Users { get; set; }

        public virtual ICollection<RoleClaim> Claims { get; set; }
    }
}
