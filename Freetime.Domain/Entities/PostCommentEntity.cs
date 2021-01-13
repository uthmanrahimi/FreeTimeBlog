using System;

namespace FreeTime.Domain.Entities
{
    public class PostCommentEntity:BaseEntity,IEntity
    {
        public PostEntity Post { get; set; }
        public int PostId { get; set; }
        public string AuthorName { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? PubDate { get; set; }
    }
}
