using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.DataAccess.Concrete.Mapping
{
    public class UyeMap : IEntityTypeConfiguration<Uye>
    {
        public void Configure(EntityTypeBuilder<Uye> builder)
        {
            builder.HasKey(I => I.id);
            builder.Property(I => I.id).UseIdentityColumn();
            builder.Property(I => I.ad).HasMaxLength(50).IsRequired();
            builder.Property(I => I.soyad).HasMaxLength(50).IsRequired();
            builder.Property(I => I.telefon).HasMaxLength(20).IsRequired();
            builder.Property(I => I.eposta).HasMaxLength(30).IsRequired();
            builder.Property(I => I.sifre).HasMaxLength(30).IsRequired();
           

            builder.HasOne(I => I.AppUser).WithOne(I => I.Uye).HasForeignKey<Uye>(I => I.AppUserId);
         
        }
    }
}
