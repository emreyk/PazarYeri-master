using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pazaryeri.DTO.DTOs;
using Pazaryeri.Entities.Concrete;
using Pazaryeri.Web.BaseControllers;
using Pazaryeri.Web.StringInfo;

namespace Pazaryeri.Web.Areas.Admin.Controllers
{

    [Area(AreaInfo.Admin)]
    public class HomeController : BaseIdentityController
    {
        private readonly SignInManager<AppUser> _signInManager;
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(userManager)
        {
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
                if (user != null)
                {
                    var sonuc = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                    if (sonuc.Succeeded)
                    {
                        var roller = await _userManager.GetRolesAsync(user);

 


                        if (roller.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "dashboard", new { area = "Admin" });
                        }
                        else
                        {
                            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                        }
                    }
                }

                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            }
            return View("Index", model);
        }



        public IActionResult CategoryRequest()
        {
            var user =  GetirGirisYapanKullanici();

            return Ok(user.Result.PhoneNumber);
        }
    }
}