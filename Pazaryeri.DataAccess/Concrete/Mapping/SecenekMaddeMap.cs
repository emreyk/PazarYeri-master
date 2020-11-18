using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.DataAccess.Concrete.Mapping
{
    public class SecenekMaddeMap : IEntityTypeConfiguration<SecenekMadde>
    {
        public void Configure(EntityTypeBuilder<SecenekMadde> builder)
        {
            builder.HasKey(I => I.id);
            builder.Property(I => I.id).UseIdentityColumn();
            builder.Property(I => I.ad).HasMaxLength(100).IsRequired();
        }
    }
}
