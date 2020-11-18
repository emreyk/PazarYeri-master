using FluentValidation;
using Pazaryeri.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Business.ValidationRules.FluentValidation
{
    public class MagazaKayitValidator : AbstractValidator<MagazaKayitDTO>
    {
        public MagazaKayitValidator()
        {
            RuleFor(I => I.ad).NotNull().WithMessage("Ad boş geçilemez");
            RuleFor(I => I.soyad).NotNull().WithMessage("Soyad adı boş geçilemez");
            RuleFor(I => I.sifre).NotNull().WithMessage("Şifre adı boş geçilemez");
            RuleFor(I => I.telefon).NotNull().WithMessage("Telefon boş geçilemez");
            RuleFor(I => I.tc).NotNull().WithMessage("Tc boş geçilemez");
            RuleFor(I => I.magaza_adi).NotNull().WithMessage("Mağaza adı boş geçilemez");
            RuleFor(I => I.eposta).NotNull().WithMessage("E-posta boş geçilemez");
          
        }
    }
}
