using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.Entities.Core
{
	public class Stok : BaseEntity
	{
		public int FirmaId { get; set; }
		public int StokAdedi { get; set; }
		public DateTime Tarih { get; set; }


		public Firma Firma { get; set; }
	}
}
