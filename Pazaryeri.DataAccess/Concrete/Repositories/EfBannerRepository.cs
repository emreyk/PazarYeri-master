using Microsoft.EntityFrameworkCore;
using Pazaryeri.DataAccess.Concrete.EntityFrameworkCore.Context;
using Pazaryeri.DataAccess.Interfaces;
using Pazaryeri.DTO.DTOs.BannerDTOs;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pazaryeri.DataAccess.Concrete.Repositories
{
    public class EfBannerRepository : EfGenericRepository<Banner>, IBannerDal
    {
        public List<Banner> BannerTipGetir()
        {
            using var context = new PazayeriContext();
            return context.Banner.Include(x => x.Kategori).ToList();
        }
    }
}
