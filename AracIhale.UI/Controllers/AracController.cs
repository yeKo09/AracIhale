using AracIhale.DAL.DAL;
using AracIhale.Entities.Enums;
using AracIhale.Entities.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracIhale.UI.Controllers
{
    public class AracController : Controller
    {
        // GET: Arac
        public ActionResult Index()
        {
            return View(new AracDAL().AraclariGetir());
        }

        [HttpGet]
        public ActionResult AracEkle()
        {
            AracEkleVM vm = new AracEkleVM();
            vm = ListeleriDoldur(vm);
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AracEkle(AracEkleVM vm)
        {
            AracDAL aracDAL = new AracDAL();
            aracDAL.AracEkle(vm);
            return RedirectToAction("Index", "Arac");
        }

        [HttpGet]
        public ActionResult AracGuncelle(int aracId)
        {
            AracEkleVM vm = new AracEkleVM();
            vm = new AracDAL().IdGoreAracGetir(aracId);
            vm = ListeleriDoldur(vm);
            return View(vm);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult AracGuncelle(AracEkleVM vm)
        {
            AracDAL aracDAL = new AracDAL();
            vm.ModifiedBy = 1;
            aracDAL.AracGuncelle(vm);
            return RedirectToAction("Index", "Arac");
        }

        //out olabilir parametre
        private AracEkleVM ListeleriDoldur(AracEkleVM vm)
        {
            vm.Markalar = new MarkaDAL().MarkalariGetir();
            vm.Modeller = new ModelDAL().ModelleriGetir();
            vm.Statuler = new StatuDAL().StatuleriGetir();
            vm.Firmalar = new FirmaDAL().FirmalariGetir();
            vm.Uyeler = new UyeDAL().UyeleriGetir(UyeTurleri.Bireysel);

            AracOzellikDAL aracOzellikDAL = new AracOzellikDAL();
            vm.GovdeTipleri = aracOzellikDAL.OzellikleriGetir(AracOzellikleri.GovdeTipi);
            vm.YakitTipleri = aracOzellikDAL.OzellikleriGetir(AracOzellikleri.YakitTipi);
            vm.VitesTipleri = aracOzellikDAL.OzellikleriGetir(AracOzellikleri.VitesTipi);
            vm.Versiyonlar = aracOzellikDAL.OzellikleriGetir(AracOzellikleri.Versiyon);
            vm.Renkler = aracOzellikDAL.OzellikleriGetir(AracOzellikleri.Renk);
            vm.OpsiyonelDonanimlar = aracOzellikDAL.OzellikleriGetir(AracOzellikleri.OpsiyonelDonanim);

            return vm;
        }
    }
}