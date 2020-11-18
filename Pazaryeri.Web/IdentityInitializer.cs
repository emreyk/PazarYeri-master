using Microsoft.AspNetCore.Identity;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pazaryeri.Web
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }

            var memberRoleMagaza = await roleManager.FindByNameAsync("Magaza");
            if (memberRoleMagaza == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Magaza" });
            }

            var memberRoleUye = await roleManager.FindByNameAsync("Uye");
            if (memberRoleUye == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Uye" });
            }


            var adminUser = await userManager.FindByNameAsync("admin");
            if (adminUser == null)
            {
                AppUser user = new AppUser
                {
                    UserName = "admin",
                    Email = "admin"
                };
                await userManager.CreateAsync(user, "admin");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
