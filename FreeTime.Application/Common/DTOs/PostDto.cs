using FreeTime.Domain.Entities.Enums;
using System;
using System.Collections.Generic;

namespace FreeTime.Application.Common.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Tags => string.Join(';', TagList);
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<string> TagList { get; set; }
        public PostStatus Status { get; set; }
        public int ViewCount { get; set; }
        public PostDto()
        {
        }
    }
}
