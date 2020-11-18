using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.DataAccess.Interfaces
{
    public interface IKategoriTalepDal : IGenericDal<KategoriTalep>
    {
        List<KategoriTalep> MagazaKategoriTalepleri();
    }
}
