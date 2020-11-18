using Pazaryeri.Entities.Concrete;
using System.Collections.Generic;

namespace Pazaryeri.DataAccess.Interfaces
{
    public interface ISecenekMaddeDal:IGenericDal<SecenekMadde>
    {
        List<SecenekMadde> SecenekIdyeGore(int id);
    }
}
