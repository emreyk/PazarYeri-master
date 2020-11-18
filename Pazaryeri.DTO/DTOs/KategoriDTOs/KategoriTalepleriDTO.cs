﻿using Pazaryeri.Entities.Concrete;

namespace Pazaryeri.DTO.DTOs.KategoriDTOs
{
    public class KategoriTalepleriDTO
    {
        public int id { get; set; }
        public bool durum { get; set; }
        public string kategori_adi { get; set; }
        public string ust_kategori_adi { get; set; }
        public int? ust_kategori_id { get; set; }
        public string seourl { get; set; }
        public bool yayin_durumu { get; set; }
        public int? sira { get; set; }
        public string resim { get; set; } = "default.png";

        public int? magaza_id { get; set; }
        public Magaza Magaza { get; set; }
    }
}
