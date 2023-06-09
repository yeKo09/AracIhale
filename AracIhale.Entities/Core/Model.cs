﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.Entities.Core
{
	public class Model
	{
		public int ModelId { get; set; }
		public int MarkaId { get; set; }
		public string ModelAdi { get; set; }
		public int? UstModelId { get; set; }
		public Marka Marka { get; set; }


		public virtual ICollection<Arac> Arac { get; set; }
		public ICollection<FavoriAramaKriter> FavoriAramaKriter { get; set; }

		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
