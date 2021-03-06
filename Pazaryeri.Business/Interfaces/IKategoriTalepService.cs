﻿using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Business.Interfaces
{
    public interface IKategoriTalepService : IGenericService<KategoriTalep>
    {
        List<KategoriTalep> MagazaKategoriTalepleri();
    }
}
