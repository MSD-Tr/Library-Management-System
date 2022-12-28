using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System.Models.Entity;
using Library_Management_System.Models.Siniflarim;

namespace Library_Management_System.Controllers
{
    public class ShowroomController : Controller
    {
        // GET: Showroom
        devrimme_nurEntities db = new devrimme_nurEntities();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.Book.ToList();
            cs.Deger2 = db.About.ToList();
            //var degerler = db.Book.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(Contact c)
        {
            db.Contact.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}