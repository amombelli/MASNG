using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.DataFix
{
    public class FixFactuPreciosToNewModel
    {
        public void FixFacturaPrecios(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                if (x == null)
                    return;

                var fmon = x.FacturaMoneda;

                var it = db.T0401_FACTURA_I.Where(c => c.IDFactura == idFactura).ToList();
                foreach (var i in it)
                {
                    if (i.PRECIOU_FACT_ARS == null)
                    {
                        i.PRECIOU_FACT_ARS = i.PRECIOU;
                        i.PRECIOT_FACT_ARS = i.PRECIOT;
                        i.PRECIOT_FACT_USD = i.PRECIOT*i.TC;
                        i.PRECIOU_FACT_USD = i.PRECIOU*i.TC;
                    }

                }
                db.SaveChanges();
            }
        }
    }
}
