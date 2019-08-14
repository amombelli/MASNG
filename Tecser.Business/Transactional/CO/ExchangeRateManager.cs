using System;
using System.Linq;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.Transactional.CO
{
    public class ExchangeRateManager
    {


        public decimal GetExchangeRate(DateTime date)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0102_EXCHANGE.SingleOrDefault(c => c.Fecha == date);
                if (x == null)
                {
                    var x2 = db.T0102_EXCHANGE.Where(c => c.Fecha < date)
                        .OrderByDescending(c => c.Fecha)
                        .FirstOrDefault();
                    if (x2 == null)
                    {
                        return 9999;
                    }
                    else
                    {
                        return x2.CotizacionFactu.Value;
                    }
                }
                else
                {
                    return x.CotizacionFactu.Value;
                }
            }
        }
    }
}
