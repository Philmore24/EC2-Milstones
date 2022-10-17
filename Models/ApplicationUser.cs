using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EC2_1701497.Models
{
    public class ApplicationUser: IdentityUser
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Please enter First Name"), MaxLength(50)]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [DataType(DataType.Text)]
         [Required(ErrorMessage = "Please enter Last Name"), MaxLength(50)]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

       
    }
}
