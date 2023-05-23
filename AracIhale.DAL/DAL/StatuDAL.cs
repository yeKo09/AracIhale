using AracIhale.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AracIhale.DAL.DAL
{
    public class StatuDAL
    {

        public List<SelectListItem> StatuleriGetir()
        {
            using (AracIhaleContext db = new AracIhaleContext())
            {
                return (
                    from m in db.Status
                    where m.IsActive == true
                    select new SelectListItem()
                    {
                        Text = m.StatuAdi,
                        Value = m.StatuId + ""
                    }
                    ).ToList();
            }
        }

    }
}
