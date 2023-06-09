﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.Entities.Core
{
	public class Ilan : BaseEntity
	{
		public int AracId { get; set; }
		public string Baslik { get; set; }
		public string Aciklama { get; set; }

		public Arac Arac { get; set; }
		public ICollection<FavoriIlan> FavoriIlanlar { get; set; }
	}
}
