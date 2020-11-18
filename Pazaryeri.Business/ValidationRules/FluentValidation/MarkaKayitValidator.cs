using FluentValidation;
using Pazaryeri.DTO.DTOs.MarkaDTOs;

namespace Pazaryeri.Business.ValidationRules.FluentValidation
{
    public class MarkaKayitValidator : AbstractValidator<MarkaGenelDTO>
    {
        public MarkaKayitValidator()
        {
            RuleFor(I => I.ad).NotNull().WithMessage("Marka adını giriniz");
            RuleFor(I => I.seourl).NotNull().WithMessage("Seourl  giriniz");
        }
    }
}
