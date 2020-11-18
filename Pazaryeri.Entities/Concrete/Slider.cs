using Pazaryeri.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Entities.Concrete
{
    public class Slider:ITablo
    {
        public int id { get; set; }
        public string ad { get; set; }
        public string resim { get; set; }
    }
}
