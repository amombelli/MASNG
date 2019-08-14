using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData.Customer
{
    //Nueva clase que pretende emprolijar complejidades de herencia de otras clases
    //Fecha 2020-03-14
    public class T400Manager
    {
        public T0400_FACTURA_H GetDocumentHeader(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
            }
        }
        public List<T0401_FACTURA_I> GetDocumentItems(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0401_FACTURA_I.Where(c => c.IDFactura == idFactura).ToList();
            }
        }




    }
}
