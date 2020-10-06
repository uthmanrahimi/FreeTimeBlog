using System;

namespace FreeTime.Web.Application.Models
{
    public class PostListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ViewCount { get; set; }
        public PostStatus Status { get; set; }

    }
}
