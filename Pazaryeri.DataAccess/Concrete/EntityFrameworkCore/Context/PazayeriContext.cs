using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pazaryeri.DataAccess.Concrete.Mapping;
using Pazaryeri.Entities.Concrete;

namespace Pazaryeri.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class PazayeriContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("data source=.;initial catalog=Pazaryeri;integrated security=True;");
            optionsBuilder.UseSqlServer("data source=94.73.147.7;initial catalog=u9544174_pazar; User Id=u9544174_userBAC; Password=KNkc67A8PSkb30O; ");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new MagazaMap());
            modelBuilder.ApplyConfiguration(new KategoriMap());
            modelBuilder.ApplyConfiguration(new KategoriTalepMap());
            modelBuilder.ApplyConfiguration(new SecenekMap());
            modelBuilder.ApplyConfiguration(new SecenekMaddeMap());
            modelBuilder.ApplyConfiguration(new MarkaMap());
            modelBuilder.ApplyConfiguration(new UyeMap());
            modelBuilder.ApplyConfiguration(new BannerMap());
            modelBuilder.ApplyConfiguration(new SliderMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Magaza> Magazalar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<KategoriTalep> KategoriTalep { get; set; }
        public DbSet<Secenek> Secenek { get; set; }
        public DbSet<SecenekMadde> SecenekMadde { get; set; }
        public DbSet<Marka> Marka { get; set; }
        public DbSet<Uye> Uye { get; set; }
        public DbSet<Banner> Banner { get; set; }
        public DbSet<Slider> Slider { get; set; }
    }
}
