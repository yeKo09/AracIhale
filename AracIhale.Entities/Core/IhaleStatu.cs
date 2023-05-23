using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.Entities.Core
{
	public class IhaleStatu
	{
		public int IhaleStatuId { get; set; }
		public DateTime Tarih { get; set; }
		public int IhaleId { get; set; }
		public int StatuId { get; set; }


		public Ihale Ihale { get; set; }
		public Statu Statu { get; set; }
	}
}
