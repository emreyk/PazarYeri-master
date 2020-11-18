using Pazaryeri.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Entities.Concrete
{
    public class Magaza:ITablo
    {
        public int id { get; set; }
        public string tip { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string telefon { get; set; }
        public string eposta { get; set; }
        public string sifre { get; set; }
        public string tc { get; set; }
        public string magaza_adi { get; set; }
        public string unvan { get; set; }
        public string vergi_dairesi { get; set; }
        public string vergi_numarasi { get; set; }
        public bool durum { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }


        public List<KategoriTalep> KategoriTalep { get; set; }
    }
}
