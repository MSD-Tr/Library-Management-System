using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System.Models.Entity;

namespace Library_Management_System.Controllers
{
    public class MovementController : Controller
    {
        devrimme_nurEntities1 db = new devrimme_nurEntities1();
        // GET: Movement
        public ActionResult Entrust()
        {
            return View();
        }
    }
}