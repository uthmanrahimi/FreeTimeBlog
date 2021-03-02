using AutoMapper;
using FreeTime.Application.Common.DTOs;
using FreeTime.Application.Features.Profile.Commands;
using FreeTime.Application.Features.Profile.Queries;
using FreeTime.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeTime.Web.Areas.Admin.Controllers
{
    [Route("admin/profile")]
    [Area("admin")]
    public class ProfileController : ProtectedController
    {
        private readonly IMapper _mapper;

        public ProfileController(IMapper mapper)
        {
            _mapper = mapper;
        }


        [HttpGet("edit")]
        public async Task<IActionResult> Edit()
        {
            var result = await Mediator.Send(new GetProfileQuery());
            return View(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(ProfileDto profile)
        {
            if (!ModelState.IsValid)
                return View(profile);
            var command = _mapper.Map<UpdateProfileCommand>(profile);
            var result = await Mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}
