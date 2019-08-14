using System;
using System.Collections.Generic;
using System.Linq;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.Transactional.FI.Cobranza
{
    public struct DiasImputacion
    {
        public int? DiasPP_FacturaRecibo;
        public int? DiasPP_ReciboPago;
        public bool ImputacionCompleta;
        public bool ErrorDetectado;
    }
    public class CobranzaUtils
    {
        public List<T0207_SPLITFACTURAS> GetListaImputacionPorRecibo(int idCobranza)
        {
            string idCobRecibo = idCobranza.ToString();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0207_SPLITFACTURAS.Where(c => c.NRECIBO == idCobRecibo).OrderBy(c=>c.IDCTACTE).ToList();
            }
        }
        public string GetReciboOficialSucursal()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
               return db.T000.SingleOrDefault(c => c.ID == "SUCRECL1").VALUE;
            }
        }
        public string GetNextReciboOficial()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rofi = db.T000.SingleOrDefault(c => c.ID == "NUMRECL1");
                int numero = Convert.ToInt32(rofi.VALUE);
                numero = numero+1;
                return numero.ToString("D8");
            }
        }
        public void SaveUltimoReciboUtilizado(string numeroRecibo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rofi = db.T000.SingleOrDefault(c => c.ID == "NUMRECL1");
                rofi.VALUE = numeroRecibo;
                db.SaveChanges();
            }
        }
        public int FixCobranzaDiasPp()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cob = db.T0205_COBRANZA_H.Where(c => c.DIAS_PP == null || c.DIAS_PP ==0).OrderByDescending(c=>c.IDCOB).Take(300).ToList();
                foreach (var lst in cob)
                {
                    var r = db.T0206_COBRANZA_I.Where(c => c.IDCOB == lst.IDCOB).ToList();
                    if (r.Count > 0)
                    {
                        var dias = CalculaDiasPromedioPago(r, lst.FECHA.Value);
                        lst.DIAS_PP = dias;
                    }
                }
                return db.SaveChanges();

            }
        }
        public int CalculaDiasPromedioPago(List<T0206_COBRANZA_I> list, DateTime fechaRecibo)
        {
            decimal diasPP = 0;
            int diasCH = 0;

            decimal importeComputo = 0;
            foreach (var it in list)
            {
                switch (it.CUENTA)
                {
                    case "ARS":
                        importeComputo += it.IMP_RECIBO.Value;
                        break;
                    case "CHE":
                        importeComputo += it.IMP_RECIBO.Value;
                        break;
                    case "USD":
                        importeComputo += it.IMP_RECIBO.Value;
                        break;
                    case "GAL":
                        importeComputo += it.IMP_RECIBO.Value;
                        break;
                    case "SAN":
                        importeComputo += it.IMP_RECIBO.Value;
                        break;
                    case "ICBC":
                        importeComputo += it.IMP_RECIBO.Value;
                        break;
                    default:
                        //son las cuentas Bonos/Retenciones que no computan 
                        break;
                }
            }

            foreach (var it in list)
            {
                if (it.CHEQUE_FECHA == null)
                {
                    diasCH = 0;
                }
                else
                {
                    TimeSpan ts = it.CHEQUE_FECHA.Value - fechaRecibo;
                    if (ts.Days < 0)
                    {
                        diasCH = 0;
                    }
                    else
                    {
                        diasCH = ts.Days;
                    }
                }
                diasPP = diasPP + (diasCH*it.IMP_RECIBO.Value);
            }
            if (importeComputo == 0)
                return 0;
            return Convert.ToInt32(diasPP/importeComputo);
        }
        public int CalculoDiasPromedioPago(int idCob)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var fechaCob = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == idCob).FECHA.Value;
                var listCobranza = db.T0206_COBRANZA_I.Where(c => c.IDCOB == idCob).ToList();
                return CalculaDiasPromedioPago(listCobranza, fechaCob);
            }
        }
        public void GuardaDiasPP_TCobranza(int idCob, int diasPP)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == idCob);
                x.DIAS_PP = diasPP;
                db.SaveChanges();

            }
        }
        public T0201_CTACTE GetT0201FromCobranza(int idCob)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0201_CTACTE.SingleOrDefault(c => c.IDT2 == idCob);
                return data;
            }
        }
        public DiasImputacion DiasPromedioPagoFacturaImputada(int idCtaCte)
        {

            DiasImputacion rtn;
            rtn.DiasPP_FacturaRecibo = null;
            rtn.DiasPP_ReciboPago = null;
            rtn.ImputacionCompleta = false;
            rtn.ErrorDetectado = false;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cc = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCte);

                if (cc?.SALDOFACTURA != 0)
                {
                    //Si el documento no esta imputada al 100% no realiza calculo y retorna null.
                    return rtn;
                }

                rtn.ImputacionCompleta = true; //SalldoFactura ==0
                
                if (cc.TDOC == "FA" || cc.TDOC == "ND")
                {
                    
                }
                else
                {
                    //Si el documento no es FA o ND no realiza calculo
                    //Esta condicion debiera ser un error porque solo se pueden imputar FA/ND
                    rtn.ErrorDetectado = true;
                    return rtn;
                }

                var importeDoc = cc.IMPORTE_ORI;
                var data207 =db.T0207_SPLITFACTURAS.Where(c => c.IDCTACTE == idCtaCte && c.MONTO_APLICADO != 0).ToList();
                decimal accImpu = 0;
                decimal accRecibo = 0;
                decimal importeCk = 0;
                foreach (var d207 in data207)
                {
                    if (d207.PFECHA==null)
                        d207.PFECHA=DateTime.Today;
                    //Esto es un FIX por las dudas pero a la fecha 2019-04-03 no hay ningun issue.
                    
                    var difPagoFact = (d207.PFECHA.Value- cc.Fecha.Value);
                    var diasPagoFactura = difPagoFact.Days;
                    accImpu += (diasPagoFactura*d207.MONTO_APLICADO.Value);
                    importeCk += d207.MONTO_APLICADO.Value;

                    int n;
                    var isNumeric = int.TryParse(d207.NRECIBO, out n);
                    if (isNumeric)
                    {
                        var idCob = Convert.ToInt32(d207.NRECIBO);
                        var diasRecibo = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == idCob);
                        if (diasRecibo.DIAS_PP == null)
                        {
                            rtn.DiasPP_ReciboPago = null;
                        }
                        else
                        {
                            accRecibo += (diasRecibo.DIAS_PP.Value*d207.MONTO_APLICADO.Value);
                        }
                    }
                    else
                    {
                        rtn.DiasPP_ReciboPago = null;
                    }
                }

                //if (importeCk != importeDoc)
                //    return rtn;

                if (importeDoc == 0)
                    return rtn;

                rtn.DiasPP_FacturaRecibo = Convert.ToInt32(accImpu/importeDoc);
                rtn.DiasPP_ReciboPago = Convert.ToInt32(accRecibo/importeDoc);
            }
            return rtn;
        }
        public DiasImputacion GetInfoDiasPPFromTable201(int idCtaCte)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rtn = new DiasImputacion();
                var info = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCte);
                rtn.DiasPP_FacturaRecibo = info.DiasPImputacion;
                rtn.DiasPP_ReciboPago = info.DiasPAcreditacion;
                return rtn;
            }
        }
        public void SetInfoDiasPPToTable201(int idCtaCte, int? diasFacturaRecibo, int? diasReciboPago)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var info = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCte);
                info.DiasPImputacion = diasFacturaRecibo;
                info.DiasPAcreditacion = diasFacturaRecibo;
                db.SaveChanges();
            }
        }
    }
}
