using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System.Models.Entity;

namespace Library_Management_System.Controllers
{
    public class AuthorController : Controller
    {
        devrimme_nurEntities1 db = new devrimme_nurEntities1();
        // GET: Author
        public ActionResult Index()
        {
            var degerler = db.Author.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult AuthorAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorAdd(Author p)
        {
            db.Author.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AuthorDelete(int id)
        {
            var author=db.Author.Find(id);
            db.Author.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AuthorBring(int id)
        {
            var author = db.Author.Find(id);
            return View("AuthorBring",author);
        }
        public ActionResult AuthorUpdate(Author P)
        {
            var author = db.Author.Find(P.ID);
            author.NAME = P.NAME;
            author.SURNAME = P.SURNAME;
            author.DETAILS = P.DETAILS;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}