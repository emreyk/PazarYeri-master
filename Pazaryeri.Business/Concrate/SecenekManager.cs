using Pazaryeri.Business.Interfaces;
using Pazaryeri.DataAccess.Interfaces;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Pazaryeri.Business.Concrate
{
    public class SecenekManager : ISecenekService
    {
        private readonly ISecenekDal _secenekDal;

        public SecenekManager(ISecenekDal secenekDal)
        {
            _secenekDal = secenekDal;
        }

        public List<Secenek> GetirHepsi()
        {
            return _secenekDal.GetirHepsi();
        }

        public Secenek GetirIdile(int id)
        {
            return _secenekDal.GetirIdile(id);
        }

        public void Guncelle(Secenek tablo)
        {
             _secenekDal.Guncelle(tablo);
        }

        public void Kaydet(Secenek tablo)
        {
            _secenekDal.Kaydet(tablo);
        }

        public void Sil(Secenek tablo)
        {
            _secenekDal.Sil(tablo);
        }
    }
}
