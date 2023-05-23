using AracIhale.DAL.DAL;
using AracIhale.Entities.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracIhale.UI.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        public ActionResult Index()
        {
            KullaniciDAL kullaniciDAL = new KullaniciDAL();
            return View(kullaniciDAL.KullanicilariGetir());
        }

        [HttpGet]
        public ActionResult KullaniciEkle()
        {
            KullaniciVeRolVM vm = new KullaniciVeRolVM();
            vm.Roller = new RolDAL().RolleriGetir();
            return View(vm);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult KullaniciEkle(KullaniciVeRolVM vm)
        {
            KullaniciDAL kullaniciDAL = new KullaniciDAL();
            kullaniciDAL.KullaniciEkle(vm);
            return RedirectToAction("Index", "Kullanici");
        }

        [HttpGet]
        public ActionResult KullaniciSil(int kullaniciId)
        {
            KullaniciDAL kullaniciDAL = new KullaniciDAL();
            kullaniciDAL.KullaniciSil(kullaniciId);
            return RedirectToAction("Index", "Kullanici");
        }

        [HttpGet]
        public ActionResult KullaniciGuncelle(int kullaniciId)
        {
            KullaniciVeRolVM kullanici = new KullaniciDAL().IdGoreKullaniciGetir(kullaniciId);
            kullanici.Roller = new RolDAL().RolleriGetir();
            return View(kullanici);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult KullaniciGuncelle(KullaniciVeRolVM vm)
        {
            KullaniciDAL kullaniciDAL = new KullaniciDAL();
            kullaniciDAL.KullaniciGuncelle(vm);
            return RedirectToAction("Index", "Kullanici");
        }

        

    }
}