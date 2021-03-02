using FreeTime.Infrastructure.ExtensionMethods;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FreeTime.Web.Areas.Admin.Controllers
{
    [Authorize]
    public abstract class ProtectedController : Controller
    {
      
        public int LogedInUserId => User.Identity.IsAuthenticated ? this.User.UserId() : throw new Exception("Could not find any loged-in user");
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
