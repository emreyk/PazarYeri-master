using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.DataAccess.Concrete.Mapping
{
    public class MarkaMap : IEntityTypeConfiguration<Marka>
    {
        public void Configure(EntityTypeBuilder<Marka> builder)
        {
            builder.HasKey(I => I.id);
            builder.Property(I => I.id).UseIdentityColumn();
            builder.Property(I => I.ad).HasMaxLength(100).IsRequired();
            builder.Property(I => I.seourl).HasMaxLength(100).IsRequired();
            builder.Property(I => I.resim).HasMaxLength(250).IsRequired(false).HasDefaultValue("default.png");
        }
    }
}
