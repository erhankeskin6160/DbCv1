using DbCv1.Models.Entity;
using DbCv1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DbCv1.Controllers
{
    public class DeneyimController : Controller
    {
        DbCv1.Repositories.DeneyimRepository repo = new Repositories.DeneyimRepository();
         
        [AllowAnonymous]
        // GET: Deneyim
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        public ActionResult DeneyimEkle() 
        {

            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimler p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id) 
        {
            TblDeneyimler t = repo.Find(x => x.Id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
         public ActionResult DeneyimGetir(int id) 
        {
            TblDeneyimler t = repo.Find(x => x.Id == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(TblDeneyimler p)
        {

           
                 TblDeneyimler t = repo.Find(x => x.Id == p.Id);
            t.Baslık = p.Baslık;
            t.Alt_Baslık = p.Alt_Baslık;
            t.Tarih = p.Tarih;
            t.Aciklama = p.Aciklama;
            repo.TUpdate(t);
           
          
            
             
            
            return RedirectToAction("Index");
        }
    }
}