using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBTP.Data;
using WEBTP.Entities;

namespace WEBTP.Controllers
{


    public class HomeController : Controller
    {

        private WEBTPContext db = new WEBTPContext();


        public ActionResult Index()
        {
            TestSession();




            return View();

        }

        public ActionResult About()
        {
            TestSession();
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            TestSession();
            ViewBag.Message = "Your contact page.";

            return View();
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
