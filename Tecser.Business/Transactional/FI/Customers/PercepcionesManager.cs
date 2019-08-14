using System;
using System.Linq;
using System.Windows.Forms;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.Transactional.FI.Customers
{
    public class PercepcionesManager
    {
        public decimal GetPercepcionDocumento(int idFacturaX)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var doc = db.T0402_FACTURA_PERCEP.SingleOrDefault(c => c.IdFactura==idFacturaX);
            }

                return 0;
        }
        public bool AddFacturaPercepcion(int idFacturaX)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var factu = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURAX == idFacturaX);
                if (factu == null)
                    return false;
                int multiplicador = 1;
                if (factu.TIPO_DOC == "NC")
                    multiplicador = -1;

                var data = new T0402_FACTURA_PERCEP()
                {
                    IdFactura =idFacturaX,
                    IdCliente =factu.Cliente,
                    NumFactura =factu.PV_AFIP + "-" + factu.ND_AFIP,
                    FechaFactura =factu.FECHA,
                    IIBB_Perc_TXT =factu.IIBB_TXT,
                    IIBB_Perc_Porc =factu.IIBB_PORC,
                    IIBB_Perc_ARS =factu.TotalIIBB *multiplicador,
                    IIBB_Perc_ARS_Saldo =factu.TotalIIBB * multiplicador,
                    IIBB_Perc_DocPago =null,
                    IIBB_Perc_FechaPago =null,
                    IDCtaCte =factu.IdCtaCte,
                    FechaImputacion =null,
                    Informado =false,
                };
                db.T0402_FACTURA_PERCEP.Add(data);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Valida que la factura se puede imputar desde el punto de vista de una percepcion
        /// </summary>
        public bool ValidaImputacionFacturaPermitida(int idCtaCteFactura, int idCtaCtePago)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataF = db.T0400_FACTURA_H.SingleOrDefault(c => c.IdCtaCte == idCtaCteFactura);
                if (dataF == null)
                    return false;

                var documentoPago = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCtePago);
                if (documentoPago == null)
                    return false;

                if (dataF.TIPOFACT != "L1")
                    return true; //Desde el punto de vista de percepcion se puede imputar.

                var idFacturaX = dataF.IDFACTURAX;
                var data = db.T0402_FACTURA_PERCEP.SingleOrDefault(c => c.IdFactura == idFacturaX);

                if (data == null)
                    return true; //No Existen Percepciones en este documento
     
                if (data.IIBB_Perc_ARS_Saldo == 0)
                    return true;
                        //Desde el punto de vista de perecpecion se puede imputar factura (Percepcion ya imputada)

                if (documentoPago.SALDOFACTURA*-1 < data.IIBB_Perc_ARS_Saldo)
                    return false; //El monto de la cobranza no alcanza para imputar la percpecion

                return true;
            }
        }
        public bool ImputaPagoUpdatePercepcion(int idCtaCteFactura, int idCtaCtePago)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataF = db.T0400_FACTURA_H.SingleOrDefault(c => c.IdCtaCte == idCtaCteFactura);
                if (dataF == null)
                    return false;

                var idFacturaX = dataF.IDFACTURAX;
                var data = db.T0402_FACTURA_PERCEP.SingleOrDefault(c => c.IdFactura == idFacturaX);

                if (data == null)
                {
                    //** por un error la percepcion no esta en la tabla! 
                    //Tendria que ejecutarse un fix para agregarla!
                    new PercepcionesManager().AddFacturaPercepcion(idFacturaX.Value);
                    data = db.T0402_FACTURA_PERCEP.SingleOrDefault(c => c.IdFactura == idFacturaX);

                    MessageBox.Show(
                        @"Se ha agregado la percecpion a la tabla porque no estaba. Por favor notifique sobre esta situacion a Andres",
                        @"MSG021A", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (data == null)
                        return false;

                }
                   // return false;

                if (data.IIBB_Perc_ARS_Saldo == 0)
                    return false;

                var documentoPago = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCtePago);
                if (documentoPago == null)
                    return false;

                if (documentoPago.SALDOFACTURA*-1 < data.IIBB_Perc_ARS_Saldo)
                    return false;

                data.IDCtaCte = idCtaCteFactura;
                data.FechaImputacion = DateTime.Today;
                data.IIBB_Perc_ARS_Saldo = 0;
                data.IIBB_Perc_DocPago = documentoPago.NUMDOC;
                data.IIBB_Perc_FechaPago = documentoPago.Fecha;
                db.SaveChanges();
                return true;
            }
        }

    }
}
