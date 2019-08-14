using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Tools;
using TecserEF.Entity;using Tecser.Business.MainApp;
using WebServicesAFIP;


namespace Tecser.Business.Transactional.FI
{
    public class FacturacionElectronicaTecser
    {
        public FacturacionElectronicaTecser(ModoEjecucion modoEjecucion)
        {
            _modoEjecucion = modoEjecucion;
        }
        //------------------------------------------------------------------------------------------------
        private readonly ModoEjecucion _modoEjecucion;
        //------------------------------------------------------------------------------------------------
        public bool PermiteSolicitarCAE(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                if (data == null)
                    return false;

                if (data.TIPOFACT != "L1")
                    return false;

                if (!string.IsNullOrEmpty(data.CAE))
                    return false;

                if (data.StatusFactura.ToUpper() !=
                    DocumentFIStatusManager.StatusHeader.PendienteCAE.ToString().ToUpper())
                    return false;

                if (!string.IsNullOrEmpty(data.PV_AFIP))
                    return false;

                if (!string.IsNullOrEmpty(data.ND_AFIP))
                    return false;

            }
                return true;
        }
        private FESetDataStructure FillFacturaElectronicaStructure(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var doc = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                var data = new FESetDataStructure();

                if (doc != null)
                {
                    //Existe el documento.
                    if (doc.TIPOFACT == "L1")
                    {
                        data.Concepto = 1; //Productos
                        data.TipoDocumento = 80; //80 = CUIT (NTAX1)
                        data.NumeroDocumento = doc.CUIT; //Numero CUIT
                        
                        switch (doc.TIPO_DOC)
                        {
                            case "FA":
                                data.TipoComprobante = TipoComprobante.Factura; //tipo_cbte >>  TipoDocumento
                                break;
                            case "NC":
                                data.TipoComprobante = TipoComprobante.NotaCredito;
                                break;
                            case "ND":
                                data.TipoComprobante = TipoComprobante.NotaDebito;
                                break;
                            case "FM":
                                data.TipoComprobante = TipoComprobante.FacturaM;
                                break;
                            case "CM":
                                data.TipoComprobante =  TipoComprobante.NotaCreditoM;
                                break;
                            case "DM":
                                data.TipoComprobante = TipoComprobante.NotaDebitoM;
                                break;
                            default:
                                return null;
                        }

                        data.PuntoVenta = 4; //todo: localizar en tabla 
                        data.ImporteTotal = FormatAndConversions.DefineFormatoNumericoAFIP(doc.TotalFacturaN);
                        decimal noGrav = (doc.TotalFacturaB-doc.Descuento.Value - doc.TotalImpo);
                        data.ImporteNoGravado = FormatAndConversions.DefineFormatoNumericoAFIP(noGrav);


                        //Importe Total
                        data.BaseImponible = FormatAndConversions.DefineFormatoNumericoAFIP(doc.TotalImpo);
                        //No va el Neto porque es la base imponible
                        //IVA
                        data.ImporteIVA = FormatAndConversions.DefineFormatoNumericoAFIP(doc.TotalIVA21);
                        var structIva = new TributosAfip();
                        if (doc.TotalIVA21 > 0)
                        {
                            //IVA es por ahora solo IVA21  
                            structIva.IdTributo = "5"; //21%
                            structIva.BaseImponible = data.BaseImponible;
                            structIva.Importe = data.ImporteIVA;
                        }
                        else
                        {
                            structIva.IdTributo = "3"; //0%
                            structIva.BaseImponible = "0.00";
                            structIva.Importe = "0.00";
                        }
                        data.IvaDetalle.Add(structIva);

                        //Manejo de Ingresos Brutos Provincia Buenos Aires
                        data.ImporteTributos = FormatAndConversions.DefineFormatoNumericoAFIP(doc.TotalIIBB);
                        if (doc.TotalIIBB > 0)
                        {
                            var structIIBB = new TributosAfip
                            {
                                IdTributo = "2",
                                Alicuota = FormatAndConversions.DefineFormatoNumericoAFIP(doc.IIBB_PORC*100),
                                Descripcion = "Percep IIBB Pcia Bs As",
                                BaseImponible = data.BaseImponible,
                                Importe = data.ImporteTributos
                            };
                            data.TributosDetalle.Add(structIIBB);
                        }
                        data.FechaComprobante = doc.FECHA.Value;
                        data.ImporteNeto = FormatAndConversions.DefineFormatoNumericoAFIP(doc.TotalImpo);
                        //>>Este no se informa >> se informa Base Imponible

                        if (doc.FacturaMoneda == "ARS")
                        {
                            data.MonedaId = "PES";
                            data.Cotizacion = "1.000";
                        }
                        else
                        {
                            data.MonedaId = "";
                            data.Cotizacion = "";
                        }
                        return data;
                    }
                }
                throw new Exception("Tipo Factura no corresponde a solicitud de CAE");
            }
        }
        public struct CheckNumeroComprobantes
        {
            public bool UltimoComprobanteIsOk { get; set; }
            public int UltimoComprobanteMAS { get; set; }
            public int UltimoComrobanteAFIP { get; set; }
        }
        public FEGetDataStructure SolicitudCAEFromT0400(int idFacturaX)
        {
            var data = this.FillFacturaElectronicaStructure(idFacturaX);
            if (data.NumeroDocumento != null)
            {
                var result = new FacturaElectronicaWs(_modoEjecucion).SolicitaCAEAfip(data);
                if (result.Resultado == "A")
                {
                    //Solicitud de CAE aprobado
                    return result;
                }
                else
                {
                    //Solicitud de CAE Rechazado u Observado
                    return result;
                    MessageBox.Show(result.Wsfev1Error);
                }
            }
            return new FEGetDataStructure();
        }
        public CheckNumeroComprobantes ValidaNumeracionComprobantes(TipoComprobante tipoComprobante)
        {
            var ultimoComprobanteMas = 0;
            var ultimoComprobanteAFIP = 0;
            var puntoVenta = 0;
            CheckNumeroComprobantes dataResult = new CheckNumeroComprobantes();

            switch (tipoComprobante)
            {
                case TipoComprobante.Factura:
                    ultimoComprobanteMas = Convert.ToInt32(ConfigurationDataT000.GetValue("NFAW"));
                    puntoVenta = Convert.ToInt32(ConfigurationDataT000.GetValue("PFAW"));
                    ultimoComprobanteAFIP =
                        Convert.ToInt32(
                            new FacturaElectronicaWs(_modoEjecucion).ObtieneUltimosComprobantesAFIP(puntoVenta)
                                .UltimaFactura);
                    break;

                case TipoComprobante.NotaCredito:
                    ultimoComprobanteMas = Convert.ToInt32(ConfigurationDataT000.GetValue("NNCW"));
                    puntoVenta = Convert.ToInt32(ConfigurationDataT000.GetValue("PNCW"));
                    ultimoComprobanteAFIP =
                        Convert.ToInt32(
                            new FacturaElectronicaWs(_modoEjecucion).ObtieneUltimosComprobantesAFIP(puntoVenta)
                                .UltimaNotaCredito);
                    break;

                case TipoComprobante.NotaDebito:
                    ultimoComprobanteMas = Convert.ToInt32(ConfigurationDataT000.GetValue("NNDW"));
                    puntoVenta = Convert.ToInt32(ConfigurationDataT000.GetValue("PNDW"));
                    ultimoComprobanteAFIP =
                        Convert.ToInt32(
                            new FacturaElectronicaWs(_modoEjecucion).ObtieneUltimosComprobantesAFIP(puntoVenta)
                                .UltimaNotaDebito);
                    break;
            }

            dataResult.UltimoComprobanteMAS = ultimoComprobanteMas;
            dataResult.UltimoComrobanteAFIP = ultimoComprobanteAFIP;
            dataResult.UltimoComprobanteIsOk = ultimoComprobanteMas == ultimoComprobanteAFIP;
            return dataResult;
        }
        public bool ActualizaUlimoComprobanteTabla(TipoComprobante tipoComprobante, string numeroDocumento)
        {
            switch (tipoComprobante)
            {
                case TipoComprobante.Factura:
                    return ConfigurationDataT000.SetData("NFAW", numeroDocumento);
                case TipoComprobante.NotaCredito:
                    return ConfigurationDataT000.SetData("NNCW", numeroDocumento);
                case TipoComprobante.NotaDebito:
                    return ConfigurationDataT000.SetData("NNDW", numeroDocumento);
                default:
                    return false;
            }
        }
        public void UpdateDataAfterDocumentNumberGetFromAFIP(int idFactura, string puntoVenta, string numeroDocumento,
            string numeroCAE, DateTime vencimientoCAE,int numeroAsiento)
        {
            int? idfx = null;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t400 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                if (t400 == null) return;

                t400.PV_AFIP = puntoVenta;
                t400.ND_AFIP = numeroDocumento;
                t400.CAE = numeroCAE;
                t400.CAE_VTO = vencimientoCAE;
                t400.StatusFactura = DocumentFIStatusManager.StatusHeader.Aprobada.ToString().ToUpper();

                var items = db.T0401_FACTURA_I.Where(c => c.IDFactura == idFactura).ToList();
                foreach (var i in items)
                {
                    i.NUMFACTURA = puntoVenta + "-" + numeroDocumento;
                }

                db.SaveChanges();

                idfx = t400.IDFACTURAX;
                if (idfx == null)
                    return;
            }

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var idfxstr = idfx.ToString();
                var d201 = db.T0201_CTACTE.SingleOrDefault(c => c.DOC_INTERNO == idfxstr);
                if (d201 == null)
                    return;
                d201.NUMDOC = numeroDocumento;
                db.SaveChanges();
            }

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d207 = db.T0207_SPLITFACTURAS.Where(c => c.IDDOC == idfx).ToList();
                foreach (var i in d207)
                {
                    i.TDOC = i.TDOC;
                    i.FACTSPLIT = i.FACTSPLIT;
                    i.NDOC = puntoVenta + "-" + numeroDocumento;
                    db.SaveChanges();
                }
                db.SaveChanges();
            }

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h600 = db.T0601_DOCU_H.SingleOrDefault(c => c.IDDOCU == numeroAsiento);
                if (h600 != null)
                {
                    h600.REFE = puntoVenta + "-" + numeroDocumento; 
                }
                var h602 = db.T0602_DOCU_S.Where(c => c.IDDOCU == numeroAsiento).ToList();
                foreach (var ix in h602)
                {
                    ix.REFE = puntoVenta + "-" + numeroDocumento; 
                }
                db.SaveChanges();
            }
        }
    }
}