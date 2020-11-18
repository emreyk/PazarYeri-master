using Microsoft.EntityFrameworkCore;
using Pazaryeri.DataAccess.Concrete.EntityFrameworkCore.Context;
using Pazaryeri.DataAccess.Interfaces;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pazaryeri.DataAccess.Concrete.Repositories
{
    public class EfKategoriTalepRepository : EfGenericRepository<KategoriTalep>, IKategoriTalepDal
    {
        //private new readonly PazayeriContext context;

        //public EfKategoriTalepRepository(PazayeriContext ctx) : base(ctx)
        //{
        //    context = ctx;
        //}
        public List<KategoriTalep> MagazaKategoriTalepleri()
        {
            using var context = new PazayeriContext();
            return context.KategoriTalep.Include(x => x.Magaza).ToList();
        }
    }
}
