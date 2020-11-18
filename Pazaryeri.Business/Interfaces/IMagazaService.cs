using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Business.Interfaces
{
    public interface IMagazaService :IGenericService<Magaza>
    {
        Magaza MagazaGetirEposta(string eposta);
        Magaza GetirMagazaLogin(string eposta,string sifre);
    }
}
