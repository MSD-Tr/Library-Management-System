using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Library_Management_System.Models.Entity;

namespace Library_Management_System.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        devrimme_nurEntities1 db = new devrimme_nurEntities1();
        public ActionResult Index()
        {
            var book = db.Book.ToList();
            return View(book);
        }
        [HttpGet]
        public ActionResult BookAdd()
        {
            List<SelectListItem> deger1 = (from i in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.Author.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.NAME + ' ' + i.SURNAME,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View();
        }
        [HttpPost]
        public ActionResult BookAdd(Book p)
        {
            var ktg = db.Categories.Where(k => k.Id == p.Categories.Id).FirstOrDefault();
            var yzr = db.Author.Where(y => y.ID == p.Author.ID).FirstOrDefault();
            p.Categories = ktg;
            p.Author = yzr;
            db.Book.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BookDelete(int id)
        {
            var book=db.Book.Find(id);
            db.Book.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult BookBring(int id)
        {
            var ktp = db.Book.Find(id);
            return View("BookBring", ktp);

        }
    }
}