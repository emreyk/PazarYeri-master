using Pazaryeri.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Entities.Concrete
{
    public class Uye : ITablo
    {
        public int id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string telefon { get; set; }
        public string eposta { get; set; }
        public string sifre { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
