using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pazaryeri.Business.Interfaces;
using Pazaryeri.DTO.DTOs;
using Pazaryeri.DTO.DTOs.KategoriDTOs;
using Pazaryeri.Entities.Concrete;
using Pazaryeri.Web.BaseControllers;
using Pazaryeri.Web.StringInfo;

namespace Pazaryeri.Web.Areas.Magaza.Controllers
{

    [Area(AreaInfo.Magaza)]
    [Authorize(Roles = RoleInfo.Magaza)]
     public class DashboardController : BaseIdentityController
    {
        private readonly IMagazaService _magazaService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IKategoriTalepService _kategoriTalepService;
        private readonly IKategoriService _kategoriService;

        public DashboardController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IMagazaService magazaService, IKategoriService kategoriService, IKategoriTalepService kategoriTalepService
            ) : base(userManager)
        {
            _magazaService = magazaService;
            _signInManager = signInManager;
            _kategoriTalepService = kategoriTalepService;
            _kategoriService = kategoriService;

        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult KategoriTalep()
        {
            return View();
        }
        public IActionResult KategoriEkle()
        {
            return View();
        }
        public IActionResult GetMagaza()
        {
            var user = GetirGirisYapanKullanici().Result;


            return Ok(user);
        }

        public IActionResult KategoriTalepListesi()
        {
            int kullanıcı_id = 1;

            //try
            //{
            //    var user = GetirGirisYapanKullanici().Result;
            //    kullanıcı_id = user.Id;
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            var list = _kategoriTalepService.GetirHepsi().Where(e=>e.magaza_id==kullanıcı_id);


            return Ok(list);
        }


        [HttpPost]
        public async Task<IActionResult> KategoriEkle(KategoriEkleDTO model, IFormFile resim)
        {
            var user = GetirGirisYapanKullanici();
            if (ModelState.IsValid)
            {
                var kategoriGelen = _kategoriService.GetirIdile(model.id);
                int magaza_id = 1;
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

                _kategoriTalepService.Kaydet(new KategoriTalep
                {
                    magaza_id = magaza_id,
                    //durum=0,
                    kategori_adi = model.kategori_adi,
                    ust_kategori_adi = model.ust_kategori_adi,
                    ust_kategori_id = model.ust_kategori_id,
                    seourl = model.seourl,
                    sira = model.sira,
                    resim = model.resim,
                    yayin_durumu = model.yayin_durumu
                }); ;

                return RedirectToAction("Index");
            }

            return View(model);
        }


 
    }
}


