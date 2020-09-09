using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineLibrary.Models
{
    public class BookReservation
    {
        [Key]
        public int reservationID { get; set; }

        public virtual Library library { get; set; }

        public virtual Book selectedBook { get; set; }

        public virtual ApplicationUser user { get; set; }
    }
}