using System.ComponentModel.DataAnnotations;

namespace FreeTime.Web.Application.Models
{
    public class UpdatePostViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public string Tags { get; set; } = string.Empty;
        [Required]
        public string Title { get; set; }
    }
}
