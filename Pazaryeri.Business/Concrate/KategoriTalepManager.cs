using Pazaryeri.Business.Interfaces;
using Pazaryeri.DataAccess.Interfaces;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Business.Concrate
{
    public class KategoriTalepManager : IKategoriTalepService
    {
        private readonly IKategoriTalepDal _kategoriTalepDal;

        public KategoriTalepManager(IKategoriTalepDal kategoriTalepDal)
        {
            _kategoriTalepDal = kategoriTalepDal;
        }

        public List<KategoriTalep> GetirHepsi()
        {
            return _kategoriTalepDal.GetirHepsi();
        }

        public KategoriTalep GetirIdile(int id)
        {
            return _kategoriTalepDal.GetirIdile(id);
        }

        public void Guncelle(KategoriTalep tablo)
        {
            _kategoriTalepDal.Guncelle(tablo);
        }

        public void Kaydet(KategoriTalep tablo)
        {
            _kategoriTalepDal.Kaydet(tablo);
        }

        public List<KategoriTalep> MagazaKategoriTalepleri()
        {
            return _kategoriTalepDal.MagazaKategoriTalepleri();
        }

        public void Sil(KategoriTalep tablo)
        {
            _kategoriTalepDal.Sil(tablo);
        }
    }
}
