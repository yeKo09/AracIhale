using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.Entities.Core
{
	public class UyeIletisim : BaseEntity
	{
		public int IletisimId { get; set; }
		public int UyeId { get; set; }
		public string IletisimBilgi { get; set; }


		public Iletisim Iletisim { get; set; }
		public Uye Uye { get; set; }
	}
}
