using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.TOOLS;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.Transactional.Cierre
{
    public class RetornaConciliacion
    {
        public string Periodo { get; set; }
        public decimal Cob205 { get; set; }
        public decimal  Cob201 { get; set; }
        public decimal Factu400 { get; set; }
        public decimal Factu201 { get; set; }
        public bool OkCob { get; set; }
        public bool OkFactu { get; set; }

    }
    public class ConciliaGeneral
    {

        public List<RetornaConciliacion> ConciliaDesde(string periodoInicial, int cantidadPeriodos, string tipoLx, bool includeFa = true, bool includeNc = true, bool includeNd = true, bool includeAj = true)
        {
            var rtn = new List<RetornaConciliacion>();
            var periodo = periodoInicial;
            for (int i = 0; i < cantidadPeriodos; i++)
            {
                rtn.Add(ConciliaCobranzaGeneral(periodo, tipoLx, includeFa, includeNc, includeNd, includeAj));
                periodo = new PeriodoConversion().GetProximoPeriodo(periodo);
            }
            return rtn;
        }
        public RetornaConciliacion ConciliaCobranzaGeneral(string periodo, string tipoLx,bool includeFa=true,bool includeNc=true,bool includeNd=true,bool includeAj=true)
        {



            DateTime fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            DateTime fechaD = new PeriodoConversion().GetFechaUltimoDiaPeriodo(periodo).AddDays(1); //traia problemas con el ultimo dia + horas
            var rtn = new RetornaConciliacion();
            rtn.Periodo = periodo;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                List<T0400_FACTURA_H> lista400_ = new List<T0400_FACTURA_H>();
                List<T0201_CTACTE> lista201 = new List<T0201_CTACTE>();
                if (tipoLx == "L3")
                {
                    //**SIN TIPO
                    rtn.Cob205 =
                        db.T0205_COBRANZA_H.Where(
                            c =>
                                c.FECHA >= fechaI && c.FECHA < fechaD && c.DOC_CANCELADO.Value == false)
                            .Sum(c => c.Monto.Value);

                    rtn.Cob201 =
                        db.T0201_CTACTE.Where(
                            c =>
                                c.Fecha >= fechaI && c.Fecha < fechaD && c.TDOC == "CO" &&
                                c.CK != "False")
                            .Sum(c => c.IMPORTE_ARS)*-1;

                    lista400_ = db.T0400_FACTURA_H.Where(c => c.FECHA >= fechaI && c.FECHA < fechaD).ToList();

                    lista201 = db.T0201_CTACTE.Where(
                        c => c.Fecha >= fechaI && c.Fecha < fechaD && c.CK != "False").ToList();
                }
                else
                {
                    //CON TIPO
                    rtn.Cob205 =
                        db.T0205_COBRANZA_H.Where(
                            c =>
                                c.FECHA >= fechaI && c.FECHA < fechaD && c.DOC_CANCELADO.Value == false &&
                                c.CUENTA == tipoLx).Sum(c => c.Monto.Value);

                    rtn.Cob201 =
                        db.T0201_CTACTE.Where(
                            c =>
                                c.Fecha >= fechaI && c.Fecha < fechaD && c.TIPO == tipoLx && c.TDOC == "CO" &&
                                c.CK != "False")
                            .Sum(c => c.IMPORTE_ARS)*-1;

                    lista400_ =
                        db.T0400_FACTURA_H.Where(c => c.TIPOFACT == tipoLx && c.FECHA >= fechaI && c.FECHA < fechaD)
                            .ToList();
                    lista201 =
                        db.T0201_CTACTE.Where(
                            c => c.Fecha >= fechaI && c.Fecha < fechaD && c.TIPO == tipoLx && c.CK != "False").ToList();
                }

                var lista400 = new List<T0400_FACTURA_H>();
                lista400.AddRange(lista400_.Where(c=>c.StatusFactura.ToUpper()=="REGISTRADA"));
                lista400.AddRange(lista400_.Where(c => c.StatusFactura.ToUpper() == "APROBADA"));

                decimal fa400 = 0;
                decimal nc400 = 0;
                decimal nd400 = 0;
                decimal aj400 = 0;


                foreach (var i in lista400)
                {
                    switch (i.TIPO_DOC)
                    {
                        case "FA":
                            fa400 += i.TotalFacturaN;
                            break;
                        case "FM":
                            fa400 += i.TotalFacturaN;
                            break;
                        case "FB":
                            fa400 += i.TotalFacturaN;
                            break;
                        case "NC":
                            nc400 -= i.TotalFacturaN;
                            break;
                        case "ND":
                            nd400 += i.TotalFacturaN;
                            break;
                        case "DM":
                            fa400 += i.TotalFacturaN;
                            break;
                        case "CM":
                            fa400 -= i.TotalFacturaN;
                            break;
                        case "DB":
                            fa400 += i.TotalFacturaN;
                            break;
                        case "CB":
                            fa400 -= i.TotalFacturaN;
                            break;
                        case "AJ":
                            aj400 += i.TotalFacturaN;
                            break;
                        case "AJ-":
                            aj400 -= i.TotalFacturaN;
                            //esto lo agregue cuando implementemos Ajustes para determinar el signo
                            break;
                        case "AJ+":
                            aj400 += i.TotalFacturaN;
                            //esto lo agregue cuando implementemos Ajustes para determinar el signo
                            break;
                        default:
                            break;
                    }
                }


               

                decimal fa201 = 0;
                decimal nc201 = 0;
                decimal nd201 = 0;
                decimal aj201 = 0;


                foreach (var i in lista201)
                {
                    switch (i.TDOC)
                    {
                        case "R2":
                            fa201 += i.IMPORTE_ARS;
                            break;
                        case "FA":
                            fa201 += i.IMPORTE_ARS;
                            break;
                        case "FM":
                            fa201 += i.IMPORTE_ARS;
                            break;
                        case "FB":
                            fa201 += i.IMPORTE_ARS;
                            break;
                        case "NC":
                            nc201 += i.IMPORTE_ARS;
                            break;
                        case "CB":
                            nc201 += i.IMPORTE_ARS;
                            break;
                        case "CM":
                            nc201 += i.IMPORTE_ARS;
                            break;
                        case "ND":
                            nd201 += i.IMPORTE_ARS;
                            break;
                        case "DM":
                            nd201 += i.IMPORTE_ARS;
                            break;
                        case "DB":
                            nd201 += i.IMPORTE_ARS;
                            break;
                        case "AJ":
                            aj201 += i.IMPORTE_ARS;
                            break;
                        case "AJ-":
                            aj201 += i.IMPORTE_ARS;
                            break;
                        default:
                            break;
                    }
                }

                decimal importeFactu400 = 0;
                decimal importeFactu201 = 0;

                if (includeFa)
                {
                    importeFactu400 += fa400;
                    importeFactu201 += fa201;
                }

                if (includeNc)
                {
                    importeFactu400 += nc400;
                    importeFactu201 += nc201;
                }

                if (includeNd)
                {
                    importeFactu400 += nd400;
                    importeFactu201 += nd201;
                }

                if (includeAj)
                {
                    importeFactu400 += aj400;
                    importeFactu201 += aj201;
                }

                rtn.Factu201 = importeFactu201;
                rtn.Factu400 = importeFactu400;

                rtn.OkCob = false;
                rtn.OkFactu = false;
                if (rtn.Cob201 == rtn.Cob205)
                    rtn.OkCob = true;

                if (rtn.Factu201 == rtn.Factu400)
                    rtn.OkFactu = true;
            }
            return rtn;
        }

        public List<T0400_FACTURA_H> RetornaListaDocumentosPeriodo(string periodo, string tipoLx, bool includeFa = true,
            bool includeNc = true, bool includeNd = true, bool includeAj = true)
        {
            List<T0400_FACTURA_H> rtn = new List<T0400_FACTURA_H>();
            DateTime fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            DateTime fechaD = new PeriodoConversion().GetFechaUltimoDiaPeriodo(periodo).AddDays(1);//para evitar problemas con las horas pasadas del ultimo dia
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //ver si hay que agregar distinto de status=registrada
                var lista400_ =
                    db.T0400_FACTURA_H.Where(c =>c.TIPOFACT == tipoLx && c.FECHA >= fechaI && c.FECHA < fechaD).ToList();


                var lista400 = new List<T0400_FACTURA_H>();
                lista400.AddRange(lista400_.Where(c => c.StatusFactura.ToUpper() == "REGISTRADA"));
                lista400.AddRange(lista400_.Where(c => c.StatusFactura.ToUpper() == "APROBADA"));


                if (includeFa)
                {
                    rtn.AddRange(lista400.Where(c => c.TIPO_DOC == "FA").ToList());
                    rtn.AddRange(lista400.Where(c => c.TIPO_DOC == "R2").ToList());
                }


                if (includeNc)
                    rtn.AddRange(lista400.Where(c => c.TIPO_DOC == "NC").ToList());

                if (includeNd)
                    rtn.AddRange(lista400.Where(c => c.TIPO_DOC == "ND").ToList());

                if (includeAj)
                {
                    rtn.AddRange(lista400.Where(c => c.TIPO_DOC == "AJ").ToList());
                    rtn.AddRange(lista400.Where(c => c.TIPO_DOC == "AJ+").ToList());
                    rtn.AddRange(lista400.Where(c => c.TIPO_DOC == "AJ-").ToList());
                }
                return rtn;
            }
        }
    }
}
