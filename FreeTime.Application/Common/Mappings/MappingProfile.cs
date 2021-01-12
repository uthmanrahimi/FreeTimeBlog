using AutoMapper;
using FreeTime.Application.Common.DTOs;
using FreeTime.Application.Common.DTOs.Posts;
using FreeTime.Application.Features.Posts.Commands;
using FreeTime.Domain.Entities;
using FreeTime.Domain.Entities.Enums;
using System.Linq;

namespace FreeTime.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePostCommand, PostEntity>().ForMember(src => src.Status, dest => dest.MapFrom(src => PostStatus.Draft));
            CreateMap<PostEntity, PostDto>()
                .ForMember(dest => dest.TagList, src => src.MapFrom(t => t.PostTags.Select(x => x.Tag).Select(x => x.Name)));

            CreateMap<UpdatePostCommand, PostEntity>().ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore());

            CreateMap<PostEntity, UserPostsDto>();

            CreateMap<PostEntity, PostListDto>()
                .ReverseMap();

        }
    }
}
