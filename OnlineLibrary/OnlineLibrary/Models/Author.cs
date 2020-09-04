using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineLibrary.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string AuthorFullName { get; set; }
        [Range(1,99)]
        public int Age { get; set; }
    }
}