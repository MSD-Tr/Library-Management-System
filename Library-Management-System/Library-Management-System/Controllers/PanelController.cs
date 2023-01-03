using Library_Management_System.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System.Models.Entity;

namespace Library_Management_System.Controllers
{
    public class PanelController : Controller
    {
        devrimme_nurEntities db = new devrimme_nurEntities();
        // GET: Panel

        [HttpGet]
        [Authorize]
        public ActionResult Index()//Kullanıcı mail ve şifre tutar
        {
            var mail = (String)Session["Mail"];
            var deger = db.Members.FirstOrDefault(x => x.Mail == mail);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Index2(Members p)//kullanıcı bilgilerini günceller.
        {
            var user = (string)Session["Mail"];
            var member = db.Members.FirstOrDefault(x => x.Mail == user);
            member.Password = p.Password;
            member.Name = p.Name;
            member.Surname = p.Surname;
            member.Password = p.Password;
            member.School = p.School;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Books()//Var olan kullanıcıya ait okunmuş kitap listesini tutuyor.
        {
            var user = (string)Session["Mail"];
            var id = db.Members.Where(x => x.Mail == user.ToString()).Select(z => z.Id).FirstOrDefault();
            var deger = db.Movement.Where(x => x.Member_ıd ==id).ToList();
            return View(deger);

        }
    }
}