using System;
using System.Collections.Generic;
using System.Linq;

namespace FreeTime.Application.Common.DTOs.Posts
{
    public class PostDetailtDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Tags { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; }
        public List<string> TagList => Tags.Split(";").ToList();
    }
}
