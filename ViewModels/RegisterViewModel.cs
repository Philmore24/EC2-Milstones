using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EC2_1701497.ViewModels
{
    public class RegisterViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter First Name"), MaxLength(50)]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Last Name"), MaxLength(50)]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }
    }
}
