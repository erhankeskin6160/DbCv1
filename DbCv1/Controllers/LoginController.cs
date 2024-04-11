using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbCv1.Controllers;
using System.Web.Security;
using DbCv1.Models.Entity;

namespace DbCv1.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
      

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin admin)
        {
            DbCvEntities2 db = new DbCvEntities2();
            var bilgi = db.TblAdmin.FirstOrDefault(x => x.KullaniciAdi == admin.KullaniciAdi);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KullaniciAdi, false);
                Session["KullaniciAdi"] = bilgi.KullaniciAdi.ToString();
                return RedirectToAction("Index", controllerName: "Deneyim");

            }
            else
            {
                return RedirectToAction("Index", controllerName: "Eğitim");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}