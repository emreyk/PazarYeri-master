using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pazaryeri.Business.Interfaces;
using Pazaryeri.DTO.DTOs;
using Pazaryeri.Entities.Concrete;
using Pazaryeri.Web.BaseControllers;
using Pazaryeri.Web.StringInfo;

namespace Pazaryeri.Web.Areas.Magaza.Controllers
{
    [Area(AreaInfo.Magaza)]

    public class HomeController : BaseIdentityController
    {
        private readonly IMagazaService _magazaService;
        private readonly SignInManager<AppUser> _signInManager;
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMagazaService magazaService
            ) : base(userManager)
        {
            _magazaService = magazaService;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GirisYap(AppUserGirisDTO model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                var gelenMagaza = _magazaService.MagazaGetirEposta(user.UserName);
                if (user != null && gelenMagaza.durum == true)
                {
                    var sonuc = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                    if (sonuc.Succeeded)
                    {
                        var roller = await _userManager.GetRolesAsync(user);



                        if (roller.Contains("Magaza"))
                        {
                            return RedirectToAction("Index", "Dashboard", new { area = "Magaza" });
                        }
                        else
                        {
                            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                        }
                    }
                }

                ModelState.AddModelError("", "Hatalı kullanıcı bilgileri yada onaysız mağaza");
            }
            return View("Index", model);
        }
        public IActionResult Kaydet()
        {
            return View();
        }


        [Route("magazakaydet")]
        [HttpPost]
        public async Task<IActionResult> MagazaKaydet(MagazaKayitDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser userModel = new AppUser()
                {
                    UserName = model.eposta,
                    Email = model.eposta

                };

                var result = await _userManager.CreateAsync(userModel, model.sifre);
                if (result.Succeeded)
                {
                    var RoleEkleSonuc = await _userManager.AddToRoleAsync(userModel, "Magaza");
                    if (RoleEkleSonuc.Succeeded)
                    {
                        var magazaKullanici = await _userManager.FindByNameAsync(userModel.UserName);

                        _magazaService.Kaydet(new Entities.Concrete.Magaza()
                        {
                            AppUserId = magazaKullanici.Id,
                            ad = model.ad,
                            soyad = model.soyad,
                            eposta = model.eposta,
                            telefon = model.telefon,
                            magaza_adi = model.magaza_adi,
                            tip = model.tip,
                            sifre = model.sifre,
                            tc = model.tc

                        });

                        return RedirectToAction("Index", "Home", new { area = "Magaza" });
                    }
                    HataEkle(RoleEkleSonuc.Errors);
                }
                HataEkle(result.Errors);
            }
            return View("Kaydet", model);
        }

    }
}
