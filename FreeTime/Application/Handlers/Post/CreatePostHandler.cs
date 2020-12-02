using AutoMapper;
using FreeTime.Web.Application.Extensions;
using FreeTime.Web.Application.Infrastructures;
using FreeTime.Web.Application.Models.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Web.Application.Handlers
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommand, bool>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public CreatePostHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {

            var post = _mapper.Map<PostEntity>(request);
            post.CreatedOn = DateTime.Now;
            post.Slug = SafeSlug(string.IsNullOrEmpty(post.Slug) ? post.Title : post.Slug);
            var tags = request.Tags.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(s => s.ToLower());
            var existedTags = _context.Tags.Select(s => new { s.Id, s.Name }).Where(t => tags.Contains(t.Name)).ToList();
            var newTags = tags.Except(existedTags.Select(r => r.Name));

            foreach (var tag in existedTags)
                post.PostTags.Add(new PostTagEntity { TagId = tag.Id });

            foreach (var item in newTags)
            {
                var tag = new TagEntity { Name = item };
                post.PostTags.Add(new PostTagEntity { Tag = tag });
            }

            await _context.Posts.AddAsync(post);
            return await _context.SaveChangesAsync() > 0;
        }

        private string SafeSlug(string slug)
        {
            slug = slug.Friendly();
            int postfix = 2;
            string result = slug;
            while (true)
            {
                var post = _context.Posts.OrderBy(p => p.Id).FirstOrDefault(p => p.Slug == result);
                if (post != null)
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
