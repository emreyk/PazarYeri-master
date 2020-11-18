using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pazaryeri.Business.Interfaces;
using Pazaryeri.DTO.DTOs.SecenekDTOs;
using Pazaryeri.Entities.Concrete;
using Pazaryeri.Web.StringInfo;

namespace Pazaryeri.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles = RoleInfo.Admin)]
    public class SecenekController : Controller
    {
        private readonly ISecenekService _secenekService;
        private readonly ISecenekMaddeService _secenekMaddeService;
        private readonly IMapper _mapper;

        public SecenekController(ISecenekService secenekService, ISecenekMaddeService secenekMaddeService,
            IMapper mapper)
        {
            _mapper = mapper;
            _secenekService = secenekService;
            _secenekMaddeService = secenekMaddeService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SecenekListesiJson()
        {
            var secenekler = _mapper.Map<List<SecenekListesiDTO>>(_secenekService.GetirHepsi());
            return Ok(secenekler);
        }

        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(SecenekKaydetDTO model)
        {
            if (ModelState.IsValid)
            {
                _secenekService.Kaydet(new Secenek
                {
                    ad = model.ad
                });

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Duzenle(int id)
        {
            var gelenSecenek = _mapper.Map<SecenekListesiDTO>(_secenekService.GetirIdile(id));
            return View(gelenSecenek);
        }

        [HttpPost]
        public IActionResult Duzenle(Secenek model)
        {
            if (ModelState.IsValid)
            {
                _secenekService.Guncelle(new Secenek
                {
                    id = model.id,
                    ad = model.ad
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Sil(int id)
        {
            TempData["id"] = id;
            var gelenSecenek = _mapper.Map<SecenekListesiDTO>(_secenekService.GetirIdile(id));
            return View(gelenSecenek);
        }

        [HttpPost]
        public IActionResult SecenekSil(Secenek model)
        {

            _secenekService.Sil(new Secenek
            {
                id = Convert.ToInt32(TempData["id"])
            });
            return RedirectToAction("Index");
        }

        public IActionResult Madde(int id)
        {
            TempData["SecenekId"] = id;
            return View();
        }


        [HttpPost]
        public IActionResult Madde(SecenekMaddeKaydetDTO model)
        {
            if (ModelState.IsValid)
            {
                _secenekMaddeService.Kaydet(new SecenekMadde
                {
                    SecenekId = model.id,
                    ad = model.ad
                });

                return RedirectToAction("Madde");
            }
            return View(model);
        }

        public IActionResult MaddeJson()
        {
           

            var maddeler = _mapper.Map<List<SecenekMaddeListesiDTO>>(_secenekMaddeService.SecenekIdyeGore(Convert.ToInt32(TempData["SecenekId"])));
            return Ok(maddeler);
        }

        public IActionResult MaddeSil(int id)
        {
            TempData["maddeId"] = id;
            var gelenSecenek = _mapper.Map<SecenekMaddeListesiDTO>(_secenekMaddeService.GetirIdile(id));
            ViewBag.SecenekId = gelenSecenek.SecenekId;
            return View(gelenSecenek);
        }

        [HttpPost]
        public IActionResult MaddeSil(SecenekMadde model)
        {
            var gelenSecenekId = _mapper.Map<SecenekMaddeListesiDTO>(_secenekMaddeService.GetirIdile(model.id)).SecenekId;
          
           _secenekMaddeService.Sil(new SecenekMadde
            {
                id = Convert.ToInt32(TempData["maddeId"])
            });
            return Redirect($"/admin/secenek/madde/{gelenSecenekId}");
        }

        public IActionResult MaddeDuzenle(int id)
        {
            TempData["maddeId"] = id;
            var gelenSecenek = _mapper.Map<SecenekMaddeListesiDTO>(_secenekMaddeService.GetirIdile(id));
            ViewBag.SecenekId = gelenSecenek.SecenekId;
            ViewBag.Secenekler = _mapper.Map<List<SecenekListesiDTO>>(_secenekService.GetirHepsi());
            return View(gelenSecenek);
        }

        [HttpPost]
        public IActionResult MaddeDuzenle(SecenekMadde model)
        {
            var gelenSecenekId = _mapper.Map<SecenekMaddeListesiDTO>(_secenekMaddeService.GetirIdile(model.id)).SecenekId;

            if (ModelState.IsValid)
            {
                _secenekMaddeService.Guncelle(new SecenekMadde
                {
                    id = model.id,
                    ad = model.ad,
                    SecenekId = model.SecenekId
                });
                return Redirect($"/admin/secenek/madde/{gelenSecenekId}");
            }
            return Redirect($"/admin/secenek/MaddeDuzenle/{gelenSecenekId}");
        }
    }
}
