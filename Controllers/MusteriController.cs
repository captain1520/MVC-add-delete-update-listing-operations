using Eticaret.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaret.Controllers
{
    public class MusteriController : Controller
    {
        MvcEticaretEntities1 db = new MvcEticaretEntities1();
        // GET: Musteri
        public ActionResult Musteriler(string p, int sayfa=1)
        {
            var degerler = from d in db.TBLMUSTERİLER select d;
            
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList().ToPagedList(sayfa, 10));
            //var musteriler = db.TBLMUSTERİLER.ToList().
            //return View(musteriler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERİLER m1)
        {
            if (!ModelState.IsValid)
            {
                return View("Musteriler");
            }
            db.TBLMUSTERİLER.Add(m1);
            db.SaveChanges();
            return View();
          
        }
        public ActionResult SIL (int id)
        {
            var musteri = db.TBLMUSTERİLER.Find(id);
            db.TBLMUSTERİLER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Musteriler");
        }
        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.TBLMUSTERİLER.Find(id);
            return View("MusteriGetir", musteri);
        }
        public ActionResult Guncelle (TBLMUSTERİLER p1)
        {
            var musteri = db.TBLMUSTERİLER.Find(p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Musteriler");
        }
    }
}