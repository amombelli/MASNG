using System;
using System.Collections.Generic;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI.CtaCte;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    public class TraspasoSaldoCliente
    {


        //---------------------------------------------------------------------------------------------------------------------------
        private List<T0300_NCD_H> _data300 = new List<T0300_NCD_H>();

        //---------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Genera documento traspaso saldos mismo tipo -> a diferente cliente
        /// ->Son 2 documentos AJN + AJP juntos
        /// </summary>
        public void GeneraDocumentoTraspasoADiferenteCliente(string tipoLx, int idClienteOri, int idClienteDest, DateTime fechaDoc,
            decimal tc, decimal importe, string comentario, string moneda = "ARS")
        {
            GeneraT300HeaderMemoria(tipoLx, idClienteOri, idClienteDest, importe, tc, fechaDoc, comentario, moneda);
            foreach (var item in _data300)
            {
                decimal signo;
                bool addRecordTo208 = false;
                var clienteAlternativo=0;
                if (item.TDOC == "AJN")
                {
                    signo = -1;
                    clienteAlternativo = idClienteDest;
                    addRecordTo208 = true;
                }
                else
                {
                    signo = 1;
                    clienteAlternativo = idClienteOri;
                    addRecordTo208 = false;
                }
                var ncdH = new CustomerNcdAjustes().GrabaT300HeaderData(item);
                var gl = GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.AR);
                new CustomerNcdAjustes().AddNcdItem(ncdH,"AJCONTA", item.MON,importe, gl);

                var ctacte = new CtaCteCustomer(item.CLINUM.Value);
                var idCtaCte = ctacte.AddCtaCteDetalleRecord(item.TDOC, item.TIPO, item.FECHA.Value,
                    item.NDOC,ncdH.ToString(), item.MON, item.TOTAL_ARS_NETO.Value*signo, item.TC.Value, item.TOTAL_ARS_NETO.Value * signo,
                    item.TOTAL_ARS_NETO.Value*signo,ncdH);

                if (addRecordTo208)
                {
                    ctacte.AddSinImputarRecord(idCtaCte);
                }
                else
                {
                    ctacte.AddRecordDocumentT0207FromIdCtaCte(idCtaCte);
                }
                ctacte.UpdateSaldoCtaCteResumen(item.TIPO, item.TOTAL_ARS_NETO.Value*signo, item.MON, item.TC);
                

                var resultadoAsiento =
                    new AsientoGenerico(GlobalApp.Tcode).CreaAsientoTraspasoSaldos(item.TDOC,fechaDoc, item.CLINUM.Value, tipoLx, clienteAlternativo, tipoLx, importe, tc, item.NDOC,
                        comentario,
                        moneda);

                if (resultadoAsiento == null)
                {
                    //Atencion capturar porque se paso mal el tipo de documento!
                }
                else
                {
                    item.ASIENTO = resultadoAsiento.Value.IdDocu;
                    item.idCtaCte = idCtaCte;
                    new CustomerNcdAjustes().UpdateNCDHAfterConta(ncdH,item.ASIENTO.Value,item.idCtaCte.Value);
                }
            }
        }

    
        /// <summary>
        /// Genera en memoria 2 documentos de ajuste uno Neg y otro POS
        /// </summary>
        private void GeneraT300HeaderMemoria(string tipoLx, int id6Ori, int id6Des, decimal importe, decimal tc,
            DateTime fechaDoc, string comentario, string moneda = "ARS")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //Cliente Original Resta Deuda AJN
                var dataNegativo = new T0300_NCD_H()
                {
                    IDH = 0,
                    TDOC =
                        ManageDocumentType.GetSystemDocumentType(ManageDocumentType.TipoDocumento.AjusteSaldoNegativo),
                    NDOC = "0",
                    CLINUM = id6Ori,
                    MON = moneda,
                    CLITXT = new CustomerManager().GetCustomerBillToData(id6Ori).cli_rsocial,
                    TC = tc,
                    FECHA = fechaDoc,
                    LOGDATE = DateTime.Now,
                    LOGUSER = Environment.UserName,
                    idCtaCte = 0,
                    ASIENTO = 0,
                    COMENTARIO = comentario,
                    TIPO = tipoLx,
                };

                if (moneda == "ARS")
                {
                    dataNegativo.TOTAL_ARS_NETO = importe;
                    dataNegativo.TOTAL_USD_NETO = decimal.Round(importe/tc, 2);
                }
                else
                {
                    dataNegativo.TOTAL_ARS_NETO = decimal.Round(importe*tc, 2);
                    dataNegativo.TOTAL_USD_NETO = importe;
                }
                _data300.Add(dataNegativo);

                //En Cliente Destino suma Saldo Positivo
                var dataPositivo = new T0300_NCD_H()
                {
                    IDH = 0,
                    TDOC =
                        ManageDocumentType.GetSystemDocumentType(ManageDocumentType.TipoDocumento.AjusteSaldoPositivo),
                    NDOC = "0",
                    CLINUM = id6Des,
                    MON = moneda,
                    CLITXT = new CustomerManager().GetCustomerBillToData(id6Des).cli_rsocial,
                    TC = tc,
                    FECHA = fechaDoc,
                    LOGDATE = DateTime.Now,
                    LOGUSER = Environment.UserName,
                    idCtaCte = 0,
                    ASIENTO = 0,
                    COMENTARIO = comentario,
                    TIPO = tipoLx,
                };

                if (moneda == "ARS")
                {
                    dataPositivo.TOTAL_ARS_NETO = importe;
                    dataPositivo.TOTAL_USD_NETO = decimal.Round(importe/tc, 2);
                }
                else
                {
                    dataPositivo.TOTAL_ARS_NETO = decimal.Round(importe*tc, 2);
                    dataPositivo.TOTAL_USD_NETO = importe;
                }
                _data300.Add(dataPositivo);
            }
        }



        private void GeneraItemT301Memoria()
        {
#pragma warning disable CS0219 // The variable 'i' is assigned but its value is never used
            int i = 0;
#pragma warning restore CS0219 // The variable 'i' is assigned but its value is never used
            var data = new T0301_NCD_I()
            {
                
            };
        }


       
    }
}
