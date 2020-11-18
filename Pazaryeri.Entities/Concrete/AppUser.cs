using Microsoft.AspNetCore.Identity;
using Pazaryeri.Entities.Interface;

namespace Pazaryeri.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, ITablo
    {
     
        public Magaza Magaza { get; set; }
        public Uye Uye { get; set; }
    }
}
