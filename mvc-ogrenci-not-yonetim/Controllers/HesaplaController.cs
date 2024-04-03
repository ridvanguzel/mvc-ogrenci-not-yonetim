using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_ogrenci_not_yonetim.Controllers
{
    public class HesaplaController : Controller
    {
        // GET: Hesapla
        public ActionResult HesapMakinesi(int sayi1 = 0, int sayi2 = 0)
        {
            var sonuc = sayi1 + sayi2;
            ViewBag.snc = sonuc;
            return View();
        }
    }
}