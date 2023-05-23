using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.Entities.Core
{
	public class AracStatu : BaseEntity
	{
		public int AracId { get; set; }
		public int StatuId { get; set; }
		public DateTime Tarih { get; set; }

		public Arac Arac { get; set; }
		public Statu Statu { get; set; }
	}
}
