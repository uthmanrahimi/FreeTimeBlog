using FreeTime.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FreeTime.Domain.Entities
{
    public class PostEntity : BaseEntity, IEntity
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Slug { get; set; }

        [Required]
        public string Title { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Required]
        public PostStatus Status { get; set; }
        public int WriterId { get; set; }
        public int ViewCount { get; set; }
        public ICollection<PostTagEntity> PostTags { get; set; }
        public ICollection<PostCommentEntity> Comments { get; private set; }

        public PostEntity()
        {
            PostTags = new List<PostTagEntity>();
            Comments = new List<PostCommentEntity>();
        }

    }
}