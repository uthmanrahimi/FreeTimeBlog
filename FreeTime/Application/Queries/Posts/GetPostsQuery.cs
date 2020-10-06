using FreeTime.Web.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace FreeTime.Web.Application.Queries.Posts
{
    public class GetPostsQuery : IRequest<Envelope<IEnumerable<PostDto>>>
    {
        public int Page { get; set; }
        public int Take { get; set; }
        public PostStatus Status { get; set; }
        public GetPostsQuery()
        {
            Status = PostStatus.Published;
        }
    }
}
