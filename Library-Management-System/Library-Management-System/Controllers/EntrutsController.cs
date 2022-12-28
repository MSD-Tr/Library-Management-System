using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System.Models.Entity;
namespace Library_Management_System.Controllers
{
    public class EntrutsController : Controller
    {
        // GET: Entruts
        devrimme_nurEntities db = new devrimme_nurEntities();
        public ActionResult Index()
        {
            var degerler = db.Movement.Where(x => x.MovementStatus == false)
              .ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Entrustt()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Entrustt(Movement p)//var olan kitabın kime verildiği
        {
            db.Movement.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult EntrustReturn(int id)// ödünç iade al kısmı
        {
            var odn = db.Movement.Find(id);
            return View("EntrustReturn", odn);
        }
        public ActionResult EntrustUpdate(Movement p)
        {
            var odn = db.Movement.Find(p.Id);
            odn.MemberBringDate = p.MemberBringDate;//üyenin getirdiği tarih
            odn.MovementStatus = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}