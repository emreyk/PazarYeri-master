using AutoMapper;
using Pazaryeri.DataAccess.Migrations;
using Pazaryeri.DTO.DTOs;
using Pazaryeri.DTO.DTOs.BannerDTOs;
using Pazaryeri.DTO.DTOs.KategoriDTOs;
using Pazaryeri.DTO.DTOs.MagazaDTOs;
using Pazaryeri.DTO.DTOs.MarkaDTOs;
using Pazaryeri.DTO.DTOs.SecenekDTOs;
using Pazaryeri.DTO.DTOs.SliderDTOs;
using Pazaryeri.Entities.Concrete;

namespace Pazaryeri.Web.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<MagazaKayitDTO, Magaza>();
            CreateMap<Magaza, MagazaKayitDTO>();


            CreateMap<KategoriListeDTO, Kategori>();
            CreateMap<Kategori, KategoriListeDTO>();
            CreateMap<KategoriEkleDTO, Kategori>();
            CreateMap<Kategori, KategoriEkleDTO>();
            CreateMap<KategoriTalepleriDTO, KategoriTalep>();
            CreateMap<KategoriTalep, KategoriTalepleriDTO>();

            CreateMap<SecenekListesiDTO, Secenek>();
            CreateMap<Secenek, SecenekListesiDTO>();
            CreateMap<SecenekMaddeListesiDTO, SecenekMadde>();
            CreateMap<SecenekMadde, SecenekMaddeListesiDTO>();

            CreateMap<MarkaGenelDTO, Marka>();
            CreateMap<Marka, MarkaGenelDTO>();

            CreateMap<MagazaListesiDto, Magaza>();
            CreateMap<Magaza, MagazaListesiDto>();

            CreateMap<Banner, BannerKaydetDTO>();
            CreateMap<BannerKaydetDTO, Banner>();
            CreateMap<Banner, BannerListeDto>();
            CreateMap<BannerListeDto, Banner>();

            CreateMap<Slider, SliderKaydetDTO>();
            CreateMap<SliderKaydetDTO, Slider>();
            CreateMap<Slider, SliderListeDTO>();
            CreateMap<SliderListeDTO, Slider>();
        }
    }
}
