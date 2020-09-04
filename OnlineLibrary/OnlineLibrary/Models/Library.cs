using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineLibrary.Models
{
    public class Library
    {
        [Key]
        public int LibraryId { get; set; }
        
        [Required]
        public string Name { get; set; }
       
        [Required]
        public string Address { get; set; }
        //list of books
        public virtual ICollection<Book> Books { get; set; }

        public Library()
        {
            Books = new List<Book>();
        }
    }
}