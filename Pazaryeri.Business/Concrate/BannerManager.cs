using Pazaryeri.Business.Interfaces;
using Pazaryeri.DataAccess.Interfaces;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Business.Concrate
{
    public class BannerManager : IBannerService
    {
        private readonly IBannerDal _bannerDal;
        public BannerManager(IBannerDal bannerDal)
        {
            _bannerDal = bannerDal;
        }

        public List<Banner> BannerTipGetir()
        {
            return _bannerDal.BannerTipGetir();
        }

        public List<Banner> GetirHepsi()
        {
            return _bannerDal.GetirHepsi();
        }

        public Banner GetirIdile(int id)
        {
            return _bannerDal.GetirIdile(id);
        }

        public void Guncelle(Banner tablo)
        {
             _bannerDal.Guncelle(tablo);
        }

        public void Kaydet(Banner tablo)
        {
            _bannerDal.Kaydet(tablo);
        }

        public void Sil(Banner tablo)
        {
            _bannerDal.Sil(tablo);
        }
    }
}
