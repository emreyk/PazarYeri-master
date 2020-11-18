using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pazaryeri.Business.Interfaces;
using Pazaryeri.DTO.DTOs.SliderDTOs;
using Pazaryeri.Entities.Concrete;
using Pazaryeri.Web.StringInfo;

namespace Pazaryeri.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles = RoleInfo.Admin)]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _iweb;

        public SliderController(ISliderService sliderService,
            IMapper mapper, IWebHostEnvironment iweb)
        {
            _mapper = mapper;
            _sliderService = sliderService;
            _iweb = iweb;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SliderListesi()
        {
            var slider = _mapper.Map<List<SliderListeDTO>>(_sliderService.GetirHepsi());
            return Ok(slider);
        }

        public IActionResult Kaydet()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Kaydet(SliderKaydetDTO model, IFormFile resim)
        {
            if (ModelState.IsValid)
            {
                if (resim != null)
                {
                    string uzanti = Path.GetExtension(resim.FileName);
                    string resimAd = Guid.NewGuid() + uzanti;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Slider/" + resimAd);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await resim.CopyToAsync(stream);
                    }

                    model.resim = resimAd;
                }

                _sliderService.Kaydet(_mapper.Map<Slider>(model));

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Duzenle(int id)
        {
            var banner = _mapper.Map<SliderListeDTO>(_sliderService.GetirIdile(id));
            return View(banner);
        }

        [HttpPost]
        public async Task<IActionResult> Duzenle(Slider model, IFormFile resim)
        {
            if (resim != null)
            {
                string uzanti = Path.GetExtension(resim.FileName);
                string resimAd = Guid.NewGuid() + uzanti;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Slider/" + resimAd);

                //resim update olmussa eski resmi sil
                if (model.resim != null)
                {
                    model.resim = Path.Combine(_iweb.WebRootPath, "img/Slider/", model.resim);
                    FileInfo fi = new FileInfo(model.resim);
                    if (fi != null)
                    {
                        System.IO.File.Delete(model.resim);
                        fi.Delete();
                    }
                }

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await resim.CopyToAsync(stream);
                }

                model.resim = resimAd;
            }

            _sliderService.Guncelle(new Slider
            {
                id = model.id,
                ad = model.ad,
                resim = model.resim
            });
            return RedirectToAction("Index");
        }

        public IActionResult Sil(int id)
        {
            var banner = _mapper.Map<SliderListeDTO>(_sliderService.GetirIdile(id));
            return View(banner);
        }

        [HttpPost]
        public IActionResult Sil(Kategori model)
        {
            model.resim = Path.Combine(_iweb.WebRootPath, "img/Slider/", model.resim);
            FileInfo fi = new FileInfo(model.resim);
            if (fi != null)
            {
                System.IO.File.Delete(model.resim);
                fi.Delete();
            }

            _sliderService.Sil(new Slider
            {
                id = model.id
            });
            return RedirectToAction("index");
        }

    }
}
