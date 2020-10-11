using System.ComponentModel.DataAnnotations;

namespace FreeTime.Web.Application.Models
{
    public class CreatePostViewModel
    {
        [Required]
       
        public string Description { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public string Tags { get; set; }
        [Required]
        public string Title { get; set; }
        public PostStatus Status { get; set; }
    }
}
