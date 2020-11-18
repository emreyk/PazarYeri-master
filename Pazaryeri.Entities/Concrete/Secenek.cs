using Pazaryeri.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Entities.Concrete
{
    public class Secenek:ITablo
    {
        public int id { get; set; }
        public string ad { get; set; }

        public List<SecenekMadde> SecenekMadde { get; set; }

    }
}
