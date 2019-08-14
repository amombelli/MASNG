using System.Collections.Generic;
using System.Linq;
using TecserEF.Entity;using Tecser.Business.MainApp;
using TecserEF.Entity.DataStructure.SD_CRM;

namespace Tecser.Business.Transactional.SD
{

    public class SalesOrderDataList
    {


        public List<MaterialRequestedInSO> GetData(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var query = from h in db.T0045_OV_HEADER
                    where (h.StatusOV.ToUpper().Equals("EMITIDA") || h.StatusOV.ToUpper().Equals("PROCESO"))
                    join i in db.T0046_OV_ITEM on h.IDOV equals i.IDOV 
                    where i.materialPrimario.ToUpper().Equals(material.ToUpper()) && (
                    i.StatusItem.ToUpper().Equals("PENDIENTE") || i.StatusItem.ToUpper().Equals("PARCIAL") || i.StatusItem.ToUpper().Equals("INICIAL"))
                    select new MaterialRequestedInSO()
                    {
                        IdCliente = h.CLIENTE.Value,
                        FechaSO = h.FECHA_OV.Value,
                        Material = i.materialPrimario,
                        IdSO = h.IDOV,
                        KgRequested = i.Cantidad,
                        KgComprometidos = i.KGStockComprometido.Value,
                        KgRestantes = i.Cantidad - i.KGStockDespachados.Value,
                        StatusOV = h.StatusOV,
                        StatusItem = i.StatusItem,
                        ClienteRs = h.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial
                    };

                return query.ToList();
            }
        }
    }
}
