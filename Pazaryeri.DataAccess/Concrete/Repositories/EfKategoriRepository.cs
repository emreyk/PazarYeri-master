using Pazaryeri.DataAccess.Concrete.EntityFrameworkCore.Context;
using Pazaryeri.DataAccess.Interfaces;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.DataAccess.Concrete.Repositories
{
    public class EfKategoriRepository : EfGenericRepository<Kategori>, IKategoriDal
    {
        //protected readonly PazayeriContext context;

        //public EfKategoriRepository(PazayeriContext ctx) : base(ctx)
        //{
        //    context = ctx;
        //}
    }
}
