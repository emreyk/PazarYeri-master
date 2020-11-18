using Pazaryeri.Business.Interfaces;
using Pazaryeri.DataAccess.Interfaces;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Business.Concrate
{
    public class SecenekMaddeManager : ISecenekMaddeService
    {
        private ISecenekMaddeDal _secenekMaddeDal;
        public SecenekMaddeManager(ISecenekMaddeDal secenekMaddeDal)
        {
            _secenekMaddeDal = secenekMaddeDal;
        }
        public List<SecenekMadde> GetirHepsi()
        {
           return _secenekMaddeDal.GetirHepsi();
        }

        public SecenekMadde GetirIdile(int id)
        {
            return _secenekMaddeDal.GetirIdile(id);
        }

        public void Guncelle(SecenekMadde tablo)
        {
            _secenekMaddeDal.Guncelle(tablo);
        }

        public void Kaydet(SecenekMadde tablo)
        {
            _secenekMaddeDal.Kaydet(tablo);
        }

        public List<SecenekMadde> SecenekIdyeGore(int id)
        {
            return _secenekMaddeDal.SecenekIdyeGore(id);
        }

        public void Sil(SecenekMadde tablo)
        {
            _secenekMaddeDal.Sil(tablo);
        }
    }
}
