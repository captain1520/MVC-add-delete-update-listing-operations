using Eticaret.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaret.Controllers
{
    public class SatisController : Controller
    {
        MvcEticaretEntities1 db = new MvcEticaretEntities1();
        // GET: Satis
        public ActionResult Satis()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR p)
        {
            db.TBLSATISLAR.Add(p);
            db.SaveChanges();
            return View("Satis");
        }

        [HttpPost]
        public ActionResult Listele(int sayfa = 1)
        {
            var satis = db.TBLSATISLAR.ToList().ToPagedList(sayfa, 10);
            return View(satis);
        } 




    }
}