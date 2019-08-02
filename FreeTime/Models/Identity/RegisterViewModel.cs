using System.ComponentModel.DataAnnotations;

namespace FreeTime.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password",ErrorMessage = "Confirm Password is Not Correct")]
        public string ConfirmPassword { get; set; }
    }
}
