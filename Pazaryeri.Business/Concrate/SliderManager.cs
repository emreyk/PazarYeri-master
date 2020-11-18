using Pazaryeri.Business.Interfaces;
using Pazaryeri.DataAccess.Interfaces;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Business.Concrate
{
    public class SliderManager:ISliderService
    {
        private readonly ISliderDal _sliderDal;
        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public List<Slider> GetirHepsi()
        {
            return _sliderDal.GetirHepsi();
        }

        public Slider GetirIdile(int id)
        {
            return _sliderDal.GetirIdile(id);
        }

        public void Guncelle(Slider tablo)
        {
            _sliderDal.Guncelle(tablo);
        }

        public void Kaydet(Slider tablo)
        {
            _sliderDal.Kaydet(tablo);
        }

        public void Sil(Slider tablo)
        {
            _sliderDal.Sil(tablo);
        }
    }
}
