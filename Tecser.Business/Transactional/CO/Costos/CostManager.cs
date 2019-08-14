using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.Costos
{
    public enum CostType
    {
        Standard,
        Reposicion,
        PPP
    };
    
    public struct CostStruct
    {
        public decimal ARS;
        public decimal USD;
        public DateTime Fecha;
        public decimal Kg;
        public string VendorUc;
    }

    public class CostManager
    {
        const decimal MaxValue = 9999999;

        public CostStruct GetUc(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var resp = new CostStruct();
                var data = db.T0033_COSTO.SingleOrDefault(c => c.MATERIAL == material);
                if (data == null)
                {
                    resp.ARS = MaxValue;
                    resp.USD = MaxValue;
                    resp.Fecha = DateTime.Today;
                }
                else
                {
                    if (data.COSTO_UC_ARS == null)
                        data.COSTO_UC_ARS = MaxValue;

                    if (data.COSTO_UC_USD == null)
                        data.COSTO_UC_USD = MaxValue;

                    resp.ARS = data.COSTO_UC_ARS.Value;
                    resp.USD = data.COSTO_UC_USD.Value;
                    resp.Fecha = data.FECHA_UC ?? DateTime.Today;
                    resp.Kg = data.STOCK ?? 0;

                    if (data.Proveedor != null)
                    {
                        resp.VendorUc = new VendorManager().GetSpecificVendor(data.Proveedor.Value).prov_rsocial;
                    }
                }
                return resp;
            }
        }
    }
}
