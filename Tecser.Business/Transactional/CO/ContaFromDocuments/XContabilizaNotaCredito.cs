using System.Linq;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.Transactional.FI.MainDocumentData;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.Transactional.CO.ContaFromDocuments
{
    public class XContabilizaNotaCredito:XContabilizaDocumentosBase
    {
        public XContabilizaNotaCredito(int idFactura) : base(idFactura)
        {
            base.Signo = -1;
        }

        public T0300_NCD_H GetDocumentoHeader()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0300_NCD_H.SingleOrDefault(c => c.IDH == H.IDFACTURA);
            }
        }

        public override ReturnContaCustomerDocument ContabilizacionCompleta()
        {
            var idNcd = new NcdTableManager().GetIdNCDFromIdFactura(H.IDFACTURA);
            base.AddRecordCtaCteDetalle201();
            var x = new CtaCteCustomer(H.Cliente.Value).AddSinImputarRecord(H.FECHA.Value, idNcd, H.FacturaMoneda,
                H.TotalFacturaN, H.TIPOFACT, "NCD", VariablesProgreso.NumeroDocumentoCompleto,
                VariablesProgreso.IdCtaCte);
            //base.AddRecordCtaCteImputacion207();
            base.UpdateSaldoCtaCte202();

            var asiento = new AsientoCustomerDocument(VariablesProgreso.IdFactura, "NCD");
            var asientoResultado = asiento.AsientoFromCustomerNotaCredito();
            VariablesProgreso.NumeroAsientoIdDocu = asientoResultado.IdDocu;
            VariablesProgreso.NumeroAsientoX1X2 = asientoResultado.NasX1;
            UpdateT0400AfterContabilizacion();
            return VariablesProgreso;
        }
    }
}
