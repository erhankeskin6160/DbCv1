using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbCv1.Models.Entity;
using DbCv1.Repositories;

namespace DbCv1.Controllers
{
   
    public class HakkımdaController : Controller
    {
        
        // GET: Hakkımda
        GenericRepository<TblHakkımda> repo = new GenericRepository<TblHakkımda>();
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var hakkında = repo.List();
            return View(hakkında);
        }

        [HttpPost]
        public ActionResult Index(TblHakkımda Hakkımda)
        {
           var tblHakkımda = repo.Find(x =>x.Id==1);
            tblHakkımda.Ad = Hakkımda.Ad;
            tblHakkımda.SoyAd = Hakkımda.SoyAd;
            tblHakkımda.Adres = Hakkımda.Adres;
            tblHakkımda.Mail = Hakkımda.Mail;
            tblHakkımda.Telefon = Hakkımda.Telefon;
            tblHakkımda.Aciklama = Hakkımda.Aciklama;
            tblHakkımda.Resim = Hakkımda.Resim;
            repo.TUpdate(tblHakkımda);

            return RedirectToAction("Index");
        }
    }
}