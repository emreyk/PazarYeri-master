using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Pazaryeri.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index(string returnUrl = null)
        {
            string[] words = returnUrl.Split('/');

            return LocalRedirect("/"+words[1]+"/Home");
          }

        public IActionResult Login(string returnUrl = null)
        {
            string[] words = returnUrl.Split('/');

            return LocalRedirect("/" + words[1] + "/Home");
        }

    }
}
