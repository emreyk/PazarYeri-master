using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.DataAccess.Interfaces
{
    public interface IMagazaDal : IGenericDal<Magaza>
    {
        Magaza MagazaGetirEposta(string eposta);
        Magaza MagazaGetirŞifre(string eposta,string sifre);
    }
}
