using FreeTime.Web.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace FreeTime.Web.Application.Queries.Posts
{
    public class GetPostsByCategoryQuery:IRequest<Envelope<IEnumerable<PostDto>>>
    {
        public string Category { get;private set; }
        public int PageIndex { get; private set; }
        public GetPostsByCategoryQuery(string category,int pageIndex)
        {
            Category = category;
            PageIndex = pageIndex;
        }
    }
}
