using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.Entities.Core
{
	public class AracOzellik : BaseEntity
	{
		public int AracId { get; set; }
		public int OzellikDetayId { get; set; }


		public Arac Arac { get; set; }
		public OzellikDetay OzellikDetay { get; set; }
	}
}
