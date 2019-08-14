using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Policy;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.CO.Costos
{
    /// <summary>
    /// Clase que Admnistra las acciones sobre los costos de reposicion/UC
    /// Tabla T0033_COSTOS >> caducar todo lo que venga de T0033!!!
    ///
    /// 2020.05.10 Tabla COSTO_UC 0036
    /// </summary>
    public class CostoReposicion:CostoBaseManager
    {
        public struct CostoRepo
        {
            public decimal ARS;
            public decimal USD;
            public DateTime Fecha;
            public decimal Kg;
            public string VendorUc;
            public string MonedaCosto;
            public bool ManualUpdated;
            public decimal VarArs;
            public decimal VarUsd;
            public DateTime FechaCostoAnterior;
        }
        public void FixCostosReposicionCeroOldVersion(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d404 = db.T0404_VENDOR_FACT_I.Where(c => c.ITEM_DESC == material)
                    .OrderByDescending(c => c.T0403_VENDOR_FACT_H.FECHA).ToList();
                foreach (var it in d404)
                {
                    if (it.MONEDA == null)
                        it.MONEDA = "ARS";

                    if (it.MonedaItemProveedor == null)
                        it.MonedaItemProveedor = "USD";

                    if (it.TC == null || it.TC == 0)
                        it.TC = new ExchangeRateManager().GetExchangeRate(it.T0403_VENDOR_FACT_H.FECHA);


                    if (it.CANT == null || it.CANT.Value == 0)
                        it.CANT = 1;
                    
                    if (it.PUNIT_ARS == null || it.PUNIT_ARS ==0)
                        it.PUNIT_ARS = decimal.Round((it.SUBTOTAL.Value / it.CANT.Value), 3);

                    if (it.PUNIT_USD == null || it.PUNIT_USD==0)
                        it.PUNIT_USD = decimal.Round((it.SUBTOTAL.Value / it.CANT.Value / it.TC.Value), 3);

                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Funcion para hacer el FIX cuando no hay ningun registro en el sistema
        /// </summary>
        public void FixObtieneCostoUcFromUltimoRegistro(string material)
        {
            decimal tc = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d404 = db.T0404_VENDOR_FACT_I.Where(c => c.ITEM_DESC == material)
                    .OrderByDescending(c => c.T0403_VENDOR_FACT_H.FECHA).Take(1).ToList();

                if (d404.Any())
                {
                    var x = d404[0];
                    if (x.PUNIT_USD == 0 || x.PUNIT_USD==null)
                    {
                        //Version vieja no manejaba PUNIT y Contabilizaba solo en ARS
                        x.MONEDA = "ARS";
                        x.PUNIT_ARS = decimal.Round((x.SUBTOTAL.Value / x.CANT.Value), 3);
                        x.PUNIT_USD = decimal.Round((x.PUNIT_ARS.Value / x.TC.Value), 3);
                    }
                    db.SaveChanges();
                    AddUpdateCosto(material, x.CANT.Value, "USD", tc, x.PUNIT_USD.Value, x.T0403_VENDOR_FACT_H.IDPROV,
                        x.T0403_VENDOR_FACT_H.FECHA, x.T0403_VENDOR_FACT_H.LOGUSER);
                }
            }
        }

        /// <summary>
        /// Update: 2020.05.10 T0036
        /// Incluye Flag CostUpdated despues del ultimo cost roll
        /// Metodo para Agregar el costo de UC/Reposicion al contabilizar una compra de MP 
        /// </summary>
        public void AddUpdateCosto(string material, decimal kg, string monedaCosto, decimal tc, decimal costoUnitarioUc,
            int proveedorId, DateTime fechaConta, string user, bool manualUpdated = false, string userUpdated = null,
            DateTime? dateUpdated = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cost = db.T0036_CostoReposicion.SingleOrDefault(c => c.Material == material);
                var matData = MaterialMasterManager.GetSpecificPrimaryInformation(material);
                if (cost == null)
                {
                    var x = new T0036_CostoReposicion()
                    {
                        MonedaCosto = monedaCosto,
                        Material = material,
                        TCConversion = tc,
                        CostoPPPUsd = 0,
                        CostoPPPArs = 0,
                        FechaCompraAnterior = fechaConta,
                        FechaUC = fechaConta,
                        ProveedorID = proveedorId,
                        VarCostoUCUsd = 0,
                        VarCostoUCArs = 0,
                        DateManualUpd = null,
                        UserManualUpd = null,
                        UserConta = user,
                        ManualUpdated = manualUpdated,
                        KgUC = kg,
                        Origen = matData.ORIGEN,
                        CostoUpdatedCostRoll = false //indica costo no fue actualizado despues del CRoll
                    };
                    if (monedaCosto == "USD")
                    {
                        x.CostoUCUsd = costoUnitarioUc;
                        x.CostoUCArs = costoUnitarioUc * tc;
                    }
                    else
                    {
                        x.CostoUCArs = costoUnitarioUc;
                        x.CostoUCUsd = costoUnitarioUc / tc;
                    }
                    db.T0036_CostoReposicion.Add(x);
                    db.SaveChanges();
                }
                else
                {
                    cost.MonedaCosto = monedaCosto;
                    cost.TCConversion = tc;
                    cost.DateManualUpd = dateUpdated;
                    cost.FechaCompraAnterior = cost.FechaUC;
                    cost.FechaUC = fechaConta;
                    cost.ProveedorID = proveedorId;
                    cost.UserManualUpd = userUpdated;
                    cost.UserConta = user;
                    cost.ManualUpdated = manualUpdated;
                    cost.KgUC = kg;
                    cost.Origen = matData.ORIGEN;
                    //CostoPPPUsd = 0,  todo: funcion PPP 
                    //CostoPPPArs = 0, todo: funcion PPP
                    var antPrecioArs = cost.CostoUCArs;
                    var antPrecioUsd = cost.CostoUCUsd;
                    if (monedaCosto == "USD")
                    {
                        if (costoUnitarioUc != cost.CostoUCUsd)
                        {
                            //hubo variacion de precio despues del costRoll
                            cost.CostoUpdatedCostRoll = true;
                            cost.CostoUCUsd = costoUnitarioUc;
                        }
                        cost.CostoUCArs = costoUnitarioUc * tc;
                    }
                    else
                    {
                        if (costoUnitarioUc != cost.CostoUCArs)
                        {
                            //hubo variacion de precio despues del costRoll
                            cost.CostoUpdatedCostRoll = true;
                            cost.CostoUCArs = costoUnitarioUc;
                        }
                        cost.CostoUCUsd = costoUnitarioUc / tc;
                    }
                    cost.VarCostoUCArs = cost.CostoUCArs - antPrecioArs;
                    cost.VarCostoUCUsd = cost.CostoUCUsd - antPrecioUsd;
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// 20191101
        /// Nueva funcion GetCosto (Reposicion)
        /// Si devuelve KG = -1 es que no encontro el registro.
        /// </summary>
        public CostoRepo GetCosto(string material, decimal tc,bool obtieneAuto)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var resp = new CostoRepo();
                var data = db.T0036_CostoReposicion.SingleOrDefault(c => c.Material == material);
                if (data == null)
                {
                    if (obtieneAuto)
                    {
                        FixObtieneCostoUcFromUltimoRegistro(material);
                        data = db.T0036_CostoReposicion.SingleOrDefault(c => c.Material == material);
                        if (data == null)
                        {
                            resp.ARS = ValorCostoMaximo;
                            resp.USD = ValorCostoMaximo;
                            resp.MonedaCosto = "USD";
                            resp.Kg = -1;
                            resp.VendorUc = "No Definido";
                            resp.VarArs = 0;
                            resp.VarUsd = 0;
                            resp.Fecha = DateTime.Today.AddYears(-5);
                            return resp;
                        }
                    }
                    else
                    {
                        resp.ARS = ValorCostoMaximo;
                        resp.USD = ValorCostoMaximo;
                        resp.MonedaCosto = "USD";
                        resp.Kg = -1;
                        resp.VendorUc = "No Definido";
                        resp.VarArs = 0;
                        resp.VarUsd = 0;
                        resp.Fecha = DateTime.Today.AddYears(-5);
                        return resp;
                    }
                }
                if (data.MonedaCosto == "USD")
                {
                    data.CostoUCArs = decimal.Round((data.CostoUCUsd * tc), 3);
                }
                else
                {
                    data.CostoUCUsd = decimal.Round((data.CostoUCArs / tc), 3);
                }
                var vendor = data.ProveedorID <=0 ? "No Definido" : new VendorManager().GetSpecificVendor(data.ProveedorID).prov_rsocial;
                resp = new CostoRepo()
                {
                    ARS = data.CostoUCArs,
                    USD = data.CostoUCUsd,
                    MonedaCosto = data.MonedaCosto,
                    Fecha = data.FechaUC,
                    VendorUc = vendor,
                    Kg = data.KgUC,
                    VarUsd = data.VarCostoUCUsd,
                    VarArs = data.VarCostoUCArs,
                    FechaCostoAnterior = data.FechaCompraAnterior,
                    ManualUpdated = data.ManualUpdated
                };
                return resp;
            }
        }

        public List<CostoUltimasCompras> GetListadoUC(string material, int topData = 10)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lista = new List<CostoUltimasCompras>();
               var d404 = db.T0404_VENDOR_FACT_I.Where(c => c.ITEM_DESC == material)
                    .OrderByDescending(c => c.T0403_VENDOR_FACT_H.FECHA).Take(topData).ToList();
                foreach (var data in d404)
                {
                    var item = new CostoUltimasCompras()
                    {
                        FechaFactura = data.T0403_VENDOR_FACT_H.FECHA,
                        IdProveedor = data.T0403_VENDOR_FACT_H.IDPROV,
                        KgCompra = data.CANT.Value,
                        Material = material,
                        NumeroOC = 1,
                        RazonSocial = data.T0403_VENDOR_FACT_H.PROVRS,
                        TC = data.T0403_VENDOR_FACT_H.TC
                    };

                    if (data.MonedaItemProveedor == null)
                    {
                        //Campo nuevo 20191030
                        data.MonedaItemProveedor = "USD";
                    }
                    item.MonedaCotizacion = data.MonedaItemProveedor;

                    //No hace conversion de TC porque fue realizada durante la contabilizacion.

                    if (data.PUNIT_ARS == null)
                        data.PUNIT_ARS = 0;

                    if (data.PUNIT_USD == null)
                        data.PUNIT_USD = 0;
                    db.SaveChanges();
                    item.PrecioARS = data.PUNIT_ARS.Value;
                    item.PrecioUSD = data.PUNIT_USD.Value;
                    lista.Add(item);
                }
                return lista;
            }
        }
        /// <summary>
        /// Obtiene el costo de reposicion para materiales de origen comprado
        /// </summary>
        public CostoRepo GetCostoReposicionUc(string material, decimal tc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var resp = new CostoRepo();
                var data = db.T0033_COSTO.SingleOrDefault(c => c.MATERIAL == material);
                if (data == null)
                {
                    resp.ARS = ValorCostoMaximo;
                    resp.USD = ValorCostoMaximo;
                    resp.MonedaCosto = "USD";
                    resp.Kg = 0;
                    resp.VendorUc = "No Definido";
                    return resp;
                }

                if (data.FECHA_UC == null)
                    data.FECHA_UC = DateTime.Today.AddMonths(-36);

                if (data.MonedaCosto == null)
                    data.MonedaCosto = "USD";

                if (data.MonedaCosto == "USD")
                {
                    if (data.COSTO_UC_USD == null)
                    {
                        data.COSTO_UC_USD = ValorCostoMaximo;
                        data.COSTO_UC_ARS = ValorCostoMaximo;
                    }
                    else
                    {
                        data.COSTO_UC_ARS = decimal.Round((data.COSTO_UC_USD.Value * tc), 3);
                    }
                }
                else
                {
                    if (data.COSTO_UC_ARS == null)
                    {
                        data.COSTO_UC_USD = ValorCostoMaximo;
                        data.COSTO_UC_ARS = ValorCostoMaximo;
                    }
                    else
                    {
                        data.COSTO_UC_USD = decimal.Round((data.COSTO_UC_ARS.Value / tc), 3);
                    }
                }

                decimal KgUC = 0;
                if (data.STOCK != null)
                    KgUC = data.STOCK.Value;

                var vendor = data.Proveedor == null ? "No Definido" : new VendorManager().GetSpecificVendor(data.Proveedor.Value).prov_rsocial;
                    resp = new CostoRepo()
                {
                        ARS = data.COSTO_UC_ARS.Value,
                        USD = data.COSTO_UC_USD.Value,
                        MonedaCosto = data.MonedaCosto,
                        Fecha = data.FECHA_UC.Value,
                        VendorUc = vendor,
                        Kg = KgUC,
                };
                return resp;
            }
        }
        public void AddCostoUltimaCompra(int idT063, DateTime fechaFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data063 = db.T0063_ITEMS_OC_INGRESADOS.SingleOrDefault(c => c.ID == idT063);

                var data = db.T0033_COSTO.SingleOrDefault(c => c.MATERIAL.ToUpper().Equals(data063.IDMATERIAL.ToUpper()));
                if (data == null)
                {
                    AddRecordT0033(data063.IDMATERIAL.ToUpper());
                    data = db.T0033_COSTO.SingleOrDefault(c => c.MATERIAL.ToUpper().Equals(data063.IDMATERIAL.ToUpper()));
                }

                if (data == null) return;
                
                if (data.COSTO_ARS == 0 || data.COSTO_ARS ==null)
                {
                    //Setea como costo standard el costo de reposicion porque era 0/null
                    data.COSTO_ARS = data063.CONTA_U_ARS;
                }

                if (data.COSTO_USD == 0 || data.COSTO_USD == null)
                {
                    //Setea como costo standard el costo de reposicion porque era 0/null
                    data.COSTO_USD = data063.CONTA_U_USD;
                    data.CostDetermination = "AUTO";
                    data.CostDeterminationBy = "COMPRA";
                    data.AUTO_UPD = true;
                }

                //Setea costo UC
                {
                    data.COSTO_UC_ARS = data063.CONTA_U_ARS;
                    data.COSTO_UC_USD = data063.CONTA_U_USD;
                    data.FECHA_UC = fechaFactura;
                }

                //Setea costo PPP
                {
                    var costoUltimaCompra = new Costo()
                    {
                        CostoARS = data.COSTO_UC_ARS.Value,
                        CostoUSD = data.COSTO_UC_USD.Value,
                    };
                    var costoPromedioP = CalculaCostoPromedioPonderado(data063.IDMATERIAL, data063.CANTIDAD.Value,
                        costoUltimaCompra);
                    data.COSTO_PPP_ARS = costoPromedioP.CostoARS;
                    data.COSTO_PPP_USD = costoPromedioP.CostoUSD;
                }

                //Formula la pasa a null porque es comprado
                data.FORM = null;
                data.AUTO_UPD = true;
                data.Proveedor = data063.PROVEEDOR;
                db.SaveChanges();
            }
        }
        private void AddRecordT0033(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var mate = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL.ToUpper().Equals(material.ToUpper()));
                if (mate == null)
                    return;

                var data = new T0033_COSTO()
                {
                    MATERIAL = material,
                    MTYPE = mate.TIPO_MATERIAL,
                };
                db.SaveChanges();
            }
        }
        private Costo CalculaCostoPromedioPonderado(string material, decimal kgCompra, Costo costoCompra)
        {
            using (var db = new TecserData(GlobalApp.CnnApp)) 
            {
                var rs = db.T0033_COSTO.SingleOrDefault(c => c.MATERIAL == material);
                if (rs == null)
                {
                    return new Costo();
                }

                if (rs.COSTO_PPP_ARS == null)
                    rs.COSTO_PPP_ARS = 0;

                if (rs.COSTO_PPP_USD == null)
                    rs.COSTO_PPP_USD = 0;

                var kgTotal = (decimal) new StockAvilability().TotalStockInPlant(material);
                var kgTotalAnterior = kgTotal-kgCompra;

                var costoPromedio = new Costo();

                if (kgTotalAnterior > 0)
                {
                    costoPromedio.CostoARS = (kgTotalAnterior*rs.COSTO_PPP_ARS.Value + kgCompra*costoCompra.CostoARS)/kgTotal;
                    costoPromedio.CostoUSD= (kgTotalAnterior * rs.COSTO_PPP_USD.Value + kgCompra * costoCompra.CostoUSD) / kgTotal;
                }
                else
                {
                    costoPromedio.CostoARS = costoCompra.CostoARS;
                    costoPromedio.CostoUSD = costoCompra.CostoUSD;

                }
                return costoPromedio;
            }
        }

    }
}
