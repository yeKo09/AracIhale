using AracIhale.Entities.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.DAL.Configuration
{
	public class KullaniciIletisimConfiguration : EntityTypeConfiguration<KullaniciIletisim>
	{
		public KullaniciIletisimConfiguration()
		{
			ToTable("KullaniciIletisim");

			HasRequired(k => k.Iletisim)
				.WithMany()
				.HasForeignKey(k => k.IletisimId);

			HasRequired(k => k.Kullanici)
				.WithMany(k => k.KullaniciIletisim)
				.HasForeignKey(k => k.KullaniciId);
		}
	}
}
