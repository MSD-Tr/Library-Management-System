using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System.Models.Entity;



namespace Library_Management_System.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        devrimme_nurEntities db = new devrimme_nurEntities();
        public ActionResult Index()
        {
            var deger1 = db.Members.Count();
            var deger2 = db.Book.Count();
            var deger3 = db.Book.Where(x => x.Status == false).Count();
            var deger4 = db.Punishment.Sum(x => x.Money);
            ViewBag.Deger1 = deger1;
            ViewBag.Deger2 = deger2;
            ViewBag.Deger3 = deger3;
            ViewBag.Deger4 = deger4;
            return View();
        }
        public ActionResult Weather()
        {
            return View();
        }
        public ActionResult WeatherCard()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PictureAdd(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }
            return RedirectToAction("Gallery");

        }
        public ActionResult LinqCard()
        {
            var deger1 = db.Book.Count();
            var deger2 = db.Members.Count();
            var deger3 = db.Punishment.Sum(x => x.Money);
            var deger4 = db.Book.Where(x => x.Status == false).Count();//kitaplar tablosunda durumu false olan kitapları getirir.
            var deger5 = db.Categories.Count();
            var deger11 = db.Contact.Count();
            var deger8 = db.MaxBookAuthor().FirstOrDefault();//Var olan prosedürü getirir.
            var deger9 = db.Book.GroupBy(x => x.Publısher).OrderByDescending(z => z.Count()).Select(y => new { y.Key }).FirstOrDefault();//prosedür kullanmadan linq sorgusuyla istenilen değere ulaşır.
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr5 = deger5;
            ViewBag.dgr8 = deger8;
            ViewBag.dgr9 = deger9;
            ViewBag.dgr11 = deger11;
            return View();
        }

    }
}
