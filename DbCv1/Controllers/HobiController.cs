using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbCv1.Models.Entity;
using DbCv1.Repositories;

namespace DbCv1.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }

        [HttpPost]
        public ActionResult Index(TblHobilerim hobi)
        {
            //TblHobilerim t = new TblHobilerim();
            var t = repo.Find(x=>x.Id == 1);
            t.Acıklama1 = hobi.Acıklama1;
            t.Acıklama2 = hobi.Acıklama2;
           
            repo.TUpdate(t);
           return RedirectToAction("Index");
        }
    }
}