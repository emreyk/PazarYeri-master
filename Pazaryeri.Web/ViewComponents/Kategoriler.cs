using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pazaryeri.Business.Interfaces;
using Pazaryeri.DTO.DTOs.KategoriDTOs;
using System.Collections.Generic;

namespace Pazaryeri.Web.ViewComponents
{
    public class Kategoriler : ViewComponent
    {
        private readonly IKategoriService _kategoriService;
        private readonly IMapper _mapper;

        public Kategoriler(IKategoriService kategoriService, IMapper mapper)
        {
            _kategoriService = kategoriService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var kategoriModel = _kategoriService.GetirHepsi();
            var model = _mapper.Map<List<KategoriListeDTO>>(kategoriModel);
            return View(model);
        }
    }
}
