using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Library_Management_System.Models.Entity;

namespace Library_Management_System.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        devrimme_nurEntities1 db = new devrimme_nurEntities1();
        public ActionResult Index()
        {
        var deger=db.Empyloyees.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult EmployeeAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeAdd(Empyloyees p)
        {
            if (!ModelState.IsValid)//Eğer geçerli değilse.Şart sağlanamadıysa.
            {
                return View("EmployeeAdd");
            }
            db.Empyloyees.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeDelete(int id)
        {
            var degerler = db.Empyloyees.Find(id);
            db.Empyloyees.Remove(degerler);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public ActionResult EmployeeBring(int id)
        {
            var prs = db.Empyloyees.Find(id);
            return View("EmployeeBring", prs);
        }
        public ActionResult EmployeeUpdate(Empyloyees p )
        {
            var prs = db.Empyloyees.Find(p.Id);
            prs.Employee = p.Employee;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}