using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.Transactional.FI.Customers;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.Transactional.FI.Cobranza
{
    public enum ModoImputacion
    {
        Completa, //Imputa si la factura mas vieja esta completa
        HastaImporte //Imputa de mas vieja a mas nueva el importe total de la factura. (puede quedar incompleto)
    };


    public class ImputacionCobranzas
    {
        public List<T0208_COB_NO_APLICADA> GetCobranzasPendientesImputacion(int idCliente=0)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return idCliente == 0
                    ? db.T0208_COB_NO_APLICADA.ToList()
                    : db.T0208_COB_NO_APLICADA.Where(c => c.CLIENTE == idCliente).ToList();
            }
        }
        public decimal GetSaldoAImputar208(int idCliente,string lx=null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (string.IsNullOrEmpty(lx))
                {
                    var x = db.T0208_COB_NO_APLICADA.Where(c => c.CLIENTE == idCliente).ToList();
                    return x.Count == 0 ? 0 : x.Sum(c => c.MONTO.Value);
                }
                else
                {
                    var x = db.T0208_COB_NO_APLICADA.Where(c => c.CLIENTE == idCliente && c.TIPOCUENTA==lx).ToList();
                    return x.Count == 0 ? 0 : x.Sum(c => c.MONTO.Value);
                }
               
            }
        }
        public List<T0207_SPLITFACTURAS> GetDocumentosAImputar(int idCliente,string tipoLX=null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (string.IsNullOrEmpty(tipoLX))
                {
                    return db.T0207_SPLITFACTURAS.Where(c => c.CLIENTE == idCliente && c.MONTO_APLICADO==0 && c.MONTO !=0).ToList();
                }
                else
                {
                    return db.T0207_SPLITFACTURAS.Where(c => c.CLIENTE == idCliente && c.TIPO == tipoLX && c.MONTO_APLICADO ==0 && c.MONTO !=0).ToList();
                }
            }
        }
        public bool ImputaCobranzaAutomatica(int idCobranza, ModoImputacion modo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t208 = db.T0208_COB_NO_APLICADA.SingleOrDefault(c => c.IDRECIBO==idCobranza);
                var cob201 = db.T0201_CTACTE.SingleOrDefault(c => c.IDT2 == idCobranza);
                if (t208 == null || cob201 == null)
                    return false;

                if (t208.MONTO != (cob201.SALDOFACTURA*-1))
                    return false;

                if (t208.CLIENTE != cob201.IDCLI)
                    return false;

                var idCliente = t208.CLIENTE.Value;
                var importeImputar = t208.MONTO.Value;
                var lxImputar = t208.TIPOCUENTA;

                var fact =
                    db.T0201_CTACTE.Where(c => c.IDCLI == idCliente && c.TIPO == lxImputar && c.SALDOFACTURA > 0)
                        .OrderBy(c => c.Fecha).ToList();

                if (fact.Count == 0)
                {
                    MessageBox.Show(@"No Existen Facturas para Imputar!", @"Sin Facturas", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return false;
                }

                var t0207 = new T0207_SPLITFACTURAS();
                int idctacteFact;

                switch (modo)
                {
                    case ModoImputacion.Completa:
                        if (fact[0].SALDOFACTURA > importeImputar) return false;
                        idctacteFact = fact[0].IDCTACTE;
                        t0207 = db.T0207_SPLITFACTURAS.SingleOrDefault(
                            c => c.IDCTACTE == idctacteFact && c.MONTO_APLICADO == 0);

                        if (t0207 == null)
                            return false;

                        if (fact[0].SALDOFACTURA != t0207.MONTO)
                            return false;

                        if (new PercepcionesManager().ValidaImputacionFacturaPermitida(idctacteFact, cob201.IDCTACTE) == false)
                            return false;
                        
                        return Imputacion(idctacteFact, t208.ID, cob201.IDCTACTE, t0207.FACTSPLIT);
 
                    case ModoImputacion.HastaImporte:
                        idctacteFact = fact[0].IDCTACTE;
                        t0207 = db.T0207_SPLITFACTURAS.SingleOrDefault(
                            c => c.IDCTACTE == idctacteFact && c.MONTO_APLICADO == 0);

                        if (t0207 == null)
                            return false;

                        if (fact[0].SALDOFACTURA != t0207.MONTO)
                            return false;

                        if (new PercepcionesManager().ValidaImputacionFacturaPermitida(idctacteFact, cob201.IDCTACTE) == false)
                            return false;

                        return Imputacion(idctacteFact, t208.ID, cob201.IDCTACTE, t0207.FACTSPLIT);

                    default:
                        throw new ArgumentOutOfRangeException(nameof(modo), modo, null);
                }
            }
        }
        private bool Imputacion(int idCtaCteFacturaImputar,int id208, int idCtaCteCobranza,int facturaSplit207, decimal? montoImputar=null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                decimal importeAImputarFactura = 0;
                decimal importe208Restante = 0;
                decimal saldoFacturaRestante = 0;

                var t201FactAImputar = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCteFacturaImputar);
                var t201Cobranza = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCteCobranza);
                var t208 = db.T0208_COB_NO_APLICADA.SingleOrDefault(c => c.ID == id208);
    
                if (montoImputar == null)
                {
                    montoImputar = t201FactAImputar.SALDOFACTURA;
                }
                else
                {
                    if (montoImputar > t201FactAImputar.SALDOFACTURA)
                        return false;
                }

                if (montoImputar.Value >= t208.MONTO.Value)
                {
                    importeAImputarFactura = t208.MONTO.Value;
                    importe208Restante = 0;
                    saldoFacturaRestante = montoImputar.Value - t208.MONTO.Value;
                }
                else
                {
                    importeAImputarFactura = montoImputar.Value;
                    importe208Restante = t208.MONTO.Value - montoImputar.Value;
                    saldoFacturaRestante = t201FactAImputar.SALDOFACTURA-montoImputar.Value;
                }

                if (t201FactAImputar.TIPO == "L1")
                {
                    new PercepcionesManager().ImputaPagoUpdatePercepcion(t201FactAImputar.IDCTACTE,
                        t201Cobranza.IDCTACTE);
                }

                var resu = new CtaCteCustomer(t201Cobranza.IDCLI).ImputacionPagoT0207(idCtaCteFacturaImputar, facturaSplit207,
                    importeAImputarFactura, id208);
                if (importe208Restante == 0)
                {
                    db.T0208_COB_NO_APLICADA.Remove(t208);
                    db.SaveChanges();
                }
                else
                {
                    t208.MONTO = importe208Restante;
                    db.SaveChanges();
                }
                t201Cobranza.SALDOFACTURA = importe208Restante*-1;
                t201FactAImputar.SALDOFACTURA = saldoFacturaRestante;
                db.SaveChanges();
                return true;
            }
        }
        private bool ValidacionOKImputar()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

            }
            return true;
        }
        public bool ImputarCobranza(int id208, decimal importeImputar, int idCtaCteImputar, int split207, decimal importePercepcion)
        {
            if (ValidacionOKImputar() == false)
                return false;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t207 = db.T0207_SPLITFACTURAS.SingleOrDefault(c => c.IDCTACTE == idCtaCteImputar && c.FACTSPLIT == split207);
                if (t207 == null)
                    return false;

                var t201 = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCteImputar);
                if (t201 == null)
                    return false;

                var t208 = db.T0208_COB_NO_APLICADA.SingleOrDefault(c => c.ID == id208);
                if (t208 == null)
                    return false;

                if (t201.TIPO != t208.TIPOCUENTA)
                    return false;

                if (t201.MONEDA != t208.MONEDA)
                    return false;

                if (t207.MONTO_APLICADO != 0)
                    return false;

                if (t207.MONTO <= 0)
                    return false;

                if (t208.IDCTACTE == null)
                {
                    MessageBox.Show(@"Debe ejecutar el FIX para agregar el IDCTACTE en T0208", @"FIX Pendiente de Ejecucion",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                var t0201Cob = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == t208.IDCTACTE);
                if (t0201Cob == null)
                    return false;

               if (t0201Cob.IDCLI != t208.CLIENTE.Value)
                    return false;

                if (Math.Abs(t0201Cob.SALDOFACTURA) != Math.Abs(t208.MONTO.Value))
                {
                    MessageBox.Show(@"El Saldo de la Cobranza no coincide con el importe no imputado");
                    return false;
                }
                   


                //define el importe a imputar
                decimal importeAImputarFactura = 0;
                decimal importe208Restante = 0;
                decimal SaldoFacturaRestante = 0;

                if (t201.SALDOFACTURA >= t208.MONTO.Value)
                {
                    importeAImputarFactura = t208.MONTO.Value;
                    importe208Restante = 0;
                    SaldoFacturaRestante = t201.SALDOFACTURA - t208.MONTO.Value;
                }
                else
                {
                    importeAImputarFactura = t201.SALDOFACTURA;
                    importe208Restante = t208.MONTO.Value - t201.SALDOFACTURA;
                    SaldoFacturaRestante = 0;
                }

                var resu = new CtaCteCustomer(t0201Cob.IDCLI).ImputacionPagoT0207(idCtaCteImputar, split207, importeAImputarFactura, id208);
                if (importe208Restante == 0)
                {
                    db.T0208_COB_NO_APLICADA.Remove(t208);
                    db.SaveChanges();
                }
                else
                {
                    t208.MONTO = importe208Restante;
                    db.SaveChanges();
                }
                t0201Cob.SALDOFACTURA = importe208Restante*-1;
                t201.SALDOFACTURA = t201.SALDOFACTURA - importeAImputarFactura;
                //t0201Cob.SALDOFACTURA = t0201Cob.SALDOFACTURA + importeAImputarFactura;
                db.SaveChanges();

                if (importePercepcion > 0)
                {
                    if (new PercepcionesManager().ImputaPagoUpdatePercepcion(idCtaCteImputar, t208.IDCTACTE.Value) ==
                        false)
                        MessageBox.Show(@"Ha Ocurrido un error en la imputacion de Percepciones",
                            @"Error en Imputacion de Percepciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return true;
            }
        }
        public decimal GetSaldoPendientePagoDocumento(int idCtaCte)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCte).SALDOFACTURA;
            }
        }

        public List<T0207_SPLITFACTURAS> GetListaRecibosImputanFactura(int idCtaCteFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0207_SPLITFACTURAS.Where(c => c.IDCTACTE == idCtaCteFactura).ToList();
            }
        }

    }
}
