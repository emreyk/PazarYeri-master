using FluentValidation;
using Pazaryeri.DTO.DTOs.AppUserDTOs;
using Pazaryeri.DTO.DTOs.BannerDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Business.ValidationRules.FluentValidation
{
    public class BannerKayitValidator : AbstractValidator<BannerKaydetDTO>
    {
        public BannerKayitValidator()
        {
            RuleFor(I => I.ad).NotNull().WithMessage("Ad boş geçilemez");
            RuleFor(I => I.KategoriId).ExclusiveBetween(-1, int.MaxValue).WithMessage("Kategori seçiniz");
            RuleFor(I => I.tip).NotEqual("seçiniz").WithMessage("Konum seçiniz");
        }
    }
}
