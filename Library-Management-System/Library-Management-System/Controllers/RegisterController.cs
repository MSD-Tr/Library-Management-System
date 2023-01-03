using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System.Models.Entity;
using Microsoft.Ajax.Utilities;

namespace Library_Management_System.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        devrimme_nurEntities db = new devrimme_nurEntities();
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Members m)
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }
            db.Members.Add(m);
            db.SaveChanges();
            return View();
        }
    }
}