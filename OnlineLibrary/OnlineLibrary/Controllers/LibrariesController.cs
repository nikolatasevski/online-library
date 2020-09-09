using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OnlineLibrary.Models;

namespace OnlineLibrary.Controllers
{
    [Authorize]
    public class LibrariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Libraries
        [Authorize(Roles =("Admin, Librarian, User"))]
        public ActionResult Index()
        {
            return View(db.Libraries.ToList());
        }

        // GET: Libraries/Details/5
        [Authorize(Roles = ("Admin, Librarian, User"))]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library library = db.Libraries.Find(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // GET: Libraries/Create
        [Authorize(Roles = ("Admin, Librarian"))]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Libraries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = ("Admin, Librarian"))]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LibraryId,Name,Address")] Library library)
        {
            if (ModelState.IsValid)
            {
                db.Libraries.Add(library);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(library);
        }

        // GET: Libraries/Edit/5
        [Authorize(Roles = ("Admin, Librarian"))]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library library = db.Libraries.Find(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // POST: Libraries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = ("Admin, Librarian"))]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LibraryId,Name,Address")] Library library)
        {
            if (ModelState.IsValid)
            {
                db.Entry(library).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(library);
        }

        // GET: Libraries/Delete/5
        [Authorize(Roles = ("Admin, Librarian"))]
        public ActionResult Delete(int id)
        {
            Library library = db.Libraries.Find(id);
            db.Libraries.Remove(library);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //GET: AddToLibrary
        [Authorize(Roles = ("Admin, Librarian"))]
        public ActionResult AddToLibrary (int id)
        {
            var model = new AddToLibrary();
            model.selectedLibrary = id;
            model.Books = db.Books.ToList();
            var library = db.Libraries.Find(model.selectedLibrary);
            ViewBag.LibraryName = library.Name;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = ("Admin, Librarian"))]
        public ActionResult AddToLibrary(AddToLibrary model)
        {
            var library = db.Libraries.Find(model.selectedLibrary);
            var book = db.Books.Find(model.selectedBook);
            library.Books.Add(book);
            db.SaveChanges();

            return RedirectToAction("Index","Libraries");
        }

        //GET: ReserveBook
        public ActionResult ReserveBook()
        {
            var model = new ReserveBook();
            model.allLibraries = db.Libraries.ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult ReserveBook(int allLibraries, int book)
        {
            BookReservation reservation = new BookReservation();
            reservation.library = db.Libraries.Where(m => m.LibraryId == allLibraries).First();
            reservation.selectedBook = db.Books.Where(m => m.BookId == book).First();
            var userID = User.Identity.GetUserId();
            reservation.user = db.Users.Where(m => m.Id == userID).First();
            db.Users.Where(m => m.Id == userID).First().reservedBooks.Add(reservation);

            db.BookReservations.Add(reservation);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        // POST: Libraries/ReserveBook/5
        [HttpPost]
        public ActionResult GetBookById(int libraryId)
        {
            List<Book> books = new List<Book>();
            books = db.Libraries.Where(m => m.LibraryId == libraryId).First().Books.ToList();
            SelectList booksList = new SelectList(books, "BookId", "BookName", 0);
            return Json(booksList);
        }

    }
}
