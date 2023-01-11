using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System.Models.Entity; //oluşturduğun projeyi model ile birlikte yani sql de oluşturduğun tabloları proje ile birleştirmek için yazılır. ve her controller de yaz.
                                               //MODELİN İÇERİSİNDE BULUNAN DEĞERLERE ULAŞMAKTIR
namespace Library_Management_System.Controllers
{
    public class CategoryController : Controller
    {
        devrimme_senaEntities db=new devrimme_senaEntities();//bağlantı sağlanması için yazılır.
        // GET: Category
        public ActionResult Index()
        {

            var degerler = db.Category.Where(x=>x.Status==true).ToList();
            return View(degerler);
        }
        [HttpGet]//refresh 
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p ) //parametre tanımlanmasının sebebi kategori tablosundan alsın p ye atsın.
        {
            db.Category.Add(p);// kategori tablosuna eklesin kategoriye eklenen değerleri
            db.SaveChanges();
            return RedirectToAction("Index");//ne yazdıysan sadece onu gösterir.
        }
        public ActionResult DeleteCategory(int id) //parametre id olacak çünkü id ye göre silme işlemi gerçekleştirecek.
        {
            var category = db.Category.Find(id);//find bul demek.
            //db.Category.Remove(category); 
            category.Status=false;//sadece id ye göre gelen durumu false yapıcak. eğer kitap false ise silecek.yani kitap sile basınca silinmeyecek false düşecek. sql de kontrol et false a düşüyor.
            db.SaveChanges();
            return RedirectToAction("Index");//BAŞKA SAYFAYA YÖNLENDİRİR.
        }
        public ActionResult BringCategory(int id) //id ye göre parametre getirecek.
        {
            var ktg = db.Category.Find(id);
            return View("BringCategory", ktg);
        }
        public ActionResult UpdateCategory (Category p )
        {
            var ktg = db.Category.Find(p.Id);
            ktg.Name=p.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}