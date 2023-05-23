using AracIhale.DAL.Context;
using AracIhale.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AracIhale.DAL.DAL
{
    public class AracOzellikDAL
    {

        public List<SelectListItem> OzellikleriGetir(AracOzellikleri aracOzellikleri)
        {
            using(AracIhaleContext db = new AracIhaleContext())
            {
                return (
                    from od in db.OzellikDetaylari
                    join o in db.Ozellikler on od.OzellikId equals o.OzellikId
                    where od.IsActive == true && o.OzellikAdi == aracOzellikleri.ToString()
                    select new SelectListItem()
                    {
                        Text = od.OzellikDetayi,
                        Value = od.OzellikDetayId + ""
                    }
                    ).ToList();
            }
        }

    }
}
