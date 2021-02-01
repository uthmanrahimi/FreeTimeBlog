using System;

namespace FreeTime.Application.Common.DTOs
{
    public class CommentDto
    {
        public string Content { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
