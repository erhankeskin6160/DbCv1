using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbCv1.Models.Entity;
using DbCv1.Repositories;

namespace DbCv1.Controllers
{
    public class İletişimController : Controller
    {
        GenericRepository<Tblİletişim> repo = new GenericRepository<Tblİletişim>();
        // GET: İletişim
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}