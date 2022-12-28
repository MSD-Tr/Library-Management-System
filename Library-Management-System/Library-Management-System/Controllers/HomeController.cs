using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System.Models.Entity;


namespace Library_Management_System.Controllers
{
    //ActionResult backend tarafındaki aksiyonları views(sayfa) kısmına kazandırmak için kullanılır.her biri birer methodu(işlem)temsil eder.
    public class HomeController : Controller
    {
        devrimme_nurEntities db = new devrimme_nurEntities();
        // GET: Home
        public ActionResult Index()
        {
            var degerler = db.Categories.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Categories p)
        {
            db.Categories.Add(p);
            db.SaveChanges();
            return View();

        }
    }
}