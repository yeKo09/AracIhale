using AracIhale.DAL.DAL;
using AracIhale.Entities.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AracIhale.UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            LoginVM loginVm = new LoginVM();

            if (Request.Cookies["kullaniciGirisBilgileri"] != null)
            {
                loginVm.KullaniciAdi = Request.Cookies["kullaniciGirisBilgileri"].Values["kullaniciAdi"];
            }
            return View(loginVm);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Index(LoginVM loginVm)
        {
            KullaniciDAL kullaniciDAL = new KullaniciDAL();

            var kullanici = kullaniciDAL.GirisKontrolEt(loginVm);

            if (kullanici == null)
            {
                return View("Index");
            }

            FormsAuthentication.SetAuthCookie(kullanici.KullaniciAdi, true);
            Session.Add("girisYapanKullanici", kullanici);
            HttpCookie cookie = new HttpCookie("kullaniciGirisBilgileri");

            if (loginVm.BeniHatirla)
            {
                cookie.Values.Add("kullaniciAdi", loginVm.KullaniciAdi);
                cookie.Expires = DateTime.Now.AddDays(3);
                HttpContext.Response.Cookies.Add(cookie);
            }

            return RedirectToAction("Index", "Kullanici");
        }

        // todo : logout
    }
}