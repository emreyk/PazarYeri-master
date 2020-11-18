using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pazaryeri.Business.Interfaces;
using Pazaryeri.DTO.DTOs.SliderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pazaryeri.Web.ViewComponents
{
    public class Slider: ViewComponent
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public Slider(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var sliderModel = _sliderService.GetirHepsi();
            var model = _mapper.Map<List<SliderListeDTO>>(sliderModel);
            return View(model);
        }
    }
}
