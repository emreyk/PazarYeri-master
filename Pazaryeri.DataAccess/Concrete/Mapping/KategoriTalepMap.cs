using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.DataAccess.Concrete.Mapping
{
    public class KategoriTalepMap : IEntityTypeConfiguration<KategoriTalep>
    {
        public void Configure(EntityTypeBuilder<KategoriTalep> builder)
        {
            builder.HasKey(I => I.id);
            builder.Property(I => I.id).UseIdentityColumn();
            builder.Property(I => I.kategori_adi).HasMaxLength(50).IsRequired();
            builder.Property(I => I.ust_kategori_adi).HasMaxLength(50).IsRequired(false);
            builder.Property(I => I.seourl).HasMaxLength(50).IsRequired();
            builder.Property(I => I.resim).HasMaxLength(250).IsRequired(false).HasDefaultValue("default.png");
        }
    }
}
