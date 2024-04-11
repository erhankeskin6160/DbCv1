using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbCv1.Models.Entity;
using DbCv1.Repositories;

namespace DbCv1.Controllers
{
    public class SertifikaController : Controller
    {
        GenericRepository<TblSertfikalarım> repo = new GenericRepository<TblSertfikalarım>();
        DbCvEntities2 db = new DbCvEntities2();
        
        
        // GET: Sertifika
        public ActionResult Index()
        {
            var sertfika = repo.List();
            return View(sertfika);
        }
        [HttpGet]
        public ActionResult SertifikaEkle() 
        {

            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(TblSertfikalarım ekle)
        {

            repo.TAdd(ekle);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SertifikaDüzenle(int id) 
        {
            var sertifaduzenle = repo.Find(x => x.Id == id);
            return View(sertifaduzenle);

        }

        [HttpPost]
        public ActionResult SertifikaDüzenle(TblSertfikalarım sertifika) 
        
        {
            var t = repo.Find(x => x.Id == sertifika.Id);
            t.Aciklama = sertifika.Aciklama;
            t.Tarih = sertifika.Tarih;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id) 
        {
            var sertıfıkasıl = repo.Find(x => x.Id == id);
            repo.TDelete(sertıfıkasıl);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaGetir(int  id) 
        {
            var sertıfıkagetir = repo.Find(x => x.Id == id);
            ViewBag.d = id;

            return View();
        }

        [HttpPost]
        public ActionResult SertifikaGetir(TblSertfikalarım t)
        {
            var sertika = repo.Find(x => x.Id == t.Id);
            sertika.Aciklama = t.Aciklama;
            sertika.Tarih = t.Tarih;
            repo.TUpdate(sertika);
            return RedirectToAction("Index");
        }
    }
}