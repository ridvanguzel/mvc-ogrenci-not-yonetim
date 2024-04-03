using mvc_ogrenci_not_yonetim.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}