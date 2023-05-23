using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.Entities.Core
{
	public class Ilce
	{
		public int IlceId { get; set; }
		public string IlceAdi { get; set; }

		public ICollection<SehirIlce> SehirIlceleri { get; set; }

		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
