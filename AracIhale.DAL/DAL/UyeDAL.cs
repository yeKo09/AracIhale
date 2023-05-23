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
    public class UyeDAL
    {

        public List<SelectListItem> UyeleriGetir(UyeTurleri uyeTurleri)
        {
            using(AracIhaleContext db = new AracIhaleContext())
            {
                return (
                    from u in db.Uyeler
                    join ut in db.UyeTurleri on u.UyeTuruId equals ut.UyeTuruId
                    where u.IsActive == true && ut.UyeTuruAdi == uyeTurleri.ToString()
                    select new SelectListItem()
                    {
                        Text = u.Isim + " " + u.Soyisim,
                        Value = u.Id + ""
                    }
                    ).ToList();
            }
        }

    }
}
