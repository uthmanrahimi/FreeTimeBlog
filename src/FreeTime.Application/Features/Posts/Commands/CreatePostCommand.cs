using AutoMapper;
using FluentValidation;
using FreeTime.Application.Common.ExtensionMethods;
using FreeTime.Application.Common.Interfaces;
using FreeTime.Application.Common.Models;
using FreeTime.Domain.Entities;
using FreeTime.Domain.Entities.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Application.Features.Posts.Commands
{
    public class CreatePostCommand : IRequest<bool>
    {
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Tags { get; set; }
        public string Title { get; set; }
        public int WriterId { get; set; }
        public PostStatus Status { get; set; }

        public class PostHandler : IRequestHandler<CreatePostCommand, bool>,
                             IRequestHandler<UpdatePostCommand, OperationResult>
        {
            private readonly IDataContext _context;
            private readonly IMapper _mapper;

            public PostHandler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<bool> Handle(CreatePostCommand request, CancellationToken cancellationToken)
            {

                var post = _mapper.Map<PostEntity>(request);
                post.Slug = SafeSlug(string.IsNullOrEmpty(post.Slug) ? post.Title : post.Slug);

                SetPostTag(request.Tags, post);

                await _context.Posts.AddAsync(post);
                return await _context.SaveChangesAsync(cancellationToken) > 0;
            }

            public async Task<OperationResult> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts.Include(p => p.PostTags).SingleOrDefaultAsync(x => x.Id == request.Id);

                if (post == null)
                    return OperationResult.Failed("blog post with requested id was not found");

                post = _mapper.Map(request, post);
                post.PostTags.Clear();
                post.Slug = SafeSlug(string.IsNullOrEmpty(post.Slug) ? post.Title : post.Slug);
                SetPostTag(request.Tags, post);

                await _context.SaveChangesAsync(cancellationToken);
                return OperationResult.Success;
            }

            private string SafeSlug(string slug, int? id = null)
            {
                slug = slug.Friendly();
                int postfix = 2;
                string result = slug;
                while (true)
                {
                    var post = GetPost(result, id);
                    if (post != null)
                    {
                        result = $"{slug}-{postfix}";
                        postfix++;
                    }
                    else
                        return result;
                }
            }

            private PostEntity GetPost(string slug, int? id)
            {
                if (id == null)
                    return _context.Posts.OrderBy(p => p.Id).FirstOrDefault(p => p.Slug == slug);
                return _context.Posts.OrderBy(p => p.Id).FirstOrDefault(p => p.Slug == slug && p.Id != id.Value);
            }

            private void SetPostTag(string blogTags, PostEntity blogPost)
            {
                var tags = blogTags.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(s => s.ToLower());
                var existedTags = _context.Tags.Select(s => new { s.Id, s.Name }).Where(t => tags.Contains(t.Name)).ToList();
                var newTags = tags.Except(existedTags.Select(r => r.Name));

                foreach (var tag in existedTags)
                    blogPost.PostTags.Add(new PostTagEntity { TagId = tag.Id });

                foreach (var item in newTags)
                {
                    var tag = new TagEntity { Name = item };
                    blogPost.PostTags.Add(new PostTagEntity { Tag = tag });
                }
            }
        }

        public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
        {
            private readonly IDataContext _dataContext;

            public CreatePostCommandValidator(IDataContext dataContext)
            {
                RuleFor(v => v.Title).MustAsync(BeUniqueTitle).WithMessage("Title must be unique")
                    .NotEmpty().WithMessage("Title is required");
                RuleFor(r => r.Description).NotEmpty().WithMessage("Post Content is Required").MinimumLength(100);
                RuleFor(r => r.Tags).NotEmpty().NotNull().WithMessage("At least one tag is required");
                _dataContext = dataContext;
            }

            public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
            {
                return await _dataContext.Posts
                    .AllAsync(l => l.Title != title);
            }
        }
    }


}