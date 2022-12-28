using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace Library_Management_System.Controllers
{
    public class MembersController : Controller
    {
        devrimme_nurEntities db = new devrimme_nurEntities();
        // GET: Members
        public ActionResult Index(int page = 1)
        {
            //var degerler = db.Members.ToList();
            var degerler = db.Members.ToList().ToPagedList(page, 3);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult MembersAdd()
        {

            return View();
        }
        [HttpPost]
        public ActionResult MembersAdd(Members p)
        {
            if (!ModelState.IsValid)
            {
                return View("MembersAdd");
            }
            db.Members.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MembersDelete(int id)
        {
            var members = db.Members.Find(id);
            db.Members.Remove(members);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MembersBring(int id)
        {
            var members = db.Members.Find(id);
            return View("MembersBring", members);

        }

        public ActionResult MembersUpdate(Members p)
        {
            var members = db.Members.Find(p.Id);
            members.Name = p.Name;
            members.Surname = p.Surname;
            members.Mail = p.Mail;
            members.UserName = p.UserName;
            members.Password = p.Password;
            members.School = p.School;
            members.PhoneNumber = p.PhoneNumber;
            members.Photography = p.Photography;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
