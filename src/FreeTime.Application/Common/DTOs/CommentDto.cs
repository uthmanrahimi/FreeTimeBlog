using System;

namespace FreeTime.Application.Common.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsApproved { get; set; }
    }
}
