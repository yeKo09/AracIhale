using AracIhale.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AracIhale.DAL.DAL
{
    public class ModelDAL
    {
        public List<SelectListItem> ModelleriGetir()
        {
            using (AracIhaleContext db = new AracIhaleContext())
            {
                return (
                    from m in db.Modeller
                    where m.IsActive == true
                    select new SelectListItem()
                    {
                        Text = m.ModelAdi,
                        Value = m.ModelId + ""
                    }
                    ).ToList();
            }
        }

        public List<SelectListItem> MarkayaGoreModelleriGetir(int markaId)
        {
            using(AracIhaleContext db = new AracIhaleContext())
            {
                return (
                    from m in db.Modeller
                    where m.IsActive == true && m.MarkaId == markaId
                    select new SelectListItem()
                    {
                        Text = m.ModelAdi,
                        Value = m.ModelId + ""
                    }
                    ).ToList();
            }
        }
    }
}
