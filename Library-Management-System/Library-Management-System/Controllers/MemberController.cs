using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System.Models.Entity;


namespace Library_Management_System.Controllers
{
    public class MemberController : Controller
    {
        devrimme_senaEntities db = new devrimme_senaEntities();
        // GET: Member
        public ActionResult Index()
        {
            var degerler = db.Member.ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult AddMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMember(Member p)
        {
            if (!ModelState.IsValid) //eğer boşsa bunu yapıyor.
            {
                return View("AddMember");
            }
            db.Member.Add(p);//sağlandıysa bu işlemler gerçekleştirsin.
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteMember(int id) 
        {
            var uye = db.Member.Find(id);
            db.Member.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringMember(int id)
        {
            var uye = db.Member.Find(id);
            return View("BringMember", uye);
        }
        public ActionResult UpdateMember(Member p)
        {
            var uye = db.Member.Find(p.Id);
            uye.Name = p.Name;
            uye.Surname = p.Surname;
            uye.Mail = p.Mail;
            uye.UserName = p.UserName;
            uye.Password = p.Password;
            uye.School = p.School;
            uye.Telephone = p.Telephone;
            uye.Photograph = p.Photograph;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MemberBookHistory(int id)
        {
            var bookhistory = db.Movement.Where(x => x.Member_Id == id).ToList();//sadece o üyeye ait olanı alır id sine göre aldığı için.
            var memberBook = db.Member.Where(y => y.Id == id).Select(z => z.Name + " " + z.Surname).FirstOrDefault();
            ViewBag.u1 = memberBook;
            return View(bookhistory);

        }
    }

}
