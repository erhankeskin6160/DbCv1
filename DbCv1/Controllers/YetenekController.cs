using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbCv1.Models.Entity;
using DbCv1.Repositories;


namespace DbCv1.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        
        GenericRepository<TblYetenekler> repo = new GenericRepository<TblYetenekler>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenekEkle() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenekEkle(TblYetenekler y) 
        {
            repo.TAdd(y);
           return  RedirectToAction("Index");
            
        }
        public ActionResult YetenekSil(int id) 
        {
            var yetenek = repo.Find(x => x.Id == id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDüzenle(int id) 
        {
            var yetenek = repo.Find(x => x.Id == id);

            return View(yetenek);
        }
        [HttpPost]
        public ActionResult YetenekDüzenle(TblYetenekler t)
        {
            var y = repo.Find(x => x.Id == t.Id);
            y.Yetenekler = t.Yetenekler;
            y.Oran = t.Oran;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}