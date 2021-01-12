using FreeTime.Infrastructure.ExtensionMethods;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FreeTime.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public int LogedInUserId => User.Identity.IsAuthenticated ? this.User.UserId() : throw new Exception("Could not find any loged-in user");

        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
        
    }
}