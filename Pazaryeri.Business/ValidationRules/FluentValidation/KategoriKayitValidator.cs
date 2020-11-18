using FluentValidation;
using Pazaryeri.DTO.DTOs.KategoriDTOs;

namespace Pazaryeri.Business.ValidationRules.FluentValidation
{
    public class KategoriKayitValidator : AbstractValidator<KategoriEkleDTO>
    {
        public KategoriKayitValidator()
        {
            RuleFor(I => I.id).ExclusiveBetween(-1, int.MaxValue).WithMessage("Kategori seçiniz");
            RuleFor(I => I.kategori_adi).NotNull().WithMessage("Kategori adı gereklidir");

        }
    }
}
