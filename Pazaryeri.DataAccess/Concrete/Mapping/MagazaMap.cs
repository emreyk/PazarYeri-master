using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.DataAccess.Concrete.Mapping
{
    public class MagazaMap : IEntityTypeConfiguration<Magaza>
    {
        public void Configure(EntityTypeBuilder<Magaza> builder)
        {
            builder.HasKey(I => I.id);
            builder.Property(I => I.id).UseIdentityColumn();
            builder.Property(I => I.tip).HasMaxLength(20).IsRequired();
            builder.Property(I => I.ad).HasMaxLength(50).IsRequired();
            builder.Property(I => I.soyad).HasMaxLength(50).IsRequired();
            builder.Property(I => I.telefon).HasMaxLength(20).IsRequired();
            builder.Property(I => I.eposta).HasMaxLength(30).IsRequired();
            builder.Property(I => I.sifre).HasMaxLength(30).IsRequired();
            builder.Property(I => I.tc).HasMaxLength(20).IsRequired();
            builder.Property(I => I.magaza_adi).HasMaxLength(100).IsRequired();
            builder.Property(I => I.unvan).HasMaxLength(30).IsRequired(false);
            builder.Property(I => I.vergi_dairesi).HasMaxLength(50).IsRequired(false);
            builder.Property(I => I.vergi_numarasi).HasMaxLength(50).IsRequired(false);

            builder.HasOne(I => I.AppUser).WithOne(I => I.Magaza).HasForeignKey<Magaza>(I => I.AppUserId);
            builder.HasMany(I => I.KategoriTalep).WithOne(I => I.Magaza).HasForeignKey(I => I.magaza_id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
