using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.DataAccess.Concrete.Mapping
{
    public class SecenekMap : IEntityTypeConfiguration<Secenek>
    {
        public void Configure(EntityTypeBuilder<Secenek> builder)
        {
            builder.HasKey(I => I.id);
            builder.Property(I=>I.id).UseIdentityColumn();
            builder.Property(I => I.ad).HasMaxLength(100).IsRequired();

            builder.HasMany(I => I.SecenekMadde).WithOne(I => I.Secenek).HasForeignKey(I => I.SecenekId);
        }
    }
}
