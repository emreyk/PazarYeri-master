using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pazaryeri.Entities.Concrete;
using Pazaryeri.Web.BaseControllers;
using Pazaryeri.Web.StringInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pazaryeri.Web.Areas.Magaza.Controllers
{
    [Area(AreaInfo.Magaza)]
    [Authorize(Roles = RoleInfo.Magaza)]
    public class UrunController : BaseIdentityController
    {
        public UrunController(UserManager<AppUser> userManager) : base(userManager)
        {
        }

        public IActionResult Index()
        {
            return View();
        }




        public IActionResult UrunEkle()
        {
            return View();
        }
    }
}
