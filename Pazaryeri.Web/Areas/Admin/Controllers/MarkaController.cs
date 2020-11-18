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
using Pazaryeri.DTO.DTOs.MarkaDTOs;
using Pazaryeri.Entities.Concrete;
using Pazaryeri.Web.StringInfo;

namespace Pazaryeri.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles = RoleInfo.Admin)]
    public class MarkaController : Controller
    {
        private readonly IMarkaService _markaService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _iweb;

        public MarkaController(IMarkaService markaService,
            IMapper mapper, IWebHostEnvironment iweb)
        {
            _mapper = mapper;
            _markaService = markaService;
            _iweb = iweb;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MarkaListesiJson()
        {
            var markalar = _mapper.Map<List<MarkaGenelDTO>>(_markaService.GetirHepsi());
            return Ok(markalar);
        }

        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Ekle(MarkaGenelDTO model, IFormFile resim)
        {
            if (ModelState.IsValid)
            {
                if (resim != null)
                {
                    string uzanti = Path.GetExtension(resim.FileName);
                    string resimAd = Guid.NewGuid() + uzanti;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Marka/" + resimAd);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await resim.CopyToAsync(stream);
                    }

                    model.resim = resimAd;
                }

                _markaService.Kaydet(new Marka
                {
                    ad = model.ad,
                    seourl = model.seourl,
                    resim = model.resim
                });

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Duzenle(int id)
        {
            var gelenMarka = _mapper.Map<MarkaGenelDTO>(_markaService.GetirIdile(id));
            return View(gelenMarka);
        }

        [HttpPost]
        public async Task<IActionResult> Duzenle(Marka model, IFormFile resim)
        {
            if (ModelState.IsValid)
            {
                if (resim != null)
                {
                    string uzanti = Path.GetExtension(resim.FileName);
                    string resimAd = Guid.NewGuid() + uzanti;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Marka/" + resimAd);

                    //resim update olmussa eski resmi sil
                    if (model.resim != "default.png")
                    {
                        model.resim = Path.Combine(_iweb.WebRootPath, "img/Marka/", model.resim);
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



                _markaService.Guncelle(new Marka
                {
                    id = model.id,
                    ad = model.ad,
                    seourl = model.seourl,
                    resim = model.resim
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Sil(int id)
        {
            TempData["id"] = id;
            var gelenMarka = _mapper.Map<MarkaGenelDTO>(_markaService.GetirIdile(id));
            return View(gelenMarka);
        }

        [HttpPost]
        public IActionResult MarkaSil(Marka model)
        {
            if (model.resim != "default.png")
            {
                model.resim = Path.Combine(_iweb.WebRootPath, "img/Marka/", model.resim);
                FileInfo fi = new FileInfo(model.resim);
                if (fi != null)
                {
                    System.IO.File.Delete(model.resim);
                    fi.Delete();
                }
            }
            _markaService.Sil(new Marka
            {
                id = Convert.ToInt32(TempData["id"])
            });
            return RedirectToAction("Index");
        }

    }
}
