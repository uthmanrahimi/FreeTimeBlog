using AutoMapper;
using FreeTime.Web.Application.Commands;
using FreeTime.Web.Application.Models.Entities;
using FreeTime.Web.Application.Models;
using System;
using FreeTime.Web.Application.Models.Dto;

namespace FreeTime.Web.Application.Config
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<CreatePostViewModel, CreatePostCommand>().ReverseMap();
            CreateMap<CreatePostCommand, PostEntity>().ForMember(src=>src.CreatedOn,dest=>dest.UseValue(DateTime.Now));
            CreateMap<PostEntity, PostDto>().ReverseMap();
            CreateMap<UpdatePostViewModel, UpdatePostCommand>();
            CreateMap<UpdatePostCommand, PostEntity>().ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore());

            CreateMap<PostEntity, UserPostsDto>();
        }
    }
}
