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
            return View();

        }
    }
}