using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibrary.Models
{
    public class AddToLibrary
    {
        public List<Book> Books { get; set; }
        public int selectedBook { get; set; }
        public int selectedLibrary { get; set; }
        public AddToLibrary()
        {
            Books = new List<Book>();
        }
    }
}