using FreeTime.Web.Application.Models.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FreeTime.Web.Application.Models.Entities
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
        public User Writer { get; set; }
        public int WriterId { get; set; }
        public int ViewCount { get; set; }
        public ICollection<PostTagEntity> PostTags { get; set; }

        public PostEntity()
        {
            PostTags = new List<PostTagEntity>();
        }

        public void AddTag(TagEntity tag)
        {
            this.PostTags.Add(new PostTagEntity { Post = this, Tag = tag });
        }

        public void AddTags(IEnumerable<TagEntity> tags)
        {
            tags.ToList().ForEach(tag =>
            {
                AddTag(tag);
            });
        }

    }
}