using mvc_ogrenci_not_yonetim.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_ogrenci_not_yonetim.Controllers
{
    public class OgrencilerController : Controller
    {
        // GET: Ogrenciler
        RG_MVCOGRENCIYONETIMEntities1 db = new RG_MVCOGRENCIYONETIMEntities1();
        public ActionResult Ogrenciler()
        {
            var modal = db.TBL_OGRENCILER.ToList();
            return View(modal);
        }
        [HttpGet]
        public ActionResult OgrenciEkle() { 
            

            //Burada ogrencı ekle sayfası açıldıgında httpget oldugunda sayfada gösterilecek olan verileri gösteririz
            //from i in db.TBL_OGRENCILER i değişken olarak konulur. nereden db.tblogrencıler tablosundan
            
            List<SelectListItem> klpdeger=(from i in db.TBL_KULUP.ToList()

                                           select new SelectListItem

                                           {
                                                Text= i.KULUPAD,
                                                Value = i.KULUPID.ToString()
                                            
                                            }).ToList();

            ViewBag.klpdeger = klpdeger;

            return View(); 
        
        }

        [HttpPost]
        //Burada ogrencı ekle sayfası açıldıgında httppost oldugunda çalışacak işlemler yer alır
        public ActionResult OgrenciEkle(TBL_OGRENCILER o1)
        {
            //seçmiş oldugumuz kulube dair atama yaparız 
            var klp = db.TBL_KULUP.Where(x => x.KULUPID == o1.TBL_KULUP.KULUPID).FirstOrDefault();
            o1.TBL_KULUP = klp;
            //seçmiş oldugumuz kulube dair atama yaparız 
            db.TBL_OGRENCILER.Add(o1);
            db.SaveChanges();
            return RedirectToAction("Ogrenciler", "Ogrenciler");
        }

        public ActionResult OgrenciSil(int id)
        {
            var ogrencisil = db.TBL_OGRENCILER.Find(id);
            db.TBL_OGRENCILER.Remove(ogrencisil);
            db.SaveChanges();
            return RedirectToAction("Ogrenciler");
        }

        public ActionResult OgrenciGetir(int id)
        {

            var ogrgetir = db.TBL_OGRENCILER.Find(id);
            return View("OgrenciGetir", ogrgetir);
        }

        public ActionResult OgrencıGuncelle(TBL_OGRENCILER o1) // TBL_OGRENCILERDEN BİR TANE PARAMETRE GÖNDERDİK.
        {
            var ogrenciguncelle = db.TBL_OGRENCILER.Find(o1.OGRID);
            ogrenciguncelle.OGRAD = o1.OGRAD; // bir tarnesi veritabanındaki alan bir tanesi değiştirdğimiz alan
            ogrenciguncelle.OGRSOYAD = o1.OGRSOYAD; // bir tarnesi veritabanındaki alan bir tanesi değiştirdğimiz alan
            ogrenciguncelle.OGRFOTOGRAF = o1.OGRFOTOGRAF; // bir tarnesi veritabanındaki alan bir tanesi değiştirdğimiz alan
            ogrenciguncelle.OGRCINSIYET = o1.OGRCINSIYET; // bir tarnesi veritabanındaki alan bir tanesi değiştirdğimiz alan
            ogrenciguncelle.OGRKULUP = o1.OGRKULUP; // bir tarnesi veritabanındaki alan bir tanesi değiştirdğimiz alan
            db.SaveChanges();
            return RedirectToAction("Ogrenciler", "Ogrenciler");
        }

    }
}