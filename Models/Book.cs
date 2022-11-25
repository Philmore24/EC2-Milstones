using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EC2_1701497.Models
{
    public class Book
    {
        [Key]
        [Display(Name = "Book ISBN")]
        public int ISBN { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter a title"), MaxLength(100)]
        [Display(Name = "Books Title")]
        public string Title { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter a author"), MaxLength(200)]
        [Display(Name = "Book's Author")]
        public string Author { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter a publish date ")]
        [Display(Name = "Book Publish Date")]
        public DateTime PublishDate { get; set; }

        //[DataType]
        [Required(ErrorMessage = "Value must integer")]
        [Display(Name = "Available Quantity")]
        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Value does not respresent correct format. Must be 00.00")]
        [Display(Name = "Unit Price JA:")]
        public float Price { get; set; }


        [Required]
        [DataType(DataType.ImageUrl, ErrorMessage = "File Must Contain image File Extension")]
        public string Image { get; set; }

    }
}
