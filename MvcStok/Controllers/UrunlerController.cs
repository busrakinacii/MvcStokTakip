using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var deger = db.TBLURUNLER.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger = (from i in db.TBLKATEGORILER.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.KATEGORIAD,
                                              Value = i.KATEGORIID.ToString()

                                          }).ToList();
            ViewBag.dgr = deger;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER urun)
        {
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == urun.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            urun.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var urunsil = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urunsil);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}