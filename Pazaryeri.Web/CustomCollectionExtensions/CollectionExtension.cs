using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Pazaryeri.Business.ValidationRules.FluentValidation;
using Pazaryeri.DataAccess.Concrete.EntityFrameworkCore.Context;
using Pazaryeri.DTO.DTOs;
using Pazaryeri.DTO.DTOs.AppUserDTOs;
using Pazaryeri.DTO.DTOs.BannerDTOs;
using Pazaryeri.DTO.DTOs.KategoriDTOs;
using Pazaryeri.DTO.DTOs.MarkaDTOs;
using Pazaryeri.DTO.DTOs.SecenekDTOs;
using Pazaryeri.DTO.DTOs.SliderDTOs;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pazaryeri.Web.CustomCollectionExtensions
{
    public static class CollectionExtension
    {
        public class CustomIdentityValidator : IdentityErrorDescriber
        {
            public override IdentityError DuplicateUserName(string UserName)
            {
                return new IdentityError()
                {
                    Code = "DuplicateMail",
                    Description = $" {UserName}  e-posta adresine ait hesap kullanılmaktadır"
                };
            }
        }


        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddErrorDescriber<CustomIdentityValidator>()
             .AddEntityFrameworkStores<PazayeriContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "PazaryeriCookie";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(365);
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                //opt.LoginPath = "/Account";
            });


        }

        public static void AddCustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AppUserGirisDTO>, AppUserSignInValidator>();
            services.AddTransient<IValidator<MagazaKayitDTO>, MagazaKayitValidator>();
            services.AddTransient<IValidator<KategoriEkleDTO>, KategoriKayitValidator>();
            services.AddTransient<IValidator<KategoriListeDTO>, KategoriGuncelleValidator>();
            services.AddTransient<IValidator<SecenekKaydetDTO>, SecenekKayitValidator>();
            services.AddTransient<IValidator<SecenekUpdateDTO>, SecenekGuncelleValidator>();
            services.AddTransient<IValidator<SecenekMaddeKaydetDTO>, SecenekMaddeKayitValidator>();
            services.AddTransient<IValidator<MarkaGenelDTO>, MarkaKayitValidator>();
            services.AddTransient<IValidator<UyeKayitDTO>, UyeKayitValidator>();
            services.AddTransient<IValidator<BannerKaydetDTO>, BannerKayitValidator>();
            services.AddTransient<IValidator<SliderKaydetDTO>, SliderKayitValidator>();
        }
    }
}
