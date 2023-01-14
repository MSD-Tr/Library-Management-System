using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System.Models.Entity;
using System.Web.Security;//bu kütüphane de yeni tanımlandı
using Library_Management_System.Models.Dto;

namespace Library_Management_System.Controllers
{
    [AllowAnonymous]//bu komutla global daki yaptığın işlem ile birlikte giriş yapma işlemi muaf tutulacak.
    public class LoginController : Controller
    {
        // GET: Login
        devrimme_senaEntities db = new devrimme_senaEntities();
       
        public ActionResult LogIn()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(Member p)//giriş işleminde kullanıcı adı ve şifreyi kontrol ediyor.
        {
            var informations = db.Member.FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);
            if (informations != null) //gelen değerler boş değilse
            {
                FormsAuthentication.SetAuthCookie(informations.Mail, false);
                //login de giriş yaparken sql deki adı paneldeki ad a taşımak için viewbag gibi bu kullanılır.
                Session["Mail"]=informations.Mail.ToString();
                return RedirectToAction("Index", "MyPanel");
            }
            else
            {

                LoginDto loginDto = new LoginDto { IsSuccess = false };
                return View(loginDto);
               
            }
            
        }
    }
}