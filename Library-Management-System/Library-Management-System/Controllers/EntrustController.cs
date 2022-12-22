using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System.Models.Entity;
namespace Library_Management_System.Controllers
{
    public class LoanedController : Controller
    {
        // GET: Loaned
        devrimme_nurEntities1 db = new devrimme_nurEntities1();
        public ActionResult Index()//kütüphaneden ödünç alınacak hareket tablosuna eklenecek.
        {
           
            return View();
        }
      
        public ActionResult entrust()//kütüphaneden ödünç verilecek hareket tablosuna eklenecek.
        {
            return View();
        }
        
    }
}