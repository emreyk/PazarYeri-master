using FluentValidation;
using Pazaryeri.DTO.DTOs.SecenekDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Business.ValidationRules.FluentValidation
{
    public class SecenekGuncelleValidator : AbstractValidator<SecenekUpdateDTO>
    {
        public SecenekGuncelleValidator()
        {
            RuleFor(I => I.ad).NotNull().WithMessage("Seçenek adını giriniz");
        }
    }
}
