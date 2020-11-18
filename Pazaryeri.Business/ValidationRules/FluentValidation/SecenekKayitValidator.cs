using FluentValidation;
using Pazaryeri.DTO.DTOs.SecenekDTOs;
using System.Data;

namespace Pazaryeri.Business.ValidationRules.FluentValidation
{
    public class SecenekKayitValidator : AbstractValidator<SecenekKaydetDTO>
    {
        public SecenekKayitValidator()
        {
            RuleFor(I => I.ad).NotNull().WithMessage("Seçenek adını giriniz");
        }
    }
}
