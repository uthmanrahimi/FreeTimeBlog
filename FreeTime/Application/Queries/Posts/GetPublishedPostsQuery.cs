using FreeTime.Web.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace FreeTime.Web.Application.Queries.Posts
{
    public class GetPublishedPostsQuery : IRequest<Envelope<IEnumerable<PostDto>>>
    {
        public int Page { get; set; }
        public int PostsPerPage { get; set; }
        public GetPublishedPostsQuery(int page,int postsPerPage=10)
        {
            Page = page;
            PostsPerPage = postsPerPage;
        }
    }
}
