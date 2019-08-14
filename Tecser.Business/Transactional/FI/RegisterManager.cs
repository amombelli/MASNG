using System;
using System.Linq;
using Tecser.Business.MasterData;
using Tecser.Business.TOOLS;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.Transactional.FI
{
    public enum tipoPC
    {
        Cliente,
        Proveedor,
        Transferencia
    };

    public class RegisterManager
    {
        public void AddRegisterRecord(string nombreCuenta, DateTime fecha, string tipoDocumento, string numeroDocumento, tipoPC PCT, int idProvCli, string descripcionRegistro, string moneda,decimal montoI, decimal montoE,int idCheque,string tipoLx, string gl, int nas, string tCode, bool UpdateSaldoCuenta=true, string nombreCuenta2EnTransferencia=null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var n = new XREGISTER()
                {
                    IDT = db.XREGISTER.Max(c=>c.IDT) +1,
                    IDC = nombreCuenta,
                    Fecha = fecha,
                    Tdoc = tipoDocumento,
                    Ref = numeroDocumento,
                    LogFecha = DateTime.Today,
                    TIPO = tipoLx,
                    Moneda = moneda,
                    CC = gl,
                    CCosto = "[Split]",
                    LogUser = Environment.UserName,
                    Descripcion = descripcionRegistro,
                    NAS =nas,
                    TCODE = tCode,
                    Monto_E = montoE,
                    Monto_I = montoI,
                };

                switch (PCT)
                {
                    case tipoPC.Cliente:
                        n.PCID = idProvCli;
                        n.PC = "C";
                        n.Entidad = new CustomerManager().GetCustomerBillToData(idProvCli).cli_rsocial;
                        break;
                    case tipoPC.Proveedor:
                        n.PCID = idProvCli;
                        n.PC = "P";
                        n.Entidad = new VendorManager().GetSpecificVendor(idProvCli).prov_rsocial;
                        break;
                    case tipoPC.Transferencia:
                        n.Entidad = "TRANSFERENCIA";
                        n.PCID = null;
                        n.PC = "T";
                        if (montoI > 0)
                        {
                            n.XTransf = nombreCuenta2EnTransferencia +"->>";
                        }
                        else
                        {
                            n.XTransf = ">>>" + nombreCuenta2EnTransferencia;
                        }                      
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(PCT), PCT, null);
                }
                if (idCheque > 0)
                {
                    n.CH_ID = idCheque;
                    var chequeData = new ChequesManager().GetCheque(idCheque);
                    n.CH_BCO = chequeData.CHE_BANCO;
                    n.CH_FEC = chequeData.CHE_FECHA;
                }

                n.XMES = new PeriodoConversion().GetMesMm(fecha);
                n.XYEAR = new PeriodoConversion().GetYearYyyy(fecha);
                db.XREGISTER.Add(n);
                db.SaveChanges();

                if (!UpdateSaldoCuenta) return;

                if (montoE > 0)
                {
                    new CuentasManager().UpdateSaldoCuenta(nombreCuenta,montoE*-1);
                }
                else
                {
                    new CuentasManager().UpdateSaldoCuenta(nombreCuenta, montoI);
                }
            }
        }
    }
}
