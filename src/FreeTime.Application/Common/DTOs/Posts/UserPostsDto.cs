using FreeTime.Domain.Entities.Enums;
using System;

namespace FreeTime.Application.Common.DTOs.Posts
{
    public class UserPostsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public PostStatus Status { get; set; }
    }
}
