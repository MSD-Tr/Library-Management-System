using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Library_Management_System.Models.Entity;

namespace Library_Management_System.Controllers
{
    public class MessagesController : Controller
    {
        devrimme_nurEntities db = new devrimme_nurEntities();
        // GET: Messages
        public ActionResult Index()
        {
            var mail = (string)Session["Mail"].ToString();
            var message = db.Messages.Where(x => x.Buyer == mail.ToString()).ToList();
            return View(message);
        }
  
        public ActionResult SentMessages()//giden mesajları tutar.
        {
            var mail = (string)Session["Mail"].ToString();
            var message = db.Messages.Where(x => x.Sender == mail.ToString()).ToList();
            return View(message);
        }   
        [HttpGet]
        public ActionResult NewMessages()//yeni mesaj sayfasını tutar.
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessages(Messages m)
        {
            var mail = (string)Session["Mail"].ToString();
            m.Sender = mail.ToString();
            m.Date = DateTime.Parse(DateTime.Now.ToShortTimeString());
            db.Messages.Add(m);
            db.SaveChanges();
            return RedirectToAction("SentMessages", "Messages");
        }
    }
}