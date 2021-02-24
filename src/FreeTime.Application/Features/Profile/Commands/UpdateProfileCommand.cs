using AutoMapper;
using FreeTime.Application.Common.Interfaces;
using FreeTime.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Application.Features.Profile.Commands
{
    public class UpdateProfileCommand : IRequest
    {
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string About { get; set; }
        public string StackOverflowProfile { get; set; }
        public string LinkedinProfile { get; set; }
        public string GithubProfile { get; set; }
        public string TwitterProfile { get; set; }
    }

    public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand>
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;

        public UpdateProfileCommandHandler(IDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = await _context.Profile.SingleOrDefaultAsync();
            profile = _mapper.Map<ProfileEntity>(request);
            _context.Profile.Update(profile);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
