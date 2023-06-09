﻿using AracIhale.Entities.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.DAL.Configuration
{
	public class AracIhaleConfiguration : EntityTypeConfiguration<AracIhales>
	{
		public AracIhaleConfiguration()
		{
			ToTable("AracIhale");

			HasKey(ai => ai.Id);

			Property(ai => ai.IhaleBaslangicFiyati)
				.IsRequired();

			Property(ai => ai.MinimumAlimFiyati)
				.IsRequired();

			HasRequired(ai => ai.Arac)
				.WithMany(a => a.AracIhale)
				.HasForeignKey(ai => ai.AracId);

			HasRequired(ai => ai.Ihale)
				.WithMany(i => i.AracIhale)
				.HasForeignKey(ai => ai.IhaleId);
		}
	}
}
