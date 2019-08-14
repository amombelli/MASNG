using System.Collections.Generic;
using System.Linq;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.SuperMD
{
    public class PlantasManager
    {

        public List<T0016_PLANTAS> GetListActivePlant()
        {
            return new TecserData(GlobalApp.CnnApp).T0016_PLANTAS.Where(c => c.Activa == true).ToList();
        }
    }
}
