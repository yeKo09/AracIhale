using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AracIhale.Entities.VM
{
    public class AracEkleVM
    {
		public int AracId { get; set; }
		//public int OzellikDetayId { get; set; }
		//public string OzellikDetayAdi { get; set; }
		public int GovdeTipiId { get; set; }
		public int VersiyonId { get; set; }
		public int RenkId { get; set; }
		public int MarkaId { get; set; }
		public int ModelId { get; set; }
		public int StatuId { get; set; }
		public int VitesTipiId { get; set; }
		public int YakitTipiId { get; set; }
		public int FirmaId { get; set; }
		public int UyeId { get; set; }
		public string Plaka { get; set; }
		public decimal Fiyat { get; set; }
		public decimal Km { get; set; }
		public int DonanimId { get; set; }
		public int Yil { get; set; }
		public int AracTuruId { get; set; }
		public int KaydedenKullaniciId { get; set; } = 1;
        public int ModifiedBy { get; set; }


        public List<SelectListItem> Markalar { get; set; }
        public List<SelectListItem> Modeller { get; set; }
        public List<SelectListItem> Statuler { get; set; }
        public List<SelectListItem> Firmalar { get; set; }
        public List<SelectListItem> Uyeler { get; set; }
        public List<SelectListItem> GovdeTipleri { get; set; }
        public List<SelectListItem> YakitTipleri { get; set; }
        public List<SelectListItem> VitesTipleri { get; set; }
        public List<SelectListItem> Versiyonlar { get; set; }
        public List<SelectListItem> Renkler { get; set; }
        public List<SelectListItem> OpsiyonelDonanimlar { get; set; }
    }
}
