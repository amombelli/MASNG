using System;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.AsientoContable
{

    /// <summary>
    /// 2018.03.11 En esta clase de asiento generico que deriva de asiento contable base iran todos los asientos que no son
    /// ni de customer ni de vendors..
    /// </summary>
    public class AsientoGenerico : AsientoBase
    {
        public AsientoGenerico(string transactionCode)
            : base(transactionCode)
        {
            //
        }


        /// <summary>
        /// Traspaso de Saldos entre cuentas
        /// Opcion de traspaso entre clientes (mismo LX) o Traspaso en mismo cliente (LX1 -> LX2)
        /// No se tendria que permitir en un solo paso pasar de cliente1 - a cliente 2 cambiando los tipos
        /// </summary>
        public IdentificacionAsiento? CreaAsientoTraspasoSaldos(string tipoAjuste, DateTime fechaDoc, int idCliente,
            string tipoLxOrigen, int idClienteAlternativo, string tipoLxDestino, decimal importeARS, decimal tc,string numeroDocumento,string descripcion2, string monedaRegistracion = "ARS")
        {
            var gl = GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.AR);
            var importeRegistracion = monedaRegistracion != "ARS" ? decimal.Round((importeARS/tc), 2) : importeARS;
            var tdoc = tipoAjuste;
            string descripcion1=null;
            var clienteDesc = new CustomerManager().GetCustomerBillToData(idClienteAlternativo).cli_rsocial;
            DebeHaber dh;
            string tipoX;
            switch (tipoAjuste)
            {
                case "AJN":
                    dh = DebeHaber.Haber;
                    tipoX = tipoLxOrigen;
                    if (tipoLxOrigen == tipoLxDestino)
                    {
                        //Es Traspaso entre diferentes clientes 
                        descripcion1 = "Movimiento Saldo Hacia: " +clienteDesc + "[" + tipoLxDestino +"]";
                    }
                    else
                    {
                        //Es Traspaso entre cuentas de mismo cliente
                        descripcion1 = "Movmiento Saldo Hacia cuenta [" + tipoLxDestino +"]";
                    }
                    break;
                case "AJP":
                    //Es el que recibo el saldo
                    dh = DebeHaber.Debe;
                    tipoX = tipoLxDestino;
                    if (tipoLxOrigen == tipoLxDestino)
                    {
                        //Es Traspaso entre diferentes clientes
                        descripcion1 = "Movimiento Saldo Desde: " + clienteDesc + "[" + tipoLxOrigen + "]";
                    }
                    else
                    {
                        //Es Traspaso entre cuentas de mismo cliente
                        descripcion1 = "Movmiento Saldo Desde cuenta [" + tipoLxOrigen + "]";
                    }
                    break;
                default:
                    //El tipo de documento solo podra ser AJUSTE NEGATIVO o AJUSTE POSITIVO
                    return null;
            }

            base.CreacionHeaderAsiento(tipoX, fechaDoc, tdoc, numeroDocumento, descripcion2, monedaRegistracion,
                importeRegistracion, tc, importeARS);

            base.AddGenericCompleteSegment(tdoc, numeroDocumento, tipoX, gl, descripcion1, descripcion2,
                monedaRegistracion, dh, importeRegistracion, Tcode, idCliente);

            dh = dh == DebeHaber.Debe ? DebeHaber.Haber : DebeHaber.Debe;
            gl = "4.1.4.1";
            base.AddGenericCompleteSegment(tdoc, numeroDocumento, tipoX, gl, descripcion1, descripcion2,
                monedaRegistracion, dh, importeRegistracion, Tcode, idCliente);



            return GrabaAsiento();
        }



        public IdentificacionAsiento CreaAsientoChequeRechazado(int idCheque, string motivoRechazo, string glCyB,
            DateTime fechaRechazo, decimal importeGastos, decimal importeIva)
        {
            var dataCheque = new ChequesManager().GetCheque(idCheque);
            var importeTotal = dataCheque.IMPORTE.Value + importeGastos + importeIva;
            var xrate = new ExchangeRateManager().GetExchangeRate(fechaRechazo);
            var numeroDocumento = "CHRE@" + idCheque;

            var glGastosChequeRechazado = "5.6.6";
            var glIVA = GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.IvaCompra21);
            var glChequeRechazado = "1.0.0.8";


            base.CreacionHeaderAsiento(dataCheque.TIPOSAL, fechaRechazo, "CHR", numeroDocumento,
                "CH.Rech " + motivoRechazo, dataCheque.MONEDA, importeTotal, xrate);

            //por simplicidad de lectura en el asiento creo primero todos los HABER y luego repito para los DEBE
            base.AddGenericCompleteSegment("CHR", numeroDocumento, dataCheque.TIPOSAL, glCyB,
                "Rechazo de Cheque @" + idCheque, motivoRechazo, dataCheque.MONEDA, DebeHaber.Haber,
                dataCheque.IMPORTE.Value, "CHR", dataCheque.IdClienteRecibido.Value, nombreTabla: "T0154_CHEQUES",
                idNumerico: idCheque);

            if (importeGastos > 0)
            {
                base.AddGenericCompleteSegment("CHR", numeroDocumento, dataCheque.TIPOSAL, glCyB,
                    "Gastos Bancarios @" + idCheque, motivoRechazo, dataCheque.MONEDA, DebeHaber.Haber,
                    importeGastos, "CHR", dataCheque.IdClienteRecibido.Value);
            }

            if (importeIva > 0)
            {
                base.AddGenericCompleteSegment("CHR", numeroDocumento, dataCheque.TIPOSAL, glCyB,
                    "IVA Gastos Bancarios @" + idCheque, motivoRechazo, dataCheque.MONEDA, DebeHaber.Haber,
                    importeIva, "CHR", dataCheque.IdClienteRecibido.Value);
            }

            //Debe
            base.AddGenericCompleteSegment("CHR", numeroDocumento, dataCheque.TIPOSAL, glChequeRechazado,
                "Rechazo de Cheque @" + idCheque, motivoRechazo, dataCheque.MONEDA, DebeHaber.Debe,
                dataCheque.IMPORTE.Value, "CHR", dataCheque.IdClienteRecibido.Value, nombreTabla: "T0154_CHEQUES",
                idNumerico: idCheque);

            if (importeGastos > 0)
            {
                base.AddGenericCompleteSegment("CHR", numeroDocumento, dataCheque.TIPOSAL, glGastosChequeRechazado,
                    "Gastos Bancarios @" + idCheque, motivoRechazo, dataCheque.MONEDA, DebeHaber.Debe,
                    importeGastos, "CHR", dataCheque.IdClienteRecibido.Value);
            }

            if (importeIva > 0)
            {
                base.AddGenericCompleteSegment("CHR", numeroDocumento, dataCheque.TIPOSAL, glIVA,
                    "IVA Gastos Bancarios @" + idCheque, motivoRechazo, dataCheque.MONEDA, DebeHaber.Debe,
                    importeIva, "CHR", dataCheque.IdClienteRecibido.Value);
            }
            return GrabaAsiento();
        }



        public IdentificacionAsiento CreaAsientoTransferenciaEC(int idRegister,string observacion=null)
        {
            TipoDocumento = ManageDocumentType.GetSystemDocumentType(ManageDocumentType.TipoDocumento.TransferenciaEC);
            var h = new TransferenciaEntreCuentasManager().GetHeaderTransferencia(idRegister);
            var listI = new TecserData(GlobalApp.CnnApp).XREGISTER_I.Where(c=>c.IDINT == idRegister).ToList();

            string textoObservacion;

            if (string.IsNullOrEmpty(observacion))
            {
                textoObservacion = "Transf E/C Destino" + h.CUENTAD;
            }
            else
            {
                textoObservacion = observacion;
            }

            base.CreacionHeaderAsiento(h.TIPO, h.FECHA.Value, TipoDocumento, h.REFNUM, textoObservacion, h.MONEDA,
                h.IMPORTE_TOTAL.Value, h.TC.Value);

            foreach (var i in listI)
            {
                AddSegmentoTransferenciaEC(i.CUENTA_O, i.CUENTA_D, h.TIPO, i.IMPORTE_D.Value, i.MONEDA, i.CHID);
            }
            return GrabaAsiento();
        }

        /// <summary>
            /// Agrega segmento de cuenta transferencia entre cuentas
            /// </summary>
        private void AddSegmentoTransferenciaEC(string cuentaCajaBancoOrigen, string cuentaCajaBancoDestino, string tipoLx,decimal importeMonedaTx, string monedaTransaccion, int? chequeId=null)
            {
                var dataOrigen = new CuentasManager().GetSpecificCuentaInfo(cuentaCajaBancoOrigen);
                var dataDestino = new CuentasManager().GetSpecificCuentaInfo(cuentaCajaBancoDestino);
                //
                var glo = new CuentasManager().GetGL(cuentaCajaBancoOrigen);
                var gld = new CuentasManager().GetGL(cuentaCajaBancoDestino);
                var monedaO = dataOrigen.CUENTA_MONEDA;
                var monedaD = dataDestino.CUENTA_MONEDA;
                string desc2=null;
                string nombreTablaReferencia=null;

                //todo: si la moneda no coincide monedaO - monedaD --- convertir a monedaTransaccion los importes


                switch (cuentaCajaBancoOrigen)
                {
                    case "CHE":
                        nombreTablaReferencia = "T0154_CHEQUES";
                        desc2 = "CHID@" + chequeId.ToString();
                        break;

                    default:
                        nombreTablaReferencia = null;
                        desc2 = cuentaCajaBancoOrigen + ">>" + cuentaCajaBancoDestino;
                        break;
                }

                base.AddGenericCompleteSegment("TXS", base.Header.REFE, tipoLx, glo, "Tx Destino " + cuentaCajaBancoDestino, desc2,
                    monedaTransaccion, DebeHaber.Haber, importeMonedaTx, base.Tcode, 0, 0, nombreTablaReferencia, chequeId);

                base.AddGenericCompleteSegment("TXE", base.Header.REFE, tipoLx, gld, "Tx Origen " + cuentaCajaBancoOrigen, desc2,
                    monedaTransaccion, DebeHaber.Debe, importeMonedaTx, base.Tcode, 0, 0, nombreTablaReferencia, chequeId);
        }

    }
}
