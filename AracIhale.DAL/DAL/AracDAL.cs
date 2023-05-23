using AracIhale.DAL.Context;
using AracIhale.Entities.Core;
using AracIhale.Entities.Enums;
using AracIhale.Entities.VM;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.DAL.DAL
{
    public class AracDAL
    {

        public List<AracVM> AraclariGetir()
        {
            using (AracIhaleContext db = new AracIhaleContext())
            {
                var araclar = (
                    from a in db.Araclar
                    join ma in db.Markalar on a.MarkaId equals ma.MarkaId
                    join mo in db.Modeller on a.ModelId equals mo.ModelId
                    join ast in db.AracStatu on a.Id equals ast.AracId
                    join s in db.Status on ast.StatuId equals s.StatuId
                    join k in db.Kullanicilar on a.KullaniciId equals k.KullaniciId
                    select new AracVM()
                    {
                        AracId = a.Id,
                        MarkaAdi = ma.MarkaAdi,
                        ModelAdi = mo.ModelAdi,
                        BireyselMi = a.BireyselMi ? "Bireysel" : "Kurumsal",
                        Statu = s.StatuAdi,
                        KaydedenKullanici = k.KullaniciAdi,
                        KaydedilmeZamani = (DateTime)k.CreatedDate,
                        Plaka = a.Plaka
                    }
                    ).ToList();
                return araclar;
            }
        }

        public bool AracEkle(AracEkleVM vm)
        {
            using(AracIhaleContext db = new AracIhaleContext())
            {
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Arac eklenmisArac = db.Araclar.Add(new Arac()
                        {
                            Plaka = vm.Plaka,
                            Km = vm.Km,
                            Yil = vm.Yil,
                            KullaniciId = 1,
                            BireyselMi = true,
                            MarkaId = vm.MarkaId,
                            ModelId = vm.ModelId,
                            UyeId = vm.UyeId
                        });

                        db.AracOzellikleri.Add(new AracOzellik()
                        {
                            AracId = eklenmisArac.Id,
                            OzellikDetayId = vm.DonanimId,
                        });
                        db.AracOzellikleri.Add(new AracOzellik()
                        {
                            AracId = eklenmisArac.Id,
                            OzellikDetayId = vm.YakitTipiId,
                        });
                        db.AracOzellikleri.Add(new AracOzellik()
                        {
                            AracId = eklenmisArac.Id,
                            OzellikDetayId = vm.GovdeTipiId,
                        });
                        db.AracOzellikleri.Add(new AracOzellik()
                        {
                            AracId = eklenmisArac.Id,
                            OzellikDetayId = vm.VitesTipiId,
                        });
                        db.AracOzellikleri.Add(new AracOzellik()
                        {
                            AracId = eklenmisArac.Id,
                            OzellikDetayId = vm.RenkId,
                        });
                        db.AracOzellikleri.Add(new AracOzellik()
                        {
                            AracId = eklenmisArac.Id,
                            OzellikDetayId = vm.VersiyonId,
                        });

                        db.AracStatu.Add(new AracStatu()
                        {
                            AracId = eklenmisArac.Id,
                            StatuId = vm.StatuId,
                            Tarih = DateTime.Now,
                        });
                        db.AracFiyatlari.Add(new AracFiyat()
                        {
                            AracId = eklenmisArac.Id,
                            Fiyat = vm.Fiyat,
                            Tarih = DateTime.Now
                        });

                        db.SaveChanges();

                        dbTransaction.Commit();
                        return true;
                    }
                    catch
                    {
                        dbTransaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public AracEkleVM IdGoreAracGetir(int aracId)
        {
            using(AracIhaleContext db = new AracIhaleContext())
            {
                var arac = (
                    from a in db.Araclar
                    join ma in db.Markalar on a.MarkaId equals ma.MarkaId
                    join mo in db.Modeller on a.ModelId equals mo.ModelId
                    join ast in db.AracStatu on a.Id equals ast.AracId
                    join s in db.Status on ast.StatuId equals s.StatuId
                    join f in db.AracFiyatlari on a.Id equals f.AracId
                    where a.Id == aracId
                    select new AracEkleVM()
                    {
                        AracId = a.Id,
                        MarkaId = ma.MarkaId,
                        ModelId = mo.ModelId,
                        StatuId = ast.StatuId,
                        Fiyat = f.Fiyat,
                        Plaka = a.Plaka,
                        Yil = a.Yil,
                        Km = a.Km,
                        UyeId = a.UyeId
                    }
                    ).SingleOrDefault();


                var aracOzellikleri = (
                    from ao in db.AracOzellikleri
                    join od in db.OzellikDetaylari on ao.OzellikDetayId equals od.OzellikDetayId
                    join o in db.Ozellikler on od.OzellikId equals o.OzellikId
                    where ao.AracId == arac.AracId
                    select new
                    {
                        OzellikDetayId = od.OzellikDetayId,
                        OzellikId = o.OzellikId
                    }
                    );

                foreach (var item in aracOzellikleri)
                {
                    if ((int)AracOzellikleri.GovdeTipi == item.OzellikId)
                    {
                        arac.GovdeTipiId = item.OzellikDetayId;
                    }
                    else if((int)AracOzellikleri.YakitTipi == item.OzellikId)
                    {
                        arac.YakitTipiId = item.OzellikDetayId;
                    }
                    else if ((int)AracOzellikleri.VitesTipi == item.OzellikId)
                    {
                        arac.VitesTipiId = item.OzellikDetayId;
                    }
                    else if ((int)AracOzellikleri.Versiyon == item.OzellikId)
                    {
                        arac.VersiyonId = item.OzellikDetayId;
                    }
                    else if ((int)AracOzellikleri.Renk == item.OzellikId)
                    {
                        arac.RenkId = item.OzellikDetayId;
                    }
                    else if ((int)AracOzellikleri.OpsiyonelDonanim == item.OzellikId)
                    {
                        arac.DonanimId = item.OzellikDetayId;
                    }
                }

                return arac;
            }
        }

        public bool AracGuncelle(AracEkleVM vm)
        {
            using(AracIhaleContext db = new AracIhaleContext())
            {
                using(var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Arac guncellenecekArac = db.Araclar.SingleOrDefault(x => x.Id == vm.AracId);

                        guncellenecekArac.Km = vm.Km;
                        guncellenecekArac.Plaka = vm.Plaka;
                        guncellenecekArac.Yil = vm.Yil;
                        guncellenecekArac.MarkaId = vm.MarkaId;
                        guncellenecekArac.ModelId = vm.ModelId;
                        guncellenecekArac.ModifiedDate = DateTime.Now;
                        guncellenecekArac.ModifiedBy = vm.ModifiedBy;


                        db.AracFiyatlari.Add(new AracFiyat()
                        {
                            AracId = guncellenecekArac.Id,
                            Fiyat = vm.Fiyat,
                            Tarih = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            ModifiedBy = vm.ModifiedBy
                        });

                        db.AracStatu.Add(new AracStatu()
                        {
                            AracId = guncellenecekArac.Id,
                            StatuId = vm.StatuId,
                            Tarih = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            ModifiedBy = vm.ModifiedBy
                        });


                        var aracOzellikleri = (
                        from ao in db.AracOzellikleri
                        join od in db.OzellikDetaylari on ao.OzellikDetayId equals od.OzellikDetayId
                        join o in db.Ozellikler on od.OzellikId equals o.OzellikId
                        where ao.AracId == vm.AracId
                        select new
                        {
                            aracOzellik = ao,
                            ozellikDetay = od,
                            ozellik = o
                        }
                        );

                        foreach (var item in aracOzellikleri)
                        {
                            if ((int)AracOzellikleri.GovdeTipi == item.aracOzellik.OzellikDetayId)
                            {
                                item.aracOzellik.OzellikDetayId = vm.GovdeTipiId;
                            }
                            else if ((int)AracOzellikleri.YakitTipi == item.aracOzellik.OzellikDetayId)
                            {
                                item.aracOzellik.OzellikDetayId = vm.YakitTipiId;
                            }
                            else if ((int)AracOzellikleri.VitesTipi == item.aracOzellik.OzellikDetayId)
                            {
                                item.aracOzellik.OzellikDetayId = vm.VitesTipiId;
                            }
                            else if ((int)AracOzellikleri.Versiyon == item.aracOzellik.OzellikDetayId)
                            {
                                item.aracOzellik.OzellikDetayId = vm.VersiyonId;
                            }
                            else if ((int)AracOzellikleri.Renk == item.aracOzellik.OzellikDetayId)
                            {
                                item.aracOzellik.OzellikDetayId = vm.RenkId;
                            }
                            else if ((int)AracOzellikleri.OpsiyonelDonanim == item.aracOzellik.OzellikDetayId)
                            {
                                item.aracOzellik.OzellikDetayId = vm.DonanimId;
                            }

                            
                        }

                        db.SaveChanges();
                        dbTransaction.Commit();
                        return true;
                    }
                    catch
                    {
                        dbTransaction.Rollback();
                        return false;
                    }
                    
                }
            }
        }
    }
}
