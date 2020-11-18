using Pazaryeri.DataAccess.Concrete.EntityFrameworkCore.Context;
using Pazaryeri.DataAccess.Interfaces;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pazaryeri.DataAccess.Concrete.Repositories
{
    public class EfSecenekMaddeRepository : EfGenericRepository<SecenekMadde>, ISecenekMaddeDal
    {
        //protected readonly PazayeriContext context;

        //public EfSecenekMaddeRepository(PazayeriContext ctx) : base(ctx)
        //{
        //    context = ctx;
        //}
        public List<SecenekMadde> SecenekIdyeGore(int id)
        {
            using var context = new PazayeriContext();
            return context.SecenekMadde.Where(x => x.SecenekId == id).ToList();
        }
    }
}
