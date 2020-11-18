using Pazaryeri.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Entities.Concrete
{
    public class SecenekMadde:ITablo
    {
        public int id { get; set; }
        public string ad { get; set; }

        public int SecenekId { get; set; }
        public Secenek Secenek { get; set; }
    }
}
