using Pazaryeri.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Entities.Concrete
{
    public class Banner:ITablo
    {
        public int id { get; set; }
        public string ad { get; set; }
        public string resim { get; set; }
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
        public string tip { get; set; }
    }
}
