using FluentValidation;
using Pazaryeri.DTO.DTOs.SliderDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Business.ValidationRules.FluentValidation
{
    public class SliderKayitValidator : AbstractValidator<SliderKaydetDTO>
    {
        public SliderKayitValidator()
        {
            RuleFor(I => I.ad).NotNull().WithMessage("Ad boş geçilemez");
           
        }
    }
}
