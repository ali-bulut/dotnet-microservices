using System;
using System.ComponentModel.DataAnnotations;

namespace FreeCourse.Web.Models
{
    public class SignInInput
    {
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool IsRemember { get; set; }
    }
}
