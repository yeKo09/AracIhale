using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.Entities.VM
{
    public class AracVM
    {
		public int AracId { get; set; }
		public string Plaka { get; set; }
		public int Km { get; set; }
		public string MarkaAdi { get; set; }
		public string ModelAdi { get; set; }
		public string BireyselMi { get; set; }
		public string Statu { get; set; }
		public string KaydedenKullanici { get; set; }
		public DateTime KaydedilmeZamani { get; set; }
	}
}
