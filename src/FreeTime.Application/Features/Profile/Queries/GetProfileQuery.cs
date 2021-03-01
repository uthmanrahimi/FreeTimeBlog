using AutoMapper;
using FreeTime.Application.Common.DTOs;
using FreeTime.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Application.Features.Profile.Queries
{
    public class GetProfileQuery : IRequest<ProfileDto>
    {
    }

    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, ProfileDto>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetProfileQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ProfileDto> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var profile = await _dataContext.Profile.SingleOrDefaultAsync(x => x.Id == 1);
            return _mapper.Map<ProfileDto>(profile);
        }
    }
}
