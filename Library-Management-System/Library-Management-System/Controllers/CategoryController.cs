using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System.Models.Entity;

namespace Library_Management_System.Controllers
{
    public class CategoryController : Controller
    {
        devrimme_nurEntities1 db = new devrimme_nurEntities1();
        // GET: Category
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
        public ActionResult CategoryDelete(int id)
        {
           var category = db.Categories.Find(id);
           db.Categories.Remove(category);
            db.SaveChanges();
           return RedirectToAction("Index");
        }
        public ActionResult CategoryBring(int id)
        {
            var category = db.Categories.Find(id);
            return View("CategoryBring", category);

        }
        public ActionResult CategoryUpdate(Categories p)
        {
            var category = db.Categories.Find(p.Id);
            category.Name = p.Name;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}