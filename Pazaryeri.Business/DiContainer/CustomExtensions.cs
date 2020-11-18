using Microsoft.Extensions.DependencyInjection;
using Pazaryeri.Business.Concrate;
using Pazaryeri.Business.CustomLogger;
using Pazaryeri.Business.Interfaces;
using Pazaryeri.DataAccess.Concrete.Repositories;
using Pazaryeri.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Business.DiContainer
{
    public static class CustomExtensions
    {
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMagazaService, MagazaManager>();
            services.AddScoped<IMagazaDal, EfMagazaRepository>();
            services.AddScoped<IKategoriService, KategoriManager>();
            services.AddScoped<IKategoriTalepService, KategoriTalepManager>();
            services.AddScoped<IKategoriTalepDal, EfKategoriTalepRepository>();
            services.AddScoped<IKategoriDal, EfKategoriRepository>();
            services.AddScoped<ISecenekDal, EfSecenekRepository>();
            services.AddScoped<ISecenekService, SecenekManager>();
            services.AddScoped<ISecenekMaddeDal, EfSecenekMaddeRepository>();
            services.AddScoped<ISecenekMaddeService, SecenekMaddeManager>();
            services.AddScoped<IMarkaDal, EfMarkaRepository>();
            services.AddScoped<IMarkaService, MarkaManager>();
            services.AddScoped<IUyeDal, EfUyeRepository>();
            services.AddScoped<IUyeService, UyeManager>();
            services.AddScoped<IBannerDal, EfBannerRepository>();
            services.AddScoped<IBannerService, BannerManager>();
            services.AddScoped<ISliderDal, EfSliderRepository>();
            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<ICustomLogger, NLogLogger>();
        }

    }
}
