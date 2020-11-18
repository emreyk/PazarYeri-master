using Pazaryeri.Business.Interfaces;
using Pazaryeri.DataAccess.Interfaces;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Pazaryeri.Business.Concrate
{
    public class MarkaManager: IMarkaService
    {
        private readonly IMarkaDal _markaDal;

        public MarkaManager(IMarkaDal markaDal)
        {
            _markaDal = markaDal;
        }

        public List<Marka> GetirHepsi()
        {
            return _markaDal.GetirHepsi();
        }

        public Marka GetirIdile(int id)
        {
            return _markaDal.GetirIdile(id);
        }

        public void Guncelle(Marka tablo)
        {
            _markaDal.Guncelle(tablo);
        }

        public void Kaydet(Marka tablo)
        {
            _markaDal.Kaydet(tablo);
        }

        public void Sil(Marka tablo)
        {
            _markaDal.Sil(tablo);
        }
    }
}
