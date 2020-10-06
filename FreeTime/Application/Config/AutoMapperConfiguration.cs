using AutoMapper;
using FreeTime.Web.Application.Commands;
using FreeTime.Web.Application.Models;
using FreeTime.Web.Application.Models.Dto;
using FreeTime.Web.Application.Models.Entities;

namespace FreeTime.Web.Application.Config
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<CreatePostViewModel, CreatePostCommand>().ReverseMap();
            CreateMap<CreatePostCommand, PostEntity>().ForMember(src=>src.Status,dest=>dest.UseValue(PostStatus.Draft));
            CreateMap<PostEntity, PostDto>();



            CreateMap<UpdatePostViewModel, UpdatePostCommand>();
            CreateMap<UpdatePostCommand, PostEntity>().ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore());

            CreateMap<PostEntity, UserPostsDto>();

            CreateMap<PostEntity, PostListDto>().ReverseMap();
        }
    }
}
