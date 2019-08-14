using System.Linq;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.Transactional.SD
{
    //referente a actulizacion y comportamiento de una SO desde el delivery/remito
    public class SalesOrderDeliveryManager
    {
        public bool CheckItemIsOkToShip(int idSO, int idItem, string materialPrimario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lineaSO = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == idSO && c.IDITEM == idItem);
                if (lineaSO == null)
                    return false;

                if (lineaSO.materialPrimario != materialPrimario)
                    return false;
            }
            return true;
        }
        public bool CheckKgIsOkToShip(int idSO, int idItem, decimal kgRemito)
        {

            decimal margenDespacho = (decimal) 0.1; //margen de despacho = 10%

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lineaSO = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == idSO && c.IDITEM == idItem);
                if (lineaSO == null)
                    return false;

                if (lineaSO.KGStockDespachados == null)
                    lineaSO.KGStockDespachados = 0;

                var kgPendientesDespacho = lineaSO.Cantidad - lineaSO.KGStockDespachados.Value;

                if (kgPendientesDespacho <= 0)
                    return false; //no hay kg para despachar;

                if (kgPendientesDespacho*(1 + margenDespacho) < kgRemito)
                    return false; //se supera el margen de despacho;
            }
            return true;
        }
        public void UpdateDeliveryQty(int idSO, int idItem, decimal kgRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lineaSO = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == idSO && c.IDITEM == idItem);
                if (lineaSO.KGStockDespachados == null)
                {
                    lineaSO.KGStockDespachados = kgRemito;
                }
                else
                {
                    lineaSO.KGStockDespachados += kgRemito;
                }
                db.SaveChanges();
            }
        }

        public bool FixPriceFromOldModel(int idSO, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == idSO && c.IDITEM == idItem);
                if (x.MODO != "L5")
                {
                    if ((x.PRECIO1 == 0 || x.PRECIO1 == null) && (x.PRECIO2 == 0 || x.PRECIO2 == null) && x.PrecioUnitario != 0)
                    {
                        if (x.MODO == "L1")
                        {
                            x.PRECIO1 = x.PrecioUnitario;
                            x.PRECIOTOTAL = x.PrecioUnitario;
                            x.PRECIO2 = 0;
                        }
                        else
                        {
                            x.PRECIO1 = 0;
                            x.PRECIO2 = x.PrecioUnitario;
                            x.PRECIOTOTAL = x.PrecioUnitario;
                        }
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                   //L5
                    if (x.PRECIO1 == 0 || x.PRECIO1 == null)
                    {
                        x.PRECIOTOTAL = x.PrecioUnitario;
                        x.PRECIO1 = x.PrecioUnitario - x.PRECIO2;
                    }
                    else
                    {
                        
                    } 
                }
                return db.SaveChanges() > 0;
            }
        }





    }
}
