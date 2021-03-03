using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WEBTP.Data;
using WEBTP.Entities;

namespace WEBTP.Controllers

{

    public class BooksController : Controller
    {
        private WEBTPContext db = new WEBTPContext();

        // GET: Books
      
        public ActionResult Index(string sortOrder, string SearchTitle, string SearchNbPagesEqual, string SearchNbPgMin, string SearchNbPgMax, string SearchNbPriceMin, string SearchNbPriceMax)

        {
            TestSession();

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var books = from b in db.Books.Include(b => b.User)
                        select b;
            //recherche par titre
            if (!String.IsNullOrEmpty(SearchTitle))
            {
                books = books.Where(b => b.Title.Contains(SearchTitle));
            }
            //recherche nbr pages min & max
            if (!String.IsNullOrEmpty(SearchNbPgMin) && !String.IsNullOrEmpty(SearchNbPgMax))
            {
                int SearchMin = Int32.Parse(SearchNbPgMin);
                int SearchMax = Int32.Parse(SearchNbPgMax);
       
                books = books.Where(x => x.NbPages > SearchMin && x.NbPages < SearchMax);
            }
            //recherche nbr pagesequals
            if (!String.IsNullOrEmpty(SearchNbPagesEqual))
            {          
                int SearchMax = Int32.Parse(SearchNbPagesEqual);
                books = books.Where(x => x.NbPages.Equals(SearchNbPagesEqual));
            }
            //recherche prix min & max
            if (!String.IsNullOrEmpty(SearchNbPriceMin) && !String.IsNullOrEmpty(SearchNbPriceMax))
            {
                int SearchMin = Int32.Parse(SearchNbPriceMin);
                int SearchMax = Int32.Parse(SearchNbPriceMax);
                books = books.Where(x => x.Price > SearchMin && x.NbPages < SearchMax);

            }
            //tri par titre et prix
            switch (sortOrder)
            {
                case "title_desc":
                    books = books.OrderByDescending(b => b.Title);
                    break;
                case "price_desc":
                    books = books.OrderByDescending(b => b.Price);
                    break;
                case "title_asc":
                    books = books.OrderBy(b => b.Title);
                    break;


                default:
                    books = books.OrderBy(b => b.Price);
                    break;


            }
            return View(books.ToList());
        }

        [HttpGet, ActionName("Buy")]
        public ActionResult Buy(long id)
        {

            TestSession();
            var book = db.Books.Find(id).Title;

            ViewBag.Message = "You Bought a book : " + book;

          


            return View();
        }

        // GET: Books/Details/5
        public ActionResult Details(long? id)
        {
            TestSession();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            TestSession();

            ViewBag.IdUser = new SelectList(db.Users, "IdUser", "Firstname");

            return View();
        }

        // POST: Books/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBook,Title,NbPages,Price,IdUser")] Book book)
        {
            TestSession();

            if (ModelState.IsValid)
            {



                long id = (long)Session["idConnect"];






                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUser = new SelectList(db.Users, "IdUser", "Firstname", book.IdUser);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(long? id)
        {
            TestSession();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUser = new SelectList(db.Users, "IdUser", "Firstname", book.IdUser);
            return View(book);
        }

        // POST: Books/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBook,Title,NbPages,Price,IdUser")] Book book)
        {
            TestSession();

            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUser = new SelectList(db.Users, "IdUser", "Firstname", book.IdUser);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(long? id)
        {
            TestSession();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TestSession();

            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            TestSession();
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        protected ActionResult TestSession()
        {
           // TestSession();
            if (Session["idConnect"] == null)
            {

                return RedirectToAction("Index", "Account");
            }
            else
            {
                long id = (long)Session["idConnect"];

                User user = db.Users.Find(id);
                return View(user.IdUser);
            }
        }
    }
}
