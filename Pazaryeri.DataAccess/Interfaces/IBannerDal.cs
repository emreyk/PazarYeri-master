using Pazaryeri.DTO.DTOs.BannerDTOs;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.DataAccess.Interfaces
{
    public interface IBannerDal:IGenericDal<Banner>
    {
        List<Banner> BannerTipGetir();
    }
}
