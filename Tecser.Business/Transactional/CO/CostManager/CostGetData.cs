using System.Linq;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.Transactional.CO.CostManager
{
    public class CostGetData:CostBase
    {
        public CostGetData(string material, CostType tipoCosto)
        {
            base.Material = material;
        }
        public decimal GetCostoStandardMaterial(string moneda)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cx = db.T0033_COSTO.SingleOrDefault(c => c.MATERIAL == Material);
                if (cx == null)
                    return 0;

                if (moneda == "ARS")
                {
                    return cx.COSTO_ARS ?? 99999999;
                }
                else
                {
                    return cx.COSTO_USD ?? 99999999;
                }
            }
        }
        public static decimal GetCostoMercaderiaVendidaInARS()
        {
            return 0;
        }
        public static decimal GetCostoMercaderiaVendidaInUSD()
        {
            return 0;
        }
    }
}
