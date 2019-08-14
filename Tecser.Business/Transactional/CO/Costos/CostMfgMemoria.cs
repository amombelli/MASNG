using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.CO.Costos
{
    public class CostMfgMemoria
    {
        //---------------------------------------------------------------------------------
        public List<CostItems> CostItems   { get; private set; }
        public List<CostHeader> CostHeader {  get; private set; }
        public decimal CostoUSD { get; private set; }
        public decimal CostoARS { get; private set; }
        public CostoBaseManager.TipoCosto TipoCosto { get; private set; }
        private decimal _tc;
        //---------------------------------------------------------------------------------

        public CostMfgMemoria()
        {
            CostHeader = new List<CostHeader>();
            CostItems = new List<CostItems>();
        }

        private bool ExplosionFormulaCompletaMemoria(int idFormula, string monedaCost, decimal tc, decimal multiplicador = 1)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var f0 = db.T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == idFormula);
                var x = new CostHeader()
                {
                    Material = f0.IDMATERIAL,
                    Costo = 0,
                    Moneda = monedaCost,
                    Origen = f0.T0010_MATERIALES.ORIGEN,
                    Fcost = idFormula,
                    CalculoOk = false
                };
                CostHeader.Add(x);

                var fi = db.T0021_FORMULA_I.Where(c => c.FORMULA == x.Fcost.Value).ToList();
                foreach (var i in fi)
                {
                    if (i.T0010_MATERIALES.ORIGEN == "FAB")
                    {
                        if (i.T0010_MATERIALES.FORM_COSTO == null || i.T0010_MATERIALES.FORM_COSTO.Value <= 0)
                        {
                            var explo = new CostItems()
                            {
                                Moneda = monedaCost,
                                MaterialF = i.ITEM,
                                ItemMP = i.ITEM,
                                Prop = multiplicador * i.CANTIDAD_PORC.Value,
                                CostoProp = 999999,
                                CostoUnit = 999999
                            };
                            CostItems.Add(explo);
                        }
                        else
                        {
                            ExplosionFormulaCompletaMemoria(i.T0010_MATERIALES.FORM_COSTO.Value, monedaCost, tc, i.CANTIDAD_PORC.Value * multiplicador);
                        }
                    }
                    else
                    {
                        var explo = new CostItems()
                        {
                            Moneda = monedaCost,
                            MaterialF = i.T0020_FORMULA_H.IDMATERIAL,
                            ItemMP = i.ITEM,
                            Prop = multiplicador * i.CANTIDAD_PORC.Value,
                            CostoProp = 0,
                            CostoUnit = 0
                        };
                        CostItems.Add(explo);
                    }
                    var ix = new CostItems()
                    {
                        Moneda = monedaCost,
                        MaterialF = i.T0020_FORMULA_H.IDMATERIAL,
                        ItemMP = i.ITEM,
                        Prop = i.CANTIDAD_PORC.Value,
                        CostoProp = 0,
                        CostoUnit = 0
                    };
                }
            }
            return true;
        }
        private void CompletaCostos(string monedaCost, decimal tc)
        {
            decimal costoProducto = 0;
            foreach (var item in CostItems)
            {
                var xcosto = new CostoReposicion().GetCosto(item.ItemMP, tc, true);
                item.CostoUnit = monedaCost == "USD" ? xcosto.USD : xcosto.ARS;
                item.CostoProp = item.CostoUnit * item.Prop;
                costoProducto = costoProducto + item.CostoProp;
            }

            if (monedaCost == "USD")
            {
                CostoUSD = costoProducto;
                CostoARS = decimal.Round(costoProducto * tc, 3);
            }
            else
            {
                CostoARS = costoProducto;
                CostoUSD = decimal.Round((costoProducto / tc), 3);
            }
        }
        public void CalculaMfgCost(int idFormula, string monedaCost, decimal tc)
        {
            _tc = tc;
            ExplosionFormulaCompletaMemoria(idFormula, monedaCost, tc, 1);
            CompletaCostos(monedaCost, tc);
        }



    }
}
