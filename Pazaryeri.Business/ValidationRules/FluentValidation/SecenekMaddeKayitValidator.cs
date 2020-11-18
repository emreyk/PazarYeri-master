using FluentValidation;
using Pazaryeri.DTO.DTOs.SecenekDTOs;
using System.Data;

namespace Pazaryeri.Business.ValidationRules.FluentValidation
{
    public class SecenekMaddeKayitValidator : AbstractValidator<SecenekMaddeKaydetDTO>
    {
        public SecenekMaddeKayitValidator()
        {
            RuleFor(I => I.ad).NotNull().WithMessage("Seçenek adını giriniz");
        }
    }
}
