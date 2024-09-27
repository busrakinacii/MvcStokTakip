using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class MusterilerController : Controller
    {
        // GET: Musteriler
        MvcDbStokEntities db=new MvcDbStokEntities();
        public ActionResult Index()
        {
            var deger = db.TBLMUSTERILER.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER mus)
        {
            db.TBLMUSTERILER.Add(mus);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Sil(int id)
        {
            var mstr = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(mstr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            //id Taşıma İşlemi İçin Bir ActionResult
            var mustr = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", mustr);
        }

        public ActionResult Guncell(TBLMUSTERILER m1)
        {
            //Güncelleme Yapmak İçin Bir Action Result
            var musterı = db.TBLMUSTERILER.Find(m1.MUSTERIID);
            musterı.MUSTERIAD = m1.MUSTERIAD;
            musterı.MUSTERISOYAD = m1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}