using FluentValidation;
using Pazaryeri.DTO.DTOs.AppUserDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Business.ValidationRules.FluentValidation
{
    public class UyeKayitValidator:AbstractValidator<UyeKayitDTO>
    {
        public UyeKayitValidator()
        {
            RuleFor(I => I.ad).NotNull().WithMessage("Ad boş geçilemez");
            RuleFor(I => I.soyad).NotNull().WithMessage("Soyad adı boş geçilemez");
            RuleFor(I => I.sifre).NotNull().WithMessage("Şifre adı boş geçilemez");
            RuleFor(I => I.telefon).NotNull().WithMessage("Telefon boş geçilemez");
            RuleFor(I => I.eposta).NotNull().WithMessage("E-posta boş geçilemez");
        }
    }
}
