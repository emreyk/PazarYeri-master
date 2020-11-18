using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.DataAccess.Concrete.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            //builder.HasOne(I => I.Magaza).WithOne(I => I.AppUser).HasForeignKey<Magaza>(I => I.AppUserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
