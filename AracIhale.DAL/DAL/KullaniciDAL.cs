using AracIhale.DAL.Context;
using AracIhale.Entities.Core;
using AracIhale.Entities.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.DAL.DAL
{
    public class KullaniciDAL
    {

        public KullaniciVeRolVM GirisKontrolEt(LoginVM loginVm)
        {
            using(AracIhaleContext db = new AracIhaleContext())
            {
                var kullanici = (
                        from k in db.Kullanicilar
                        join r in db.Roller on k.RolId equals r.RolId
                        where (k.KullaniciAdi == loginVm.KullaniciAdi || k.Mail == loginVm.Mail)
                        && k.Sifre == loginVm.Sifre
                        select new KullaniciVeRolVM()
                        {
                            KullaniciId = k.KullaniciId,
                            Isim = k.Isim,
                            Soyisim = k.Soyisim,
                            KullaniciAdi = k.KullaniciAdi,
                            Mail = k.Mail,
                            Sifre = k.Sifre,
                            Telefon = k.Telefon,
                            RolAdi = r.RolAdi,
                            RolId = r.RolId,
                            AktifMi = k.IsActive
                        }).SingleOrDefault();
                return kullanici;
            }
        }

        public List<KullaniciVeRolVM> KullanicilariGetir()
        {
            using (AracIhaleContext db = new AracIhaleContext())
            {
                List<KullaniciVeRolVM> kullanicilar = (
                        from k in db.Kullanicilar
                        join r in db.Roller on k.RolId equals r.RolId
                        where k.IsActive == true
                        select new KullaniciVeRolVM()
                        {
                            KullaniciId = k.KullaniciId,
                            Isim = k.Isim,
                            Soyisim = k.Soyisim,
                            KullaniciAdi = k.KullaniciAdi,
                            Mail = k.Mail,
                            Sifre = k.Sifre,
                            Telefon = k.Telefon,
                            RolAdi = r.RolAdi,
                            RolId = r.RolId,
                            AktifMi = k.IsActive
                        }
                    ).ToList();
                return kullanicilar;
            }
        }

        public void KullaniciEkle(KullaniciVeRolVM vm)
        {
            using (AracIhaleContext db = new AracIhaleContext())
            {
                db.Kullanicilar.Add(new Kullanici() 
                {
                    Isim = vm.Isim,
                    Soyisim = vm.Soyisim,
                    KullaniciAdi = vm.KullaniciAdi,
                    Sifre = vm.Sifre,
                    Telefon = vm.Telefon,
                    Mail = vm.Mail,
                    ModifiedBy = 1,
                    RolId = vm.RolId
                });
                db.SaveChanges();
            }
        }

        public KullaniciVeRolVM IdGoreKullaniciGetir(int kullaniciId)
        {
            using(AracIhaleContext db = new AracIhaleContext())
            {
                return (
                    from k in db.Kullanicilar
                    join r in db.Roller on k.RolId equals r.RolId
                    where k.KullaniciId == kullaniciId
                    select new KullaniciVeRolVM()
                    {
                        KullaniciId = k.KullaniciId,
                        Isim = k.Isim,
                        Soyisim = k.Soyisim,
                        KullaniciAdi = k.KullaniciAdi,
                        Mail = k.Mail,
                        Sifre = k.Sifre,
                        Telefon = k.Telefon,
                        RolAdi = r.RolAdi,
                        RolId = r.RolId,
                        AktifMi = k.IsActive
                    }
                    ).SingleOrDefault();
            }
        }

        public void KullaniciSil(int kullaniciId)
        {
            using(AracIhaleContext db = new AracIhaleContext())
            {
                Kullanici kullanici = db.Kullanicilar.SingleOrDefault(x => x.KullaniciId == kullaniciId);
                kullanici.IsActive = false;
                kullanici.IsDeleted = true;

                db.SaveChanges();
            }
            
        }

        public void KullaniciGuncelle(KullaniciVeRolVM vm)
        {
            using (AracIhaleContext db = new AracIhaleContext())
            {
                Kullanici kullanici = db.Kullanicilar.SingleOrDefault(x => x.KullaniciId == vm.KullaniciId);
                kullanici.Isim = vm.Isim;
                kullanici.Soyisim = vm.Soyisim;
                kullanici.KullaniciAdi = vm.KullaniciAdi;
                kullanici.Mail = vm.Mail;
                kullanici.Sifre = vm.Sifre;
                kullanici.Telefon = vm.Telefon;
                kullanici.RolId = vm.RolId;

                db.SaveChanges();
            }
        }
    }
}
