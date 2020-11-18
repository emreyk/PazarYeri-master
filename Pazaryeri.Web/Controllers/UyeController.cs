using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pazaryeri.Business.Interfaces;
using Pazaryeri.DTO.DTOs.AppUserDTOs;
using Pazaryeri.Entities.Concrete;
using Pazaryeri.Web.BaseControllers;

namespace Pazaryeri.Web.Controllers
{
    public class UyeController : BaseIdentityController
    {
        private readonly IUyeService _uyeService;
        private readonly SignInManager<AppUser> _signInManager;

        public UyeController(UserManager<AppUser> userManager, IUyeService uyeService
         ) : base(userManager)
        {
            _uyeService = uyeService;
           

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Kayit(UyeKayitDTO model)
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
                    var RoleEkleSonuc = await _userManager.AddToRoleAsync(userModel, "Uye");
                    if (RoleEkleSonuc.Succeeded)
                    {
                        var uye = await _userManager.FindByNameAsync(userModel.UserName);
                        _uyeService.Kaydet(new Entities.Concrete.Uye()
                        {
                            AppUserId = uye.Id,
                            ad = model.ad,
                            soyad = model.soyad,
                            eposta = model.eposta,
                            telefon = model.telefon,
                            sifre = model.sifre
                            
                        });

                        return RedirectToAction("Index");
                    }

                    HataEkle(RoleEkleSonuc.Errors);
                }
                HataEkle(result.Errors);
            }


            return View(model);
        }

    }
}
