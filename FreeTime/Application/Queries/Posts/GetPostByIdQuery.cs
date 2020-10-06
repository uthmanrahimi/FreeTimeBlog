using FreeTime.Web.Application.Models;
using MediatR;

namespace FreeTime.Web.Application.Queries.Posts
{
    public class GetPostByIdQuery:IRequest<PostDto>
    {
     
        public int Id { get; set; }
    }
}
