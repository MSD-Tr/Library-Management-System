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
        devrimme_nurEntities db = new devrimme_nurEntities();

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
            if (!ModelState.IsValid)
            {
                return View("AuthorAdd");
            }
            db.Author.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult AuthorDelete(int id)
        {
            var author = db.Author.Find(id);
            db.Author.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AuthorBring(int id)
        {
            var author = db.Author.Find(id);
            return View("AuthorBring", author);
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
        public ActionResult AuthorBook(int id)
        {
            var author = db.Book.Where(x => x.Author_Id == id).ToList();
            var authorname = db.Author.Where(x => x.ID == id).Select(z => z.NAME + " " + z.SURNAME).FirstOrDefault();
            ViewBag.name = authorname;
            return View(author);
        }
    }
}