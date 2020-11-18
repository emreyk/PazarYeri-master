using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.DTO.DTOs.MagazaDTOs
{
    public class MagazaListesiDto
    {
        public int id { get; set; }
        public string magaza_adi { get; set; }
        public string telefon { get; set; }
        public string tip { get; set; }
        public bool durum { get; set; }
        public string eposta { get; set; }
    }
}
