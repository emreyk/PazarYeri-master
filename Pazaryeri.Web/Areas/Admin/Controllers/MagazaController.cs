using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pazaryeri.Business.Interfaces;
using Pazaryeri.DTO.DTOs.MagazaDTOs;
using Pazaryeri.Entities.Concrete;
using Pazaryeri.Web.StringInfo;

namespace Pazaryeri.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles = RoleInfo.Admin)]
    public class MagazaController : Controller
    {
        private readonly IMagazaService _magazaService;
        private readonly IMapper _mapper;

        public MagazaController(IMagazaService magazaService, IMapper mapper)
        {
            _magazaService = magazaService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MagazaListesiJson()
        {
            var magazalar = _mapper.Map<List<MagazaListesiDto>>(_magazaService.GetirHepsi());
            return Ok(magazalar);
        }

        public IActionResult MagazaOnayla(int id)
        {
            var magazaGelen = _magazaService.GetirIdile(id);
            magazaGelen.durum = true;
            _magazaService.Guncelle(magazaGelen);
            
            return View("index");
        }

        public IActionResult MagazaIptal(int id)
        {
            var magazaGelen = _magazaService.GetirIdile(id);
            magazaGelen.durum = false;
            _magazaService.Guncelle(magazaGelen);

            return View("index");

        }
    }
}
