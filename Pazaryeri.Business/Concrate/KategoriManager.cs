using Pazaryeri.Business.Interfaces;
using Pazaryeri.DataAccess.Interfaces;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Business.Concrate
{
    public class KategoriManager : IKategoriService
    {
        private readonly IKategoriDal _kategoriDal;

        public KategoriManager(IKategoriDal kategoriDal)
        {
            _kategoriDal = kategoriDal;
        }

        public List<Kategori> GetirHepsi()
        {
            return _kategoriDal.GetirHepsi();
        }

        public Kategori GetirIdile(int id)
        {
            return _kategoriDal.GetirIdile(id);
        }

        public void Guncelle(Kategori tablo)
        {
            _kategoriDal.Guncelle(tablo);
        }

        public void Kaydet(Kategori tablo)
        {
            _kategoriDal.Kaydet(tablo);
        }

        public void Sil(Kategori tablo)
        {
            _kategoriDal.Sil(tablo);
        }
    }
}
