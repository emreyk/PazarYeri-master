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
using Pazaryeri.DTO.DTOs.BannerDTOs;
using Pazaryeri.DTO.DTOs.KategoriDTOs;
using Pazaryeri.Entities.Concrete;
using Pazaryeri.Web.StringInfo;

namespace Pazaryeri.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles = RoleInfo.Admin)]
    public class TasarimController : Controller
    {

        private readonly IBannerService _bannerService;
        private readonly IKategoriService _kategoriService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _iweb;


        public TasarimController(IBannerService bannerService,
           IMapper mapper, IWebHostEnvironment iweb, IKategoriService kategoriService)
        {
            _mapper = mapper;
            _bannerService = bannerService;
            _iweb = iweb;
            _kategoriService = kategoriService;
        }

        public IActionResult Index(int id)
        {

            return View();
        }

        public IActionResult BannerListesi()
        {
            List<BannerListeDto> banner = _mapper.Map<List<BannerListeDto>>(_bannerService.BannerTipGetir());
            return Ok(banner);
        }


        public IActionResult Kaydet()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Kaydet(BannerKaydetDTO model, IFormFile resim)
        {
            if (ModelState.IsValid)
            {
                if (resim != null)
                {
                    string uzanti = Path.GetExtension(resim.FileName);
                    string resimAd = Guid.NewGuid() + uzanti;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Banner/" + resimAd);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await resim.CopyToAsync(stream);
                    }

                    model.resim = resimAd;
                }


                _bannerService.Kaydet(_mapper.Map<Banner>(model));

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Sil(int id)
        {
            var banner = _mapper.Map<BannerListeDto>(_bannerService.GetirIdile(id));
            return View(banner);
        }

        [HttpPost]
        public IActionResult Sil(Kategori model)
        {
            model.resim = Path.Combine(_iweb.WebRootPath, "img/Banner/", model.resim);
            FileInfo fi = new FileInfo(model.resim);
            if (fi != null)
            {
                System.IO.File.Delete(model.resim);
                fi.Delete();
            }

            _bannerService.Sil(new Banner
            {
                id = model.id
            });
            return RedirectToAction("index");
        }


        public IActionResult Duzenle(int id)
        {
            var banner = _mapper.Map<BannerListeDto>(_bannerService.GetirIdile(id));
            ViewBag.TumKategoriler = _mapper.Map<List<KategoriListeDTO>>(_kategoriService.GetirHepsi());
            return View(banner);
        }

        [HttpPost]
        public async Task<IActionResult> Duzenle(Banner model, IFormFile resim)
        {
            if (resim != null)
            {
                string uzanti = Path.GetExtension(resim.FileName);
                string resimAd = Guid.NewGuid() + uzanti;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Banner/" + resimAd);

                //resim update olmussa eski resmi sil
                if (model.resim != null)
                {
                    model.resim = Path.Combine(_iweb.WebRootPath, "img/Banner/", model.resim);
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

            _bannerService.Guncelle(new Banner
            {
                id = model.id,
                ad = model.ad,
                KategoriId = model.KategoriId,
                tip = model.tip,
                resim = model.resim
            });
            return RedirectToAction("Index");
        }

    }
}
