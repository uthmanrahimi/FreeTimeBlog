using FreeTime.Web.Application.Models.Dto;
using MediatR;
using System.Collections.Generic;

namespace FreeTime.Web.Application.Queries.Posts
{
    public class GetUserPostsQuery:IRequest<IEnumerable<UserPostsDto>>
    {
        public int UserId { get;private set; }

        public GetUserPostsQuery(int userId)
        {
            UserId = userId;
        }
    }
}
