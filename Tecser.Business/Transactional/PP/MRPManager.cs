using System;
using System.Linq;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.SD;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.Transactional.PP
{
    public class MrpManager
    {
        public MrpManager()
        {
        }

        public MrpManager(string material)
        {
            var primario = _materialMaster.GetPrimarioFromAka(material);
            if (primario == material.ToUpper())
            {
                _primarioSelecionado = MaterialMasterManager.GetSpecificPrimaryInformation(primario);
            }
        }

        private readonly MaterialMasterManager _materialMaster = new MaterialMasterManager();
        private T0010_MATERIALES _primarioSelecionado = new T0010_MATERIALES();

        /// <summary>
        /// Manda a fabricar o realiza RC de acuerdo al origen de un material
        /// </summary>
        /// <returns></returns>
        public string AddMrpAuto(string materialAka, decimal cantidadKg, DateTime fechaCompromiso,
            string observacionesParaPfrc, string planta, int numeroOv = 0, bool urgente = false)
        {
            //Obtiene el primario. Si origen = FAB manda el PF sino manda la RC
            var materialPrimario = new MaterialMasterManager().GetPrimarioFromAka(materialAka);
            var primarioData = MaterialMasterManager.GetSpecificPrimaryInformation(materialPrimario);
            if (primarioData != null)
            {
                if (primarioData.ORIGEN == "FAB")
                {
                    string clienteFantasia = null;
                    if (numeroOv > 0)
                    {
                        clienteFantasia = new SalesOrderManager().GetCustomerFantasiaFromOrdenVenta(numeroOv);
                    }

                    var numeroOf = new PlanProduccionManager().AddPlanProduccion(materialPrimario, materialAka, cantidadKg, numeroOv,
                    fechaCompromiso, observacionesParaPfrc, planta, PlanProduccionManager.MotivoFabricacion.OrdenVenta,
                    clienteFantasia,urgente);

                    if (numeroOf > 0)
                    {
                        return "OF@" + numeroOf;
                    }
                    return null;
                }
                else
                {
                    //funcion mrp para RC //todo:falta hacer funcion para MRP RC
                    return null;
                }
            }
            else
            {
                //No se encontro el material primario
                return null;
            }
        }

        public static int CantidadClientesLlevanMaterial(string materialAKA, int vecesMinimo = 2, int periodoDias = 180)
        {
            if (vecesMinimo < 1)
            {
                vecesMinimo = 1;
            }

            if (periodoDias < 1)
            {
                periodoDias = 1;
            }

            var fecha1 = DateTime.Today.AddDays(-periodoDias);

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var p = from mov in db.T0040_MAT_MOVIMIENTOS
                    where (mov.TIPOMOVIMIENTO == 50 || mov.TIPOMOVIMIENTO == 51) && (mov.FECHAMOV >= fecha1)
                    group mov by new
                    {
                        mov.IDMATERIAL,
                        mov.IDCLI
                    }
                    into grp
                    where
                        grp.Key.IDMATERIAL.ToUpper().Equals(materialAKA.ToUpper()) &&
                        grp.Key.IDMATERIAL.Count() > vecesMinimo
                    select new
                    {
                        CLI = grp.Key.IDCLI,
                        MAT = grp.Key.IDMATERIAL.Count()
                    };


                return 1;

                //return (int) p.Count(c => c.MAT);
            }
        }


        public static decimal ConsumoPromedioMateriaPrimaProduccion30(string primario, int periodoDias = 180)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var fecha1 = DateTime.Today.AddDays(-periodoDias);
                var p = from mov in db.T0040_MAT_MOVIMIENTOS
                    where
                        (mov.TIPOMOVIMIENTO == 10 || mov.TIPOMOVIMIENTO == 11) &&
                        (mov.FECHAMOV >= fecha1)
                    group mov by new
                    {
                        mov.IDMATERIAL
                    }
                    into grp
                    where grp.Key.IDMATERIAL.ToUpper().Equals(primario.ToUpper())
                    select new
                    {
                        KG = (decimal) grp.Sum(x => x.CANTIDAD)
                    };
                var a = p.Sum(c => c.KG);

                return decimal.Round(a/periodoDias*30, 2);
            }
        }


        public static decimal ConsumoPromedioMaterialDespachado30(string primario, int periodoDias = 180)
        {
            var a = ConsumoMaterialDespachado(primario, periodoDias);
            return decimal.Round(a/periodoDias*30, 2);
        }

        /// <summary>
        /// Calcula el consumo promedio de un PT considerando movimientos 50,51 y devoluciones (5,6,7)
        /// </summary>
        /// <returns></returns>
        public static decimal ConsumoMaterialDespachado(string primario, int periodoDias = 180)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var fecha1 = DateTime.Today.AddDays(-periodoDias);
                var p = from mov in db.T0040_MAT_MOVIMIENTOS
                    where
                        (mov.TIPOMOVIMIENTO == 50 || mov.TIPOMOVIMIENTO == 51 || mov.TIPOMOVIMIENTO == 5 ||
                         mov.TIPOMOVIMIENTO == 6 || mov.TIPOMOVIMIENTO == 7) &&
                        (mov.FECHAMOV >= fecha1)
                    group mov by new
                    {
                        mov.IDMATERIAL
                    }
                    into grp
                    where grp.Key.IDMATERIAL.ToUpper().Equals(primario.ToUpper())
                    select new
                    {
                        KG = (decimal) grp.Sum(x => x.CANTIDAD)
                    };
                return p.Sum(c => c.KG);
            }
        }


        public static decimal ConsumoTotalMaterial(string primario, int periodoDias = 180)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var fecha1 = DateTime.Today.AddDays(-periodoDias);
                //var p = from mov in db.T0040_MAT_MOVIMIENTOS
                //        where
                //            (mov.TIPOMOVIMIENTO == 50 || mov.TIPOMOVIMIENTO == 51 || mov.TIPOMOVIMIENTO == 5 ||
                //             mov.TIPOMOVIMIENTO == 6 || mov.TIPOMOVIMIENTO == 7 || mov.TIPOMOVIMIENTO == 10 || mov.TIPOMOVIMIENTO == 11) &&
                //            (mov.FECHAMOV >= fecha1)
                //        group mov by new
                //        {
                //            mov.IDMATERIAL
                //        }
                //            into grp
                //            where grp.Key.IDMATERIAL.ToUpper().Equals(primario.ToUpper())
                //            select new
                //            {
                //                KG = (decimal)grp.Sum(x => x.CANTIDAD)
                //            };
                //return p.Sum(c => c.KG);
                return (decimal) 0;
            }
        }


        public static decimal ConsumoPromedioTotalMaterial(string primario, int periodoDias = 180)
        {
            var a = ConsumoTotalMaterial(primario, periodoDias);
            return decimal.Round(a/periodoDias*30, 2);
        }
    }
}
