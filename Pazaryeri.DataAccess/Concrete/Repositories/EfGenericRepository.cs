using Pazaryeri.DataAccess.Concrete.EntityFrameworkCore.Context;
using Pazaryeri.DataAccess.Interfaces;
using Pazaryeri.Entities.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Pazaryeri.DataAccess.Concrete.Repositories
{
    public class EfGenericRepository<Tablo> : IGenericDal<Tablo>
        where Tablo : class, ITablo, new()
    {


        //protected readonly PazayeriContext context;

        //public EfGenericRepository(PazayeriContext ctx)
        //{
        //    context = ctx;
        //}

        public List<Tablo> GetirHepsi()
        {

            using var context = new PazayeriContext();
            return context.Set<Tablo>().ToList();
        }

        public Tablo GetirIdile(int id)
        {
            using var context = new PazayeriContext();
            return context.Set<Tablo>().Find(id);
        }

        public void Guncelle(Tablo tablo)
        {
            using var context = new PazayeriContext();
            context.Set<Tablo>().Update(tablo);
            context.SaveChanges();
        }

        public void Kaydet(Tablo tablo)
        {
            using var context = new PazayeriContext();
            context.Set<Tablo>().Add(tablo);
            context.SaveChanges();
        }

        public void Sil(Tablo tablo)
        {
            using var context = new PazayeriContext();
            context.Set<Tablo>().Remove(tablo);
            context.SaveChanges();
        }
    }
}
