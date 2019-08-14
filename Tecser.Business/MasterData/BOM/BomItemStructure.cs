using System.Collections.Generic;
using System.Linq;
using TecserEF.Entity;using Tecser.Business.MainApp;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.MasterData.BOM
{
    public class BomItemStructure
    {
        public List<BomItemsStructure> GetFormulaItems(int idFormula)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var itemList = from it in db.T0021_FORMULA_I
                               where it.FORMULA == idFormula
                               orderby it.ID_ITEM ascending
                               select new BomItemsStructure()
                               {
                                   Cantidad = it.CANTIDAD.Value,
                                   IdItem = it.ID_ITEM,
                                   Secuencia = it.Secuencia.Value,
                                   CantidadPorcentaje = it.CANTIDAD_PORC.Value,
                                   DescripcionMaterial = it.T0010_MATERIALES.MAT_DESC,
                                   IdFormula = it.FORMULA,
                                   Item = it.ITEM,
                                   UoM = it.T0010_MATERIALES.UNIDAD,
                                   DescripcionLaboratorio =  it.T0010_MATERIALES.MAT_DESC2,
                                   Explota = it.Explota,
                                   ExplotaVersion = it.ExplotaVer
                               };
                return itemList.ToList();
            }
        }
    }
}
