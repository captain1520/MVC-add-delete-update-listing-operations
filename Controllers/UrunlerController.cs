using Eticaret.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaret.Controllers
{
    public class UrunlerController : Controller
    {
        MvcEticaretEntities1 db = new MvcEticaretEntities1();
        // GET: Urunler
        public ActionResult Urunler(int sayfa=1)
        {
            var urunler = db.TBLURUNLER.ToList().ToPagedList(sayfa,10);
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORİLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                           }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER u1)
        {
            var ktg = db.TBLKATEGORİLER.Where(m => m.KATEGORIID == u1.TBLKATEGORİLER.KATEGORIID).FirstOrDefault();
            u1.TBLKATEGORİLER = ktg;
            db.TBLURUNLER.Add(u1);
            db.SaveChanges();
            return RedirectToAction("Urunler");
            
        }
        public ActionResult SIL(int id)
        {
            var urunler = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urunler);
            db.SaveChanges();
            return RedirectToAction("Urunler");
        }
        public ActionResult UrunGetir (int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKATEGORİLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir", urun);
        }
        public ActionResult Guncelle(TBLURUNLER p1)
        {
            var urun = db.TBLURUNLER.Find(p1.URUNID);
            urun.URUNAD = p1.URUNAD;
            urun.MARKA = p1.MARKA;
            urun.STOK = p1.STOK;
            urun.FIYAT = p1.FIYAT;
            //urun.URUNKATEGORI = p1.URUNKATEGORI;
            var ktg = db.TBLKATEGORİLER.Where(m => m.KATEGORIID == p1.TBLKATEGORİLER.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Urunler");

        }
    }
}