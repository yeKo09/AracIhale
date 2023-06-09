﻿using AracIhale.Entities.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.DAL.Configuration
{
	public class AracParcaConfiguration : EntityTypeConfiguration<AracParca>
	{
		public AracParcaConfiguration()
		{
			ToTable("AracParca");
			HasKey(a => a.AracParcaId);
			Property(a => a.ParcaAdi).IsRequired();
			Property(a => a.IsActive).IsRequired();
			Property(a => a.IsDeleted).IsRequired();
		}
	}
}
