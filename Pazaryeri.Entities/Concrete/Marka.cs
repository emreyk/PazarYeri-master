using Pazaryeri.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Entities.Concrete
{
    public class Marka:ITablo
    {
        public int id { get; set; }
        public string ad { get; set; }
        public string seourl { get; set; }
        public string resim { get; set; } = "default.png";
      
    }
}
