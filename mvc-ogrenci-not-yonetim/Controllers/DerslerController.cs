
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_ogrenci_not_yonetim.Models.EntityFramework;
namespace mvc_ogrenci_not_yonetim.Controllers
{
    public class DerslerController : Controller
    {
        // GET: Dersler
        RG_MVCOGRENCIYONETIMEntities1 db = new RG_MVCOGRENCIYONETIMEntities1(); // burada bu kodu yazdık çünkü public olarak her action resultta kullanmak için.
    
        public ActionResult Dersler()
        {
            var dersler = db.TBL_DERSLER.ToList();
            return View(dersler);
        }

        //BU BİR EKLEME İŞLEMİDİR
        [HttpGet] // sayfa yüklendıgınde çalışacak olan deeğer

        public ActionResult YeniDersEkle()
        {
            return View();
        }

        //BU BİR EKLEME İŞLEMİDİR
        [HttpPost] // bir değer göndermek istedigimizde burası çalışacak
        public ActionResult YeniDersEkle(TBL_DERSLER d1)
        {
            db.TBL_DERSLER.Add(d1); // Paramatreden gelen değeri ekle. bu deger nereden gelıyor yeni ders ekle sayfasından.
            db.SaveChanges();
            return View();
        }

        //SİLME İŞLEMİ

        public ActionResult DersSil(int id)


        {
            var dersler = db.TBL_DERSLER.Find(id);
            db.TBL_DERSLER.Remove(dersler);
            db.SaveChanges();
            return RedirectToAction("Dersler");
        }

        //Guncelleme İşlemi

        public ActionResult DersGetir(int id)
        {
            var dersgetir = db.TBL_DERSLER.Find(id);
            return View("DersGetir", dersgetir);
        }

        public ActionResult DersGuncelle(TBL_DERSLER d1)
        {
            var dersguncelle = db.TBL_DERSLER.Find(d1.DERSID);
            dersguncelle.DERSAD = d1.DERSAD; // BİRTANESI VERİTABANINDAKİ ALAN, BİRTANESI GÖNDERECEĞİMİZ ALAN
            db.SaveChanges();
            return RedirectToAction("Dersler", "Dersler");
        }
    }
}