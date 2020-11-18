using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.DataAccess.Concrete.Mapping
{
    public class KategoriMap : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.HasKey(I => I.id);
            builder.Property(I => I.id).UseIdentityColumn();
            builder.Property(I => I.kategori_adi).HasMaxLength(250).IsRequired();
            builder.Property(I => I.ust_kategori_adi).HasMaxLength(250).IsRequired(false);
            builder.Property(I => I.seourl).HasMaxLength(250).IsRequired();
            builder.Property(I => I.resim).HasMaxLength(250).IsRequired(false).HasDefaultValue("default.png");
        }
    }
}
