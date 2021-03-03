using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WEBTP.Data;
using WEBTP.Entities;

namespace WEBTP.Controllers
{

    public class AccountController : Controller
    {
        private WEBTPContext db = new WEBTPContext();        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string mail, string password)
        {
            //username.Equals("acc1") && password.Equals("123")
            //A la premiere connexion 
            //SELECT * From User WHERE Mail= mail AND PassWord = password
            var users = from u in db.Users.Where(u => u.Mail == mail)
                        select u;

            if (!String.IsNullOrEmpty(mail) && !String.IsNullOrEmpty(password))
            {
                users = users.Where(u => u.Mail.Contains(mail) && u.PassWord.Contains(password));

                long idUserConnect = (from u in db.Users.Where(u => u.Mail == mail)
                                      select u.IdUser).Single();

                if (idUserConnect != 0)
                {
                    Session["idConnect"] = idUserConnect;

                    ViewBag.error = "Connected";

                    return RedirectToAction("Index", "Books");

                }
                else
                {
                    ViewBag.error = "Invalid Account un";

                    return View("Index");
                }
            }
            else
            {
                ViewBag.error = "Invalid Account deux";

                return View("Index");
            }
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove("username");
            return RedirectToAction("Index", "home");           

        }

    }
}