using FreeTime.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Application.Features.Tags.Queries
{
    public class GetPopularTagsQuery : IRequest<IEnumerable<KeyValuePair<string, int>>>
    {

    }

    public class GetPopularTagsQueryHandler : IRequestHandler<GetPopularTagsQuery, IEnumerable<KeyValuePair<string, int>>>
    {
        private readonly IDataContext _context;

        public GetPopularTagsQueryHandler(IDataContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<KeyValuePair<string, int>>> Handle(GetPopularTagsQuery request, CancellationToken cancellationToken)
        {
            return await _context.PostTags.Include(x => x.Tag).GroupBy(x => new { x.TagId, x.Tag.Name })
                .OrderByDescending(x=>x.Count())
                .Select(x => new KeyValuePair<string, int>(x.Key.Name, x.Count()))
            .ToListAsync();
        }
    }
}
