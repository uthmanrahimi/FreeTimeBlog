using AutoMapper;
using FreeTime.Web.Application.Commands;
using FreeTime.Web.Application.Core;
using FreeTime.Web.Application.Extensions;
using FreeTime.Web.Application.Infrastructures;
using FreeTime.Web.Application.Models.Entities;
using FreeTime.Web.Application.Services.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Web.Application.Handlers.Post
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, OperationResult>
    {
        private readonly ApplicationContext _context;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public UpdatePostHandler(ApplicationContext context, IPostService postService, IMapper mapper)
        {
            _context = context;
            _postService = postService;
            _mapper = mapper;
        }

        public async Task<OperationResult> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postService.Get(request.Id);

            if (post == null)
                return OperationResult.Failed("blog post with requested id was not found");

            post = _mapper.Map(request, post);

            post.PostTags.Clear();
            post.Slug = SafeSlug(string.IsNullOrEmpty(post.Slug) ? post.Title : post.Slug,post.Id);
            var tags = request.Tags.Split(";", System.StringSplitOptions.RemoveEmptyEntries);
            var existedTags = _context.Tags.Select(s => new { s.Id, s.Name }).Where(t => tags.Contains(t.Name)).ToList();
            var newTags = tags.Except(existedTags.Select(r => r.Name));

            foreach (var tag in existedTags)
                post.PostTags.Add(new PostTagEntity { TagId = tag.Id });

            foreach (var item in newTags)
            {
                var tag = new TagEntity { Name = item };
                post.PostTags.Add(new PostTagEntity { Tag = tag });
            }



            await _context.SaveChangesAsync();
            return OperationResult.Success;
        }
        private string SafeSlug(string slug, int id)
        {
            slug = slug.Friendly();
            int postfix = 2;
            string result = slug;
            while (true)
            {
                var post = _context.Posts.OrderBy(p => p.Id).FirstOrDefault(p => p.Slug == result);
                if (post != null && post.Id != id)
                {
                    result = $"{slug}-{postfix}";
                    postfix++;
                }
                else
                    return result;
            }
        }
    }
}
