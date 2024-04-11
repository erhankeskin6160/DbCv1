using DbCv1.Models.Entity;
using DbCv1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DbCv1.Controllers
{
    public class EğitimController : Controller
    {
        GenericRepository<TblEğitimlerim> repo = new GenericRepository<TblEğitimlerim>();
        // GET: Eğitim
        public ActionResult Index()
        {
            var eğitimlerim = repo.List();
            return View(eğitimlerim);
        }
        [HttpGet]
        public ActionResult EğitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EğitimEkle(TblEğitimlerim e) 
        {
            if (!ModelState.IsValid)
            {
                return View("EğitimEkle");
            }
            repo.TAdd(e);
            return RedirectToAction("Index");
        }
        public ActionResult EğitimSil(int id) 
        {
            var eğtim = repo.Find(x => x.Id == id);
            repo.TDelete(eğtim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EğitimDüzenle(int id) 
        {
            var eğitim = repo.Find(x => x.Id == id);
            return View(eğitim);
        }
        [HttpPost]
        public ActionResult EğitimDüzenle(TblEğitimlerim e) 
        {
            if (!ModelState.IsValid)
            {
                return View("EğitimDüzenle");
            }
            var eğitim = repo.Find(x => x.Id == e.Id);
            eğitim.Baslık = e.Baslık;
            eğitim.AltBaslık = e.AltBaslık;
            eğitim.AltBaslık2 = e.AltBaslık2;
            eğitim.Tarih = e.Tarih;
            eğitim.GNO = e.GNO;
            repo.TUpdate(eğitim);
            return RedirectToAction("Index");
        
        }
    }
}