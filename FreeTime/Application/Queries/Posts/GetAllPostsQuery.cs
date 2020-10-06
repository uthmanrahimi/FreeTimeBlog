using FreeTime.Web.Application.Models;
using FreeTime.Web.Application.Models.Dto;
using MediatR;
using System.Collections.Generic;

namespace FreeTime.Web.Application.Queries.Posts
{
    public class GetAllPostsQuery : IRequest<Envelope<IEnumerable<PostListDto>>>
    {
        public int Page { get; set; }
    }
}
