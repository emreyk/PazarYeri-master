using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pazaryeri.Business.Interfaces;
using Pazaryeri.DTO.DTOs.KategoriDTOs;
using Pazaryeri.Entities.Concrete;
using Pazaryeri.Web.StringInfo;

namespace Pazaryeri.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles = RoleInfo.Admin)]
    public class KategoriController : Controller
    {
        private readonly IKategoriService _kategoriService;
        private readonly IKategoriTalepService _kategoriTalepService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _iweb;
        public KategoriController(IKategoriService kategoriService, IMapper mapper,
         IKategoriTalepService kategoriTalepService, IWebHostEnvironment iweb,IMagazaService magaza)
        {
            _mapper = mapper;
            _kategoriService = kategoriService;
            _kategoriTalepService = kategoriTalepService;
            _iweb = iweb;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult KategoriListesi()
        {
            List<KategoriListeDTO> kategoriler = _mapper.Map<List<KategoriListeDTO>>(_kategoriService.GetirHepsi());
            return Ok(kategoriler);
        }
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(KategoriEkleDTO model, IFormFile resim)
        {
            if (ModelState.IsValid)
            {
                var kategoriGelen = _kategoriService.GetirIdile(model.id);

                if (model.id == 0)
                {
                    model.ust_kategori_adi = "Anakategori";
                    model.ust_kategori_id = 0;
                }
                else
                {
                    model.ust_kategori_adi = kategoriGelen.kategori_adi;
                    model.ust_kategori_id = model.id;
                }

                if (resim != null)
                {
                    string uzanti = Path.GetExtension(resim.FileName);
                    string resimAd = Guid.NewGuid() + uzanti;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Kategori/" + resimAd);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await resim.CopyToAsync(stream);
                    }

                    model.resim = resimAd;
                }

                _kategoriService.Kaydet(new Kategori
                {
                    kategori_adi = model.kategori_adi,
                    ust_kategori_adi = model.ust_kategori_adi,
                    ust_kategori_id = model.ust_kategori_id,
                    seourl = model.seourl,
                    sira = model.sira,
                    resim = model.resim,
                    yayin_durumu = model.yayin_durumu
                });

                return RedirectToAction("Index");
            }

            return View(model);
        }


        public IActionResult Sil(int id)
        {
            var gelenKategori = _mapper.Map<KategoriListeDTO>(_kategoriService.GetirIdile(id));
            return View(gelenKategori);
        }

        [HttpPost]
        public IActionResult Sil(Kategori model)
        {
            if (model.resim != "default.png")
            {
                model.resim = Path.Combine(_iweb.WebRootPath, "img/Kategori/", model.resim);
                FileInfo fi = new FileInfo(model.resim);
                if (fi != null)
                {
                    System.IO.File.Delete(model.resim);
                    fi.Delete();
                }
            }

            _kategoriService.Sil(new Kategori
            {
                id = model.id
            });
            return RedirectToAction("Index");
        }
        public IActionResult Duzenle(int id)
        {
            TempData["id"] = id;
            ViewBag.TumKategoriler = _mapper.Map<List<KategoriListeDTO>>(_kategoriService.GetirHepsi());
            var gelenKategori = _mapper.Map<KategoriListeDTO>(_kategoriService.GetirIdile(id));
            return View(gelenKategori);
        }

        [HttpPost]
        public async Task<IActionResult> Duzenle(KategoriListeDTO model, IFormFile resim)
        {
            //model.id = Convert.ToInt32(TempData["id"]);
            var kategoriGelen = _kategoriService.GetirIdile(model.id);

            if (ModelState.IsValid)
            {
              
                if (resim != null)
                {
                    string uzanti = Path.GetExtension(resim.FileName);
                    string resimAd = Guid.NewGuid() + uzanti;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Kategori/" + resimAd);

                    //resim update olmussa eski resmi sil
                    if (model.resim != "default.png")
                    {
                        model.resim = Path.Combine(_iweb.WebRootPath, "img/Kategori/", model.resim);
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

                

                //farklı bir kategori seçilmemişse
                if (Convert.ToInt32(TempData["id"]) == model.id)
                {
                    _kategoriService.Guncelle(new Kategori()
                    {
                        id = Convert.ToInt32(TempData["id"]),
                        kategori_adi = model.kategori_adi,
                        ust_kategori_adi = kategoriGelen.ust_kategori_adi,
                        ust_kategori_id = kategoriGelen.ust_kategori_id,
                        seourl = model.seourl,
                        yayin_durumu = model.yayin_durumu,
                        //sira = model.sira,
                        resim = model.resim
                    });
                }

                //farklı bir kategori seçilip güncelleme yapılmışsa
                if (Convert.ToInt32(TempData["id"]) != model.id && model.id != 0)
                {
                    _kategoriService.Guncelle(new Kategori()
                    {
                        id = Convert.ToInt32(TempData["id"]),
                        kategori_adi = model.kategori_adi,
                        ust_kategori_adi = kategoriGelen.kategori_adi,
                        ust_kategori_id = kategoriGelen.id,
                        seourl = model.seourl,
                        yayin_durumu = model.yayin_durumu,
                        //sira = model.sira,
                        resim = model.resim
                    });
                }

                //anakategori seçilip güncelleme yapılmışsa
                if (model.id == 0)
                {
                    _kategoriService.Guncelle(new Kategori()
                    {
                        id = Convert.ToInt32(TempData["id"]),
                        kategori_adi = model.kategori_adi,
                        ust_kategori_adi = "Anakategori",
                        ust_kategori_id = 0,
                        seourl = model.seourl,
                        yayin_durumu = model.yayin_durumu,
                        //sira = model.sira,
                        resim = model.resim
                    });
                }

               
              

                return RedirectToAction("Index");
            };

            var gelenKategori = _mapper.Map<KategoriListeDTO>(_kategoriService.GetirIdile(model.id));
            ViewBag.TumKategoriler = _mapper.Map<List<KategoriListeDTO>>(_kategoriService.GetirHepsi());
            return View(model);
        }

        public IActionResult KategoriTalepleri()
        {
          
            return View(); 
        }
        public IActionResult KategoriListesiJson()
        {
            var kategoriTalepleri = _mapper.Map<List<KategoriTalepleriDTO>>(_kategoriTalepService.MagazaKategoriTalepleri());
            return Ok(kategoriTalepleri);
        }

      
        public IActionResult TalepOnayla(int id)
        {
            var guncellencekTalep = _kategoriTalepService.GetirIdile(id);
            guncellencekTalep.durum = true;
            _kategoriTalepService.Guncelle(guncellencekTalep);

            KategoriEkleDTO model = new KategoriEkleDTO();

            if (guncellencekTalep.ust_kategori_id == 0)
            {
                model.ust_kategori_adi = "Anakategori";
                model.ust_kategori_id = 0;
            }
            else
            {
                model.ust_kategori_adi = guncellencekTalep.kategori_adi;
                model.ust_kategori_id = (int)guncellencekTalep.ust_kategori_id;
            }

           

            _kategoriService.Kaydet(new Kategori
            {
                kategori_adi = guncellencekTalep.kategori_adi,
                ust_kategori_adi = guncellencekTalep.ust_kategori_adi,
                ust_kategori_id = (int)guncellencekTalep.ust_kategori_id,
                seourl = guncellencekTalep.seourl,
                sira = guncellencekTalep.sira,
                resim = guncellencekTalep.resim,
                yayin_durumu = guncellencekTalep.yayin_durumu
            });

            return RedirectToAction("KategoriTalepleri");
        }

        public IActionResult KategoriTalepSil(int id)
        {
            var gelenKategoriTalep = _mapper.Map<KategoriTalepleriDTO>(_kategoriTalepService.GetirIdile(id));
            return View(gelenKategoriTalep);
        }

        [HttpPost]
        public IActionResult KategoriTalepSil(KategoriTalep model)
        {
            if (model.resim != "default.png")
            {
                model.resim = Path.Combine(_iweb.WebRootPath, "img/Kategori/", model.resim);
                FileInfo fi = new FileInfo(model.resim);
                if (fi != null)
                {
                    System.IO.File.Delete(model.resim);
                    fi.Delete();
                }
            }
            
            _kategoriTalepService.Sil(new KategoriTalep
            {
                id = model.id
            });
            return RedirectToAction("KategoriTalepleri");
        }
     
    }
}
