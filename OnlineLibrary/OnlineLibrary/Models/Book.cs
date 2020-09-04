using OnlineLibrary.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineLibrary.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public Author Author { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Publisher { get; set; }
        
        public Language Language { get; set; }
        //list of libraries

        public virtual ICollection<Library> Libraries{ get; set; }
    
        public Book()
        {
            Libraries = new List<Library>();
        }
    }
}