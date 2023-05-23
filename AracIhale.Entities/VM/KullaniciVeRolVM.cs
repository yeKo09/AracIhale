using AracIhale.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AracIhale.Entities.VM
{
    public class KullaniciVeRolVM
    {
		public int KullaniciId { get; set; }
		public string Isim { get; set; }
		public string Soyisim { get; set; }
		public string KullaniciAdi { get; set; }
		public string Sifre { get; set; }
		public string Telefon { get; set; }
		public string Mail { get; set; }
        public string RolAdi { get; set; }
		public int RolId { get; set; }
        public bool AktifMi { get; set; }


        public List<SelectListItem> Roller { get; set; }
	}
}
