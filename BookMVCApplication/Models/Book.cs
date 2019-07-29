using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookMVCApplication.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Display(Name = "Book Name")]
        [Required]
        public string BookName { get; set; }
        //public string Author { get; set; }
    }
}