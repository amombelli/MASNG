using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.IntegridadContable
{
    public class ValidacionFaturasAfip
    {
        public bool FacturaContabilizada(string ncuit, string documento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var y = db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.PRTAX1 == ncuit && c.NFACTURA == documento);
                if (y == null)
                    return false;
                return true;
            }
        }
    }
}
