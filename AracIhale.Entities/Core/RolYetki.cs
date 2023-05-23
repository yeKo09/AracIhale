using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.Entities.Core
{
	public class RolYetki
	{
		[Key]
		[Column(Order = 0)]
		public int RolId { get; set; }
		[Key]
		[Column(Order = 1)]
		public int SayfaId { get; set; }


		public Rol Rol { get; set; }
		public Sayfa Sayfa { get; set; }
	}
}
