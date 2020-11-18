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
    [Authorize(Roles = RoleInfo.Admin)]
 
    public class DashboardController : BaseIdentityController
    {
        private readonly SignInManager<AppUser> _signInManager;
        public DashboardController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(userManager)
        {
            _signInManager = signInManager;

        }

        public IActionResult Index()
        {
            return View();
        }

      
    }
}
