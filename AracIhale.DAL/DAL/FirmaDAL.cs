using AracIhale.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AracIhale.DAL.DAL
{
    public class FirmaDAL
    {
        public List<SelectListItem> FirmalariGetir()
        {
            using (AracIhaleContext db = new AracIhaleContext())
            {
                return (
                    from m in db.Firmalar
                    where m.IsActive == true
                    select new SelectListItem()
                    {
                        Text = m.Unvan,
                        Value = m.Id + ""
                    }
                    ).ToList();
            }
        }
    }
}
