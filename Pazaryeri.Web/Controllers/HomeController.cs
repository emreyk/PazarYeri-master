using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pazaryeri.Business.Interfaces;
using Pazaryeri.Entities.Concrete;
using Pazaryeri.Web.BaseControllers;
using Pazaryeri.Web.Models;

namespace Pazaryeri.Web.Controllers
{

    public class HomeController : BaseIdentityController
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IKategoriService _kategoriService;
        private readonly ICustomLogger _customLogger;
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
             ICustomLogger customLogger, IKategoriService kategoriService) : base(userManager)
        {
            _signInManager = signInManager;
            _customLogger = customLogger;
            _kategoriService = kategoriService;

        }

        [Route("")]
        [Route("Anasayfa")]
        public IActionResult Index()
        {
            //var kategoriler = _kategoriService.GetirHepsi();

            //AnasayfaViewModel model = new AnasayfaViewModel();

            //model.TumKategoriler = kategoriler;

            return View();
        }

        public IActionResult Error()
        {
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            _customLogger.LogError($"Hatanın oluştuğu yer :{exceptionHandler.Path}\nHatanın mesajı :{exceptionHandler.Error.Message}\nStack Trace :{exceptionHandler.Error.StackTrace}");
            return View();
        }

        public IActionResult Hata()
        {
            throw new Exception("Bu bir hata");
        }
    }
}
