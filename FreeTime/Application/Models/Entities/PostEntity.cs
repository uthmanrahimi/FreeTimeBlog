using FreeTime.Web.Application.Models.Entities.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace FreeTime.Web.Application.Models.Entities
{
    public class PostEntity: IEntity
    {
        [Required]
        public string Description { get; set; }
        public int Id { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public string Tags { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public PostStatus Status { get; set; }
        public User Writer { get; set; }
        public int WriterId { get; set; }
    }
}