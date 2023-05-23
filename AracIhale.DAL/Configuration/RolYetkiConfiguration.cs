using AracIhale.Entities.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.DAL.Configuration
{
	public class RolYetkiConfiguration : EntityTypeConfiguration<RolYetki>
	{
		public RolYetkiConfiguration()
		{
			ToTable("RolYetki");
			HasKey(x => new { x.RolId, x.SayfaId });


			HasRequired(x => x.Sayfa)
				.WithMany(x => x.SayfaRolYetkileri)
				.HasForeignKey(x => x.SayfaId);
		}
	}
}
