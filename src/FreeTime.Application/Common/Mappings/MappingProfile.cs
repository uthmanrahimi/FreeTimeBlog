using AutoMapper;

using FreeTime.Application.Common.DTOs;
using FreeTime.Application.Common.DTOs.Posts;
using FreeTime.Application.Features.Comments.Commands;
using FreeTime.Application.Features.Posts.Commands;
using FreeTime.Domain.Entities;

using System.Linq;

namespace FreeTime.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePostCommand, PostEntity>();
            CreateMap<PostEntity, PostDto>()
                .ForMember(dest => dest.TagList, src => src.MapFrom(t => t.PostTags.Select(x => x.Tag).Select(x => x.Name)))
                .ForMember(dest => dest.Tags, src => src.MapFrom(t => string.Join(';', t.PostTags.Select(x => x.Tag).Select(x => x.Name))))
                .ForMember(dest => dest.CommentsCount, src => src.MapFrom(c => c.Comments.Count(comment => comment.IsApproved)))
                ;

            CreateMap<UpdatePostCommand, PostEntity>().ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore());

            CreateMap<PostEntity, UserPostsDto>();

            CreateMap<PostEntity, PostListDto>()
                .ForMember(dest => dest.CommentsCount, src => src.MapFrom(s => s.Comments.Count))
                .ReverseMap();

            CreateMap<AddCommentCommand, PostCommentEntity>();

            CreateMap<PostCommentEntity, CommentDto>()
                .ForMember(dest => dest.CreatedDate, src => src.MapFrom(s => s.CreatedOn));

            CreateMap<UpdatePostCommand, PostDto>();
        }
    }
}
