using FreeTime.Web.Application.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FreeTime.Web.Controllers
{
    public class BaseController : Controller
    {
        public int LogedInUserId => User.Identity.IsAuthenticated ? this.User.UserId() : throw new Exception("Could not find any loged-in user");
    }
}