using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.CO.Costos
{
    /// <summary>
    /// Administracion de costo de manufactura T0033_COSTL0 ** caducar 2020.05.10
    /// </summary>
    public class CostoManufactura : CostoBaseManager
    {
        public struct MfgCostStruct
        {
            public decimal ARS;
            public decimal USD;
            public decimal TC;
            public int FormulaId;
            public DateTime Fecha;
            public string User;
            public bool Updated;
            public string MonedaCost;
            public string Origen;
        }
        public struct ManufactureReturn
        {
            public decimal StdArs;
            public decimal StdUsd;
            public decimal RepoArs;
            public decimal RepoUsd;
            public decimal TC;
            public int FormulaId;
            public DateTime FechaStd;
            public DateTime FechaRepo;
            public string MonedaCost;
            public string Origen;
        }
        private void AddUpdateCostBomHeader(string material, string monedaCost, decimal tc)
        {
            if (material == null)
                return;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var matData = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == material);
                var dataH = db.T0037_CostoMfg.SingleOrDefault(c => c.Material == material);
                int idFcost;
                if (matData.FORM_COSTO == null)
                {
                    idFcost = -1;
                }
                else
                {
                    idFcost = matData.FORM_COSTO.Value;
                }
                if (dataH == null)
                {
                    var data = new T0037_CostoMfg()
                    {
                        Material = material,
                        MonedaCosto = monedaCost,
                        Origen = matData.ORIGEN,
                        FCost = idFcost,
                        CostDateRepo = DateTime.Today,
                        CostDateStd = DateTime.Today,
                        LevelMax = 1,
                        MfgArsRepo = 0,
                        MfgArsStd = 0,
                        MfgUsdRepo = 0,
                        MfgUsdStd = 0,
                        TCCalculo = tc,
                        UpdateFCost = DateTime.Today,
                        LastRun = DateTime.Now
                    };
                    db.T0037_CostoMfg.Add(data);
                }
                else
                {
                    dataH.Origen = matData.ORIGEN;
                    if (dataH.FCost != idFcost)
                    {
                        dataH.FCost = idFcost;
                        dataH.UpdateFCost = DateTime.Today;
                        dataH.LastRun = DateTime.Now;
                    }
                    dataH.MonedaCosto = monedaCost;
                    dataH.TCCalculo = tc;
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Si existe un registro previo lo elimina y lo agrega nuevamente
        /// </summary>
        private void AddCostBomItems(int idFormula, string moneda, decimal tc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var formulaData = db.T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == idFormula);
                var xplow = db.T0038_CostoMfgExplo.Where(c => c.MaterialFabricar == formulaData.IDMATERIAL).ToList();
                db.T0038_CostoMfgExplo.RemoveRange(xplow);
                db.SaveChanges();
                //
                var itemFormula = db.T0021_FORMULA_I.Where(c => c.FORMULA == idFormula).ToList();
                foreach (var item in itemFormula)
                {
                    var matData = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == item.ITEM);
                    var itel1 = new T0038_CostoMfgExplo()
                    {
                        MaterialFabricar = formulaData.IDMATERIAL,
                        MaterialItem = item.ITEM,
                        IdItemFormula = item.ID_ITEM,
                        Origen = matData.ORIGEN,
                        MonedaItem = moneda,
                        FormulaProp = item.CANTIDAD_PORC.Value,
                        CostoUSD = ValorCostoMaximo,
                        CostoARS = ValorCostoMaximo,
                        FechaCostoItem = DateTime.Today.AddYears(-5),
                        FormulaId = idFormula,
                        PropARS = ValorCostoMaximo,
                        PropUSD = ValorCostoMaximo,
                        TipoCosto = "?",
                        LastRun = DateTime.Now
                    };
                    db.T0038_CostoMfgExplo.Add(itel1);
                    db.SaveChanges();
                }
            }
        }


        /// <summary>
        /// Calculo de Costo Manufactura
        /// </summary>
        /// <returns></returns>
        public CostMini CalculaCostoNew(string material, TipoCosto tipo, string monedaCost, decimal tc,
            bool updateDataTable = false)
        {
            if (material == null)
                return new CostMini()
                {
                    ARS = ValorCostoMaximo,
                    USD = ValorCostoMaximo,
                    Fecha = DateTime.Today.AddYears(-5),
                    Porcentaje = 1,
                    LevelMax = 1,
                };
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var itemData = db.T0038_CostoMfgExplo.Where(c => c.MaterialFabricar == material).ToList();
                if (itemData.Any() == false)
                {
                    //Si no hay informacion intenta generar la info
                    var matdata = MaterialMasterManager.GetSpecificPrimaryInformation(material);
                    this.AddUpdateCostBomHeader(material, monedaCost, tc);
                    if (matdata.FORM_COSTO == null)
                    {
                        return new CostMini()
                        {
                            ARS = ValorCostoMaximo,
                            USD = ValorCostoMaximo,
                            Fecha = DateTime.Today.AddYears(-5),
                            LevelMax = 0,
                        };
                    }
                    else
                    {
                        this.AddCostBomItems(matdata.FORM_COSTO.Value, monedaCost, tc);
                        itemData = db.T0038_CostoMfgExplo.Where(c => c.MaterialFabricar == material).ToList();
                    }
                }

                var costoSuma = new CostMini()
                {
                    ARS = 0,
                    USD = 0,
                    Fecha = DateTime.Today.AddYears(1),
                    LevelMax = 1,
                };

                if (tipo == TipoCosto.Standard)
                {
                    foreach (var item in itemData)
                    {
                        //if (item.Origen != "FAB")
                        //{
                        //    //Obtiene el costo Standard desde T0033
                        //    var cx = new CostoStandard().GetCostoStandard(item.MATERIAL_);
                        //    item.COSTO_ARS = cx.CostoARS;
                        //    item.COSTO_USD = cx.CostoUSD;
                        //    item.PROP_ARS = item.COSTO_ARS * item.PROP.Value;
                        //    item.PROP_USD = item.COSTO_USD * item.PROP.Value;
                        //    db.SaveChanges();
                        //    costoSuma.ARS += item.PROP_ARS.Value;
                        //    costoSuma.USD += item.PROP_USD.Value;
                        //}
                        //else
                        //{
                        //    //El Material es Fabricado por lo tanto obtiene el costo desde la explosion
                        //    var costo = CalculaCosto(item.MATERIAL_);
                        //    item.COSTO_ARS = costo.ARS;
                        //    item.COSTO_USD = costo.USD;
                        //    item.PROP_ARS = item.COSTO_ARS * item.PROP.Value;
                        //    item.PROP_USD = item.COSTO_USD * item.PROP.Value;
                        //    db.SaveChanges();
                        //}
                    }
                    return costoSuma;
                }
                else
                {
                    //Costo de Reposicion-UC
                    costoSuma.Fecha = DateTime.Today.AddDays(1);
                    foreach (var item in itemData)
                    {
                        if (item.Origen != "FAB")
                        {
                            var cx = new CostoReposicion().GetCosto(item.MaterialItem, tc, true);
                            item.CostoARS = cx.ARS;
                            item.CostoUSD = cx.USD;
                            item.PropARS = item.CostoARS * item.FormulaProp;
                            item.PropUSD = item.CostoUSD * item.FormulaProp;
                            item.LastRun = DateTime.Now;
                            item.FechaCostoItem = cx.Fecha;

                            if (updateDataTable)
                                db.SaveChanges();
                            costoSuma.ARS += item.PropARS;
                            costoSuma.USD += item.PropUSD;
                            if (costoSuma.Fecha > item.FechaCostoItem)
                                costoSuma.Fecha = item.FechaCostoItem;
                        }
                        else
                        {
                            //El Material es Fabricado por lo tanto obtiene el costo desde la explosion
                            var costo = CalculaCostoNew(item.MaterialItem, tipo, monedaCost, tc, updateDataTable);
                            costo.LevelMax = costo.LevelMax + 1;
                            //var dataH = db.T0037_CostoMfg.SingleOrDefault(c => c.Material ==item.MaterialItem);
                            //dataH.LastRun = DateTime.Now;
                            //dataH.CostDateRepo = costo.Fecha;
                            //dataH.MfgArsRepo = costo.ARS;
                            //dataH.MfgUsdRepo = costo.USD;
                            //dataH.LevelMax = costo.LevelMax++;

                            item.CostoARS = costo.ARS;
                            item.CostoUSD = costo.USD;
                            item.PropARS = item.CostoARS * item.FormulaProp;
                            item.PropUSD = item.CostoUSD * item.FormulaProp;
                            item.FechaCostoItem = costo.Fecha;
                            item.LastRun = DateTime.Now;
                            if (updateDataTable)
                                db.SaveChanges();
                            costoSuma.ARS += item.PropARS;
                            costoSuma.USD += item.PropUSD;
                            costoSuma.LevelMax = costo.LevelMax;
                            //costoSuma.Fecha 
                            if (costoSuma.Fecha > item.FechaCostoItem)
                                costoSuma.Fecha = item.FechaCostoItem;
                        }
                    }

                    if (updateDataTable)
                    {
                        var dataH = db.T0037_CostoMfg.SingleOrDefault(c => c.Material == material);
                        dataH.LastRun = DateTime.Now;
                        dataH.CostDateRepo = costoSuma.Fecha;
                        dataH.MfgArsRepo = costoSuma.ARS;
                        dataH.MfgUsdRepo = costoSuma.USD;
                        dataH.LevelMax = costoSuma.LevelMax;
                        db.SaveChanges();
                    }
                    return costoSuma;
                }
            }
        }
        public List<T0038_CostoMfgExplo> GetBomItems(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0038_CostoMfgExplo.Where(c => c.MaterialFabricar == material).ToList();
            }
        }

        /// <summary>
        /// Nueva funcion de obtencion de costo de manufactura
        /// Si no encuentra el material devuelve FormulaID = -1
        /// </summary>
        public ManufactureReturn GetCostSaved(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var mfg = db.T0037_CostoMfg.SingleOrDefault(c => c.Material == material);
                if (mfg == null)
                {
                    //No hay registro en la tabla
                    return new ManufactureReturn()
                    {
                        TC = 1,
                        FormulaId = -1,
                        Origen = "FAB",
                        MonedaCost = "USD",
                    };
                }

                var resp = new ManufactureReturn()
                {
                    TC = mfg.TCCalculo,
                    StdArs = mfg.MfgArsStd,
                    StdUsd = mfg.MfgUsdStd,
                    RepoArs = mfg.MfgArsRepo,
                    RepoUsd = mfg.MfgUsdRepo,
                    Origen = mfg.Origen,
                    FechaRepo = mfg.CostDateRepo,
                    FechaStd = mfg.CostDateStd,
                    FormulaId = mfg.FCost,
                    MonedaCost = mfg.MonedaCosto,
                };
                return resp;
            }
        }
        public ManufactureReturn CalculaMfgCost(string material, string moneda, decimal tc, TipoCosto tipoC)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var mfg = db.T0037_CostoMfg.SingleOrDefault(c => c.Material == material);
                if (mfg == null)
                {
                    //No hay registro en la tabla
                    return new ManufactureReturn()
                    {
                        TC = 1,
                        FormulaId = -1,
                        Origen = "FAB",
                        MonedaCost = "USD",
                    };
                }

                var matData = MaterialMasterManager.GetSpecificPrimaryInformation(material);
                var resp = new ManufactureReturn()
                {
                    TC = mfg.TCCalculo,
                    StdArs = mfg.MfgArsStd,
                    StdUsd = mfg.MfgUsdStd,
                    RepoArs = mfg.MfgArsRepo,
                    RepoUsd = mfg.MfgUsdRepo,
                    Origen = mfg.Origen,
                    FechaRepo = mfg.CostDateRepo,
                    FechaStd = mfg.CostDateStd,
                    FormulaId = mfg.FCost,
                    MonedaCost = mfg.MonedaCosto,
                };
                return resp;
            }
        }
        public MfgCostStruct GetCost(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var resp = new MfgCostStruct()
                {
                    Fecha = DateTime.Today,
                    ARS = 1,
                    USD = Decimal.MaxValue,
                    TC = 1,
                    Updated = false,
                    User = null,
                    FormulaId = 0
                };

                var data = db.T0033_COSTL0.SingleOrDefault(c => c.MATERIAL == material);
                if (data == null)
                    return resp;

                if (data.COSTO_ARS == null || data.COSTO_ARS == 0)
                    data.COSTO_ARS = ValorCostoMaximo;

                if (data.COSTO_USD == null || data.COSTO_USD == 0)
                    data.COSTO_USD = ValorCostoMaximo;

                if (data.MON == null)
                    data.MON = "USD";

                if (data.UPD == null)
                    data.UPD = false;

                if (data.LOG_DATE == null)
                    data.LOG_DATE = DateTime.Today;

                if (data.TC == null || data.TC == 0)
                    data.TC = 1;

                if (data.FORM_ID == null)
                    data.FORM_ID = 0;

                resp = new MfgCostStruct()
                {
                    Fecha = data.LOG_DATE.Value,
                    ARS = data.COSTO_ARS.Value,
                    USD = data.COSTO_USD.Value,
                    TC = data.TC.Value,
                    Updated = data.UPD.Value,
                    User = data.LOG_USER,
                    FormulaId = data.FORM_ID.Value,
                    MonedaCost = data.MON,
                    Origen = data.ORIGEN,
                };
                return resp;
            }
        }
        public List<T0033_COSTL1> GetExplosionListLevel1(string material, bool recalculaCosto)
        {
            if (recalculaCosto)
                this.CalculaCosto(material);

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0033_COSTL1.Where(c => c.MATERIAL == material).ToList();
            }
        }
        public int GetFCostId(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var matData = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == material);
                if (matData.FORM_COSTO == null)
                    return 0;
                return matData.FORM_COSTO.Value;
            }
        }
        public void UpdateFCost(int idFormula, string moneda = "USD", decimal? tc = null)
        {
            if (tc == null)
            {
                tc = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
            }

            if (moneda == null)
            {
                moneda = "USD";
            }

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var formulaData = db.T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == idFormula);
                var matData = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == formulaData.IDMATERIAL);
                matData.FORM_COSTO = idFormula;
                db.SaveChanges();
                AddUpdateCostBomHeader(matData.IDMATERIAL, moneda, tc.Value);
                AddCostBomItems(idFormula, moneda, tc.Value);
            }
        }
        private void AddUpdateRecordLevel0(string material, string monedaCost, decimal TC)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var matData = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == material);
                var dataL0 = db.T0033_COSTL0.SingleOrDefault(c => c.MATERIAL == material);
                if (dataL0 == null)
                {
                    var data = new T0033_COSTL0()
                    {
                        ORIGEN = matData.ORIGEN,
                        MATERIAL = material,
                        TC = TC,
                        LOG_USER = Environment.UserName,
                        FORM_ID = matData.FORM_COSTO,
                        COST_DATE = null,
                        MON = monedaCost,
                        UPD = false,
                        LOG_DATE = DateTime.Today,
                        COSTO_ARS = null,
                        COSTO_USD = null,
                        CANT = null,
                        COMENT_L0 = null,
                        LEVEL = 1
                    };
                    db.T0033_COSTL0.Add(data);
                }
                else
                {
                    dataL0.ORIGEN = matData.ORIGEN;
                    dataL0.FORM_ID = matData.FORM_COSTO;
                    dataL0.LOG_DATE = DateTime.Today;
                    dataL0.LOG_USER = Environment.UserName;
                    dataL0.UPD = false;
                    dataL0.COST_DATE = null;
                    dataL0.COSTO_ARS = null;
                    dataL0.COSTO_USD = null;
                    dataL0.MON = monedaCost;
                    dataL0.TC = TC;
                }

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Si existe un registro previo lo elimina y lo agrega nuevamente
        /// </summary>
        private void AddRecordLevel1(int idFormula, string moneda, decimal tc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var formulaData = db.T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == idFormula);
                var level1 = db.T0033_COSTL1.Where(c => c.MATERIAL == formulaData.IDMATERIAL).ToList();
                db.T0033_COSTL1.RemoveRange(level1);
                db.SaveChanges();
                //
                var itemFormula = db.T0021_FORMULA_I.Where(c => c.FORMULA == idFormula).ToList();
                foreach (var item in itemFormula)
                {
                    var matData = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == item.ITEM);
                    var itel1 = new T0033_COSTL1()
                    {
                        MATERIAL = formulaData.IDMATERIAL,
                        MATERIAL_ = item.ITEM,
                        ORIGEN = matData.ORIGEN,
                        MON = moneda,
                        PROP = item.CANTIDAD_PORC,
                        TC = tc,
                        COST_DATE = null,
                        COSTO_ARS = null,
                        COSTO_USD = null,
                        PROP_ARS = null,
                        PROP_USD = null,
                        FORM_ID = null,
                        LEVEL = 1,
                    };
                    if (itel1.ORIGEN == "FAB")
                    {
                        itel1.LEVEL = 2;
                        itel1.FORM_ID = matData.FORM_COSTO;
                    }

                    db.T0033_COSTL1.Add(itel1);
                    db.SaveChanges();
                }
            }
        }
        public CostMini CalculaCosto(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var itemData = db.T0033_COSTL1.Where(c => c.MATERIAL == material).ToList();
                if (!itemData.Any())
                {
                    var matdata = MaterialMasterManager.GetSpecificPrimaryInformation(material);
                    this.AddUpdateRecordLevel0(material, "USD", 1);
                    if (matdata.FORM_COSTO == null)
                    {
                        return new CostMini()
                        {
                            ARS = ValorCostoMaximo,
                            USD = ValorCostoMaximo,
                        };
                    }
                    else
                    {
                        this.AddRecordLevel1(matdata.FORM_COSTO.Value, "USD", 1);
                        itemData = db.T0033_COSTL1.Where(c => c.MATERIAL == material).ToList();
                    }
                }

                CostMini costoSuma = new CostMini()
                {
                    ARS = 0,
                    USD = 0
                };

                foreach (var item in itemData)
                {
                    if (item.ORIGEN != "FAB")
                    {
                        //Obtiene el costo Standard desde T0033
                        var cx = new CostoStandard().GetCosto(item.MATERIAL_);
                        item.COSTO_ARS = cx.CostoARS;
                        item.COSTO_USD = cx.CostoUSD;
                        item.PROP_ARS = item.COSTO_ARS * item.PROP.Value;
                        item.PROP_USD = item.COSTO_USD * item.PROP.Value;
                        db.SaveChanges();
                        costoSuma.ARS += item.PROP_ARS.Value;
                        costoSuma.USD += item.PROP_USD.Value;
                    }
                    else
                    {
                        //El Material es Fabricado por lo tanto obtiene el costo desde la explosion
                        var costo = CalculaCosto(item.MATERIAL_);
                        item.COSTO_ARS = costo.ARS;
                        item.COSTO_USD = costo.USD;
                        item.PROP_ARS = item.COSTO_ARS * item.PROP.Value;
                        item.PROP_USD = item.COSTO_USD * item.PROP.Value;
                        db.SaveChanges();
                    }
                }

                return costoSuma;
            }
        }
    }
}