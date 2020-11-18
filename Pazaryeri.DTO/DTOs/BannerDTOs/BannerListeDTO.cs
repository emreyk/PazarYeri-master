using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.DTO.DTOs.BannerDTOs
{
    public class BannerListeDto
    {
        public int id { get; set; }
        public string ad { get; set; }
        public string resim { get; set; }
        public string tip { get; set; }
        public string kategori_adi { get; set; }
        public string ust_kategori_adi { get; set; }
        public Kategori Kategori { get; set; }
    }
}
