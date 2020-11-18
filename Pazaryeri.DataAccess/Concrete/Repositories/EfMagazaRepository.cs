using Pazaryeri.DataAccess.Concrete.EntityFrameworkCore.Context;
using Pazaryeri.DataAccess.Interfaces;
using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pazaryeri.DataAccess.Concrete.Repositories
{
    public class EfMagazaRepository : EfGenericRepository<Magaza>, IMagazaDal
    {
        //private new readonly PazayeriContext context;

        //public EfMagazaRepository(PazayeriContext ctx) : base(ctx)
        //{
        //    context = ctx;
        //}
 
        public Magaza MagazaGetirEposta(string eposta)
        {
            using var context = new PazayeriContext();
            return context.Magazalar.Where(x => x.eposta == eposta).FirstOrDefault();
        }
        public Magaza MagazaGetirŞifre(string eposta, string sifre)
        {
            using var context = new PazayeriContext();
            return context.Magazalar.Where(e => e.eposta == eposta && e.sifre == sifre).FirstOrDefault();
        }
    }
}
