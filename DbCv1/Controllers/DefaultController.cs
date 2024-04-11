using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbCv1.Models.Entity;

namespace DbCv1.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        public DbCvEntities2 db = new DbCvEntities2();
        
        public ActionResult Index()
        {
           
            var degerler=db.TblHakkımda.ToList();
            return View(degerler);
            
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedya.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim() 
        {
            var deneyimler=db.TblDeneyimler.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Eğitimlerim()
        {
            var eğitimlerim = db.TblEğitimlerim.ToList();
            return PartialView(eğitimlerim);
        }
        
        public PartialViewResult Yeteneklerim()
        {
            var yeteneklerim = db.TblYetenekler.ToList();
            return PartialView(yeteneklerim);
        }
        public PartialViewResult Hobilerim()
        {
            var hobilerim = db.TblHobilerim.ToList();
            return PartialView(hobilerim);
        }
        public PartialViewResult Sertfikalarım()
        {
            var sertfikalar = db.TblSertfikalarım.ToList();
            return PartialView(sertfikalar);
        }
        [HttpGet]
        public PartialViewResult İletişim()
        {
         
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult İletişim(Tblİletişim tblİletişim)
        {

           
            
                db.Tblİletişim.Add(tblİletişim);
                db.SaveChanges();

            
             

             

            return PartialView();
        }
    }
}