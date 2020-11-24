﻿using AutoMapper;
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
            post.Slug = SafeSlug(post.Slug.Friendly());
            request.Tags.Split(";").ToList().ForEach(tag => post.PostTags.Add(new PostTagEntity { Post = post, Tag = new TagEntity { Name = tag } }));
            await _context.Posts.AddAsync(post);
            return await _context.SaveChangesAsync() > 0;
        }

        private string SafeSlug(string slug)
        {
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
        private void AddTags()
        {

        }

    }
}
