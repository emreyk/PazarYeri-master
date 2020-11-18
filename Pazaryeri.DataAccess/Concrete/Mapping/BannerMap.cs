using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.DataAccess.Concrete.Mapping
{
    class BannerMap : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.HasKey(I => I.id);
            builder.Property(I => I.id).UseIdentityColumn();
            builder.Property(I => I.ad).HasMaxLength(50).IsRequired();
            builder.Property(I => I.resim).HasMaxLength(255).IsRequired();
            builder.Property(I => I.tip).HasMaxLength(50).IsRequired();
            builder.HasOne(I => I.Kategori).WithOne(I => I.Banner).HasForeignKey<Banner>(I => I.KategoriId);

        }
     
    }
}
