using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        SchoolEntities db = new SchoolEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(user objchk)
        {

            if (ModelState.IsValid)
            {
                using (SchoolEntities db = new SchoolEntities())
                {
                    var obj = db.users.Where(a => a.UserName.Equals(objchk.UserName) && a.Password.Equals(objchk.Password)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The UserName or Password");

                    }

                }

            }

            return View(objchk);
        }

        public ActionResult Logout()
        {

            Session.Clear();
            return RedirectToAction("Index", "Login");
        }

    }
}