using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.Costos
{
    public class StxCostoItemMemoria
    {
        public string material { get; set; }
        public string moneda { get; set; }
        public decimal repoARS { get; set; }
        public decimal repoUSD { get; set; }
        public DateTime fechaCosto { get; set; }
        public int LevelMax { get; set; }
    }
    public class CostRollExplosion
    {
        public List<StxCostoItemMemoria> ListaCostoMP = new List<StxCostoItemMemoria>();


        private void AddRecordCostRoll(Guid guidCostRoll, DateTime costRollDate, string material, string monedaCosto,
            int formulaId, string materialType,
            decimal costoStd, decimal costoRepo, DateTime stdDate, DateTime repoDate, DateTime pppDate)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stx = new T0035_CostRoll()
                {
                    CostRollId = guidCostRoll,
                    CostRollDate = costRollDate,
                    Material = material,
                    ManualUpdated = false,
                    RecordAddedBy = GlobalApp.AppUsername,
                    RecordAddedOn = DateTime.Now,
                    MonedaCosto = monedaCosto,
                    MOrigen = "FAB",
                    FCost = formulaId,
                    MType = materialType,
                    CostoUnitarioPPP = 0,
                    CostoUnitarioStd = costoStd,
                    CostoUnitarioRepo = costoRepo,
                    CostStdDate = DateTime.Now.AddYears(-5),
                    CostPppDate = DateTime.Today.AddYears(-5),
                    CostRepoDate = DateTime.Today.AddYears(-5),
                };
            }
        }

        /// <summary>
        /// Agregar todos los materiales fabricados a tabla CostRoll + Agregar todas las explosiones a tabla T0037
        /// si a la hora de agregar encuentra que no existe formula determinada genera costo 9999
        /// </summary>
        public bool GeneraEstructuraFormula(Guid guid)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var costRollInfo = db.T0034_CostRollHeader.SingleOrDefault(c => c.idCostRoll == guid);
                if (costRollInfo == null)
                {
                    return false;
                }
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [T0037_CostRollExplosionL1]");
                string sql;
                string name = "tanweer";
                long id = 10001;
                decimal costoNulo = GlobalApp.MaxCosto;
                //var sql = @"Update [User] SET FirstName = {0} WHERE Id = {1}";
                //ctx.Database.ExecuteSqlCommand(sql, name, id);
                
                sql = "INSERT INTO T0037_CostRollExplosionL1(ProductoFabricado, FormulaID, MaterialID, MaterialComponente, OrigenComponente, MonedaCosto, Proporcion, CostoRepoArs, CostoRepoUsd, CostoStdArs, CostoStdUsd, FechaCosto, ManualUpdStd, ManualUpdRepo, FlagStd, FlagRepo, MaterialActivo, FormulaComplex, CostoStdArsProp, CostoStdUsdProp, CostoRepoArsProp, CostoRepoUsdProp ) " +
                      "SELECT T0035_CostRoll.material, T0021_FORMULA_I.formula, T0021_FORMULA_I.ID_ITEM, T0021_FORMULA_I.item, T0035_CostRoll.MOrigen, T0035_CostRoll.MonedaCosto, 1 AS Prop, {0}, {0}, {0}, {0}, 1 / 1 / 1900 AS Expr5, 0 AS Expr6, 0 AS Expr7, 'I' AS Expr8, 'I' AS Expr9, 1 AS Expr10, 0 AS Expr11, 0 AS Expr12, 0 AS Expr13, 0 AS Expr14, 0 AS Expr15 FROM T0035_CostRoll INNER JOIN T0021_FORMULA_I ON T0035_CostRoll.FCost = T0021_FORMULA_I.FORMULA;";
                db.Database.ExecuteSqlCommand(sql,costoNulo);
                DateTime inicio = DateTime.Now;
                //var mat = db.T0035_CostRoll.Where(c => c.MOrigen == "FAB").ToList();
                //foreach (var mfab in mat)
                //{
                //    if (mfab.FCost == null)
                //    {
                //        //El Material no tiene Formula - no agregará ningun item a la Explosion.
                //        stx = new T0037_CostRollExplosionL1()
                //        {
                //            MonedaCosto = "USD",
                //            FechaCosto = DateTime.Today.AddYears(-5),
                //            CostoRepoArs = GlobalApp.MaxCosto,
                //            CostoStdArs = GlobalApp.MaxCosto,
                //            CostoRepoUsd = GlobalApp.MaxCosto,
                //            CostoStdUsd = GlobalApp.MaxCosto,
                //            FormulaComplex = -1,
                //            FlagRepo = "E",
                //            FlagStd = "E",
                //            FormulaID = -1,
                //            ManualUpdRepo = false,
                //            ManualUpdStd = false,
                //            MaterialActivo = true,
                //            ProductoFabricado = mfab.Material,
                //            MaterialComponente = null,
                //            MaterialID = 5,
                //            Proporcion = 1,
                //            OrigenComponente = "XXX"
                //        };
                //        //agerga material costo 999 --> Tcroll
                //    }
                //    else
                //    {
                //        var formula = db.T0021_FORMULA_I.Where(c => c.FORMULA == mfab.FCost.Value);
                //        List<T0037_CostRollExplosionL1> litems = new List<T0037_CostRollExplosionL1>();
                //        foreach (var fitem in formula)
                //        {
                //            stx = new T0037_CostRollExplosionL1()
                //            {
                //                MonedaCosto = mfab.MonedaCosto ?? "USD",
                //                FechaCosto = DateTime.Today.AddYears(-5),
                //                CostoRepoArs = GlobalApp.MaxCosto,
                //                CostoStdArs = GlobalApp.MaxCosto,
                //                CostoRepoUsd = GlobalApp.MaxCosto,
                //                CostoStdUsd = GlobalApp.MaxCosto,
                //                FormulaComplex = -2,
                //                FlagRepo = "I",
                //                FlagStd = "I",
                //                FormulaID = mfab.FCost.Value,
                //                ManualUpdRepo = false,
                //                ManualUpdStd = false,
                //                MaterialActivo = true,
                //                ProductoFabricado = mfab.Material,
                //                MaterialComponente = fitem.ITEM,
                //                MaterialID = fitem.ID_ITEM,
                //                Proporcion = fitem.CANTIDAD_PORC.Value,
                //                OrigenComponente = fitem.T0010_MATERIALES.ORIGEN
                //            };
                //            litems.Add(stx);
                //        }
                //        db.T0037_CostRollExplosionL1.AddRange(litems);
                //    }
                //    db.SaveChanges();
                //}
                DateTime final = DateTime.Now;
                TimeSpan duracion = final - inicio;
                double segundosTotales = duracion.TotalSeconds;
                int segundos = duracion.Seconds;
                costRollInfo.RunTimeExplosion = (decimal) segundosTotales;
                db.SaveChanges();
            }
            return true;
        }
        public void MapCostoReposicion()
        {
            var repoList = new List<StxCostoItemMemoria>();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var listaMaterialesDistinct = db.T0037_CostRollExplosionL1.GroupBy(c => c.MaterialComponente)
                    .Select(x => x.FirstOrDefault()).ToList();

                foreach (var matdistinct in listaMaterialesDistinct)
                {
                    var p = db.T0036_CostoReposicion.SingleOrDefault(c => c.Material == matdistinct.MaterialComponente);
                    if (p != null)
                    {
                        var z = new StxCostoItemMemoria()
                        {
                            material = matdistinct.MaterialComponente,
                            moneda = p.MonedaCosto,
                            repoARS = p.CostoUCArs,
                            repoUSD = p.CostoUCUsd,
                        };
                        repoList.Add(z);
                    }
                }
            }
        }





        public int SetCostForAllManufacturedMaterials(Guid guid)
        {
            DateTime inicio = DateTime.Now;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var tc = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
                var materialesCosto = db.T0035_CostRoll.Where(c=>c.MOrigen=="FAB").ToList();
                foreach (var materiales in materialesCosto)
                {
                    var rtnExplosion = LaMagia(materiales.Material, materiales.MonedaCosto, tc);
                    {
                        if (materiales.MonedaCosto == "USD")
                        {
                            materiales.CostoUnitarioRepo = rtnExplosion.USD;
                        }
                        else
                        {
                            materiales.CostoUnitarioRepo = rtnExplosion.ARS;
                        }

                        materiales.CostRepoDate = rtnExplosion.Fecha;
                        materiales.RecordAddedOn = DateTime.Now;
                        materiales.MaterialComplex = rtnExplosion.LevelMax;
                        //Debug.Print($"Material {materiales.Material} - Costo {materiales.CostoUnitarioRepo}");
                    }
                }
                db.SaveChanges(); //ver si lo pasamos para abajo
                DateTime final = DateTime.Now;
                TimeSpan duracion = final - inicio;
                double segundosTotales = duracion.TotalSeconds;
                int segundos = duracion.Seconds;
                var costRollHeader = db.T0034_CostRollHeader.SingleOrDefault(c => c.idCostRoll == guid);
                costRollHeader.RunTimeFabricado = (int) segundosTotales;
                db.SaveChanges();
                return (int) segundosTotales;
            }
        }


        public int RetornaRegistrosT0035Compras()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0035_CostRoll.Count(c => c.MOrigen != "FAB");
            }
        }
        public int RetornaRegistrosT0035Fabricados()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0035_CostRoll.Count(c => c.MOrigen == "FAB");
            }
        }

        public int RetornaRegistrosT0035()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0035_CostRoll.Count();
            }
        }

        public int RetornaRegistrosExplosion()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0037_CostRollExplosionL1.Count();
            }
        }

        /// <summary>
        /// Funcion principal para costeo por explosion
        /// </summary>
        private CostoBaseManager.CostMini LaMagia(string material, string monedaCost, decimal tc)
        {
            //if (material == "PMDRYBLEND75")
            //{
            //    var a = 1;
            //}

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //A- Busca en Lista Memoria si ya tiene costo para este elemento que tiene que ser Fabricado
                var isInList = ListaCostoMP.SingleOrDefault(c => c.material == material);
                if (isInList != null)
                {
                    //Encontre el costo almancenado por lo tanto lo retorna sin ejecutar explosion
                    return new CostoBaseManager.CostMini
                    {
                        ARS = isInList.repoARS,
                        USD = isInList.repoUSD,
                        Fecha = isInList.fechaCosto,
                        Porcentaje = 1,
                        LevelMax = isInList.LevelMax
                    };
                }

                //No tengo datos almancenados - Realiza la Explosion de Items
                var listaExplosion = db.T0037_CostRollExplosionL1.Where(c => c.ProductoFabricado == material).ToList();
                if (!listaExplosion.Any())
                {
                    //La formula no tiene ningun Item lo agrega a la lista para no volver a consultar
                    var tmp = new StxCostoItemMemoria()
                    {
                        material = material,
                        moneda = "USD",
                        repoUSD = GlobalApp.MaxCosto,
                        repoARS = GlobalApp.MaxCosto,
                        LevelMax = 99,
                        fechaCosto = DateTime.Today.AddDays(-10)
                    };

                    //Retorna valores maximos porue no tiene componentes a explotar
                    return new CostoBaseManager.CostMini()
                    {
                        USD = tmp.repoUSD,
                        ARS = tmp.repoARS,
                        Fecha = tmp.fechaCosto,
                        LevelMax = tmp.LevelMax,
                        Porcentaje = 1
                    };
                }

                //Inicializa variable de Retorno donde acumulara los costos de los items
                //para obtener el costo final del Item - fecha base -5años
                var rtnCostoFinalAcumulado = new CostoBaseManager.CostMini()
                {
                    ARS = 0,
                    USD = 0,
                    Fecha = DateTime.Today,
                    LevelMax = 0,
                    Porcentaje = 0
                };

                //Empieza a Recorrer los ITems de la explosion -->
                foreach (var itemBom in listaExplosion)
                {
                    //Busca si componente esta en lista memoria antes de inciar la busqueda en Db del costo
                    isInList = ListaCostoMP.SingleOrDefault(c => c.material == itemBom.MaterialComponente);
                    if (isInList != null)
                    {
                        //Se encontro el costo almacenado en memoria. --> Mapea desde Memoria
                        itemBom.CostoRepoArs = isInList.repoARS;
                        itemBom.CostoRepoUsd = isInList.repoUSD;
                        itemBom.FechaCosto = isInList.fechaCosto;
                        itemBom.CostoRepoArsProp = isInList.repoARS * itemBom.Proporcion;
                        itemBom.CostoRepoUsdProp = isInList.repoUSD * itemBom.Proporcion;
                        itemBom.FlagRepo = "M";
                        itemBom.FormulaComplex = isInList.LevelMax;
                        db.SaveChanges();

                        //Acumula costo unitario
                        rtnCostoFinalAcumulado.ARS += itemBom.CostoRepoArsProp;
                        rtnCostoFinalAcumulado.USD += itemBom.CostoRepoUsdProp;
                        rtnCostoFinalAcumulado.Porcentaje += itemBom.Proporcion;
                        //Actualiza siempre a la fecha mas antigua del item
                        if (rtnCostoFinalAcumulado.Fecha > itemBom.FechaCosto)
                            rtnCostoFinalAcumulado.Fecha = itemBom.FechaCosto;
                        //Actualiza FormulaComplex con el mayor valor de sus items
                        if (itemBom.FormulaComplex > rtnCostoFinalAcumulado.LevelMax)
                            rtnCostoFinalAcumulado.LevelMax = itemBom.FormulaComplex;
                        db.SaveChanges();
                    }
                    else
                    {
                        //El Costo del Item no esta en memoria.
                        if (itemBom.OrigenComponente != "FAB")
                        {
                            //Material es Comprado por lo tanto mapea desde Cost_Roll Table 
                            var itemTableCostRoll =
                                db.T0035_CostRoll.SingleOrDefault(c => c.Material == itemBom.MaterialComponente);
                            if (itemTableCostRoll == null)
                            {
                                //no encontro el costo ni en memoria ni en la Db
                                itemBom.CostoRepoArs = GlobalApp.MaxCosto;
                                itemBom.CostoRepoUsd = GlobalApp.MaxCosto;
                                itemBom.FechaCosto = DateTime.Today.AddYears(-10);
                                itemBom.CostoRepoArsProp = GlobalApp.MaxCosto;
                                itemBom.CostoRepoUsdProp = GlobalApp.MaxCosto;
                                itemBom.FlagRepo = "X";
                                itemBom.FormulaComplex = 50;
                            }
                            else
                            {
                                //Mapeamos el costo del material *comprado* desde Tabla CostRoll 
                                if (itemBom.MonedaCosto == "USD")
                                {
                                    itemBom.CostoRepoArs = itemTableCostRoll.CostoUnitarioRepo * tc;
                                    itemBom.CostoRepoUsd = itemTableCostRoll.CostoUnitarioRepo;
                                    itemBom.FechaCosto = itemTableCostRoll.CostRepoDate.Value;
                                    itemBom.CostoRepoArsProp = itemBom.CostoRepoArs * itemBom.Proporcion;
                                    itemBom.CostoRepoUsdProp = itemBom.CostoRepoUsd * itemBom.Proporcion;
                                    itemBom.FlagRepo = "R";
                                    itemBom.FormulaComplex = 0;
                                }
                                else
                                {
                                    itemBom.CostoRepoUsd = itemTableCostRoll.CostoUnitarioRepo / tc;
                                    itemBom.CostoRepoArs = itemTableCostRoll.CostoUnitarioRepo;
                                    itemBom.FechaCosto = itemTableCostRoll.CostRepoDate.Value;
                                    itemBom.CostoRepoArsProp = itemBom.CostoRepoArs * itemBom.Proporcion;
                                    itemBom.CostoRepoUsdProp = itemBom.CostoRepoUsd * itemBom.Proporcion;
                                    itemBom.FlagRepo = "R";
                                    itemBom.FormulaComplex = 0;
                                }
                            }

                            //agrego el costo a la lista a memoria para tenerla disponible luego
                            ListaCostoMP.Add(new StxCostoItemMemoria()
                            {
                                material = itemBom.MaterialComponente,
                                moneda = itemBom.MonedaCosto,
                                fechaCosto = itemBom.FechaCosto,
                                repoARS = itemBom.CostoRepoArs,
                                repoUSD = itemBom.CostoRepoUsd,
                                LevelMax = itemBom.FormulaComplex,
                            });

                            rtnCostoFinalAcumulado.ARS += itemBom.CostoRepoArsProp;
                            rtnCostoFinalAcumulado.USD += itemBom.CostoRepoUsdProp;
                            rtnCostoFinalAcumulado.Porcentaje += itemBom.Proporcion;
                            //Actualiza siempre a la fecha mas antigua del item
                            if (rtnCostoFinalAcumulado.Fecha > itemBom.FechaCosto)
                                rtnCostoFinalAcumulado.Fecha = itemBom.FechaCosto;
                            //Actualiza FormulaComplex con el mayor valor de sus items
                            if (itemBom.FormulaComplex > rtnCostoFinalAcumulado.LevelMax)
                                rtnCostoFinalAcumulado.LevelMax = itemBom.FormulaComplex;
                            db.SaveChanges();
                        }
                        else
                        {
                            //Material es Fabricado por lo tanto re-explota y retornar el valor
                            var costo = LaMagia(itemBom.MaterialComponente, monedaCost, tc);
                            if (costo.LevelMax >= 50)
                            {
                                //No Encontro explosion de formula para retornar
                                itemBom.CostoRepoArs = GlobalApp.MaxCosto;
                                itemBom.CostoRepoUsd = GlobalApp.MaxCosto;
                                itemBom.CostoRepoArsProp = GlobalApp.MaxCosto;
                                itemBom.CostoRepoUsdProp = GlobalApp.MaxCosto;
                                itemBom.FlagRepo = "J";
                                itemBom.FormulaComplex = costo.LevelMax;
                                itemBom.FechaCosto = DateTime.Now.AddYears(-5);
                            }
                            else
                            {
                                //La Formula se exploto y retorno un valor
                                itemBom.CostoRepoArs = costo.ARS;
                                itemBom.CostoRepoUsd = costo.USD;
                                itemBom.CostoRepoArsProp = itemBom.CostoRepoArs * itemBom.Proporcion;
                                itemBom.CostoRepoUsdProp = itemBom.CostoRepoUsd * itemBom.Proporcion;
                                itemBom.FlagRepo = "F";
                                itemBom.FormulaComplex = costo.LevelMax+1; //aumento la complejidad en 1
                                itemBom.FechaCosto = costo.Fecha;

                                var tmpFab = new StxCostoItemMemoria()
                                {
                                    material = itemBom.MaterialComponente,
                                    repoARS = itemBom.CostoRepoArs,
                                    repoUSD = itemBom.CostoRepoUsd,
                                    moneda = itemBom.MonedaCosto,
                                    fechaCosto = itemBom.FechaCosto,
                                    LevelMax = itemBom.FormulaComplex,
                                };
                                ListaCostoMP.Add(tmpFab);
                            }

                            //Agregamos el costo de este material fabricado a la lista
                            //costo.LevelMax = costo.LevelMax;  //aca habia puesto +1
                            db.SaveChanges();
                            rtnCostoFinalAcumulado.ARS += itemBom.CostoRepoArsProp;
                            rtnCostoFinalAcumulado.USD += itemBom.CostoRepoUsdProp;
                            rtnCostoFinalAcumulado.LevelMax = costo.LevelMax;
                            rtnCostoFinalAcumulado.Porcentaje += itemBom.Proporcion;
                            if (rtnCostoFinalAcumulado.Fecha > itemBom.FechaCosto)
                                rtnCostoFinalAcumulado.Fecha = itemBom.FechaCosto;
                        }
                    }
                }
                rtnCostoFinalAcumulado.LevelMax++;
                return rtnCostoFinalAcumulado;
            }
        }
    }
}