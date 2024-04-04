using mvc_ogrenci_not_yonetim.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_ogrenci_not_yonetim.Models;
using Antlr.Runtime;

namespace mvc_ogrenci_not_yonetim.Controllers
{
    public class NotlarController : Controller
    {
        // GET: Notlar
        RG_MVCOGRENCIYONETIMEntities1 db = new RG_MVCOGRENCIYONETIMEntities1();
        public ActionResult Notlar()
        {
            var modal = db.TBL_NOTLAR.ToList();
            return View(modal);
        }

        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(TBL_NOTLAR n1)
        {

            db.TBL_NOTLAR.Add(n1);
            db.SaveChanges();

            return RedirectToAction("Notlar");
        }

        public ActionResult NotGetir(int id)
        {

         


            var notgetir = db.TBL_NOTLAR.Find(id);
            return View("NotGetir", notgetir);
        }

        [HttpPost]
        public ActionResult NotGetir(Context Model, TBL_NOTLAR n1, int SINAV1=0, int SINAV2 = 0, int SINAV3 = 0, int PROJE = 0)
        {

            if(Model.islem == "HESAPLA")
            {
                int ORTALAMA = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
                ViewBag.ortalama = ORTALAMA;
            }
            if(Model.islem == "NOTGUNCELLE")
            {
                var notguncelle = db.TBL_NOTLAR.Find(n1.OGRID);
                notguncelle.SINAV1 = n1.SINAV1;
                notguncelle.SINAV2 = n1.SINAV2;
                notguncelle.SINAV3 = n1.SINAV3;
                notguncelle.PROJE = n1.PROJE;
                notguncelle.ORTALAMA = n1.ORTALAMA;
                db.SaveChanges();
                return RedirectToAction("Notlar", "Notlar");
            }



            return View();
        }
        
    }
}