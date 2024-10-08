﻿using MvcStok.Models.Entity;
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
        public ActionResult Index(string p)
        {
            var degerler = from x in db.TBLMUSTERILER select x;
            if (!string.IsNullOrEmpty(p))
            {
                degerler=degerler.Where(a=>a.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
            //var deger = db.TBLMUSTERILER.ToList();
            //return View(deger);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER mus)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILER.Add(mus);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Sil(int a)
        {
            var mstr = db.TBLMUSTERILER.Find(a);
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