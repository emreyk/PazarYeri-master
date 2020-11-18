using Pazaryeri.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Entities.Concrete
{
    public class Kategori:ITablo
    {
        public int id { get; set; }
        public string kategori_adi { get; set; }
        public string ust_kategori_adi { get; set; }
        public int ust_kategori_id { get; set; }
        public string seourl { get; set; }
        public bool yayin_durumu { get; set; }
        public int? sira { get; set; }
        public string resim { get; set; } = "default.png";

        public Banner Banner { get; set; }
    }
}
