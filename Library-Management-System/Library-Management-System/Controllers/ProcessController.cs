using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using System.Web;
using System.Web.Mvc;
using Library_Management_System.Models.Entity;

namespace Library_Management_System.Controllers
{
    public class ProcessController : Controller
    {
        // GET: Process
        devrimme_nurEntities db = new devrimme_nurEntities();
        public ActionResult Index()
        {
            var degerler = db.Movement.Where(x => x.MovementStatus == true)
            .ToList();
            return View(degerler);
        }
    }
}