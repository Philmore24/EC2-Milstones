using EC2_1701497.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EC2_1701497.ViewModels
{
    public class OrderViewModel
    {

        public int Id { get; set; }

        public Book BookOrder { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "1 - 10")]
        public int Quantity { get; set; }
    }
}
