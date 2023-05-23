using AracIhale.Entities.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.DAL.Configuration
{
	public class OzellikConfiguration : EntityTypeConfiguration<Ozellik>
	{
		public OzellikConfiguration()
		{
			ToTable("Ozellik");

			HasKey(o => o.OzellikId);

			Property(o => o.OzellikAdi)
				.IsRequired()
				.HasMaxLength(50);

			Property(o => o.IsActive)
				.IsRequired();

			Property(o => o.IsDeleted)
				.IsRequired();
		}
	}
}
