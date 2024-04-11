using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbCv1.Models.Entity;
using DbCv1.Repositories;

namespace DbCv1.Controllers
{
    public class SosyalMedyaController : Controller
    {
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();
        
        // GET: SosyalMedya
        public ActionResult Index()
        {
            var sosyalmedya = repo.List();
            return View(sosyalmedya);
        }
        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya t) 
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
            
        }
        public ActionResult SosyalMedyaDüzenle(int id) 
        {
            var hesap = repo.Find(x => x.ID == id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult SosyalMedyaDüzenle(TblSosyalMedya t)
        {
            var hesap = repo.Find(x => x.ID == t.ID);
            hesap.Durum = true;
            hesap.Ad = t.Ad;
            hesap.Link = t.Link;
            hesap.Icon = t.Icon;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id) 
        {
            var hesap = repo.Find(x => x.ID == id);
            hesap.Durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}