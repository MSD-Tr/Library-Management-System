using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Library_Management_System.Models.Entity;

namespace Library_Management_System.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        devrimme_nurEntities db = new devrimme_nurEntities();



        public ActionResult Loginn()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Loginn(Members m)
        {
            var deger = db.Members.FirstOrDefault(x => x.Mail == m.Mail && x.Password == m.Password);
            // TempData Controller kısmındaki verileri Vies Kısmına Taşımak amaçlı kullanılır
            if (deger != null)
            {
                FormsAuthentication.SetAuthCookie(deger.Mail, false); //var olan form yetkilendirmesi.
                Session["Mail"] = deger.Mail.ToString();
                //TempData["a"] = deger.Name.ToString();
                //TempData["b"] = deger.Surname.ToString();
                //TempData["c"] = deger.UserName.ToString();
                //TempData["d"] = deger.Password.ToString();
                //TempData["e"] = deger.PhoneNumber.ToString();
                //TempData["f"] = deger.School.ToString();

                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }

        }
    }
}