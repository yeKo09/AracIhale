using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.Entities.Core
{
	public class AracIhales : BaseEntity
	{
		public int AracId { get; set; }
		public int IhaleId { get; set; }
		public decimal IhaleBaslangicFiyati { get; set; }
		public decimal MinimumAlimFiyati { get; set; }


		public Arac Arac { get; set; }
		public Ihale Ihale { get; set; }
		public ICollection<AracTeklif> AracTeklifler { get; internal set; }
	}
}
