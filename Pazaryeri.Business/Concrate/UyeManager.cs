using Pazaryeri.Business.Interfaces;
using Pazaryeri.DataAccess.Interfaces;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Business.Concrate
{
    public class UyeManager:IUyeService
    {
        private readonly IUyeDal _uyeDal;

        public UyeManager(IUyeDal uyeDal)
        {
            _uyeDal = uyeDal;
        }

        public List<Uye> GetirHepsi()
        {
            throw new NotImplementedException();
        }

        public Uye GetirIdile(int id)
        {
            throw new NotImplementedException();
        }

        public void Guncelle(Uye tablo)
        {
            throw new NotImplementedException();
        }

        public void Kaydet(Uye tablo)
        {
            _uyeDal.Kaydet(tablo);
        }

        public void Sil(Uye tablo)
        {
            throw new NotImplementedException();
        }
    }
}
