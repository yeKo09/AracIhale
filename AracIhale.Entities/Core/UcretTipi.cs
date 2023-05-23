﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.Entities.Core
{
	public class UcretTipi
	{
		public int UcretTipiId { get; set; }
		public string UcretTipiAdi { get; set; }
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;


		public ICollection<Ucret> Ucretler { get; set; }
	}
}
