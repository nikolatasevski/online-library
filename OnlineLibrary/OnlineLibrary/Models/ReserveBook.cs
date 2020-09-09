using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLibrary.Models
{
    public class ReserveBook
    {
        public List<Library> allLibraries{ get; set; }

        public SelectList FilteredBooks { get; set; }

    }
}