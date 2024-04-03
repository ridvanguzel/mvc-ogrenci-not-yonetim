using mvc_ogrenci_not_yonetim.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_ogrenci_not_yonetim.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        RG_MVCOGRENCIYONETIMEntities1 db = new RG_MVCOGRENCIYONETIMEntities1(); // burada bu kodu yazdık çünkü public olarak her action resultta kullanmak için.
        public ActionResult Kulupler()
        {
            var modal = db.TBL_KULUP.ToList();
            return View(modal);
        }

        //EKLEME İŞLEMİ BAŞLIYOR

        [HttpGet]
        public ActionResult YeniKulupEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulupEkle(TBL_KULUP k1) {

            db.TBL_KULUP.Add(k1); // Yenikulupekle sayfasından gelen parametre değeri
            db.SaveChanges();
            return View();}
        //EKLEME İŞLEMİ BİTİYOR


        //SİLME İŞLEMİ
        public ActionResult KulupSil(int Id) // int türünde bir değişken tanımladık
        {
            var kulupsil = db.TBL_KULUP.Find(Id);
            db.TBL_KULUP.Remove(kulupsil);
            db.SaveChanges();
            return RedirectToAction("Kulupler");

        }
        //GUNCELLEME İŞLEMİ

        public ActionResult KulupGetir(int id)
        {

            var kulupgetir = db.TBL_KULUP.Find(id); // KulupGetir sayfasına tıkladıgımızda idsien göre  bize kulubu sayfaya getirecek.
            return View("KulupGetir", kulupgetir);
        }

        [HttpPost]
        public ActionResult KulupGuncelle(TBL_KULUP g1) // dışarıdan g1 adında kulupten türüyen bir parametre göndeririz.
        {
            var kulupguncelle = db.TBL_KULUP.Find(g1.KULUPID);
            kulupguncelle.KULUPAD = g1.KULUPAD; // Kulup güncelle parametresıne tbl_kulup tablosundan gelen idyi atadık.
            //butona bastıgımızda kulupguncelleye atadıgımız var olan değer tbl_kulup1 değeri ile ddeğişecek

            db.SaveChanges();
            return RedirectToAction("Kulupler", "Kulupler");
        }
    }
}