using AracIhale.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AracIhale.DAL.DAL
{
    public class MarkaDAL
    {
        public List<SelectListItem> MarkalariGetir()
        {
            using (AracIhaleContext db = new AracIhaleContext())
            {
                return (
                    from m in db.Markalar
                    where m.IsActive == true
                    select new SelectListItem()
                    {
                        Text = m.MarkaAdi,
                        Value = m.MarkaId + ""
                    }
                    ).ToList();
            }
        }
    }
}
