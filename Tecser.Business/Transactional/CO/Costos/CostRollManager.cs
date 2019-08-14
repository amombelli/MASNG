using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.Costos
{
    public class CostRollManager
    {
        public enum Runtype
        {
            Compras,
            Formulas
        }

        public T0034_CostRollHeader GetCostRollHeaderActivo()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0034_CostRollHeader.SingleOrDefault(c => c.VersionActiva == true);
            }
        }

        public List<T0035_CostRoll> GetListCostRollMateriasPrimas(Guid mGuid)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0035_CostRoll.Where(c => c.MOrigen != "FAB" && c.CostRollId == mGuid).ToList();
            }
        }

        public void UpdateHeaderRunTime(Runtype runType, Guid mguid, decimal time)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var g = db.T0034_CostRollHeader.SingleOrDefault(c => c.idCostRoll == mguid);
                if (runType == Runtype.Compras)
                {
                    g.RunTimeCompras = time;
                }
                else
                {
                    g.RunTimeFabricado = time;
                }
            }
        }

        public void GeneraEstructuraInicialCostRoll(Guid guid)
        {

        }

        public Guid CreateNewCostRollHeader(string comentario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var id = Guid.NewGuid();

                //Desactvia version Activa y deja solo la nueva Activa
                var versionActiva = db.T0034_CostRollHeader.Where(c => c.VersionActiva).ToList();
                foreach (var va in versionActiva)
                {
                    va.VersionActiva = false;
                }

                var data = new T0034_CostRollHeader()
                {
                    idCostRoll = id,
                    VersionActiva = true,
                    FechaCostRoll = DateTime.Now,
                    UserRun = GlobalApp.AppUsername,
                    Machinerun = Environment.MachineName,
                    Comentario = comentario,
                    RunTimeCompras = 0,
                    RunTimeFabricado = 0,
                    RunTimeExplosion = 0
                };
                db.T0034_CostRollHeader.Add(data);
                db.SaveChanges();
                db.Database.ExecuteSqlCommand("DELETE FROM T0035_CostRoll");
                db.Database.ExecuteSqlCommand("DELETE FROM T0037_CostRollExplosionL1");
                return id;
            }
        }

        public Guid AddNewCostRollHeader(string comentario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var id = Guid.NewGuid();

                var data = new T0034_CostRollHeader()
                {
                    idCostRoll = id,
                    VersionActiva = true,
                    FechaCostRoll = DateTime.Now,
                    UserRun = GlobalApp.AppUsername,
                    Machinerun = Environment.MachineName,
                    Comentario = comentario,
                    RunTimeCompras = 0,
                    RunTimeFabricado = 0
                };
                db.T0034_CostRollHeader.Add(data);
                db.SaveChanges();
                //Elimina datos CostRoll + Estructura 

                //

                return id;
            }
        }

        private void AddUpdateMaterialCostRoll(string material, string mOrigen, string mtype, Guid costRollId,
            int? fcostId,
            decimal costoRepo, DateTime? repoDate, decimal costoStd, DateTime? stdDate, decimal costoPpp,
            DateTime? pppDate, string monedaCost = "USD", bool manualUpdated = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0035_CostRoll.SingleOrDefault(c => c.Material == material);
                if (data == null)
                {
                    var r = new T0035_CostRoll()
                    {
                        Material = material,
                        MType = mtype,
                        CostRollDate = DateTime.Now,
                        CostRollId = costRollId,
                        RecordAddedOn = DateTime.Now,
                        RecordAddedBy = GlobalApp.AppUsername,
                        MonedaCosto = monedaCost,
                        FCost = fcostId,
                        CostoUnitarioPPP = costoPpp,
                        CostoUnitarioRepo = costoRepo,
                        CostoUnitarioStd = costoStd,
                        ManualUpdated = manualUpdated,
                        CostPppDate = pppDate,
                        CostRepoDate = repoDate,
                        CostStdDate = stdDate,
                        MOrigen = mOrigen
                    };


                    db.T0035_CostRoll.Add(r);
                    db.SaveChanges();
                    return;
                }

                //fix temporal para agregado de Material Origen
                data.MOrigen = mOrigen;
                //
                data.CostRollDate = DateTime.Now;
                data.CostRollId = costRollId;
                data.MonedaCosto = monedaCost;
                data.FCost = fcostId;
                data.CostoUnitarioPPP = costoPpp;
                data.CostoUnitarioRepo = costoRepo;
                data.CostoUnitarioStd = costoStd;
                data.ManualUpdated = manualUpdated;
                data.CostPppDate = pppDate;
                data.CostRepoDate = repoDate;
                data.CostStdDate = stdDate;
                db.SaveChanges();
            }
        }

        public decimal CostRollRunFormulas(Guid guidId, bool onlyActivo = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0034_CostRollHeader.SingleOrDefault(c => c.idCostRoll == guidId);
                if (header == null)
                {
                    return -1;
                }

                DateTime inicio = DateTime.Now;
                var mfg = new CostoManufactura();
                var matlist = onlyActivo
                    ? db.T0010_MATERIALES.Where(c => c.ACTIVO == true && c.ORIGEN == "FAB").ToList()
                    : db.T0010_MATERIALES.Where(c => c.ORIGEN == "FAB").ToList();
                var tc = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
                string monedaCosto;
                bool manualUpdated;
                decimal cRepo;
                decimal cStd;
                decimal cPPP;
                DateTime? repoDate = null;
                DateTime? stdDate = null;
                DateTime? pppDate = null;

                foreach (var mx in matlist)
                {
                    var mcost = mfg.CalculaCostoNew(mx.IDMATERIAL, CostoBaseManager.TipoCosto.MfgRepo, "USD", tc, true);
                    monedaCosto = "USD";
                    cRepo = mcost.USD;
                    cPPP = 0;
                    cStd = 0;
                    repoDate = mcost.Fecha;
                    stdDate = null;
                    pppDate = null;
                    AddUpdateMaterialCostRoll(mx.IDMATERIAL, mx.ORIGEN, mx.TIPO_MATERIAL, guidId, mx.FORM_COSTO, cRepo,
                        repoDate, cStd,
                        stdDate, cPPP, pppDate, monedaCosto);
                }

                DateTime final = DateTime.Now;
                TimeSpan duracion = final - inicio;
                double segundosTotales = duracion.TotalSeconds;
                int segundos = duracion.Seconds;
                header.RunTimeCompras = (decimal) segundosTotales;
                db.SaveChanges();
                return (decimal) segundosTotales;
            }
        }

        /// <summary>
        /// Genera estructura nueva
        /// </summary>
        public bool GeneraEstructuraCostRollNueva(Guid guidId, bool onlyActivo = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0034_CostRollHeader.SingleOrDefault(c => c.idCostRoll == guidId);
                if (header == null)
                {
                    return false;
                }

                DateTime inicio = DateTime.Now;
                decimal MaxCost = GlobalApp.MaxCosto;
                string user = GlobalApp.AppUsername;
                var fechaCostRoll = header.FechaCostRoll;
                var fechaAdded = DateTime.Now;

                //Alta Datos --> Estructura T0035
                var sql1 = "INSERT INTO T0035_CostRoll ( Material, MType, MOrigen, FCost, MonedaCosto, CostoUnitarioRepo, CostRepoDate, CostoUnitarioStd, CostStdDate, CostoUnitarioPPP, CostPppDate, RecordAddedOn, RecordAddedBy, CostRollDate, ManualUpdated, CostRollId ) " +
                           "SELECT T0010_MATERIALES.IDMATERIAL, T0010_MATERIALES.TIPO_MATERIAL, T0010_MATERIALES.ORIGEN, T0010_MATERIALES.FORM_COSTO, T0010_MATERIALES.MonedaCosto, {0}, 1 / 1 / 1900 AS zCostoRepoDate,{0}, 1 / 1 / 1900 AS zCostoStdDate,{0}, 1 / 1 / 1900 AS zCostoPppDate, {4}, {1}, {3}, 0 AS zManualUpdate, {2} " +
                           "FROM T0010_MATERIALES";

                db.Database.ExecuteSqlCommand(sql1,MaxCost,user,guidId,fechaCostRoll,fechaAdded);
                //Alta Explosion
                sql1 =
                    "INSERT INTO T0037_CostRollExplosionL1 ( ProductoFabricado, FormulaID, MaterialID, MaterialComponente, OrigenComponente, MonedaCosto, Proporcion, CostoRepoArs, CostoRepoUsd, CostoStdArs, CostoStdUsd, FechaCosto, ManualUpdStd, ManualUpdRepo, FlagStd, FlagRepo, MaterialActivo, FormulaComplex, CostoStdArsProp, CostoStdUsdProp, CostoRepoArsProp, CostoRepoUsdProp ) " +
                    "SELECT T0035_CostRoll.material, T0021_FORMULA_I.formula, T0021_FORMULA_I.ID_ITEM, T0021_FORMULA_I.item, T0010_MATERIALES.ORIGEN, T0035_CostRoll.MonedaCosto, T0021_FORMULA_I.Cantidad_Porc, 0 AS crepoArs, 0 AS crepoUsd, 0 AS cstdars, 0 AS cstdusd, 1 / 1 / 1900 AS Expr5, 0 AS manualupdstd, T0035_CostRoll.ManualUpdated, 'I' AS flagstd, 'I' AS flagrepo, 1 AS materialactivo, 0 AS formulacomplex, 0 AS costostdarsprop, 0 AS costostdusdprop, 0 AS costorepoarsprop, 0 AS costorepousdprop " +
                    "FROM(T0035_CostRoll INNER JOIN T0021_FORMULA_I ON T0035_CostRoll.FCost = T0021_FORMULA_I.FORMULA) INNER JOIN T0010_MATERIALES ON T0021_FORMULA_I.ITEM = T0010_MATERIALES.IDMATERIAL; ";
                db.Database.ExecuteSqlCommand(sql1);
                return true;
            }
        }


        public decimal CostRollRunMP(Guid guidId, bool onlyActivo = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0034_CostRollHeader.SingleOrDefault(c => c.idCostRoll == guidId);
                if (header == null)
                {
                    return -1;
                }
                //reset info header
                header.RunTimeFabricado = 0;
                header.RunTimeCompras = 0;
                header.UserRun = GlobalApp.AppUsername;
                header.Machinerun = Environment.MachineName;
                header.FechaCostRoll=DateTime.Now;
                db.SaveChanges();

                DateTime inicio = DateTime.Now;

                var matlist = onlyActivo
                    ? db.T0010_MATERIALES.Where(c => c.ACTIVO == true && c.ORIGEN != "FAB").ToList()
                    : db.T0010_MATERIALES.Where(c => c.ORIGEN != "FAB").ToList();

                var repo = new CostoReposicion();
                string monedaCosto;
                bool manualUpdated;
                decimal cRepo;
                decimal cStd;
                decimal cPPP;
                DateTime? repoDate = null;
                DateTime? stdDate = null;
                DateTime? pppDate = null;

                var tc = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
                foreach (var mx in matlist)
                {
                    var rcost = repo.GetCosto(mx.IDMATERIAL, tc, true);
                    //
                    monedaCosto = rcost.MonedaCosto;
                    manualUpdated = rcost.ManualUpdated;
                    cRepo = monedaCosto == "USD" ? rcost.USD : rcost.ARS;
                    cStd = 0;
                    cPPP = 0;
                    repoDate = rcost.Fecha;
                    stdDate = null;
                    pppDate = null;

                    //funcion recolecta costo
                    AddUpdateMaterialCostRoll(mx.IDMATERIAL, mx.ORIGEN, mx.TIPO_MATERIAL, guidId, mx.FORM_COSTO, cRepo,
                        repoDate, cStd,
                        stdDate, cPPP, pppDate, monedaCosto);
                }
                
                DateTime final = DateTime.Now;
                TimeSpan duracion = final - inicio;
                double segundosTotales = duracion.TotalSeconds;
                int segundos = duracion.Seconds;
                header.RunTimeCompras = (decimal) segundosTotales;
                db.SaveChanges();
                return (decimal) segundosTotales;
            }
        }
    }
}