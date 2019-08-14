using System.Collections.Generic;
using System.Linq;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    public class NCDAnulaDocumento
    {
        public List<T0400_FACTURA_H> GetListaDocumentos(int idCliente, string tipoLX)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0400_FACTURA_H.Where(c => c.Cliente == idCliente).OrderByDescending(c=>c.IDFACTURA).ToList();
                if (tipoLX == null)
                    return x;
                return x.Where(c => c.TIPOFACT == tipoLX).ToList();
            }
        }

        public T0400_FACTURA_H GetDatosFactura(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
            }
        }

        public List<T0401_FACTURA_I> GetItemsDocumentoSeleccionado(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0401_FACTURA_I.Where(c => c.IDFactura == idFactura).ToList();
            }
        }


    }
}
