﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.Entities.Core
{
	public class Satis : BaseEntity
	{
		public int IlanId { get; set; }
		public DateTime SatisTarihi { get; set; }
		public decimal SatisToplamUcreti { get; set; }
		public int UcretId { get; set; }
		public int UyeId { get; set; }
		public int SatisTuruId { get; set; }


		public SatisTuru SatisTuru { get; set; }
		public Ucret Ucret { get; set; }
		public Uye Uye { get; set; }
		public Ilan Ilan { get; set; }

	}
}
