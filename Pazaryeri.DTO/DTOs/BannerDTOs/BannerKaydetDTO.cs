using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.DTO.DTOs.BannerDTOs
{
    public class BannerKaydetDTO
    {
        public int id { get; set; }
        public string ad { get; set; }
        public string resim { get; set; }
        public string tip { get; set; }
        public int KategoriId { get; set; }
    }
}
