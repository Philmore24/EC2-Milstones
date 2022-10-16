using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using Microsoft.AspNetCore.Http;

namespace EC2_1701497.ViewModels
{
    public class BookCreateViewModel
    {
        [Display(Name = "Book ISBN")]
        public int ISBN { get; set; }
        [Required]
        [Display(Name = "Books Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Book's Author")]
        public string Author { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Book Publish Date")]
        public DateTime PublishDate { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
