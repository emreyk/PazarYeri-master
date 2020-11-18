using Pazaryeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pazaryeri.Business.Interfaces
{
    public interface ISecenekMaddeService:IGenericService<SecenekMadde>
    {
        List<SecenekMadde> SecenekIdyeGore(int id);
    }
}
