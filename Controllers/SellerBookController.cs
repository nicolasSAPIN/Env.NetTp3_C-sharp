using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBTP.Data;
using WEBTP.Entities;

namespace WEBTP.Controllers
{
    public class SellerBookController : Controller
    {
        private WEBTPContext db = new WEBTPContext();
        // GET: BookSellerController
        public ActionResult Index()
        {
            TestSession();

            if (Session["idConnect"] != null)
            {
                long id = (long)Session["idConnect"];

                User user = db.Users.Find(id);

                var books = from b in db.Books.Where(b => b.IdUser == user.IdUser)
                            select b;

                return View(books.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }

        protected ActionResult TestSession()
        {

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