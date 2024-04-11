using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbCv1.Models.Entity;
using DbCv1.Repositories;

namespace DbCv1.Controllers
{
     
    public class AdminController : Controller
    {
        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();
        // GET: Admin
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }
        [HttpGet]
        public ActionResult AdminEkle() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(TblAdmin admin)
        {
            repo.TAdd(admin);
             
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminDüzenle(int id)
        {
            var admindüzenle = repo.Find(x => x.Id == id);
            return View(admindüzenle);
        }
        [HttpPost]
        public ActionResult AdminDüzenle(TblAdmin admin)
        {

            var admindüzenle = repo.Find(x => x.Id == admin.Id);
            admindüzenle.KullaniciAdi = admin.KullaniciAdi;
            admindüzenle.Sifre = admin.Sifre;
            repo.TUpdate(admindüzenle);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminSil(int id)
        {
            var admindüzenle = repo.Find(x => x.Id == id);
            repo.TDelete(admindüzenle);
            return RedirectToAction("Index");
        }
         
    }
}