using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EC2_1701497.ViewModels
{
    
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<string>();

            Roles = new List<string>();
        }
        public string Id { get; set; }
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Username { get; set; }

        [DataType(DataType.Date)]
        public string DOB { get; set; }

        public string Gender { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public List<string> Claims { get; set; }
        public IList<string> Roles { get; set; }
    }
}
