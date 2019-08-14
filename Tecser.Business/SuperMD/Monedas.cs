using System.Collections.Generic;
using System.Linq;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.SuperMD
{
    public class Monedas
    {

        public List<T0151_MONEDAS> GetListMonedas()
        {
            return new TecserData(GlobalApp.CnnApp).T0151_MONEDAS.ToList();
        }

        public T0151_MONEDAS GetSpecificMoneda(string monedaId)
        {
            var data =
                new TecserData(GlobalApp.CnnApp).T0151_MONEDAS.SingleOrDefault(c => c.IdMoneda.ToUpper().Equals(monedaId.ToUpper()));
            if (data == null)
            {
                var datanull = new T0151_MONEDAS();
                datanull.IdMoneda = "000";
                return datanull;
            }
            return data;
        }

    }
}
