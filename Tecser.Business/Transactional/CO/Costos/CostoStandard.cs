using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.Costos
{
    public class CostoStandard : CostoBaseManager
    {
        public enum CostDeterminatedBy
        {
            Manual,
            MRepo,
            MForm,
            CRoll_Repo,
            CRoll_Form
        };

        public void AddUpdateCosto(string material, string moneda, decimal costoStandard, decimal tc,
            bool manualUpdated,CostDeterminatedBy cdet)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var matData = MaterialMasterManager.GetSpecificPrimaryInformation(material);
                var mat = db.T0039_CostoStandard.SingleOrDefault(c => c.Material == material);
                if (mat == null)
                {
                    //El Material no existe en la T0039 - 
                    //Crea el Registro con Var.=0
                    var xm = new T0039_CostoStandard()
                    {
                        Material = material,
                        Origen = matData.ORIGEN,
                        MonedaCosto = moneda,
                        FechaCosto = DateTime.Today,
                        MType = matData.TIPO_MATERIAL,
                        CostoArsOld = 0,
                        CostoUsdOld = 0,
                        FechaCostoOld = DateTime.Today,
                        VarCostoArs = 0,
                        VarCostoUsd = 0,
                        ManualUpdated = manualUpdated,
                        FechaCostRoll = DateTime.Today,
                        CostDetBy = cdet.ToString(),
                        DeltaUsd1 = 0,
                        DeltaUsd2 = 0,
                        UpdatedBy = null
                    };
                    if (moneda == @"USD")
                    {
                        xm.CostoUsd = costoStandard;
                        xm.CostoArs = decimal.Round((costoStandard * tc), 3);
                    }
                    else
                    {
                        xm.CostoArs = costoStandard;
                        xm.CostoUsd = decimal.Round((costoStandard / tc), 3);
                    }

                    db.T0039_CostoStandard.Add(xm);
                    db.SaveChanges();
                }
                else
                {
                    //El Registro Existe pero solo actualiza si hubo variacion de Costos
                    if (mat.MonedaCosto == moneda)
                    {
                        //la moneda es la mismo - verifico si hubo variacion
                        //de Costos
                        if (moneda == @"USD")
                        {
                            if (costoStandard == mat.CostoUsd)
                            {
                                //Se mantiene el mismo costo pero actualizo por TC
                                //sin loguear el update
                                var nuevoCostoArs = decimal.Round((costoStandard * tc), 3);
                                mat.VarCostoArs = nuevoCostoArs - mat.CostoArsOld;
                                mat.CostoArsOld = mat.CostoArs;
                                mat.CostoArs = nuevoCostoArs;
                            }
                            else
                            {
                                //hubo variacion de costo en moneda-costo [USD]
                                var nuevoCostoArs = decimal.Round((costoStandard * tc), 3);
                                mat.VarCostoArs = nuevoCostoArs - mat.CostoArsOld;
                                mat.CostoArsOld = mat.CostoArs;
                                mat.CostoArs = nuevoCostoArs;

                                mat.VarCostoUsd = costoStandard - mat.CostoUsdOld;
                                mat.CostoUsdOld = mat.CostoUsd;
                                mat.CostoUsd = costoStandard;

                                mat.UpdatedBy = Environment.UserName;
                                mat.UpdatedOn = DateTime.Now;
                            }
                        }
                        else
                        {
                            //Estamos en costo ARS
                            if (costoStandard == mat.CostoUsd)
                            {
                                //Se mantiene el mismo costo pero actualizo por TC el costo USD
                                //sin loguear el update
                                var nuevoCostoUsd = decimal.Round((costoStandard / tc), 3);
                                mat.VarCostoUsd = nuevoCostoUsd - mat.CostoUsdOld;
                                mat.CostoUsdOld = mat.CostoUsd;
                                mat.CostoUsd = nuevoCostoUsd;
                            }
                            else
                            {
                                //hubo variacion de costo en moneda-costo [ARS]
                                var nuevoCostoUsd = decimal.Round((costoStandard * tc), 3);
                                mat.VarCostoUsd = nuevoCostoUsd - mat.CostoUsdOld;
                                mat.CostoUsdOld = mat.CostoUsd;
                                mat.CostoUsd = nuevoCostoUsd;

                                mat.VarCostoArs = costoStandard - mat.CostoArsOld;
                                mat.CostoArsOld = mat.CostoArs;
                                mat.CostoArs = costoStandard;

                                mat.UpdatedBy = Environment.UserName;
                                mat.UpdatedOn = DateTime.Now;
                            }
                        }
                    }
                    else
                    {
                        //Ya esta modificando la moneda del costo por lo tanto
                        //actualizo everythin y logue como cambio de costo
                        //la moneda es la mismo - verifico si hubo variacion
                        //de Costos
                        if (moneda == @"USD")
                        {
                            //hubo variacion de costo en moneda-costo [USD]
                            var nuevoCostoArs = decimal.Round((costoStandard * tc), 3);
                            mat.VarCostoArs = nuevoCostoArs - mat.CostoArsOld;
                            mat.CostoArsOld = mat.CostoArs;
                            mat.CostoArs = nuevoCostoArs;

                            mat.VarCostoUsd = costoStandard - mat.CostoUsdOld;
                            mat.CostoUsdOld = mat.CostoUsd;
                            mat.CostoUsd = costoStandard;

                            mat.UpdatedBy = Environment.UserName;
                            mat.UpdatedOn = DateTime.Now;
                        }
                        else
                        {
                            //hubo variacion de costo en moneda-costo [ARS]
                            var nuevoCostoUsd = decimal.Round((costoStandard * tc), 3);
                            mat.VarCostoUsd = nuevoCostoUsd - mat.CostoUsdOld;
                            mat.CostoUsdOld = mat.CostoUsd;
                            mat.CostoUsd = nuevoCostoUsd;

                            mat.VarCostoArs = costoStandard - mat.CostoArsOld;
                            mat.CostoArsOld = mat.CostoArs;
                            mat.CostoArs = costoStandard;

                            mat.UpdatedBy = Environment.UserName;
                            mat.UpdatedOn = DateTime.Now;
                        }
                    }
                }
                db.SaveChanges();
            }
        }

        public Costo GetCosto(string material,decimal tc=0)
        {
            if (tc <= 0)
                tc = new ExchangeRateManager().GetExchangeRate(DateTime.Today);

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var costData = db.T0039_CostoStandard.SingleOrDefault(c => c.Material == material);
                if (costData == null)
                {
                    AddUpdateCosto(material,"USD",99999,1,true,CostDeterminatedBy.Manual);
                    var respNull = new Costo()
                    {
                        CostoUSD = 99999,
                        CostoARS = 99999,
                        Moneda = "USD",
                        FechaCosto = DateTime.Today,
                        UsuarioLog = Environment.UserName
                    };
                    return respNull;
                }
                Costo resp = default;
                if (costData.MonedaCosto ==@"USD")
                {
                    resp.CostoUSD = costData.CostoUsd;
                    resp.CostoARS = decimal.Round((costData.CostoUsd * tc), 3);
                    resp.Moneda = costData.MonedaCosto;
                    resp.FechaCosto = costData.FechaCosto;
                    resp.UsuarioLog = costData.UpdatedBy;
                }
                else
                {
                    resp.CostoARS = costData.CostoArs;
                    resp.CostoUSD = decimal.Round((costData.CostoArs / tc), 3);
                    resp.Moneda = costData.MonedaCosto;
                    resp.FechaCosto = costData.FechaCosto;
                    resp.UsuarioLog = costData.UpdatedBy;
                }
                return resp;
            }
        }

        


    
    }
}
