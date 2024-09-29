using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var deger = db.TBLKATEGORILER.ToList();
            var deger = db.TBLKATEGORILER.ToList().ToPagedList(sayfa, 4);
            return View(deger);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER p1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ktgrsil = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(ktgrsil);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORILER.Find(id);
            return View("KategoriGetir",ktgr);
        }

        public ActionResult Guncel(TBLKATEGORILER a1)
        {
            var ktg = db.TBLKATEGORILER.Find(a1.KATEGORIID);
            ktg.KATEGORIAD= a1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}