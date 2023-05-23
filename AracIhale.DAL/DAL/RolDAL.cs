using AracIhale.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AracIhale.DAL.DAL
{
    public class RolDAL
    {

        public List<SelectListItem> RolleriGetir()
        {
            using(AracIhaleContext db = new AracIhaleContext())
            {
                return (
                    from r in db.Roller
                    where r.IsActive == true
                    select new SelectListItem()
                    {
                        Text = r.RolAdi,
                        Value = r.RolId + ""
                    }
                    ).ToList();
            }
        }

    }
}
