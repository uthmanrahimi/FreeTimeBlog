using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeTime.Web.Application.Models.Entities.Identity
{
    public class UserToken : IdentityUserToken<int>
    {
  
    }

    public class UserLogin : IdentityUserLogin<int>
    {
      
    }
}
