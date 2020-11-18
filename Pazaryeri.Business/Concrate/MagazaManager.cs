using Pazaryeri.Business.Interfaces;
using Pazaryeri.DataAccess.Interfaces;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Business.Concrate
{
    public class MagazaManager : IMagazaService
    {
        private readonly IMagazaDal _magazaDal;

        public MagazaManager(IMagazaDal magazaDal)
        {
            _magazaDal = magazaDal;
        }

        public List<Magaza> GetirHepsi()
        {
            return _magazaDal.GetirHepsi();
        }
        public Magaza GetirMagazaLogin(string eposta, string sifre)
        {
            return _magazaDal.MagazaGetirŞifre(eposta, sifre);
        }
        public Magaza GetirIdile(int id)
        {
            return _magazaDal.GetirIdile(id);
        }

        public void Guncelle(Magaza tablo)
        {
            _magazaDal.Guncelle(tablo);
        }

        public void Kaydet(Magaza tablo)
        {
            _magazaDal.Kaydet(tablo);
        }

        public Magaza MagazaGetirEposta(string eposta)
        {
            return _magazaDal.MagazaGetirEposta(eposta);
        }

        public void Sil(Magaza tablo)
        {
            _magazaDal.Sil(tablo);
        }
    }
}
